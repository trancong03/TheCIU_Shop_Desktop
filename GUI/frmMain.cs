using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        private string loggedInUsername;

        public frmMain(string username)
        {
            InitializeComponent();
            loggedInUsername = username;

            this.Text = $"Trang quản lý - Người dùng: {loggedInUsername}";
        }

        private void accountManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountManagement accountForm = new frmAccountManagement();
            accountForm.MdiParent = this;
            accountForm.Show();
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductManagement productForm = new frmProductManagement();
            productForm.MdiParent = this;
            productForm.Show();
        }

        private void categoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCategoryManagement categoryForm = new frmCategoryManagement();
            //categoryForm.MdiParent = this;
            //categoryForm.Show();
        }

        private void orderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmOrderManagement orderForm = new frmOrderManagement();
            //orderForm.MdiParent = this;
            //orderForm.Show();
        }

        private void feedbackManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmFeedbackManagement feedbackForm = new frmFeedbackManagement();
            //feedbackForm.MdiParent = this;
            //feedbackForm.Show();
        }

        private void voucherManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmVoucherManagement voucherForm = new frmVoucherManagement();
            //voucherForm.MdiParent = this;
            //voucherForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap loginForm = new frmDangNhap();
            loginForm.Show();
            this.Close(); // Đóng frmMain khi đăng xuất
        }
    }
}
