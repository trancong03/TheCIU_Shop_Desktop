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
        private readonly StockBLL stockBLL;

        public FrmStockManagement()
        {
            InitializeComponent();


            productBLL = new ProductBLL();
            categoryBLL = new CategoryBLL();
            stockBLL = new StockBLL();


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

        /// <summary>
        /// Load stock data into the DataGridView.
        /// </summary>
        /// <param name="search">Search keyword.</param>
        /// <param name="categoryId">Category ID for filtering.</param>
        private void LoadStockData(string search = "", int? categoryId = null)
        {
            try
            {
                var stockData = stockBLL.GetStockData(search, categoryId);

                dgvStock.DataSource = stockData;

                // Format DataGridView
                dgvStock.Columns["ProductId"].HeaderText = "Mã sản phẩm";
                dgvStock.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvStock.Columns["CategoryId"].HeaderText = "Mã danh mục";
                dgvStock.Columns["TotalStock"].HeaderText = "Tồn kho";

                dgvStock.Columns["ProductId"].Width = 100;
                dgvStock.Columns["ProductName"].Width = 200;
                dgvStock.Columns["CategoryId"].Width = 150;
                dgvStock.Columns["TotalStock"].Width = 100;

                dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStock.AutoGenerateColumns = true;
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

            LoadStockData(search, categoryId == 0 ? null : categoryId);
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            cmbCategories.SelectedIndex = 0;

            LoadStockData();
        }
    }
}
