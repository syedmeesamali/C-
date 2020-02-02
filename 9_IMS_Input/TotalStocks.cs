using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // TODO: This line of code loads data into the 'StocksDataSet.StockinTable' table. You can move, or remove it, as needed.
            try
            {
                this.StockinTableTableAdapter.Fill(this.StocksDataSet.StockinTable);
            } catch (Exception ex)
            {
                MessageBox.Show("Exception!" + ex.ToString());
            }


            this.reportViewer1.RefreshReport();
        }
    }
}
