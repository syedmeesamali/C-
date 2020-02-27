using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class Item_History : Form
    {
        public Item_History()
        {
            InitializeComponent();
        }

        private void Item_History_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDBDataSet_Products.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.stocksDBDataSet_Products.Products);

        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void btnSummary_Click(object sender, EventArgs e)
        {
            label2.Text = "Summary of Product (Units Bought, Sold and Stock) selected Above:";
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            string selectedItem = cboHistory.GetItemText(cboHistory.SelectedItem);
            adapt = new SqlDataAdapter("SELECT DISTINCT sin.Prod_ID, sin.Prod_Name, sin.Bought, ISNULL(sout.SOLD,0) as [Sold], " +
                    "ISNULL((sin.Bought - sout.SOLD),0) AS [Stock Now] " +
                    "FROM (SELECT Prod_ID, Prod_Name, ISNULL(SUM(Units),0) AS Bought " +
                    "FROM StockinTable sout GROUP BY Prod_ID, Prod_Name) sin " +
                    "LEFT JOIN  (SELECT Prod_ID, ISNULL(SUM(Boxes),0) AS SOLD " +
                    "FROM StockoutTable GROUP BY Prod_ID) sout " +
                    "ON sin.Prod_ID = sout.Prod_ID " +
                    "WHERE sin.Prod_Name = '" + selectedItem + "' ",conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            conn.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            label2.Text = "Detailed History of Product selected Above:";
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            string selectedItem = cboHistory.GetItemText(cboHistory.SelectedItem);
            adapt = new SqlDataAdapter("SELECT sin.Prod_ID AS [Prod ID], sin.Prod_Name AS [Prod Name], sin.Date, " +
                "sin.Sup_Name AS[Supplier / Customer], sin.Units AS[Units], FORMAT(sin.Cost, 'N2') AS[Cost / Price], " +
                "CONVERT(varchar(100),sin.Expiry, 102) AS [Expiry / Invoice] " +
                "FROM StockinTable AS sin WHERE sin.Prod_Name ='" + selectedItem + "' " +
                "UNION ALL SELECT sout.Prod_ID, sout.Prod_Name, sout.Date, sout.Cust_Name, sout.Boxes, " +
                "FORMAT(sout.Price,'N2'), sout.Invoice FROM StockoutTable AS sout WHERE sout.Prod_Name = '" + selectedItem + "' " , conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].Width = 120;
            conn.Close();
        }

    }
}
