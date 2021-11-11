
namespace RPI_GUI_02
{
    partial class Form1
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
            this.btnSerial = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.textSerial = new System.Windows.Forms.TextBox();
            this.labelSerial = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSerial
            // 
            this.btnSerial.Location = new System.Drawing.Point(41, 88);
            this.btnSerial.Name = "btnSerial";
            this.btnSerial.Size = new System.Drawing.Size(189, 50);
            this.btnSerial.TabIndex = 0;
            this.btnSerial.Text = "Send Data To Serial Port";
            this.btnSerial.UseVisualStyleBackColor = true;
            this.btnSerial.Click += new System.EventHandler(this.btnSerial_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(43, 196);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(162, 54);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textSerial
            // 
            this.textSerial.Location = new System.Drawing.Point(41, 47);
            this.textSerial.Name = "textSerial";
            this.textSerial.Size = new System.Drawing.Size(317, 20);
            this.textSerial.TabIndex = 3;
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Location = new System.Drawing.Point(40, 31);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(239, 13);
            this.labelSerial.TabIndex = 4;
            this.labelSerial.Text = "Enter Text below to send to Serial Port of Arduino";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 287);
            this.Controls.Add(this.labelSerial);
            this.Controls.Add(this.textSerial);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSerial);
            this.Name = "Form1";
            this.Text = "Simple GUI for RPI 3B+";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSerial;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox textSerial;
        private System.Windows.Forms.Label labelSerial;
    }
}

