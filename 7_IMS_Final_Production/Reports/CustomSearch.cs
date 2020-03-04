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
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM StockInTable", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 250;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[8].Width = 50;
            conn.Close();
        }

        //Update the database based on the word typed in the product-search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {   SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True");
                conn.Open();
                adapt = new SqlDataAdapter("SELECT * FROM StockInTable WHERE Prod_Name like '" + txtSearch.Text + "%'", conn);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            } catch (Exception ex)
            {  MessageBox.Show("Some Issues with Query!", ex.ToString());        }            
        }
        //Update the DGV based on the Expiry date picked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will now see results which have expiry date earlier than specified!");
            try
            {   string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True");
                conn.Open();
                adapt = new SqlDataAdapter("SELECT * FROM StockInTable WHERE Expiry <= '" + theDate + "'", conn);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }  catch (Exception ex)
            {  MessageBox.Show("Some Issues with Query!", ex.ToString());      }
        }
        //Update the database based on the word typed in the Product-ID
        private void txtProdID_TextChanged(object sender, EventArgs e)
        {   try
            {   SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True");
                conn.Open();
                adapt = new SqlDataAdapter("SELECT * FROM StockInTable WHERE Prod_ID like '" + txtProdID.Text + "%'", conn);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }  catch (Exception ex)
            {   MessageBox.Show("Some Issues with Query!", ex.ToString());     }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
