using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmStockManagement : Form
    {
        private readonly ProductBLL productBLL;
        private readonly CategoryBLL categoryBLL;

        public FrmStockManagement()
        {
            InitializeComponent();

            productBLL = new ProductBLL();
            categoryBLL = new CategoryBLL();

            LoadCategories();
            LoadStockData();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = categoryBLL.GetAllCategories();
                var categoryList = new List<dynamic>
                {
                    new { CategoryId = 0, CategoryName = "Tất cả" }
                };
                categoryList.AddRange(categories.Select(c => new { c.category_id, c.category_name }));

                cmbCategories.DataSource = categoryList;
                cmbCategories.DisplayMember = "CategoryName";
                cmbCategories.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStockData(string search = "", int? categoryId = null)
        {
            try
            {
                // Lấy danh sách sản phẩm từ BLL
                var products = productBLL.GetAllProducts();

                // Lọc theo từ khóa và danh mục (nếu có)
                if (!string.IsNullOrEmpty(search))
                {
                    products = products.Where(p => p.product_name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                if (categoryId.HasValue && categoryId > 0)
                {
                    products = products.Where(p => p.category_id == categoryId).ToList();
                }

                // Tính tồn kho cho từng sản phẩm
                var stockData = products.SelectMany(product =>
                {
                    var stockByProduct = productBLL.GetStockByProductId(product.product_id);
                    return new List<dynamic>
                    {
                        new
                        {
                            ProductId = product.product_id,
                            ProductName = product.product_name,
                            VariantId = product.product_id,
                            TotalStock = stockByProduct
                        }
                    };
                }).ToList();

                // Kiểm tra nếu không có dữ liệu tồn kho
                if (!stockData.Any())
                {
                    MessageBox.Show("Không có dữ liệu tồn kho để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvStock.DataSource = null;
                    return;
                }

                // Bind dữ liệu vào DataGridView
                dgvStock.DataSource = stockData;

                // Định nghĩa cột
                dgvStock.Columns.Clear();
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã sản phẩm", DataPropertyName = "ProductId", Width = 100 });
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sản phẩm", DataPropertyName = "ProductName", Width = 200 });
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã biến thể", DataPropertyName = "VariantId", Width = 150 });
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tồn kho", DataPropertyName = "TotalStock", Width = 100 });

                // Cấu hình DataGridView
                dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStock.AllowUserToAddRows = false;
                dgvStock.ReadOnly = true;
                dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu tồn kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text.Trim();
            var categoryId = (int)cmbCategories.SelectedValue;

            LoadStockData(search, categoryId == 0 ? (int?)null : categoryId);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            cmbCategories.SelectedIndex = 0;

            LoadStockData();
        }
    }
}
