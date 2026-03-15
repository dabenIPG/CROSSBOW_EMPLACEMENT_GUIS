using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CROSSBOW;

namespace CROSSBOW_EMPLACEMENT_GUIS
{
    public partial class frmLORA : Form
    {
        System.IO.Ports.SerialPort _serialPort;
        private delegate void SetTextDeleg(string text);

        ROVER_MSG roverMSG = new ROVER_MSG();
        public ptLLA BaseStation = new ptLLA(37.1246, -122.2076, 615);
        UdpClient client;

        public frmLORA()
        {
            InitializeComponent();
            // disable mouse interaction by default

            ChangeControlStyles(gMap, ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void ChangeControlStyles(Control ctrl, ControlStyles flag, bool value)
        {
            MethodInfo method = ctrl.GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            if (method != null)
                method.Invoke(ctrl, new object[] { flag, value });
        }
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_serialPort.IsOpen)
                return;

            string data = _serialPort.ReadLine();
            // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method.
            // ---- The "si_DataReceived" method will be executed on the UI thread, which allows populating the textbox.
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
            //Debug.WriteLine($"Port RX: {_serialPort.BytesToRead} {data.ToString()}");

            //string[] s = data.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string[] s = data.Split(",");

            string msgID = s[0];


            switch (msgID)
            {
                case "$GNGGA":
                    //Debug.WriteLine("$GNGGA");
                    roverMSG.Parse_GNGGA(s);
                    break;
                case "$GNVTG":
                    //Debug.WriteLine("$GNVTG");
                    roverMSG.Parse_GNVTG(s);
                    break;
                default:
                    Debug.WriteLine($"Port RX: {_serialPort.BytesToRead} {data.ToString()}");
                    break;
            }
        }
        private void si_DataReceived(string data) { tss_LoRaMsg.Text = data.Trim(); }

