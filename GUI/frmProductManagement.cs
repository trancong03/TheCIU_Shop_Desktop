using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmProductManagement : Form
    {
        private readonly ProductBLL productBLL = new ProductBLL();
        private readonly CategoryBLL categoryBLL = new CategoryBLL();
        private readonly SizeBLL sizeBLL = new SizeBLL();
        private readonly ColorBLL colorBLL = new ColorBLL();
        private readonly ProductVariantBLL productVariantBLL = new ProductVariantBLL();

        public FrmProductManagement()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadInitialData();
            LoadFilterOptions();

            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.SearchClicked += ActionControl_SearchClicked;
            actionControl.FilterChanged += ActionControl_FilterChanged;
            dataGridViewProducts.CellFormatting += DataGridViewProducts_CellFormatting;

            dataGridViewProducts.SelectionChanged += DataGridViewProducts_SelectionChanged;
        }

        private void DataGridViewProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "Price" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    e.Value = $"{price:N0} đ"; // Định dạng giá trị và thêm "đ"
                    e.FormattingApplied = true;
                }
            }
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
            // Clear the existing data source
            dataGridViewProducts.DataSource = null;

            // Load the latest data
            var products = productBLL.GetProductDetails().ToList();
            dataGridViewProducts.DataSource = products;

            // Adjust column properties
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Hide unnecessary columns and set column headers
            dataGridViewProducts.Columns["product_id"].Visible = false;
            dataGridViewProducts.Columns["product_name"].HeaderText = "Tên Sản Phẩm";
            dataGridViewProducts.Columns["Title"].HeaderText = "Tiêu Đề";
            dataGridViewProducts.Columns["Dateadd"].HeaderText = "Ngày Thêm";
            dataGridViewProducts.Columns["rating"].HeaderText = "Đánh Giá";

            // Format the Price column
            dataGridViewProducts.Columns["Price"].HeaderText = "Giá";
            dataGridViewProducts.Columns["Price"].DefaultCellStyle.Format = "N0"; // Thousand separator
            dataGridViewProducts.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewProducts.Columns["CategoryName"].HeaderText = "Danh Mục";
            dataGridViewProducts.Columns["CategoryName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProducts.Columns["SizeName"].HeaderText = "Kích Cỡ";
            dataGridViewProducts.Columns["SizeName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProducts.Columns["ColorName"].HeaderText = "Màu Sắc";
            dataGridViewProducts.Columns["ColorName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewProducts.Columns["Quantity"].HeaderText = "Số Lượng";
            dataGridViewProducts.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridViewProducts.Columns)
            {
                column.MinimumWidth = 100;
            }

            // Disable horizontal scrolling
            dataGridViewProducts.ScrollBars = ScrollBars.Vertical;
        }




        private void LoadFilterOptions()
        {
            // Chỉ thêm các tùy chọn lọc giá
            var filterOptions = new[]
            {
                new { category_id = 0, category_name = "Tất cả" },
                new { category_id = -1, category_name = "Giá cao đến thấp" },
                new { category_id = -2, category_name = "Giá thấp đến cao" }
            }.ToList();

            actionControl.FilterDataSource = filterOptions;
            actionControl.FilterDisplayMember = "category_name";
            actionControl.FilterValueMember = "category_id";
        }

        private void ActionControl_FilterChanged(object sender, EventArgs e)
        {
            if (actionControl.SelectedFilterValue == null)
                return;

            if (int.TryParse(actionControl.SelectedFilterValue.ToString(), out var categoryId))
            {
                if (categoryId == 0)
                {
                    // Tùy chọn "Tất cả"
                    LoadProducts();
                }
                else if (categoryId == -1)
                {
                    // Tùy chọn "Giá cao đến thấp"
                    var sortedProducts = productBLL.SortProductsByPriceDescending();
                    dataGridViewProducts.DataSource = sortedProducts;
                }
                else if (categoryId == -2)
                {
                    // Tùy chọn "Giá thấp đến cao"
                    var sortedProducts = productBLL.SortProductsByPriceAscending();
                    dataGridViewProducts.DataSource = sortedProducts;
                }
            }
        }

        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            string searchText = actionControl.SearchText;
            var filteredProducts = productBLL.SearchProducts(searchText);
            dataGridViewProducts.DataSource = filteredProducts;
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
            if (dataGridViewProducts.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateProductInput()) return;

            try
            {
                // Lấy ID của sản phẩm được chọn
                var selectedProductId = (int)dataGridViewProducts.CurrentRow.Cells["product_id"].Value;

                // Cập nhật thông tin sản phẩm
                var product = new Product
                {
                    product_id = selectedProductId,
                    product_name = txtProductName.Text,
                    Title = txtTitle.Text,
                    price = float.TryParse(txtPrice.Text, out var price) ? price : 0,
                    category_id = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    Dateadd = dtpDateAdd.Value
                };

                // Gọi BLL để cập nhật sản phẩm
                if (productBLL.EditProduct(product))
                {
                    // Lấy thông tin biến thể
                    var variant = productVariantBLL.GetProductVariantById(selectedProductId);

                    if (variant != null)
                    {
                        variant.size_id = cmbSize.SelectedValue != null ? (int)cmbSize.SelectedValue : 0;
                        variant.color_id = cmbColor.SelectedValue != null ? (int)cmbColor.SelectedValue : 0;
                        variant.quantity = int.TryParse(txtQuantity.Text, out var qty) ? qty : 0;

                        // Cập nhật biến thể sản phẩm
                        productVariantBLL.EditProductVariant(variant);
                    }

                    // Load lại dữ liệu
                    LoadProducts();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dữ liệu các điều khiển đầu vào
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Gọi BLL để xóa
                if (productBLL.RemoveProduct(selectedProductId))
                {
                    LoadProducts(); // Tải lại dữ liệu
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa sản phẩm vì nó đang được sử dụng trong các bảng liên quan.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;

            txtProductName.Text = dataGridViewProducts.CurrentRow.Cells["product_name"].Value?.ToString() ?? string.Empty;
            txtTitle.Text = dataGridViewProducts.CurrentRow.Cells["Title"].Value?.ToString() ?? string.Empty;
            txtPrice.Text = dataGridViewProducts.CurrentRow.Cells["Price"].Value?.ToString() ?? string.Empty;
            cmbCategory.Text = dataGridViewProducts.CurrentRow.Cells["CategoryName"].Value?.ToString() ?? string.Empty;
            cmbSize.Text = dataGridViewProducts.CurrentRow.Cells["SizeName"].Value?.ToString() ?? string.Empty;
            cmbColor.Text = dataGridViewProducts.CurrentRow.Cells["ColorName"].Value?.ToString() ?? string.Empty;
            txtQuantity.Text = dataGridViewProducts.CurrentRow.Cells["Quantity"].Value?.ToString() ?? string.Empty;

            if (DateTime.TryParse(dataGridViewProducts.CurrentRow.Cells["Dateadd"].Value?.ToString(), out var date))
            {
                dtpDateAdd.Value = date;
            }
            else
            {
                dtpDateAdd.Value = DateTime.Now;
            }
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
    }
}

