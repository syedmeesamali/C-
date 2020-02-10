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
        DataTable tbl = new DataTable("Details");
        
        

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
                            tbl.Columns.Add("Prod ID", typeof(String));
                            tbl.Columns.Add("Description", typeof(String));
                            tbl.Columns.Add("Boxes", typeof(String));
                            tbl.Columns.Add("Pcs", typeof(String));
                            tbl.Columns.Add("Price", typeof(String));
                            tbl.Columns.Add("Units", typeof(String));
                        }
                        
                        for (int row = 15; row < 30; row++)
                        {
                            DataRow dr = tbl.NewRow();
                            if (ws.Cells[row, col].Value != null)
                            {
                                //Populate the columns and rows of our defined datatable
                                dr[0] = ws.Cells[row, col].Value;
                                dr[1] = ws.Cells[row, col + 3].Value;
                                dr[2] = ws.Cells[row, col + 6].Value;
                                dr[3] = ws.Cells[row, col + 9].Value;
                                dr[4] = ws.Cells[row, col + 11].Value;
                                dr[5] = ws.Cells[row, col + 15].Value;
                                tbl.Rows.Add(dr); //Add the prepared row to table
                            }
                        } //End of for loop to input Excel data
                        //dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = tbl;
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
    }
}
