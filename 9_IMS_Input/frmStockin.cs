using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

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
            // TODO: This line of code loads data into the 'stocksDataSet.StockinTable' table. You can move, or remove it, as needed.
            this.stockinTableTableAdapter.Fill(this.stocksDataSet.StockinTable);

        }
    }
}
