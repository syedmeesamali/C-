using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class StockReportSearch : Form
    {
        public StockReportSearch()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void StockReportSearch_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("select sin.Prod_ID, sin.Prod_Name, sin.Sup_ID, sin.Sup_Name, " +
            "sin.Units, format(sin.Cost, 'N2') as [Cost], sin.Expiry, pr.Re_Order from Products pr, StockinTable sin " +
            "where sin.Prod_Name = pr.Prod_Name", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 90;
            conn.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
                //dataGridPrinter1 = new DataGridPrinter(dataGridView1, printDocument1, dataSet11.Customers);
            
        }

       
    private void btnPurchase_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("select sin.Prod_Name, sin.Prod_ID, sin.Expiry, " +
                    "format(sum(sin.Cost), 'N2') as [Total Cost], " +
                    " count(*) as [No.of Items] " +
                    "from StockinTable as sin " +
                    "inner join StockoutTable as sout " +
                    "on sin.Prod_Name = sout.Prod_Name " +
                    "inner join Products as pr " +
                    "on sin.Prod_Name = pr.Prod_Name " +
                    "group by sin.Prod_Name, sin.Prod_ID, sin.Expiry ", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 250;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            conn.Close();
        }

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("select sin.Prod_ID, sin.Prod_Name, sin.Sup_ID, sin.Sup_Name, " +
            "sin.Units, format(sin.Cost, 'N2') as [Cost], sin.Expiry, pr.Re_Order from Products pr, StockinTable sin " +
            "where sin.Prod_Name = pr.Prod_Name", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 90;
            conn.Close();
        }
    }
}
