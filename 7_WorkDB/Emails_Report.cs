using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WorkDB
{
    public partial class Emails_Report : Form
    {
        public Emails_Report()
        {
            InitializeComponent();
        }

        SqlDataAdapter adapt;   //For sql data connection
        DataTable dt;           //Sql data table

        //Search based on dates
        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Work.mdf;Integrated Security=True");
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Emails " +
                "WHERE Date Like '%" + txtDate.Text + "%'", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;
            conn.Close();
        }

        //Load the full Emails table when the report form is loaded
        private void Emails_Report_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Work.mdf;Integrated Security=True");
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Emails", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;
            conn.Close();
        }
    }
}
