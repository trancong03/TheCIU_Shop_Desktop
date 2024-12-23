﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

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

                // Tạo danh sách danh mục với tùy chọn "Tất cả"
                var categoryList = new List<Category>
        {
            new Category { category_id = 0, category_name = "Tất cả" }
        };
                categoryList.AddRange(categories);

                // Gán dữ liệu vào ComboBox
                cmbCategories.DataSource = categoryList;
                cmbCategories.DisplayMember = "category_name"; // Tên thuộc tính đúng
                cmbCategories.ValueMember = "category_id";     // Tên thuộc tính đúng
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
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Mã sản phẩm",
                    DataPropertyName = "ProductId",
                    Visible = false // Ẩn cột ProductId
                });
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tên sản phẩm",
                    DataPropertyName = "ProductName",
                    Width = 200
                });
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Mã biến thể",
                    DataPropertyName = "VariantId",
                    Visible = false // Ẩn cột VariantId
                });
                dgvStock.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tồn kho",
                    DataPropertyName = "TotalStock",
                    Width = 100
                });

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
