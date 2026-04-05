// SensorSim.cs  —  CUE SIM sensor injection into HYPERION
//
// Sends EXT_OPS framed CUE packets (CMD 0xAA, 71 bytes) to HYPERION's aLORA
// listener on UDP:10032. HYPERION ingests these identically to a real LoRa
// sensor via RADAR.ParseMsg → trackMSG(payload, "LORA", vzPositiveUp=false).
//
// Port strategy (15000 block — EXT_OPS tier):
//   Port 15001 — HYPERION aRADAR sensor input  (SensorSim sends here)
//   Port 15002 — HYPERION aLORA sensor input
//   Port 15009 — THEIA CueReceiver             (no conflict)
//   Port 15010 — HYPERION CUE output → THEIA   (no conflict)
//
// Single-machine testing is clean — all ports distinct, no rebind conflicts.
//
// ⚠ vz sign: aLORA uses vzPositiveUp=false — HYPERION negates received vz.
//   SensorSim always sends vz=0.0f so the sign flip has no effect.
//   If non-zero vz is ever needed, send the NEGATIVE of the desired climb rate.
//
// ⚠ ICAO: aLORA sets ICAO = "LORA" for all tracks (BaseICAO="LORA").
//   The injected trackId bytes become CallSign, not ICAO, in HYPERION's trackLog.

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using CROSSBOW;

namespace CROSSBOW_EMPLACEMENT_GUIS
{
    public class SensorSim : IDisposable
    {
        // ── Configuration ─────────────────────────────────────────────────────
        /// <summary>
        /// HYPERION sensor input ports — 15000 block (EXT_OPS tier).
        /// HYPERION_RADAR_PORT (15001) — primary injection target for CUE SIM.
        /// HYPERION_LORA_PORT  (15002) — LoRa/MAVLink sensor input.
        /// Both are safe to use simultaneously on a single machine —
        /// no conflict with THEIA CueReceiver (15009) or HYPERION CUE output (15010).
        /// </summary>
        public const int HYPERION_RADAR_PORT = 15001;
        public const int HYPERION_LORA_PORT = 15002;

        // ── State ─────────────────────────────────────────────────────────────
        private readonly string  _hyperionHost;
        private readonly int     _port;
        private UdpClient?       _udp;
        private ushort           _seq = 0;
        private bool             _disposed = false;

        // Packet counters (for UI / verification)
        public int  PacketsSent    { get; private set; } = 0;
        public long LastSentMs     { get; private set; } = 0;

        // ── Constructor ───────────────────────────────────────────────────────
        /// <param name="hyperionHost">IP of machine running HYPERION (127.0.0.1 for single-machine).</param>
        /// <param name="port">
        ///   Injection port. Defaults to HYPERION_RADAR_PORT (15001) — HYPERION aRADAR sensor input.
        ///   Override to HYPERION_LORA_PORT (15002) to inject via aLORA path instead.
        ///   Both ports are safe on a single machine — no conflict with THEIA (15009).
        /// </param>
        public SensorSim(string hyperionHost = "127.0.0.1", int port = HYPERION_RADAR_PORT)
        {
            _hyperionHost = hyperionHost;
            _port = port;
        }

        // ── Lifecycle ─────────────────────────────────────────────────────────
        public void Start()
        {
            _udp = new UdpClient();
            _udp.Connect(_hyperionHost, _port);
            Debug.WriteLine($"[SensorSim] Ready → {_hyperionHost}:{_port}");
        }

        public void Stop()
        {
            try { _udp?.Close(); } catch { }
            _udp = null;
            Debug.WriteLine("[SensorSim] Stopped");
        }

        public void Dispose()
        {
            if (!_disposed) { Stop(); _disposed = true; }
        }

        // ── Send helpers ──────────────────────────────────────────────────────

