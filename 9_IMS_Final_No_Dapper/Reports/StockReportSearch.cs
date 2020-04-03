using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class StockReportSearch : Form
    {
        public StockReportSearch()
        {
            InitializeComponent();
        }      
        
        DataGridViewPrinter MyDataGridViewPrinter;

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM(" +
                "select sin.Prod_ID, sin.Prod_Name, sin.Sup_ID, sin.Sup_Name, " +
            "sin.Units, format(sin.Cost, 'N2') as [Cost], sin.Expiry, pr.Re_Order from Products pr, StockinTable sin " +
            "where sin.Prod_Name = pr.Prod_Name) AS results WHERE " +
            "Prod_Name Like '" + txtSearch.Text + "%'", conn);
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

        
        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Customers Report";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Do you want the report to be centered on the page", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, true, true, "Customers", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, false, true, "Customers", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
                MyPrintDocument.Print();
            }
                
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {

        }
    }
}
