using System;
using System.Windows.Forms;

namespace IMS_Input
{
    public partial class StockinFilters : Form
    {
        public StockinFilters()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void btnFullReport_Click(object sender, EventArgs e)
        {
            TotalStocks totalstocks = new TotalStocks();
            totalstocks.Visible = true;
        }
    }
}
