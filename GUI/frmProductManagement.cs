using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using BLL;
using DTO;
using Ultis;
using System.Collections.Generic;

namespace GUI
{
    public partial class FrmProductManagement : Form
    {
        private readonly ProductBLL productBLL = new ProductBLL();
        private readonly CategoryBLL categoryBLL = new CategoryBLL();
        private readonly SizeBLL sizeBLL = new SizeBLL();
        private readonly ColorBLL colorBLL = new ColorBLL();
        private readonly ProductVariantBLL productVariantBLL = new ProductVariantBLL();

        List<ProductDetailDTO> filteredProducts;


        public FrmProductManagement()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadInitialData();       // Tải dữ liệu ban đầu cho form
            SetupEvents();           // Đăng ký sự kiện
            ConfigureGrids();        // Cấu hình DataGridView
            LoadFilterOptions();     // Cấu hình bộ lọc
            EnableControls(false);   // Đặt các trường ở trạng thái readonly mặc định
        }

        private void SetupEvents()
        {
            // Sự kiện cho actionControl
            actionControl.AddClicked += ActionControl_AddClicked; // Sự kiện Thêm mới
            actionControl.UpdateClicked += ActionControl_UpdateClicked; // Sự kiện Cập nhật
            actionControl.DeleteClicked += ActionControl_DeleteClicked; // Sự kiện Xóa
            actionControl.ReloadClicked += ActionControl_ReloadClicked;
            actionControl.FilterChanged += ActionControl_FilterChanged; // Sự kiện Lọc dữ liệu
            actionControl.SearchClicked += ActionControl_SearchClicked; // Sự kiện Tìm kiếm

            this.btnSave.Click += BtnSave_Click;
            

            // Sự kiện cho actionControlMini
            actionControlMini.AddClicked += ActionControlMini_AddClicked; // Thêm biến thể sản phẩm
            actionControlMini.UpdateClicked += ActionControlMini_UpdateClicked; // Cập nhật biến thể
            actionControlMini.DeleteClicked += ActionControlMini_DeleteClicked; // Xóa biến thể
            actionControl.SaveClicked += ActionControl_SaveClicked;

            // Sự kiện cho các điều khiển khác
            dataGridViewProducts.SelectionChanged += DataGridViewProducts_SelectionChanged; // Thay đổi dòng được chọn
            pictureBoxProduct.Click += PictureBoxProduct_Click; // Chọn ảnh sản phẩm

            
        }

        private void ActionControl_SaveClicked(object sender, EventArgs e)
        {
            SaveProductVariants();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateProductInput()) return;

                var product = new ProductDetailDTO
                {
                    ProductName = txtProductName.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    Price = (float)txtPrice.Value,
                    CategoryId = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    DateAdd = dtpDateAdd.Value,
                    ImageSP = SaveImage()
                };

                int productId = GetSelectedProductId();

