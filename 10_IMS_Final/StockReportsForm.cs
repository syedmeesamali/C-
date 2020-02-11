using IMS_Final.Reports;
using System;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class StockReportsForm : Form
    {
        public StockReportsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product_Report product_Report = new Product_Report();
            product_Report.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExpiryReports expiryReports = new ExpiryReports();
            expiryReports.Show();
        }
    }
}
