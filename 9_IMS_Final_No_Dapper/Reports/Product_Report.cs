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
            // TODO: This line of code loads data into the 'stocksDBDataSet_Products.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.stocksDBDataSet_Products.Products);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDBDataSet_StockinExpiry1.StockinTable' table. You can move, or remove it, as needed.
            this.stockinTableTableAdapter.Fill(this.stocksDBDataSet_StockinExpiry1.StockinTable);
            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
