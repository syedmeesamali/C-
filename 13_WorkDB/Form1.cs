using System;
using System.Collections.Generic;
using System.Globalization;
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
        private List<TaskLog> TaskLogs = new List<TaskLog>();
        
        public frmMain()
        {
            InitializeComponent();
            dataGridView1.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
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
                            ExcelPackage package = new ExcelPackage(fileName);
                            ExcelWorksheet ws = package.Workbook.Worksheets[1];
                            int colLogs = 1;
                            
                            for (int rowLogs = 2; rowLogs < 5; rowLogs++) //Hard-coded start as well
                            {
                                if (ws.Cells[rowLogs, 1].Value != null)
                                {
                                    DateTime parsedDate;
                                    TaskLog taskLogs = new TaskLog();
                                    string date_Val = ws.Cells[rowLogs, colLogs].Value.ToString();
                                    DateTime.TryParseExact(date_Val, "yyyy-MM-dd", null, DateTimeStyles.None, out parsedDate);
                                    MessageBox.Show("date_Val: " + date_Val.ToString());
                                    MessageBox.Show("parsed: " + parsedDate.ToString());
                                taskLogs.Date = parsedDate;
                                    taskLogs.ProjectName = ws.Cells[rowLogs, colLogs + 1].Value.ToString();
                                    taskLogs.Place = ws.Cells[rowLogs, colLogs + 2].Value.ToString();
                                    taskLogs.Type = ws.Cells[rowLogs, colLogs + 3].Value.ToString();
                                    taskLogs.Status = ws.Cells[rowLogs, colLogs + 4].Value.ToString();
                                    taskLogs.Remarks = ws.Cells[rowLogs, colLogs + 4].Value.ToString();
                                TaskLogs.Add(taskLogs);
                                }
                            } //End of for loop to input Excel data
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); }
                    }
                    dataGridView1.DataSource = TaskLogs;
                    dataGridView1.Refresh();
            }//End of filter
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to import Task-Log data to database?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DapperPlusManager.Entity<TaskLog>().Table("TaskLog");
                    List<TaskLog> taskLogs = dataGridView1.DataSource as List<TaskLog>;
                    if (taskLogs != null)
                    {
                        using (IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Repos\CSharp\13_WorkDB\Work.mdf;Integrated Security=True"))
                        { db.BulkInsert(taskLogs); }
                        MessageBox.Show("Tasklog Data Imported successfully!");
                    }
                    else
                    { MessageBox.Show("Tasklog is still null or there is some issue!"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Some error occurred! Please check parameters!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
