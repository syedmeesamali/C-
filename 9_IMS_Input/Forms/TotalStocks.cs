using System;
using System.Windows.Forms;

namespace IMS_Input
{
    public partial class TotalStocks : Form
    {
        public TotalStocks()
        {
            InitializeComponent();
        }

        private void TotalStocks_Load(object sender, EventArgs e)
        {
            try
            {
                this.StockinTableTableAdapter.Fill(this.StocksDataSet.StockinTable);
                //this.StockinTableTableAdapter.Fill(this.StocksDataSet.StockinTable);
            } catch (Exception ex)
            {
                MessageBox.Show("Exception!" + ex.ToString());
            }
        }
    }
}
