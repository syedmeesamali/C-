namespace IMS_Final.Reports
{
    partial class ExpiryReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpiryReports));
            this.stockinTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDBDataSet_StockinExpiry = new IMS_Final.StocksDBDataSet_StockinExpiry();
            this.btnExpiryReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.stockinTableTableAdapter = new IMS_Final.StocksDBDataSet_StockinExpiryTableAdapters.StockinTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_StockinExpiry)).BeginInit();
            this.SuspendLayout();
            // 
            // stockinTableBindingSource
            // 
            this.stockinTableBindingSource.DataMember = "StockinTable";
            this.stockinTableBindingSource.DataSource = this.stocksDBDataSet_StockinExpiry;
            // 
            // stocksDBDataSet_StockinExpiry
            // 
            this.stocksDBDataSet_StockinExpiry.DataSetName = "StocksDBDataSet_StockinExpiry";
            this.stocksDBDataSet_StockinExpiry.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnExpiryReport
            // 
            this.btnExpiryReport.Location = new System.Drawing.Point(500, 33);
            this.btnExpiryReport.Name = "btnExpiryReport";
            this.btnExpiryReport.Size = new System.Drawing.Size(293, 34);
            this.btnExpiryReport.TabIndex = 10;
            this.btnExpiryReport.Text = "Generate Report";
            this.btnExpiryReport.UseVisualStyleBackColor = true;
            this.btnExpiryReport.Click += new System.EventHandler(this.btnExpiryReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select Date as Limit for Expiry:";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet_Expiry_Stockin";
            reportDataSource1.Value = this.stockinTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS_Final.Reports.Expiry.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 81);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1164, 518);
            this.reportViewer1.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(199, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(230, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // stockinTableTableAdapter
            // 
            this.stockinTableTableAdapter.ClearBeforeFill = true;
            // 
            // ExpiryReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnExpiryReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExpiryReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expiry Report (Stock-in Basis)";
            this.Load += new System.EventHandler(this.ExpiryReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_StockinExpiry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExpiryReport;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private StocksDBDataSet_StockinExpiry stocksDBDataSet_StockinExpiry;
        private System.Windows.Forms.BindingSource stockinTableBindingSource;
        private StocksDBDataSet_StockinExpiryTableAdapters.StockinTableTableAdapter stockinTableTableAdapter;
    }
}