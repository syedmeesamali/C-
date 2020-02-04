namespace IMS_Input
{
    partial class StockFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockFilters));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStockin = new System.Windows.Forms.Button();
            this.cboStockin = new System.Windows.Forms.ComboBox();
            this.stockinTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDataSet = new IMS_Input.StocksDataSet();
            this.stockinTableTableAdapter = new IMS_Input.StocksDataSetTableAdapters.StockinTableTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStockout = new System.Windows.Forms.ComboBox();
            this.stockoutTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockoutTableTableAdapter = new IMS_Input.StocksDataSetTableAdapters.StockoutTableTableAdapter();
            this.btnStockout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockoutTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(21, 132);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnStockin
            // 
            this.btnStockin.Location = new System.Drawing.Point(21, 30);
            this.btnStockin.Name = "btnStockin";
            this.btnStockin.Size = new System.Drawing.Size(169, 31);
            this.btnStockin.TabIndex = 1;
            this.btnStockin.Text = "Full stock-in Data";
            this.btnStockin.UseVisualStyleBackColor = true;
            this.btnStockin.Click += new System.EventHandler(this.btnStockin_Click_1);
            // 
            // cboStockin
            // 
            this.cboStockin.DataSource = this.stockinTableBindingSource;
            this.cboStockin.DisplayMember = "Prod_Name";
            this.cboStockin.FormattingEnabled = true;
            this.cboStockin.Location = new System.Drawing.Point(385, 40);
            this.cboStockin.Name = "cboStockin";
            this.cboStockin.Size = new System.Drawing.Size(270, 21);
            this.cboStockin.TabIndex = 2;
            this.cboStockin.ValueMember = "Prod_Name";
            // 
            // stockinTableBindingSource
            // 
            this.stockinTableBindingSource.DataMember = "StockinTable";
            this.stockinTableBindingSource.DataSource = this.stocksDataSet;
            // 
            // stocksDataSet
            // 
            this.stocksDataSet.DataSetName = "StocksDataSet";
            this.stocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockinTableTableAdapter
            // 
            this.stockinTableTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Stock-in Product Names:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stock-out Product Names:";
            // 
            // cboStockout
            // 
            this.cboStockout.DataSource = this.stockoutTableBindingSource;
            this.cboStockout.DisplayMember = "Prod_Name";
            this.cboStockout.FormattingEnabled = true;
            this.cboStockout.Location = new System.Drawing.Point(384, 111);
            this.cboStockout.Name = "cboStockout";
            this.cboStockout.Size = new System.Drawing.Size(270, 21);
            this.cboStockout.TabIndex = 4;
            this.cboStockout.ValueMember = "Prod_Name";
            // 
            // stockoutTableBindingSource
            // 
            this.stockoutTableBindingSource.DataMember = "StockoutTable";
            this.stockoutTableBindingSource.DataSource = this.stocksDataSet;
            // 
            // stockoutTableTableAdapter
            // 
            this.stockoutTableTableAdapter.ClearBeforeFill = true;
            // 
            // btnStockout
            // 
            this.btnStockout.Location = new System.Drawing.Point(21, 76);
            this.btnStockout.Name = "btnStockout";
            this.btnStockout.Size = new System.Drawing.Size(169, 31);
            this.btnStockout.TabIndex = 6;
            this.btnStockout.Text = "Full stock-out Data";
            this.btnStockout.UseVisualStyleBackColor = true;
            this.btnStockout.Click += new System.EventHandler(this.btnStockout_Click);
            // 
            // StockFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 262);
            this.Controls.Add(this.btnStockout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStockout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStockin);
            this.Controls.Add(this.btnStockin);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StockFilters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports for Stock-in Stock-out";
            this.Load += new System.EventHandler(this.StockinFilters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockoutTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStockin;
        private System.Windows.Forms.ComboBox cboStockin;
        private StocksDataSet stocksDataSet;
        private System.Windows.Forms.BindingSource stockinTableBindingSource;
        private StocksDataSetTableAdapters.StockinTableTableAdapter stockinTableTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStockout;
        private System.Windows.Forms.BindingSource stockoutTableBindingSource;
        private StocksDataSetTableAdapters.StockoutTableTableAdapter stockoutTableTableAdapter;
        private System.Windows.Forms.Button btnStockout;
    }
}