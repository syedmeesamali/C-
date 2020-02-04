namespace IMS_Final
{
    partial class StockReportsForm
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
            this.btnFullReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.stocksDBDataSet_Products = new IMS_Final.StocksDBDataSet_Products();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new IMS_Final.StocksDBDataSet_ProductsTableAdapters.ProductsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFullReport
            // 
            this.btnFullReport.Location = new System.Drawing.Point(28, 32);
            this.btnFullReport.Name = "btnFullReport";
            this.btnFullReport.Size = new System.Drawing.Size(162, 34);
            this.btnFullReport.TabIndex = 0;
            this.btnFullReport.Text = "Full stocks report";
            this.btnFullReport.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(32, 85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(158, 34);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // stocksDBDataSet_Products
            // 
            this.stocksDBDataSet_Products.DataSetName = "StocksDBDataSet_Products";
            this.stocksDBDataSet_Products.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.stocksDBDataSet_Products;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Specific Reports";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StockReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 283);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFullReport);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(681, 322);
            this.MinimumSize = new System.Drawing.Size(681, 322);
            this.Name = "StockReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Reports Form";
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFullReport;
        private System.Windows.Forms.Button btnExit;
        private StocksDBDataSet_Products stocksDBDataSet_Products;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private StocksDBDataSet_ProductsTableAdapters.ProductsTableAdapter productsTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}