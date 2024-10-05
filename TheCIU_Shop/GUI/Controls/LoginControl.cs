using System;
using System.Linq;
using System.Windows.Forms;
using TheCIU_Shop.Data.Context;
using TheCIU_Shop.GUI.Forms;
using CustomTextBox;

namespace TheCIU_Shop.GUI.Controls {
    public partial class LoginControl : UserControl
    {
        // Tạo các điều khiển cho tên đăng nhập và mật khẩu.
        public txtUsername UsernameControl { get; set; }
        public txtPassword PasswordControl { get; set; }

        public LoginControl()
        {
            InitializeComponent();

            // Thiết lập giao diện của LoginControl.
            SetupLoginControl();
        }

        private void SetupLoginControl()
        {
            // Tạo và thêm điều khiển txtUsername.
            UsernameControl = new txtUsername();
            UsernameControl.Location = new System.Drawing.Point(50, 50);
            UsernameControl.Width = 250;
            this.Controls.Add(UsernameControl);

            // Tạo và thêm điều khiển txtPassword.
            PasswordControl = new txtPassword();
            PasswordControl.Location = new System.Drawing.Point(50, 100);
            PasswordControl.Width = 250;
            this.Controls.Add(PasswordControl);

            // Tạo nút Đăng Nhập.
            Button btnLogin = new Button();
            btnLogin.Text = "Đăng Nhập";
            btnLogin.Location = new System.Drawing.Point(50, 150);
            btnLogin.Width = 250;
            btnLogin.Click += BtnLogin_Click; // Gán sự kiện Click cho nút
            this.Controls.Add(btnLogin);
        }

        // Sự kiện xử lý khi nhấn nút đăng nhập
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = UsernameControl.Text;
            string password = PasswordControl.Text;

            
        }
    }
}

