namespace CROSSBOW_EMPLACEMENT_GUIS
{
    partial class frmCUESim
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cmbMapSources = new ComboBox();
            btn_CenterMap = new Button();
            txt_Map_ALT = new TextBox();
            txt_Map_Lat = new TextBox();
            txt_Map_Lng = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            tabPage2 = new TabPage();
            txt_radius = new TextBox();
            chk_EnablePattern = new CheckBox();
            rad_pattern_circle = new RadioButton();
            tabPage3 = new TabPage();
            txt_TargetIP = new TextBox();
            chk_SendData = new CheckBox();
            statusStrip1 = new StatusStrip();
            tss_LoRaMsg = new ToolStripStatusLabel();
            tss_UTCTime = new ToolStripStatusLabel();
            gMap = new GMap.NET.WindowsForms.GMapControl();
            groupBox2 = new GroupBox();
            lblRover_Speed = new Label();
            lblRover_Heading = new Label();
            lblRover_FixType = new Label();
            lblRover_SIV = new Label();
            lblRover_Date = new Label();
            lblRover_dt = new Label();
            lblRover_ALT = new Label();
            lblRover_LNG = new Label();
            lblRover_LAT = new Label();
            timSimAC = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            timUDP = new System.Windows.Forms.Timer(components);
            txtCueResponse = new TextBox();
            tabPage4 = new TabPage();
            txt_HyperionIP = new TextBox();
            chk_SensorSim = new CheckBox();
            chk_HyperionSniff = new CheckBox();
            btn_ResetCounters = new Button();
            lbl_PacketsSent = new Label();
            lbl_PacketsRx = new Label();
            lbl_PacketsPass = new Label();
            lbl_PacketsFail = new Label();
            lstVerifyLog = new ListBox();
            timer_SnifferStats = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(264, 192);
            tabControl1.TabIndex = 41;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cmbMapSources);
            tabPage1.Controls.Add(btn_CenterMap);
            tabPage1.Controls.Add(txt_Map_ALT);
            tabPage1.Controls.Add(txt_Map_Lat);
            tabPage1.Controls.Add(txt_Map_Lng);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(256, 164);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "MAP";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbMapSources
            // 
            cmbMapSources.Dock = DockStyle.Bottom;
            cmbMapSources.FormattingEnabled = true;
            cmbMapSources.Location = new Point(3, 138);
            cmbMapSources.Name = "cmbMapSources";
            cmbMapSources.Size = new Size(250, 23);
            cmbMapSources.TabIndex = 39;
            // 
            // btn_CenterMap
            // 
            btn_CenterMap.Location = new Point(95, 95);
            btn_CenterMap.Name = "btn_CenterMap";
            btn_CenterMap.Size = new Size(51, 23);
            btn_CenterMap.TabIndex = 38;
            btn_CenterMap.Text = "Center";
            btn_CenterMap.UseVisualStyleBackColor = true;
            btn_CenterMap.Click += btn_CenterMap_Click;
            // 
            // txt_Map_ALT
            // 
            txt_Map_ALT.Location = new Point(46, 66);
            txt_Map_ALT.Name = "txt_Map_ALT";
            txt_Map_ALT.Size = new Size(100, 23);
            txt_Map_ALT.TabIndex = 37;
            // 
            // txt_Map_Lat
            // 
            txt_Map_Lat.Location = new Point(46, 6);
            txt_Map_Lat.Name = "txt_Map_Lat";
            txt_Map_Lat.Size = new Size(100, 23);
            txt_Map_Lat.TabIndex = 32;
            // 
            // txt_Map_Lng
            // 
            txt_Map_Lng.Location = new Point(46, 36);
            txt_Map_Lng.Name = "txt_Map_Lng";
            txt_Map_Lng.Size = new Size(100, 23);
            txt_Map_Lng.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 13);
            label4.Name = "label4";
            label4.Size = new Size(26, 15);
            label4.TabIndex = 33;
            label4.Text = "LAT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 35;
            label2.Text = "ALT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 43);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 34;
            label3.Text = "LNG";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txt_radius);
            tabPage2.Controls.Add(chk_EnablePattern);
            tabPage2.Controls.Add(rad_pattern_circle);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(256, 164);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "SIM";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_radius
            // 
            txt_radius.Location = new Point(73, 53);
            txt_radius.Name = "txt_radius";
            txt_radius.Size = new Size(57, 23);
            txt_radius.TabIndex = 1;
            txt_radius.Text = "10.0";
            // 
            // chk_EnablePattern
            // 
            chk_EnablePattern.AutoSize = true;
            chk_EnablePattern.Location = new Point(12, 20);
            chk_EnablePattern.Name = "chk_EnablePattern";
            chk_EnablePattern.Size = new Size(61, 19);
            chk_EnablePattern.TabIndex = 0;
            chk_EnablePattern.Text = "Enable";
            chk_EnablePattern.UseVisualStyleBackColor = true;
            chk_EnablePattern.CheckedChanged += chk_EnablePattern_CheckedChanged;
            // 
            // rad_pattern_circle
            // 
            rad_pattern_circle.AutoSize = true;
            rad_pattern_circle.Checked = true;
            rad_pattern_circle.Location = new Point(12, 55);
            rad_pattern_circle.Name = "rad_pattern_circle";
            rad_pattern_circle.Size = new Size(55, 19);
            rad_pattern_circle.TabIndex = 0;
            rad_pattern_circle.TabStop = true;
            rad_pattern_circle.Text = "Circle";
            rad_pattern_circle.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(txt_TargetIP);
            tabPage3.Controls.Add(chk_SendData);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(256, 164);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "UDP";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_TargetIP
            // 
            txt_TargetIP.Location = new Point(13, 18);
            txt_TargetIP.Name = "txt_TargetIP";
            txt_TargetIP.Size = new Size(100, 23);
            txt_TargetIP.TabIndex = 24;
            txt_TargetIP.Text = "192.168.1.8";
            // 
            // chk_SendData
            // 
            chk_SendData.AutoSize = true;
            chk_SendData.Location = new Point(11, 58);
            chk_SendData.Name = "chk_SendData";
            chk_SendData.Size = new Size(81, 19);
            chk_SendData.TabIndex = 23;
            chk_SendData.Text = "CONNECT";
            chk_SendData.UseVisualStyleBackColor = true;
            chk_SendData.CheckedChanged += chk_SendData_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tss_LoRaMsg, tss_UTCTime });
            statusStrip1.Location = new Point(0, 601);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(951, 22);
            statusStrip1.TabIndex = 42;
            statusStrip1.Text = "statusStrip1";
            // 
            // tss_LoRaMsg
            // 
            tss_LoRaMsg.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tss_LoRaMsg.Name = "tss_LoRaMsg";
            tss_LoRaMsg.Size = new Size(736, 17);
            tss_LoRaMsg.Spring = true;
            tss_LoRaMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tss_UTCTime
            // 
            tss_UTCTime.AutoSize = false;
            tss_UTCTime.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tss_UTCTime.Name = "tss_UTCTime";
            tss_UTCTime.Size = new Size(200, 17);
            tss_UTCTime.Text = "MM/dd/yyyy HH:mm:ss.ff";
            tss_UTCTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gMap
            // 
            gMap.Bearing = 0F;
            gMap.BorderStyle = BorderStyle.FixedSingle;
            gMap.CanDragMap = true;
            gMap.EmptyTileColor = Color.Navy;
            gMap.GrayScaleMode = false;
            gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMap.LevelsKeepInMemory = 5;
            gMap.Location = new Point(273, 2);
            gMap.MarkersEnabled = true;
            gMap.MaxZoom = 2;
            gMap.MinZoom = 2;
            gMap.MouseWheelZoomEnabled = true;
            gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMap.Name = "gMap";
            gMap.NegativeMode = false;
            gMap.PolygonsEnabled = true;
            gMap.RetryLoadTile = 0;
            gMap.RoutesEnabled = true;
            gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMap.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMap.ShowTileGridLines = false;
            gMap.Size = new Size(666, 596);
            gMap.TabIndex = 43;
            gMap.Zoom = 0D;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblRover_Speed);
            groupBox2.Controls.Add(lblRover_Heading);
            groupBox2.Controls.Add(lblRover_FixType);
            groupBox2.Controls.Add(lblRover_SIV);
            groupBox2.Controls.Add(lblRover_Date);
            groupBox2.Controls.Add(lblRover_dt);
            groupBox2.Controls.Add(lblRover_ALT);
            groupBox2.Controls.Add(lblRover_LNG);
            groupBox2.Controls.Add(lblRover_LAT);
            groupBox2.Location = new Point(3, 196);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(262, 238);
            groupBox2.TabIndex = 44;
            groupBox2.TabStop = false;
            groupBox2.Text = "ROVER";
            // 
            // lblRover_Speed
            // 
            lblRover_Speed.AutoSize = true;
            lblRover_Speed.Location = new Point(15, 204);
            lblRover_Speed.Name = "lblRover_Speed";
            lblRover_Speed.Size = new Size(42, 15);
            lblRover_Speed.TabIndex = 33;
            lblRover_Speed.Text = "Speed:";
            // 
            // lblRover_Heading
            // 
            lblRover_Heading.AutoSize = true;
            lblRover_Heading.Location = new Point(15, 182);
            lblRover_Heading.Name = "lblRover_Heading";
            lblRover_Heading.Size = new Size(55, 15);
            lblRover_Heading.TabIndex = 32;
            lblRover_Heading.Text = "Heading:";
            // 
            // lblRover_FixType
            // 
            lblRover_FixType.AutoSize = true;
            lblRover_FixType.Location = new Point(15, 72);
            lblRover_FixType.Name = "lblRover_FixType";
            lblRover_FixType.Size = new Size(49, 15);
            lblRover_FixType.TabIndex = 30;
            lblRover_FixType.Text = "Fix Type";
            // 
            // lblRover_SIV
            // 
            lblRover_SIV.AutoSize = true;
            lblRover_SIV.Location = new Point(15, 160);
            lblRover_SIV.Name = "lblRover_SIV";
            lblRover_SIV.Size = new Size(23, 15);
            lblRover_SIV.TabIndex = 16;
            lblRover_SIV.Text = "SIV";
            // 
            // lblRover_Date
            // 
            lblRover_Date.AutoSize = true;
            lblRover_Date.Location = new Point(15, 50);
            lblRover_Date.Name = "lblRover_Date";
            lblRover_Date.Size = new Size(31, 15);
            lblRover_Date.TabIndex = 8;
            lblRover_Date.Text = "Date";
            // 
            // lblRover_dt
            // 
            lblRover_dt.AutoSize = true;
            lblRover_dt.Location = new Point(15, 28);
            lblRover_dt.Name = "lblRover_dt";
            lblRover_dt.Size = new Size(18, 15);
            lblRover_dt.TabIndex = 7;
            lblRover_dt.Text = "dt";
            // 
            // lblRover_ALT
            // 
            lblRover_ALT.AutoSize = true;
            lblRover_ALT.Location = new Point(15, 138);
            lblRover_ALT.Name = "lblRover_ALT";
            lblRover_ALT.Size = new Size(26, 15);
            lblRover_ALT.TabIndex = 6;
            lblRover_ALT.Text = "ALT";
            // 
            // lblRover_LNG
            // 
            lblRover_LNG.AutoSize = true;
            lblRover_LNG.Location = new Point(15, 116);
            lblRover_LNG.Name = "lblRover_LNG";
            lblRover_LNG.Size = new Size(30, 15);
            lblRover_LNG.TabIndex = 5;
            lblRover_LNG.Text = "LNG";
            // 
            // lblRover_LAT
            // 
            lblRover_LAT.AutoSize = true;
            lblRover_LAT.Location = new Point(15, 94);
            lblRover_LAT.Name = "lblRover_LAT";
            lblRover_LAT.Size = new Size(26, 15);
            lblRover_LAT.TabIndex = 4;
            lblRover_LAT.Text = "LAT";
            // 
            // timSimAC
            // 
            timSimAC.Tick += timSimAC_Tick;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timUDP
            // 
            timUDP.Tick += timUDP_Tick;
            // 
            // txtCueResponse
            // 
            txtCueResponse.Location = new Point(3, 447);
            txtCueResponse.Multiline = true;
            txtCueResponse.Name = "txtCueResponse";
            txtCueResponse.Size = new Size(260, 74);
            txtCueResponse.TabIndex = 45;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lbl_PacketsFail);
            tabPage4.Controls.Add(lbl_PacketsPass);
            tabPage4.Controls.Add(lbl_PacketsRx);
            tabPage4.Controls.Add(lbl_PacketsSent);
            tabPage4.Controls.Add(btn_ResetCounters);
            tabPage4.Controls.Add(chk_HyperionSniff);
            tabPage4.Controls.Add(chk_SensorSim);
            tabPage4.Controls.Add(txt_HyperionIP);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(256, 164);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Verify";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // txt_HyperionIP
            // 
            txt_HyperionIP.Location = new Point(6, 6);
            txt_HyperionIP.Name = "txt_HyperionIP";
            txt_HyperionIP.Size = new Size(100, 23);
            txt_HyperionIP.TabIndex = 0;
            txt_HyperionIP.Text = "127.0.0.1";
            // 
            // chk_SensorSim
            // 
            chk_SensorSim.AutoSize = true;
            chk_SensorSim.Location = new Point(6, 35);
            chk_SensorSim.Name = "chk_SensorSim";
            chk_SensorSim.Size = new Size(128, 19);
            chk_SensorSim.TabIndex = 1;
            chk_SensorSim.Text = "Inject → HYPERION";
            chk_SensorSim.UseVisualStyleBackColor = true;
            chk_SensorSim.CheckedChanged += chk_SensorSim_CheckedChanged;
            // 
            // chk_HyperionSniff
            // 
            chk_HyperionSniff.AutoSize = true;
            chk_HyperionSniff.Location = new Point(6, 60);
            chk_HyperionSniff.Name = "chk_HyperionSniff";
            chk_HyperionSniff.Size = new Size(123, 19);
            chk_HyperionSniff.TabIndex = 2;
            chk_HyperionSniff.Text = "Sniff ← HYPERION";
            chk_HyperionSniff.UseVisualStyleBackColor = true;
            chk_HyperionSniff.CheckedChanged += chk_HyperionSniff_CheckedChanged;
            // 
            // btn_ResetCounters
            // 
            btn_ResetCounters.Location = new Point(112, 6);
            btn_ResetCounters.Name = "btn_ResetCounters";
            btn_ResetCounters.Size = new Size(56, 23);
            btn_ResetCounters.TabIndex = 3;
            btn_ResetCounters.Text = "Reset";
            btn_ResetCounters.UseVisualStyleBackColor = true;
            btn_ResetCounters.Click += btn_ResetCounters_Click;
            // 
            // lbl_PacketsSent
            // 
            lbl_PacketsSent.AutoSize = true;
            lbl_PacketsSent.Location = new Point(7, 87);
            lbl_PacketsSent.Name = "lbl_PacketsSent";
            lbl_PacketsSent.Size = new Size(42, 15);
            lbl_PacketsSent.TabIndex = 4;
            lbl_PacketsSent.Text = "Sent: 0";
            // 
            // lbl_PacketsRx
            // 
            lbl_PacketsRx.AutoSize = true;
            lbl_PacketsRx.Location = new Point(8, 113);
            lbl_PacketsRx.Name = "lbl_PacketsRx";
            lbl_PacketsRx.Size = new Size(32, 15);
            lbl_PacketsRx.TabIndex = 5;
            lbl_PacketsRx.Text = "Rx: 0";
            // 
            // lbl_PacketsPass
            // 
            lbl_PacketsPass.AutoSize = true;
            lbl_PacketsPass.Location = new Point(100, 90);
            lbl_PacketsPass.Name = "lbl_PacketsPass";
            lbl_PacketsPass.Size = new Size(42, 15);
            lbl_PacketsPass.TabIndex = 6;
            lbl_PacketsPass.Text = "Pass: 0";
            // 
            // lbl_PacketsFail
            // 
            lbl_PacketsFail.AutoSize = true;
            lbl_PacketsFail.Location = new Point(102, 119);
            lbl_PacketsFail.Name = "lbl_PacketsFail";
            lbl_PacketsFail.Size = new Size(37, 15);
            lbl_PacketsFail.TabIndex = 7;
            lbl_PacketsFail.Text = "Fail: 0";
            // 
            // lstVerifyLog
            // 
            lstVerifyLog.FormattingEnabled = true;
            lstVerifyLog.HorizontalScrollbar = true;
            lstVerifyLog.ItemHeight = 15;
            lstVerifyLog.Location = new Point(3, 527);
            lstVerifyLog.Name = "lstVerifyLog";
            lstVerifyLog.Size = new Size(260, 49);
            lstVerifyLog.TabIndex = 46;
            // 
            // timer_SnifferStats
            // 
            timer_SnifferStats.Tick += timer_SnifferStats_Tick;
            // 
            // frmCUESim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 623);
            Controls.Add(lstVerifyLog);
            Controls.Add(txtCueResponse);
            Controls.Add(groupBox2);
            Controls.Add(gMap);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl1);
            Name = "frmCUESim";
            Text = "CROSSBOW: CUE SIMULATOR";
            FormClosing += frmCUESim_FormClosing;
            Load += frmCUESim_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private ComboBox cmbMapSources;
        private Button btn_CenterMap;
        private TextBox txt_Map_ALT;
        private TextBox txt_Map_Lat;
        private TextBox txt_Map_Lng;
        private Label label4;
        private Label label2;
        private Label label3;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox txt_TargetIP;
        private CheckBox chk_SendData;
        private StatusStrip statusStrip1;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private TextBox txt_radius;
        private CheckBox chk_EnablePattern;
        private RadioButton rad_pattern_circle;
        private GroupBox groupBox2;
        private Label lblRover_Speed;
        private Label lblRover_Heading;
        private Label lblRover_FixType;
        private Label lblRover_SIV;
        private Label lblRover_Date;
        private Label lblRover_dt;
        private Label lblRover_ALT;
        private Label lblRover_LNG;
        private Label lblRover_LAT;
        private System.Windows.Forms.Timer timSimAC;
        private System.Windows.Forms.Timer timer1;
        private ToolStripStatusLabel tss_UTCTime;
        private ToolStripStatusLabel tss_LoRaMsg;
        private System.Windows.Forms.Timer timUDP;
        private TextBox txtCueResponse;
        private TabPage tabPage4;
        private CheckBox chk_HyperionSniff;
        private CheckBox chk_SensorSim;
        private TextBox txt_HyperionIP;
        private Button btn_ResetCounters;
        private Label lbl_PacketsRx;
        private Label lbl_PacketsSent;
        private Label lbl_PacketsFail;
        private Label lbl_PacketsPass;
        private ListBox lstVerifyLog;
        private System.Windows.Forms.Timer timer_SnifferStats;
    }
}