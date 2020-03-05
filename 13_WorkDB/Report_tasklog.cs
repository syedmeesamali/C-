using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WorkDB
{
    public partial class Report_tasklog : Form
    {
        public Report_tasklog()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void Report_tasklog_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Work.mdf;Integrated Security=True");
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM TaskLog", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 470;
            conn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Work.mdf;Integrated Security=True");
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM TaskLog " +
                "WHERE ProjectName Like '%" + txtSearch.Text + "%'", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 470;
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string commandText = "DELETE FROM TaskLog WHERE Id >= " + txtFrom.Text + " AND Id <= " + txtTo.Text + ";";
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Work.mdf;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            dataGridView1.Refresh();
            txtFrom.Text = "";
            txtTo.Text = "";
            MessageBox.Show("Record(s) deleted successfully!", "DELETED!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Work.mdf;Integrated Security=True");
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM TaskLog " +
                "WHERE Remarks Like '%" + txtRemarks.Text + "%'", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 470;
            conn.Close();
        }
    }
}
