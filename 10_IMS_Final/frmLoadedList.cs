using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class frmLoadedList : Form
    {
        public frmLoadedList(string transfer)
        {
            InitializeComponent();
            listLoaded.Items.Add(transfer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmmain = new frmMain();
            frmmain.Show();
        }

        private void frmLoadedList_Load(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            listLoaded.Items.Add(frm.transfer);
        }
    }
}
