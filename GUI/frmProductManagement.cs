using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

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
            LoadCategories();
            LoadSizes();
            LoadColors();
            LoadProducts();

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            dataGridViewProducts.SelectionChanged += DataGridViewProducts_SelectionChanged;
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
            var products = productBLL.GetAllProducts().Select(p => new
            {
                p.product_id,
                p.product_name,
                Title = p.Title,
                Price = p.price,
                CategoryName = p.Category?.category_name ?? "Không có",
                SizeName = p.ProductVariants.FirstOrDefault()?.Size.size_name ?? "Không có",
                ColorName = p.ProductVariants.FirstOrDefault()?.Color.color_name ?? "Không có",
                Quantity = p.ProductVariants.FirstOrDefault()?.quantity ?? 0,
                DateAdded = p.Dateadd,
            }).ToList();

            dataGridViewProducts.DataSource = products;

            // Thiết lập tiêu đề cho các cột
            dataGridViewProducts.Columns["product_id"].Visible = false;
            dataGridViewProducts.Columns["product_name"].HeaderText = "Tên Sản Phẩm";
            dataGridViewProducts.Columns["Title"].HeaderText = "Tiêu Đề";
            dataGridViewProducts.Columns["Price"].HeaderText = "Giá";
            dataGridViewProducts.Columns["CategoryName"].HeaderText = "Danh Mục";
            dataGridViewProducts.Columns["SizeName"].HeaderText = "Kích Cỡ";
            dataGridViewProducts.Columns["ColorName"].HeaderText = "Màu Sắc";
            dataGridViewProducts.Columns["Quantity"].HeaderText = "Số Lượng";
            dataGridViewProducts.Columns["DateAdded"].HeaderText = "Ngày Thêm";
        }

        private bool isAdding = false;

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (isAdding) return;

            try
            {
                isAdding = true;

                if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Tên sản phẩm và Tiêu đề không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                    var productVariant = new ProductVariant
                    {
                        product_id = product.product_id,
                        size_id = cmbSize.SelectedValue != null ? (int)cmbSize.SelectedValue : 0,
                        color_id = cmbColor.SelectedValue != null ? (int)cmbColor.SelectedValue : 0,
                        quantity = int.TryParse(txtQuantity.Text, out var qty) ? qty : 0
                    };

                    productVariantBLL.AddProductVariant(productVariant);

                    MessageBox.Show("Sản phẩm đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshProductGrid();
                    ResetInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isAdding = false;
            }
        }

        private void RefreshProductGrid()
        {
            LoadProducts();
            dataGridViewProducts.Refresh();
        }

        private void ResetInputFields()
        {
            txtProductName.Clear();
            txtTitle.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbSize.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            dtpDateAdd.Value = DateTime.Now;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;

            try
            {
                var selectedProduct = dataGridViewProducts.CurrentRow.DataBoundItem as Product;
                selectedProduct.product_name = txtProductName.Text;
                selectedProduct.category_id = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0;

                if (productBLL.EditProduct(selectedProduct))
                {
                    var productVariant = productVariantBLL.GetProductVariantById(selectedProduct.product_id);
                    if (productVariant != null)
                    {
                        productVariant.size_id = cmbSize.SelectedValue != null ? (int)cmbSize.SelectedValue : 0;
                        productVariant.color_id = cmbColor.SelectedValue != null ? (int)cmbColor.SelectedValue : 0;
                        productVariant.quantity = int.TryParse(txtQuantity.Text, out var qty) ? qty : productVariant.quantity;

                        if (productVariantBLL.EditProductVariant(productVariant))
                        {
                            MessageBox.Show("Sản phẩm và biến thể đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProducts();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật biến thể thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    var selectedProduct = dataGridViewProducts.CurrentRow.DataBoundItem as Product;

                    if (productBLL.RemoveProduct(selectedProduct.product_id) && productVariantBLL.RemoveProductVariant(selectedProduct.product_id))
                    {
                        MessageBox.Show("Sản phẩm và biến thể đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm hoặc biến thể thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;

            var selectedProduct = dataGridViewProducts.CurrentRow.DataBoundItem as Product;

            txtProductName.Text = selectedProduct?.product_name ?? string.Empty;
            txtPrice.Text = selectedProduct?.price.ToString() ?? "0";
            cmbCategory.SelectedValue = selectedProduct?.category_id ?? 0;
            txtTitle.Text = selectedProduct?.Title ?? string.Empty;

            var productVariant = selectedProduct?.ProductVariants.FirstOrDefault();
            cmbSize.SelectedValue = productVariant?.size_id ?? 0;
            cmbColor.SelectedValue = productVariant?.color_id ?? 0;
            txtQuantity.Text = productVariant?.quantity.ToString() ?? "0";

            dtpDateAdd.Value = selectedProduct?.Dateadd ?? DateTime.Now;
        }
    }
}
