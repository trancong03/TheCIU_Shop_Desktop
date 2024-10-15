using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            loginControl.LoginClicked += LoginControl_LoginClicked; // Đăng ký sự kiện khi nhấn vào nút Đăng nhập
            loginControl.RegisterClicked += LoginControl_RegisterClicked;
        }

        private void LoginControl_RegisterClicked(object sender, EventArgs e)
        {
            frmDangKy frm = new frmDangKy();
            frm.Show();
            this.Hide();
        }

        private void LoginControl_LoginClicked(object sender, EventArgs e)
        {
            string username = loginControl.Username; 
            string password = loginControl.Password;  


            AccountBLL accountBLL = new AccountBLL();
            var account = accountBLL.CheckLogin(username, password); 

            if (account != null) 
            {
                if (account.status == 1) 
                {
                    frmMain frm = new frmMain(username); 
                    frm.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Tài khoản của bạn đã bị ngưng hoạt động. Vui lòng liên hệ quản trị viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        private bool ValidateLogin(string username, string password)
        {
            AccountBLL accountBLL = new AccountBLL();
            var account = accountBLL.CheckLogin(username, password);

            return account != null && account.status == 1;
        }
    }
}
