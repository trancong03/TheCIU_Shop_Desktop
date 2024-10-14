using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmAccountManagement : Form
    {
        private AccountBLL accountBLL = new AccountBLL();

        public frmAccountManagement()
        {
            InitializeComponent();
            LoadAccounts(); // Load dữ liệu tài khoản khi mở form

            // Đăng ký sự kiện cho ActionControl
            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.SearchClicked += ActionControl_SearchClicked;
        }

        private void LoadAccounts()
        {
            dataGridViewAccounts.DataSource = accountBLL.GetAllAccounts(); // Lấy tất cả tài khoản từ BLL
        }

        // Xử lý sự kiện Thêm từ ActionControl
        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            try
            {
                Account account = new Account
                {
                    username = txtUsername.Text,
                    name = txtName.Text,
                    password = txtPassword.Text,
                    email = txtEmail.Text,
                    phone = txtPhone.Text,
                    address = txtAddress.Text,
                    gender = cmbGender.Text
                };

                accountBLL.AddAccount(account);
                MessageBox.Show("Tài khoản đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); // Tải lại danh sách tài khoản sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện Sửa từ ActionControl
        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            try
            {
                Account account = new Account
                {
                    username = txtUsername.Text,
                    name = txtName.Text,
                    password = txtPassword.Text,
                    email = txtEmail.Text,
                    phone = txtPhone.Text,
                    address = txtAddress.Text,
                    gender = cmbGender.Text
                };

                accountBLL.EditAccount(account);
                MessageBox.Show("Tài khoản đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); // Tải lại danh sách tài khoản sau khi cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện Xóa từ ActionControl
        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                accountBLL.RemoveAccount(username);
                MessageBox.Show("Tài khoản đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); // Tải lại danh sách tài khoản sau khi xóa
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện Tìm kiếm từ ActionControl
        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            string searchUsername = actionControl.SearchText; // Lấy nội dung tìm kiếm từ ActionControl
            var searchResult = accountBLL.GetAccountByUsername(searchUsername);
            if (searchResult != null)
            {
                dataGridViewAccounts.DataSource = new List<Account> { searchResult }; // Hiển thị kết quả tìm kiếm
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); // Nếu không tìm thấy, tải lại danh sách đầy đủ
            }
        }

        // Xử lý khi chọn tài khoản trong DataGridView để hiển thị thông tin lên các TextBox
        private void dataGridViewAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAccounts.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["username"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();
                txtAddress.Text = row.Cells["address"].Value.ToString();
                cmbGender.Text = row.Cells["gender"].Value.ToString();
            }
        }
    }
}
