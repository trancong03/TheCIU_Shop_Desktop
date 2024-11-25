using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmOrderManagement : Form
    {
        private readonly OrderBLL orderBLL = new OrderBLL();
        private readonly OrderDetailsBLL orderDetailsBLL = new OrderDetailsBLL();

        public FrmOrderManagement()
        {
            InitializeComponent();
            LoadOrders();

            // Đăng ký sự kiện cho ActionControl
            actionControl.AddClicked += ActionControl_AddClicked;
            actionControl.UpdateClicked += ActionControl_UpdateClicked;
            actionControl.DeleteClicked += ActionControl_DeleteClicked;
            actionControl.SearchClicked += ActionControl_SearchClicked;

            // Đăng ký sự kiện cho CustomDataGridViewControl
            customDataGridViewOrders.ViewOrderClicked += CustomDataGridViewOrders_ViewOrderClicked;
        }

        private void LoadOrders()
        {
            try
            {
                // Lấy danh sách đơn hàng và gán vào CustomDataGridViewControl
                customDataGridViewOrders.DataSource = orderBLL.GetAllOrders();
                customDataGridViewOrders.AddFilterButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_AddClicked(object sender, EventArgs e)
        {
            try
            {
                // Tạo mới đơn hàng
                Order order = new Order
                {
                    username = txtUsername.Text,
                    order_date = dateOrderDate.Value,
                    status = Convert.ToInt32(txtStatus.Text),
                    amount = Convert.ToDouble(txtAmount.Text)
                };

                // Thêm đơn hàng
                orderBLL.AddOrder(order);
                MessageBox.Show("Đơn hàng đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_UpdateClicked(object sender, EventArgs e)
        {
            try
            {
                // Cập nhật đơn hàng
                Order order = new Order
                {
                    order_id = Convert.ToInt32(txtOrderId.Text),
                    username = txtUsername.Text,
                    order_date = dateOrderDate.Value,
                    status = Convert.ToInt32(txtStatus.Text),
                    amount = Convert.ToDouble(txtAmount.Text)
                };

                orderBLL.EditOrder(order);
                MessageBox.Show("Đơn hàng đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_DeleteClicked(object sender, EventArgs e)
        {
            try
            {
                // Xóa đơn hàng
                int orderId = Convert.ToInt32(txtOrderId.Text);

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng '{orderId}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    orderBLL.RemoveOrder(orderId);
                    MessageBox.Show("Đơn hàng đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            try
            {
                // Tìm kiếm đơn hàng theo ID
                int orderId;
                if (int.TryParse(actionControl.SearchText, out orderId))
                {
                    Order order = orderBLL.GetOrderById(orderId);
                    if (order != null)
                    {
                        customDataGridViewOrders.DataSource = new List<Order> { order };
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                }
                else
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomDataGridViewOrders_ViewOrderClicked(object sender, int orderId)
        {
            try
            {
                // Lấy chi tiết đơn hàng từ BLL
                List<dynamic> orderDetails = orderDetailsBLL.GetOrderDetailsWithProductInfo(orderId);

                // Mở form chi tiết đơn hàng
                FrmOrderDetail orderDetailForm = new FrmOrderDetail(orderId, orderDetails);
                orderDetailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
