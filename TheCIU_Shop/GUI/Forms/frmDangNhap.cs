using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheCIU_Shop.GUI.Forms;
using TheCIU_Shop.Data.Context;
using TheCIU_Shop.Data.Repository;

namespace TheCIU_Shop.GUI.Forms
{
    public partial class frmDangNhap : Form
    {
   
        private UserRepository _userRepository = new UserRepository();

        public frmDangNhap()
        {
            InitializeComponent();
            loginControl.LoginClicked += LoginControl_LoginClicked;

            
        }

        private void LoginControl_LoginClicked(object sender, EventArgs e)
        {
            string username = loginControl.UserName;
            string password = loginControl.Password;

            if(_userRepository.ValidateUser (username, password))
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

    }
}
