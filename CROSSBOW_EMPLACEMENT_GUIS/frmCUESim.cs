using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CROSSBOW;

namespace CROSSBOW_EMPLACEMENT_GUIS
{
    public partial class frmCUESim : Form
    {
        private Bitmap? AC_ICON;
        private Bitmap? MAP_CENTER;

        public ptLLA BaseStation = new ptLLA(37.1246, -122.2076, 615);
        ROVER_MSG roverMSG = new ROVER_MSG();

        double angle = 90;
        double radius_m = 1000;
        double spd = 500;
        trackLOG aTrackLog = new trackLOG();
        DateTime lastUpdateTime = DateTime.UtcNow;
        string ICAO = "Test";

        private CueSender? _cueSender;
        private ushort _txSeq = 0;


        public frmCUESim()
        {
            InitializeComponent();
            ChangeControlStyles(gMap, ControlStyles.OptimizedDoubleBuffer, true);
            AC_ICON = Properties.Resources.AC_LIGHT; //new Bitmap(new Bitmap("Resources\\AC_LIGHT.png"), 36, 36);
            MAP_CENTER = Properties.Resources.target; //new Bitmap("Resources\\target.png");
        }

        private void frmCUESim_Load(object sender, EventArgs e)
        {
            //cmbSerialPorts.DataSource = SerialPort.GetPortNames();
            iniMAP();
            cmbMapSources.DataSource = GMap.NET.MapProviders.GMapProviders.List;
            cmbMapSources.SelectedItem = gMap.MapProvider;

            txt_Map_Lat.Text = BaseStation.lat.ToString();
            txt_Map_Lng.Text = BaseStation.lng.ToString();
            txt_Map_ALT.Text = BaseStation.alt.ToString();
        }
        private void ChangeControlStyles(Control ctrl, ControlStyles flag, bool value)
        {
            MethodInfo method = ctrl.GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            if (method != null)
                method.Invoke(ctrl, new object[] { flag, value });
        }

        #region GMAP
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

            ptLLA cPt = BaseStation; // new ptLLA(BaseStation.Lat, BaseStation.Lng, 226);
            float dRadius = 20000;

            // plot center
            GMarkerGoogle sMarker = new GMarkerGoogle(new PointLatLng(BaseStation.lat, BaseStation.lng), GMarkerGoogleType.orange_dot); //new GMarkerGoogle(new PointLatLng(BaseStation.lat, BaseStation.lng), new Bitmap(Properties.Resources.target));
            sMarker.Tag = "BaseStation";
            sMarker.ToolTipText = "[" + BaseStation.lat.ToString("0.######") + "° x " + BaseStation.lng.ToString("0.######") + "°]";
            sMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            symbolLayer.Markers.Add(sMarker);

            for (int i = 1; i <= 9; i++)
            {
                float radius = i * dRadius;
                List<PointLatLng> points = new List<PointLatLng>();

                for (double theta = 0; theta <= 360; theta += 5)
                {
                    ptLLA pt2 = COMMON.projectLLA(cPt, radius, theta);
                    //Coordinate pt = bs;
                    //pt.Move(radius, theta, Shape.Ellipsoid);
                    points.Add(new PointLatLng(pt2.lat, pt2.lng));
                }

                GMapRoute aroute = new GMapRoute(points, "RR_" + i.ToString());
                Pen aPen = new Pen(Color.FromArgb(50, Color.Black));
                aPen.Width = 2;
                aPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                aroute.Stroke = aPen;
                symbolLayer.Routes.Add(aroute);
            }

