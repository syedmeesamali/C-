using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace IMS_Input
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            dataGridView1.DataSource = dt;
        }

        private void cboSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
        }

        private void importExcelSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xls|Excel Workbook|*.xlsx" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))  //Create stream for data
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheets.Items.Clear(); // clear the combo box
                            foreach (DataTable table in tableCollection)
                                cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook wb = xlApp.Workbooks.Open(@"C:\Users\cclgulf\Desktop\Projects.xlsx\");
        }
    }
}
