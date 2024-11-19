using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        readonly AccountBLL accountBLL = new AccountBLL();
        public frmLogin()
        {
            InitializeComponent();
            loginControl.LoginClicked += LoginControl_LoginClicked;
        }

        private void LoginControl_LoginClicked(object sender, EventArgs e)
        {
            var username = loginControl.Username;
            var password = loginControl.Password;

            var accountBLL = new AccountBLL();
            var user = accountBLL.Authenticate(username, password);

            if (user != null)
            {
               
                if (user.status == 1) 
                {
                    MessageBox.Show($"Đăng nhập thành công! Vai trò: {user.name}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var mainForm = new frmMain(user.name); 
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
