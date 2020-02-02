namespace IMS_Input
{
    partial class frmStockOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockOut));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stocksDataSet = new IMS_Input.StocksDataSet();
            this.stockoutTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockoutTableTableAdapter = new IMS_Input.StocksDataSetTableAdapters.StockoutTableTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.cboSheets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdDisplay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockoutTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.custIDDataGridViewTextBoxColumn,
            this.custNameDataGridViewTextBoxColumn,
            this.prodIDDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.unitsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.stockoutTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(20, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(770, 331);
            this.dataGridView1.TabIndex = 0;
            // 
            // stocksDataSet
            // 
            this.stocksDataSet.DataSetName = "StocksDataSet";
            this.stocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // custIDDataGridViewTextBoxColumn
            // 
            this.custIDDataGridViewTextBoxColumn.DataPropertyName = "Cust_ID";
            this.custIDDataGridViewTextBoxColumn.HeaderText = "Cust_ID";
            this.custIDDataGridViewTextBoxColumn.Name = "custIDDataGridViewTextBoxColumn";
            // 
            // custNameDataGridViewTextBoxColumn
            // 
            this.custNameDataGridViewTextBoxColumn.DataPropertyName = "Cust_Name";
            this.custNameDataGridViewTextBoxColumn.HeaderText = "Cust_Name";
            this.custNameDataGridViewTextBoxColumn.Name = "custNameDataGridViewTextBoxColumn";
            // 
            // prodIDDataGridViewTextBoxColumn
            // 
            this.prodIDDataGridViewTextBoxColumn.DataPropertyName = "Prod_ID";
            this.prodIDDataGridViewTextBoxColumn.HeaderText = "Prod_ID";
            this.prodIDDataGridViewTextBoxColumn.Name = "prodIDDataGridViewTextBoxColumn";
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            // 
            // unitsDataGridViewTextBoxColumn
            // 
            this.unitsDataGridViewTextBoxColumn.DataPropertyName = "Units";
            this.unitsDataGridViewTextBoxColumn.HeaderText = "Units";
            this.unitsDataGridViewTextBoxColumn.Name = "unitsDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 32);
            this.button1.TabIndex = 17;
            this.button1.Text = "&Import to Database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboSheets
            // 
            this.cboSheets.FormattingEnabled = true;
            this.cboSheets.Location = new System.Drawing.Point(275, 358);
            this.cboSheets.Name = "cboSheets";
            this.cboSheets.Size = new System.Drawing.Size(221, 21);
            this.cboSheets.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Sheet:";
            // 
            // cmdDisplay
            // 
            this.cmdDisplay.Location = new System.Drawing.Point(275, 395);
            this.cmdDisplay.Name = "cmdDisplay";
            this.cmdDisplay.Size = new System.Drawing.Size(153, 32);
            this.cmdDisplay.TabIndex = 14;
            this.cmdDisplay.Text = "&Display Data";
            this.cmdDisplay.UseVisualStyleBackColor = true;
            this.cmdDisplay.Click += new System.EventHandler(this.cmdDisplay_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(20, 406);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(153, 32);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(20, 358);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(153, 32);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "&Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmStockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboSheets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdDisplay);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStockOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStockOut";
            this.Load += new System.EventHandler(this.frmStockOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockoutTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private StocksDataSet stocksDataSet;
        private System.Windows.Forms.BindingSource stockoutTableBindingSource;
        private StocksDataSetTableAdapters.StockoutTableTableAdapter stockoutTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboSheets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdDisplay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnImport;
    }
}