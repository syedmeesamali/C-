using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class frmLoadedList : Form
    {
        public frmLoadedList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmmain = new frmMain();
            frmmain.Show();
        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void frmLoadedList_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True");
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM ExcelFiles", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 350;
            conn.Close();
        }
    }
}
