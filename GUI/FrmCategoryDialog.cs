using BLL;
using CustomControl;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmCategoryDialog : Form
    {
        private readonly CategoryBLL categoryBLL = new CategoryBLL();

        public FrmCategoryDialog()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = categoryBLL.GetAllCategories();
            dataGridViewCategories.DataSource = categories;
            dataGridViewCategories.Columns["category_id"].Visible = false; // Ẩn cột ID
            dataGridViewCategories.Columns["category_name"].HeaderText = "Tên Danh Mục";
        }

        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newCategory = new Category { category_name = txtCategoryName.Text };
            if (categoryBLL.AddCategory(newCategory))
            {
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            if (dataGridViewCategories.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một danh mục để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCategoryId = (int)dataGridViewCategories.CurrentRow.Cells["category_id"].Value;
            var updatedCategory = new Category
            {
                category_id = selectedCategoryId,
                category_name = txtCategoryName.Text
            };

            if (categoryBLL.EditCategory(updatedCategory))
            {
                MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Cập nhật danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            if (dataGridViewCategories.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một danh mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCategoryId = (int)dataGridViewCategories.CurrentRow.Cells["category_id"].Value;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (categoryBLL.RemoveCategory(selectedCategoryId))
                {
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            var searchText = actionControl.SearchText;
            var filteredCategories = categoryBLL.SearchCategories(searchText);
            dataGridViewCategories.DataSource = filteredCategories;
        }

        private void DataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCategories.CurrentRow != null)
            {
                txtCategoryName.Text = dataGridViewCategories.CurrentRow.Cells["category_name"].Value.ToString();
            }
        }

        private void ClearInputFields()
        {
            txtCategoryName.Clear();
        }

        private void actionControl_Load(object sender, EventArgs e)
        {
        }
    }
}
