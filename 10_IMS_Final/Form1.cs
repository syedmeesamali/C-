using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

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
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            dataGridView1.DataSource = dt;
        }

        private void importInvoiceExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx|Excel Workbook|*.xls" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {

                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        //using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))  //Create stream for data
                        //{
                        //    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        //    {
                        //        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        //    });
                        //    tableCollection = result.Tables;
                        //    cboSheets.Items.Clear(); // clear the combo box
                        //    foreach (DataTable table in tableCollection)
                        //        cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                        //}
                    }
                }
            } //End of filter for import 
        }
    }
}
