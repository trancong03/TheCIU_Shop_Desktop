using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel leftContainerPanel;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel mainPanel;
        private Panel panelChildren; // Panel chứa các nút con cho chức năng cha được chọn

        // Các nút chức năng cha
        private Button btnManageProducts;
        //private Button btnManageCategories;
        private Button btnManageCustomers;
        private Button btnManageOrders;
        private Button btnManageVouchers;
        private Button btnManageFeedback;
        private Button btnReports;
        private Button btnSettings;

        // Biến xác định trạng thái thu gọn/mở rộng
        private bool isCollapsed = true;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftContainerPanel = new System.Windows.Forms.Panel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.btnToggle = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelChildren = new Panel(); // Panel chứa nút con

            this.leftContainerPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // leftContainerPanel
            // 
            this.leftContainerPanel.BackColor = Color.FromArgb(166, 174, 191); // Màu nền mới của navigationPanel
            this.leftContainerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftContainerPanel.Width = 60; // Bắt đầu ở trạng thái thu gọn
            this.leftContainerPanel.Controls.Add(this.navigationPanel);
            this.leftContainerPanel.Controls.Add(this.btnToggle);

            // 
            // btnToggle
            // 
            this.btnToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnToggle.Image = global::GUI.Properties.Resources.menu_icon;
            this.btnToggle.ImageAlign = ContentAlignment.MiddleCenter;
            this.btnToggle.Size = new System.Drawing.Size(60, 40);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);

            // 
            // navigationPanel
            // 
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.BackColor = Color.FromArgb(166, 174, 191); // Màu nền mới của navigationPanel
            this.navigationPanel.Location = new System.Drawing.Point(0, 40);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(229, 410);
            this.navigationPanel.TabIndex = 1;

            // Khởi tạo các nút điều hướng và panel con
            InitializeNavigationButtons();

            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(229, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(685, 450);
            this.mainPanel.TabIndex = 0;

            // 
            // panelChildren
            // 
            this.panelChildren.BackColor = Color.FromArgb(197, 211, 232); // Màu nền mới của panelChildren
            this.panelChildren.Dock = DockStyle.Left; // Đặt Dock cho panelChildren
            this.panelChildren.Size = new Size(229, 450); // Chiều rộng và chiều cao giống với navigationPanel
            this.panelChildren.Visible = false;
            this.panelChildren.BringToFront();

            // Thêm panelChildren vào form
            this.Controls.Add(panelChildren);

            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.leftContainerPanel);
            this.Name = "frmMain";
            this.Text = "Quản lý cửa hàng TheCIU";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.leftContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void InitializeNavigationButtons()
        { 
            btnSettings = new Button { Text = "Cài đặt", Dock = DockStyle.Top };
            btnSettings.Click += BtnSettings_Click;
            navigationPanel.Controls.Add(btnSettings);

            btnReports = new Button { Text = "Thống kê và Báo cáo", Dock = DockStyle.Top };
            btnReports.Click += BtnReports_Click;
            navigationPanel.Controls.Add(btnReports);

            btnManageCustomers = new Button { Text = "Quản lý Khách hàng", Dock = DockStyle.Top };
            btnManageCustomers.Click += BtnManageCustomers_Click;
            navigationPanel.Controls.Add(btnManageCustomers);


            btnManageVouchers = new Button { Text = "Quản lý Voucher", Dock = DockStyle.Top };
            btnManageVouchers.Click += BtnManageVouchers_Click;
            navigationPanel.Controls.Add(btnManageVouchers);

            btnManageFeedback = new Button { Text = "Quản lý Phản hồi", Dock = DockStyle.Top };
            btnManageFeedback.Click += BtnManageFeedback_Click;
            navigationPanel.Controls.Add(btnManageFeedback);
            btnManageOrders = new Button { Text = "Quản lý Đơn hàng", Dock = DockStyle.Top };
            btnManageOrders.Click += BtnManageOrders_Click;
            navigationPanel.Controls.Add(btnManageOrders);

            btnManageProducts = new Button { Text = "Quản lý Sản phẩm", Dock = DockStyle.Top };
            btnManageProducts.Click += BtnManageProducts_Click;
            navigationPanel.Controls.Add(btnManageProducts);
        }


        #endregion
    }
}
