using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        // Sự kiện đăng nhập, để form chính bắt sự kiện này và xử lý logic đăng nhập
        public event EventHandler LoginClicked;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.Text = "Hide Password"; 
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.Text = "Show Password"; 
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Thoát ứng dụng
            Application.Exit();
        }

        // Properties để lấy giá trị từ các textbox
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
    }
}