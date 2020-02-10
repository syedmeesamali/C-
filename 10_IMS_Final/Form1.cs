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

        private void importInvoiceExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {

                    //string fileName;
                    FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                    ExcelPackage package = new ExcelPackage(fileName);
                    MessageBox.Show("FileName: " + fileName.ToString());
                    ExcelWorksheet ws = package.Workbook.Worksheets[1];
                    
                    int col = 1;
                    tbl.Columns.Add("Prod ID", typeof(String));
                    tbl.Columns.Add("Description", typeof(String));
                    tbl.Columns.Add("Boxes", typeof(String));
                    tbl.Columns.Add("Pcs", typeof(String));
                    tbl.Columns.Add("Price", typeof(String));
                    tbl.Columns.Add("Units", typeof(String));
                    
                    int[] offsets = {1, 3, 6, 9, 11, 16}; // use for offsets of columns
                    
                    for (int row = 15; row < 30; row++)
                    {
                        
                        if (ws.Cells[row, col].Value != null)
                        {
                            DataRow dr = tbl.NewRow();
                            //for (int cols =1; cols<6; cols++)
                            //{
                            //    dr[cols] = ws.Cells[row, cols].Value;
                            //}
                            foreach (int cols in offsets)
                            {
                                dr[cols] = ws.Cells[row, cols].Value;
                            }

                            tbl.Rows.Add(dr); //Add the prepared row to table
                            
                            listBox1.Items.Add(ws.Cells[row, col].Value);
                            listBox1.Items.Add(ws.Cells[row, col + 3].Value);
                            listBox1.Items.Add(ws.Cells[row, col + 6].Value);
                            listBox1.Items.Add(ws.Cells[row, col + 9].Value);
                            listBox1.Items.Add(ws.Cells[row, col + 11].Value);
                            listBox1.Items.Add(ws.Cells[row, col + 15].Value);
                        }
                        
                    } //End of for loop to input Excel data
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = tbl;
                    dataGridView1.Refresh();

                } //End of dialog selection
            }//End of filter
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
        }
    }
}
