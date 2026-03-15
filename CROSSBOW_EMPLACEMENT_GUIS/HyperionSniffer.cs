// HyperionSniffer.cs  —  Fake THEIA listener / HYPERION output verifier
//
// Binds UDP:10009, receives EXT_OPS framed CUE packets (CMD 0xAA, 71 bytes)
// forwarded by HYPERION to THEIA. Validates frame integrity and payload field
// ranges, then raises events for the UI and the VerificationLog.
//
// Single-machine setup:
//   HYPERION must be configured to send its CUE output to 127.0.0.1:10009.
//   SensorSim injects via port 10032 (aLORA) — no conflict with this listener.
//
// Verification checks performed on every received frame:
//   FRAME  1 — Total length == 71 bytes
//   FRAME  2 — Magic == 0xCB 0x48
//   FRAME  3 — CMD == 0xAA
//   FRAME  4 — PAYLOAD_LEN == 62
//   FRAME  5 — CRC-16/CCITT valid
//   FRAME  6 — SEQ_NUM monotonically increasing (rollover allowed at 0xFFFF→0)
//   FIELD  7 — Latitude  in [-90, +90]
//   FIELD  8 — Longitude in [-180, +180]
//   FIELD  9 — Altitude HAE > -500 m (below Dead Sea) and < 100000 m
//   FIELD 10 — Heading in [0, 360)
//   FIELD 11 — Speed >= 0 m/s
//   FIELD 12 — Track CMD == 0x01 (TRACK) for normal update packets
//   FIELD 13 — Timestamp is recent (within 10 s of local UTC)

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CROSSBOW;

namespace CROSSBOW_EMPLACEMENT_GUIS
{
    // ── Result types ──────────────────────────────────────────────────────────

    public enum VerifyResult { Pass, Fail, Warning }

    public class VerifyCheck
    {
        public int          Id       { get; set; }
        public string       Name     { get; set; } = "";
        public VerifyResult Result   { get; set; }
        public string       Detail   { get; set; } = "";

        public override string ToString() =>
            $"[{(Result == VerifyResult.Pass ? "PASS" : Result == VerifyResult.Fail ? "FAIL" : "WARN")}] " +
            $"#{Id:D2} {Name}" +
            (string.IsNullOrEmpty(Detail) ? "" : $" — {Detail}");
    }

    public class CapturedCuePacket
    {
        // Raw
        public byte[]  RawFrame      { get; set; } = Array.Empty<byte>();
        public ushort  SeqNum        { get; set; }
        public DateTime ReceivedAt   { get; set; } = DateTime.UtcNow;

        // Parsed payload fields
        public long    MsTimestamp   { get; set; }
        public string  TrackId       { get; set; } = "";
        public byte    TrackClass    { get; set; }
        public byte    TrackCmd      { get; set; }
        public double  Latitude      { get; set; }
        public double  Longitude     { get; set; }
        public float   AltHAE        { get; set; }
        public float   Heading       { get; set; }
        public float   Speed         { get; set; }
        public float   Vz            { get; set; }

        // Verification results
        public VerifyCheck[] Checks  { get; set; } = Array.Empty<VerifyCheck>();
        public bool          AllPass => Array.TrueForAll(Checks,
                                            c => c.Result != VerifyResult.Fail);
    }

    // ── HyperionSniffer ───────────────────────────────────────────────────────

    public class HyperionSniffer : IDisposable
    {
        // ── Configuration ────────────────────────────────────────────────────
        public const int LISTEN_PORT      = 10009;
        private const int RECV_TIMEOUT_MS = 1000;

        // Timestamp staleness threshold — flag if HYPERION packet timestamp is
        // more than this many milliseconds from local UTC.
        private const long TIMESTAMP_STALENESS_MS = 10_000;

        // ── State ────────────────────────────────────────────────────────────
        private UdpClient?     _udp;
        private Thread?        _thread;
        private volatile bool  _running = false;
        private bool           _disposed = false;

        // SEQ_NUM tracking — detect out-of-order or non-monotonic increments
        private bool   _firstPacket = true;
        private ushort _lastSeq     = 0;

        // Counters
        public int PacketsReceived { get; private set; } = 0;
        public int PacketsPassed   { get; private set; } = 0;
        public int PacketsFailed   { get; private set; } = 0;

        // ── Events ────────────────────────────────────────────────────────────
        /// <summary>Raised for every received and verified packet.</summary>
        public event Action<CapturedCuePacket>? PacketReceived;

        /// <summary>Raised when any verification check fails.</summary>
        public event Action<CapturedCuePacket>? VerifyFailed;

        // ── Lifecycle ─────────────────────────────────────────────────────────
        public bool IsRunning => _running;

        public void Start()
        {
            if (_running) return;
            _running     = true;
            _firstPacket = true;

            _udp = new UdpClient(new IPEndPoint(IPAddress.Any, LISTEN_PORT));
            _udp.Client.ReceiveTimeout = RECV_TIMEOUT_MS;

            _thread = new Thread(ListenThread)
            {
                IsBackground = true,
                Name         = "HyperionSniffer"
            };
            _thread.Start();

            Debug.WriteLine($"[HyperionSniffer] Listening on UDP:{LISTEN_PORT}");
        }

