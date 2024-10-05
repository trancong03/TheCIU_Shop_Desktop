using System;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class LoginControl : UserControl
    {

        public LoginControl()
        {
            InitializeComponent();
        }

        // Phương thức nhận UserRepository từ form chính
       

        // Sự kiện xử lý khi nhấn nút đăng nhập
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername1.Text;
            string password = txtPassword1.Text;

            // Kiểm tra đăng nhập qua UserRepository
            //bool isValidUser = _userRepository.ValidateUser(username, password);

            //if (isValidUser)
            //{
            //    MessageBox.Show("Đăng nhập thành công!");
            //    // Thực hiện các hành động sau khi đăng nhập thành công (chuyển form, đóng form hiện tại, v.v.)
            //}
            //else
            //{
            //    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            //}
        }
    }
}
