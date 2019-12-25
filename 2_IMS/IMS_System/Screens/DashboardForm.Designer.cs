using System;

namespace IMS_System.Screens
{
    partial class DashboardForm 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.cmdDefine = new System.Windows.Forms.Button();
            this.cmdManage = new System.Windows.Forms.Button();
            this.cmdStock = new System.Windows.Forms.Button();
            this.cmdCategories = new System.Windows.Forms.Button();
            this.cmdCustomers = new System.Windows.Forms.Button();
            this.cmdNewSalesOrder = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdCustomReports = new System.Windows.Forms.Button();
            this.cmdChangePassword = new System.Windows.Forms.Button();
            this.cmdOrdersRecord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdDefine
            // 
            this.cmdDefine.BackColor = System.Drawing.Color.White;
            this.cmdDefine.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDefine.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cmdDefine.Image = ((System.Drawing.Image)(resources.GetObject("cmdDefine.Image")));
            this.cmdDefine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDefine.Location = new System.Drawing.Point(42, 63);
            this.cmdDefine.Name = "cmdDefine";
            this.cmdDefine.Size = new System.Drawing.Size(201, 126);
            this.cmdDefine.TabIndex = 0;
            this.cmdDefine.Text = "Define Products";
            this.cmdDefine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdDefine.UseVisualStyleBackColor = false;
            this.cmdDefine.Click += new System.EventHandler(this.cmdDefine_Click);
            // 
            // cmdManage
            // 
            this.cmdManage.BackColor = System.Drawing.Color.White;
            this.cmdManage.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdManage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cmdManage.Image = ((System.Drawing.Image)(resources.GetObject("cmdManage.Image")));
            this.cmdManage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdManage.Location = new System.Drawing.Point(268, 63);
            this.cmdManage.Name = "cmdManage";
            this.cmdManage.Size = new System.Drawing.Size(201, 126);
            this.cmdManage.TabIndex = 1;
            this.cmdManage.Text = "Manage Products";
            this.cmdManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdManage.UseVisualStyleBackColor = false;
            // 
            // cmdStock
            // 
            this.cmdStock.BackColor = System.Drawing.Color.White;
            this.cmdStock.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStock.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmdStock.Image = ((System.Drawing.Image)(resources.GetObject("cmdStock.Image")));
            this.cmdStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdStock.Location = new System.Drawing.Point(42, 206);
            this.cmdStock.Name = "cmdStock";
            this.cmdStock.Size = new System.Drawing.Size(201, 116);
            this.cmdStock.TabIndex = 2;
            this.cmdStock.Text = "Stock Management";
            this.cmdStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdStock.UseVisualStyleBackColor = false;
            // 
            // cmdCategories
            // 
            this.cmdCategories.BackColor = System.Drawing.Color.White;
            this.cmdCategories.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCategories.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmdCategories.Image = ((System.Drawing.Image)(resources.GetObject("cmdCategories.Image")));
            this.cmdCategories.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCategories.Location = new System.Drawing.Point(268, 206);
            this.cmdCategories.Name = "cmdCategories";
            this.cmdCategories.Size = new System.Drawing.Size(201, 116);
            this.cmdCategories.TabIndex = 3;
            this.cmdCategories.Text = "Manage Categories";
            this.cmdCategories.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCategories.UseVisualStyleBackColor = false;
            // 
            // cmdCustomers
            // 
            this.cmdCustomers.BackColor = System.Drawing.Color.White;
            this.cmdCustomers.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCustomers.Image = ((System.Drawing.Image)(resources.GetObject("cmdCustomers.Image")));
            this.cmdCustomers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCustomers.Location = new System.Drawing.Point(42, 328);
            this.cmdCustomers.Name = "cmdCustomers";
            this.cmdCustomers.Size = new System.Drawing.Size(427, 130);
            this.cmdCustomers.TabIndex = 4;
            this.cmdCustomers.Text = "Customer Management";
            this.cmdCustomers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCustomers.UseVisualStyleBackColor = false;
            // 
            // cmdNewSalesOrder
            // 
            this.cmdNewSalesOrder.BackColor = System.Drawing.Color.White;
            this.cmdNewSalesOrder.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewSalesOrder.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewSalesOrder.Image")));
            this.cmdNewSalesOrder.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.cmdNewSalesOrder.Location = new System.Drawing.Point(517, 63);
            this.cmdNewSalesOrder.Name = "cmdNewSalesOrder";
            this.cmdNewSalesOrder.Size = new System.Drawing.Size(386, 126);
            this.cmdNewSalesOrder.TabIndex = 5;
            this.cmdNewSalesOrder.Text = "Add New Sales Order";
            this.cmdNewSalesOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNewSalesOrder.UseVisualStyleBackColor = false;
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.White;
            this.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdExit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExit.Location = new System.Drawing.Point(719, 342);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(184, 116);
            this.cmdExit.TabIndex = 9;
            this.cmdExit.Text = "Exit Application";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdCustomReports
            // 
            this.cmdCustomReports.BackColor = System.Drawing.Color.White;
            this.cmdCustomReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdCustomReports.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCustomReports.Image = ((System.Drawing.Image)(resources.GetObject("cmdCustomReports.Image")));
            this.cmdCustomReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCustomReports.Location = new System.Drawing.Point(517, 342);
            this.cmdCustomReports.Name = "cmdCustomReports";
            this.cmdCustomReports.Size = new System.Drawing.Size(180, 116);
            this.cmdCustomReports.TabIndex = 8;
            this.cmdCustomReports.Text = "Custom Reports";
            this.cmdCustomReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCustomReports.UseVisualStyleBackColor = false;
            // 
            // cmdChangePassword
            // 
            this.cmdChangePassword.BackColor = System.Drawing.Color.White;
            this.cmdChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdChangePassword.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("cmdChangePassword.Image")));
            this.cmdChangePassword.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdChangePassword.Location = new System.Drawing.Point(719, 206);
            this.cmdChangePassword.Name = "cmdChangePassword";
            this.cmdChangePassword.Size = new System.Drawing.Size(184, 130);
            this.cmdChangePassword.TabIndex = 7;
            this.cmdChangePassword.Text = "Change Password";
            this.cmdChangePassword.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdChangePassword.UseVisualStyleBackColor = false;
            // 
            // cmdOrdersRecord
            // 
            this.cmdOrdersRecord.BackColor = System.Drawing.Color.White;
            this.cmdOrdersRecord.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOrdersRecord.Image = ((System.Drawing.Image)(resources.GetObject("cmdOrdersRecord.Image")));
            this.cmdOrdersRecord.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdOrdersRecord.Location = new System.Drawing.Point(517, 206);
            this.cmdOrdersRecord.Name = "cmdOrdersRecord";
            this.cmdOrdersRecord.Size = new System.Drawing.Size(180, 130);
            this.cmdOrdersRecord.TabIndex = 6;
            this.cmdOrdersRecord.Text = "Orders Record";
            this.cmdOrdersRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdOrdersRecord.UseVisualStyleBackColor = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 504);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdCustomReports);
            this.Controls.Add(this.cmdChangePassword);
            this.Controls.Add(this.cmdOrdersRecord);
            this.Controls.Add(this.cmdNewSalesOrder);
            this.Controls.Add(this.cmdCustomers);
            this.Controls.Add(this.cmdCategories);
            this.Controls.Add(this.cmdStock);
            this.Controls.Add(this.cmdManage);
            this.Controls.Add(this.cmdDefine);
            this.Name = "DashboardForm";
            this.Text = "Main Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button cmdDefine;
        private System.Windows.Forms.Button cmdManage;
        private System.Windows.Forms.Button cmdStock;
        private System.Windows.Forms.Button cmdCategories;
        private System.Windows.Forms.Button cmdCustomers;
        private System.Windows.Forms.Button cmdNewSalesOrder;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdCustomReports;
        private System.Windows.Forms.Button cmdChangePassword;
        private System.Windows.Forms.Button cmdOrdersRecord;
    }
}