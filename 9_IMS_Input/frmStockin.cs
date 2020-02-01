using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Z.Dapper.Plus;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IMS_Input
{
    public partial class frmStockin : Form
    {
        public frmStockin()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xls|Excel Workbook|*.xlsx" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {

                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))  //Create stream for data
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            
                        }
                    }
                }
            } //End of filter for imoprt

        }

        private void frmStockin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDataSet.StockinTable' table.
            this.stockinTableTableAdapter.Fill(this.stocksDataSet.StockinTable);

        }

        private void cmdDisplay_Click(object sender, EventArgs e)
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
                stockinTableBindingSource.DataSource = stockin;
            }
            //BELOW CODE WILL IMPORT DATA TO LOCAL DATABASE
           
            try
            { 
                DapperPlusManager.Entity<Stockin>().Table("StockinTable");
                List<Stockin> stockin = stockinTableBindingSource.DataSource as List<Stockin>;
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
            
        }
    }
}
