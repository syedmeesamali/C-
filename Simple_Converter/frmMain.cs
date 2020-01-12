using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Converter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdCalculate_Click(object sender, EventArgs e)
        {
            float inVal; 
            inVal = float.Parse(txtInput.Text);
            
            switch(cboMain.SelectedItem.ToString().Trim())
            {
                case "mm - m":
                    float result;
                    result = inVal * 1000;
                    txtOutput.Text = result.ToString();
                    break;
                case "m - mm":
                    result = inVal / 1000;
                    txtOutput.Text = result.ToString();
                    break;
                default:
                    MessageBox.Show("None selected!");
                    break;
            } //End of switch
            
        }

        
    }
}
