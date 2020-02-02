using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using OfficeOpenXml;
using Z.Dapper.Plus;


namespace IMS_Input
{
    public partial class Form1 : Form
    {
        //LOAD AND INITIALIZE
        public Form1()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;
        //Import PREPARED SHEETS
        private void importPreparedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStockin frmstockin = new frmStockin();
            frmstockin.Show();
        }


        //EXIT APPLICATION
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        //ABOUT BUTTON
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                FileInfo excelFile = new FileInfo("test.xls");
                excel.SaveAs(excelFile);
                bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;
                if (isExcelInstalled)
                {
                    System.Diagnostics.Process.Start(excelFile.ToString());

                }
            }
        }


    private void importExcelSheetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog()
        { Filter = "Excel 97-2003 workbooks|*.xls|Excel Workbook|*.xlsx" }) //Filter for the type of files to show
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
            {
                var fName = openFileDialog.FileName;
                using (var fileStream = File.Open(fName, FileMode.Open, FileAccess.Read))
                {
                    MessageBox.Show("Name of workbook: " + fName.ToString());

                }//End of reading stream
            }
        }
    }


        //EXIT APPLICATION
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void importStockOutFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
