using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class StockReportDGV : Form
    {
        public StockReportDGV()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void StockReportDGV_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("select pr.Prod_ID, pr.Prod_Name, pr.Re_Order, sin.Bought, sout.Sold " +
                "from Products as pr " +
                "inner join " +
                "( " +
                "select sin.Prod_Name, format(sum(sin.Cost), 'N2') as [Bought] " +
                "from StockinTable as sin " +
                "where sin.Cost > 0 " +
                "group by sin.Prod_Name) sin on sin.Prod_Name = pr.Prod_Name " +
                "inner join " +
                "( " +
                "select sout.Prod_Name, format(sum(sout.Price), 'N2') as [Sold] " +
                "from StockoutTable as sout " +
                "where sout.Price > 0 " +
                "group by sout.Prod_Name) sout on sout.Prod_Name = pr.Prod_Name",conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 70;
            conn.Close();
        }
    }
}
