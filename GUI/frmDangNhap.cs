using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            loginControl.LoginClicked += LoginControl_LoginClicked;
        }

        private void LoginControl_LoginClicked(object sender, EventArgs e)
        {
            string username = loginControl.Username;
            string password = loginControl.Password;

            if (ValidateLogin(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private bool ValidateLogin(string username, string password)
        {
            AccountBLL accountBLL = new AccountBLL();
            return accountBLL.CheckLogin(username, password);
        }
    }
}
