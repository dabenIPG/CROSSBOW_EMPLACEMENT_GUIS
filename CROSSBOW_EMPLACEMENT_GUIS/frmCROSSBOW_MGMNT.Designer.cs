namespace CROSSBOW_EMPLACEMENT_GUIS
{
    partial class frmCROSSBOW_MGMNT
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
            menuStrip = new MenuStrip();
            mnuEmplacement = new ToolStripMenuItem();
            mnuEmplacement_HORIZ_gen = new ToolStripMenuItem();
            mnuEmplacement_PA_gen = new ToolStripMenuItem();
            mnuEmplacement_PA_Verify = new ToolStripMenuItem();
            mnuEmplacement_LORA = new ToolStripMenuItem();
            mnuEmplacement_CUE_SIM = new ToolStripMenuItem();
            windowsMenu = new ToolStripMenuItem();
            cascadeToolStripMenuItem = new ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new ToolStripMenuItem();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(32, 32);
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuEmplacement, windowsMenu, helpMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.MdiWindowListItem = windowsMenu;
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(13, 5, 0, 5);
            menuStrip.Size = new Size(1369, 46);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // mnuEmplacement
            // 
            mnuEmplacement.DropDownItems.AddRange(new ToolStripItem[] { mnuEmplacement_HORIZ_gen, mnuEmplacement_PA_gen, mnuEmplacement_PA_Verify, mnuEmplacement_LORA, mnuEmplacement_CUE_SIM });
            mnuEmplacement.Name = "mnuEmplacement";
            mnuEmplacement.Size = new Size(179, 36);
            mnuEmplacement.Text = "E&mplacement";
            // 
            // mnuEmplacement_HORIZ_gen
            // 
            mnuEmplacement_HORIZ_gen.Name = "mnuEmplacement_HORIZ_gen";
            mnuEmplacement_HORIZ_gen.Size = new Size(344, 44);
            mnuEmplacement_HORIZ_gen.Text = "&Horizon Generator";
            mnuEmplacement_HORIZ_gen.Click += mnuEmplacement_HORIZ_gen_Click;
            // 
            // mnuEmplacement_PA_gen
            // 
            mnuEmplacement_PA_gen.Name = "mnuEmplacement_PA_gen";
            mnuEmplacement_PA_gen.Size = new Size(344, 44);
            mnuEmplacement_PA_gen.Text = "&PA Generator";
            mnuEmplacement_PA_gen.Click += mnuEmplacement_PA_gen_Click;
            // 
            // mnuEmplacement_PA_Verify
            // 
            mnuEmplacement_PA_Verify.Name = "mnuEmplacement_PA_Verify";
            mnuEmplacement_PA_Verify.Size = new Size(344, 44);
            mnuEmplacement_PA_Verify.Text = "&Verify PA";
            mnuEmplacement_PA_Verify.Click += mnuEmplacement_PA_Verify_Click;
            // 
            // mnuEmplacement_LORA
            // 
            mnuEmplacement_LORA.Name = "mnuEmplacement_LORA";
            mnuEmplacement_LORA.Size = new Size(344, 44);
            mnuEmplacement_LORA.Text = "&LORA";
            mnuEmplacement_LORA.Click += mnuEmplacement_LORA_Click;
            // 
            // mnuEmplacement_CUE_SIM
            // 
            mnuEmplacement_CUE_SIM.Name = "mnuEmplacement_CUE_SIM";
            mnuEmplacement_CUE_SIM.Size = new Size(344, 44);
            mnuEmplacement_CUE_SIM.Text = "&CUE SIM";
            mnuEmplacement_CUE_SIM.Click += mnuEmplacement_CUE_SIM_Click;
            // 
            // windowsMenu
            // 
            windowsMenu.DropDownItems.AddRange(new ToolStripItem[] { cascadeToolStripMenuItem, tileVerticalToolStripMenuItem, tileHorizontalToolStripMenuItem, closeAllToolStripMenuItem });
            windowsMenu.Name = "windowsMenu";
            windowsMenu.Size = new Size(131, 36);
            windowsMenu.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(302, 44);
            cascadeToolStripMenuItem.Text = "&Cascade";
            cascadeToolStripMenuItem.Click += CascadeToolStripMenuItem_Click;
            // 
            // tileVerticalToolStripMenuItem
            // 
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new Size(302, 44);
            tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            tileVerticalToolStripMenuItem.Click += TileVerticalToolStripMenuItem_Click;
            // 
            // tileHorizontalToolStripMenuItem
            // 
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new Size(302, 44);
            tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            tileHorizontalToolStripMenuItem.Click += TileHorizontalToolStripMenuItem_Click;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(302, 44);
            closeAllToolStripMenuItem.Text = "C&lose All";
            closeAllToolStripMenuItem.Click += CloseAllToolStripMenuItem_Click;
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator8, aboutToolStripMenuItem });
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(84, 36);
            helpMenu.Text = "&Help";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(253, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(256, 44);
            aboutToolStripMenuItem.Text = "&About ... ...";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(32, 32);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 1073);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 30, 0);
            statusStrip.Size = new Size(1369, 42);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(78, 32);
            toolStripStatusLabel.Text = "Status";
            // 
            // frmCROSSBOW_MGMNT
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1369, 1115);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(6, 7, 6, 7);
            Name = "frmCROSSBOW_MGMNT";
            Text = "frmCROSSBOW_MGMNT";
            Load += frmCROSSBOW_MGMNT_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem mnuEmplacement;
        private ToolStripMenuItem mnuEmplacement_HORIZ_gen;
        private ToolStripMenuItem mnuEmplacement_PA_gen;
        private ToolStripMenuItem mnuEmplacement_PA_Verify;
        private ToolStripMenuItem mnuEmplacement_LORA;
        private ToolStripMenuItem mnuEmplacement_CUE_SIM;
    }
}



