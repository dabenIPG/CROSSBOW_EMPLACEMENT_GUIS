using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CROSSBOW;

namespace CROSSBOW_EMPLACEMENT_GUIS
{
    public partial class frmPAGen : Form
    {
        LCH aKIZ = new LCH();

        public frmPAGen()
        {
            InitializeComponent();
        }

        private void frmPAGen_Load(object sender, EventArgs e)
        {
            //aKIZ.FilePath = @"c:\temp\kiz_auto.txt";
            //aKIZ.MissionID = "CROSSBOW_TEST1";
            //aKIZ.Operator = "IPG";
            //aKIZ.MissionName = "CROSSBOW_TEST1";
            //aKIZ.MissionStartDateTime = DateTime.UtcNow;
            //aKIZ.MissionEndDateTime = DateTime.UtcNow.AddHours(8).AddSeconds(-1);
            //aKIZ.AuthorizationType = LCH.AUTHORIZATION.EXECUTION;
            //dateTimePicker1.Value = aKIZ.MissionStartDateTime;

            buildGrid();
        }
        private void buildGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.MultiSelect = false;
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //dataGridView1.Columns.Add("Target", "Target");
            dataGridView1.Columns.Add("SartTime", "SartTime");
            dataGridView1.Columns.Add("StopTime", "StopTime");
            dataGridView1.Columns.Add("Az1", "Az1");
            dataGridView1.Columns.Add("El1", "El1");
            dataGridView1.Columns.Add("Az2", "Az2");
            dataGridView1.Columns.Add("El2", "El2");

            dataGridView1.Columns["SartTime"].ValueType = typeof(DateTime);
            dataGridView1.Columns["StopTime"].ValueType = typeof(DateTime);

            dataGridView1.Columns["Az1"].ValueType = typeof(double);
            dataGridView1.Columns["El1"].ValueType = typeof(double);
            dataGridView1.Columns["Az2"].ValueType = typeof(double);
            dataGridView1.Columns["El2"].ValueType = typeof(double);


            dataGridView1.Columns["SartTime"].DefaultCellStyle.Format = "MM/dd/yyy HH:mm:ss";
            dataGridView1.Columns["StopTime"].DefaultCellStyle.Format = "MM/dd/yyy HH:mm:ss";
            dataGridView1.Columns["Az1"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Az2"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["El1"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["El2"].DefaultCellStyle.Format = "N2";

            dataGridView1.Columns["SartTime"].Width = 800;
            dataGridView1.Columns["StopTime"].Width = 800;





            int rowId = dataGridView1.Rows.Add();
            DataGridViewRow dgvRow = dataGridView1.Rows[rowId];
            dgvRow.Cells["SartTime"].Value = aKIZ.MissionStartDateTime.ToString("MM/dd/yyy HH:mm:ss");
            dgvRow.Cells["StopTime"].Value = aKIZ.MissionEndDateTime.ToString("MM/dd/yyy HH:mm:ss");
            dgvRow.Cells["Az1"].Value = 10.0;
            dgvRow.Cells["El1"].Value = 1;
            dgvRow.Cells["Az2"].Value = 20.0;
            dgvRow.Cells["El2"].Value = 10.0;


            rowId = dataGridView1.Rows.Add();
            dgvRow = dataGridView1.Rows[rowId];
            dgvRow.Cells["SartTime"].Value = aKIZ.MissionStartDateTime.ToString("MM/dd/yyy HH:mm:ss");
            dgvRow.Cells["StopTime"].Value = aKIZ.MissionEndDateTime.ToString("MM/dd/yyy HH:mm:ss");
            dgvRow.Cells["Az1"].Value = 40.0;
            dgvRow.Cells["El1"].Value = 1.0;
            dgvRow.Cells["Az2"].Value = 50.0;
            dgvRow.Cells["El2"].Value = 10.0;

            //DataGridViewProgressColumn pcolumn = new DataGridViewProgressColumn();
            //pcolumn.Name = "Progress";
            //pcolumn.HeaderText = "TrackAge";
            //pcolumn.Width = 50;
            //pcolumn.ReadOnly = true;
            //dataGridView1.Columns.Add(pcolumn);


        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
        }

