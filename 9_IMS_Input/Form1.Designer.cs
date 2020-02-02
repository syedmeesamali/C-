namespace IMS_Input
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExcelSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preparedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPreparedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importStockOutFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockMainReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expiryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnData = new System.Windows.Forms.Button();
            this.cboSheets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preparedFileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importExcelSheetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importExcelSheetToolStripMenuItem
            // 
            this.importExcelSheetToolStripMenuItem.Name = "importExcelSheetToolStripMenuItem";
            this.importExcelSheetToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.importExcelSheetToolStripMenuItem.Text = "Import Excel Sheet";
            this.importExcelSheetToolStripMenuItem.Click += new System.EventHandler(this.importExcelSheetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // preparedFileToolStripMenuItem
            // 
            this.preparedFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPreparedFileToolStripMenuItem,
            this.importStockOutFileToolStripMenuItem});
            this.preparedFileToolStripMenuItem.Name = "preparedFileToolStripMenuItem";
            this.preparedFileToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.preparedFileToolStripMenuItem.Text = "Prepared File";
            // 
            // importPreparedFileToolStripMenuItem
            // 
            this.importPreparedFileToolStripMenuItem.Name = "importPreparedFileToolStripMenuItem";
            this.importPreparedFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.importPreparedFileToolStripMenuItem.Text = "Import Stock-In File";
            this.importPreparedFileToolStripMenuItem.Click += new System.EventHandler(this.importPreparedFileToolStripMenuItem_Click);
            // 
            // importStockOutFileToolStripMenuItem
            // 
            this.importStockOutFileToolStripMenuItem.Name = "importStockOutFileToolStripMenuItem";
            this.importStockOutFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.importStockOutFileToolStripMenuItem.Text = "Import Stock-Out File";
            this.importStockOutFileToolStripMenuItem.Click += new System.EventHandler(this.importStockOutFileToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockMainReportToolStripMenuItem,
            this.filterReportToolStripMenuItem,
            this.expiryReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // stockMainReportToolStripMenuItem
            // 
            this.stockMainReportToolStripMenuItem.Name = "stockMainReportToolStripMenuItem";
            this.stockMainReportToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.stockMainReportToolStripMenuItem.Text = "StockIn Main Report";
            this.stockMainReportToolStripMenuItem.Click += new System.EventHandler(this.stockMainReportToolStripMenuItem_Click);
            // 
            // filterReportToolStripMenuItem
            // 
            this.filterReportToolStripMenuItem.Name = "filterReportToolStripMenuItem";
            this.filterReportToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.filterReportToolStripMenuItem.Text = "Filter Report";
            // 
            // expiryReportToolStripMenuItem
            // 
            this.expiryReportToolStripMenuItem.Name = "expiryReportToolStripMenuItem";
            this.expiryReportToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.expiryReportToolStripMenuItem.Text = "Expiry Report";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 289);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data in Selected Sheet:";
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(290, 354);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(115, 24);
            this.btnData.TabIndex = 9;
            this.btnData.Text = "&Display";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // cboSheets
            // 
            this.cboSheets.FormattingEnabled = true;
            this.cboSheets.Location = new System.Drawing.Point(57, 356);
            this.cboSheets.Name = "cboSheets";
            this.cboSheets.Size = new System.Drawing.Size(221, 21);
            this.cboSheets.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sheet:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 408);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.cboSheets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMS Data Analysis";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExcelSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.ComboBox cboSheets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem preparedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPreparedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importStockOutFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockMainReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expiryReportToolStripMenuItem;
    }
}

