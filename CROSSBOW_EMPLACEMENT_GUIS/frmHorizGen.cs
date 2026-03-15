using GeographicLib;
using GMap.NET;
using GMap.NET.WindowsForms;
using MaxRev.Gdal.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSGeo.GDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CROSSBOW;

namespace CROSSBOW_EMPLACEMENT_GUIS
{
    public partial class frmHorizGen : Form
    {
        private GMapOverlay? horizLayer = new("horiz");
        string filePath_dted = "";

        double pi = Math.Acos(-1.0);
        WebClient wc = new WebClient();
        SortedDictionary<DateTime, string> geoTiffFiles = new SortedDictionary<DateTime, string>();

        public class TNM_ITEMS
        {
            public String title { get; set; }
            public String moreInfo { get; set; }
            public String sourceId { get; set; }
            public String sourceName { get; set; }
            public String publicationDate { get; set; }
            public string dateCreated { get; set; }
            public int sizeInBytes { get; set; }
            public String extent { get; set; }
            public String format { get; set; }
            public String downloadURL { get; set; }
            public TNM_BB boundingBox { get; set; }
        }
        public class TNM_BB
        {
            public double minX { get; set; }
            public double maxX { get; set; }
            public double minY { get; set; }
            public double maxY { get; set; }
            public override string ToString()
            {
                return $"[{minX.ToString("0.000")}, {maxY.ToString("0.000")} ; {maxX.ToString("0.000")}, {minY.ToString("0.000")}]";
            }

        }


        public frmHorizGen()
        {
            InitializeComponent();
            GdalBase.ConfigureAll();

        }

        private void frmHorizGen_Load(object sender, EventArgs e)
        {
            double mylatitude = Convert.ToDouble(txt_lat.Text);  //34.459541;
            double mylongitude = Convert.ToDouble(txt_lng.Text);  //-86.432505;
            double myelevation = Convert.ToDouble(txt_alt.Text);  //173;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
            gMapControl1.Position = new GMap.NET.PointLatLng(mylatitude, mylongitude);
            gMapControl1.Overlays.Add(horizLayer);

            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);

        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Update the progress bar value
            //progressBar2.Value = e.ProgressPercentage;
            progressBar2.Invoke(new Action(() => { progressBar2.Value = e.ProgressPercentage; }));

        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Handle download completion
            if (e.Error != null)
            {
                Debug.WriteLine("Download failed: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                Debug.WriteLine("Download cancelled.");
            }
            else
            {
                var foo = (CodeArtEng.Controls.StatusLabel)e.UserState;
                foo.State = CodeArtEng.Controls.StatusLabelState.Green;
                Debug.WriteLine("Download completed successfully!");
                statusStrip1.Invoke(new Action(() => { tss_msgs.Text = $"Download completed successfully!"; }));
                progressBar2.Value = 0;
                this.Cursor = Cursors.Default;

            }
        }

