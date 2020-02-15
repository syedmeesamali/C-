using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class SalesSearch : Form
    {
        public SalesSearch()
        {
            InitializeComponent();
        }

        SqlDataAdapter adapt;
        DataTable dt;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\repos\CSharp\9_IMS_Final\StocksDB.mdf; Integrated Security = True");
                conn.Open();
                adapt = new SqlDataAdapter("SELECT * FROM StockoutTable WHERE Prod_Name like '" + txtSearch.Text + "%'", conn);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Some Issues with Query!", ex.ToString()); }
        }
    }
}
