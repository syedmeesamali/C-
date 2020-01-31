using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemBox.Spreadsheet;

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
        //EXIT APPLICATION
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ABOUT BUTTON
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workbook = ExcelFile.Load(@"C:\Users\cclgulf\Desktop\test.xls");
            var sb = new StringBuilder();
            var worksheet = workbook.Worksheets[0];
            MessageBox.Show("Value: " + worksheet.Cells[0, 0].Value.ToString());
            
        }

        private void newWorkbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var workbook = new ExcelFile();
            //var worksheet = workbook.Worksheets.Add("Hello World");

            //worksheet.Cells[0, 0].Value = "English:";
            //worksheet.Cells[0, 1].Value = "Hello";
            //worksheet.Cells[1, 0].Value = "Russian:";
            //worksheet.Cells[2, 0].Value = "Chinese:";
            
            //workbook.Save("Hello World.xlsx");
        }

        private void importSpecialNewToolStripMenuItem_Click(object sender, EventArgs e)
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
            }//End of Filter

        }//End of button import procedure

        private void importExcelSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
