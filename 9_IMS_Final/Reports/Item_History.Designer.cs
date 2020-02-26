namespace IMS_Final.Reports
{
    partial class Item_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Item_History));
            this.btnSummary = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboHistory = new System.Windows.Forms.ComboBox();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDBDataSet_Products = new IMS_Final.StocksDBDataSet_Products();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productsTableAdapter = new IMS_Final.StocksDBDataSet_ProductsTableAdapters.ProductsTableAdapter();
            this.btnHistory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(500, 19);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(152, 26);
            this.btnSummary.TabIndex = 17;
            this.btnSummary.Text = "Get Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Select Product Name:";
            // 
            // cboHistory
            // 
            this.cboHistory.DataSource = this.productsBindingSource;
            this.cboHistory.DisplayMember = "Prod_Name";
            this.cboHistory.FormattingEnabled = true;
            this.cboHistory.Location = new System.Drawing.Point(144, 19);
            this.cboHistory.Name = "cboHistory";
            this.cboHistory.Size = new System.Drawing.Size(326, 21);
            this.cboHistory.TabIndex = 19;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1210, 510);
            this.dataGridView1.TabIndex = 20;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(500, 51);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(152, 26);
            this.btnHistory.TabIndex = 21;
            this.btnHistory.Text = "Get History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Summary:";
            // 
            // Item_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 631);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSummary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Item_History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product History and Summary";
            this.Load += new System.EventHandler(this.Item_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDBDataSet_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHistory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private StocksDBDataSet_Products stocksDBDataSet_Products;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private StocksDBDataSet_ProductsTableAdapters.ProductsTableAdapter productsTableAdapter;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label label2;
    }
}