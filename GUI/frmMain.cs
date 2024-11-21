using System;
using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    public partial class FrmMain : Form
    {
        private string userRole;

        public string UserRole { get => userRole; set => userRole = value; }

        public FrmMain(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            leftContainerPanel.Width = 60;
            isCollapsed = true;

            MessageBox.Show($"Chào mừng, vai trò của bạn: {userRole}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ConfigureNavigationButtons();

            foreach (Control control in navigationPanel.Controls)
            {
                if (control is Button btn)
                {
                    btn.Text = ""; // Ẩn text
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                }
            }
        }


        private void ConfigureNavigationButtons()
        {
            // Quản lý sản phẩm
            if (userRole == "admin" || userRole == "employee")
            {
                btnManageProducts.Visible = true;
                ConfigureButton(btnManageProducts, "Quản lý Sản phẩm", Properties.Resources.product_icon);
            }
            else
            {
                btnManageProducts.Visible = false;
            }

            // Quản lý đơn hàng
            if (userRole == "admin")
            {
                btnManageOrders.Visible = true;
                ConfigureButton(btnManageOrders, "Quản lý Đơn hàng", Properties.Resources.order_icon);
            }
            else
            {
                btnManageOrders.Visible = false;
            }

            // Quản lý voucher
            if (userRole == "admin")
            {
                btnManageVouchers.Visible = true;
                ConfigureButton(btnManageVouchers, "Quản lý Voucher", Properties.Resources.voucher_icon);
            }
            else
            {
                btnManageVouchers.Visible = false;
            }

            // Thống kê và báo cáo
            if (userRole == "admin")
            {
                btnReports.Visible = true;
                ConfigureButton(btnReports, "Thống kê và Báo cáo", Properties.Resources.report_icon);
            }
            else
            {
                btnReports.Visible = false;
            }

            // Quản lý khách hàng
            if (userRole == "employee")
            {
                btnManageCustomers.Visible = true;
                ConfigureButton(btnManageCustomers, "Quản lý Khách hàng", Properties.Resources.customer_icon);
            }
            else
            {
                btnManageCustomers.Visible = false;
            }

            // Quản lý phản hồi (hiển thị cho tất cả vai trò)
            btnManageFeedback.Visible = true;
            ConfigureButton(btnManageFeedback, "Quản lý Phản hồi", Properties.Resources.feedback_icon);

            // Cài đặt (hiển thị cho tất cả vai trò)
            btnSettings.Visible = true;
            ConfigureButton(btnSettings, "Cài đặt", Properties.Resources.settings_icon);
        }



        private void ConfigureButton(Button button, string text, Image icon)
        {
            button.Dock = DockStyle.Top;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            button.Image = icon;
            button.Text = text;
            button.Tag = text;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.Padding = new Padding(0, 0, 0, 0);
            button.Size = new Size(229, 40);
            button.FlatAppearance.BorderSize = 0;
            button.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void BtnManageProducts_Click(object sender, EventArgs e)
        {
            TogglePanelChildren(new[]
            {
                new Tuple<string, EventHandler>("Quản lý danh mục", BtnManageCategories_Click),
                new Tuple<string, EventHandler>("Quản lý tồn kho", BtnStockManagement_Click),
                new Tuple<string, EventHandler>("Thông tin sản phẩm", BtnProductInfo_Click),
            });
        }


        private void BtnManageCategories_Click(object sender, EventArgs e)
        {
            // OpenFormInMainPanel(new FrmCategoryManagement());
            using (var categoryDialog = new FrmCategoryDialog())
            {
               categoryDialog.ShowDialog();
            }
        }

        private void BtnManageCustomers_Click(object sender, EventArgs e)
        {
            TogglePanelChildren(new[]
            {
                new Tuple<string, EventHandler>("Thông tin khách hàng", BtnCustomerInfo_Click),
                new Tuple<string, EventHandler>("Lịch sử mua hàng", BtnPurchaseHistory_Click)
            });
        }

        private void BtnManageOrders_Click(object sender, EventArgs e)
        {
            TogglePanelChildren(new[]
            {
                new Tuple<string, EventHandler>("Cập nhật trạng thái đơn hàng", BtnUpdateOrderStatus_Click),
                new Tuple<string, EventHandler>("Xử lý hoàn trả", BtnHandleReturn_Click)
            });
        }

        private void BtnManageVouchers_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new FrmVoucherManagement());
        }

        private void BtnManageFeedback_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new FrmFeedbackManagement());
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new FrmReports());
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            TogglePanelChildren(new[]
            {
                new Tuple<string, EventHandler>("Đăng xuất", BtnLogout_Click),
                new Tuple<string, EventHandler>("Cài đặt chung", BtnGeneralSettings_Click)
            });
        }

        private void TogglePanelChildren(Tuple<string, EventHandler>[] children)
        {
            panelChildren.Controls.Clear();

            foreach (var child in children)
            {
                Button childButton = new Button { Text = child.Item1, Dock = DockStyle.Top, Size = new Size(229, 40) };
                childButton.Click += child.Item2;
                panelChildren.Controls.Add(childButton);
            }

            panelChildren.Visible = !panelChildren.Visible;
            panelChildren.BringToFront();
        }

        private void OpenFormInMainPanel(Form form)
        {
            mainPanel.Controls.Clear();
            form.TopLevel = false;
            mainPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void BtnProductInfo_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmProductManagement());
        private void BtnStockManagement_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmStockManagement());
        private void BtnCustomerInfo_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmCustomerInfo());
        private void BtnPurchaseHistory_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmPurchaseHistory ());
        private void BtnUpdateOrderStatus_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmOrderStatusUpdate());
        private void BtnHandleReturn_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmLogin());
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận trước khi logout
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại
                this.Hide();

                // Mở lại form Login
                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();

                // Đóng hoàn toàn ứng dụng khi Login Form bị tắt
                loginForm.FormClosed += (s, args) => this.Close();
            }
        }

        private void BtnGeneralSettings_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmAccountManagement());

        private void btnToggle_Click(object sender, EventArgs e) 
            => timer.Start();

        private void timer_Tick(object sender, EventArgs e)
        {
            int step = 30; // Tăng bước thay đổi để tăng tốc độ
            if (isCollapsed)
            {
                leftContainerPanel.Width += step;
                if (leftContainerPanel.Width >= 229)
                {
                    timer.Stop();
                    isCollapsed = false;
                    UpdateNavigationButtonsText(isCollapsed);
                }
            }
            else
            {
                leftContainerPanel.Width -= step;
                if (leftContainerPanel.Width <= 60)
                {
                    timer.Stop();
                    isCollapsed = true;
                    UpdateNavigationButtonsText(isCollapsed);
                }
            }
        }

        // Cập nhật text của các nút điều hướng
        private void UpdateNavigationButtonsText(bool isCollapsed)
        {
            foreach (Control control in navigationPanel.Controls)
            {
                if (control is Button btn)
                {
                    if (isCollapsed)
                    {
                        btn.Text = "";
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                        btn.ImageAlign = ContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        btn.Text = btn.Tag?.ToString();
                        btn.TextAlign = ContentAlignment.MiddleLeft;
                        btn.ImageAlign = ContentAlignment.MiddleLeft;
                    }
                }
            }
        }

        // Bật DoubleBuffered để giảm nhấp nháy
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EnableDoubleBuffering(leftContainerPanel);
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null,
                control,
                new object[] { true });
        }

    }
}
