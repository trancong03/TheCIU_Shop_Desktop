using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmCategoryManagement : Form
    {
        private readonly CategoryBLL categoryBLL = new CategoryBLL();

        public FrmCategoryManagement()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadCategories();

            // Liên kết sự kiện của ActionControl
            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;

            // Liên kết sự kiện chọn dòng trong DataGridView
            dataGridViewCategories.SelectionChanged += DataGridViewCategories_SelectionChanged;
        }

        private void LoadCategories()
        {
            var categories = categoryBLL.GetAllCategories();
            if (categories.Any())
            {
                dataGridViewCategories.DataSource = categories;
                dataGridViewCategories.Columns["category_id"].HeaderText = "Mã danh mục";
                dataGridViewCategories.Columns["category_name"].HeaderText = "Tên danh mục";
            }
            else
            {
                dataGridViewCategories.DataSource = null;
                MessageBox.Show("Chưa có dữ liệu danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            try
            {
                var newCategory = new Category
                {
                    category_name = txtCategoryName.Text.Trim()
                };

                if (categoryBLL.AddCategory(newCategory))
                {
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Thêm danh mục thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            if (dataGridViewCategories.CurrentRow == null) return;

            try
            {
                var selectedCategoryId = (int)dataGridViewCategories.CurrentRow.Cells["category_id"].Value;

                var updatedCategory = new Category
                {
                    category_id = selectedCategoryId,
                    category_name = txtCategoryName.Text.Trim()
                };

                if (categoryBLL.EditCategory(updatedCategory))
                {
                    MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Cập nhật danh mục thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            if (dataGridViewCategories.CurrentRow == null) return;

            try
            {
                var selectedCategoryId = (int)dataGridViewCategories.CurrentRow.Cells["category_id"].Value;

                if (categoryBLL.RemoveCategory(selectedCategoryId))
                {
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Xóa danh mục thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCategories.CurrentRow == null) return;

            txtCategoryName.Text = dataGridViewCategories.CurrentRow.Cells["category_name"].Value.ToString();
        }
    }
}
