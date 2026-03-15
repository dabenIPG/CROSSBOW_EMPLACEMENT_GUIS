namespace CROSSBOW_EMPLACEMENT_GUIS
{
    partial class frmPAGen
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
            txt_alt_msl = new TextBox();
            label3 = new Label();
            txt_lng = new TextBox();
            label5 = new Label();
            txt_lat = new TextBox();
            label6 = new Label();
            lbl_MissionDuration = new Label();
            label4 = new Label();
            lbl_MissionEndDateTime = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            btn_Parse = new Button();
            btn_Delete = new Button();
            dataGridView1 = new DataGridView();
            btn_Generate = new Button();
            chk_ForExec = new CheckBox();
            txt_Operator = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txt_alt_msl
            // 
            txt_alt_msl.Font = new Font("Courier New", 9F);
            txt_alt_msl.Location = new Point(154, 210);
            txt_alt_msl.Name = "txt_alt_msl";
            txt_alt_msl.Size = new Size(61, 21);
            txt_alt_msl.TabIndex = 66;
            txt_alt_msl.Text = "173";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 210);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 65;
            label3.Text = "ALT: ";
            // 
            // txt_lng
            // 
            txt_lng.Font = new Font("Courier New", 9F);
            txt_lng.Location = new Point(154, 186);
            txt_lng.Name = "txt_lng";
            txt_lng.Size = new Size(100, 21);
            txt_lng.TabIndex = 64;
            txt_lng.Text = "-86.432505";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 186);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 63;
            label5.Text = "LNG: ";
            // 
            // txt_lat
            // 
            txt_lat.Font = new Font("Courier New", 9F);
            txt_lat.Location = new Point(154, 162);
            txt_lat.Name = "txt_lat";
            txt_lat.Size = new Size(100, 21);
            txt_lat.TabIndex = 62;
            txt_lat.Text = "34.459541";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 162);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 61;
            label6.Text = "LAT: ";
            // 
            // lbl_MissionDuration
            // 
            lbl_MissionDuration.AutoSize = true;
            lbl_MissionDuration.Font = new Font("Courier New", 9F);
            lbl_MissionDuration.Location = new Point(154, 79);
            lbl_MissionDuration.Name = "lbl_MissionDuration";
            lbl_MissionDuration.Size = new Size(119, 15);
            lbl_MissionDuration.TabIndex = 60;
            lbl_MissionDuration.Text = "Mission Duration";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 9F);
            label4.Location = new Point(23, 79);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 59;
            label4.Text = "Mission Duration";
            // 
            // lbl_MissionEndDateTime
            // 
            lbl_MissionEndDateTime.AutoSize = true;
            lbl_MissionEndDateTime.Font = new Font("Courier New", 9F);
            lbl_MissionEndDateTime.Location = new Point(154, 50);
            lbl_MissionEndDateTime.Name = "lbl_MissionEndDateTime";
            lbl_MissionEndDateTime.Size = new Size(84, 15);
            lbl_MissionEndDateTime.TabIndex = 58;
            lbl_MissionEndDateTime.Text = "Mission End";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 9F);
            label2.Location = new Point(23, 50);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 57;
            label2.Text = "Mission End";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 9F);
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 56;
            label1.Text = "Mission Start";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.Font = new Font("Courier New", 9F);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(154, 18);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(189, 21);
            dateTimePicker1.TabIndex = 55;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // btn_Parse
            // 
            btn_Parse.Location = new Point(12, 260);
            btn_Parse.Name = "btn_Parse";
            btn_Parse.Size = new Size(75, 23);
            btn_Parse.TabIndex = 70;
            btn_Parse.Text = "Parse";
            btn_Parse.UseVisualStyleBackColor = true;
            btn_Parse.Click += btn_Parse_Click;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(713, 260);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(75, 23);
            btn_Delete.TabIndex = 69;
            btn_Delete.Text = "Delete";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 289);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 176);
            dataGridView1.TabIndex = 68;
            // 
            // btn_Generate
            // 
            btn_Generate.Location = new Point(93, 260);
            btn_Generate.Name = "btn_Generate";
            btn_Generate.Size = new Size(75, 23);
            btn_Generate.TabIndex = 67;
            btn_Generate.Text = "Generate";
            btn_Generate.UseVisualStyleBackColor = true;
            btn_Generate.Click += btn_Generate_Click;
            // 
            // chk_ForExec
            // 
            chk_ForExec.AutoSize = true;
            chk_ForExec.Location = new Point(345, 122);
            chk_ForExec.Name = "chk_ForExec";
            chk_ForExec.Size = new Size(70, 19);
            chk_ForExec.TabIndex = 71;
            chk_ForExec.Text = "For Exec";
            chk_ForExec.UseVisualStyleBackColor = true;
            // 
            // txt_Operator
            // 
            txt_Operator.Font = new Font("Courier New", 9F);
            txt_Operator.Location = new Point(154, 122);
            txt_Operator.Name = "txt_Operator";
            txt_Operator.Size = new Size(100, 21);
            txt_Operator.TabIndex = 73;
            txt_Operator.Text = "IPG";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(23, 122);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 72;
            label7.Text = "OPERATOR: ";
            // 
            // frmPAGen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 465);
            Controls.Add(txt_Operator);
            Controls.Add(label7);
            Controls.Add(chk_ForExec);
            Controls.Add(btn_Parse);
            Controls.Add(btn_Delete);
            Controls.Add(dataGridView1);
            Controls.Add(btn_Generate);
            Controls.Add(txt_alt_msl);
            Controls.Add(label3);
            Controls.Add(txt_lng);
            Controls.Add(label5);
            Controls.Add(txt_lat);
            Controls.Add(label6);
            Controls.Add(lbl_MissionDuration);
            Controls.Add(label4);
            Controls.Add(lbl_MissionEndDateTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Name = "frmPAGen";
            Text = "CROSSBOW: KIZ/LCH Generator";
            Load += frmPAGen_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_alt_msl;
        private Label label3;
        private TextBox txt_lng;
        private Label label5;
        private TextBox txt_lat;
        private Label label6;
        private Label lbl_MissionDuration;
        private Label label4;
        private Label lbl_MissionEndDateTime;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Button btn_Parse;
        private Button btn_Delete;
        private DataGridView dataGridView1;
        private Button btn_Generate;
        private CheckBox chk_ForExec;
        private TextBox txt_Operator;
        private Label label7;
    }
}