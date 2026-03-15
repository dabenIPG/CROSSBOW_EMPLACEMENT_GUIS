using ScottPlot.Finance;
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
    public partial class frmPAVerify : Form
    {
        LCH aLCH = new LCH();
        LCH aKIZ = new LCH();

        DateTime currentTime = DateTime.UtcNow;
        ptLLA SystemLocation { get; set; } = new ptLLA(37.12464900, -122.20761400, 615);
        string SystemOperator = "IPG";
        private CancellationTokenSource? ts;
        private CancellationToken ct;
        PointF LOS = new PointF();

        public frmPAVerify()
        {
            InitializeComponent();
        }

        #region PICBOX
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            double az = (double)e.X / 2.0 - 180.0;
            az = az < 0 ? az + 360 : az;

            double el = 90.0 - (double)e.Y / 2.0;

            //tss_Coords.Text = $"{az.ToString("0.0")}, {el.ToString("0.0")}";
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            double az = (double)e.X / 2.0 - 180.0;
            az = az < 0 ? az + 360 : az;

            double el = 90.0 - (double)e.Y / 2.0;
            LOS = new PointF((float)az, (float)el);

            tss_Coords.Text = $"{az.ToString("0.0")}, {el.ToString("0.0")}";
            pictureBox1.Invalidate();

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (LCH_TARGET lch in aLCH.LCH_Targets)
            {
                // degees to pix = 1:2

                double az1 = lch.Az1 > 180 ? lch.Az1 - 360 : lch.Az1;
                //double az2 = lch.Az2 > 180 ? lch.Az2 - 360 : lch.Az2;

                int x1 = 2 * 180 + (int)Math.Floor(2 * az1);
                int y1 = 2 * 90 - (int)Math.Floor(2 * lch.El2);
                int dx = (int)Math.Floor(2 * (lch.Az2 - lch.Az1));
                int dy = (int)Math.Floor(2 * (lch.El2 - lch.El1));
                Rectangle r = new Rectangle(x1, y1, dx, dy);

                bool isValid = false;
                foreach (LCH_WINDOW win in lch.LCH_Windows)
                {
                    // check each window
                    if (currentTime.ToUniversalTime() >= win.StartDateTime.ToUniversalTime() && currentTime.ToUniversalTime() <= win.EndDateTime.ToUniversalTime())
                    {
                        UInt64 t1 = (UInt64)(new DateTimeOffset(currentTime.ToUniversalTime()).ToUnixTimeSeconds());
                        UInt64 tw1 = (UInt64)(new DateTimeOffset(win.StartDateTime.ToUniversalTime()).ToUnixTimeSeconds());
                        UInt64 tw2 = (UInt64)(new DateTimeOffset(win.EndDateTime.ToUniversalTime()).ToUnixTimeSeconds());

                        isValid = true;
                        break;
                    }
                }
                SolidBrush semiTransBrush = new SolidBrush(isValid ? Color.FromArgb(128, 0, 255, 0) : Color.FromArgb(128, 255, 0, 0));
                e.Graphics.FillRectangle(semiTransBrush, r);
            }

            foreach (LCH_TARGET kiz in aKIZ.LCH_Targets)
            {
                // degees to pix = 1:2
                double az1 = kiz.Az1 > 180 ? kiz.Az1 - 360 : kiz.Az1;

                int x1 = 2 * 180 + (int)Math.Floor(2 * az1);
                int y1 = 2 * 90 - (int)Math.Floor(2 * kiz.El2);
                int dx = (int)Math.Floor(2 * (kiz.Az2 - kiz.Az1));
                int dy = (int)Math.Floor(2 * (kiz.El2 - kiz.El1));
                Rectangle r = new Rectangle(x1, y1, dx, dy);

                bool isValid = false;
                foreach (LCH_WINDOW win in kiz.LCH_Windows)
                {
                    // check each window
                    if (currentTime.ToUniversalTime() >= win.StartDateTime.ToUniversalTime() && currentTime.ToUniversalTime() <= win.EndDateTime.ToUniversalTime())
                    {
                        UInt64 t1 = (UInt64)(new DateTimeOffset(currentTime.ToUniversalTime()).ToUnixTimeSeconds());
                        UInt64 tw1 = (UInt64)(new DateTimeOffset(win.StartDateTime.ToUniversalTime()).ToUnixTimeSeconds());
                        UInt64 tw2 = (UInt64)(new DateTimeOffset(win.EndDateTime.ToUniversalTime()).ToUnixTimeSeconds());

                        isValid = true;
                        break;
                    }
                }
                //SolidBrush semiTransBrush = new SolidBrush(isValid ? Color.FromArgb(128, 0, 255, 0) : Color.FromArgb(128, 255, 0, 0));
                //e.Graphics.FillRectangle(semiTransBrush, r);

                using (Pen apen = new Pen(isValid ? Color.FromArgb(128, 0, 255, 0) : Color.FromArgb(128, 255, 0, 0), 1))
                {
                    e.Graphics.DrawRectangle(apen, r);
                }

            }


            double az = LOS.X;
            double el = LOS.Y;

            int px = 2 * 180 + (int)Math.Floor(2 * az);
            if (az>180)
                px = (int)((az - 180) * 2);
            int py = 2 * 90 - (int)Math.Floor(2 * el);
            int radius = 2;
            e.Graphics.DrawEllipse(new Pen(Color.Black, 2), px - radius, py - radius, radius * 2, radius * 2);


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                StartPaint();
            else
                StopPaint();
        }
        public void StartPaint()
        {
            ts = new CancellationTokenSource();
            ct = ts.Token;
            Debug.WriteLine("Starting Painter");
            backgroundPaint();
        }
        public void StopPaint()
        {
            Debug.WriteLine("Stopping Painter");
            ts?.Cancel();
        }
        private void backgroundPaint()
        {

            // Start a task - this runs on the background thread...
            Task task = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (ct.IsCancellationRequested)
                    {
                        // another thread decided to cancel
                        Debug.WriteLine("Painiter CANCELLED");

                        break;
                    }
                    Thread.Sleep(50);
                    pictureBox1.Invalidate();
                    //drawViewPort_LCH();


                }
                while (!ct.IsCancellationRequested);
            }, ct);
        }



        #endregion

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            tss_ScrollTime.Text = currentTime.ToUniversalTime().ToString("MM/dd/yyyy HH:mm:ss");
        }
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            currentTime = aLCH.MissionStartDateTime.ToUniversalTime().AddSeconds(trackBar2.Value);
        }
        private void txt_SystemOperator_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SystemOperator = txt_SystemOperator.Text;
                aLCH.SystemOperator = SystemOperator;
                aKIZ.SystemOperator = SystemOperator;
            }
        }

        #region LCH
        private void btn_LCH_LoadFile_Click(object sender, EventArgs e)
        {
            // load PAM file and start parsing
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\Scratch";
                openFileDialog.Filter = "LCH files (*LCH*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "LOAD LCH FILE";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Debug.Write($"Opening LCH file {Path.GetFileName(openFileDialog.FileName)}");
                    
                    lbl_LCH_fname.Text = Path.GetFileName(openFileDialog.FileName);

                    double Undulation = Convert.ToDouble(txt_undulation.Text);

                    aLCH = new LCH(openFileDialog.FileName, LCH.FILETYPE.LCH, SystemLocation, SystemOperator, Undulation);
                    lbl_LCH_MissionID.Text = string.Format("{0,-15} {1,-30}", "Mission ID:", aLCH.MissionID);
                    lbl_LCH_Operator.Text = string.Format("{0,-15} {1,-30}", "Operator:", aLCH.Operator);
                    lbl_LCH_MissionName.Text = string.Format("{0,-15} {1, -30}", "Mission Name:", aLCH.MissionName);
                    lbl_LCH_MissionStartDate.Text = string.Format("{0,-15} {1,-30}", "Start Date/Time:", aLCH.MissionStartDateTime.ToUniversalTime().ToString("MM/dd/yyyy HH:mm:ss"));
                    lbl_LCH_MissionEndDate.Text = string.Format("{0,-15} {1,-30}", "End Date/Time:", aLCH.MissionEndDateTime.ToUniversalTime().ToString("MM/dd/yyyy HH:mm:ss"));
                    lbl_LCH_MissionDuration.Text = string.Format("{0,-15} {1,-30}", "Duration:", aLCH.MissionDuration.ToString());

                    mb_LCH_ForExec.State = aLCH.isForExecution ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
                    mb_LCH_isOperatorValid.State = aLCH.isOperatorValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
                    mb_LCH_isLocationValid.State = aLCH.isLocationValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;


                    lbl_LCH_nTargets.Text = string.Format("{0,-15} {1,-30}", "N Target:", aLCH.NumberTarget.ToString());
                    lbl_LCH_WindowBounds.Text = string.Format("{0,-15} {1,-30}", "Window Bounds:", aLCH.Bounds);
                    lbl_LCH_nWindows.Text = string.Format("{0,-15} {1,-30}", "N Windows:", aLCH.NumberWindows.ToString());

                    currentTime = aLCH.MissionStartDateTime.ToUniversalTime();
                    trackBar2.Minimum = 0;
                    trackBar2.Maximum = (int)aLCH.MissionDuration.TotalSeconds;
                    trackBar2.TickFrequency = trackBar2.Maximum / 100;
                    trackBar2.LargeChange = trackBar2.Maximum / 100;

                    checkBox1.Checked = true;
                }
            }
        }

        private void btn_LCH_CheckLocalVote_Click(object sender, EventArgs e)
        {
            aLCH.CheckLocalVote(currentTime, LOS);
            mb_LCH_Vote.State = aLCH.WindowVote ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
            mb_LCH_TotalVote.State = aLCH.TotalVote ? CodeArtEng.Controls.StatusLabelState.Green : (aLCH.WindowVote ? CodeArtEng.Controls.StatusLabelState.Yellow : CodeArtEng.Controls.StatusLabelState.Red);

            mb_LCH_isOperatorValid.State = aLCH.isOperatorValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
            mb_LCH_isLocationValid.State = aLCH.isLocationValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;

        }
        #endregion

        #region KIZ
        private void btn_KIZ_LoadFile_Click(object sender, EventArgs e)
        {
            // load PAM file and start parsing
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\Scratch";
                openFileDialog.Filter = "KIZ files (*KIZ*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "LOAD KIZ FILE";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Debug.Write($"Opening KIZ file {Path.GetFileName(openFileDialog.FileName)}");

                    double Undulation = Convert.ToDouble(txt_undulation.Text);

                    lbl_KIZ_fname.Text = Path.GetFileName(openFileDialog.FileName);

                    aKIZ = new LCH(openFileDialog.FileName, LCH.FILETYPE.KIZ, SystemLocation, SystemOperator, Undulation);
                    lbl_KIZ_MissionID.Text = string.Format("{0,-15} {1,-30}", "Mission ID:", aKIZ.MissionID);
                    lbl_KIZ_Operator.Text = string.Format("{0,-15} {1,-30}", "Operator:", aKIZ.Operator);
                    lbl_KIZ_MissionName.Text = string.Format("{0,-15} {1, -30}", "Mission Name:", aKIZ.MissionName);
                    lbl_KIZ_MissionStartDate.Text = string.Format("{0,-15} {1,-30}", "Start Date/Time:", aKIZ.MissionStartDateTime.ToUniversalTime().ToString("MM/dd/yyyy HH:mm:ss"));
                    lbl_KIZ_MissionEndDate.Text = string.Format("{0,-15} {1,-30}", "End Date/Time:", aKIZ.MissionEndDateTime.ToUniversalTime().ToString("MM/dd/yyyy HH:mm:ss"));
                    lbl_KIZ_MissionDuration.Text = string.Format("{0,-15} {1,-30}", "Duration:", aKIZ.MissionDuration.ToString());

                    mb_KIZ_ForExec.State = aKIZ.isForExecution ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
                    mb_KIZ_isOperatorValid.State = aKIZ.isOperatorValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
                    mb_KIZ_isLocationValid.State = aKIZ.isLocationValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;

                    lbl_KIZ_nTargets.Text = string.Format("{0,-15} {1,-30}", "N Target:", aKIZ.NumberTarget.ToString());
                    lbl_KIZ_WindowBounds.Text = string.Format("{0,-15} {1,-30}", "Window Bounds:", aKIZ.Bounds);
                    lbl_KIZ_nWindows.Text = string.Format("{0,-15} {1,-30}", "N Windows:", aKIZ.NumberWindows.ToString());

                    currentTime = aKIZ.MissionStartDateTime.ToUniversalTime();
                    trackBar2.Minimum = 0;
                    trackBar2.Maximum = (int)aKIZ.MissionDuration.TotalSeconds;
                    trackBar2.TickFrequency = trackBar2.Maximum / 100;
                    trackBar2.LargeChange = trackBar2.Maximum / 100;

                    checkBox1.Checked = true;

                }
            }
        }

        private void btn_KIZ_CheckLocalVote_Click(object sender, EventArgs e)
        {
            aKIZ.CheckLocalVote(currentTime, LOS);
            mb_KIZ_Vote.State = aKIZ.WindowVote ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
            mb_KIZ_TotalVote.State = aKIZ.TotalVote ? CodeArtEng.Controls.StatusLabelState.Green : (aKIZ.WindowVote ? CodeArtEng.Controls.StatusLabelState.Yellow : CodeArtEng.Controls.StatusLabelState.Red);

            mb_KIZ_isOperatorValid.State = aKIZ.isOperatorValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;
            mb_KIZ_isLocationValid.State = aKIZ.isLocationValid ? CodeArtEng.Controls.StatusLabelState.Green : CodeArtEng.Controls.StatusLabelState.Red;

        }

        #endregion


        private void btn_reset_timeLimits_Click(object sender, EventArgs e)
        {
            if (aKIZ.NumberTarget > 0)
            {
                trackBar2.Minimum = 0;
                trackBar2.Maximum = (int)aKIZ.MissionDuration.TotalSeconds;
                trackBar2.TickFrequency = trackBar2.Maximum / 100;
                trackBar2.LargeChange = trackBar2.Maximum / 100;
            }
            if (aKIZ.NumberTarget > 0)
            {
                if ((int)aKIZ.MissionDuration.TotalSeconds > trackBar2.Maximum)
                    trackBar2.Maximum = (int)aKIZ.MissionDuration.TotalSeconds;

                trackBar2.TickFrequency = trackBar2.Maximum / 100;
                trackBar2.LargeChange = trackBar2.Maximum / 100;
            }


        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            double lat = Convert.ToDouble(txt_lat_test.Text);
            double lng = Convert.ToDouble(txt_lng_test.Text);
            double alt_msl = Convert.ToDouble(txt_alt_msl_test.Text);

            SystemOperator = txt_SystemOperator.Text;

            aLCH.SystemOperator = SystemOperator;
            aLCH.SystemLocation = new ptLLA(lat, lng, alt_msl);

            aKIZ.SystemOperator = SystemOperator;
            aKIZ.SystemLocation = new ptLLA(lat, lng, alt_msl);

        }
    }
}
