using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Spire.Xls;

namespace Excel_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<FilesLoaded> fileList = new List<FilesLoaded>();
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xls" }) //Filter for the type of files to show
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select xls files to be converted";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {    
                    foreach (string file in openFileDialog.FileNames)
                    {
                        try
                        {
                            {
                                FilesLoaded loadedList = new FilesLoaded();
                                loadedList.fileNames = file;
                                fileList.Add(loadedList);
                                Workbook book = new Workbook();
                                book.LoadFromFile(file);
                                string newfile = file + 'x';
                                book.SaveToFile(newfile, ExcelVersion.Version2016);
                            }
                            
                        } catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); }
                    }
                    MessageBox.Show("All files successfully converted !");
                    dataGridView1.DataSource = fileList;
                    dataGridView1.Columns[0].HeaderText = "List of files loaded";
                    dataGridView1.Columns[0].Width = 350;
                    dataGridView1.Refresh();
                }
            }//End of filter
        }

    }
}
