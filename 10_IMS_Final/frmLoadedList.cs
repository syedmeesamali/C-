using System;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class frmLoadedList : Form
    {
        public frmLoadedList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmmain = new frmMain();
            frmmain.Show();
        }

    }
}
