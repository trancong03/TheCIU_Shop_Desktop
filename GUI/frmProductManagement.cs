using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using BLL;
using DTO;
using Ultis;

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
            actionControl.ReloadClicked += ActionControl_ReloadClicked;
            dataGridViewProducts.CellFormatting += DataGridViewProducts_CellFormatting;

            dataGridViewProducts.SelectionChanged += DataGridViewProducts_SelectionChanged;
            
            
        }

        private void ActionControl_ReloadClicked(object sender, EventArgs e)
        {
            LoadProducts();
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
            // Clear existing data
            dataGridViewProducts.DataSource = null;

            // Fetch product details
            var products = productBLL.GetProductDetails();
            if (products == null || !products.Any())
            {
                var emptyTable = new System.Data.DataTable();
                emptyTable.Columns.Add("Thông báo", typeof(string));
                emptyTable.Rows.Add("Chưa có dữ liệu");
                dataGridViewProducts.DataSource = emptyTable;

                dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewProducts.ColumnHeadersVisible = false;
                dataGridViewProducts.ReadOnly = true;
                return;
            }

            // Bind data to DataGridView
            dataGridViewProducts.DataSource = products;

            // Adjust column headers
            dataGridViewProducts.Columns["ProductId"].Visible = false;
            dataGridViewProducts.Columns["CategoryId"].Visible = false;
            dataGridViewProducts.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            dataGridViewProducts.Columns["CategoryName"].HeaderText = "Danh Mục";
            dataGridViewProducts.Columns["ColorName"].HeaderText = "Màu Sắc";
            dataGridViewProducts.Columns["SizeName"].HeaderText = "Kích Cỡ";
            dataGridViewProducts.Columns["Quantity"].HeaderText = "Số Lượng";
            dataGridViewProducts.Columns["Price"].HeaderText = "Giá";
            dataGridViewProducts.Columns["Rating"].HeaderText = "Đánh Giá";
            dataGridViewProducts.Columns["DateAdd"].HeaderText = "Ngày Thêm";

            // Set DataGridView properties
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.ReadOnly = true;

            // Attach CellClick event
            dataGridViewProducts.CellClick += DataGridViewProducts_CellClick;

            pictureBoxProduct.Image = Properties.Resources.DefaultImage; // Ảnh mặc định
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void DataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewProducts.Rows.Count)
                return;

            var row = dataGridViewProducts.Rows[e.RowIndex];
            var product = row.DataBoundItem as ProductDetailDTO;

            if (product != null)
            {
                string localImagePath = Path.Combine(@"D:\TEAMWORKING\TheCIU_Shop_Desktop\GUI\bin\Debug", product.ImageSP);

                Ultis.ImageHelper.LoadImageFromLocalOrURL(pictureBoxProduct, localImagePath);
            }
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
                // Lấy tên tệp hình ảnh từ PictureBox (nếu có)
                string imageFileName = null;

                if (pictureBoxProduct.Image != null)
                {
                    // Đường dẫn lưu ảnh
                    string imageFolderPath = @"D:\TEAMWORKING\TheCIU_Shop_Desktop\Images";
                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    // Tạo tên tệp duy nhất hoặc giữ nguyên tên gốc từ OpenFileDialog
                    string originalFileName = Guid.NewGuid().ToString() + ".jpg"; // Tạo tên file duy nhất
                    string imageFilePath = Path.Combine(imageFolderPath, originalFileName);

                    // Lưu ảnh từ PictureBox vào thư mục
                    pictureBoxProduct.Image.Save(imageFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // Lưu tên file (không bao gồm đường dẫn) vào database
                    imageFileName = originalFileName;
                }

                // Tạo sản phẩm mới
                var product = new Product
                {
                    product_name = txtProductName.Text,
                    Title = txtTitle.Text,
                    price = float.TryParse(txtPrice.Text, out var price) ? price : 0,
                    category_id = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    Dateadd = dtpDateAdd.Value,
                    ImageSP = imageFileName // Gán tên file ảnh vào cơ sở dữ liệu
                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                if (productBLL.AddProduct(product))
                {
                    // Tạo biến thể sản phẩm
                    var variant = new ProductVariant
                    {
                        product_id = product.product_id,
                        size_id = cmbSize.SelectedValue != null ? (int)cmbSize.SelectedValue : 0,
                        color_id = cmbColor.SelectedValue != null ? (int)cmbColor.SelectedValue : 0,
                        quantity = int.TryParse(txtQuantity.Text, out var qty) ? qty : 0
                    };

                    // Thêm biến thể sản phẩm
                    productVariantBLL.AddProductVariant(variant);

                    // Tải lại danh sách sản phẩm
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
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Choose file (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxProduct.Image?.Dispose();
                    pictureBoxProduct.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    MessageBox.Show("Ảnh đã được tải lên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;

            // Kiểm tra và gán giá trị cho từng cột
            txtProductName.Text = dataGridViewProducts.Columns.Contains("ProductName") ?
                dataGridViewProducts.CurrentRow.Cells["ProductName"].Value?.ToString() ?? string.Empty : string.Empty;

            txtTitle.Text = dataGridViewProducts.Columns.Contains("Title") ?
                dataGridViewProducts.CurrentRow.Cells["Title"].Value?.ToString() ?? string.Empty : string.Empty;
            txtRating.Text = dataGridViewProducts.Columns.Contains("Rating") ? dataGridViewProducts.CurrentRow.Cells["Rating"].Value?.ToString() ?? string.Empty : string.Empty;
            txtPrice.Text = dataGridViewProducts.Columns.Contains("Price") ?
                dataGridViewProducts.CurrentRow.Cells["Price"].Value?.ToString() ?? string.Empty : string.Empty;

            cmbCategory.Text = dataGridViewProducts.Columns.Contains("CategoryName") ?
                dataGridViewProducts.CurrentRow.Cells["CategoryName"].Value?.ToString() ?? string.Empty : string.Empty;

            cmbSize.Text = dataGridViewProducts.Columns.Contains("SizeName") ?
                dataGridViewProducts.CurrentRow.Cells["SizeName"].Value?.ToString() ?? string.Empty : string.Empty;

            cmbColor.Text = dataGridViewProducts.Columns.Contains("ColorName") ?
                dataGridViewProducts.CurrentRow.Cells["ColorName"].Value?.ToString() ?? string.Empty : string.Empty;

            txtQuantity.Text = dataGridViewProducts.Columns.Contains("Quantity") ?
                dataGridViewProducts.CurrentRow.Cells["Quantity"].Value?.ToString() ?? string.Empty : string.Empty;

            if (dataGridViewProducts.Columns.Contains("Dateadd") &&
                DateTime.TryParse(dataGridViewProducts.CurrentRow.Cells["Dateadd"].Value?.ToString(), out DateTime date))
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

