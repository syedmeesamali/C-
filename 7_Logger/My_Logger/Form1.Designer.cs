namespace My_Logger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmdLog = new Button();
            cmdExit = new Button();
            SuspendLayout();
            // 
            // cmdLog
            // 
            cmdLog.Location = new Point(46, 34);
            cmdLog.Name = "cmdLog";
            cmdLog.Size = new Size(202, 47);
            cmdLog.TabIndex = 0;
            cmdLog.Text = "Create Log";
            cmdLog.UseVisualStyleBackColor = true;
            cmdLog.Click += cmdLog_Click;
            // 
            // cmdExit
            // 
            cmdExit.Location = new Point(46, 102);
            cmdExit.Name = "cmdExit";
            cmdExit.Size = new Size(202, 47);
            cmdExit.TabIndex = 1;
            cmdExit.Text = "&Exit";
            cmdExit.UseVisualStyleBackColor = true;
            cmdExit.Click += cmdExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 260);
            Controls.Add(cmdExit);
            Controls.Add(cmdLog);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Logger Form";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button cmdLog;
        private Button cmdExit;
    }
}