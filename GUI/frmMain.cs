using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

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
            var buttonConfigurations = new Dictionary<Button, (string text, Image icon, string[] roles)>
            {
                { btnManageProducts, ("Manage Products", Properties.Resources.product_icon, new[] { "admin", "employee" }) },
                { btnManageOrders, ("Manage Orders", Properties.Resources.order_icon, new[] { "admin" }) },
                { btnManageVouchers, ("Manage Vouchers", Properties.Resources.voucher_icon, new[] { "admin" }) },
                { btnReports, ("Reports", Properties.Resources.report_icon, new[] { "admin" }) },
                { btnManageCustomers, ("Manage Customers", Properties.Resources.customer_icon, new[] { "employee" }) },
                { btnManageFeedback, ("Manage Feedback", Properties.Resources.feedback_icon, new[] { "admin", "employee" }) },
                { btnSettings, ("Settings", Properties.Resources.settings_icon, new[] { "admin", "employee" }) }
            };

            foreach (var config in buttonConfigurations)
            {
                ConfigureButtonVisibility(config.Key, config.Value.text, config.Value.icon, config.Value.roles);
            }
        }

        private void ConfigureButtonVisibility(Button button, string text, Image icon, string[] roles)
        {
            if (roles.Contains(userRole))
            {
                button.Visible = true;
                ConfigureButton(button, text, icon);
            }
            else
            {
                button.Visible = false;
            }
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
                new Tuple<string, EventHandler>("Thông tin/ Tra cứu đơn hàng", BtnOrderManagement_Click)
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
            OpenFormInMainPanel(new FrmReport());
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
            => OpenFormInMainPanel(new FrmPurchaseHistory());
        private void BtnUpdateOrderStatus_Click(object sender, EventArgs e)
            => OpenFormInMainPanel(new FrmOrderStatusUpdate());
        private void BtnOrderManagement_Click(object sender, EventArgs e)
            => OpenFormInMainPanel(new FrmOrderManagement());
        private void BtnHandleReturn_Click(object sender, EventArgs e)
            => OpenFormInMainPanel(new FrmLogin());
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();
                loginForm.FormClosed += (s, args) => this.Close();
            }
        }

        private void BtnGeneralSettings_Click(object sender, EventArgs e)
            => OpenFormInMainPanel(new FrmAccountManagement());

        private void btnToggle_Click(object sender, EventArgs e)
            => timer.Start();

        private void timer_Tick(object sender, EventArgs e)
        {
            int step = 30;
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