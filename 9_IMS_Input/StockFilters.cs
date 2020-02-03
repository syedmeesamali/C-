using System;
using System.Windows.Forms;

namespace IMS_Input
{
    public partial class StockFilters : Form
    {
        public StockFilters()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void btnStockin_Click(object sender, EventArgs e)
        {
            TotalStocks totalstocks = new TotalStocks();
            totalstocks.Visible = true;
        }

        private void StockinFilters_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDataSet.StockoutTable' table. You can move, or remove it, as needed.
            this.stockoutTableTableAdapter.Fill(this.stocksDataSet.StockoutTable);
            // TODO: This line of code loads data into the 'stocksDataSet.StockinTable' table. You can move, or remove it, as needed.

            try
            {
                this.stockinTableTableAdapter.Fill(this.stocksDataSet.StockinTable);
            } catch (Exception ex)
            {
                MessageBox.Show("ExceptION: " + ex.ToString());
            }
            

        }

        private void btnStockout_Click(object sender, EventArgs e)
        {
            Stocksout stocksOut = new Stocksout();
            stocksOut.Visible = true;
        }
    }
}