            // plot LoRa
            GMarkerGoogle gMarker = new GMarkerGoogle(new PointLatLng(BaseStation.lat, BaseStation.lng), GMarkerGoogleType.blue_dot);
            gMarker.Tag = "LoRa GPS";
            gMarker.ToolTipText = "[" + BaseStation.lat.ToString("0.######") + "° x " + BaseStation.lng.ToString("0.######") + "°]";
            gMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            symbolLayer.Markers.Add(gMarker);


        }
        private void gmap_UpdateLoRaMarker()
        {
            PointLatLng pos = new PointLatLng(roverMSG.Latitude_Deg, roverMSG.Longitude_Deg);
            double range = 1;// aLog.LatestRangekm;
            double bearing = 2;// aLog.LatestBearing;
            double elev = 3;// aLog.LatestElevationAngle;

            int ndx = symbolLayer.Markers.ToList().FindIndex(a => a.Tag.ToString().Equals("LoRa GPS"));

            if (ndx != 0 && roverMSG.Latitude_Deg != 0 && roverMSG.Longitude_Deg != 0)
            {
                symbolLayer.Markers[ndx].Position = pos;
                //(adsbLayer.Markers[ndx] as bMarker).Bearing = (float)aLog.LatestHeading - gMap.Bearing;
                symbolLayer.Markers[ndx].ToolTipText = "LoRa" + " <" + "GPS" + ">\n[" +
                                                           range.ToString("0") + "km @" +
                                                           bearing.ToString("0.#") + "° x " +
                                                           elev.ToString("0.#") + "°]";
                symbolLayer.Markers[ndx].Offset = new Point(-24, -24);
            }

        }
        private void plot1090Track()
        {
            if (adsbLayer == null || aTrackLog.PositionLogCount < 1)
                return;

            //trackLOG aLog = aCB.aADSB.trackLogs[ICAO];
            //// do we need to add a track on GUI
            int ndx = adsbLayer.Markers.ToList().FindIndex(a => a.Tag.ToString() == ICAO);
            if (ndx < 0)
                addACMarker(aTrackLog);
            else
                updateACMarker(aTrackLog, ndx, true);


            gMap?.Refresh();
        }
        private void addACMarker(trackLOG aLog)
        {
            if (gMap == null || adsbLayer == null || AC_ICON == null)
                return;

            if (aLog.Position.lat != 0 && aLog.Position.lng != 0 && aLog.Position.alt != 0)
            {
                PointLatLng pt = new PointLatLng(aLog.Position.lat, aLog.Position.lng);
                bMarker? aMarker;
                aMarker = new bMarker(pt, AC_ICON);  // updated to handle rotation

                aMarker.Tag = aLog.ICAO;
                ((bMarker)aMarker).Bearing = (float)aLog.Heading_deg - gMap.Bearing;
                aMarker.ToolTipText = aLog.CallSign + " <" + aLog.ICAO + ">\n[" +
                                                           aLog.Rangekm.ToString("0") + "km @" +
                                                           aLog.Bearing.ToString("0.#") + "° x " +
                                                           aLog.Elevation.ToString("0.#") + "°]";

                adsbLayer?.Markers.Add(aMarker);
            }
        }
        private void updateACMarker(trackLOG aLog, int ndx, bool _isCue = false)
        {
            if (gMap == null || adsbLayer == null)
                return;


            PointLatLng pos = new PointLatLng(aLog.Position.lat, aLog.Position.lng);
            double range = aLog.Rangekm;
            double bearing = aLog.Bearing;
            double elev = aLog.Elevation;

            adsbLayer.Markers[ndx].Position = pos;
            ((bMarker)adsbLayer.Markers[ndx]).Bearing = (float)aLog.Heading_deg - gMap.Bearing;
            adsbLayer.Markers[ndx].ToolTipText = aLog.CallSign + " <" + aLog.ICAO + ">\n[" +
                                                       range.ToString("0") + "km @" +
                                                       bearing.ToString("0.#") + "° x " +
                                                       elev.ToString("0.#") + "°]";
            adsbLayer.Markers[ndx].Offset = new Point(-24, -24);

        }

        #endregion

        private void btn_CenterMap_Click(object sender, EventArgs e)
        {
            double lat0 = Convert.ToDouble(txt_Map_Lat.Text);
            double lng0 = Convert.ToDouble(txt_Map_Lng.Text);
            double alt0 = Convert.ToDouble(txt_Map_ALT.Text);

            BaseStation = new ptLLA(lat0, lng0, alt0);
            gMap.Position = new GMap.NET.PointLatLng(BaseStation.lat, BaseStation.lng);
            rangeRings();
            gMap.Invalidate();
        }

