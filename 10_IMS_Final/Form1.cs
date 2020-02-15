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
        private ObservableCollection<Stockout> stockout = new ObservableCollection<Stockout>();
        private ObservableCollection<Stockin> stockin = new ObservableCollection<Stockin>();
        
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

        //-------------------------------------
        //Import the STOCK-OUT data to DATABASE
        //-------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DapperPlusManager.Entity<Stockin>().Table("StockoutTable");
            //    List<Stockout> stockout = dataGridView1.DataSource as List<Stockout>;
            //    if (stockin != null)
            //    {
            //        using (IDbConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\repos\CSharp\10_IMS_Final\StocksDB.mdf; Integrated Security = True"))
            //        {
            //            db.BulkInsert(stockin);
            //        }
            //    }
            //    MessageBox.Show("Sales Data Imported successfully!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        int counterSales = 0;
        private void importInvoiceExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                try
                {
                    FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                    ExcelPackage package = new ExcelPackage(fileName);
                    MessageBox.Show("FileName: " + fileName.ToString());
                    ExcelWorksheet ws = package.Workbook.Worksheets[1];
                    counterSales++;
                    int colSales = 1;
                    
                    if (counterSales == 1) //Only for the first time define table structure
                    {
                        tblSales.Columns.Add("Date", typeof(DateTime));
                        tblSales.Columns.Add("Cust ID", typeof(String));
                        tblSales.Columns.Add("Prod ID", typeof(String));
                        tblSales.Columns.Add("Prod Name", typeof(String));
                        tblSales.Columns.Add("Pcs", typeof(String));
                    }
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
                            dr[0] = date_Val;
                            stockoutList.Date = Convert.ToDateTime(dr[0].ToString());
                            dr[1] = cust_ID;
                            stockoutList.Cust_Name = dr[1].ToString();
                            dr[2] = ws.Cells[rowSales, colSales].Value;
                            stockoutList.Prod_ID = dr[2].ToString();
                            dr[3] = ws.Cells[rowSales, colSales + 3].Value;
                            stockoutList.Prod_Name = dr[3].ToString();
                            dr[4] = ws.Cells[rowSales, colSales + 9].Value;
                            stockoutList.Units = float.Parse(dr[4].ToString());
                            tblSales.Rows.Add(dr); //Add the prepared rowSales to table
                            stockout.Add(stockoutList);
                        }
                    } //End of for loop to input Excel data
                    //dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = stockout;
                    dataGridView1.Refresh();
                }  catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                } //End of dialog selection
            }//End of filter
        }

        //-------------------------------------
        //Import the STOCK-IN data to DATABASE
        //-------------------------------------
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<Stockin>().Table("StockinTable");
                List<Stockin> stockin = dataGridView1.DataSource as List<Stockin>;
                if (stockin != null)
                {
                    using (IDbConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\repos\CSharp\10_IMS_Final\StocksDB.mdf; Integrated Security = True"))
                    {
                        db.BulkInsert(stockin);
                    }
                }
                MessageBox.Show("Purchase Data Imported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                {
                    //string fileName;
                    FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                    ExcelPackage package = new ExcelPackage(fileName);
                    MessageBox.Show("FileName: " + fileName.ToString());
                    ExcelWorksheet ws = package.Workbook.Worksheets[1];
                    counterPurchase++;
                    int colPurchase = 1;
                    //List<Stockin> stockin = new List<Stockin>();

                    if (counterPurchase == 1) //Only for the first time define table structure
                    {
                        tblPurchase.Columns.Add("Prod ID", typeof(String));
                        tblPurchase.Columns.Add("Prod Name", typeof(String));
                        tblPurchase.Columns.Add("Date", typeof(String));
                        tblPurchase.Columns.Add("Expiry", typeof(String));
                        tblPurchase.Columns.Add("Supp Code", typeof(String));
                        tblPurchase.Columns.Add("Supp Name", typeof(String));
                        tblPurchase.Columns.Add("Units", typeof(float));
                        //tblPurchase.Columns.Add("Cost", typeof(float));
                    }

                    for (int rowPurchase = 2; rowPurchase < 5000; rowPurchase++) //HARD-CODED - NEED TO UPDATE
                    {
                        DataRow dr = tblPurchase.NewRow();
                        if (ws.Cells[rowPurchase, colPurchase].Value != null)
                        {
                            Stockin stockinList = new Stockin();
                            //Populate the colPurchaseumns and rows of our defined datatable
                            stockinList.ID = rowPurchase;
                            dr[0] = ws.Cells[rowPurchase, colPurchase].Value;
                            stockinList.Prod_ID = dr[0].ToString();
                            dr[1] = ws.Cells[rowPurchase, colPurchase + 1].Value;
                            stockinList.Prod_Name = dr[1].ToString();
                            dr[2] = ws.Cells[rowPurchase, colPurchase + 2].Value;
                            stockinList.Date = Convert.ToDateTime(dr[2].ToString());
                            dr[3] = ws.Cells[rowPurchase, colPurchase + 3].Value;
                            stockinList.Expiry = Convert.ToDateTime(dr[3].ToString());
                            dr[4] = ws.Cells[rowPurchase, colPurchase + 4].Value;
                            stockinList.Sup_ID = dr[4].ToString();
                            dr[5] = ws.Cells[rowPurchase, colPurchase + 5].Value;
                            stockinList.Sup_Name = dr[5].ToString();
                            dr[6] = ws.Cells[rowPurchase, colPurchase + 6].Value;
                            stockinList.Units = float.Parse(dr[6].ToString());
                            //dr[7] = ws.Cells[rowPurchase, colPurchase + 7].Value;
                            tblPurchase.Rows.Add(dr); //Add the prepared row to table
                            stockin.Add(stockinList);
                        }
                    } //End of for loop to input Excel data
                    dataGridView1.DataSource = stockin;
                    dataGridView1.Refresh();
                }  catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
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
