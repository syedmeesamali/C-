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

        //Show report for the stockout
        private void btnStockout_Click(object sender, EventArgs e)
        {
            StockoutReport stockoutReport = new StockoutReport();
            stockoutReport.Visible = true;
        }

        //Load the datasets on loading of form
        private void StockinFilters_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    this.stockinTableTableAdapter.Fill(this.stocksDataSet.StockinTable);
            //    this.stockoutTableTableAdapter.Fill(this.stocksDataSet.StockoutTable);
            //} catch (Exception ex)
            //{
            //    MessageBox.Show("ExceptION: " + ex.ToString());
            //}
            
        }

        private void btnStockin_Click_1(object sender, EventArgs e)
        {
            TotalStocks totalstocks = new TotalStocks();
            totalstocks.Visible = true;
        }
    }
}