        private void btn_SerialConnect_Click(object sender, EventArgs e)
        {
            if (btn_SerialConnect.Text == "Connect")
            {

                try
                {
                    _serialPort = new System.IO.Ports.SerialPort(cmbSerialPorts.Text, 230400, Parity.None, 8, StopBits.One);
                    _serialPort.Handshake = Handshake.None;
                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                    _serialPort.WriteTimeout = 500;
                    _serialPort.Open();
                    Debug.WriteLine("Com Port Opened");
                    btn_SerialConnect.Text = "DisConnect";
                    timer1.Enabled = true;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Communications Error: " + ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("Com Port Closed");
                btn_SerialConnect.Text = "Connect";
                timUDP.Enabled = false;
                timer1.Enabled = false;
                _serialPort.Close();

            }
        }

        private void frmLORA_Load(object sender, EventArgs e)
        {
            cmbSerialPorts.DataSource = SerialPort.GetPortNames();
            iniMAP();
            cmbMapSources.DataSource = GMap.NET.MapProviders.GMapProviders.List;
            cmbMapSources.SelectedItem = gMap.MapProvider;

            txt_Map_Lat.Text = BaseStation.lat.ToString();
            txt_Map_Lng.Text = BaseStation.lng.ToString();
            txt_Map_ALT.Text = BaseStation.alt.ToString();
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

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            tss_UTCTime.Text = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss.ff");


            gmap_UpdateLoRaMarker();
            lblRover_LAT.Text = string.Format("LAT: {0:0.00000000}", roverMSG.Latitude_Deg);
            lblRover_LNG.Text = string.Format("LNG: {0:0.00000000}", roverMSG.Longitude_Deg);
            lblRover_ALT.Text = string.Format("ALT: {0:0.00}", roverMSG.ALT_MSL_m);
            lblRover_dt.Text = string.Format("Delta T: {0:0.00}", roverMSG.TrackAge_ms);
            DateTime dt_epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            lblRover_Date.Text = roverMSG.roverLastMsgDateTime.ToString("MM/dd/yyyy HH:mm:ss.ff");
            //lblRover_Range.Text = string.Format("Range: {0:0.000}m", LatestRange_m());
            //lblRover_Elevation.Text = string.Format("Elev: {0:0.00}°", LatestElevationAngle());
            //lblRover_Bearing.Text = string.Format("Bearing: {0:0.00}°", LatestBearing());
            //lblRover_CNT.Text = myE.posRover[0].cnt.ToString();
            //progRover_SOC.Value = Math.Min(Convert.ToInt32(myE.posRover[0].soc / 1000.00), 100);
            lblRover_SIV.Text = $"SIV: {roverMSG.nSatellites}";
            lblRover_FixType.Text = $"FIX TYPE: {roverMSG.FixType.ToString()}";
            //lblRover_ID.Text = myE.posRover[0].id.ToString();
            ////tssClockDelta.Text = (epoch_base - epoch_rover).ToString("0.000");
            lblRover_Heading.Text = string.Format("HEADING: {0:0.00}°", roverMSG.Heading_Deg);
            lblRover_Speed.Text = string.Format("SPEED: {0:0.00}mps", roverMSG.Speed_mps);
        }

        private void timUDP_Tick(object sender, EventArgs e)
        {
            //byte[] data = new byte[] { 0xAA, 0x01, 0x02, 0x03, 0xAA };
            byte[] data = ToArray();
            client.Send(data);
        }
        public byte[] ToArray()
        {
            using (var ms = new MemoryStream())
            using (var sw = new BinaryWriter(ms))
            {

                //long timeStamp = new DateTimeOffset(rxTime.ToUniversalTime()).ToUnixTimeMilliseconds();
                //long timeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
                long timeStamp = new DateTimeOffset(roverMSG.roverMsgDateTime.ToLocalTime()).ToUnixTimeMilliseconds();
                byte tClass = (byte)0x08;// (byte)aTrackLog.Classification;
                byte tCMD = (byte)7;
                string tID = "12345678".Trim('\0');
                byte[] bID = Encoding.ASCII.GetBytes(tID);

                sw.Write((byte)0xAA);
                sw.Write(timeStamp);
                sw.Write(bID);
                sw.Write((byte)tClass);
                sw.Write((byte)0x01);

                sw.Write((double)roverMSG.Latitude_Deg);
                sw.Write((double)roverMSG.Longitude_Deg);
                sw.Write((Single)roverMSG.ALT_MSL_m);
                sw.Write((Single)roverMSG.ve);
                sw.Write((Single)roverMSG.vn);
                sw.Write((Single)roverMSG.vd);

                sw.Write((UInt32)0);
                sw.Write((UInt32)0);
                sw.Write((UInt32)0);

                sw.Write((byte)0xAA);
                return ms.ToArray();
            }
        }

        private void chk_SendData_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SendData.Checked)
            {
                client = new UdpClient();
                string tIP = txt_TargetIP.Text;
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(tIP), 10032);
                client.Connect(ipEndPoint);
            }
            else
            {
                //timUDP.Enabled = false;
            }
        }

        private void chk_UDP_Transmit_CheckedChanged(object sender, EventArgs e)
        {
            timUDP.Enabled = chk_UDP_Transmit.Checked;

        }

        private void frmLORA_FormClosing(object sender, FormClosingEventArgs e)
        {
            timUDP.Enabled = false;
            timer1.Enabled = false;
            _serialPort.Close();

        }

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

        private void btn_SerialQuery_Click(object sender, EventArgs e)
        {
        }

        private void btn_Serial_RTI_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine("RTI\r\n");

        }

        private void btn_Serial_ATI_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine("ATI\r\n");

        }

        private void chk_Serial_ATO_Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Serial_ATO_Enable.Checked)
            {
                Debug.WriteLine("SERIAL ATO");
                _serialPort.WriteLine("ATO\r\n");
            }
            else
            {
                _serialPort.WriteLine("+++\r\n");
                Thread.Sleep(10);
                _serialPort.WriteLine("RTO\r\n");

                Debug.WriteLine("+++");

            }
        }
    }

    public class ROVER_MSG
    {
        public enum EMLIDS_FIX_TYPES
        {
            INVALID = 0,
            GNSS = 1,
            DGPS = 2,
            RTK_FIXED = 4,
            RTK_FLOAT = 5,
        }

        public ROVER_MSG() { }
        public double Latitude_Deg { get; private set; } = 35;
        public double Longitude_Deg { get; private set; } = -122;
        public double ALT_MSL_m { get; private set; } = 50;
        public DateTime roverMsgDateTime { get; private set; } = DateTime.UtcNow;
        public DateTime roverLastMsgDateTime { get; private set; } = DateTime.UtcNow;
        public long TrackAge_ms { get { return (long)((TimeSpan)(roverMsgDateTime - roverLastMsgDateTime)).TotalMilliseconds; } }
        public int nSatellites { get; private set; } = 0;
        public double Heading_Deg { get; private set; } = 0;
        public double Speed_mps { get; private set; } = 0;

        public EMLIDS_FIX_TYPES FixType { get; private set; } = EMLIDS_FIX_TYPES.INVALID;

        public double vn { get { return Speed_mps * Math.Cos(Heading_Deg * Math.PI / 180.0); } }
        public double ve { get { return Speed_mps * Math.Sin(Heading_Deg * Math.PI / 180.0); } }
        public double vd { get { return 0; } }

        public void Parse_GNGGA(string[] msg)
        {
            if (msg.Length != 15)
                return;

            string dt = msg[1];
            int hr = Convert.ToInt32(dt.Substring(0, 2));
            int min = Convert.ToInt32(dt.Substring(2, 2));
            int sec = Convert.ToInt32(dt.Substring(4, 2));
            int msec = Convert.ToInt32(dt.Substring(7, 2)) * 10;

            roverLastMsgDateTime = roverMsgDateTime;
            roverMsgDateTime = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, hr, min, sec, msec);
            //roverMsgDateTime = roverMsgDateTime.AddSeconds(-18);
            //roverMsgDateTime = DateTime.UtcNow;
            double degrees = Convert.ToDouble(msg[2].Substring(0, 2));
            double mins = Convert.ToDouble(msg[2].Substring(2, 10));
            Latitude_Deg = degrees + mins / 60;
            Latitude_Deg *= msg[3].Equals("N") ? 1 : -1;

            degrees = Convert.ToDouble(msg[4].Substring(0, 3));
            mins = Convert.ToDouble(msg[4].Substring(3, 10));
            Longitude_Deg = degrees + mins / 60;
            Longitude_Deg *= msg[5].Equals("E") ? 1 : -1;


            FixType = (EMLIDS_FIX_TYPES)Convert.ToInt32(msg[6]);
            nSatellites = Convert.ToInt32(msg[7]);

            ALT_MSL_m = Convert.ToDouble(msg[9]);

        }
        public void Parse_GNVTG(string[] msg)
        {
            //if (msg.Length != 10)
            //    return;
            //Heading_Deg = Convert.ToDouble(msg[1]);
            //Speed_mps = Convert.ToDouble(msg[7]) * 0.277778; // kph->mps

            if (msg.Length != 10)
                return;

            _ = double.TryParse(msg[1], out double res);
            Heading_Deg = res;

            _ = double.TryParse(msg[7], out double res2);
            Speed_mps = res2 * 0.277778; // kph->mps

            //Heading_Deg = Convert.ToDouble(msg[1]);
            //Speed_mps = Convert.ToDouble(msg[7])* 0.277778; // kph->mps
        }

    }



}
