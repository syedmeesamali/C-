using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class CustomSearch : Form
    {
        public CustomSearch()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void CustomSearch_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Repos\CSharp\10_IMS_Final\StocksDB.mdf;Integrated Security=True");
            conn.Open();
            adapt = new SqlDataAdapter("select * from StockInTable", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
