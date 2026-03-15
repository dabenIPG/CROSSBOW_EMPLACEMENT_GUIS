using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CROSSBOW_EMPLACEMENT_GUIS
{
    public partial class frmCROSSBOW_MGMNT : Form
    {
        private int childFormNumber = 0;

        public frmCROSSBOW_MGMNT()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }





        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void mnuEmplacement_HORIZ_gen_Click(object sender, EventArgs e)
        {
            frmHorizGen newMDIChild = new frmHorizGen();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void mnuEmplacement_PA_gen_Click(object sender, EventArgs e)
        {
            frmPAGen newMDIChild = new frmPAGen();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void mnuEmplacement_PA_Verify_Click(object sender, EventArgs e)
        {
            frmPAVerify newMDIChild = new frmPAVerify();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void mnuEmplacement_LORA_Click(object sender, EventArgs e)
        {
            frmLORA newMDIChild = new frmLORA();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void mnuEmplacement_CUE_SIM_Click(object sender, EventArgs e)
        {
            frmCUESim newMDIChild = new frmCUESim();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void frmCROSSBOW_MGMNT_Load(object sender, EventArgs e)
        {
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            this.Text = $"IPG CROSSBOW MANAGEMENT SUITE {version} ({buildDate})";
        }
    }
}
