using IMS_Final.Reports;
using System;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class StockReportsForm : Form
    {
        public StockReportsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //frmMain frm = new frmMain();
            //this.Hide();
            //frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product_Report product_Report = new Product_Report();
            product_Report.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExpiryReports expiryReports = new ExpiryReports();
            expiryReports.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomSearch customSearch = new CustomSearch();
            customSearch.Show();
        }

        private void StockReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFullReport_Click(object sender, EventArgs e)
        {
            ProductListSearch productListSearch = new ProductListSearch();
            productListSearch.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesSearch salesSearch = new SalesSearch();
            salesSearch.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockReportDGV stockReportDGV = new StockReportDGV();
            stockReportDGV.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockoutReport stockoutReport = new StockoutReport();
            stockoutReport.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StockReportSearch stockReportSearch = new StockReportSearch();
            stockReportSearch.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Item_History item_History = new Item_History();
            item_History.Show();
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            ReOrderReport reOrderReport = new ReOrderReport();
            reOrderReport.Show();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            Summary_Stock summary_Stock = new Summary_Stock();
            summary_Stock.Show();
        }
    }
}
