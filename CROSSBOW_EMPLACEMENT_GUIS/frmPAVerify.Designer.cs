namespace   CROSSBOW_EMPLACEMENT_GUIS
{
    partial class frmPAVerify
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
            txt_SystemOperator = new TextBox();
            label7 = new Label();
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            mb_LCH_TotalVote = new CodeArtEng.Controls.StatusLabel();
            mb_LCH_Vote = new CodeArtEng.Controls.StatusLabel();
            mb_LCH_isLocationValid = new CodeArtEng.Controls.StatusLabel();
            mb_LCH_isOperatorValid = new CodeArtEng.Controls.StatusLabel();
            mb_LCH_ForExec = new CodeArtEng.Controls.StatusLabel();
            btn_LCH_CheckLocalVote = new Button();
            btn_LCH_LoadFile = new Button();
            lbl_LCH_nWindows = new Label();
            lbl_LCH_WindowBounds = new Label();
            lbl_LCH_MissionDuration = new Label();
            lbl_LCH_nTargets = new Label();
            lbl_LCH_MissionEndDate = new Label();
            lbl_LCH_MissionStartDate = new Label();
            lbl_LCH_MissionName = new Label();
            lbl_LCH_Operator = new Label();
            lbl_LCH_MissionID = new Label();
            groupBox4 = new GroupBox();
            mb_KIZ_TotalVote = new CodeArtEng.Controls.StatusLabel();
            mb_KIZ_Vote = new CodeArtEng.Controls.StatusLabel();
            mb_KIZ_isLocationValid = new CodeArtEng.Controls.StatusLabel();
            mb_KIZ_isOperatorValid = new CodeArtEng.Controls.StatusLabel();
            mb_KIZ_ForExec = new CodeArtEng.Controls.StatusLabel();
            btn_KIZ_CheckLocalVote = new Button();
            lbl_KIZ_nWindows = new Label();
            lbl_KIZ_WindowBounds = new Label();
            lbl_KIZ_MissionDuration = new Label();
            lbl_KIZ_nTargets = new Label();
            lbl_KIZ_MissionEndDate = new Label();
            lbl_KIZ_MissionStartDate = new Label();
            lbl_KIZ_MissionName = new Label();
            lbl_KIZ_Operator = new Label();
            lbl_KIZ_MissionID = new Label();
            btn_KIZ_LoadFile = new Button();
            statusStrip1 = new StatusStrip();
            tss_ScrollTime = new ToolStripStatusLabel();
            tss_Coords = new ToolStripStatusLabel();
            tss_VoteResult = new ToolStripStatusLabel();
            tssStatus_Date = new ToolStripStatusLabel();
            panel1 = new Panel();
            btn_reset_timeLimits = new Button();
            label6 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            trackBar2 = new TrackBar();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            errorProvider1 = new ErrorProvider(components);
            toolTip1 = new ToolTip(components);
            groupBox6 = new GroupBox();
            btn_Update = new Button();
            txt_undulation = new TextBox();
            label1 = new Label();
            txt_alt_msl_test = new TextBox();
            label9 = new Label();
            txt_lng_test = new TextBox();
            label10 = new Label();
            txt_lat_test = new TextBox();
            label15 = new Label();
            lbl_KIZ_fname = new Label();
            lbl_LCH_fname = new Label();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // txt_SystemOperator
            // 
            txt_SystemOperator.Font = new Font("Courier New", 9F);
            txt_SystemOperator.Location = new Point(63, 119);
            txt_SystemOperator.Name = "txt_SystemOperator";
            txt_SystemOperator.Size = new Size(61, 21);
            txt_SystemOperator.TabIndex = 52;
            txt_SystemOperator.Text = "IPG";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 122);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 51;
            label7.Text = "OPER:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(13, 323);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(53, 19);
            checkBox1.TabIndex = 63;
            checkBox1.Text = "Paint";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbl_LCH_fname);
            groupBox1.Controls.Add(mb_LCH_TotalVote);
            groupBox1.Controls.Add(mb_LCH_Vote);
            groupBox1.Controls.Add(mb_LCH_isLocationValid);
            groupBox1.Controls.Add(mb_LCH_isOperatorValid);
            groupBox1.Controls.Add(mb_LCH_ForExec);
            groupBox1.Controls.Add(btn_LCH_CheckLocalVote);
            groupBox1.Controls.Add(btn_LCH_LoadFile);
            groupBox1.Controls.Add(lbl_LCH_nWindows);
            groupBox1.Controls.Add(lbl_LCH_WindowBounds);
            groupBox1.Controls.Add(lbl_LCH_MissionDuration);
            groupBox1.Controls.Add(lbl_LCH_nTargets);
            groupBox1.Controls.Add(lbl_LCH_MissionEndDate);
            groupBox1.Controls.Add(lbl_LCH_MissionStartDate);
            groupBox1.Controls.Add(lbl_LCH_MissionName);
            groupBox1.Controls.Add(lbl_LCH_Operator);
            groupBox1.Controls.Add(lbl_LCH_MissionID);
            groupBox1.Location = new Point(495, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 360);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "LCH FILE INFORMATION";
            // 
            // mb_LCH_TotalVote
            // 
            mb_LCH_TotalVote.Location = new Point(186, 286);
            mb_LCH_TotalVote.Margin = new Padding(4, 3, 4, 3);
            mb_LCH_TotalVote.MaximumSize = new Size(1166, 18);
            mb_LCH_TotalVote.MinimumSize = new Size(0, 18);
            mb_LCH_TotalVote.Name = "mb_LCH_TotalVote";
            mb_LCH_TotalVote.Size = new Size(80, 18);
            mb_LCH_TotalVote.TabIndex = 49;
            mb_LCH_TotalVote.Text = "Total Vote";
            // 
            // mb_LCH_Vote
            // 
            mb_LCH_Vote.Location = new Point(97, 286);
            mb_LCH_Vote.Margin = new Padding(4, 3, 4, 3);
            mb_LCH_Vote.MaximumSize = new Size(1166, 18);
            mb_LCH_Vote.MinimumSize = new Size(0, 18);
            mb_LCH_Vote.Name = "mb_LCH_Vote";
            mb_LCH_Vote.Size = new Size(80, 18);
            mb_LCH_Vote.TabIndex = 48;
            mb_LCH_Vote.Text = "Vote";
            // 
            // mb_LCH_isLocationValid
            // 
            mb_LCH_isLocationValid.Location = new Point(185, 323);
            mb_LCH_isLocationValid.Margin = new Padding(4, 3, 4, 3);
            mb_LCH_isLocationValid.MaximumSize = new Size(1166, 18);
            mb_LCH_isLocationValid.MinimumSize = new Size(0, 18);
            mb_LCH_isLocationValid.Name = "mb_LCH_isLocationValid";
            mb_LCH_isLocationValid.Size = new Size(80, 18);
            mb_LCH_isLocationValid.TabIndex = 47;
            mb_LCH_isLocationValid.Text = "Location";
            // 
            // mb_LCH_isOperatorValid
            // 
            mb_LCH_isOperatorValid.Location = new Point(97, 323);
            mb_LCH_isOperatorValid.Margin = new Padding(4, 3, 4, 3);
            mb_LCH_isOperatorValid.MaximumSize = new Size(1166, 18);
            mb_LCH_isOperatorValid.MinimumSize = new Size(0, 18);
            mb_LCH_isOperatorValid.Name = "mb_LCH_isOperatorValid";
            mb_LCH_isOperatorValid.Size = new Size(80, 18);
            mb_LCH_isOperatorValid.TabIndex = 46;
            mb_LCH_isOperatorValid.Text = "Operator";
            // 
            // mb_LCH_ForExec
            // 
            mb_LCH_ForExec.Location = new Point(8, 323);
            mb_LCH_ForExec.Margin = new Padding(4, 3, 4, 3);
            mb_LCH_ForExec.MaximumSize = new Size(1166, 18);
            mb_LCH_ForExec.MinimumSize = new Size(0, 18);
            mb_LCH_ForExec.Name = "mb_LCH_ForExec";
            mb_LCH_ForExec.Size = new Size(80, 18);
            mb_LCH_ForExec.TabIndex = 45;
            mb_LCH_ForExec.Text = "Execution";
            // 
            // btn_LCH_CheckLocalVote
            // 
            btn_LCH_CheckLocalVote.Location = new Point(8, 284);
            btn_LCH_CheckLocalVote.Name = "btn_LCH_CheckLocalVote";
            btn_LCH_CheckLocalVote.Size = new Size(75, 23);
            btn_LCH_CheckLocalVote.TabIndex = 40;
            btn_LCH_CheckLocalVote.Text = "CHECK";
            btn_LCH_CheckLocalVote.UseVisualStyleBackColor = true;
            btn_LCH_CheckLocalVote.Click += btn_LCH_CheckLocalVote_Click;
            // 
            // btn_LCH_LoadFile
            // 
            btn_LCH_LoadFile.Location = new Point(8, 22);
            btn_LCH_LoadFile.Name = "btn_LCH_LoadFile";
            btn_LCH_LoadFile.Size = new Size(75, 23);
            btn_LCH_LoadFile.TabIndex = 37;
            btn_LCH_LoadFile.Text = "LOAD";
            btn_LCH_LoadFile.UseVisualStyleBackColor = true;
            btn_LCH_LoadFile.Click += btn_LCH_LoadFile_Click;
            // 
            // lbl_LCH_nWindows
            // 
            lbl_LCH_nWindows.AutoSize = true;
            lbl_LCH_nWindows.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_nWindows.Location = new Point(6, 236);
            lbl_LCH_nWindows.Name = "lbl_LCH_nWindows";
            lbl_LCH_nWindows.Size = new Size(77, 15);
            lbl_LCH_nWindows.TabIndex = 17;
            lbl_LCH_nWindows.Text = "N Windows:";
            // 
            // lbl_LCH_WindowBounds
            // 
            lbl_LCH_WindowBounds.AutoSize = true;
            lbl_LCH_WindowBounds.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_WindowBounds.Location = new Point(6, 261);
            lbl_LCH_WindowBounds.Name = "lbl_LCH_WindowBounds";
            lbl_LCH_WindowBounds.Size = new Size(105, 15);
            lbl_LCH_WindowBounds.TabIndex = 16;
            lbl_LCH_WindowBounds.Text = "Window Bounds:";
            // 
            // lbl_LCH_MissionDuration
            // 
            lbl_LCH_MissionDuration.AutoSize = true;
            lbl_LCH_MissionDuration.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_MissionDuration.Location = new Point(6, 184);
            lbl_LCH_MissionDuration.Name = "lbl_LCH_MissionDuration";
            lbl_LCH_MissionDuration.Size = new Size(70, 15);
            lbl_LCH_MissionDuration.TabIndex = 11;
            lbl_LCH_MissionDuration.Text = "Duration:";
            // 
            // lbl_LCH_nTargets
            // 
            lbl_LCH_nTargets.AutoSize = true;
            lbl_LCH_nTargets.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_nTargets.Location = new Point(6, 211);
            lbl_LCH_nTargets.Name = "lbl_LCH_nTargets";
            lbl_LCH_nTargets.Size = new Size(77, 15);
            lbl_LCH_nTargets.TabIndex = 9;
            lbl_LCH_nTargets.Text = "N Targets:";
            // 
            // lbl_LCH_MissionEndDate
            // 
            lbl_LCH_MissionEndDate.AutoSize = true;
            lbl_LCH_MissionEndDate.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_MissionEndDate.Location = new Point(6, 159);
            lbl_LCH_MissionEndDate.Name = "lbl_LCH_MissionEndDate";
            lbl_LCH_MissionEndDate.Size = new Size(70, 15);
            lbl_LCH_MissionEndDate.TabIndex = 8;
            lbl_LCH_MissionEndDate.Text = "End Date:";
            // 
            // lbl_LCH_MissionStartDate
            // 
            lbl_LCH_MissionStartDate.AutoSize = true;
            lbl_LCH_MissionStartDate.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_MissionStartDate.Location = new Point(6, 134);
            lbl_LCH_MissionStartDate.Name = "lbl_LCH_MissionStartDate";
            lbl_LCH_MissionStartDate.Size = new Size(91, 15);
            lbl_LCH_MissionStartDate.TabIndex = 7;
            lbl_LCH_MissionStartDate.Text = "Start Date: ";
            // 
            // lbl_LCH_MissionName
            // 
            lbl_LCH_MissionName.AutoSize = true;
            lbl_LCH_MissionName.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_MissionName.Location = new Point(6, 109);
            lbl_LCH_MissionName.Name = "lbl_LCH_MissionName";
            lbl_LCH_MissionName.Size = new Size(105, 15);
            lbl_LCH_MissionName.TabIndex = 6;
            lbl_LCH_MissionName.Text = "Mission Name: ";
            // 
            // lbl_LCH_Operator
            // 
            lbl_LCH_Operator.AutoSize = true;
            lbl_LCH_Operator.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_Operator.Location = new Point(6, 84);
            lbl_LCH_Operator.Name = "lbl_LCH_Operator";
            lbl_LCH_Operator.Size = new Size(70, 15);
            lbl_LCH_Operator.TabIndex = 5;
            lbl_LCH_Operator.Text = "Operator:";
            // 
            // lbl_LCH_MissionID
            // 
            lbl_LCH_MissionID.AutoSize = true;
            lbl_LCH_MissionID.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_MissionID.Location = new Point(6, 59);
            lbl_LCH_MissionID.Name = "lbl_LCH_MissionID";
            lbl_LCH_MissionID.Size = new Size(91, 15);
            lbl_LCH_MissionID.TabIndex = 4;
            lbl_LCH_MissionID.Text = "Mission ID: ";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbl_KIZ_fname);
            groupBox4.Controls.Add(mb_KIZ_TotalVote);
            groupBox4.Controls.Add(mb_KIZ_Vote);
            groupBox4.Controls.Add(mb_KIZ_isLocationValid);
            groupBox4.Controls.Add(mb_KIZ_isOperatorValid);
            groupBox4.Controls.Add(mb_KIZ_ForExec);
            groupBox4.Controls.Add(btn_KIZ_CheckLocalVote);
            groupBox4.Controls.Add(lbl_KIZ_nWindows);
            groupBox4.Controls.Add(lbl_KIZ_WindowBounds);
            groupBox4.Controls.Add(lbl_KIZ_MissionDuration);
            groupBox4.Controls.Add(lbl_KIZ_nTargets);
            groupBox4.Controls.Add(lbl_KIZ_MissionEndDate);
            groupBox4.Controls.Add(lbl_KIZ_MissionStartDate);
            groupBox4.Controls.Add(lbl_KIZ_MissionName);
            groupBox4.Controls.Add(lbl_KIZ_Operator);
            groupBox4.Controls.Add(lbl_KIZ_MissionID);
            groupBox4.Controls.Add(btn_KIZ_LoadFile);
            groupBox4.Location = new Point(189, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(300, 360);
            groupBox4.TabIndex = 32;
            groupBox4.TabStop = false;
            groupBox4.Text = "KIZ FILE INFORMATION";
            // 
            // mb_KIZ_TotalVote
            // 
            mb_KIZ_TotalVote.Location = new Point(184, 286);
            mb_KIZ_TotalVote.Margin = new Padding(4, 3, 4, 3);
            mb_KIZ_TotalVote.MaximumSize = new Size(1166, 18);
            mb_KIZ_TotalVote.MinimumSize = new Size(0, 18);
            mb_KIZ_TotalVote.Name = "mb_KIZ_TotalVote";
            mb_KIZ_TotalVote.Size = new Size(80, 18);
            mb_KIZ_TotalVote.TabIndex = 46;
            mb_KIZ_TotalVote.Text = "Total Vote";
            // 
            // mb_KIZ_Vote
            // 
            mb_KIZ_Vote.Location = new Point(95, 286);
            mb_KIZ_Vote.Margin = new Padding(4, 3, 4, 3);
            mb_KIZ_Vote.MaximumSize = new Size(1166, 18);
            mb_KIZ_Vote.MinimumSize = new Size(0, 18);
            mb_KIZ_Vote.Name = "mb_KIZ_Vote";
            mb_KIZ_Vote.Size = new Size(80, 18);
            mb_KIZ_Vote.TabIndex = 45;
            mb_KIZ_Vote.Text = "Vote";
            // 
            // mb_KIZ_isLocationValid
            // 
            mb_KIZ_isLocationValid.Location = new Point(184, 323);
            mb_KIZ_isLocationValid.Margin = new Padding(4, 3, 4, 3);
            mb_KIZ_isLocationValid.MaximumSize = new Size(1166, 18);
            mb_KIZ_isLocationValid.MinimumSize = new Size(0, 18);
            mb_KIZ_isLocationValid.Name = "mb_KIZ_isLocationValid";
            mb_KIZ_isLocationValid.Size = new Size(80, 18);
            mb_KIZ_isLocationValid.TabIndex = 44;
            mb_KIZ_isLocationValid.Text = "Location";
            // 
            // mb_KIZ_isOperatorValid
            // 
            mb_KIZ_isOperatorValid.Location = new Point(95, 323);
            mb_KIZ_isOperatorValid.Margin = new Padding(4, 3, 4, 3);
            mb_KIZ_isOperatorValid.MaximumSize = new Size(1166, 18);
            mb_KIZ_isOperatorValid.MinimumSize = new Size(0, 18);
            mb_KIZ_isOperatorValid.Name = "mb_KIZ_isOperatorValid";
            mb_KIZ_isOperatorValid.Size = new Size(80, 18);
            mb_KIZ_isOperatorValid.TabIndex = 43;
            mb_KIZ_isOperatorValid.Text = "Operator";
            // 
            // mb_KIZ_ForExec
            // 
            mb_KIZ_ForExec.Location = new Point(7, 323);
            mb_KIZ_ForExec.Margin = new Padding(4, 3, 4, 3);
            mb_KIZ_ForExec.MaximumSize = new Size(1166, 18);
            mb_KIZ_ForExec.MinimumSize = new Size(0, 18);
            mb_KIZ_ForExec.Name = "mb_KIZ_ForExec";
            mb_KIZ_ForExec.Size = new Size(80, 18);
            mb_KIZ_ForExec.TabIndex = 42;
            mb_KIZ_ForExec.Text = "Execution";
            // 
            // btn_KIZ_CheckLocalVote
            // 
            btn_KIZ_CheckLocalVote.Location = new Point(8, 284);
            btn_KIZ_CheckLocalVote.Name = "btn_KIZ_CheckLocalVote";
            btn_KIZ_CheckLocalVote.Size = new Size(75, 23);
            btn_KIZ_CheckLocalVote.TabIndex = 41;
            btn_KIZ_CheckLocalVote.Text = "CHECK";
            btn_KIZ_CheckLocalVote.UseVisualStyleBackColor = true;
            btn_KIZ_CheckLocalVote.Click += btn_KIZ_CheckLocalVote_Click;
            // 
            // lbl_KIZ_nWindows
            // 
            lbl_KIZ_nWindows.AutoSize = true;
            lbl_KIZ_nWindows.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_nWindows.Location = new Point(6, 236);
            lbl_KIZ_nWindows.Name = "lbl_KIZ_nWindows";
            lbl_KIZ_nWindows.Size = new Size(77, 15);
            lbl_KIZ_nWindows.TabIndex = 17;
            lbl_KIZ_nWindows.Text = "N Windows:";
            // 
            // lbl_KIZ_WindowBounds
            // 
            lbl_KIZ_WindowBounds.AutoSize = true;
            lbl_KIZ_WindowBounds.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_WindowBounds.Location = new Point(6, 261);
            lbl_KIZ_WindowBounds.Name = "lbl_KIZ_WindowBounds";
            lbl_KIZ_WindowBounds.Size = new Size(105, 15);
            lbl_KIZ_WindowBounds.TabIndex = 16;
            lbl_KIZ_WindowBounds.Text = "Window Bounds:";
            // 
            // lbl_KIZ_MissionDuration
            // 
            lbl_KIZ_MissionDuration.AutoSize = true;
            lbl_KIZ_MissionDuration.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_MissionDuration.Location = new Point(6, 184);
            lbl_KIZ_MissionDuration.Name = "lbl_KIZ_MissionDuration";
            lbl_KIZ_MissionDuration.Size = new Size(70, 15);
            lbl_KIZ_MissionDuration.TabIndex = 11;
            lbl_KIZ_MissionDuration.Text = "Duration:";
            // 
            // lbl_KIZ_nTargets
            // 
            lbl_KIZ_nTargets.AutoSize = true;
            lbl_KIZ_nTargets.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_nTargets.Location = new Point(6, 211);
            lbl_KIZ_nTargets.Name = "lbl_KIZ_nTargets";
            lbl_KIZ_nTargets.Size = new Size(77, 15);
            lbl_KIZ_nTargets.TabIndex = 9;
            lbl_KIZ_nTargets.Text = "N Targets:";
            // 
            // lbl_KIZ_MissionEndDate
            // 
            lbl_KIZ_MissionEndDate.AutoSize = true;
            lbl_KIZ_MissionEndDate.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_MissionEndDate.Location = new Point(6, 159);
            lbl_KIZ_MissionEndDate.Name = "lbl_KIZ_MissionEndDate";
            lbl_KIZ_MissionEndDate.Size = new Size(70, 15);
            lbl_KIZ_MissionEndDate.TabIndex = 8;
            lbl_KIZ_MissionEndDate.Text = "End Date:";
            // 
            // lbl_KIZ_MissionStartDate
            // 
            lbl_KIZ_MissionStartDate.AutoSize = true;
            lbl_KIZ_MissionStartDate.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_MissionStartDate.Location = new Point(6, 134);
            lbl_KIZ_MissionStartDate.Name = "lbl_KIZ_MissionStartDate";
            lbl_KIZ_MissionStartDate.Size = new Size(91, 15);
            lbl_KIZ_MissionStartDate.TabIndex = 7;
            lbl_KIZ_MissionStartDate.Text = "Start Date: ";
            // 
            // lbl_KIZ_MissionName
            // 
            lbl_KIZ_MissionName.AutoSize = true;
            lbl_KIZ_MissionName.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_MissionName.Location = new Point(6, 109);
            lbl_KIZ_MissionName.Name = "lbl_KIZ_MissionName";
            lbl_KIZ_MissionName.Size = new Size(105, 15);
            lbl_KIZ_MissionName.TabIndex = 6;
            lbl_KIZ_MissionName.Text = "Mission Name: ";
            // 
            // lbl_KIZ_Operator
            // 
            lbl_KIZ_Operator.AutoSize = true;
            lbl_KIZ_Operator.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_Operator.Location = new Point(6, 84);
            lbl_KIZ_Operator.Name = "lbl_KIZ_Operator";
            lbl_KIZ_Operator.Size = new Size(70, 15);
            lbl_KIZ_Operator.TabIndex = 5;
            lbl_KIZ_Operator.Text = "Operator:";
            // 
            // lbl_KIZ_MissionID
            // 
            lbl_KIZ_MissionID.AutoSize = true;
            lbl_KIZ_MissionID.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_MissionID.Location = new Point(6, 59);
            lbl_KIZ_MissionID.Name = "lbl_KIZ_MissionID";
            lbl_KIZ_MissionID.Size = new Size(91, 15);
            lbl_KIZ_MissionID.TabIndex = 4;
            lbl_KIZ_MissionID.Text = "Mission ID: ";
            // 
            // btn_KIZ_LoadFile
            // 
            btn_KIZ_LoadFile.Location = new Point(6, 22);
            btn_KIZ_LoadFile.Name = "btn_KIZ_LoadFile";
            btn_KIZ_LoadFile.Size = new Size(75, 23);
            btn_KIZ_LoadFile.TabIndex = 0;
            btn_KIZ_LoadFile.Text = "LOAD";
            btn_KIZ_LoadFile.UseVisualStyleBackColor = true;
            btn_KIZ_LoadFile.Click += btn_KIZ_LoadFile_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tss_ScrollTime, tss_Coords, tss_VoteResult, tssStatus_Date });
            statusStrip1.Location = new Point(0, 839);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(818, 22);
            statusStrip1.TabIndex = 33;
            statusStrip1.Text = "statusStrip1";
            // 
            // tss_ScrollTime
            // 
            tss_ScrollTime.Name = "tss_ScrollTime";
            tss_ScrollTime.Size = new Size(118, 17);
            tss_ScrollTime.Text = "toolStripStatusLabel1";
            // 
            // tss_Coords
            // 
            tss_Coords.Name = "tss_Coords";
            tss_Coords.Size = new Size(118, 17);
            tss_Coords.Text = "toolStripStatusLabel1";
            // 
            // tss_VoteResult
            // 
            tss_VoteResult.Name = "tss_VoteResult";
            tss_VoteResult.Size = new Size(449, 17);
            tss_VoteResult.Spring = true;
            tss_VoteResult.Text = "INTERLOCK";
            // 
            // tssStatus_Date
            // 
            tssStatus_Date.Name = "tssStatus_Date";
            tssStatus_Date.Size = new Size(118, 17);
            tssStatus_Date.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btn_reset_timeLimits);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(trackBar2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 377);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 441);
            panel1.TabIndex = 48;
            // 
            // btn_reset_timeLimits
            // 
            btn_reset_timeLimits.Location = new Point(339, 379);
            btn_reset_timeLimits.Name = "btn_reset_timeLimits";
            btn_reset_timeLimits.Size = new Size(59, 23);
            btn_reset_timeLimits.TabIndex = 49;
            btn_reset_timeLimits.Text = "RESET";
            btn_reset_timeLimits.UseVisualStyleBackColor = true;
            btn_reset_timeLimits.Click += btn_reset_timeLimits_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 352);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 43;
            label6.Text = "-90°";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(729, 370);
            label14.Name = "label14";
            label14.Size = new Size(35, 15);
            label14.TabIndex = 42;
            label14.Text = "180°";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(40, 370);
            label13.Name = "label13";
            label13.Size = new Size(42, 15);
            label13.TabIndex = 41;
            label13.Text = "-180°";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(20, 172);
            label12.Name = "label12";
            label12.Size = new Size(21, 15);
            label12.TabIndex = 40;
            label12.Text = "0°";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(13, 7);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 39;
            label11.Text = "90°";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // trackBar2
            // 
            trackBar2.AutoSize = false;
            trackBar2.Dock = DockStyle.Bottom;
            trackBar2.Location = new Point(0, 408);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(782, 31);
            trackBar2.TabIndex = 18;
            trackBar2.Scroll += trackBar2_Scroll;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(44, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(720, 360);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btn_Update);
            groupBox6.Controls.Add(txt_undulation);
            groupBox6.Controls.Add(label1);
            groupBox6.Controls.Add(checkBox1);
            groupBox6.Controls.Add(txt_SystemOperator);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(txt_alt_msl_test);
            groupBox6.Controls.Add(label9);
            groupBox6.Controls.Add(txt_lng_test);
            groupBox6.Controls.Add(label10);
            groupBox6.Controls.Add(txt_lat_test);
            groupBox6.Controls.Add(label15);
            groupBox6.Location = new Point(0, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(183, 359);
            groupBox6.TabIndex = 49;
            groupBox6.TabStop = false;
            groupBox6.Text = "Test Parameters";
            // 
            // btn_Update
            // 
            btn_Update.Location = new Point(15, 151);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(75, 23);
            btn_Update.TabIndex = 66;
            btn_Update.Text = "Update";
            btn_Update.UseVisualStyleBackColor = true;
            btn_Update.Click += btn_Update_Click;
            // 
            // txt_undulation
            // 
            txt_undulation.Font = new Font("Courier New", 9F);
            txt_undulation.Location = new Point(56, 270);
            txt_undulation.Name = "txt_undulation";
            txt_undulation.Size = new Size(61, 21);
            txt_undulation.TabIndex = 65;
            txt_undulation.Text = "-33.5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 273);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 64;
            label1.Text = "UND:";
            // 
            // txt_alt_msl_test
            // 
            txt_alt_msl_test.Font = new Font("Courier New", 9F);
            txt_alt_msl_test.Location = new Point(63, 75);
            txt_alt_msl_test.Name = "txt_alt_msl_test";
            txt_alt_msl_test.Size = new Size(61, 21);
            txt_alt_msl_test.TabIndex = 16;
            txt_alt_msl_test.Text = "615";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(15, 78);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 15;
            label9.Text = "ALT: ";
            // 
            // txt_lng_test
            // 
            txt_lng_test.Font = new Font("Courier New", 9F);
            txt_lng_test.Location = new Point(63, 51);
            txt_lng_test.Name = "txt_lng_test";
            txt_lng_test.Size = new Size(100, 21);
            txt_lng_test.TabIndex = 14;
            txt_lng_test.Text = "-122.207302";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(15, 54);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 13;
            label10.Text = "LNG: ";
            // 
            // txt_lat_test
            // 
            txt_lat_test.Font = new Font("Courier New", 9F);
            txt_lat_test.Location = new Point(63, 27);
            txt_lat_test.Name = "txt_lat_test";
            txt_lat_test.Size = new Size(100, 21);
            txt_lat_test.TabIndex = 12;
            txt_lat_test.Text = "37.1246";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(15, 30);
            label15.Name = "label15";
            label15.Size = new Size(42, 15);
            label15.TabIndex = 11;
            label15.Text = "LAT: ";
            // 
            // lbl_KIZ_fname
            // 
            lbl_KIZ_fname.AutoSize = true;
            lbl_KIZ_fname.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_KIZ_fname.Location = new Point(95, 26);
            lbl_KIZ_fname.Name = "lbl_KIZ_fname";
            lbl_KIZ_fname.Size = new Size(63, 15);
            lbl_KIZ_fname.TabIndex = 47;
            lbl_KIZ_fname.Text = "filename";
            // 
            // lbl_LCH_fname
            // 
            lbl_LCH_fname.AutoSize = true;
            lbl_LCH_fname.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LCH_fname.Location = new Point(97, 27);
            lbl_LCH_fname.Name = "lbl_LCH_fname";
            lbl_LCH_fname.Size = new Size(63, 15);
            lbl_LCH_fname.TabIndex = 50;
            lbl_LCH_fname.Text = "filename";
            // 
            // frmPAVerify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 861);
            Controls.Add(groupBox6);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Name = "frmPAVerify";
            Text = "CROSSBOW: KIZ/LCH Verification";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_SystemOperator;
        private Label label7;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private Button btn_LCH_CheckLocalVote;
        private Button btn_LCH_LoadFile;
        private Label lbl_LCH_nWindows;
        private Label lbl_LCH_WindowBounds;
        private Label lbl_LCH_MissionDuration;
        private Label lbl_LCH_nTargets;
        private Label lbl_LCH_MissionEndDate;
        private Label lbl_LCH_MissionStartDate;
        private Label lbl_LCH_MissionName;
        private Label lbl_LCH_Operator;
        private Label lbl_LCH_MissionID;
        private GroupBox groupBox4;
        private Button btn_KIZ_CheckLocalVote;
        private Label lbl_KIZ_nWindows;
        private Label lbl_KIZ_WindowBounds;
        private Label lbl_KIZ_MissionDuration;
        private Label lbl_KIZ_nTargets;
        private Label lbl_KIZ_MissionEndDate;
        private Label lbl_KIZ_MissionStartDate;
        private Label lbl_KIZ_MissionName;
        private Label lbl_KIZ_Operator;
        private Label lbl_KIZ_MissionID;
        private Button btn_KIZ_LoadFile;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tss_ScrollTime;
        private ToolStripStatusLabel tss_Coords;
        private ToolStripStatusLabel tss_VoteResult;
        private ToolStripStatusLabel tssStatus_Date;
        private Panel panel1;
        private Label label6;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private TrackBar trackBar2;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private ErrorProvider errorProvider1;
        private ToolTip toolTip1;
        private Button btn_reset_timeLimits;
        private GroupBox groupBox6;
        private TextBox txt_alt_msl_test;
        private Label label9;
        private TextBox txt_lng_test;
        private Label label10;
        private TextBox txt_lat_test;
        private Label label15;
        private TextBox txt_undulation;
        private Label label1;
        private CodeArtEng.Controls.StatusLabel mb_KIZ_isLocationValid;
        private CodeArtEng.Controls.StatusLabel mb_KIZ_isOperatorValid;
        private CodeArtEng.Controls.StatusLabel mb_KIZ_ForExec;
        private CodeArtEng.Controls.StatusLabel mb_LCH_isLocationValid;
        private CodeArtEng.Controls.StatusLabel mb_LCH_isOperatorValid;
        private CodeArtEng.Controls.StatusLabel mb_LCH_ForExec;
        private CodeArtEng.Controls.StatusLabel mb_KIZ_Vote;
        private CodeArtEng.Controls.StatusLabel mb_KIZ_TotalVote;
        private CodeArtEng.Controls.StatusLabel mb_LCH_TotalVote;
        private CodeArtEng.Controls.StatusLabel mb_LCH_Vote;
        private Button btn_Update;
        private Label lbl_LCH_fname;
        private Label lbl_KIZ_fname;
    }
}