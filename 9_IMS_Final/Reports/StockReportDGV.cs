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
            adapt = new SqlDataAdapter("SELECT sin.Prod_ID, sin.Prod_Name, sin.Bought, ISNULL(sout.SOLD,0) as [Sold], " +
                   "FORMAT(ISNULL((ISNULL(sin.Bought,0) - ISNULL(sout.SOLD,0)),0),'N2') AS [Stock Now] " +
                   "FROM (SELECT Prod_ID, Prod_Name, ISNULL(SUM(Units),0) AS Bought " +
                   "FROM StockinTable sin GROUP BY Prod_ID, Prod_Name) sin " +
                   "LEFT JOIN  (SELECT Prod_ID, ISNULL(SUM(Boxes),0) AS SOLD " +
                   "FROM StockoutTable GROUP BY Prod_ID) sout " +
                   "ON sin.Prod_ID = sout.Prod_ID ", conn);
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
