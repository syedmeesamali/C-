using System;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class ExpiryReports : Form
    {
        public ExpiryReports()
        {
            InitializeComponent();
        }

        private void btnExpiryReport_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void ExpiryReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDBDataSet_Complete.StockinTable' table. You can move, or remove it, as needed.
            

        }
    }
}