        private void chk_EnablePattern_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_EnablePattern.Checked)
            {
                angle = 0;
                aTrackLog = new trackLOG();
                aTrackLog.TrackType = TRACK_TYPES.KALMAN_PREDICTED;
                ptLLA pt2 = COMMON.projectLLA(new ptLLA(BaseStation.lat, BaseStation.lng, BaseStation.alt + 100), radius_m, 0);
                trackMSG tmsg = new trackMSG("Test", "CS", pt2, new HeadingSpeed(angle + 0, spd));
                aTrackLog.Update(tmsg, true);

                timer1.Enabled = true;
                timSimAC.Enabled = true;
                groupBox2.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;

                timSimAC.Enabled = false;
                chk_SendData.Checked = false;
                groupBox2.Enabled = false;
            }
        }

        private void timSimAC_Tick(object sender, EventArgs e)
        {
            // update the ac position on each tick
            double dt = (DateTime.UtcNow - lastUpdateTime).TotalSeconds;
            lastUpdateTime = DateTime.UtcNow;

            ptLLA pt1 = aTrackLog.PositionLog[aTrackLog.PositionLog.LastOrDefault().Key];
            ptLLA pt2 = COMMON.projectLLA(pt1, spd * dt, angle);
            trackMSG tmsg = new trackMSG("Test", "CS", pt2, new HeadingSpeed(angle + 0, spd));
            aTrackLog.Update(tmsg, false);
            angle += 1;
            if (angle >= 360)
                angle = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tss_UTCTime.Text = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss.ff");
            //lbl_SelectedPosition.Text = $"{selectedPosition.Lat.ToString("0.00000")}, {selectedPosition.Lng.ToString("0.00000")}";
            if (chk_EnablePattern.Checked)
                plot1090Track();
            if (aTrackLog.PositionLogCount > 0)
            {
                lblRover_Date.Text = aTrackLog.LastUpdateTime.ToString("MM/dd/yyyy HH:mm:ss.ff");

                lblRover_LAT.Text = string.Format("LAT: {0:0.00000000}", aTrackLog.Position.lat);
                lblRover_LNG.Text = string.Format("LNG: {0:0.00000000}", aTrackLog.Position.lng);
                lblRover_ALT.Text = string.Format("ALT: {0:0.00}", aTrackLog.Position.alt);
                //lblRover_dt.Text = string.Format("Delta T: {0:0.00}", roverMSG.TrackAge_ms);

                lblRover_Heading.Text = string.Format("HEADING: {0:0.00}°", aTrackLog.Heading_deg);
                lblRover_Speed.Text = string.Format("SPEED: {0:0.00}mps", aTrackLog.Speed_mps);


            }
        }

        private void chk_SendData_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SendData.Checked)
            {
                string tIP   = txt_TargetIP.Text;
                _cueSender   = new CueSender(tIP);
                _cueSender.StatusReceived  += OnStatusReceived;
                _cueSender.PosAttReceived  += OnPosAttReceived;
                _cueSender.Start();
                timUDP.Enabled = true;
            }
            else
            {
                timUDP.Enabled = false;
                _cueSender?.Stop();
                _cueSender = null;
            }
        }

        private void timUDP_Tick(object sender, EventArgs e)
        {
            if (_cueSender == null || aTrackLog.PositionLogCount < 1) return;

            ptLLA pos = aTrackLog.LatestPosition;

            _cueSender.SendTrack(
                trackId:    "12345678",
                trackClass: ExtOpsFrame.TrackClass.UAV,
                lat:        pos.lat,
                lng:        pos.lng,
                altHAE:     (float)pos.alt,
                heading:    (float)aTrackLog.Heading_deg,
                speed:      (float)aTrackLog.Speed_mps
                // vz defaults to 0.0f — no vertical rate in sim
            );
        }
        private void chk_UDP_Transmit_CheckedChanged(object sender, EventArgs e)
        {
            timUDP.Enabled = chk_UDP_Transmit.Checked;
        }

        // ── CueSender response handlers ───────────────────────────────────────
        private void OnStatusReceived(TheiaStatus status)
        {
            // Marshal to UI thread
            if (InvokeRequired) { Invoke(new Action(() => OnStatusReceived(status))); return; }

            txtCueResponse.Text =
                $"── 0xAF Status ──────────────────\r\n" +
                $"State:   0x{status.SystemState:X2}   Mode: 0x{status.SystemMode:X2}   CAM: {status.ActiveCamId}\r\n" +
                $"MCC:     {Convert.ToString(status.MccVoteBits,  2).PadLeft(8, '0')}\r\n" +
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
    }



}
