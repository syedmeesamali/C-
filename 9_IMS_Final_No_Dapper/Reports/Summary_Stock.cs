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
    public partial class Summary_Stock : Form
    {
        public Summary_Stock()
        {
            InitializeComponent();
        }

        private void Summary_Stock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'combination.CombinationTable' table. You can move, or remove it, as needed.
            this.combinationTableTableAdapter.Fill(this.combination.CombinationTable);
            this.reportViewer1.RefreshReport();
        }
    }
}
