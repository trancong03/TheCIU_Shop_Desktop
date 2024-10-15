using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmProductManagement : Form
    {
        private ProductBLL productBLL = new ProductBLL();
        private CategoryBLL categoryBLL = new CategoryBLL();

        public frmProductManagement()
        {
            InitializeComponent();
            LoadProducts();
            LoadCategories();

            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.SearchClicked += ActionControl_SearchClicked;
            btnUploadImage.Click += btnUploadImage_Click;
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Chọn ảnh sản phẩm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    txtImagePath.Text = selectedImagePath;

                    string destinationPath = @"C:\YourImageFolder\" + System.IO.Path.GetFileName(selectedImagePath);
                    if (!System.IO.File.Exists(destinationPath))
                    {
                        System.IO.File.Copy(selectedImagePath, destinationPath);
                    }
                }
            }
        }

        // Đổ dữ liệu sản phẩm vào DataGridView
        private void LoadProducts()
        {
            var products = productBLL.GetAllProducts();

            var productDisplayList = products.Select(p => new
            {
                p.product_id,
                p.product_name,
                p.Title,
                p.price,
                CategoryName = p.Category != null ? p.Category.category_name : "Không có",
                p.ImageSP,
                p.rating,
                p.Dateadd
            }).ToList();

            dataGridViewProducts.DataSource = productDisplayList;
        }

        // Đổ dữ liệu danh mục vào ComboBox
        private void LoadCategories()
        {
            var categories = categoryBLL.GetAllCategories();
            cmbCategoryId.DataSource = categories;
            cmbCategoryId.DisplayMember = "category_name";
            cmbCategoryId.ValueMember = "category_id";
        }

        // Thêm sản phẩm
        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    product_name = txtProductName.Text,
                    price = double.Parse(txtPrice.Text),
                    category_id = (int)cmbCategoryId.SelectedValue,
                    Title = txtDescription.Text,
                    rating = double.Parse(txtRating.Text) / 5, // Tính rating dựa trên thang điểm 5
                    ImageSP = txtImagePath.Text,
                    Dateadd = dtpDateAdd.Value
                };

                productBLL.AddProduct(product);
                MessageBox.Show("Sản phẩm đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa sản phẩm
        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    product_id = int.Parse(txtProductId.Text),
                    product_name = txtProductName.Text,
                    price = double.Parse(txtPrice.Text),
                    category_id = (int)cmbCategoryId.SelectedValue,
                    Title = txtDescription.Text,
                    rating = double.Parse(txtRating.Text) / 5,
                    ImageSP = txtImagePath.Text,
                    Dateadd = dtpDateAdd.Value
                };

                productBLL.EditProduct(product);
                MessageBox.Show("Sản phẩm đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa sản phẩm
        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(txtProductId.Text);
                productBLL.RemoveProduct(productId);
                MessageBox.Show("Sản phẩm đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm kiếm sản phẩm
        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            string searchProductName = actionControl.SearchText;
            var searchResult = productBLL.GetProductByName(searchProductName);
            if (searchResult != null)
            {
                dataGridViewProducts.DataSource = new List<Product> { searchResult };
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
        }

        // Xử lý khi chọn sản phẩm trong DataGridView
        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewProducts.Rows[e.RowIndex];

                txtProductId.Text = row.Cells["product_id"].Value != null ? row.Cells["product_id"].Value.ToString() : "";
                txtProductName.Text = row.Cells["product_name"].Value != null ? row.Cells["product_name"].Value.ToString() : "";
                txtPrice.Text = row.Cells["price"].Value != null ? row.Cells["price"].Value.ToString() : "";

                string categoryName = row.Cells["CategoryName"].Value != null ? row.Cells["CategoryName"].Value.ToString() : "";
                cmbCategoryId.SelectedIndex = !string.IsNullOrEmpty(categoryName) ? cmbCategoryId.FindStringExact(categoryName) : -1;

                txtDescription.Text = row.Cells["Title"].Value != null ? row.Cells["Title"].Value.ToString() : "";

                txtRating.Text = row.Cells["rating"].Value != null
                                 ? (double.Parse(row.Cells["rating"].Value.ToString()) * 5).ToString()
                                 : "0";  // Tính lại rating nếu có giá trị

                txtImagePath.Text = row.Cells["ImageSP"].Value != null ? row.Cells["ImageSP"].Value.ToString() : "";

                dtpDateAdd.Value = row.Cells["Dateadd"].Value != null
                                   ? (DateTime)row.Cells["Dateadd"].Value
                                   : DateTime.Now; // Giá trị mặc định nếu không có ngày thêm
            }
        }

    }
}
