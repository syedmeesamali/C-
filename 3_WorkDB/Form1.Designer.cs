namespace WorkDB
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importEmailsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importQuotationsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importWordFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskLogReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.combinedReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnEmails = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importEmailsDataToolStripMenuItem,
            this.importDataToolStripMenuItem,
            this.importQuotationsDataToolStripMenuItem,
            this.importWordFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importEmailsDataToolStripMenuItem
            // 
            this.importEmailsDataToolStripMenuItem.Name = "importEmailsDataToolStripMenuItem";
            this.importEmailsDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.importEmailsDataToolStripMenuItem.Text = "Import Emails Data";
            this.importEmailsDataToolStripMenuItem.Click += new System.EventHandler(this.importEmailsDataToolStripMenuItem_Click);
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.importDataToolStripMenuItem.Text = "&Import Task-Log (Excel)";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // importQuotationsDataToolStripMenuItem
            // 
            this.importQuotationsDataToolStripMenuItem.Name = "importQuotationsDataToolStripMenuItem";
            this.importQuotationsDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.importQuotationsDataToolStripMenuItem.Text = "Import Quotations Data";
            this.importQuotationsDataToolStripMenuItem.Click += new System.EventHandler(this.importQuotationsDataToolStripMenuItem_Click);
            // 
            // importWordFileToolStripMenuItem
            // 
            this.importWordFileToolStripMenuItem.Name = "importWordFileToolStripMenuItem";
            this.importWordFileToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.importWordFileToolStripMenuItem.Text = "Word File Import";
            this.importWordFileToolStripMenuItem.Click += new System.EventHandler(this.importWordFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailsReportToolStripMenuItem,
            this.taskLogReportToolStripMenuItem1,
            this.combinedReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // emailsReportToolStripMenuItem
            // 
            this.emailsReportToolStripMenuItem.Name = "emailsReportToolStripMenuItem";
            this.emailsReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.emailsReportToolStripMenuItem.Text = "Emails Report";
            this.emailsReportToolStripMenuItem.Click += new System.EventHandler(this.emailsReportToolStripMenuItem_Click);
            // 
            // taskLogReportToolStripMenuItem1
            // 
            this.taskLogReportToolStripMenuItem1.Name = "taskLogReportToolStripMenuItem1";
            this.taskLogReportToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.taskLogReportToolStripMenuItem1.Text = "Task Log Report";
            this.taskLogReportToolStripMenuItem1.Click += new System.EventHandler(this.taskLogReportToolStripMenuItem1_Click);
            // 
            // combinedReportToolStripMenuItem
            // 
            this.combinedReportToolStripMenuItem.Name = "combinedReportToolStripMenuItem";
            this.combinedReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.combinedReportToolStripMenuItem.Text = "Combined Report";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1142, 513);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(187, 38);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(168, 33);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "&Import Task Log to DB";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnEmails
            // 
            this.btnEmails.Location = new System.Drawing.Point(12, 38);
            this.btnEmails.Name = "btnEmails";
            this.btnEmails.Size = new System.Drawing.Size(139, 33);
            this.btnEmails.TabIndex = 4;
            this.btnEmails.Text = "&Import Emails";
            this.btnEmails.UseVisualStyleBackColor = true;
            this.btnEmails.Click += new System.EventHandler(this.btnEmails_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.btnEmails);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1200, 650);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ToolStripMenuItem importWordFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importQuotationsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskLogReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem combinedReportToolStripMenuItem;
        private System.Windows.Forms.Button btnEmails;
        private System.Windows.Forms.ToolStripMenuItem importEmailsDataToolStripMenuItem;
    }
}

