namespace IMS_Final.Reports
{
    partial class Product_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product_Report));
            this.stocksDBDataSet_StockinExpiry = new IMS_Final.StocksDBDataSet_StockinExpiry();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.stockinTableProductsTableAdapter = new IMS_Final.StocksDBDataSet_StockinExpiryTableAdapters.StockinTableProductsTableAdapter();
            this.stockinTableProductsNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockinTableProductsNTableAdapter = new IMS_Final.StocksDBDataSet_StockinExpiryTableAdapters.StockinTableProductsNTableAdapter();
            this.stockinTableProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDBDataSet_StockinExpiry1 = new IMS_Final.StocksDBDataSet_StockinExpiry();
            this.stockinTableProductsNBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_StockinExpiry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableProductsNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_StockinExpiry1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableProductsNBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // stocksDBDataSet_StockinExpiry
            // 
            this.stocksDBDataSet_StockinExpiry.DataSetName = "StocksDBDataSet_StockinExpiry";
            this.stocksDBDataSet_StockinExpiry.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet_StockinExpiry";
            reportDataSource1.Value = this.stockinTableProductsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS_Final.Reports.Expiry_Stockin.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 58);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(785, 337);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select name of product below:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.stockinTableProductsNBindingSource1, "Prod_Name", true));
            this.comboBox1.DataSource = this.stockinTableProductsNBindingSource;
            this.comboBox1.DisplayMember = "Prod_Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(181, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "Prod_Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(293, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Generate Report for Selected Product";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stockinTableProductsTableAdapter
            // 
            this.stockinTableProductsTableAdapter.ClearBeforeFill = true;
            // 
            // stockinTableProductsNBindingSource
            // 
            this.stockinTableProductsNBindingSource.DataMember = "StockinTableProductsN";
            this.stockinTableProductsNBindingSource.DataSource = this.stocksDBDataSet_StockinExpiry;
            // 
            // stockinTableProductsNTableAdapter
            // 
            this.stockinTableProductsNTableAdapter.ClearBeforeFill = true;
            // 
            // stockinTableProductsBindingSource
            // 
            this.stockinTableProductsBindingSource.DataMember = "StockinTableProducts";
            this.stockinTableProductsBindingSource.DataSource = this.stocksDBDataSet_StockinExpiry;
            // 
            // stocksDBDataSet_StockinExpiry1
            // 
            this.stocksDBDataSet_StockinExpiry1.DataSetName = "StocksDBDataSet_StockinExpiry";
            this.stocksDBDataSet_StockinExpiry1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockinTableProductsNBindingSource1
            // 
            this.stockinTableProductsNBindingSource1.DataMember = "StockinTableProductsN";
            this.stockinTableProductsNBindingSource1.DataSource = this.stocksDBDataSet_StockinExpiry1;
            // 
            // Product_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 407);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Product_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product_Report";
            this.Load += new System.EventHandler(this.Product_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_StockinExpiry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableProductsNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_StockinExpiry1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableProductsNBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private StocksDBDataSet_StockinExpiry stocksDBDataSet_StockinExpiry;
        private StocksDBDataSet_StockinExpiryTableAdapters.StockinTableProductsTableAdapter stockinTableProductsTableAdapter;
        private System.Windows.Forms.BindingSource stockinTableProductsNBindingSource;
        private StocksDBDataSet_StockinExpiryTableAdapters.StockinTableProductsNTableAdapter stockinTableProductsNTableAdapter;
        private System.Windows.Forms.BindingSource stockinTableProductsBindingSource;
        private StocksDBDataSet_StockinExpiry stocksDBDataSet_StockinExpiry1;
        private System.Windows.Forms.BindingSource stockinTableProductsNBindingSource1;
    }
}