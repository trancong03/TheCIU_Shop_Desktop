using System;
using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            leftContainerPanel.Width = 60;
            isCollapsed = true;

            // Thiết lập các nút điều hướng
            ConfigureNavigationButtons();

            // Ẩn text trên các nút điều hướng khi thu gọn
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
            ConfigureButton(btnManageProducts, "Quản lý Sản phẩm", Properties.Resources.product_icon);
            ConfigureButton(btnManageCategories, "Quản lý Danh mục", Properties.Resources.category_icon);
            ConfigureButton(btnManageCustomers, "Quản lý Khách hàng", Properties.Resources.customer_icon);
            ConfigureButton(btnManageOrders, "Quản lý Đơn hàng", Properties.Resources.order_icon);
            ConfigureButton(btnManageVouchers, "Quản lý Voucher", Properties.Resources.voucher_icon);
            ConfigureButton(btnManageFeedback, "Quản lý Phản hồi", Properties.Resources.feedback_icon);
            ConfigureButton(btnReports, "Thống kê và Báo cáo", Properties.Resources.report_icon);
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
                new Tuple<string, EventHandler>("Thông tin sản phẩm", BtnProductInfo_Click),
                new Tuple<string, EventHandler>("Quản lý tồn kho", BtnStockManagement_Click)
            });
        }

        private void BtnManageCategories_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new FrmCategoryManagement());
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
            => OpenFormInMainPanel(new frmProductManagement());
        private void BtnStockManagement_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmStockManagement());
        private void BtnCustomerInfo_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmCustomerInfo());
        private void BtnPurchaseHistory_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmPurchaseHistory ());
        private void BtnUpdateOrderStatus_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new FrmOrderStatusUpdate());
        private void BtnHandleReturn_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new frmLogin());
        private void BtnLogout_Click(object sender, EventArgs e) 
            => MessageBox.Show("Đã đăng xuất!", "Thông báo", MessageBoxButtons.OK);
        private void BtnGeneralSettings_Click(object sender, EventArgs e) 
            => OpenFormInMainPanel(new frmAccountManagement());

        private void btnToggle_Click(object sender, EventArgs e) 
            => timer.Start();
        private void timer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                leftContainerPanel.Width += 10;
                if (leftContainerPanel.Width >= 229)
                {
                    timer.Stop();
                    isCollapsed = false;
                    foreach (Control control in navigationPanel.Controls)
                    {
                        if (control is Button btn)
                        {
                            btn.Text = btn.Tag?.ToString();
                            btn.TextAlign = ContentAlignment.MiddleLeft;
                            btn.ImageAlign = ContentAlignment.MiddleLeft;
                        }
                    }
                }
            }
            else
            {
                leftContainerPanel.Width -= 10;
                if (leftContainerPanel.Width <= 60)
                {
                    timer.Stop();
                    isCollapsed = true;
                    foreach (Control control in navigationPanel.Controls)
                    {
                        if (control is Button btn)
                        {
                            btn.Text = "";
                            btn.TextAlign = ContentAlignment.MiddleCenter;
                            btn.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                }
            }
        }
    }
}
