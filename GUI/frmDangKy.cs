using BLL;
using System;
using System.Windows.Forms;
using Validation;
namespace GUI
{
    public partial class frmDangKy : Form
    {

        public frmDangKy()
        {
            InitializeComponent();

            registerControl1.RegisterClicked += RegisterControl_RegisterClicked;
            registerControl1.CancelClicked += RegisterControl_CancelClicked;
        }

        private void RegisterControl_RegisterClicked(object sender, EventArgs e)
        {
            // Lấy thông tin từ RegisterControl
            string username = registerControl1.Username;
            string name = registerControl1.Name;
            string password = registerControl1.Password;
            string email = registerControl1.Email;
            string phone = registerControl1.Phone;
            string address = registerControl1.Address;
            string gender = registerControl1.Gender;
            string avatarPath = registerControl1.AvatarPath;
            string backgroundPath = registerControl1.BackgroundPath;

            try
            {
                AccountBLL accountBLL = new AccountBLL();
                accountBLL.RegisterNewAccount(username, name, password, email, phone, address, gender, avatarPath, backgroundPath);

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterControl_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}
