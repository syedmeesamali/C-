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
namespace ExceltoSQL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        DataTableCollection tableCollection;
        private void BtnImport_Click(object sender, EventArgs e)
        {
            
            using(OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xls|Excel Workbook|*.xlsx" }) //Filter for the type of files to show
             {
               if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                    txtFileName.Text = openFileDialog.FileName;        //Pick name from dialog box
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))  //Create stream for data
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true}
                            });
                            tableCollection = result.Tables;        
                            cboSheets.Items.Clear(); // clear the combo box
                            foreach (DataTable table in tableCollection)
                                cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                        }
                    }
                }
             }
        }
        private void cboSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            dataGridView.DataSource = dt;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will show now data stored in Product_Data SQL Database!");
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_con"].ConnectionString))
            {
                //conn.Open();
                SqlDataAdapter sqd = new SqlDataAdapter("SELECT * FROM ProductData", conn); //Show all records from table
                DataTable dt = new DataTable();
                sqd.Fill(dt);  //Fill the data table
                dataGridView.DataSource = dt;   //Data source is the data table
            } //End of usingSql
        }
    }
}