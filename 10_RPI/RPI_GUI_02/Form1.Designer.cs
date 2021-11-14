
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnBase = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnArm1 = new System.Windows.Forms.Button();
            this.btnArm2 = new System.Windows.Forms.Button();
            this.btnCloseGrip = new System.Windows.Forms.Button();
            this.btnOpenGrip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBase
            // 
            this.btnBase.Location = new System.Drawing.Point(202, 23);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(111, 50);
            this.btnBase.TabIndex = 0;
            this.btnBase.Text = "Move Base - 1";
            this.btnBase.UseVisualStyleBackColor = true;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(165, 248);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(193, 54);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnArm1
            // 
            this.btnArm1.Location = new System.Drawing.Point(74, 93);
            this.btnArm1.Name = "btnArm1";
            this.btnArm1.Size = new System.Drawing.Size(111, 50);
            this.btnArm1.TabIndex = 3;
            this.btnArm1.Text = "Move Arm1 - 2";
            this.btnArm1.UseVisualStyleBackColor = true;
            this.btnArm1.Click += new System.EventHandler(this.btnArm1_Click);
            // 
            // btnArm2
            // 
            this.btnArm2.Location = new System.Drawing.Point(326, 93);
            this.btnArm2.Name = "btnArm2";
            this.btnArm2.Size = new System.Drawing.Size(111, 50);
            this.btnArm2.TabIndex = 4;
            this.btnArm2.Text = "Move Arm2 - 3";
            this.btnArm2.UseVisualStyleBackColor = true;
            this.btnArm2.Click += new System.EventHandler(this.btnArm2_Click);
            // 
            // btnCloseGrip
            // 
            this.btnCloseGrip.Location = new System.Drawing.Point(202, 169);
            this.btnCloseGrip.Name = "btnCloseGrip";
            this.btnCloseGrip.Size = new System.Drawing.Size(111, 50);
            this.btnCloseGrip.TabIndex = 5;
            this.btnCloseGrip.Text = "Close Gripper - 5";
            this.btnCloseGrip.UseVisualStyleBackColor = true;
            this.btnCloseGrip.Click += new System.EventHandler(this.btnCloseGrip_Click);
            // 
            // btnOpenGrip
            // 
            this.btnOpenGrip.Location = new System.Drawing.Point(202, 93);
            this.btnOpenGrip.Name = "btnOpenGrip";
            this.btnOpenGrip.Size = new System.Drawing.Size(111, 50);
            this.btnOpenGrip.TabIndex = 6;
            this.btnOpenGrip.Text = "Open Gripper - 4";
            this.btnOpenGrip.UseVisualStyleBackColor = true;
            this.btnOpenGrip.Click += new System.EventHandler(this.btnOpenGrip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 330);
            this.Controls.Add(this.btnOpenGrip);
            this.Controls.Add(this.btnCloseGrip);
            this.Controls.Add(this.btnArm2);
            this.Controls.Add(this.btnArm1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple GUI for RPI 3B+";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBase;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnArm1;
        private System.Windows.Forms.Button btnArm2;
        private System.Windows.Forms.Button btnCloseGrip;
        private System.Windows.Forms.Button btnOpenGrip;
    }
}