        private void btn_Parse_Click(object sender, EventArgs e)
        {
            aKIZ.LCH_Targets.Clear();
            double lat = Convert.ToDouble(txt_lat.Text);
            double lng = Convert.ToDouble(txt_lng.Text);
            double alt = Convert.ToDouble(txt_alt_msl.Text);

            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                if (!dgvRow.IsNewRow)
                    aKIZ.LCH_Targets.Add(new LCH_TARGET(dgvRow, lat, lng, alt));
            }
            Debug.WriteLine("DONE");
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.Title = "Save CROSSBOW Configuration";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.RestoreDirectory = true;
                //saveFileDialog1.ShowDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    aKIZ.FilePath = saveFileDialog1.FileName;
                    aKIZ.Operator = txt_Operator.Text.ToString();
                    aKIZ.AuthorizationType = chk_ForExec.Checked? LCH.AUTHORIZATION.EXECUTION : LCH.AUTHORIZATION.PRACTICE;
                    write_PALOS_File();
                }
            }



        }

        private void write_PALOS_File()
        {
            int dMin = (int)Math.Floor(aKIZ.MissionDuration.TotalMinutes);
            int dSec = (int)(((double)aKIZ.MissionDuration.TotalMinutes - dMin) * 60);

            using (TextWriter tw = File.CreateText(aKIZ.FilePath))
            {

                tw.WriteLine("\t\tClassification: UNCLASSIFIED ");
                tw.WriteLine("");
                tw.WriteLine("KIZ WINDOWS");
                tw.WriteLine(" ");
                //tw.WriteLine("{0,-9}{1}", "Date:", "2025 Jun 29 00:00:01 ");
                tw.WriteLine("{0,-9}{1}", "Date:", DateTime.UtcNow.ToString("yyyy MMM dd HH:mm:ss "));

                tw.WriteLine("{0,-9}{1}", "From:", "IPG");
                tw.WriteLine("{0,-9}{1}", "To:", "CROSSBOW");
                tw.WriteLine("{0,-9}{1}", "Subject:", "KIZ Authorized Shoot (Open) Windows");
                tw.WriteLine(" ");
                tw.WriteLine(" ");
                tw.WriteLine("1. The attached information contains the coordinated and approved ");
                tw.WriteLine("   spatial parameters");
                tw.WriteLine("  ");
                tw.WriteLine("      (a) Authorized Shoot (Open) Windows");
                tw.WriteLine(" ");
                tw.WriteLine("   During Authorized Shoot Windows, the laser owner-operator (O/O) is authorized ");
                tw.WriteLine("   to operate the approved system laser in accordance with the Source/Target ");
                tw.WriteLine("   geometry definitions contained in this report. ");
                tw.WriteLine("");
                tw.WriteLine("2. See below for comments specific to this mission.     ");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("{0,-33}{1}", "Mission ID:", aKIZ.MissionID);
                tw.WriteLine("{0,-33}{1}", "Laser Owner/Operator:", aKIZ.Operator);
                tw.WriteLine("{0,-33}{1}", "Report Date/Time (UTC):", DateTime.UtcNow.ToString("yyyy MMM dd HH:mm:ss "));
                tw.WriteLine("{0,-33}{1}", "Mission Name:", aKIZ.MissionName);
                tw.WriteLine("{0,-33}{1}", "Mission Start Date/Time (UTC):", aKIZ.MissionStartDateTime.ToString("yyyy MMM dd HH:mm:ss "));
                tw.WriteLine("{0,-33}{1}", "Mission Stop  Date/Time (UTC):", aKIZ.MissionEndDateTime.ToString("yyyy MMM dd HH:mm:ss "));
                tw.WriteLine("{0,-33}{1}", "Mission Duration   (HH:MM:SS):", $"{aKIZ.MissionDuration.Hours.ToString("00")}:{aKIZ.MissionDuration.Minutes.ToString("00")}:{aKIZ.MissionDuration.Seconds.ToString("00")}");
                tw.WriteLine("{0,-33}{1}", "Type of Windows in this report:", "Authorized Shoot(Open) Windows");
                tw.WriteLine("{0,-33}{1}", "Comment:", "For Execution");
                tw.WriteLine("{0,-33}{1}", "", "Report file 1 of 1");
                tw.WriteLine("{0,-33}{1}", "Number of Targets:", aKIZ.NumberTarget);
                tw.WriteLine("");
                tw.WriteLine("");
                tw.WriteLine("");

                writeWindows(tw);
            }

            Debug.WriteLine("Done");
        }

        private void writeWindows(TextWriter tw)
        {
            int iw = 1;
            foreach (LCH_TARGET aTarget in aKIZ.LCH_Targets)
            {
                writeWindow(tw, aTarget, iw);
                iw++;
            }
        }

        private void writeWindow(TextWriter tw, LCH_TARGET aTarget, int iw)
        {
            //YYYY MMM dd(DDD) HHMM SS    YYYY MMM dd(DDD) HHMM SS      MM: SS
            //------------------------ - --------------------------------
            //2025 Jun 30(088) 0000 01    2025 Jun 30(088) 0759 59    0479:59

            //Percent = 100.00 %

            //Source Geometry: (WGS - 84)
            //-------------- -
            //Method: Fixed Point
            //Latitude: 34.71624692 degrees N
            //Longitude: 86.64981044 degrees W
            //Altitude: 0.2008 km

            //Target Geometry: (WGS - 84) 1
            //-------------- -
            //Method: Fixed Field of View
            //Azimuth Range:   2.0 to 11.0 degrees
            //Elevation Range: 3.0 to 15.0 degrees
            //

            int dMin = (int)Math.Floor(aTarget.Duration.TotalMinutes);
            int dSec = (int)(((double)aTarget.Duration.TotalMinutes - dMin) * 60);
            string NS = aTarget.Latitude >= 0 ? "N" : "S";
            string EW = aTarget.Longitude >= 0 ? "E" : "W";


            tw.WriteLine("YYYY MMM dd (DDD) HHMM SS    YYYY MMM dd (DDD) HHMM SS      MM:SS");
            tw.WriteLine("-------------------------    -------------------------    -------");
            //tw.WriteLine("2025 Jun 30 (088) 0000 01    2025 Jun 30 (088) 0759 59    0479:59");
            tw.WriteLine($"{aTarget.StartDateTime.ToString("yyyy")} {aTarget.StartDateTime.ToString("MMM")} {aTarget.StartDateTime.ToString("dd")} ({aTarget.StartDateTime.DayOfYear.ToString("000")}) {aTarget.StartDateTime.ToString("HHmm")} {aTarget.StartDateTime.ToString("ss")}    {aTarget.StartDateTime.ToString("yyyy")} {aTarget.EndDateTime.ToString("MMM")} {aTarget.EndDateTime.ToString("dd")} ({aTarget.EndDateTime.DayOfYear.ToString("000")}) {aTarget.EndDateTime.ToString("HHmm")} {aTarget.EndDateTime.ToString("ss")}    {dMin.ToString("0000")}:{dSec.ToString("00")}");
            tw.WriteLine("");
            tw.WriteLine("Percent = 100.00%");
            tw.WriteLine("");
            tw.WriteLine("Source Geometry: (WGS-84)");
            tw.WriteLine("---------------");
            tw.WriteLine("Method: Fixed Point");
            tw.WriteLine($"Latitude:  {(Math.Abs(aTarget.Latitude)).ToString("0.00000000")} degrees {NS}");
            tw.WriteLine($"Longitude: {(Math.Abs(aTarget.Longitude)).ToString("0.00000000")} degrees {EW}");
            tw.WriteLine($"Altitude:  {(aTarget.Altitude / 1000.0).ToString("0.0000")} km");
            tw.WriteLine("");
            tw.WriteLine($"Target Geometry: (WGS-84) {iw}");
            tw.WriteLine("---------------");
            tw.WriteLine("Method: Fixed Field of View");
            tw.WriteLine($"Azimuth Range:   {aTarget.Az1.ToString("0.0")} to {aTarget.Az2.ToString("0.0")} degrees");
            tw.WriteLine($"Elevation Range: {aTarget.El1.ToString("0.0")} to {aTarget.El2.ToString("0.0")} degrees");
            tw.WriteLine("");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dts = dateTimePicker1.Value;
            DateTime dte = dts.AddHours(8).AddSeconds(-1);
            lbl_MissionEndDateTime.Text = dte.ToString("MM/dd/yyyy HH:mm:ss");

            TimeSpan duration = dte.Subtract(dts);

        }
    }
}
