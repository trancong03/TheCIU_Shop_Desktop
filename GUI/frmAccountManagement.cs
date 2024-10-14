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

            actionControl.SearchTextChanged += ActionControl_SearchTextChanged;

           
        }
        private void ActionControl_SearchTextChanged(object sender, EventArgs e)
        {
            string searchUsername = actionControl.SearchText;
            if (string.IsNullOrEmpty(searchUsername))
            {
                LoadAccounts(); 
            }
            else
            {
                var searchResults = accountBLL.SearchAccounts(searchUsername);
                if (searchResults != null && searchResults.Count > 0)
                {
                    dataGridViewAccounts.DataSource = searchResults; 
                }
                else
                {
                    dataGridViewAccounts.DataSource = null; 
                }
            }
        }
       
        private void LoadAccounts()
        {
            dataGridViewAccounts.DataSource = accountBLL.GetAllAccounts(); 
        }

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
                    gender = cmbGender.Text,
                    status = chkStatus.Checked ? 1 : 0
                };

                accountBLL.AddAccount(account);
                MessageBox.Show("Tài khoản đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


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
                    gender = cmbGender.Text,
                    status = chkStatus.Checked ? 1 : 0 // Lấy giá trị từ CheckBox trạng thái
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

        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                accountBLL.RemoveAccount(username);
                MessageBox.Show("Tài khoản đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            string searchUsername = actionControl.SearchText;
            var searchResult = accountBLL.GetAccountByUsername(searchUsername);
            if (searchResult != null)
            {
                dataGridViewAccounts.DataSource = new List<Account> { searchResult };
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); 
            }
        }


        private void dataGridViewAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAccounts.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["username"].Value != null ? row.Cells["username"].Value.ToString() : "";
                txtName.Text = row.Cells["name"].Value != null ? row.Cells["name"].Value.ToString() : "";
                txtPassword.Text = row.Cells["password"].Value != null ? row.Cells["password"].Value.ToString() : "";
                txtEmail.Text = row.Cells["email"].Value != null ? row.Cells["email"].Value.ToString() : "";
                txtPhone.Text = row.Cells["phone"].Value != null ? row.Cells["phone"].Value.ToString() : "";
                txtAddress.Text = row.Cells["address"].Value != null ? row.Cells["address"].Value.ToString() : "";
                cmbGender.Text = row.Cells["gender"].Value != null ? row.Cells["gender"].Value.ToString() : "";

                chkStatus.Checked = row.Cells["status"].Value != null && row.Cells["status"].Value.ToString() == "1";
            }
        }
    }
}
