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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private bool IsValid()
        {
            if (txtUserName.Text.TrimStart() == string.Empty | txtUserName.Text.Length < 5)
            {
                MessageBox.Show("User name is required! Length >= 5", "Error");
                return false;
            }

            if (txtPassword.Text.TrimStart() == string.Empty | txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Password is required! Length >= 8", "Error");
                return false;
            }

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (IsValid())
            {
                frmMain frm = new frmMain();
                this.Hide();
                frm.Show();
            } else
            {
                MessageBox.Show("Check login info !");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
