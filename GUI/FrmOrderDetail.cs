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
        private readonly List<OrderDetail> orderDetails;
        OrderDetailsBLL orderDetailsBLL = new OrderDetailsBLL();

        public FrmOrderDetail(int orderId, List<OrderDetail> orderDetails)
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
                var orderDetails = orderDetailsBLL.GetOrderDetailsWithProductInfo(orderId);
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
                txtProductId.Text = row.Cells["ProductId"].Value?.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();
                txtPrice.Text = row.Cells["Price"].Value?.ToString();
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
