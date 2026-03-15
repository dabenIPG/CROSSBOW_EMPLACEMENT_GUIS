namespace CROSSBOW_EMPLACEMENT_GUIS
{
    partial class frmLORA
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
            chk_SendData = new CheckBox();
            chk_UDP_Transmit = new CheckBox();
            cmbSerialPorts = new ComboBox();
            btn_SerialConnect = new Button();
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
            gMap = new GMap.NET.WindowsForms.GMapControl();
            statusStrip1 = new StatusStrip();
            tss_LoRaMsg = new ToolStripStatusLabel();
            tss_UTCTime = new ToolStripStatusLabel();
            btn_CenterMap = new Button();
            txt_Map_ALT = new TextBox();
            txt_Map_Lng = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txt_Map_Lat = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cmbMapSources = new ComboBox();
            tabPage2 = new TabPage();
            btn_Serial_ATI = new Button();
            btn_Serial_RTI = new Button();
            tabPage3 = new TabPage();
            txt_TargetIP = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timUDP = new System.Windows.Forms.Timer(components);
            chk_Serial_ATO_Enable = new CheckBox();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // chk_SendData
            // 
            chk_SendData.AutoSize = true;
            chk_SendData.Location = new Point(11, 58);
            chk_SendData.Name = "chk_SendData";
            chk_SendData.Size = new Size(82, 19);
            chk_SendData.TabIndex = 23;
            chk_SendData.Text = "CONNECT";
            chk_SendData.UseVisualStyleBackColor = true;
            chk_SendData.CheckedChanged += chk_SendData_CheckedChanged;
            // 
            // chk_UDP_Transmit
            // 
            chk_UDP_Transmit.AutoSize = true;
            chk_UDP_Transmit.Location = new Point(11, 84);
            chk_UDP_Transmit.Name = "chk_UDP_Transmit";
            chk_UDP_Transmit.Size = new Size(84, 19);
            chk_UDP_Transmit.TabIndex = 22;
            chk_UDP_Transmit.Text = "TRANSMIT";
            chk_UDP_Transmit.UseVisualStyleBackColor = true;
            chk_UDP_Transmit.CheckedChanged += chk_UDP_Transmit_CheckedChanged;
            // 
            // cmbSerialPorts
            // 
            cmbSerialPorts.FormattingEnabled = true;
            cmbSerialPorts.Location = new Point(6, 17);
            cmbSerialPorts.Name = "cmbSerialPorts";
            cmbSerialPorts.Size = new Size(121, 23);
            cmbSerialPorts.TabIndex = 20;
            // 
            // btn_SerialConnect
            // 
            btn_SerialConnect.Location = new Point(6, 46);
            btn_SerialConnect.Name = "btn_SerialConnect";
            btn_SerialConnect.Size = new Size(75, 23);
            btn_SerialConnect.TabIndex = 19;
            btn_SerialConnect.Text = "Connect";
            btn_SerialConnect.UseVisualStyleBackColor = true;
            btn_SerialConnect.Click += btn_SerialConnect_Click;
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
            groupBox2.Size = new Size(262, 288);
            groupBox2.TabIndex = 18;
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
            lblRover_ALT.Size = new Size(27, 15);
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
            lblRover_LAT.Size = new Size(27, 15);
            lblRover_LAT.TabIndex = 4;
            lblRover_LAT.Text = "LAT";
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
            gMap.Size = new Size(521, 482);
            gMap.TabIndex = 19;
            gMap.Zoom = 0D;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tss_LoRaMsg, tss_UTCTime });
            statusStrip1.Location = new Point(0, 499);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(832, 24);
            statusStrip1.TabIndex = 20;
            statusStrip1.Text = "statusStrip1";
            // 
            // tss_LoRaMsg
            // 
            tss_LoRaMsg.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tss_LoRaMsg.Name = "tss_LoRaMsg";
            tss_LoRaMsg.Size = new Size(617, 19);
            tss_LoRaMsg.Spring = true;
            tss_LoRaMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tss_UTCTime
            // 
            tss_UTCTime.AutoSize = false;
            tss_UTCTime.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tss_UTCTime.Name = "tss_UTCTime";
            tss_UTCTime.Size = new Size(200, 19);
            tss_UTCTime.Text = "MM/dd/yyyy HH:mm:ss.ff";
            tss_UTCTime.TextAlign = ContentAlignment.MiddleLeft;
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
            // txt_Map_Lng
            // 
            txt_Map_Lng.Location = new Point(46, 36);
            txt_Map_Lng.Name = "txt_Map_Lng";
            txt_Map_Lng.Size = new Size(100, 23);
            txt_Map_Lng.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 70);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 35;
            label2.Text = "ALT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 40);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 34;
            label3.Text = "LNG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 10);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 33;
            label4.Text = "LAT";
            // 
            // txt_Map_Lat
            // 
            txt_Map_Lat.Location = new Point(46, 6);
            txt_Map_Lat.Name = "txt_Map_Lat";
            txt_Map_Lat.Size = new Size(100, 23);
            txt_Map_Lat.TabIndex = 32;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(264, 192);
            tabControl1.TabIndex = 40;
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
            // tabPage2
            // 
            tabPage2.Controls.Add(chk_Serial_ATO_Enable);
            tabPage2.Controls.Add(btn_Serial_ATI);
            tabPage2.Controls.Add(btn_Serial_RTI);
            tabPage2.Controls.Add(cmbSerialPorts);
            tabPage2.Controls.Add(btn_SerialConnect);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(256, 164);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "SERIAL";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_Serial_ATI
            // 
            btn_Serial_ATI.Location = new Point(87, 96);
            btn_Serial_ATI.Name = "btn_Serial_ATI";
            btn_Serial_ATI.Size = new Size(75, 23);
            btn_Serial_ATI.TabIndex = 23;
            btn_Serial_ATI.Text = "ATI";
            btn_Serial_ATI.UseVisualStyleBackColor = true;
            btn_Serial_ATI.Click += btn_Serial_ATI_Click;
            // 
            // btn_Serial_RTI
            // 
            btn_Serial_RTI.Location = new Point(6, 96);
            btn_Serial_RTI.Name = "btn_Serial_RTI";
            btn_Serial_RTI.Size = new Size(75, 23);
            btn_Serial_RTI.TabIndex = 22;
            btn_Serial_RTI.Text = "RTI";
            btn_Serial_RTI.UseVisualStyleBackColor = true;
            btn_Serial_RTI.Click += btn_Serial_RTI_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(txt_TargetIP);
            tabPage3.Controls.Add(chk_SendData);
            tabPage3.Controls.Add(chk_UDP_Transmit);
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
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timUDP
            // 
            timUDP.Tick += timUDP_Tick;
            // 
            // chk_Serial_ATO_Enable
            // 
            chk_Serial_ATO_Enable.AutoSize = true;
            chk_Serial_ATO_Enable.Location = new Point(11, 129);
            chk_Serial_ATO_Enable.Name = "chk_Serial_ATO_Enable";
            chk_Serial_ATO_Enable.Size = new Size(129, 19);
            chk_Serial_ATO_Enable.TabIndex = 24;
            chk_Serial_ATO_Enable.Text = "ENABLE TRANSMIT";
            chk_Serial_ATO_Enable.UseVisualStyleBackColor = true;
            chk_Serial_ATO_Enable.CheckedChanged += chk_Serial_ATO_Enable_CheckedChanged;
            // 
            // frmLORA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 523);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Controls.Add(gMap);
            Controls.Add(groupBox2);
            Name = "frmLORA";
            Text = "CROSSBOW: LORA TOOL";
            FormClosing += frmLORA_FormClosing;
            Load += frmLORA_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox chk_SendData;
        private CheckBox chk_UDP_Transmit;
        private Label label1;
        private ComboBox cmbSerialPorts;
        private Button btn_SerialConnect;
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
        private GMap.NET.WindowsForms.GMapControl gMap;
        private StatusStrip statusStrip1;
        private Button btn_CenterMap;
        private TextBox txt_Map_ALT;
        private TextBox txt_Map_Lng;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_Map_Lat;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timUDP;
        private ToolStripStatusLabel tss_LoRaMsg;
        private ComboBox cmbMapSources;
        private TabPage tabPage3;
        private TextBox txt_TargetIP;
        private ToolStripStatusLabel tss_UTCTime;
        private Button btn_Serial_ATI;
        private Button btn_Serial_RTI;
        private CheckBox chk_Serial_ATO_Enable;
    }
}