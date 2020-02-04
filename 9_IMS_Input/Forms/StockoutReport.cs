using System;
using System.Windows.Forms;

namespace IMS_Input
{
    public partial class StockoutReport : Form
    {
        public StockoutReport()
        {
            InitializeComponent();
        }

        private void StockoutReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'StocksDataSet.StockoutTable' table. You can move, or remove it, as needed.
            
            try
            {
                this.StockoutTableTableAdapter.Fill(this.StocksDataSet.StockoutTable);
            } catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }


        }
    }
}
