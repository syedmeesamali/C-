using System;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class Product_Report : Form
    {
        public Product_Report()
        {
            InitializeComponent();
        }

        private void Product_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDBDataSet_StockinExpiry.StockinTableProducts' table. You can move, or remove it, as needed.
            this.stockinTableProductsTableAdapter.Fill(this.stocksDBDataSet_StockinExpiry.StockinTableProducts);
            // TODO: This line of code loads data into the 'stocksDBDataSet_StockinExpiry.StockinTableProducts' table. You can move, or remove it, as needed.
            this.stockinTableProductsTableAdapter.Fill(this.stocksDBDataSet_StockinExpiry.StockinTableProducts);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
