using CROSSBOW;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CROSSBOW_EMPLACEMENT_GUIS
{
    public partial class frmCUESim : Form
    {
        // ── Bitmaps ───────────────────────────────────────────────────────────
        private Bitmap? AC_ICON;
        private Bitmap? MAP_CENTER;

        // ── Base station ──────────────────────────────────────────────────────
        public ptLLA BaseStation = new ptLLA(34.4593583, -86.4326550, 174.6);

        // ── Simulated track state ─────────────────────────────────────────────
        double angle = 90;
        double radius_m = 1000;
        double spd = 500;
        trackLOG aTrackLog = new trackLOG();
        DateTime lastUpdateTime = DateTime.UtcNow;
        string ICAO = "Test";

        // ── Mode A: Direct-to-THEIA (CueSender) ──────────────────────────────
        private CueSender? _cueSender;

        // ── Mode B: HYPERION test (SensorSim + HyperionSniffer) ───────────────
        private SensorSim? _sensorSim = null;
        private HyperionSniffer? _sniffer = null;
        private const int LOG_MAX_ROWS = 200;

        // ─────────────────────────────────────────────────────────────────────
        #region Init
        // ─────────────────────────────────────────────────────────────────────

        public frmCUESim()
        {
            InitializeComponent();
            ChangeControlStyles(gMap, ControlStyles.OptimizedDoubleBuffer, true);
            AC_ICON = Properties.Resources.AC_LIGHT;
            MAP_CENTER = Properties.Resources.target;
        }

        private void frmCUESim_Load(object sender, EventArgs e)
        {
            iniMAP();
            cmbMapSources.DataSource = GMap.NET.MapProviders.GMapProviders.List;
            cmbMapSources.SelectedItem = gMap.MapProvider;

            txt_Map_Lat.Text = BaseStation.lat.ToString();
            txt_Map_Lng.Text = BaseStation.lng.ToString();
            txt_Map_ALT.Text = BaseStation.alt.ToString();
        }

        private void frmCUESim_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Always clean up sockets on close regardless of UI state
            _cueSender?.Stop();

            _sensorSim?.Stop();
            _sensorSim?.Dispose();

            _sniffer?.Stop();
            _sniffer?.Dispose();
        }

        private void ChangeControlStyles(Control ctrl, ControlStyles flag, bool value)
        {
            MethodInfo? method = ctrl.GetType().GetMethod("SetStyle",
                BindingFlags.Instance | BindingFlags.NonPublic);
            method?.Invoke(ctrl, new object[] { flag, value });
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GMap
        // ─────────────────────────────────────────────────────────────────────

        GMapOverlay adsbLayer = new GMapOverlay("adsb");
        GMapOverlay adsbRouteLayer = new GMapOverlay("adsb_routes");
        GMapOverlay symbolLayer = new GMapOverlay("symbol");

        private void iniMAP()
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMap.Position = new GMap.NET.PointLatLng(BaseStation.lat, BaseStation.lng);
            gMap.MinZoom = 0;
            gMap.MaxZoom = 24;
            gMap.Zoom = 10;
            gMap.RoutesEnabled = true;
            gMap.Overlays.Add(adsbRouteLayer);
            gMap.Overlays.Add(adsbLayer);
            gMap.Overlays.Add(symbolLayer);
            rangeRings();
            gMap.Invalidate();
        }

        private void rangeRings()
        {
            symbolLayer.Markers.Clear();
            symbolLayer.Routes.Clear();

            float dRadius = 20000;

            // Base station marker
            var sMarker = new GMarkerGoogle(
                new PointLatLng(BaseStation.lat, BaseStation.lng),
                GMarkerGoogleType.orange_dot);
            sMarker.Tag = "BaseStation";
            sMarker.ToolTipText = $"[{BaseStation.lat:0.######}° x {BaseStation.lng:0.######}°]";
            sMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            symbolLayer.Markers.Add(sMarker);

            for (int i = 1; i <= 9; i++)
            {
                float radius = i * dRadius;
                var points = new List<PointLatLng>();
                for (double theta = 0; theta <= 360; theta += 5)
                {
                    ptLLA pt2 = COMMON.projectLLA(BaseStation, radius, theta);
                    points.Add(new PointLatLng(pt2.lat, pt2.lng));
                }
                var aroute = new GMapRoute(points, "RR_" + i);
                aroute.Stroke = new System.Drawing.Pen(Color.FromArgb(50, Color.Black), 2)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                symbolLayer.Routes.Add(aroute);
            }

            // LoRa marker placeholder
            var gMarker = new GMarkerGoogle(
                new PointLatLng(BaseStation.lat, BaseStation.lng),
                GMarkerGoogleType.blue_dot);
            gMarker.Tag = "LoRa GPS";
            gMarker.ToolTipText = $"[{BaseStation.lat:0.######}° x {BaseStation.lng:0.######}°]";
            gMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            symbolLayer.Markers.Add(gMarker);
        }

        private void plot1090Track()
        {
            if (adsbLayer == null || aTrackLog.PositionLogCount < 1) return;

            int ndx = adsbLayer.Markers.ToList().FindIndex(a => a.Tag.ToString() == ICAO);
            if (ndx < 0) addACMarker(aTrackLog);
            else updateACMarker(aTrackLog, ndx);

            gMap?.Refresh();
        }

        private void addACMarker(trackLOG aLog)
        {
            if (gMap == null || adsbLayer == null || AC_ICON == null) return;
            if (aLog.Position.lat == 0 && aLog.Position.lng == 0) return;

            var pt = new PointLatLng(aLog.Position.lat, aLog.Position.lng);
            var aMarker = new bMarker(pt, AC_ICON);
            aMarker.Tag = aLog.ICAO;
            aMarker.Bearing = (float)aLog.Heading_deg - gMap.Bearing;
            aMarker.ToolTipText = $"{aLog.CallSign} <{aLog.ICAO}>\n" +
                                   $"[{aLog.Rangekm:0}km @{aLog.Bearing:0.#}° x {aLog.Elevation:0.#}°]";
            adsbLayer.Markers.Add(aMarker);
        }

        private void updateACMarker(trackLOG aLog, int ndx)
        {
            if (gMap == null || adsbLayer == null) return;

            adsbLayer.Markers[ndx].Position = new PointLatLng(aLog.Position.lat, aLog.Position.lng);
            ((bMarker)adsbLayer.Markers[ndx]).Bearing = (float)aLog.Heading_deg - gMap.Bearing;
            adsbLayer.Markers[ndx].ToolTipText =
                $"{aLog.CallSign} <{aLog.ICAO}>\n" +
                $"[{aLog.Rangekm:0}km @{aLog.Bearing:0.#}° x {aLog.Elevation:0.#}°]";
            adsbLayer.Markers[ndx].Offset = new Point(-24, -24);
        }

        private void btn_CenterMap_Click(object sender, EventArgs e)
        {
            double lat0 = Convert.ToDouble(txt_Map_Lat.Text);
            double lng0 = Convert.ToDouble(txt_Map_Lng.Text);
            double alt0 = Convert.ToDouble(txt_Map_ALT.Text);

            BaseStation = new ptLLA(lat0, lng0, alt0);
            gMap.Position = new GMap.NET.PointLatLng(lat0, lng0);
            rangeRings();
            gMap.Invalidate();
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Simulated track — timSimAC + timer1
        // ─────────────────────────────────────────────────────────────────────

        private void chk_EnablePattern_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_EnablePattern.Checked)
            {
                // Reinitialise track log with first position
                angle = 0;
                aTrackLog = new trackLOG();
                aTrackLog.TrackType = TRACK_TYPES.KALMAN_PREDICTED;

                ptLLA pt2 = COMMON.projectLLA(
                    new ptLLA(BaseStation.lat, BaseStation.lng, BaseStation.alt + 100),
                    radius_m, 0);
                trackMSG tmsg = new trackMSG("Test", "CS", pt2, new HeadingSpeed(angle, spd));
                aTrackLog.Update(tmsg, true);

                timer1.Enabled = true;
                timSimAC.Enabled = true;
                groupBox2.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                timSimAC.Enabled = false;
                groupBox2.Enabled = false;

                // Stop both send modes cleanly
                chk_SendData.Checked = false;
                chk_SensorSim.Checked = false;
                chk_HyperionSniff.Checked = false;
            }
        }

        /// <summary>
        /// timSimAC — advances the simulated aircraft position.
        /// This is the data source for both send modes.
        /// </summary>
        private void timSimAC_Tick(object sender, EventArgs e)
        {
            double dt = (DateTime.UtcNow - lastUpdateTime).TotalSeconds;
            lastUpdateTime = DateTime.UtcNow;

            ptLLA pt1 = aTrackLog.PositionLog[aTrackLog.PositionLog.LastOrDefault().Key];
            ptLLA pt2 = COMMON.projectLLA(pt1, spd * dt, angle);

            trackMSG tmsg = new trackMSG("Test", "CS", pt2, new HeadingSpeed(angle, spd));
            aTrackLog.Update(tmsg, false);

            angle += 1;
            if (angle >= 360) angle = 0;
        }

        /// <summary>
        /// timer1 — UI refresh at ~10 Hz (100 ms interval).
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            tss_UTCTime.Text = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss.ff");

            if (chk_EnablePattern.Checked)
                plot1090Track();

            if (aTrackLog.PositionLogCount > 0)
            {
                lblRover_Date.Text = aTrackLog.LastUpdateTime.ToString("MM/dd/yyyy HH:mm:ss.ff");
                lblRover_LAT.Text = $"LAT: {aTrackLog.Position.lat:0.00000000}";
                lblRover_LNG.Text = $"LNG: {aTrackLog.Position.lng:0.00000000}";
                lblRover_ALT.Text = $"ALT: {aTrackLog.Position.alt:0.00}";
                lblRover_Heading.Text = $"HEADING: {aTrackLog.Heading_deg:0.00}°";
                lblRover_Speed.Text = $"SPEED: {aTrackLog.Speed_mps:0.00}mps";
            }
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region timUDP — unified send tick
        //
        // Single timer drives both send modes.
        // Priority: HYPERION test mode (_sensorSim) → Direct THEIA (_cueSender).
        // Only one should be active at a time — the UI checkboxes enforce this.
        // ─────────────────────────────────────────────────────────────────────

        private void timUDP_Tick(object sender, EventArgs e)
        {
            if (aTrackLog.PositionLogCount < 1) return;

            ptLLA pos = aTrackLog.LatestPosition;

            // ── Mode B: HYPERION test — inject via SensorSim ──────────────────
            if (_sensorSim != null)
            {
                _sensorSim.SendTrack(
                    trackId: "SIMTRK1",                      // becomes CallSign in HYPERION trackLog
                    trackClass: ExtOpsFrame.TrackClass.UAV,
                    lat: pos.lat,
                    lng: pos.lng,
                    altHAE: (float)pos.alt,
                    heading: (float)aTrackLog.Heading_deg,
                    speed: (float)aTrackLog.Speed_mps
                // vz = 0.0f (default) — aLORA sign-flip is a no-op at zero
                );
                lbl_PacketsSent.Text = $"Sent: {_sensorSim.PacketsSent}";  // ← add this
                return;
            }

            // ── Mode A: Direct-to-THEIA — send via CueSender ─────────────────
            if (_cueSender == null) return;

            _cueSender.SendTrack(
                trackId: "12345678",
                trackClass: ExtOpsFrame.TrackClass.UAV,
                lat: pos.lat,
                lng: pos.lng,
                altHAE: (float)pos.alt,
                heading: (float)aTrackLog.Heading_deg,
                speed: (float)aTrackLog.Speed_mps
            // vz = 0.0f (default)
            );
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Mode A — Direct-to-THEIA (CueSender)
        // ─────────────────────────────────────────────────────────────────────

        private void chk_SendData_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SendData.Checked)
            {
                // Prevent both modes running simultaneously
                if (_sensorSim != null)
                {
                    MessageBox.Show("Stop HYPERION test mode before enabling direct THEIA send.",
                        "Mode conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chk_SendData.Checked = false;
                    return;
                }

                string tIP = txt_TargetIP.Text;
                _cueSender = new CueSender(tIP);
                _cueSender.StatusReceived += OnStatusReceived;
                _cueSender.PosAttReceived += OnPosAttReceived;
                _cueSender.Start();
                timUDP.Enabled = true;
            }
            else
            {
                timUDP.Enabled = false;
                if (_cueSender != null)
                {
                    _cueSender.StatusReceived -= OnStatusReceived;
                    _cueSender.PosAttReceived -= OnPosAttReceived;
                    _cueSender.Stop();
                    _cueSender = null;
                }
            }
        }

        private void OnStatusReceived(TheiaStatus status)
        {
            if (InvokeRequired) { Invoke(new Action(() => OnStatusReceived(status))); return; }

            txtCueResponse.Text =
                $"── 0xAF Status ──────────────────\r\n" +
                $"State:   0x{status.SystemState:X2}   Mode: 0x{status.SystemMode:X2}   CAM: {status.ActiveCamId}\r\n" +
                $"MCC:     {Convert.ToString(status.MccVoteBits, 2).PadLeft(8, '0')}\r\n" +
                $"BDC1:    {Convert.ToString(status.BdcVoteBits1, 2).PadLeft(8, '0')}\r\n" +
                $"BDC2:    {Convert.ToString(status.BdcVoteBits2, 2).PadLeft(8, '0')}\r\n" +
                $"GimAz:   {status.GimbalAzNed:F2}°   GimEl: {status.GimbalElNed:F2}°\r\n" +
                $"LasAz:   {status.LaserAzNed:F2}°   LasEl: {status.LaserElNed:F2}°\r\n" +
                $"Fire:    {(status.IsFireReady ? "✓ READY" : "✗ NOT READY")}\r\n" +
                $"────────────────────────────────";
        }

        private void OnPosAttReceived(TheiaPosAtt posAtt)
        {
            if (InvokeRequired) { Invoke(new Action(() => OnPosAttReceived(posAtt))); return; }

            txtCueResponse.Text =
                $"── 0xAB POS/ATT ─────────────────\r\n" +
                $"Lat:     {posAtt.Latitude:F8}°\r\n" +
                $"Lng:     {posAtt.Longitude:F8}°\r\n" +
                $"Alt HAE: {posAtt.AltHAE:F1} m\r\n" +
                $"Roll:    {posAtt.Roll:F2}°\r\n" +
                $"Pitch:   {posAtt.Pitch:F2}°\r\n" +
                $"Yaw:     {posAtt.Yaw:F2}°\r\n" +
                $"────────────────────────────────";
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Mode B — HYPERION test (SensorSim + HyperionSniffer)
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Start/stop injecting simulated track data into HYPERION via aRADAR (port 15001).
        /// HYPERION processes it through the Kalman filter and forwards to THEIA (port 15009).
        /// </summary>
        private void chk_SensorSim_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SensorSim.Checked)
            {
                // Prevent both modes running simultaneously
                if (_cueSender != null)
                {
                    MessageBox.Show("Stop direct THEIA send before enabling HYPERION test mode.",
                        "Mode conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chk_SensorSim.Checked = false;
                    return;
                }

                string host = txt_HyperionIP.Text.Trim();
                _sensorSim = new SensorSim(host, SensorSim.HYPERION_RADAR_PORT);
                _sensorSim.StatusReceived += OnStatusReceived;   // reuse existing handler
                _sensorSim.PosAttReceived += OnPosAttReceived;   // reuse existing handler
                _sensorSim.Start();
                Debug.WriteLine($"[SensorSim] Started → {host}:{SensorSim.HYPERION_RADAR_PORT}");
                chk_SensorSim.Text = $"Inject → HYPERION  port {SensorSim.HYPERION_RADAR_PORT} (aRADAR)";

                if (chk_EnablePattern.Checked)
                    timUDP.Enabled = true;
            }
            else
            {
                timUDP.Enabled = false;
                _sensorSim.StatusReceived -= OnStatusReceived;
                _sensorSim.PosAttReceived -= OnPosAttReceived;
                _sensorSim?.Stop();
                _sensorSim?.Dispose();
                _sensorSim = null;
                chk_SensorSim.Text = "Inject → HYPERION";
            }
        }

        /// <summary>
        /// Start/stop HyperionSniffer — listens on port 10009 as fake THEIA,
        /// captures and verifies every 0xAA packet HYPERION forwards.
        /// </summary>
        private void chk_HyperionSniff_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_HyperionSniff.Checked)
            {
                _sniffer = new HyperionSniffer();
                _sniffer.PacketReceived += OnHyperionPacketReceived;
                _sniffer.VerifyFailed += OnHyperionVerifyFailed;
                _sniffer.Start();
                timer_SnifferStats.Enabled = true;
            }
            else
            {
                timer_SnifferStats.Enabled = false;

                if (_sniffer != null)
                {
                    _sniffer.PacketReceived -= OnHyperionPacketReceived;
                    _sniffer.VerifyFailed -= OnHyperionVerifyFailed;
                    _sniffer.Stop();
                    _sniffer.Dispose();
                    _sniffer = null;
                }
            }
        }

        /// <summary>
        /// Called on every packet received by HyperionSniffer (pass or fail).
        /// Appends a summary line to the verify log.
        /// </summary>
        private void OnHyperionPacketReceived(CapturedCuePacket pkt)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => OnHyperionPacketReceived(pkt))); return; }

            if (pkt.AllPass)
            {
                AppendLog(
                    $"[{pkt.ReceivedAt:HH:mm:ss.ff}]  SEQ={pkt.SeqNum,5}" +
                    $"  LAT={pkt.Latitude:F4}  LNG={pkt.Longitude:F4}" +
                    $"  ALT={pkt.AltHAE:F0}m  HDG={pkt.Heading:F0}°  SPD={pkt.Speed:F0}m/s  ✓",
                    Color.LimeGreen);
            }
            else
            {
                AppendLog(
                    $"[{pkt.ReceivedAt:HH:mm:ss.ff}]  SEQ={pkt.SeqNum,5}  ✗ VERIFY FAILED",
                    Color.Red);

                // Log each failing or warning check indented below the summary line
                foreach (var c in pkt.Checks)
                {
                    if (c.Result == VerifyResult.Fail)
                        AppendLog($"        {c}", Color.OrangeRed);
                    else if (c.Result == VerifyResult.Warning)
                        AppendLog($"        {c}", Color.Yellow);
                }
            }
        }

        /// <summary>
        /// Called only on verify failures — hook here for additional alerting if needed.
        /// </summary>
        private void OnHyperionVerifyFailed(CapturedCuePacket pkt)
        {
            // Already fully handled in OnHyperionPacketReceived.
            // Add sound, status bar flash, etc. here if desired.
        }

        /// <summary>
        /// timer_SnifferStats — updates the packet counter labels at 10 Hz.
        /// </summary>
        private void timer_SnifferStats_Tick(object sender, EventArgs e)
        {
            if (_sniffer != null)
            {
                lbl_PacketsRx.Text = $"Rx:   {_sniffer.PacketsReceived}";
                lbl_PacketsPass.Text = $"Pass: {_sniffer.PacketsPassed}";
                lbl_PacketsFail.Text = $"Fail: {_sniffer.PacketsFailed}";
            }

            if (_sensorSim != null)
                lbl_PacketsSent.Text = $"Sent: {_sensorSim.PacketsSent}";
        }

        private void btn_ResetCounters_Click(object sender, EventArgs e)
        {
            _sniffer?.ResetCounters();
            lstVerifyLog.Items.Clear();
            lbl_PacketsSent.Text = "Sent: 0";
            lbl_PacketsRx.Text = "Rx:   0";
            lbl_PacketsPass.Text = "Pass: 0";
            lbl_PacketsFail.Text = "Fail: 0";
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers
        // ─────────────────────────────────────────────────────────────────────

        private void AppendLog(string text, Color? color = null)
        {
            while (lstVerifyLog.Items.Count >= LOG_MAX_ROWS)
                lstVerifyLog.Items.RemoveAt(0);

            lstVerifyLog.Items.Add(text);
            // Scroll to latest without leaving anything selected
            lstVerifyLog.SelectedIndex = lstVerifyLog.Items.Count - 1;
            lstVerifyLog.SelectedIndex = -1;
        }

        #endregion
    }
}
