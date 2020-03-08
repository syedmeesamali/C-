namespace WorkDB
{
    partial class Word_Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Word_Import));
            this.txtWord = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtClear = new System.Windows.Forms.Button();
            this.txtQtn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWord.Location = new System.Drawing.Point(12, 65);
            this.txtWord.Multiline = true;
            this.txtWord.Name = "txtWord";
            this.txtWord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
<<<<<<< HEAD
            this.txtWord.Size = new System.Drawing.Size(963, 524);
=======
            this.txtWord.Size = new System.Drawing.Size(932, 524);
>>>>>>> Trying to search text in word document - so far not successfull
            this.txtWord.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(170, 26);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "&Import Word Document:";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(402, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(151, 28);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtClear
            // 
            this.txtClear.Location = new System.Drawing.Point(220, 12);
            this.txtClear.Name = "txtClear";
            this.txtClear.Size = new System.Drawing.Size(151, 28);
            this.txtClear.TabIndex = 3;
            this.txtClear.Text = "&Clear Text";
            this.txtClear.UseVisualStyleBackColor = true;
            this.txtClear.Click += new System.EventHandler(this.txtClear_Click);
            // 
            // txtQtn
            // 
            this.txtQtn.Location = new System.Drawing.Point(975, 89);
            this.txtQtn.Name = "txtQtn";
            this.txtQtn.Size = new System.Drawing.Size(168, 20);
            this.txtQtn.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(972, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quotation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(972, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Client:";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(975, 157);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(168, 20);
            this.txtClient.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(972, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Project:";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(975, 233);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(168, 20);
            this.txtProject.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(972, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Value (AED):";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(975, 297);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(168, 20);
            this.txtValue.TabIndex = 10;
            // 
            // Word_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 601);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQtn);
            this.Controls.Add(this.txtClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Word_Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word_Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button txtClear;
        private System.Windows.Forms.TextBox txtQtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValue;
    }
}