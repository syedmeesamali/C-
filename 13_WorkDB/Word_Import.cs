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
                        using (var document = DocX.Load(fileName.FullName))
                        {
                            
                            txtWord.Text = document.Paragraphs[0].Text;
                            for (int j=1; j<document.Paragraphs.Count; j++)
                            {
                                txtWord.AppendText(Environment.NewLine + document.Paragraphs[j].Text);
                            }
                        }
                    } catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }
                }
            }//End of filter
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            txtWord.Text = "";
        }
    }
}
