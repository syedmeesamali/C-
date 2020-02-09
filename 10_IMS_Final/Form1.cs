using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace IMS_Final
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReportsForm stockReportsForm = new StockReportsForm();
            stockReportsForm.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            //dataGridView1.DataSource = dt;
        }

        private void importInvoiceExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                    //Setup to read the excel file using openxml package i.e. EPPlus
                    FileInfo fileName = new FileInfo(openFileDialog.FileName);
                    MessageBox.Show("FileName: " + fileName.ToString());
                    ExcelPackage package = new ExcelPackage(fileName);
                    ExcelWorksheet ws = package.Workbook.Worksheets[1]; //First worksheet only for my case
                    int col = 1;
                    for (int row = 14; row < 28; row++)
                    {
                        if (ws.Cells[row, col].Value != null)
                            listBox1.Items.Add(ws.Cells[row, col].Value);
                    }
                    }
                }
        }
    }
}
