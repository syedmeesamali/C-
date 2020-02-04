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
            this.stockinTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDBDataSet_Complete = new IMS_Final.StocksDBDataSet_Complete();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDBDataSet_Products = new IMS_Final.StocksDBDataSet_Products();
            this.button1 = new System.Windows.Forms.Button();
            this.productsTableAdapter = new IMS_Final.StocksDBDataSet_ProductsTableAdapters.ProductsTableAdapter();
            this.stockinTableTableAdapter = new IMS_Final.StocksDBDataSet_CompleteTableAdapters.StockinTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Complete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Products)).BeginInit();
            this.SuspendLayout();
            // 
            // stockinTableBindingSource
            // 
            this.stockinTableBindingSource.DataMember = "StockinTable";
            this.stockinTableBindingSource.DataSource = this.stocksDBDataSet_Complete;
            // 
            // stocksDBDataSet_Complete
            // 
            this.stocksDBDataSet_Complete.DataSetName = "StocksDBDataSet_Complete";
            this.stocksDBDataSet_Complete.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Product_Report_StocksDB";
            reportDataSource1.Value = this.stockinTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS_Final.Reports.Product_Report.rdlc";
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
            this.comboBox1.DataSource = this.productsBindingSource;
            this.comboBox1.DisplayMember = "Prod_Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(181, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "Prod_Name";
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.stocksDBDataSet_Products;
            // 
            // stocksDBDataSet_Products
            // 
            this.stocksDBDataSet_Products.DataSetName = "StocksDBDataSet_Products";
            this.stocksDBDataSet_Products.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // stockinTableTableAdapter
            // 
            this.stockinTableTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Complete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private StocksDBDataSet_Products stocksDBDataSet_Products;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private StocksDBDataSet_ProductsTableAdapters.ProductsTableAdapter productsTableAdapter;
        private StocksDBDataSet_Complete stocksDBDataSet_Complete;
        private System.Windows.Forms.BindingSource stockinTableBindingSource;
        private StocksDBDataSet_CompleteTableAdapters.StockinTableTableAdapter stockinTableTableAdapter;
    }
}