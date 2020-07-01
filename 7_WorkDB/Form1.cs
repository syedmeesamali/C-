using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using FastMember;
using OfficeOpenXml;

namespace WorkDB
{
    public partial class frmMain : Form
    {
        private List<TaskLog> TaskLogs = new List<TaskLog>();   //List for tasklogs
        private List<Word> Words = new List<Word>();            //List for word data
        private List<Emails> EmailList = new List<Emails>();       //List for emails data

        //Main dispaly form - refresh the datagrid as well
        public frmMain()
        {
            InitializeComponent();
            dataGridView1.Refresh();
        }

        //Import the emails data the the database table
        private void importEmailsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to import Stock-in data to database?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            { try
                {   List<Emails> emailsList = dataGridView1.DataSource as List<Emails>;
                    if (emailsList != null)
                    {
                        using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Work.mdf;Integrated Security=True"))
                        {
                            conn.Open();
                            using (var bcp = new SqlBulkCopy(conn))
                            using (var reader = ObjectReader.Create(emailsList, "", "Date", "Project",
                                "Title"))
                            {
                                bcp.DestinationTableName = "Emails";
                                bcp.WriteToServer(reader);
                            }
                            MessageBox.Show("Emails Data Imported to SQL Server DB Successfully!");
                        }
                    }
                    else
                    { MessageBox.Show("Stockin is still null or there is some issue!"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Import the final project data sheet
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 2003-2016 workbooks|*.xlsx" }) //Filter for the type of files to show
            {   openFileDialog.Title = "Select input file for Log Data:";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                { try
                        {   FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //Important line
                            ExcelPackage package = new ExcelPackage(fileName);
                            ExcelWorksheet ws = package.Workbook.Worksheets[1];
                            int colLogs = 1;
                            for (int rowLogs = 2; rowLogs < 2000; rowLogs++) //Hard-coded start as well
                            {   if (ws.Cells[rowLogs, 1].Value != null)
                                {   DateTime parsedDate;
                                    TaskLog taskLogs = new TaskLog();
                                    parsedDate = DateTime.FromOADate(float.Parse((ws.Cells[rowLogs, colLogs].Value).ToString()));
                                    taskLogs.Date = parsedDate;
                                    taskLogs.ProjectName = ws.Cells[rowLogs, colLogs + 1].Value.ToString();
                                    taskLogs.Place = ws.Cells[rowLogs, colLogs + 2].Value.ToString();
                                    taskLogs.Type = ws.Cells[rowLogs, colLogs + 3].Value.ToString();
                                    taskLogs.Status = ws.Cells[rowLogs, colLogs + 4].Value.ToString();
                                taskLogs.Remarks = ws.Cells[rowLogs, colLogs + 5]?.Value?.ToString();
                                TaskLogs.Add(taskLogs);   }
                            } //End of for loop to input Excel data
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); }
                    }
                dataGridView1.DataSource = TaskLogs;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 350;
                dataGridView1.Refresh();
            }//End of filter
        }      

        //About button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Software developed by Engr. Syed", "About Software!");
        }

        //Import the word file using the word_import form module
        private void importWordFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Word_Import word_Import = new Word_Import();
            word_Import.Show();
        }

        //Import the quotations data
        private void importQuotationsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 2003-2016 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                openFileDialog.Title = "Select input file for Log Data:";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {
                    try
                    {
                        FileInfo fileName = new FileInfo("" + openFileDialog.FileName);
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //Important line
                        ExcelPackage package = new ExcelPackage(fileName);
                        ExcelWorksheet ws = package.Workbook.Worksheets[1];
                        int colLogs = 1;

                        for (int rowLogs = 2; rowLogs < 2000; rowLogs++) //Hard-coded start as well
                        {
                            if (ws.Cells[rowLogs, 1].Value != null)
                            {
                                DateTime parsedDate;
                                TaskLog taskLogs = new TaskLog();
                                parsedDate = DateTime.FromOADate(float.Parse((ws.Cells[rowLogs, colLogs].Value).ToString()));
                                taskLogs.Date = parsedDate;
                                taskLogs.ProjectName = ws.Cells[rowLogs, colLogs + 1].Value.ToString();
                                taskLogs.Place = ws.Cells[rowLogs, colLogs + 2].Value.ToString();
                                taskLogs.Type = ws.Cells[rowLogs, colLogs + 3].Value.ToString();
                                taskLogs.Status = ws.Cells[rowLogs, colLogs + 4].Value.ToString();
                                taskLogs.Remarks = ws.Cells[rowLogs, colLogs + 5]?.Value?.ToString();
                                TaskLogs.Add(taskLogs);
                            }
                        } //End of for loop to input Excel data
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }
                }

                dataGridView1.DataSource = TaskLogs;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 350;
                dataGridView1.Refresh();
            }//End of filter
        }


        //#####################################################
        //------------IMPORT EMAILS WITH PROJECT REFERENCE----
        //#####################################################
        private void btnEmails_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx" }) //Filter for the type of files to show
            {
                openFileDialog.Multiselect = false;
                openFileDialog.Title = "Select emails excel file";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {   foreach (string file in openFileDialog.FileNames)
                    {   try
                        {
                            FileInfo fileName = new FileInfo("" + file);
                            
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //Important line
                            ExcelPackage package = new ExcelPackage(fileName);
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            int colData = 1;
                            //string pattern = "dd/MM/yyyy";
                            //DateTime parsedDate;
                            for (int rowData = 2; rowData < 1500; rowData++) //Hard-coded start as well
                            {
                                if (ws.Cells[rowData, colData].Value != null)
                                {
                                    Emails mailsList = new Emails();
                                    //string date_val = (ws.Cells[rowData, colData + 1].Value).ToString();
                                    //DateTime.TryParseExact(date_val, pattern, null, DateTimeStyles.None, out parsedDate);
                                    mailsList.Date = (ws.Cells[rowData, colData + 1].Value).ToString();
                                    mailsList.Project = (ws.Cells[rowData, colData + 2].Value).ToString();
                                    mailsList.Title = (ws.Cells[rowData, colData + 3].Value).ToString();
                                    EmailList.Add(mailsList);
                                }
                            } //End of for loop to input Excel data
                        } catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); }
                    }
                    dataGridView1.DataSource = EmailList;
                    dataGridView1.Refresh();
                }
            }//End of filter and input for the data to be imported
        }

        //Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Show the task-log report
        private void taskLogReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Report_tasklog report_Tasklog = new Report_tasklog();
            report_Tasklog.Show();
        }
    }
}
