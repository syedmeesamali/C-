using System;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;
using System.Drawing;

namespace WorkDB
{
    public partial class Word_Import : Form
    {
        public Word_Import()
        {
            InitializeComponent();
        }
        
        //Find my text method 
        public int FindMyText(string text, int start)
        {
            int returnValue = -1;
            if (text.Length > 0 && start >= 0)
            {
                int indexToText =rtBoxData.Find(text, start, RichTextBoxFinds.MatchCase);
                if (indexToText >= 0)
                {
                    returnValue = indexToText;
                }
            }
            return returnValue;
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
                            rtBoxData.Text = document.Paragraphs[0].Text;
                            for (int j=1; j<document.Paragraphs.Count; j++)
                            {
                                rtBoxData.AppendText(Environment.NewLine + document.Paragraphs[j].Text);
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
            rtBoxData.Text = "";
        }

        //Search for particular text in the main box
        private void btnGet_Click(object sender, EventArgs e)
        {
            //rtBoxData.Find("Ref: ", RichTextBoxFinds.MatchCase);
            //rtBoxData.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
            //rtBoxData.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
            //rtBoxData.SelectionColor = Color.Red;
            //rtBoxData.SelectionBackColor = Color.Yellow;
            string ref1 = "Ref:";
            string ref2 = "Project:";
            string ref3 = "Subject:";
            int fVal = FindMyText(ref1, 1);
            int pVal = FindMyText(ref2, 1);
            int sVal = FindMyText(ref3, 1);

            txtQtn.Text = rtBoxData.Text.Substring(fVal+5, 15);
            String[] myLines = rtBoxData.Text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            txtClient.Text = myLines[2] + myLines[3] + myLines[4];
            
            
            txtProject.Text = rtBoxData.Text.Substring(pVal + 9, sVal - pVal - 9);
            txtValue.Text = "AED Value";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }
    }
}
