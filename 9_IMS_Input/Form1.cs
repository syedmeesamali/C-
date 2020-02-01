
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
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            if (dt != null)
            {
                List<Stockin> stockin = new List<Stockin>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Stockin stockinItems = new Stockin();
                    stockinItems.ID = i;
                    stockinItems.Date = (DateTime)dt.Rows[i]["Date"]; //Explicit conversion
                    stockinItems.Sup_ID = dt.Rows[i]["Sup_ID"].ToString();
                    stockinItems.Sup_Name = dt.Rows[i]["Sup_Name"].ToString();
                    stockinItems.Prod_ID = dt.Rows[i]["Prod_ID"].ToString();
                    stockinItems.Prod_Name = dt.Rows[i]["Prod_Name"].ToString();
                    stockinItems.Expiry = (DateTime)dt.Rows[i]["Expiry"];
                    stockinItems.Units = (float)dt.Rows[i]["Units"];
                    stockin.Add(stockinItems);
                }
                //productsBindingSource.DataSource = products;
            }
            //BELOW CODE WILL IMPORT DATA TO LOCAL DATABASE
            /*
            try
            {
                
                DapperPlusManager.Entity<Stockin>().Table("StockinTable");
                List<Stockin> stockin = productsBindingSource.DataSource as List<Stockin>;
                if (stockin != null)
                {
                    using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\repos\CSharp\8_Work_Log\Stocks.mdf;Integrated Security=True"))
                    {
                        db.BulkInsert(stockin);
                    }
                }
                MessageBox.Show("Database update done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void importStockOutFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
