using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Work_Log
{
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataTableCollection tableCollection;
        private void importExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
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
                                cboSheets.Items.Clear(); // clear the combo box
                                foreach (DataTable table in tableCollection)
                                    cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                            }
                        }
                    } //If valid excel file
                }//Open excel file
        }//Import excel file button

        //Display the selected sheet in excel file loaded
        private void btnData_Click(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            //dataGridView1.DataSource = dt;
            if (dt != null)
            {
                List<Products> products = new List<Products>();
                for (int i=0; i < dt.Rows.Count; i++)
                {
                    Products prodList = new Products();
                    prodList.ID = i.ToString();
                    prodList.ProdID = dt.Rows[i]["ProdID"].ToString();
                    prodList.ProdName = dt.Rows[i]["ProdName"].ToString();
                    products.Add(prodList);
                }
                productsBindingSource.DataSource = products;
            }
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDBDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.masterDBDataSet.Products);

        }
    }
}
