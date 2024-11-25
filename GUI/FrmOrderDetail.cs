using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmOrderDetail : Form
    {
        private readonly int orderId;
        OrderDetailsBLL orderDetailsBLL = new OrderDetailsBLL();
        private readonly List<dynamic> orderDetails;

        public FrmOrderDetail(int orderId, List<dynamic> orderDetails)
        {
            InitializeComponent();
            this.orderId = orderId;
            this.orderDetails = orderDetails;

            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                dgvOrderDetails.AutoGenerateColumns = false; // Ngừng tự động tạo cột
                dgvOrderDetails.Columns.Clear(); // Xóa các cột hiện tại để tránh trùng lặp

                // Tạo cột ProductName
                var productNameColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Tên Sản Phẩm",
                    DataPropertyName = "ProductName", 
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                dgvOrderDetails.Columns.Add(productNameColumn);

                // Tạo các cột khác
                dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Số Lượng",
                    DataPropertyName = "Quantity",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Subtotal",
                    HeaderText = "Thành Tiền",
                    DataPropertyName = "Subtotal",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Size",
                    HeaderText = "Kích Cỡ",
                    DataPropertyName = "Size",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Color",
                    HeaderText = "Màu Sắc",
                    DataPropertyName = "Color",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                // Gán dữ liệu
                dgvOrderDetails.DataSource = orderDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvOrderDetails.Rows[e.RowIndex];
                //txtProductId.Text = row.Cells["ProductId"].Value?.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();
                txtPrice.Text = row.Cells["Subtotal"].Value?.ToString();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int productId = int.Parse(txtProductId.Text);
            //    int quantity = int.Parse(txtQuantity.Text);
            //    decimal price = decimal.Parse(txtPrice.Text);

            //    var detailToUpdate = orderDetails.FirstOrDefault(d => d.ProductId == productId);
            //    if (detailToUpdate != null)
            //    {
            //        detailToUpdate.Quantity = quantity;
            //        detailToUpdate.Price = price;

            //        // Refresh DataGridView
            //        dgvOrderDetails.Refresh();
            //        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

    }
}
