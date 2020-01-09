using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            { Filter = "Excel 97-2003 workbooks|*.xls|Excel Workbook|*.xlsx" })
             {
               if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true}
                            });
                            tableCollection = result.Tables;
                            cboSheets.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                        }
                    }
                }
             }
        }
        private void cboSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()];
            dataGridView.DataSource = dt;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet!");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void cmdLogin_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                //using (string constring = ConfigurationManager.ConnectionStrings["rbx"].ConnectionString) ;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["rbx"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Login_VerifyLoginDetails", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", userName.Text.TrimStart());
                        cmd.Parameters.AddWithValue("@Password", passBox.Password.TrimStart());
                        conn.Open();    //Open DB connection

                        //MessageBox.Show(dat1);
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            this.Hide();
                            DashboardForm df = new DashboardForm();
                            df.Show();

                        }
                        else
                        {
                            MessageBox.Show("Username or password is wrong!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    } //End of sqlCommand

                } //End of usingSql

            } //End of isValid()
        } //End of cmdLogin

        //Function to check if the input fields are empty or filled
        private bool IsValid()
        {
            if (userName.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("User name is required!", "Error");
                return false;
            }

            //Check password box
            if (passBox.Password.TrimStart() == string.Empty)
            {
                MessageBox.Show("Password is required!", "Error");
                return false;
            }

            return true;

        } //End of isValid function

    }
}