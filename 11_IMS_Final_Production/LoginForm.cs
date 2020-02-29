using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM Login WHERE LoginID = '" + txtUserName.Text.Trim() +
                        "' AND Password = '" + txtPassword.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 1)
                    {
                        frmMain frm = new frmMain();
                        this.Hide();
                        frm.Show();
                    }   else
                    {
                        MessageBox.Show("Entered information not correct!", "Wrong Input");
                    }
                }
            }//End of validity check
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
