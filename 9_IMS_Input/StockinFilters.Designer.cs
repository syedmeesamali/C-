namespace IMS_Input
{
    partial class StockinFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockinFilters));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFullReport = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.stocksDataSet = new IMS_Input.StocksDataSet();
            this.stockinTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockinTableTableAdapter = new IMS_Input.StocksDataSetTableAdapters.StockinTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(21, 85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnFullReport
            // 
            this.btnFullReport.Location = new System.Drawing.Point(21, 30);
            this.btnFullReport.Name = "btnFullReport";
            this.btnFullReport.Size = new System.Drawing.Size(169, 31);
            this.btnFullReport.TabIndex = 1;
            this.btnFullReport.Text = "Full stock-in Data";
            this.btnFullReport.UseVisualStyleBackColor = true;
            this.btnFullReport.Click += new System.EventHandler(this.btnFullReport_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.stockinTableBindingSource;
            this.comboBox1.DisplayMember = "Prod_Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(280, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(270, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "Prod_Name";
            // 
            // stocksDataSet
            // 
            this.stocksDataSet.DataSetName = "StocksDataSet";
            this.stocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockinTableBindingSource
            // 
            this.stockinTableBindingSource.DataMember = "StockinTable";
            this.stockinTableBindingSource.DataSource = this.stocksDataSet;
            // 
            // stockinTableTableAdapter
            // 
            this.stockinTableTableAdapter.ClearBeforeFill = true;
            // 
            // StockinFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 317);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnFullReport);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StockinFilters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports for Stockin";
            this.Load += new System.EventHandler(this.StockinFilters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFullReport;
        private System.Windows.Forms.ComboBox comboBox1;
        private StocksDataSet stocksDataSet;
        private System.Windows.Forms.BindingSource stockinTableBindingSource;
        private StocksDataSetTableAdapters.StockinTableTableAdapter stockinTableTableAdapter;
    }
}