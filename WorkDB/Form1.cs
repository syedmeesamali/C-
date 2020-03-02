using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using Z.Dapper.Plus;

namespace WorkDB
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 2003-2016 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                openFileDialog.Title = "Select input file for Log Data:";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                        try
                        {
                            FileInfo fileName = new FileInfo("" + file);
                           
                            ExcelPackage package = new ExcelPackage(fileName);
                            ExcelWorksheet ws = package.Workbook.Worksheets[1];
                            int colSales = 1;
                            string cust_ID = ws.Cells[8, 8].Value.ToString(); //Hard-coded customer name value
                            string pattern = "dd/MM/yyyy";
                            string date_Loc = ws.Cells[4, 15].Value.ToString();
                            string date_Val = date_Loc.Substring(6, 10).ToString();
                            
                            DateTime parsedDate;
                            for (int rowSales = 15; rowSales < 70; rowSales++) //Hard-coded start as well
                            {
                                if (ws.Cells[rowSales, colSales].Value != null)
                                {
                                    Stockout stockoutList = new Stockout();
                                    DateTime.TryParseExact(date_Val, pattern, null, DateTimeStyles.None, out parsedDate);
                                    stockoutList.Date = parsedDate;
                                    stockoutList.Invoice = Invoice_Val;
                                    stockoutList.Cust_Name = cust_ID;
                                    stockoutList.Prod_ID = (ws.Cells[rowSales, colSales].Value).ToString();
                                    stockoutList.Prod_Name = ws.Cells[rowSales, colSales + 3].Value.ToString();
                                    stockoutList.Boxes = float.Parse((ws.Cells[rowSales, colSales + 6].Value).ToString());
                                    stockoutList.Pcs = float.Parse((ws.Cells[rowSales, colSales + 9].Value).ToString());
                                    stockoutList.Price = float.Parse((ws.Cells[rowSales, colSales + 11].Value).ToString());
                                    stockout.Add(stockoutList);
                                }
                            } //End of for loop to input Excel data

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); }
                    }
                    dataGridView1.DataSource = stockout;
                    dataGridView1.Refresh();
            }//End of filter
        }
    }
}
