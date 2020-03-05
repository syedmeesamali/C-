using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Xceed.Words.NET;

namespace WorkDB
{
    public partial class Word_Import : Form
    {
        public Word_Import()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Import Word Document|*.docx" }) //Filter for the type of files to show
            {
                openFileDialog.Title = "Select word document to import: ";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                    FileInfo fileName = new FileInfo("" + openFileDialog.FileName);

                    try
                    {
                        MessageBox.Show("File name is: " + fileName);
                        using (var document = DocX.Load(fileName.FullName))
                        {
                            txtWord.Text = document.Text;
                        }
                    } catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }
                }
            }//End of filter
        }
    }
}
