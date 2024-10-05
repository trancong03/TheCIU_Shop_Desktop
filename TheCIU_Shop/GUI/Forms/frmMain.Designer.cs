namespace TheCIU_Shop.GUI.Forms
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.menuItemUserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHR = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSalary = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUser = new System.Windows.Forms.ToolStripMenuItem(); // Người Dùng
            this.menuItemUserGroup = new System.Windows.Forms.ToolStripMenuItem(); // Nhóm Người Dùng
            this.menuItemAddUserToGroup = new System.Windows.Forms.ToolStripMenuItem(); // Thêm vào Nhóm Người Dùng
            this.menuItemRoleManagement = new System.Windows.Forms.ToolStripMenuItem(); // Phân Quyền

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.menuItemUserManagement,
        this.menuItemHR,
        this.menuItemAttendance,
        this.menuItemSalary});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemUserManagement
            // 
            this.menuItemUserManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.menuItemUser,
        this.menuItemUserGroup,
        this.menuItemAddUserToGroup,
        this.menuItemRoleManagement});
            this.menuItemUserManagement.Name = "menuItemUserManagement";
            this.menuItemUserManagement.Size = new System.Drawing.Size(125, 20);
            this.menuItemUserManagement.Text = "Quản lý người dùng";
            // 
            // menuItemHR
            // 
            this.menuItemHR.Name = "menuItemHR";
            this.menuItemHR.Size = new System.Drawing.Size(63, 20);
            this.menuItemHR.Text = "Nhân sự";
            // 
            // menuItemAttendance
            // 
            this.menuItemAttendance.Name = "menuItemAttendance";
            this.menuItemAttendance.Size = new System.Drawing.Size(81, 20);
            this.menuItemAttendance.Text = "Chấm công";
            // 
            // menuItemSalary
            // 
            this.menuItemSalary.Name = "menuItemSalary";
            this.menuItemSalary.Size = new System.Drawing.Size(76, 20);
            this.menuItemSalary.Text = "Tính lương";
            // 
            // menuItemUser
            // 
            this.menuItemUser.Name = "menuItemUser";
            this.menuItemUser.Size = new System.Drawing.Size(180, 22);
            this.menuItemUser.Text = "Người Dùng";
            this.menuItemUser.Click += new System.EventHandler(this.MenuItemUser_Click);

            // 
            // menuItemUserGroup
            // 
            this.menuItemUserGroup.Name = "menuItemUserGroup";
            this.menuItemUserGroup.Size = new System.Drawing.Size(180, 22);
            this.menuItemUserGroup.Text = "Nhóm Người Dùng";
            this.menuItemUserGroup.Click += new System.EventHandler(this.MenuItemUserGroup_Click);

            // 
            // menuItemAddUserToGroup
            // 
            this.menuItemAddUserToGroup.Name = "menuItemAddUserToGroup";
            this.menuItemAddUserToGroup.Size = new System.Drawing.Size(180, 22);
            this.menuItemAddUserToGroup.Text = "Thêm vào Nhóm";
            this.menuItemAddUserToGroup.Click += new System.EventHandler(this.MenuItemAddUserToGroup_Click);

            // 
            // menuItemRoleManagement
            // 
            this.menuItemRoleManagement.Name = "menuItemRoleManagement";
            this.menuItemRoleManagement.Size = new System.Drawing.Size(180, 22);
            this.menuItemRoleManagement.Text = "Phân Quyền";
            this.menuItemRoleManagement.Click += new System.EventHandler(this.MenuItemRoleManagement_Click);

            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemUserManagement;
        private System.Windows.Forms.ToolStripMenuItem menuItemHR;
        private System.Windows.Forms.ToolStripMenuItem menuItemAttendance;
        private System.Windows.Forms.ToolStripMenuItem menuItemSalary;
        private System.Windows.Forms.ToolStripMenuItem menuItemUser;  // Người Dùng
        private System.Windows.Forms.ToolStripMenuItem menuItemUserGroup;  // Nhóm Người Dùng
        private System.Windows.Forms.ToolStripMenuItem menuItemAddUserToGroup;  // Thêm vào Nhóm Người Dùng
        private System.Windows.Forms.ToolStripMenuItem menuItemRoleManagement;  // Phân Quyền
    }

}

