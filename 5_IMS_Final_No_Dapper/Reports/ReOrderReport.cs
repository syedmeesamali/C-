﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class ReOrderReport : Form
    {
        public ReOrderReport()
        {
            InitializeComponent();
        }

        SqlDataAdapter adapt;
        DataTable dt;
        private void ReOrderReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("SELECT sin.Prod_ID, sin.Prod_Name, sin.Bought, ISNULL(sout.SOLD,0) as [Sold], " +
                   "FORMAT(ISNULL((ISNULL(sin.Bought,0) - ISNULL(sout.SOLD,0)),0),'N2') AS [Stock Now], " +
                   "pr.[Re-Order],  (pr.[Re-Order] - ISNULL((ISNULL(sin.Bought,0) - ISNULL(sout.SOLD,0)),0)) AS [ORDER NOW] " +
                   "FROM (SELECT Prod_ID, Prod_Name, ISNULL(SUM(Units),0) AS Bought " +
                   "FROM StockinTable sout GROUP BY Prod_ID, Prod_Name) sin " +
                   "LEFT JOIN  (SELECT Prod_ID, ISNULL(SUM(Boxes),0) AS SOLD " +
                   "FROM StockoutTable GROUP BY Prod_ID) sout " +
                   "ON sin.Prod_ID = sout.Prod_ID " +
                   "LEFT JOIN  (SELECT Prod_ID, Prod_Name, Re_Order as [Re-Order] " +
                   "FROM Products GROUP BY Prod_ID, Prod_Name, Re_Order) pr " +
                   "ON sin.Prod_ID = pr.Prod_ID " +
                   " ORDER BY [ORDER NOW] DESC", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 90;
            conn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM (" +
                "SELECT sin.Prod_ID, sin.Prod_Name, sin.Bought, ISNULL(sout.SOLD,0) as [Sold], " +
                   "FORMAT(ISNULL((ISNULL(sin.Bought,0) - ISNULL(sout.SOLD,0)),0),'N2') AS [Stock Now], " +
                   "pr.[Re-Order],  FORMAT((pr.[Re-Order] - ISNULL((ISNULL(sin.Bought,0) - ISNULL(sout.SOLD,0)),0)),'N2') AS [ORDER NOW] " +
                   "FROM (SELECT Prod_ID, Prod_Name, ISNULL(SUM(Units),0) AS Bought " +
                   "FROM StockinTable sout GROUP BY Prod_ID, Prod_Name) sin " +
                   "LEFT JOIN  (SELECT Prod_ID, ISNULL(SUM(Boxes),0) AS SOLD " +
                   "FROM StockoutTable GROUP BY Prod_ID) sout " +
                   "ON sin.Prod_ID = sout.Prod_ID " +
                   "LEFT JOIN  (SELECT Prod_ID, Prod_Name, Re_Order as [Re-Order] " +
                   "FROM Products GROUP BY Prod_ID, Prod_Name, Re_Order) pr " +
                   "ON sin.Prod_ID = pr.Prod_ID)  AS results " +
                   "WHERE Prod_Name Like '" + txtSearch.Text + "%'", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
