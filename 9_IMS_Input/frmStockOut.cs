using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Z.Dapper.Plus;
using System.Collections.Generic;
using System.Data.SqlClient;
using ExcelDataReader;

namespace IMS_Input
{
    public partial class frmStockOut : Form
    {
        public frmStockOut()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;
        private void frmStockOut_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDataSet.StockoutTable' table. You can move, or remove it, as needed.
            this.stockoutTableTableAdapter.Fill(this.stocksDataSet.StockoutTable);

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx|Excel Workbook|*.xls" }) //Filter for the type of files to show
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
                            cboSheets.Items.Clear(); // clear the combo box
                            foreach (DataTable table in tableCollection)
                                cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                        }
                    }
                }
            } //End of filter for import 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void cmdDisplay_Click(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            if (dt != null)
            {
                List<Stockout> stockout = new List<Stockout>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Stockout stockoutItems = new Stockout();
                    stockoutItems.ID = i;
                    stockoutItems.Date = (DateTime)dt.Rows[i]["Date"]; //Explicit conversion
                    stockoutItems.Cust_ID = dt.Rows[i]["Cust_ID"].ToString();
                    stockoutItems.Cust_Name = dt.Rows[i]["Cust_Name"].ToString();
                    stockoutItems.Prod_ID = dt.Rows[i]["Prod_ID"].ToString();
                    stockoutItems.Prod_Name = dt.Rows[i]["Prod_Name"].ToString();
                    stockoutItems.Units = float.Parse(dt.Rows[i]["Units"].ToString());
                    stockout.Add(stockoutItems);
                }
                stockoutTableBindingSource.DataSource = stockout;
            } //if not null
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BELOW CODE WILL IMPORT DATA TO LOCAL DATABASE
            try
            {
                DapperPlusManager.Entity<Stockout>().Table("StockOutTable");
                List<Stockout> stockout = stockoutTableBindingSource.DataSource as List<Stockout>;
                if (stockout != null)
                {
                    using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\repos\CSharp\9_IMS_Input\Stocks.mdf;Integrated Security=True"))
                    {
                        db.BulkInsert(stockout);
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