        public void Stop()
        {
            if (!_running) return;
            _running = false;
            try { _udp?.Close(); } catch { }
            _thread?.Join(2000);
            Debug.WriteLine("[HyperionSniffer] Stopped");
        }

        public void Dispose()
        {
            if (!_disposed) { Stop(); _disposed = true; }
        }

        public void ResetCounters()
        {
            PacketsReceived = 0;
            PacketsPassed   = 0;
            PacketsFailed   = 0;
            _firstPacket    = true;
        }

        // ── Listen thread ─────────────────────────────────────────────────────
        private void ListenThread()
        {
            var remoteEP = new IPEndPoint(IPAddress.Any, 0);

            while (_running)
            {
                try
                {
                    byte[] buf = _udp!.Receive(ref remoteEP);
                    PacketsReceived++;

                    var packet = ParseAndVerify(buf);

                    if (packet.AllPass)
                        PacketsPassed++;
                    else
                    {
                        PacketsFailed++;
                        VerifyFailed?.Invoke(packet);
                    }

                    PacketReceived?.Invoke(packet);
                }
                catch (SocketException) { /* timeout — loop */ }
                catch (ObjectDisposedException) { break; }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[HyperionSniffer] Error: {ex.Message}");
                }
            }
        }

        // ── Verify pipeline ───────────────────────────────────────────────────
        private CapturedCuePacket ParseAndVerify(byte[] buf)
        {
            var packet = new CapturedCuePacket
            {
                RawFrame    = buf,
                ReceivedAt  = DateTime.UtcNow,
            };

            var checks = new System.Collections.Generic.List<VerifyCheck>();

            // ── FRAME CHECK 1: total length ───────────────────────────────────
            bool lenOk = buf.Length == ExtOpsFrame.FRAME_LEN_CUE;
            checks.Add(new VerifyCheck
            {
                Id     = 1,
                Name   = "Frame length == 71",
                Result = lenOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = lenOk ? $"{buf.Length} B" : $"got {buf.Length} B, expected {ExtOpsFrame.FRAME_LEN_CUE}"
            });

            if (!lenOk)
            {
                packet.Checks = checks.ToArray();
                return packet; // can't safely parse further
            }

            // ── FRAME CHECK 2: magic ──────────────────────────────────────────
            bool magicOk = buf[0] == ExtOpsFrame.MAGIC_HI && buf[1] == ExtOpsFrame.MAGIC_LO;
            checks.Add(new VerifyCheck
            {
                Id     = 2,
                Name   = "Magic == 0xCB 0x48",
                Result = magicOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = magicOk ? "OK" : $"got 0x{buf[0]:X2} 0x{buf[1]:X2}"
            });

            // ── FRAME CHECK 3: CMD byte ───────────────────────────────────────
            bool cmdOk = buf[2] == ExtOpsFrame.CMD_CUE_INBOUND;
            checks.Add(new VerifyCheck
            {
                Id     = 3,
                Name   = "CMD == 0xAA",
                Result = cmdOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = cmdOk ? "OK" : $"got 0x{buf[2]:X2}"
            });

            // ── FRAME CHECK 4: PAYLOAD_LEN ────────────────────────────────────
            ushort payloadLen = (ushort)(buf[5] | (buf[6] << 8));
            bool   plenOk    = payloadLen == ExtOpsFrame.PAYLOAD_LEN_CUE;
            checks.Add(new VerifyCheck
            {
                Id     = 4,
                Name   = "PAYLOAD_LEN == 62",
                Result = plenOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = plenOk ? "OK" : $"got {payloadLen}"
            });

            // ── FRAME CHECK 5: CRC ────────────────────────────────────────────
            ushort crcRx   = (ushort)(buf[69] | (buf[70] << 8));
            ushort crcCalc = ExtOpsFrame.Crc16(buf, 0, ExtOpsFrame.HDR_LEN + ExtOpsFrame.PAYLOAD_LEN_CUE);
            bool   crcOk   = crcRx == crcCalc;
            checks.Add(new VerifyCheck
            {
                Id     = 5,
                Name   = "CRC-16/CCITT valid",
                Result = crcOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = crcOk ? $"0x{crcCalc:X4}" : $"rx=0x{crcRx:X4} calc=0x{crcCalc:X4}"
            });

            // ── FRAME CHECK 6: SEQ_NUM monotonic ─────────────────────────────
            ushort seq    = (ushort)(buf[3] | (buf[4] << 8));
            packet.SeqNum = seq;
            bool seqOk;
            string seqDetail;
            if (_firstPacket)
            {
                seqOk     = true;
                seqDetail = $"{seq} (first packet)";
                _firstPacket = false;
            }
            else
            {
                ushort expected = (ushort)(_lastSeq + 1); // wraps at 0xFFFF→0
                seqOk     = seq == expected;
                seqDetail = seqOk
                    ? $"{seq}"
                    : $"got {seq}, expected {expected} (delta={(seq - _lastSeq + 65536) % 65536})";
            }
            _lastSeq = seq;
            checks.Add(new VerifyCheck
            {
                Id     = 6,
                Name   = "SEQ_NUM monotonic",
                Result = seqOk ? VerifyResult.Pass : VerifyResult.Warning,
                Detail = seqDetail
            });

            // ── Parse payload (only if frame checks pass) ─────────────────────
            if (!magicOk || !cmdOk || !plenOk || !crcOk)
            {
                packet.Checks = checks.ToArray();
                return packet;
            }

            // Extract 62-byte payload
            byte[] p = new byte[ExtOpsFrame.PAYLOAD_LEN_CUE];
            Buffer.BlockCopy(buf, ExtOpsFrame.HDR_LEN, p, 0, ExtOpsFrame.PAYLOAD_LEN_CUE);

            long   msTs    = ExtOpsFrame.ReadInt64 (p, 0);
            byte[] idBytes = new byte[8];
            Buffer.BlockCopy(p, 8, idBytes, 0, 8);
            string trackId = Encoding.ASCII.GetString(idBytes).TrimEnd('\0');
            byte   tClass  = p[16];
            byte   tCmd    = p[17];
            double lat     = ExtOpsFrame.ReadDouble(p, 18);
            double lng     = ExtOpsFrame.ReadDouble(p, 26);
            float  alt     = ExtOpsFrame.ReadFloat (p, 34);
            float  hdg     = ExtOpsFrame.ReadFloat (p, 38);
            float  spd     = ExtOpsFrame.ReadFloat (p, 42);
            float  vz      = ExtOpsFrame.ReadFloat (p, 46);

            packet.MsTimestamp = msTs;
            packet.TrackId     = trackId;
            packet.TrackClass  = tClass;
            packet.TrackCmd    = tCmd;
            packet.Latitude    = lat;
            packet.Longitude   = lng;
            packet.AltHAE      = alt;
            packet.Heading     = hdg;
            packet.Speed       = spd;
            packet.Vz          = vz;

            // ── FIELD CHECK 7: latitude ───────────────────────────────────────
            bool latOk = lat >= -90.0 && lat <= 90.0;
            checks.Add(new VerifyCheck
            {
                Id     = 7,
                Name   = "Latitude in [-90, +90]",
                Result = latOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = $"{lat:F6}°"
            });

            // ── FIELD CHECK 8: longitude ──────────────────────────────────────
            bool lngOk = lng >= -180.0 && lng <= 180.0;
            checks.Add(new VerifyCheck
            {
                Id     = 8,
                Name   = "Longitude in [-180, +180]",
                Result = lngOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = $"{lng:F6}°"
            });

            // ── FIELD CHECK 9: altitude ───────────────────────────────────────
            bool altOk = alt > -500f && alt < 100_000f;
            checks.Add(new VerifyCheck
            {
                Id     = 9,
                Name   = "Altitude HAE in (-500, 100000) m",
                Result = altOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = $"{alt:F1} m"
            });

            // ── FIELD CHECK 10: heading ───────────────────────────────────────
            bool hdgOk = hdg >= 0f && hdg < 360f;
            checks.Add(new VerifyCheck
            {
                Id     = 10,
                Name   = "Heading in [0, 360)",
                Result = hdgOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = $"{hdg:F2}°"
            });

            // ── FIELD CHECK 11: speed ─────────────────────────────────────────
            bool spdOk = spd >= 0f;
            checks.Add(new VerifyCheck
            {
                Id     = 11,
                Name   = "Speed >= 0 m/s",
                Result = spdOk ? VerifyResult.Pass : VerifyResult.Fail,
                Detail = $"{spd:F2} m/s"
            });

            // ── FIELD CHECK 12: Track CMD == TRACK(1) ─────────────────────────
            bool cmdValOk = tCmd == (byte)ExtOpsFrame.TrackCmd.Track;
            checks.Add(new VerifyCheck
            {
                Id     = 12,
                Name   = "Track CMD == 0x01 (TRACK)",
                Result = cmdValOk ? VerifyResult.Pass : VerifyResult.Warning,
                Detail = cmdValOk ? "TRACK" : $"0x{tCmd:X2} ({(ExtOpsFrame.TrackCmd)tCmd})"
            });

            // ── FIELD CHECK 13: timestamp freshness ───────────────────────────
            long nowMs    = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long deltaMs  = Math.Abs(nowMs - msTs);
            bool tsOk     = deltaMs < TIMESTAMP_STALENESS_MS;
            checks.Add(new VerifyCheck
            {
                Id     = 13,
                Name   = $"Timestamp fresh (< {TIMESTAMP_STALENESS_MS / 1000} s)",
                Result = tsOk ? VerifyResult.Pass : VerifyResult.Warning,
                Detail = $"delta={deltaMs} ms"
            });

            packet.Checks = checks.ToArray();
            return packet;
        }
    }
}