        private void MapGeoTiffLimits(TNM_BB _box, string _name)
        {

            // show geotiff on map
            List<PointLatLng> pointsG = new List<PointLatLng>();
            pointsG.Add(new PointLatLng(_box.maxY, _box.minX));
            pointsG.Add(new PointLatLng(_box.maxY, _box.maxX));
            pointsG.Add(new PointLatLng(_box.minY, _box.maxX));
            pointsG.Add(new PointLatLng(_box.minY, _box.minX));
            GMapPolygon polygonG = new GMapPolygon(pointsG, _name);
            polygonG.Fill = new SolidBrush(Color.FromArgb(50, Color.Gray));
            polygonG.Stroke = new Pen(Color.Black, 1);
            horizLayer?.Polygons.Add(polygonG);
            gMapControl1.Invalidate();
        }
        private void calculate_dip_angle(double lat1, double long1, double alt1, double lat2, double long2, double alt2, double pi, out double azimuth, out double dip_angle, out double dist, bool lcorr_for_refraction = true, bool lmeters = true)
        {
            //###############################################################################
            // if we are going to correct for refraction, calculate the
            // distance so we can correct alt2
            // yoeli_with_viewshed_refraction_paper
            // awesome_paper_on_viewshed_analysis
            // horizon_calculation.pdf
            //###############################################################################
            double scale = 3280.84; // ft per km
            if (lmeters) scale = 1000.0;

            double theta1 = lat1 * pi / 180.0;
            double theta2 = lat2 * pi / 180.0;
            double phi1 = long1 * pi / 180.0;
            double phi2 = long2 * pi / 180.0;

            double a = 6378.1370 * scale; // earth ellisoid parameters
            double b = 6356.7523 * scale;

            double R1 = a * a * a * a * Math.Cos(theta1) * Math.Cos(theta1) + b * b * b * b * Math.Sin(theta1) * Math.Sin(theta1);
            R1 = R1 / (a * a * Math.Cos(theta1) * Math.Cos(theta1) + b * b * Math.Sin(theta1) * Math.Sin(theta1));
            R1 = Math.Sqrt(R1);
            double R2 = a * a * a * a * Math.Cos(theta2) * Math.Cos(theta2) + b * b * b * b * Math.Sin(theta2) * Math.Sin(theta2);
            R2 = R2 / (a * a * Math.Cos(theta2) * Math.Cos(theta2) + b * b * Math.Sin(theta2) * Math.Sin(theta2));
            R2 = Math.Sqrt(R2);

            //###############################################################################
            // calculate the correction for refraction
            // yoeli_with_viewshed_refraction_paper
            // awesome_paper_on_viewshed_analysis
            //###############################################################################
            double dlat = (theta2 - theta1);
            double dlon = (phi2 - phi1);
            a = (Math.Sin(dlat / 2.0) * Math.Sin(dlat / 2.0))
               + (Math.Sin(dlon / 2.0) * Math.Sin(dlon / 2.0)) * Math.Cos(theta1) * Math.Cos(theta2);
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));
            dist = R2 * c;
            double k = 0.13;
            double adiff = 0.0;
            if (lcorr_for_refraction)
            {
                adiff = (dist * dist) * (k) / (R2 * 2.0);
            }

