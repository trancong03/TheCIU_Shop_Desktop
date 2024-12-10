using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmLogin : Form
    {
        readonly AccountBLL accountBLL = new AccountBLL();
        public FrmLogin()
        {
            InitializeComponent();
            loginControl.LoginClicked += LoginControl_LoginClicked;
        }

        private void LoginControl_LoginClicked(object sender, EventArgs e)
        {
            var username = loginControl.Username;
            var password = loginControl.Password;

            var account = accountBLL.Authenticate(username, password);

            if (account != null)
            {
                if (account.status == 1) // Tài khoản active
                {
                    this.Hide();
                    FrmMain mainForm = new FrmMain(username); // Truyền username vào FrmMain
                    mainForm.Show();
                    mainForm.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản không hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
