using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class StockoutReport : Form
    {
        public StockoutReport()
        {
            InitializeComponent();
        }

        private void StockoutReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockDataset.StockoutTable' table. You can move, or remove it, as needed.
            this.stockoutTableTableAdapter.Fill(this.stockDataset.StockoutTable);

        }

        private void btnExpiryReport_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
