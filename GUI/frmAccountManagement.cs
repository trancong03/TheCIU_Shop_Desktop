using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmAccountManagement : Form
    {
        private AccountBLL accountBLL = new AccountBLL();

        public FrmAccountManagement()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadAccounts(); // Load dữ liệu tài khoản khi mở form

            // Đăng ký sự kiện cho ActionControl
            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.SearchClicked += ActionControl_SearchClicked;

            actionControl.SearchTextChanged += ActionControl_SearchTextChanged;
            dataGridViewAccounts.CellClick += DataGridViewAccounts_CellClick;


        }
        private void ConfigureDataGridView()
        {
            dataGridViewAccounts.AutoGenerateColumns = false;
            dataGridViewAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAccounts.AllowUserToResizeColumns = false;
            dataGridViewAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cột Tên đăng nhập
            dataGridViewAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên đăng nhập",
                DataPropertyName = "username",
                Name = "usernameColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            // Cột Họ và tên
            dataGridViewAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ và tên",
                DataPropertyName = "name",
                Name = "nameColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });
            // Cột Mật khẩu
            dataGridViewAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mật khẩu",
                DataPropertyName = "password", // Đúng tên thuộc tính trong DTO
                Name = "passwordColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            // Cột Email
            dataGridViewAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "email",
                Name = "emailColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            // Cột Số điện thoại
            dataGridViewAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số điện thoại",
                DataPropertyName = "phone",
                Name = "phoneColumn",
                Width = 120,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            // Cột Địa chỉ
            dataGridViewAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Địa chỉ",
                DataPropertyName = "address",
                Name = "addressColumn",
                Width = 250,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            // Cột Giới tính
            dataGridViewAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giới tính",
                DataPropertyName = "gender",
                Name = "genderColumn",
                Width = 100,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            // Cột Trạng thái
            dataGridViewAccounts.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "Trạng thái",
                DataPropertyName = "status",
                Name = "statusColumn",
                Width = 80,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });
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




        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbGender.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

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
                if (!ValidateInput()) return;

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

                accountBLL.EditAccount(account);
                MessageBox.Show("Tài khoản đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
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

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{username}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    accountBLL.RemoveAccount(username);
                    MessageBox.Show("Tài khoản đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActionControl_SearchClicked(object sender, EventArgs e)
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
                    dataGridViewAccounts.DataSource = new BindingList<Account>(searchResults);
                }
                else
                {
                    dataGridViewAccounts.DataSource = null;
                    MessageBox.Show("Không tìm thấy tài khoản phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void DataGridViewAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAccounts.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["usernameColumn"]?.Value?.ToString() ?? "";
                txtName.Text = row.Cells["nameColumn"]?.Value?.ToString() ?? "";
                txtPassword.Text = row.Cells["passwordColumn"]?.Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["emailColumn"]?.Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phoneColumn"]?.Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["addressColumn"]?.Value?.ToString() ?? "";
                cmbGender.Text = row.Cells["genderColumn"]?.Value?.ToString() ?? "";

                // Xử lý trạng thái (status)
                var statusValue = row.Cells["statusColumn"]?.Value;
                if (statusValue is bool statusBool)
                {
                    chkStatus.Checked = statusBool;
                }
                else if (statusValue is int statusInt)
                {
                    chkStatus.Checked = statusInt == 1;
                }
                else if (statusValue is string statusString)
                {
                    chkStatus.Checked = statusString == "1" || statusString.ToLower() == "true";
                }
                else
                {
                    chkStatus.Checked = false; // Mặc định nếu không xác định được
                }
            }
        }

    }
}
