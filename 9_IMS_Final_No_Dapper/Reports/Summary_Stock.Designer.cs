namespace IMS_Final.Reports
{
    partial class Summary_Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Summary_Stock));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.combination = new IMS_Final.Combination();
            this.combinationTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.combinationTableTableAdapter = new IMS_Final.CombinationTableAdapters.CombinationTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.combination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combinationTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Combinaton";
            reportDataSource1.Value = this.combinationTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS_Final.Reports.Summary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1160, 556);
            this.reportViewer1.TabIndex = 13;
            // 
            // combination
            // 
            this.combination.DataSetName = "Combination";
            this.combination.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // combinationTableBindingSource
            // 
            this.combinationTableBindingSource.DataMember = "CombinationTable";
            this.combinationTableBindingSource.DataSource = this.combination;
            // 
            // combinationTableTableAdapter
            // 
            this.combinationTableTableAdapter.ClearBeforeFill = true;
            // 
            // Summary_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 591);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Summary_Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summary_Stock";
            this.Load += new System.EventHandler(this.Summary_Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combinationTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Combination combination;
        private System.Windows.Forms.BindingSource combinationTableBindingSource;
        private CombinationTableAdapters.CombinationTableTableAdapter combinationTableTableAdapter;
    }
}