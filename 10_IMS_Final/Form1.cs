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
        int counter = 0;
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
                        counter++;
                        int col = 1;
                        if (counter == 1) //Only for the first time define table structure
                        {
                            tblSales.Columns.Add("Prod ID", typeof(String));
                            tblSales.Columns.Add("Description", typeof(String));
                            tblSales.Columns.Add("Boxes", typeof(String));
                            tblSales.Columns.Add("Pcs", typeof(String));
                            tblSales.Columns.Add("Price", typeof(String));
                            tblSales.Columns.Add("Units", typeof(String));
                        }
                        
                        for (int row = 15; row < 30; row++)
                        {
                            DataRow dr = tblSales.NewRow();
                            if (ws.Cells[row, col].Value != null)
                            {
                                //Populate the columns and rows of our defined datatable
                                dr[0] = ws.Cells[row, col].Value;
                                dr[1] = ws.Cells[row, col + 3].Value;
                                dr[2] = ws.Cells[row, col + 6].Value;
                                dr[3] = ws.Cells[row, col + 9].Value;
                                dr[4] = ws.Cells[row, col + 11].Value;
                                dr[5] = ws.Cells[row, col + 15].Value;
                                tblSales.Rows.Add(dr); //Add the prepared row to table
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
                        counter++;
                        int col = 1;
                        if (counter == 1) //Only for the first time define table structure
                        {
                            tblPurchase.Columns.Add("Prod ID", typeof(String));
                            tblPurchase.Columns.Add("Prod Name", typeof(String));
                            tblPurchase.Columns.Add("Date", typeof(DateTime));
                            tblPurchase.Columns.Add("Expiry", typeof(DateTime));
                            tblPurchase.Columns.Add("Supp Code", typeof(String));
                            tblPurchase.Columns.Add("Supp Name", typeof(String));
                            tblPurchase.Columns.Add("Units", typeof(float));
                            tblPurchase.Columns.Add("Cost", typeof(float));
                        }

                        for (int row = 2; row < 5000; row++) //HARD-CODED - NEED TO UPDATE
                        {
                            DataRow dr = tblPurchase.NewRow();
                            if (ws.Cells[row, col].Value != null)
                            {
                                //Populate the columns and rows of our defined datatable
                                dr[0] = ws.Cells[row, col].Value;
                                dr[1] = ws.Cells[row, col + 1].Value;
                                dr[2] = ws.Cells[row, col + 2].Value;
                                dr[3] = ws.Cells[row, col + 3].Value;
                                dr[4] = ws.Cells[row, col + 4].Value;
                                dr[5] = ws.Cells[row, col + 5].Value;
                                dr[5] = ws.Cells[row, col + 6].Value;
                                dr[5] = ws.Cells[row, col + 7].Value;
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
