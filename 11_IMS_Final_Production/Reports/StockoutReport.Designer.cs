namespace IMS_Final.Reports
{
    partial class StockoutReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockoutReport));
            this.stockoutTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockDataset = new IMS_Final.StockDataset();
            this.btnExpiryReport = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.stockoutTableTableAdapter = new IMS_Final.StockDatasetTableAdapters.StockoutTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.stockoutTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // stockoutTableBindingSource
            // 
            this.stockoutTableBindingSource.DataMember = "StockoutTable";
            this.stockoutTableBindingSource.DataSource = this.stockDataset;
            // 
            // stockDataset
            // 
            this.stockDataset.DataSetName = "StockDataset";
            this.stockDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnExpiryReport
            // 
            this.btnExpiryReport.Location = new System.Drawing.Point(12, 12);
            this.btnExpiryReport.Name = "btnExpiryReport";
            this.btnExpiryReport.Size = new System.Drawing.Size(293, 34);
            this.btnExpiryReport.TabIndex = 11;
            this.btnExpiryReport.Text = "Generate Report";
            this.btnExpiryReport.UseVisualStyleBackColor = true;
            this.btnExpiryReport.Click += new System.EventHandler(this.btnExpiryReport_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "StockoutDataset";
            reportDataSource1.Value = this.stockoutTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS_Final.Reports.Stocks.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1242, 536);
            this.reportViewer1.TabIndex = 12;
            // 
            // stockoutTableTableAdapter
            // 
            this.stockoutTableTableAdapter.ClearBeforeFill = true;
            // 
            // StockoutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 611);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnExpiryReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockoutReport";
            this.Text = "Stockout Report";
            this.Load += new System.EventHandler(this.StockoutReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockoutTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExpiryReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private StockDataset stockDataset;
        private System.Windows.Forms.BindingSource stockoutTableBindingSource;
        private StockDatasetTableAdapters.StockoutTableTableAdapter stockoutTableTableAdapter;
    }
}