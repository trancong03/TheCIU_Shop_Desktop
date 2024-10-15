using System.Windows.Forms;

namespace GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem taskToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem accountManagementToolStripMenuItem;  // Quản lý tài khoản

        // Các mục trong menu Tác vụ
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
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voucherManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productManagementToolStripMenuItem,
            this.categoryManagementToolStripMenuItem,
            this.orderManagementToolStripMenuItem,
            this.feedbackManagementToolStripMenuItem,
            this.voucherManagementToolStripMenuItem});
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.taskToolStripMenuItem.Text = "Tác vụ";
            // 
            // productManagementToolStripMenuItem
            // 
            this.productManagementToolStripMenuItem.Name = "productManagementToolStripMenuItem";
            this.productManagementToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.productManagementToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.productManagementToolStripMenuItem.Click += new System.EventHandler(this.productManagementToolStripMenuItem_Click);
            // 
            // categoryManagementToolStripMenuItem
            // 
            this.categoryManagementToolStripMenuItem.Name = "categoryManagementToolStripMenuItem";
            this.categoryManagementToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.categoryManagementToolStripMenuItem.Text = "Quản lý danh mục";
            this.categoryManagementToolStripMenuItem.Click += new System.EventHandler(this.categoryManagementToolStripMenuItem_Click);
            // 
            // orderManagementToolStripMenuItem
            // 
            this.orderManagementToolStripMenuItem.Name = "orderManagementToolStripMenuItem";
            this.orderManagementToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.orderManagementToolStripMenuItem.Text = "Quản lý đơn hàng";
            this.orderManagementToolStripMenuItem.Click += new System.EventHandler(this.orderManagementToolStripMenuItem_Click);
            // 
            // feedbackManagementToolStripMenuItem
            // 
            this.feedbackManagementToolStripMenuItem.Name = "feedbackManagementToolStripMenuItem";
            this.feedbackManagementToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.feedbackManagementToolStripMenuItem.Text = "Quản lý phản hồi";
            this.feedbackManagementToolStripMenuItem.Click += new System.EventHandler(this.feedbackManagementToolStripMenuItem_Click);
            // 
            // voucherManagementToolStripMenuItem
            // 
            this.voucherManagementToolStripMenuItem.Name = "voucherManagementToolStripMenuItem";
            this.voucherManagementToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.voucherManagementToolStripMenuItem.Text = "Quản lý voucher";
            this.voucherManagementToolStripMenuItem.Click += new System.EventHandler(this.voucherManagementToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountManagementToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountToolStripMenuItem.Text = "Tài khoản";
            // 
            // accountManagementToolStripMenuItem
            // 
            this.accountManagementToolStripMenuItem.Name = "accountManagementToolStripMenuItem";
            this.accountManagementToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.accountManagementToolStripMenuItem.Text = "Quản lý tài khoản";
            this.accountManagementToolStripMenuItem.Click += new System.EventHandler(this.accountManagementToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.logoutToolStripMenuItem.Text = "Đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 681);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Trang quản lý";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
