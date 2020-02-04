namespace IMS_Input
{
    partial class TotalStocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotalStocks));
            this.StockinTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StocksDataSet = new IMS_Input.StocksDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StockinTableTableAdapter = new IMS_Input.StocksDataSetTableAdapters.StockinTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.StockinTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StocksDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // StockinTableBindingSource
            // 
            this.StockinTableBindingSource.DataMember = "StockinTable";
            this.StockinTableBindingSource.DataSource = this.StocksDataSet;
            // 
            // StocksDataSet
            // 
            this.StocksDataSet.DataSetName = "StocksDataSet";
            this.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.StockinTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS_Input.TotalStocks.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(889, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // StockinTableTableAdapter
            // 
            this.StockinTableTableAdapter.ClearBeforeFill = true;
            // 
            // TotalStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(905, 489);
            this.Name = "TotalStocks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TotalStocks";
            this.Load += new System.EventHandler(this.TotalStocks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockinTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StocksDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StockinTableBindingSource;
        private StocksDataSet StocksDataSet;
        private StocksDataSetTableAdapters.StockinTableTableAdapter StockinTableTableAdapter;
    }
}