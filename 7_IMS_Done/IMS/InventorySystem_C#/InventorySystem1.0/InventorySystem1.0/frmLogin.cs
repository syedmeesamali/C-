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
using InventorySystem1._0.Includes;

namespace InventorySystem1._0
{
    public partial class frmLogin : Form
    {
        Form1 frm;
        public frmLogin(Form1 frm)
        {
            InitializeComponent();

            this.frm = frm;
        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToShortTimeString();
            lbldate.Text = DateTime.Now.ToShortDateString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Timer1.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SYED\Downloads\IMS\InventorySystem_C#\InventorySystem1.0\InventorySystem1.0\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =" SELECT * FROM LoginDetails WHERE Name = '" + txtusername.Text + "' and Password = sha1('" + txtpass.Text + "')";
            cmd.ExecuteNonQuery();
            cmd.Parameters.AddWithValue("@username", txtusername);
            cmd.Parameters.AddWithValue("@password", txtpass);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            if (loginSuccessful)
            {
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
            txtusername.Clear();
            txtusername.Focus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}