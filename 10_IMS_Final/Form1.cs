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

        //DataTableCollection tableCollection;
        DataTable tblSales = new DataTable("Sales");
        DataTable tblPurchase = new DataTable("Purchase");

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReportsForm stockReportsForm = new StockReportsForm();
            stockReportsForm.Show();
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
                        //string fileName;
                        FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                        ExcelPackage package = new ExcelPackage(fileName);
                        MessageBox.Show("FileName: " + fileName.ToString());
                        ExcelWorksheet ws = package.Workbook.Worksheets[1];
                        counterSales++;
                        int colSales = 1;
                        if (counterSales == 1) //Only for the first time define table structure
                        {
                            tblSales.Columns.Add("Prod ID", typeof(String));
                            tblSales.Columns.Add("Description", typeof(String));
                            tblSales.Columns.Add("Boxes", typeof(String));
                            tblSales.Columns.Add("Pcs", typeof(String));
                            tblSales.Columns.Add("Price", typeof(String));
                            tblSales.Columns.Add("Units", typeof(String));
                        }
                        
                        for (int rowSales = 15; rowSales < 30; rowSales++)
                        {
                            DataRow dr = tblSales.NewRow();
                            if (ws.Cells[rowSales, colSales].Value != null)
                            {
                                //Populate the colSalesumns and rowSaless of our defined datatable
                                dr[0] = ws.Cells[rowSales, colSales].Value;
                                dr[1] = ws.Cells[rowSales, colSales + 3].Value;
                                dr[2] = ws.Cells[rowSales, colSales + 6].Value;
                                dr[3] = ws.Cells[rowSales, colSales + 9].Value;
                                dr[4] = ws.Cells[rowSales, colSales + 11].Value;
                                dr[5] = ws.Cells[rowSales, colSales + 15].Value;
                                tblSales.Rows.Add(dr); //Add the prepared rowSales to table
                            }
                        } //End of for loop to input Excel data
                        //dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = tblSales;
                        dataGridView1.Refresh();
                    } //End of try blocks

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                } //End of dialog selection
            }//End of filter
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
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
                        if (counterPurchase == 1) //Only for the first time define table structure
                        {
                            tblPurchase.Columns.Add("Prod ID", typeof(String));
                            tblPurchase.Columns.Add("Prod Name", typeof(String));
                            tblPurchase.Columns.Add("Date", typeof(String));
                            tblPurchase.Columns.Add("Expiry", typeof(String));
                            tblPurchase.Columns.Add("Supp Code", typeof(String));
                            tblPurchase.Columns.Add("Supp Name", typeof(String));
                            tblPurchase.Columns.Add("Units", typeof(float));
                            tblPurchase.Columns.Add("Cost", typeof(float));
                        }

                        for (int rowPurchase = 2; rowPurchase < 5000; rowPurchase++) //HARD-CODED - NEED TO UPDATE
                        {
                            DataRow dr = tblPurchase.NewRow();
                            if (ws.Cells[rowPurchase, colPurchase].Value != null)
                            {
                                //Populate the colPurchaseumns and rows of our defined datatable
                                dr[0] = ws.Cells[rowPurchase, colPurchase].Value;
                                dr[1] = ws.Cells[rowPurchase, colPurchase + 1].Value;
                                dr[2] = ws.Cells[rowPurchase, colPurchase + 2].Value;
                                dr[3] = ws.Cells[rowPurchase, colPurchase + 3].Value;
                                dr[4] = ws.Cells[rowPurchase, colPurchase + 4].Value;
                                dr[5] = ws.Cells[rowPurchase, colPurchase + 5].Value;
                                dr[6] = ws.Cells[rowPurchase, colPurchase + 6].Value;
                                dr[7] = ws.Cells[rowPurchase, colPurchase + 7].Value;
                                tblPurchase.Rows.Add(dr); //Add the prepared row to table
                            }
                        } //End of for loop to input Excel data
                        //dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = tblPurchase;
                        dataGridView1.Refresh();
                    } //End of try blocks

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                } //End of dialog selection
            }//End of filter
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInstructions frminstructions = new frmInstructions();
            frminstructions.Show();
        }

        private void filesLoadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoadedList frmloaded = new frmLoadedList();
            frmloaded.Show();
        }
    }
}