                // Nếu ID = -1, thì đây là thêm mới
                if (productId == -1)
                {
                    if (productBLL.AddProduct(product))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridViewProduct();
                        EnableControls(false);
                        ResetFormForNewProduct();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Cập nhật sản phẩm
                {
                    product.ProductId = productId;
                    if (productBLL.EditProduct(product))
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridViewProduct();
                        EnableControls(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetFormForNewProduct()
        {
            ClearInputs(); // Xóa dữ liệu trên form
            EnableControls(false); // Khóa các trường nhập liệu
            ClearProductVariantGrid(); // Xóa danh sách biến thể
            dataGridViewProducts.ClearSelection(); // Không chọn dòng nào
        }

        private void SaveProductVariants()
        {
            if (GetSelectedProductId() == -1)
            {
                MessageBox.Show("Hãy thêm sản phẩm trước khi thêm biến thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = GetSelectedProductId();
            var variants = GetProductVariantsFromGrid();

            foreach (var variant in variants)
            {
                variant.ProductId = productId;
                productVariantBLL.SaveProductVariant(variant);
            }

            MessageBox.Show("Lưu biến thể sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridViewProductVariant(productId); // Cập nhật danh sách biến thể
        }


        private void ActionControl_ReloadClicked(object sender, EventArgs e)
        {
            LoadDataGridViewProduct();
        }

        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            ClearInputs(); // Xóa dữ liệu trên form
            EnableControls(true); // Cho phép chỉnh sửa các trường nhập liệu
            ClearProductVariantGrid(); // Xóa dữ liệu biến thể
                                       // Đặt trạng thái ID sản phẩm để thêm mới
            dataGridViewProducts.ClearSelection();
        }


        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            if (GetSelectedProductId() == -1)
            {
                MessageBox.Show("Hãy chọn sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnableControls(true); 
        }

        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            int productId = GetSelectedProductId();
            if (productId == -1)
            {
                MessageBox.Show("Hãy chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (productBLL.RemoveProduct(productId))
                {
                    MessageBox.Show("Xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridViewProduct(); // Tải lại danh sách sản phẩm
                }
                else
                {
                    MessageBox.Show("Không thể xóa sản phẩm. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        


        private void EnableControls(bool isEnabled)
        {
            txtProductName.ReadOnly = !isEnabled;
            txtTitle.ReadOnly = !isEnabled;
            txtPrice.Enabled = isEnabled;
            cmbCategory.Enabled = isEnabled;
            cmbSize.Enabled = isEnabled;
            cmbColor.Enabled = isEnabled;
            txtQuantity.ReadOnly = !isEnabled;
            txtRating.ReadOnly = !isEnabled;
            dtpDateAdd.Enabled = isEnabled;
        }


        
        private void ConfigureGrids()
        {
            productVariantBLL.ConfigureProductVariantGrid(dataGridViewProductVariant);
        }

        private void ConfigureProductVariantGrid()
        {
            if (dataGridViewProductVariant.Columns["VariantId"] != null)
                dataGridViewProductVariant.Columns["VariantId"].Visible = false;

            if (dataGridViewProductVariant.Columns["ProductId"] != null)
                dataGridViewProductVariant.Columns["ProductId"].Visible = false;

            if (dataGridViewProductVariant.Columns["SizeId"] != null)
                dataGridViewProductVariant.Columns["SizeId"].Visible = false;

            if (dataGridViewProductVariant.Columns["ColorId"] != null)
                dataGridViewProductVariant.Columns["ColorId"].Visible = false;

            // Điều chỉnh giao diện
            dataGridViewProductVariant.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductVariant.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductVariant.ReadOnly = false; // Cho phép chỉnh sửa nếu cần
        }
        private void ClearProductVariantGrid()
        {
            dataGridViewProductVariant.DataSource = null; 
            dataGridViewProductVariant.Rows.Clear(); 
            ConfigureProductVariantGrid(); 
        }

        private int GetSelectedProductId()
        {
            // Nếu không có dòng nào được chọn, trả về -1 (thêm mới)
            if (dataGridViewProducts.CurrentRow == null || dataGridViewProducts.SelectedRows.Count == 0)
                return -1;

            // Trả về ID của sản phẩm đã chọn
            return (int)dataGridViewProducts.CurrentRow.Cells["ProductId"].Value;
        }

        private void ActionControlMini_AddClicked(object sender, EventArgs e)
        {
            if (!ValidateVariantInputs(out int quantity)) return;

            var variant = new ProductVariantDTO
            {
                SizeName = cmbSize.Text,
                ColorName = cmbColor.Text,
                Quantity = quantity
            };

            var variants = GetProductVariantsFromGrid();
            variants.Add(variant);
            UpdateProductVariantGrid(variants);

            ClearInputs();
        }

        private void ActionControlMini_UpdateClicked(object sender, EventArgs e)
        {
            if (dataGridViewProductVariant.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một dòng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateVariantInputs(out int quantity)) return;

            var rowIndex = dataGridViewProductVariant.CurrentRow.Index;

            dataGridViewProductVariant.Rows[rowIndex].Cells["SizeName"].Value = cmbSize.Text;
            dataGridViewProductVariant.Rows[rowIndex].Cells["ColorName"].Value = cmbColor.Text;
            dataGridViewProductVariant.Rows[rowIndex].Cells["Quantity"].Value = quantity;

            ClearInputs();
        }

        private void ActionControlMini_DeleteClicked(object sender, EventArgs e)
        {
            if (dataGridViewProductVariant.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewProductVariant.Rows.RemoveAt(dataGridViewProductVariant.CurrentRow.Index);
            ClearInputs();
        }


        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            string searchText = actionControl.SearchText.Trim();
            filteredProducts = float.TryParse(searchText, out float price)
                ? productBLL.FilterProductsByPrice(price)
                : productBLL.SearchProducts(searchText);

            if (filteredProducts == null || !filteredProducts.Any())
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridViewProducts.DataSource = filteredProducts;
        }

        private void ActionControl_FilterChanged(object sender, EventArgs e)
        {
            if (actionControl.SelectedFilterValue == null) return;

            if (int.TryParse(actionControl.SelectedFilterValue.ToString(), out var categoryId))
            {
                switch (categoryId)
                {
                    case 0:
                        filteredProducts = productBLL.GetBasicProductDetails();
                        break;
                    case -1:
                        filteredProducts = productBLL.SortProductsByPriceDescending();
                        break;
                    case -2:
                        filteredProducts = productBLL.SortProductsByPriceAscending();
                        break;               
                    default:
                        filteredProducts = productBLL.GetBasicProductDetails();
                        break;
                }

                dataGridViewProducts.DataSource = filteredProducts;
            }
        }


        private void LoadFilterOptions()
        {
            // Thêm các tùy chọn lọc giá
            var filterOptions = new[]
            {
                new { category_id = 0, category_name = "Tất cả" },
                new { category_id = -1, category_name = "Giá cao đến thấp" },
                new { category_id = -2, category_name = "Giá thấp đến cao" },
            }.ToList();

            actionControl.FilterDataSource = filterOptions;
            actionControl.FilterDisplayMember = "category_name";
            actionControl.FilterValueMember = "category_id";
        }

        private void PictureBoxProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo hộp thoại OpenFileDialog để chọn ảnh
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Chọn ảnh sản phẩm";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                    // Nếu người dùng chọn ảnh
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Load ảnh đã chọn vào PictureBox
                        string selectedImagePath = openFileDialog.FileName;
                        pictureBoxProduct.Image = System.Drawing.Image.FromFile(selectedImagePath);
                        pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void SetReadOnlyState(bool isReadOnly)
        {
            txtProductName.ReadOnly = isReadOnly;
            txtTitle.ReadOnly = isReadOnly;
            txtPrice.Enabled = !isReadOnly; 
            cmbCategory.Enabled = !isReadOnly;
            cmbSize.Enabled = !isReadOnly;
            cmbColor.Enabled = !isReadOnly;
            txtQuantity.ReadOnly = isReadOnly;
            txtRating.ReadOnly = isReadOnly;
            dtpDateAdd.Enabled = !isReadOnly;
        }


        private void SaveProductVariants(int productId)
        {
            var variants = GetProductVariantsFromGrid();
            foreach (var variant in variants)
            {
                variant.ProductId = productId;
                productVariantBLL.SaveProductVariant(variant);
            }
        }

        private string SaveImage()
        {
            if (pictureBoxProduct.Image != null)
            {
                string imageFolderPath = @"D:\TEAMWORKING\TheCIU_Shop_Desktop\Images";
                if (!Directory.Exists(imageFolderPath)) Directory.CreateDirectory(imageFolderPath);

                string originalFileName = $"{Guid.NewGuid()}.jpg";
                string imageFilePath = Path.Combine(imageFolderPath, originalFileName);

                using (var bitmap = new Bitmap(pictureBoxProduct.Image))
                {
                    bitmap.Save(imageFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                return originalFileName;
            }

            return null;
        }

        private void LoadInitialData()
        {
            LoadCategories();
            LoadSizes();
            LoadColors();
            LoadDataGridViewProduct();
        }

        private void LoadComboBoxData(ComboBox comboBox, object dataSource, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedIndex = -1;
        }

        private void LoadCategories() => LoadComboBoxData(cmbCategory, categoryBLL.GetAllCategories(), "category_name", "category_id");
        private void LoadSizes() => LoadComboBoxData(cmbSize, sizeBLL.GetAllSizes(), "size_name", "size_id");
        private void LoadColors() => LoadComboBoxData(cmbColor, colorBLL.GetAllColors(), "color_name", "color_id");

        private void LoadDataGridViewProduct()
        {
            try
            {
                var products = productBLL.GetBasicProductDetails();
                dataGridViewProducts.DataSource = products;

                dataGridViewProducts.Columns["ProductId"].Visible = false;
                dataGridViewProducts.Columns["CategoryId"].Visible = false;
                dataGridViewProducts.Columns["ColorName"].Visible = false;
                dataGridViewProducts.Columns["SizeName"].Visible = false;
                dataGridViewProducts.Columns["Quantity"].Visible = false;
                dataGridViewProducts.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
                dataGridViewProducts.Columns["Title"].HeaderText = "Tiêu Đề";
                dataGridViewProducts.Columns["Price"].HeaderText = "Giá";
                dataGridViewProducts.Columns["DateAdd"].HeaderText = "Ngày Thêm";
                dataGridViewProducts.Columns["ImageSP"].HeaderText = "Hình Ảnh";
                dataGridViewProducts.Columns["CategoryName"].HeaderText = "Danh Mục";

                dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewProducts.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataGridViewProductVariant(int productId)
        {
            try
            {
                ConfigureProductVariantGrid();
                // Lấy danh sách biến thể sản phẩm dựa trên ProductId
                var variants = productVariantBLL.GetVariantsByProductId(productId);
                dataGridViewProductVariant.DataSource = variants;

                // Tùy chỉnh hiển thị các cột
                dataGridViewProductVariant.Columns["VariantId"].Visible = false;
                dataGridViewProductVariant.Columns["ProductId"].Visible = false;
                dataGridViewProductVariant.Columns["SizeId"].Visible = false;
                dataGridViewProductVariant.Columns["ColorId"].Visible = false;
                dataGridViewProductVariant.Columns["Quantity"].HeaderText = "Số Lượng";
                dataGridViewProductVariant.Columns["SizeName"].HeaderText = "Kích Cỡ";
                dataGridViewProductVariant.Columns["ColorName"].HeaderText = "Màu Sắc";

                // Điều chỉnh giao diện
                dataGridViewProductVariant.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewProductVariant.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewProductVariant.ReadOnly = true;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách biến thể sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
            {
            if (dataGridViewProducts.CurrentRow == null) return;

            txtProductName.Text = dataGridViewProducts.Columns.Contains("ProductName") ?
                dataGridViewProducts.CurrentRow.Cells["ProductName"].Value?.ToString() ?? string.Empty : string.Empty;
            
            txtTitle.Text = dataGridViewProducts.Columns.Contains("Title") ?
                dataGridViewProducts.CurrentRow.Cells["Title"].Value?.ToString() ?? string.Empty : string.Empty;

            txtPrice.Value = dataGridViewProducts.Columns.Contains("Price") ?
                decimal.TryParse(dataGridViewProducts.CurrentRow.Cells["Price"].Value?.ToString(), out var price) ? price : 0 : 0;

            cmbCategory.Text = dataGridViewProducts.Columns.Contains("CategoryName") ?
                dataGridViewProducts.CurrentRow.Cells["CategoryName"].Value?.ToString() ?? string.Empty : string.Empty;

            cmbSize.Text = dataGridViewProducts.Columns.Contains("SizeName") ?
                dataGridViewProducts.CurrentRow.Cells["SizeName"].Value?.ToString() ?? string.Empty : string.Empty;

            cmbColor.Text = dataGridViewProducts.Columns.Contains("ColorName") ?
                dataGridViewProducts.CurrentRow.Cells["ColorName"].Value?.ToString() ?? string.Empty : string.Empty;

            txtQuantity.Text = dataGridViewProducts.Columns.Contains("Quantity") ?
                dataGridViewProducts.CurrentRow.Cells["Quantity"].Value?.ToString() ?? string.Empty : string.Empty;

            if (dataGridViewProducts.CurrentRow != null)
            {
                int productId = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells["ProductId"].Value);
                LoadDataGridViewProductVariant(productId);
            }
            if (dataGridViewProducts.Columns.Contains("DateAdd") &&
                DateTime.TryParse(dataGridViewProducts.CurrentRow.Cells["DateAdd"].Value?.ToString(), out DateTime date))
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
            if (txtPrice.Value <= 0)
            {
                MessageBox.Show("Giá sản phẩm phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private List<ProductVariantDTO> GetProductVariantsFromGrid()
        {
            var variants = new List<ProductVariantDTO>();
            foreach (DataGridViewRow row in dataGridViewProductVariant.Rows)
            {
                if (!row.IsNewRow)
                {
                    variants.Add(new ProductVariantDTO
                    {
                        SizeName = row.Cells["SizeName"].Value.ToString(),
                        ColorName = row.Cells["ColorName"].Value.ToString(),
                        Quantity = int.Parse(row.Cells["Quantity"].Value.ToString())
                    });
                }
            }
            return variants;
        }

        private bool ValidateVariantInputs(out int quantity)
        {
            quantity = 0;
            if (cmbSize.SelectedIndex == -1 || cmbColor.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ kích cỡ, màu sắc và số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void UpdateProductVariantGrid(List<ProductVariantDTO> variants)
        {
            dataGridViewProductVariant.DataSource = null;
            dataGridViewProductVariant.DataSource = variants;
        }


        private void ClearInputs(bool isProductInput = true)
        {
            if (isProductInput)
            {
                txtProductName.Clear();
                txtTitle.Clear();
                txtPrice.Clear();
                cmbCategory.SelectedIndex = -1;
                txtRating.Clear();
                dtpDateAdd.Value = DateTime.Now;
            }
            cmbSize.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            txtQuantity.Clear();
        }



    }
}
