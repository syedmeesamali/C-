using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using Z.Dapper.Plus;

namespace WorkDB
{
    public partial class frmMain : Form
    {
        private List<TaskLog> TaskLogs = new List<TaskLog>();   //List for tasklogs
        private List<Word> Words = new List<Word>();            //List for word data
        private List<Emails> Emails = new List<Emails>();       //List for emails data

        //Main dispaly form - refresh the datagrid as well
        public frmMain()
        {
            InitializeComponent();
            dataGridView1.Refresh();
        }


        //Import the emails data and dispaly in the DGV
        private void importEmailsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        //Import task-log to the database
        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to import Task-Log data to database?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {   try
                {   DapperPlusManager.Entity<TaskLog>().Table("TaskLog"); //Dapper based method
                    List<TaskLog> taskLogs = dataGridView1.DataSource as List<TaskLog>;
                    if (taskLogs != null)
                    {
                        using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Repos\CSharp\13_WorkDB\Work.mdf;Integrated Security=True"))
                        { db.BulkInsert(taskLogs); }
                        MessageBox.Show("Tasklog Data Imported successfully!");
                    }  else
                    { MessageBox.Show("Tasklog is still null or there is some issue!"); }
                }  catch (Exception ex)
                { MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);                 }
                }
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

        
        //Import the emails to the database table already defined
        private void btnEmails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will import the emails");
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
