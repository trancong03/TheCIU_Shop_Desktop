using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmProductManagement : Form
    {
        private readonly ProductBLL productBLL = new ProductBLL();
        private readonly CategoryBLL categoryBLL = new CategoryBLL();
        private readonly SizeBLL sizeBLL = new SizeBLL();
        private readonly ColorBLL colorBLL = new ColorBLL();
        private readonly ProductVariantBLL productVariantBLL = new ProductVariantBLL();

        public frmProductManagement()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadInitialData();

            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.SearchClicked += ActionControl_SearchClicked;
            actionControl.FilterChanged += ActionControl_FilterChanged;

            dataGridViewProducts.SelectionChanged += DataGridViewProducts_SelectionChanged;
        }

        private void LoadInitialData()
        {
            LoadCategories();
            LoadSizes();
            LoadColors();
            LoadProducts();
        }

        private void LoadComboBoxData(ComboBox comboBox, object dataSource, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedIndex = -1; // Clear selection
        }

        private void LoadCategories() => LoadComboBoxData(cmbCategory, categoryBLL.GetAllCategories(), "category_name", "category_id");
        private void LoadSizes() => LoadComboBoxData(cmbSize, sizeBLL.GetAllSizes(), "size_name", "size_id");
        private void LoadColors() => LoadComboBoxData(cmbColor, colorBLL.GetAllColors(), "color_name", "color_id");

        private void LoadProducts()
        {
            var products = productBLL.GetProductDetails().ToList();
            dataGridViewProducts.DataSource = products;

            // Thiết lập tiêu đề cho các cột
            dataGridViewProducts.Columns["product_id"].Visible = false;
            dataGridViewProducts.Columns["product_name"].HeaderText = "Tên Sản Phẩm";
            dataGridViewProducts.Columns["Title"].HeaderText = "Tiêu Đề";
            dataGridViewProducts.Columns["Dateadd"].HeaderText = "Ngày Thêm";
            dataGridViewProducts.Columns["Price"].HeaderText = "Giá";
            dataGridViewProducts.Columns["CategoryName"].HeaderText = "Danh Mục";
            dataGridViewProducts.Columns["SizeName"].HeaderText = "Kích Cỡ";
            dataGridViewProducts.Columns["ColorName"].HeaderText = "Màu Sắc";
            dataGridViewProducts.Columns["Quantity"].HeaderText = "Số Lượng";
        }

        private bool ValidateProductInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!float.TryParse(txtPrice.Text, out var price) || price <= 0)
            {
                MessageBox.Show("Giá sản phẩm phải là số lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInputFields()
        {
            txtProductName.Clear();
            txtTitle.Clear();
            txtPrice.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbSize.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            txtQuantity.Clear();
            txtRating.Clear();
            dtpDateAdd.Value = DateTime.Now;
        }

        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            if (!ValidateProductInput()) return;

            try
            {
                var product = new Product
                {
                    product_name = txtProductName.Text,
                    Title = txtTitle.Text,
                    price = float.TryParse(txtPrice.Text, out var price) ? price : 0,
                    category_id = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    Dateadd = dtpDateAdd.Value
                };

                if (productBLL.AddProduct(product))
                {
                    var variant = new ProductVariant
                    {
                        product_id = product.product_id,
                        size_id = cmbSize.SelectedValue != null ? (int)cmbSize.SelectedValue : 0,
                        color_id = cmbColor.SelectedValue != null ? (int)cmbColor.SelectedValue : 0,
                        quantity = int.TryParse(txtQuantity.Text, out var qty) ? qty : 0
                    };

                    productVariantBLL.AddProductVariant(variant);
                    LoadProducts();
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;

            if (!ValidateProductInput()) return;

            try
            {
                var selectedProductId = (int)dataGridViewProducts.CurrentRow.Cells["product_id"].Value;

                var product = new Product
                {
                    product_id = selectedProductId,
                    product_name = txtProductName.Text,
                    Title = txtTitle.Text,
                    price = float.TryParse(txtPrice.Text, out var price) ? price : 0,
                    category_id = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    Dateadd = dtpDateAdd.Value
                };

                if (productBLL.EditProduct(product))
                {
                    var variant = new ProductVariant
                    {
                        product_id = selectedProductId,
                        size_id = cmbSize.SelectedValue != null ? (int)cmbSize.SelectedValue : 0,
                        color_id = cmbColor.SelectedValue != null ? (int)cmbColor.SelectedValue : 0,
                        quantity = int.TryParse(txtQuantity.Text, out var qty) ? qty : 0
                    };

                    productVariantBLL.EditProductVariant(variant);
                    LoadProducts();
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedProductId = (int)dataGridViewProducts.CurrentRow.Cells["product_id"].Value;

                if (productBLL.RemoveProduct(selectedProductId))
                {
                    productVariantBLL.RemoveProductVariant(selectedProductId);
                    LoadProducts();
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;

            txtProductName.Text = dataGridViewProducts.CurrentRow.Cells["product_name"].Value.ToString();
            txtTitle.Text = dataGridViewProducts.CurrentRow.Cells["Title"].Value.ToString();
            txtPrice.Text = dataGridViewProducts.CurrentRow.Cells["Price"].Value.ToString();
            cmbCategory.Text = dataGridViewProducts.CurrentRow.Cells["CategoryName"].Value.ToString();
            cmbSize.Text = dataGridViewProducts.CurrentRow.Cells["SizeName"].Value.ToString();
            cmbColor.Text = dataGridViewProducts.CurrentRow.Cells["ColorName"].Value.ToString();
            txtQuantity.Text = dataGridViewProducts.CurrentRow.Cells["Quantity"].Value.ToString();
            dtpDateAdd.Value = (DateTime)dataGridViewProducts.CurrentRow.Cells["Dateadd"].Value;
        }

        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            string searchText = actionControl.SearchText;
            var filteredProducts = productBLL.SearchProducts(searchText);
            dataGridViewProducts.DataSource = filteredProducts;
        }


        private void ActionControl_FilterChanged(object sender, EventArgs e)
        {
            var filterValue = actionControl.SelectedFilterValue;
            if (filterValue != null)
            {
                var filteredProducts = productBLL.FilterProductsByCategory((int)filterValue);
                dataGridViewProducts.DataSource = filteredProducts;
            }
        }
    }
}
