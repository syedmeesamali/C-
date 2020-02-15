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
            
            // TODO: This line of code loads data into the 'stocksDBDataSet_Complete.Products' table. You can move, or remove it, as needed.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDBDataSet_Complete.StockinTable' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'stocksDBDataSet_Products.Products' table. You can move, or remove it, as needed.

            this.reportViewer1.RefreshReport();
        }
    }
}
