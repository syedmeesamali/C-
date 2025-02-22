﻿namespace IMS_Final
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
            this.importInvoiceExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPurchaseExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importProductListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockReportFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearStockinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearStockoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFilesLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportProducts = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importInvoiceExcelToolStripMenuItem,
            this.importPurchaseExcelToolStripMenuItem,
            this.importProductListToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importInvoiceExcelToolStripMenuItem
            // 
            this.importInvoiceExcelToolStripMenuItem.Name = "importInvoiceExcelToolStripMenuItem";
            this.importInvoiceExcelToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.importInvoiceExcelToolStripMenuItem.Text = "Import Sales Invoice (Excel)";
            this.importInvoiceExcelToolStripMenuItem.Click += new System.EventHandler(this.importInvoiceExcelToolStripMenuItem_Click);
            // 
            // importPurchaseExcelToolStripMenuItem
            // 
            this.importPurchaseExcelToolStripMenuItem.Name = "importPurchaseExcelToolStripMenuItem";
            this.importPurchaseExcelToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.importPurchaseExcelToolStripMenuItem.Text = "Import Purchase Invoice (Excel)";
            this.importPurchaseExcelToolStripMenuItem.Click += new System.EventHandler(this.importPurchaseExcelToolStripMenuItem_Click);
            // 
            // importProductListToolStripMenuItem
            // 
            this.importProductListToolStripMenuItem.Name = "importProductListToolStripMenuItem";
            this.importProductListToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.importProductListToolStripMenuItem.Text = "Import Product List";
            this.importProductListToolStripMenuItem.Click += new System.EventHandler(this.importProductListToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockReportFormToolStripMenuItem,
            this.clearProductsToolStripMenuItem,
            this.clearStockinToolStripMenuItem,
            this.clearStockoutToolStripMenuItem,
            this.clearFilesLoadedToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // stockReportFormToolStripMenuItem
            // 
            this.stockReportFormToolStripMenuItem.Name = "stockReportFormToolStripMenuItem";
            this.stockReportFormToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stockReportFormToolStripMenuItem.Text = "&Main Reports Form";
            this.stockReportFormToolStripMenuItem.Click += new System.EventHandler(this.stockReportFormToolStripMenuItem_Click);
            // 
            // clearProductsToolStripMenuItem
            // 
            this.clearProductsToolStripMenuItem.Name = "clearProductsToolStripMenuItem";
            this.clearProductsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearProductsToolStripMenuItem.Text = "Clear Products";
            this.clearProductsToolStripMenuItem.Click += new System.EventHandler(this.clearProductsToolStripMenuItem_Click);
            // 
            // clearStockinToolStripMenuItem
            // 
            this.clearStockinToolStripMenuItem.Name = "clearStockinToolStripMenuItem";
            this.clearStockinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearStockinToolStripMenuItem.Text = "Clear Stockin";
            this.clearStockinToolStripMenuItem.Click += new System.EventHandler(this.clearStockinToolStripMenuItem_Click);
            // 
            // clearStockoutToolStripMenuItem
            // 
            this.clearStockoutToolStripMenuItem.Name = "clearStockoutToolStripMenuItem";
            this.clearStockoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearStockoutToolStripMenuItem.Text = "Clear Stockout";
            this.clearStockoutToolStripMenuItem.Click += new System.EventHandler(this.clearStockoutToolStripMenuItem_Click);
            // 
            // clearFilesLoadedToolStripMenuItem
            // 
            this.clearFilesLoadedToolStripMenuItem.Name = "clearFilesLoadedToolStripMenuItem";
            this.clearFilesLoadedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearFilesLoadedToolStripMenuItem.Text = "Clear FilesLoaded";
            this.clearFilesLoadedToolStripMenuItem.Click += new System.EventHandler(this.clearFilesLoadedToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesLoadedToolStripMenuItem,
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // filesLoadedToolStripMenuItem
            // 
            this.filesLoadedToolStripMenuItem.Name = "filesLoadedToolStripMenuItem";
            this.filesLoadedToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.filesLoadedToolStripMenuItem.Text = "Files Loaded";
            this.filesLoadedToolStripMenuItem.Click += new System.EventHandler(this.filesLoadedToolStripMenuItem_Click);
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(19, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(852, 552);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(19, 607);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(216, 26);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "Import Stock-In to Databasee";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 607);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Import Stock-out to Database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(880, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(392, 524);
            this.listBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(877, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "List of files loaded:";
            // 
            // btnImportProducts
            // 
            this.btnImportProducts.Location = new System.Drawing.Point(535, 607);
            this.btnImportProducts.Name = "btnImportProducts";
            this.btnImportProducts.Size = new System.Drawing.Size(180, 26);
            this.btnImportProducts.TabIndex = 6;
            this.btnImportProducts.Text = "Import Product List";
            this.btnImportProducts.UseVisualStyleBackColor = true;
            this.btnImportProducts.Click += new System.EventHandler(this.btnImportProducts_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.btnImportProducts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1050, 650);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management & Reporting System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importInvoiceExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPurchaseExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockReportFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesLoadedToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem importProductListToolStripMenuItem;
        private System.Windows.Forms.Button btnImportProducts;
        private System.Windows.Forms.ToolStripMenuItem clearProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearStockinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearStockoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFilesLoadedToolStripMenuItem;
    }
}