        /// <summary>
        /// Inject a TRACK update into HYPERION. Call this from frmCUESim.timUDP_Tick.
        /// </summary>
        /// <param name="trackId">
        ///   8-char ASCII ID. Becomes CallSign in HYPERION's trackLog (not ICAO —
        ///   aLORA forces ICAO = "LORA" for all LoRa-injected tracks).
        /// </param>
        /// <param name="trackClass">Target classification.</param>
        /// <param name="lat">WGS-84 latitude, degrees.</param>
        /// <param name="lng">WGS-84 longitude, degrees.</param>
        /// <param name="altHAE">Altitude HAE, metres. Do NOT use MSL.</param>
        /// <param name="heading">True heading 0–360°, North=0.</param>
        /// <param name="speed">Ground speed m/s.</param>
        /// <param name="vz">
        ///   Vertical speed m/s, positive=climbing (ENU convention).
        ///   ⚠ aLORA negates this before Kalman update. Keep 0.0f unless you
        ///   intentionally compensate.
        /// </param>
        public void SendTrack(
            string   trackId,
            ExtOpsFrame.TrackClass trackClass,
            double   lat,
            double   lng,
            float    altHAE,
            float    heading,
            float    speed,
            float    vz = 0.0f)
            => Send(trackId, trackClass, ExtOpsFrame.TrackCmd.Track,
                    lat, lng, altHAE, heading, speed, vz);

        /// <summary>Send DROP — clears the LORA track from HYPERION's trackLogs.</summary>
        public void SendDrop()
            => Send("", ExtOpsFrame.TrackClass.None, ExtOpsFrame.TrackCmd.Drop,
                    0, 0, 0, 0, 0, 0);

        // ── Core send ─────────────────────────────────────────────────────────
        private void Send(
            string trackId,
            ExtOpsFrame.TrackClass trackClass,
            ExtOpsFrame.TrackCmd trackCmd,
            double lat, double lng, float altHAE,
            float heading, float speed, float vz)
        {
            if (_udp == null)
            {
                Debug.WriteLine("[SensorSim] Not started — call Start() first");
                return;
            }

            try
            {
                byte[] payload = BuildPayload(trackId, trackClass, trackCmd,
                                              lat, lng, altHAE, heading, speed, vz);
                byte[] frame = ExtOpsFrame.BuildFrame(ExtOpsFrame.CMD_CUE_INBOUND,
                                                        _seq++, payload);
                _udp.Send(frame, frame.Length);  // destination set via Connect() in Start()
                PacketsSent++;
                LastSentMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SensorSim] Send error: {ex.Message}");
            }
        }

        // ── Payload builder ───────────────────────────────────────────────────
        private static byte[] BuildPayload(
            string   trackId,
            ExtOpsFrame.TrackClass trackClass,
            ExtOpsFrame.TrackCmd   trackCmd,
            double   lat, double lng, float altHAE,
            float    heading, float speed, float vz)
        {
            // 62-byte payload — zero-initialised.
            // Layout per ICD_EXTERNAL_INT v3.0.2 / trackMSG(byte[]) constructor.
            byte[] p = new byte[ExtOpsFrame.PAYLOAD_LEN_CUE];

            // [0–7]   ms timestamp
            ExtOpsFrame.WriteInt64(p, 0, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            // [8–15]  track ID — ASCII, null-padded to 8 bytes
            if (!string.IsNullOrEmpty(trackId))
            {
                byte[] id  = Encoding.ASCII.GetBytes(trackId);
                int    len = Math.Min(id.Length, 8);
                Buffer.BlockCopy(id, 0, p, 8, len);
            }

            // [16]    track class
            p[16] = (byte)trackClass;

            // [17]    track command
            p[17] = (byte)trackCmd;

            // [18–25] latitude double LE
            ExtOpsFrame.WriteDouble(p, 18, lat);

            // [26–33] longitude double LE
            ExtOpsFrame.WriteDouble(p, 26, lng);

            // [34–37] altitude HAE float LE
            ExtOpsFrame.WriteFloat(p, 34, altHAE);

            // [38–41] heading degrees true (0–360, North=0)
            ExtOpsFrame.WriteFloat(p, 38, heading);

            // [42–45] ground speed m/s
            ExtOpsFrame.WriteFloat(p, 42, speed);

            // [46–49] vertical speed m/s (positive = climbing)
            //   ⚠ aLORA negates this on ingest. Keep 0.0f to avoid the sign flip.
            ExtOpsFrame.WriteFloat(p, 46, vz);

            // [50–61] RESERVED — already zero

            return p;
        }
    }
}