            //###############################################################################
            // now calculate the dip angle
            // a good online calculator is at   view-source:http://cosinekitty.com/compass.html
            // first calculate the cartesian coordinates of each of the points
            // gamma is the angle between the vectors
            // then calculate the dip angle
            // using law of cosines, calculate the distance between the points, w,
            // at the ends of the vectors, given that we know the angle between them
            // we also have
            // R2+h2+v = (R1+h1)/cos(gamma)
            // (thus v = (R1+h1)/cos(gamma)-R2-h2 )
            // and
            // w/sin(90-gamma) = v/sin(delta)
            // (thus sin(delta) = v*sin(90-gamma)/w)
            //###############################################################################
            double x1 = (R1 + alt1) * Math.Cos(phi1) * Math.Sin(pi / 2.0 - theta1);
            double y1 = (R1 + alt1) * Math.Sin(phi1) * Math.Sin(pi / 2.0 - theta1);
            double z1 = (R1 + alt1) * Math.Cos(pi / 2.0 - theta1);
            double x2 = (R2 + alt2) * Math.Cos(phi2) * Math.Sin(pi / 2.0 - theta2);
            double y2 = (R2 + alt2) * Math.Sin(phi2) * Math.Sin(pi / 2.0 - theta2);
            double z2 = (R2 + alt2) * Math.Cos(pi / 2.0 - theta2);
            double d1 = Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1);
            double d2 = Math.Sqrt(x2 * x2 + y2 * y2 + z2 * z2);
            double gamma = Math.Abs(Math.Acos((x1 * x2 + y1 * y2 + z1 * z2) / (d1 * d2)));

            double w = Math.Sqrt((R2 + alt2 + adiff) * (R2 + alt2 + adiff)
                           + (R1 + alt1) * (R1 + alt1)
                           - 2.0 * (R1 + alt1) * (R2 + alt2 + adiff) * Math.Cos(gamma));
            double v = ((alt1 + R1) / Math.Cos(gamma) - R2 - alt2 - adiff);
            dip_angle = -Math.Asin(v * Math.Sin(pi / 2.0 - gamma) / w);
            dip_angle = dip_angle * 180.0 / pi;

            a = Math.Sin(phi2 - phi1) * Math.Cos(theta2);
            b = Math.Cos(theta1) * Math.Sin(theta2) - Math.Sin(theta1) * Math.Cos(theta2) * Math.Cos(phi2 - phi1);
            azimuth = Math.Atan2(a, b);
            azimuth = azimuth * 180.0 / pi;
        }

        private void btn_CenterMap_Click(object sender, EventArgs e)
        {
            double mylatitude = Convert.ToDouble(txt_lat.Text);  //34.459541;
            double mylongitude = Convert.ToDouble(txt_lng.Text);  //-86.432505;
            double myelevation = Convert.ToDouble(txt_alt.Text);  //173;
            ptLLA baseStation = new ptLLA(mylatitude, mylongitude, myelevation);

            gMapControl1.Position = new GMap.NET.PointLatLng(mylatitude, mylongitude);
            mb_center.State = CodeArtEng.Controls.StatusLabelState.Green;
        }

        private void btn_fetch_Click(object sender, EventArgs e)
        {
            // queary api
            CancellationTokenSource? ts;
            CancellationToken ct;
            ts = new CancellationTokenSource();
            ct = ts.Token;
            this.Cursor = Cursors.WaitCursor;
            geoTiffFiles.Clear();

            listBox1.Items.Clear();
            listBox1.Sorted = true;

            Task task = Task.Factory.StartNew(async () =>
            {
                Debug.WriteLine("Fetching Tiffs");
                statusStrip1.Invoke(new Action(() => { tss_msgs.Text = $"Fetching Tiffs"; }));

                // get map extents
                var bounds = gMapControl1.ViewArea;

                string q = $"https://tnmaccess.nationalmap.gov/api/v1/products?bbox={bounds.Left},{bounds.Top},{bounds.Right},{bounds.Bottom}&datasets=National%20Elevation%20Dataset%20%28NED%29%201%2F3%20arc-second&prodFormats=GeoTIFF&outputFormat=JSON";
                //var jsonText = await wc.DownloadStringTaskAsync(q);
                var jsonText = wc.DownloadString(q);
                Debug.WriteLine("JSON Response");
                var jo = JObject.Parse(jsonText);

                int n = Convert.ToInt32(jo["total"].ToString());
                TNM_ITEMS? tnm_ITEMS = JsonConvert.DeserializeObject<TNM_ITEMS>(jo["items"][0].ToString());
                TNM_ITEMS[] tnm_ITEMS_list = JsonConvert.DeserializeObject<TNM_ITEMS[]>(jo["items"].ToString());


                horizLayer?.Markers.Clear();
                horizLayer?.Routes.Clear();
                horizLayer?.Polygons.Clear();
                Application.DoEvents();

                foreach (TNM_ITEMS tnm in tnm_ITEMS_list)
                {
                    string _fname = System.IO.Path.GetFileName(tnm.downloadURL.ToString());
                    MapGeoTiffLimits(tnm.boundingBox, _fname);

                    //listBox1.Items.Add( $"{_fname}  {tnm.boundingBox.ToString()}");
                    DateTime dt = DateTime.ParseExact(tnm.publicationDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime dt2 = DateTime.ParseExact(tnm.dateCreated.Split('T')[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    Debug.WriteLine($"Publication Date: {dt.ToString()}");
                    Debug.WriteLine($"Date Created: {dt2.ToString()}");

                    geoTiffFiles.Add(dt2, tnm.downloadURL.ToString());

                    Debug.WriteLine(tnm.downloadURL.ToString());

                    listBox1.Invoke(new Action(() => { listBox1.Items.Add($"{dt2.ToShortDateString()}\t{_fname} "); }));

                }

                //string filename = $"{txt_label.Text}_{System.IO.Path.GetFileName(tnm_ITEMS.downloadURL.ToString())}";
                //Debug.WriteLine($"Downloading Tiffs: {filename}");
                //wc.DownloadFileAsync(new Uri(tnm_ITEMS.downloadURL.ToString()), Path.Combine(@"C:\temp", filename));
                listBox1.Invoke(new Action(() => { listBox1.SetSelected(listBox1.Items.Count - 1, true); }));

                statusStrip1.Invoke(new Action(() => { tss_msgs.Text = $"{listBox1.Items.Count} files available"; }));
                mb_fetch.Invoke(new Action(() => { mb_fetch.State = CodeArtEng.Controls.StatusLabelState.Green; }));
                this.Cursor = Cursors.Default;
            }, ct);

            ;
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                // prompt for filename
                DateTime dt = DateTime.Parse(listBox1.SelectedItem.ToString().Split('\t')[0]);
                Uri uri = new Uri(geoTiffFiles[dt].ToString());
                string fname = System.IO.Path.GetFileName(uri.LocalPath);
                this.Cursor = Cursors.WaitCursor;

                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.InitialDirectory = @"C:\temp\";
                    saveFileDialog1.FileName = fname;
                    saveFileDialog1.Filter = "GEOTIFF files (*.tif)|*.tif|All files (*.*)|*.*";
                    saveFileDialog1.Title = "SAVE GEOTIFF FILE";
                    saveFileDialog1.FilterIndex = 0;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.OverwritePrompt = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filePath_dted = saveFileDialog1.FileName;
                        Debug.WriteLine($"Downloading Tiff: {fname}");
                        statusStrip1.Invoke(new Action(() => { tss_msgs.Text = $"Downloading Tiff: {fname}"; }));

                        wc.DownloadFileAsync(uri, filePath_dted, mb_download);
                    }
                }



            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            /*
          * DATA DOWNLOADED FROM https://earthexplorer.usgs.gov/
          * CHOOSE GeoTIFF 1 Arc-second FROM SRTM
          * CHOOSE VOID FILLED
          * 
          */

            horizLayer?.Markers.Clear();
            horizLayer?.Routes.Clear();
            horizLayer?.Polygons.Clear();
            Application.DoEvents();


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (!string.IsNullOrEmpty(filePath_dted))
                {
                    openFileDialog.InitialDirectory = Path.GetFullPath(filePath_dted);
                    openFileDialog.FileName = filePath_dted;
                }
                openFileDialog.Filter = $"GEOTIFF files (*.tif)|*.tif|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "LOAD GEOTIFF FILE";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath_dted = openFileDialog.FileName;
                    tss_geoTiffFileName.Text = Path.GetFileName(filePath_dted);


                    double mylatitude = Convert.ToDouble(txt_lat.Text);  //34.459541;
                    double mylongitude = Convert.ToDouble(txt_lng.Text);  //-86.432505;
                    double myelevation = Convert.ToDouble(txt_alt.Text);  //173;
                    ptLLA baseStation = new ptLLA(mylatitude, mylongitude, myelevation);

                    Dataset dataset = Gdal.Open(filePath_dted, Access.GA_ReadOnly); // Open the GeoTIFF
                    Band band = dataset.GetRasterBand(1); // Get the first band (elevation)

                    var projection = dataset.GetProjection();
                    var srs = new OSGeo.OSR.SpatialReference(null);
                    srs.ImportFromWkt(ref projection);
                    tss_projection.Text = srs.GetName();

                    //bool isUTM = !string.IsNullOrEmpty(srs.GetUTMZone().ToString());
                    int utmZone = srs.GetUTMZone();

                    // Get raster dimensions
                    int width = dataset.RasterXSize;
                    int height = dataset.RasterYSize;

                    double[] geotransform = new double[6];
                    dataset.GetGeoTransform(geotransform);

                    double lng0 = 0;
                    double lat0 = 0;
                    double lng1 = 0;
                    double lat1 = 0;

                    if (utmZone != 0)
                    {
                        // Calculate corner coordinates in UTM
                        double minx = geotransform[0];
                        double maxy = geotransform[3];
                        double maxx = geotransform[0] + width * geotransform[1];
                        double miny = geotransform[3] + height * geotransform[5];



                        // Convert UTM to geographic coordinates
                        (lat0, lng0) = UTMUPS.Reverse(utmZone, true, minx, miny);
                        (lat1, lng1) = UTMUPS.Reverse(utmZone, true, maxx, maxy);

                    }
                    else
                    {
                        // Upper-left corner coordinates
                        lng0 = geotransform[0];
                        lat0 = geotransform[3];

                        double dlat = geotransform[5];
                        double dlng = geotransform[1];

                        // Lower-right corner coordinates
                        lng1 = lng0 + width * geotransform[1];
                        lat1 = lat0 + height * geotransform[5];
                    }



                    // Output the coordinates (in the dataset's original SRS)
                    Debug.WriteLine($"Upper-Left: ({lng0}, {lat0})");
                    Debug.WriteLine($"Lower-Right: ({lng1},{lat1})");

                    // show geotiff on map
                    List<PointLatLng> pointsG = new List<PointLatLng>();
                    pointsG.Add(new PointLatLng(lat0, lng0));
                    pointsG.Add(new PointLatLng(lat0, lng1));
                    pointsG.Add(new PointLatLng(lat1, lng1));
                    pointsG.Add(new PointLatLng(lat1, lng0));
                    GMapPolygon polygonG = new GMapPolygon(pointsG, "GEOTIFF");
                    polygonG.Fill = new SolidBrush(Color.FromArgb(50, Color.Gray));
                    polygonG.Stroke = new Pen(Color.Black, 1);
                    horizLayer?.Polygons.Add(polygonG);
                    gMapControl1.Invalidate();

                    dataset.Dispose(); // Free resources

                    tss_msgs.Text = $"File Opened";
                    mb_open.State = CodeArtEng.Controls.StatusLabelState.Green;
                }
            }

        }

        private void btn_Process_Click(object sender, EventArgs e)
        {

            // extract elevations using GDAL

            // HSV FARM
            double mylatitude = Convert.ToDouble(txt_lat.Text);  //34.459541;
            double mylongitude = Convert.ToDouble(txt_lng.Text);  //-86.432505;
            double myelevation = Convert.ToDouble(txt_alt.Text);  //173;
            ptLLA baseStation = new ptLLA(mylatitude, mylongitude, myelevation);

            Dataset dataset = Gdal.Open(filePath_dted, Access.GA_ReadOnly); // Open the GeoTIFF
            Band band = dataset.GetRasterBand(1); // Get the first band (elevation)

            var projection = dataset.GetProjection();
            var srs = new OSGeo.OSR.SpatialReference(null);
            srs.ImportFromWkt(ref projection);
            tss_projection.Text = srs.GetName();

            int utmZone = srs.GetUTMZone();
            bool isUTM = (utmZone != 0);

            // Get raster dimensions
            int width = dataset.RasterXSize;
            int height = dataset.RasterYSize;

            double[] geotransform = new double[6];
            dataset.GetGeoTransform(geotransform);

            double lng0 = 0; double lat0 = 0;
            double lng1 = 0; double lat1 = 0;
            double dlat = 0; double dlng = 0;
            double minx = 0; double maxy = 0;

            if (isUTM)
            {
                // Calculate corner coordinates in UTM
                minx = geotransform[0];
                maxy = geotransform[3];
                double maxx = geotransform[0] + width * geotransform[1];
                double miny = geotransform[3] + height * geotransform[5];



                // Convert UTM to geographic coordinates
                (lat0, lng0) = UTMUPS.Reverse(utmZone, true, minx, miny);
                (lat1, lng1) = UTMUPS.Reverse(utmZone, true, maxx, maxy);

            }
            else
            {
                // Upper-left corner coordinates
                lng0 = geotransform[0];
                lat0 = geotransform[3];

                dlat = geotransform[5];
                dlng = geotransform[1];

                // Lower-right corner coordinates
                lng1 = lng0 + width * geotransform[1];
                lat1 = lat0 + height * geotransform[5];
            }

            double[] seaLevel = new double[360];
            double[] horizon = new double[360];
            double[] distance = new double[360];
            double[] altitudes = new double[360];
            Array.Fill(altitudes, myelevation); // set default to current elevation in case no intercept?

            this.Cursor = Cursors.WaitCursor;

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    double ilat = 0; double ilng = 0;
                    if (isUTM)
                    {
                        double iy = (double)y * geotransform[5] + geotransform[3];
                        double ix = (double)x * geotransform[1] + geotransform[0];
                        (ilat, ilng) = UTMUPS.Reverse(utmZone, true, ix, iy);
                    }
                    else
                    {
                        ilat = (double)y * dlat + lat0;
                        ilng = (double)x * dlng + lng0;
                    }

                    ptLLA pt = new ptLLA(ilat, ilng, myelevation);
                    double groundRange = COMMON.geoDist(baseStation, pt);
                    double bearing = COMMON.GetBearing(baseStation, pt);


                    if (groundRange > 100 && groundRange < 50000)
                    {

                        //double ielev = gtiff.GetElevationAtLatLon(ilat, ilng); // lat, lng?
                        // Read pixel value at specific coordinates (e.g., pixel 10, 20)
                        float[] pixelValue = new float[1];
                        band.ReadRaster(x, y, 1, 1, pixelValue, 1, 1, 0, 0); // Read 1x1 pixel
                        float ielev = pixelValue[0]; // Extract elevation

                        double iaz, ida, idist;
                        calculate_dip_angle(mylatitude, mylongitude, myelevation, ilat, ilng, ielev, pi, out iaz, out ida, out idist, false, true);
                        if (iaz < 0.0) iaz = iaz + 360.0;
                        int fiaz = (int)Math.Floor(iaz); // bin azimuth into 1 deg 

                        if (ida >= horizon[fiaz])
                        {
                            horizon[fiaz] = ida;
                            distance[fiaz] = idist;
                            altitudes[fiaz] = ielev;
                        }

                        // track range to sealevel line
                        calculate_dip_angle(mylatitude, mylongitude, myelevation, ilat, ilng, 0, pi, out iaz, out ida, out idist, false, true);
                        if (idist > seaLevel[fiaz])
                            seaLevel[fiaz] = idist;

                    }

                }
                double pcomplete = (double)x / height * 100;
                progressBar2.Value = (int)Math.Clamp(pcomplete, 0, 100);
            }
            progressBar2.Value = 0;
            this.Cursor = Cursors.Default;
            tss_msgs.Text = $"Process Complete";
            mb_process.State = CodeArtEng.Controls.StatusLabelState.Green;

            List<PointLatLng> points = new List<PointLatLng>();

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog1.Title = "SAVE HORIZON CSV FILE";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath2 = saveFileDialog1.FileName;

                    using (StreamWriter outputFile = new StreamWriter(filePath2))
                    {
                        outputFile.WriteLine($"AZ, EL, RANGE, ALT, SeaLevelRange");
                        for (int i = 0; i < horizon.Length; i++)
                        {
                            outputFile.WriteLine($"{i}, {horizon[i].ToString("0.00")}, {distance[i].ToString("0.00")}, {altitudes[i].ToString("0.00")}, {seaLevel[i].ToString("0.00")}");

                            // overlay horizon on gmap?
                            ptLLA h = COMMON.projectLLA(baseStation, distance[i], i);
                            points.Add(new PointLatLng(h.lat, h.lng));
                        }

                        // overlay viewshed
                        GMapPolygon polygon = new GMapPolygon(points, "HORIZON");
                        polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                        polygon.Stroke = new Pen(Color.Red, 1);
                        horizLayer?.Polygons.Add(polygon);
                    }

                    // write the array as text
                    File.WriteAllLines(filePath2.Replace("csv", "txt"), horizon.Select(d => d.ToString()));

                    //using (StreamWriter writer = new StreamWriter(filePath2.Replace("csv", "txt")))
                    //{
                    //    for (int i = 0; i < horizon.Length; i++)
                    //    {
                    //        writer.Write(horizon[i].ToString("0.00")); // Write the line content
                    //        if (i < lines.Length - 1) // If it's not the last line
                    //        {
                    //            writer.WriteLine(); // Add a newline character
                    //        }
                    //    }
                    //}

                    tss_msgs.Text = $"Horizon file saved: {Path.GetFileName(filePath2)} [{Path.GetFileName(filePath2.Replace("csv", "txt"))}]";


                }
            }
            dataset.Dispose(); // Free resources

        }

        private void gMapControl1_OnMapZoomChanged()
        {

        }
    }
}
