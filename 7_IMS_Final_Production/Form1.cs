using System;
using System.Collections.Generic;
using System.Globalization;
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
        private List<Stockout> stockout = new List<Stockout>();
        private List<Stockin> stockin = new List<Stockin>();
        private List<ExcelLoaded> excelLoaded = new List<ExcelLoaded>();
        private List<Products> products = new List<Products>();

        public frmMain()
        {
            InitializeComponent();
            dataGridView1.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReportsForm stockReportsForm = new StockReportsForm();
            stockReportsForm.Show();
        }
        //############################################
        //------------IMPORT SALES DATA (INVOICES)----
        //############################################
        private void importInvoiceExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select all invoices to be input";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                
                foreach (string file in openFileDialog.FileNames)
                    {   try
                        {   FileInfo fileName = new FileInfo("" + file);
                            ExcelLoaded loadedList = new ExcelLoaded();
                            ExcelPackage package = new ExcelPackage(fileName);
                            ExcelWorksheet ws = package.Workbook.Worksheets[1];
                            loadedList.LoadedFileName = file;
                            listBox1.Items.Add(file);
                            listBox1.HorizontalScrollbar = true;
                            excelLoaded.Add(loadedList);
                            int colSales = 1;
                            string cust_ID = ws.Cells[8, 8].Value.ToString(); //Hard-coded customer name value
                            string pattern = "dd/MM/yyyy";
                            string date_Loc = ws.Cells[4, 15].Value.ToString();
                            string date_Val = date_Loc.Substring(6, 10).ToString();
                            string Invoice_Loc = ws.Cells[4, 11].Value.ToString();
                            string Invoice_Val = Invoice_Loc.Substring(8, 9).ToString();
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
                            
                        }  catch (Exception ex)
                        {  MessageBox.Show(ex.ToString());    }
                    }
                    
                    dataGridView1.DataSource = stockout;
                    dataGridView1.Refresh();
                } 
            }//End of filter
        }

        //Import the STOCK-OUT data to DATABASE
        //-------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to import data?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DapperPlusManager.Entity<Stockout>().Table("StockoutTable");
                    DapperPlusManager.Entity<ExcelLoaded>().Table("ExcelFiles");
                    List<Stockout> stockout = dataGridView1.DataSource as List<Stockout>;
                    //List<ExcelLoaded> excelLoaded = listBox1.DataSource as List<ExcelLoaded>;
                    if (excelLoaded != null)
                    {
                        using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                        {
                            db.BulkInsert(stockout);
                            db.BulkInsert(excelLoaded);
                        }
                        MessageBox.Show("Purchase Data Imported successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Stockout or Excel-loaded is null and there is some error!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            else
            {
                MessageBox.Show("No data update done!", "Update Cancelled");
            }
            
        }
        //############################################
        //------------IMPORT PURCHASE DATA-----------
        //############################################
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
                    ExcelWorksheet ws = package.Workbook.Worksheets[1];
                    int colPurchase = 1;
                    for (int rowPurchase = 2; rowPurchase < 25000; rowPurchase++) //HARD-CODED - NEED TO UPDATE
                    {
                        if (ws.Cells[rowPurchase, colPurchase].Value != null)
                        {
                            Stockin stockinList = new Stockin();
                            stockinList.Prod_ID = (ws.Cells[rowPurchase, colPurchase].Value).ToString();
                            stockinList.Prod_Name = (ws.Cells[rowPurchase, colPurchase + 1].Value).ToString();
                            stockinList.Date = Convert.ToDateTime(ws.Cells[rowPurchase, colPurchase + 2].Value.ToString());
                            stockinList.Expiry = Convert.ToDateTime(ws.Cells[rowPurchase, colPurchase + 3].Value.ToString());
                            stockinList.Sup_ID = ws.Cells[rowPurchase, colPurchase + 4].Value.ToString();
                            stockinList.Sup_Name = ws.Cells[rowPurchase, colPurchase + 5].Value.ToString();
                            stockinList.Units = float.Parse(ws.Cells[rowPurchase, colPurchase + 6].Value.ToString());
                            stockinList.Cost = float.Parse(ws.Cells[rowPurchase, colPurchase + 7].Value.ToString());
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

        //-------------------------------------
        //Import the STOCK-IN data to DATABASE
        private void btnView_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to import Stock-in data to database?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DapperPlusManager.Entity<Stockin>().Table("StockinTable");
                    List<Stockin> stockin = dataGridView1.DataSource as List<Stockin>;
                    if (stockin != null)
                    {
                        using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                        { db.BulkInsert(stockin); }
                        MessageBox.Show("Purchase Data Imported successfully!");
                    }
                    else
                    { MessageBox.Show("Stockin is still null or there is some issue!"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Instructions about use of software
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInstructions frminstructions = new frmInstructions();
            frminstructions.Show();
        }
        //Files already loaded in database
        private void filesLoadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoadedList frmloaded = new frmLoadedList();
            frmloaded.Show();
        }

        //############################################
        //------------IMPORT PRODUCT LIST-----------
        //############################################
        private void importProductListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 2003-2016 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                    try
                    {   FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                        ExcelPackage package = new ExcelPackage(fileName);
                        ExcelWorksheet ws = package.Workbook.Worksheets[1];
                        int colProds = 1;
                        int reOrderVal;
                        for (int rowProds = 2; rowProds < 5000; rowProds++) //HARD-CODED - NEED TO UPDATE
                        {
                            if (ws.Cells[rowProds, colProds].Value != null)
                            {
                                Products productList = new Products();
                                productList.Prod_ID = (ws.Cells[rowProds, colProds].Value).ToString();
                                productList.Prod_Name = (ws.Cells[rowProds, colProds + 1].Value).ToString();
                                Int32.TryParse(ws.Cells[rowProds, colProds + 2].Value.ToString(), out reOrderVal);
                                productList.Re_Order = reOrderVal;
                                products.Add(productList);
                            }
                        } //End of for loop to input Excel data
                        dataGridView1.DataSource = products;
                        dataGridView1.Refresh();
                    } catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }
                } //End of dialog selection
            }//End of filter
        }

        private void btnImportProducts_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to import Product-List data to database?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DapperPlusManager.Entity<Stockin>().Table("Products");
                    List<Products> products = dataGridView1.DataSource as List<Products>;
                    if (products != null)
                    {
                        using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                        { db.BulkInsert(products); }
                        MessageBox.Show("Products Data with Re-Order Imported successfully!");
                    }
                    else
                    { MessageBox.Show("Data is null or some issue!"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } //End of button import products

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutIMS aboutIMS = new AboutIMS();
            aboutIMS.Show();
        }

        private void clearProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = "DELETE FROM Products; DBCC CHECKIDENT ('Products', RESEED, 0);";
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Products Table emptied successfully!", "Products Table");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void clearFilesLoadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = "DELETE FROM ExcelFiles; DBCC CHECKIDENT ('ExcelFiles', RESEED, 0);";
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Loaded list emptied successfully!", "Loaded List");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearStockinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to DELETE the Stock-in Table?", "Delete Stockin?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string commandText = "DELETE FROM StockinTable; DBCC CHECKIDENT ('StockinTable', RESEED, 0);";
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Stockin Table emptied successfully!", "Stockin Table");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }//End of dialog-box IF
        }

        private void clearStockoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to DELETE the Stock-out Table?", "Delete Stockin?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string commandText = "DELETE FROM StockoutTable; DBCC CHECKIDENT ('StockoutTable', RESEED, 0);";
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True"))
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Stockout Table emptied successfully!", "Stockout Table");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }//End of dialog-box IF
        }
    }//End of class
}
