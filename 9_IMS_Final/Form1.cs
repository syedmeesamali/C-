using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using Z.Dapper.Plus;

namespace IMS_Final
{
    public partial class frmMain : Form
    {
        //These lists will be used to update the individual lists locally
        private ObservableCollection<Stockout> stockout = new ObservableCollection<Stockout>();
        private ObservableCollection<Stockin> stockin = new ObservableCollection<Stockin>();
        private ObservableCollection<ExcelLoaded> excelLoaded = new ObservableCollection<ExcelLoaded>();

        public frmMain()
        {
            InitializeComponent();
            dataGridView1.Refresh();
        }

        //DataTableCollection tableCollection;
        DataTable tblSales = new DataTable("Sales");
        DataTable tblPurchase = new DataTable("Purchase");
        public static string transfer;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReportsForm stockReportsForm = new StockReportsForm();
            stockReportsForm.Show();
        }

        //Import the STOCK-OUT data to DATABASE
        //-------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<Stockout>().Table("StockoutTable");
                DapperPlusManager.Entity<ExcelLoaded>().Table("ExcelLoaded");
                List<Stockout> stockoutTable = dataGridView1.DataSource as List<Stockout>;
                List<ExcelLoaded> excelLoadedTable = listBox1.DataSource as List<ExcelLoaded>;
                if (stockin != null)
                {
                    using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\repos\CSharp\9_IMS_Final\StocksDB.mdf;Integrated Security=True"))
                    { db.BulkInsert(stockoutTable);
                        db.BulkInsert(excelLoaded);
                    }
                }
                MessageBox.Show("Purchase Data Imported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importInvoiceExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select all invoices to be input";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                ExcelLoaded loadedList = new ExcelLoaded();
                foreach (string file in openFileDialog.FileNames)
                    {   try
                        {   FileInfo fileName = new FileInfo("" + file);
                            ExcelPackage package = new ExcelPackage(fileName);
                            ExcelWorksheet ws = package.Workbook.Worksheets[1];
                            loadedList.LoadedFileExcel = file;
                            listBox1.Items.Add(file);
                            excelLoaded.Add(loadedList);
                            int colSales = 1;
                            string cust_ID = ws.Cells[8, 8].Value.ToString(); //Hard-coded customer name value
                            string date_Loc = ws.Cells[4, 15].Value.ToString();
                            string date_Val = date_Loc.Substring(6, 10).ToString();
                            for (int rowSales = 15; rowSales < 30; rowSales++) //Hard-coded start as well
                            {
                                DataRow dr = tblSales.NewRow();
                                if (ws.Cells[rowSales, colSales].Value != null)
                                {
                                    //Populate the colSalesumns and rowSaless of our defined datatable
                                    Stockout stockoutList = new Stockout();
                                    stockoutList.Date = Convert.ToDateTime(date_Val);
                                    stockoutList.Cust_Name = cust_ID;
                                    stockoutList.Prod_ID = (ws.Cells[rowSales, colSales].Value).ToString();
                                    stockoutList.Prod_Name = ws.Cells[rowSales, colSales + 3].Value.ToString();
                                    stockoutList.Units = float.Parse((ws.Cells[rowSales, colSales + 9].Value).ToString());
                                    stockout.Add(stockoutList);
                                }
                            } //End of for loop to input Excel data
                            
                        }  catch (Exception ex)
                        {  MessageBox.Show(ex.ToString());    }
                    }
                    //Update datagridview after all files have been loaded.
                    
                    dataGridView1.DataSource = stockout;
                    dataGridView1.Refresh();
                } //End of dialog selection
            }//End of filter
        }
        //-------------------------------------
        //Import the STOCK-IN data to DATABASE
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {  DapperPlusManager.Entity<Stockin>().Table("StockinTable");
                List<Stockin> stockin = dataGridView1.DataSource as List<Stockin>;
                if (stockin != null)
                {
                    using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\repos\CSharp\9_IMS_Final\StocksDB.mdf;Integrated Security=True"))
                    {    db.BulkInsert(stockin);      }
                }  MessageBox.Show("Purchase Data Imported successfully!");
            }  catch (Exception ex)
            { MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int counterPurchase = 0;
        //------------import purchase data-----------
        private void importPurchaseExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                try
                {   FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                    ExcelPackage package = new ExcelPackage(fileName);
                    MessageBox.Show("FileName: " + fileName.ToString());
                    ExcelWorksheet ws = package.Workbook.Worksheets[1];
                    int colPurchase = 1;
                    for (int rowPurchase = 2; rowPurchase < 5000; rowPurchase++) //HARD-CODED - NEED TO UPDATE
                    {
                        DataRow dr = tblPurchase.NewRow();
                        if (ws.Cells[rowPurchase, colPurchase].Value != null)
                        {
                            Stockin stockinList = new Stockin();
                                //Populate the colPurchaseumns and rows of our defined datatable
                                //stockinList.ID = rowPurchase;
                            stockinList.Prod_ID = (ws.Cells[rowPurchase, colPurchase].Value).ToString();
                            stockinList.Prod_Name = (ws.Cells[rowPurchase, colPurchase + 1].Value).ToString();
                            stockinList.Date = Convert.ToDateTime(ws.Cells[rowPurchase, colPurchase + 2].Value.ToString());
                            stockinList.Expiry = Convert.ToDateTime(ws.Cells[rowPurchase, colPurchase + 3].Value.ToString());
                            stockinList.Sup_ID = ws.Cells[rowPurchase, colPurchase + 4].Value.ToString();
                            stockinList.Sup_Name = ws.Cells[rowPurchase, colPurchase + 5].Value.ToString();
                            stockinList.Units = float.Parse(ws.Cells[rowPurchase, colPurchase + 6].Value.ToString());
                            //dr[7] = ws.Cells[rowPurchase, colPurchase + 7].Value;
                            stockin.Add(stockinList);
                        }
                    } //End of for loop to input Excel data
                    dataGridView1.DataSource = stockin;
                    dataGridView1.Refresh();
                }  catch (Exception ex)
                {  MessageBox.Show(ex.ToString());  }
            } //End of dialog selection
            }//End of filter
        }

        //Instructions about use of software
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInstructions frminstructions = new frmInstructions();
            frminstructions.Show();
        }
        //Files already loaded in database
        private void filesLoadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoadedList frmloaded = new frmLoadedList();
            frmloaded.Show();
        }
    }
}
