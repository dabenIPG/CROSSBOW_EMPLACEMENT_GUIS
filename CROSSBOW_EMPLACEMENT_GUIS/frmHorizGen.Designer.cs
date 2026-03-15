namespace CROSSBOW_EMPLACEMENT_GUIS
{
    partial class frmHorizGen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            mb_center = new CodeArtEng.Controls.StatusLabel();
            mb_download = new CodeArtEng.Controls.StatusLabel();
            mb_open = new CodeArtEng.Controls.StatusLabel();
            mb_process = new CodeArtEng.Controls.StatusLabel();
            mb_fetch = new CodeArtEng.Controls.StatusLabel();
            btn_fetch = new Button();
            btn_Download = new Button();
            listBox1 = new ListBox();
            txt_label = new TextBox();
            label5 = new Label();
            progressBar2 = new ProgressBar();
            btn_CenterMap = new Button();
            btn_Open = new Button();
            txt_alt = new TextBox();
            label4 = new Label();
            txt_lng = new TextBox();
            label3 = new Label();
            txt_lat = new TextBox();
            label2 = new Label();
            btn_Process = new Button();
            statusStrip1 = new StatusStrip();
            tss_geoTiffFileName = new ToolStripStatusLabel();
            tss_projection = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tss_msgs = new ToolStripStatusLabel();
            panel2 = new Panel();
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(mb_center);
            panel1.Controls.Add(mb_download);
            panel1.Controls.Add(mb_open);
            panel1.Controls.Add(mb_process);
            panel1.Controls.Add(mb_fetch);
            panel1.Controls.Add(btn_fetch);
            panel1.Controls.Add(btn_Download);
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(txt_label);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(progressBar2);
            panel1.Controls.Add(btn_CenterMap);
            panel1.Controls.Add(btn_Open);
            panel1.Controls.Add(txt_alt);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txt_lng);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txt_lat);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btn_Process);
            panel1.Location = new Point(7, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 502);
            panel1.TabIndex = 0;
            // 
            // mb_center
            // 
            mb_center.Location = new Point(98, 168);
            mb_center.Margin = new Padding(4, 3, 4, 3);
            mb_center.MaximumSize = new Size(1166, 18);
            mb_center.MinimumSize = new Size(0, 18);
            mb_center.Name = "mb_center";
            mb_center.Size = new Size(18, 18);
            mb_center.TabIndex = 47;
            mb_center.Text = "<Title>";
            // 
            // mb_download
            // 
            mb_download.Location = new Point(98, 226);
            mb_download.Margin = new Padding(4, 3, 4, 3);
            mb_download.MaximumSize = new Size(1166, 18);
            mb_download.MinimumSize = new Size(0, 18);
            mb_download.Name = "mb_download";
            mb_download.Size = new Size(18, 18);
            mb_download.TabIndex = 46;
            mb_download.Text = "<Title>";
            // 
            // mb_open
            // 
            mb_open.Location = new Point(98, 255);
            mb_open.Margin = new Padding(4, 3, 4, 3);
            mb_open.MaximumSize = new Size(1166, 18);
            mb_open.MinimumSize = new Size(0, 18);
            mb_open.Name = "mb_open";
            mb_open.Size = new Size(18, 18);
            mb_open.TabIndex = 45;
            mb_open.Text = "<Title>";
            // 
            // mb_process
            // 
            mb_process.Location = new Point(98, 284);
            mb_process.Margin = new Padding(4, 3, 4, 3);
            mb_process.MaximumSize = new Size(1166, 18);
            mb_process.MinimumSize = new Size(0, 18);
            mb_process.Name = "mb_process";
            mb_process.Size = new Size(18, 18);
            mb_process.TabIndex = 44;
            mb_process.Text = "<Title>";
            // 
            // mb_fetch
            // 
            mb_fetch.Location = new Point(98, 197);
            mb_fetch.Margin = new Padding(4, 3, 4, 3);
            mb_fetch.MaximumSize = new Size(1166, 18);
            mb_fetch.MinimumSize = new Size(0, 18);
            mb_fetch.Name = "mb_fetch";
            mb_fetch.Size = new Size(18, 18);
            mb_fetch.TabIndex = 43;
            mb_fetch.Text = "<Title>";
            // 
            // btn_fetch
            // 
            btn_fetch.Location = new Point(16, 195);
            btn_fetch.Name = "btn_fetch";
            btn_fetch.Size = new Size(75, 23);
            btn_fetch.TabIndex = 42;
            btn_fetch.Text = "FETCH";
            btn_fetch.UseVisualStyleBackColor = true;
            btn_fetch.Click += btn_fetch_Click;
            // 
            // btn_Download
            // 
            btn_Download.Location = new Point(16, 224);
            btn_Download.Name = "btn_Download";
            btn_Download.Size = new Size(75, 23);
            btn_Download.TabIndex = 39;
            btn_Download.Text = "DOWNLD";
            btn_Download.UseVisualStyleBackColor = true;
            btn_Download.Click += btn_Download_Click;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Bottom;
            listBox1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 325);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(351, 154);
            listBox1.TabIndex = 38;
            // 
            // txt_label
            // 
            txt_label.Location = new Point(91, 9);
            txt_label.Name = "txt_label";
            txt_label.Size = new Size(100, 23);
            txt_label.TabIndex = 37;
            txt_label.Text = "FARM";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 12);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 36;
            label5.Text = "LABEL";
            // 
            // progressBar2
            // 
            progressBar2.Dock = DockStyle.Bottom;
            progressBar2.Location = new Point(0, 479);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(351, 23);
            progressBar2.TabIndex = 35;
            // 
            // btn_CenterMap
            // 
            btn_CenterMap.Location = new Point(16, 166);
            btn_CenterMap.Name = "btn_CenterMap";
            btn_CenterMap.Size = new Size(75, 23);
            btn_CenterMap.TabIndex = 33;
            btn_CenterMap.Text = "CENTER";
            btn_CenterMap.UseVisualStyleBackColor = true;
            btn_CenterMap.Click += btn_CenterMap_Click;
            // 
            // btn_Open
            // 
            btn_Open.Location = new Point(16, 253);
            btn_Open.Name = "btn_Open";
            btn_Open.Size = new Size(75, 23);
            btn_Open.TabIndex = 32;
            btn_Open.Text = "OPEN";
            btn_Open.UseVisualStyleBackColor = true;
            btn_Open.Click += btn_Open_Click;
            // 
            // txt_alt
            // 
            txt_alt.Location = new Point(91, 96);
            txt_alt.Name = "txt_alt";
            txt_alt.Size = new Size(100, 23);
            txt_alt.TabIndex = 31;
            txt_alt.Text = "173";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 99);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 30;
            label4.Text = "ALT MSL [m]";
            // 
            // txt_lng
            // 
            txt_lng.Location = new Point(91, 67);
            txt_lng.Name = "txt_lng";
            txt_lng.Size = new Size(100, 23);
            txt_lng.TabIndex = 29;
            txt_lng.Text = "-86.432505";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 70);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 28;
            label3.Text = "LNG [dec °]";
            // 
            // txt_lat
            // 
            txt_lat.Location = new Point(91, 38);
            txt_lat.Name = "txt_lat";
            txt_lat.Size = new Size(100, 23);
            txt_lat.TabIndex = 27;
            txt_lat.Text = "34.459541";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 41);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 26;
            label2.Text = "LAT [dec °]";
            // 
            // btn_Process
            // 
            btn_Process.Location = new Point(16, 282);
            btn_Process.Name = "btn_Process";
            btn_Process.Size = new Size(75, 23);
            btn_Process.TabIndex = 25;
            btn_Process.Text = "PROCESS";
            btn_Process.UseVisualStyleBackColor = true;
            btn_Process.Click += btn_Process_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tss_geoTiffFileName, tss_projection, toolStripStatusLabel1, tss_msgs });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(984, 24);
            statusStrip1.TabIndex = 17;
            statusStrip1.Text = "statusStrip1";
            // 
            // tss_geoTiffFileName
            // 
            tss_geoTiffFileName.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tss_geoTiffFileName.Name = "tss_geoTiffFileName";
            tss_geoTiffFileName.Size = new Size(17, 19);
            tss_geoTiffFileName.Text = "  ";
            // 
            // tss_projection
            // 
            tss_projection.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tss_projection.Name = "tss_projection";
            tss_projection.Size = new Size(17, 19);
            tss_projection.Text = "  ";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(350, 19);
            // 
            // tss_msgs
            // 
            tss_msgs.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tss_msgs.Name = "tss_msgs";
            tss_msgs.Size = new Size(585, 19);
            tss_msgs.Spring = true;
            tss_msgs.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(gMapControl1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(383, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(601, 574);
            panel2.TabIndex = 18;
            // 
            // gMapControl1
            // 
            gMapControl1.Bearing = 0F;
            gMapControl1.BorderStyle = BorderStyle.FixedSingle;
            gMapControl1.CanDragMap = true;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.EmptyTileColor = Color.Navy;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new Point(0, 0);
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 16;
            gMapControl1.MinZoom = 6;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.ViewCenter;
            gMapControl1.Name = "gMapControl1";
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RetryLoadTile = 0;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl1.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Size = new Size(599, 572);
            gMapControl1.TabIndex = 0;
            gMapControl1.Zoom = 14D;
            gMapControl1.OnMapZoomChanged += gMapControl1_OnMapZoomChanged;
            // 
            // frmHorizGen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 598);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Name = "frmHorizGen";
            Text = "CROSSBOW: HORIZON Generator";
            Load += frmHorizGen_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btn_Download;
        private ListBox listBox1;
        private TextBox txt_label;
        private Label label5;
        private ProgressBar progressBar2;
        private Button btn_CenterMap;
        private Button btn_Open;
        private TextBox txt_alt;
        private Label label4;
        private TextBox txt_lng;
        private Label label3;
        private TextBox txt_lat;
        private Label label2;
        private Button btn_Process;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tss_geoTiffFileName;
        private ToolStripStatusLabel tss_projection;
        private Panel panel2;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tss_msgs;
        private Button btn_fetch;
        private CodeArtEng.Controls.StatusLabel mb_fetch;
        private CodeArtEng.Controls.StatusLabel mb_center;
        private CodeArtEng.Controls.StatusLabel mb_download;
        private CodeArtEng.Controls.StatusLabel mb_open;
        private CodeArtEng.Controls.StatusLabel mb_process;
    }
}