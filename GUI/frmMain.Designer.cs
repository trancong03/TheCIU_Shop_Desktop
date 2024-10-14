using System.Windows.Forms;

namespace GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem accountManagementToolStripMenuItem;
        private ToolStripMenuItem productManagementToolStripMenuItem;
        private ToolStripMenuItem categoryManagementToolStripMenuItem;
        private ToolStripMenuItem orderManagementToolStripMenuItem;
        private ToolStripMenuItem feedbackManagementToolStripMenuItem;
        private ToolStripMenuItem voucherManagementToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voucherManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountManagementToolStripMenuItem,
            this.productManagementToolStripMenuItem,
            this.categoryManagementToolStripMenuItem,
            this.orderManagementToolStripMenuItem,
            this.feedbackManagementToolStripMenuItem,
            this.voucherManagementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
<<<<<<< HEAD
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
=======
            this.menuStrip1.Size = new System.Drawing.Size(1041, 24);
>>>>>>> Huy
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountManagementToolStripMenuItem
            // 
            this.accountManagementToolStripMenuItem.Name = "accountManagementToolStripMenuItem";
<<<<<<< HEAD
            this.accountManagementToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
=======
            this.accountManagementToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
>>>>>>> Huy
            this.accountManagementToolStripMenuItem.Text = "Quản lý tài khoản";
            this.accountManagementToolStripMenuItem.Click += new System.EventHandler(this.accountManagementToolStripMenuItem_Click);
            // 
            // productManagementToolStripMenuItem
            // 
            this.productManagementToolStripMenuItem.Name = "productManagementToolStripMenuItem";
<<<<<<< HEAD
            this.productManagementToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
=======
            this.productManagementToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
>>>>>>> Huy
            this.productManagementToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.productManagementToolStripMenuItem.Click += new System.EventHandler(this.productManagementToolStripMenuItem_Click);
            // 
            // categoryManagementToolStripMenuItem
            // 
            this.categoryManagementToolStripMenuItem.Name = "categoryManagementToolStripMenuItem";
<<<<<<< HEAD
            this.categoryManagementToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
=======
            this.categoryManagementToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
>>>>>>> Huy
            this.categoryManagementToolStripMenuItem.Text = "Quản lý danh mục";
            this.categoryManagementToolStripMenuItem.Click += new System.EventHandler(this.categoryManagementToolStripMenuItem_Click);
            // 
            // orderManagementToolStripMenuItem
            // 
            this.orderManagementToolStripMenuItem.Name = "orderManagementToolStripMenuItem";
<<<<<<< HEAD
            this.orderManagementToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
=======
            this.orderManagementToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
>>>>>>> Huy
            this.orderManagementToolStripMenuItem.Text = "Quản lý đơn hàng";
            this.orderManagementToolStripMenuItem.Click += new System.EventHandler(this.orderManagementToolStripMenuItem_Click);
            // 
            // feedbackManagementToolStripMenuItem
            // 
            this.feedbackManagementToolStripMenuItem.Name = "feedbackManagementToolStripMenuItem";
<<<<<<< HEAD
            this.feedbackManagementToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
=======
            this.feedbackManagementToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
>>>>>>> Huy
            this.feedbackManagementToolStripMenuItem.Text = "Quản lý phản hồi";
            this.feedbackManagementToolStripMenuItem.Click += new System.EventHandler(this.feedbackManagementToolStripMenuItem_Click);
            // 
            // voucherManagementToolStripMenuItem
            // 
            this.voucherManagementToolStripMenuItem.Name = "voucherManagementToolStripMenuItem";
<<<<<<< HEAD
            this.voucherManagementToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
=======
            this.voucherManagementToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
>>>>>>> Huy
            this.voucherManagementToolStripMenuItem.Text = "Quản lý voucher";
            this.voucherManagementToolStripMenuItem.Click += new System.EventHandler(this.voucherManagementToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(800, 450);
=======
            this.ClientSize = new System.Drawing.Size(1041, 450);
>>>>>>> Huy
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Trang quản lý";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
<<<<<<< HEAD
=======

>>>>>>> Huy
        }
    }
}
