using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

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
        //Below function will display the data of selected sheet to datagridview
        private void cboSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            dataGridView.DataSource = dt;
        }

        //Show data from local database
        private void btnData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will show now data stored in Locald DB = prod_localdb");
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Repos\CSharp\5_Excel_SQL\prod_localdb.mdf;Integrated Security=True"); 
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM prods";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView.DataSource = dt;
        }

        //Insert new record to database
        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Repos\CSharp\5_Excel_SQL\prod_localdb.mdf;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO prods(Product_ID, Product_Name) VALUES('" + txtCode.Text + "', '" + txtProdName.Text + "')";
                    cmd.ExecuteNonQuery();
                    txtCode.Text = "";
                    txtProdName.Text = "";
                    dataGridView.Update();
                    dataGridView.Refresh();
                    MessageBox.Show("Date inserted into local DB successfully!");
                } catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.ToString());
                }
                
            }
            else
            {
                MessageBox.Show("Product code or name is invalid!", "Insert Failed");
            }
        }

        //Input box validation
        private bool IsValid()
        {
            if (txtCode.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Product code is required!", "Error");
                return false;
            }
            if (txtProdName.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Product name is required!", "Error");
                return false;
            }
            return true;
        }

        //Delete records by selecting manually from visible data-grid view
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will delete the selected datagridview record!", "Error");
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Repos\CSharp\5_Excel_SQL\prod_localdb.mdf;Integrated Security=True");
            try
            {
                int id = dataGridView.CurrentCell.RowIndex;
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE  E " +
                "FROM (SELECT  rn = ROW_NUMBER() OVER(ORDER BY(SELECT 0)) FROM dbo.prods) AS E " +
                "WHERE E.rn = " +  (id+1).ToString() + "";
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Row Deleted!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        } //End of cmdDelete button function

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//End of class
}