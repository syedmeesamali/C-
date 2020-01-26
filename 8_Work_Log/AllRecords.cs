using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_Log
{
    public partial class AllRecords : Form
    {
        public AllRecords()
        {
            InitializeComponent();
        }

        private void AllRecords_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;
            localReport.ReportPath = "ProductsData.rdlc";
            DataSet dataset = new DataSet("ProductData");

            ReportDataSource dsSalesOrder = new ReportDataSource();
            dsSalesOrder.Name = "SalesOrder";
            dsSalesOrder.Value = dataset.Tables["Products"];

            localReport.DataSources.Add(dsSalesOrder);
            reportViewer1.RefreshReport();
        }
    }
}
