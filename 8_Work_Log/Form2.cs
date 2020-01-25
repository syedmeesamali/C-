using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace Work_Log
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new frmLogs();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string query_1 = "";
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\repos\CSharp\8_Work_Log\MasterDB.mdf;Integrated Security=True");
            conn.Close();
            conn.Open();
            query_1 = "SELECT TOP 100 * FROM Products";
            SqlCommand cmd = new SqlCommand(query_1, conn);
            SqlDataAdapter sqd = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqd.Fill(ds);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ds", ds.Tables[0]));
            this.reportViewer1.RefreshReport();
        }
    }
}
