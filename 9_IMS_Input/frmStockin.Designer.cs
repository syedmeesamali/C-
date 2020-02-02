namespace IMS_Input
{
    partial class frmStockin
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockinTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDataSet = new IMS_Input.StocksDataSet();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.stockinTableTableAdapter = new IMS_Input.StocksDataSetTableAdapters.StockinTableTableAdapter();
            this.cmdDisplay = new System.Windows.Forms.Button();
            this.cboSheets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.supIDDataGridViewTextBoxColumn,
            this.supNameDataGridViewTextBoxColumn,
            this.prodIDDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.expiryDataGridViewTextBoxColumn,
            this.unitsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.stockinTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(799, 300);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supIDDataGridViewTextBoxColumn
            // 
            this.supIDDataGridViewTextBoxColumn.DataPropertyName = "Sup_ID";
            this.supIDDataGridViewTextBoxColumn.HeaderText = "Sup_ID";
            this.supIDDataGridViewTextBoxColumn.Name = "supIDDataGridViewTextBoxColumn";
            this.supIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supNameDataGridViewTextBoxColumn
            // 
            this.supNameDataGridViewTextBoxColumn.DataPropertyName = "Sup_Name";
            this.supNameDataGridViewTextBoxColumn.HeaderText = "Sup_Name";
            this.supNameDataGridViewTextBoxColumn.Name = "supNameDataGridViewTextBoxColumn";
            this.supNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodIDDataGridViewTextBoxColumn
            // 
            this.prodIDDataGridViewTextBoxColumn.DataPropertyName = "Prod_ID";
            this.prodIDDataGridViewTextBoxColumn.HeaderText = "Prod_ID";
            this.prodIDDataGridViewTextBoxColumn.Name = "prodIDDataGridViewTextBoxColumn";
            this.prodIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expiryDataGridViewTextBoxColumn
            // 
            this.expiryDataGridViewTextBoxColumn.DataPropertyName = "Expiry";
            this.expiryDataGridViewTextBoxColumn.HeaderText = "Expiry";
            this.expiryDataGridViewTextBoxColumn.Name = "expiryDataGridViewTextBoxColumn";
            this.expiryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitsDataGridViewTextBoxColumn
            // 
            this.unitsDataGridViewTextBoxColumn.DataPropertyName = "Units";
            this.unitsDataGridViewTextBoxColumn.HeaderText = "Units";
            this.unitsDataGridViewTextBoxColumn.Name = "unitsDataGridViewTextBoxColumn";
            this.unitsDataGridViewTextBoxColumn.ReadOnly = true;
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
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 319);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(153, 32);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "&Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 367);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(153, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // stockinTableTableAdapter
            // 
            this.stockinTableTableAdapter.ClearBeforeFill = true;
            // 
            // cmdDisplay
            // 
            this.cmdDisplay.Location = new System.Drawing.Point(267, 356);
            this.cmdDisplay.Name = "cmdDisplay";
            this.cmdDisplay.Size = new System.Drawing.Size(153, 32);
            this.cmdDisplay.TabIndex = 3;
            this.cmdDisplay.Text = "&Display Data";
            this.cmdDisplay.UseVisualStyleBackColor = true;
            this.cmdDisplay.Click += new System.EventHandler(this.cmdDisplay_Click);
            // 
            // cboSheets
            // 
            this.cboSheets.FormattingEnabled = true;
            this.cboSheets.Location = new System.Drawing.Point(267, 319);
            this.cboSheets.Name = "cboSheets";
            this.cboSheets.Size = new System.Drawing.Size(221, 21);
            this.cboSheets.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sheet:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = "&Import to Database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmStockin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 429);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboSheets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdDisplay);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "frmStockin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Prepared Stockin Sheet";
            this.Load += new System.EventHandler(this.frmStockin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockinTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExit;
        private StocksDataSet stocksDataSet;
        private System.Windows.Forms.BindingSource stockinTableBindingSource;
        private StocksDataSetTableAdapters.StockinTableTableAdapter stockinTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button cmdDisplay;
        private System.Windows.Forms.ComboBox cboSheets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}