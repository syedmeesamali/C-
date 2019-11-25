using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class myForm: UserControl
    {
        public myForm()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            btnOne.Text = "Form loaded";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnOne.Text = "Hello World";
            DialogResult dr = MessageBox.Show("Are you sure you want to close this form?", "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 5;
            }
            else
            {
                progressBar1.Value = 0;
            }
        }
    }
}
