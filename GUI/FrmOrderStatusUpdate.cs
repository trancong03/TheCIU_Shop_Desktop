using BLL;
using CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class FrmOrderStatusUpdate : Form
    {
        private readonly OrderBLL orderBLL = new OrderBLL();
        private readonly OrderDetailsBLL orderDetailsBLL = new OrderDetailsBLL();
        private readonly VoucherBLL voucherBLL = new VoucherBLL();
        public FrmOrderStatusUpdate()
        {
            InitializeComponent();
            //Action Control
            actionControl.FilterChanged += ActionControl_FilterChanged;
            actionControl.AddButtonVisible = false;
            actionControl.DeleteButtonVisible = false;
            actionControl.UpdateButtonVisble = false;
            actionControl.ReloadButtonVisible = false;
            actionControl.SaveButtonVisible = false;
            // Btn
            btnConfirmOrders.Click += BtnConfirmOrders_Click;
            btnCancelOrders.Click += BtnCancelOrders_Click;
            btnCompleteOrders.Click += BtnCompleteOrders_Click;
            btnShipOrders.Click += BtnShipOrders_Click;
            // DataGridView
            dataGridViewOrderDetails.CellClick += DataGridViewOrderDetails_CellClick;

            LoadFilterOptions();
            LoadStatusOptions();
            LoadOrdersByStatus();

        }

        private void BtnShipOrders_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dòng được chọn từ dataGridViewConfirmedOrders
                if (dataGridViewConfirmedOrders.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewConfirmedOrders.SelectedRows[0];
                    int orderId = Convert.ToInt32(selectedRow.Cells["OrderId"].Value);

                    // Gọi BLL để cập nhật trạng thái đơn hàng sang "Giao hàng" (status = 3)
                    bool isUpdated = orderBLL.UpdateOrderStatus(orderId, 3); // 3 là trạng thái "Giao hàng"

                    if (isUpdated)
                    {
                        MessageBox.Show("Đơn hàng đã được chuyển sang trạng thái Giao hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu
                        LoadOrdersByStatus();
                    }
                    else
                    {
                        MessageBox.Show("Không thể chuyển trạng thái đơn hàng. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần chuyển sang Giao hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển trạng thái Giao hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCompleteOrders_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dòng được chọn từ dataGridViewShippingOrders
                if (dataGridViewShippingOrders.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewShippingOrders.SelectedRows[0];
                    int orderId = Convert.ToInt32(selectedRow.Cells["OrderId"].Value);

                    // Gọi BLL để cập nhật trạng thái đơn hàng sang "Hoàn tất" (status = 4)
                    bool isUpdated = orderBLL.UpdateOrderStatus(orderId, 4); // 4 là trạng thái "Hoàn tất"

                    if (isUpdated)
                    {
                        MessageBox.Show("Đơn hàng đã được hoàn tất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu
                        LoadOrdersByStatus();
                    }
                    else
                    {
                        MessageBox.Show("Không thể chuyển trạng thái đơn hàng. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần hoàn tất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn tất đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelOrders_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dòng được chọn từ dataGridViewPendingOrders
                if (dataGridViewPendingOrders.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewPendingOrders.SelectedRows[0];
                    int orderId = Convert.ToInt32(selectedRow.Cells["OrderId"].Value);

                    // Gọi BLL để cập nhật trạng thái đơn hàng sang "Hủy" (status = 0)
                    bool isUpdated = orderBLL.UpdateOrderStatus(orderId, 0); // 0 là trạng thái "Hủy"

                    if (isUpdated)
                    {
                        MessageBox.Show("Đơn hàng đã bị hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu sau khi cập nhật
                        LoadOrdersByStatus();
                    }
                    else
                    {
                        MessageBox.Show("Không thể hủy đơn hàng. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirmOrders_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dòng được chọn từ dataGridViewPendingOrders
                if (dataGridViewPendingOrders.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewPendingOrders.SelectedRows[0];
                    int orderId = Convert.ToInt32(selectedRow.Cells["OrderId"].Value);

                    // Gọi BLL để cập nhật trạng thái đơn hàng sang "Xác nhận" (status = 2)
                    bool isUpdated = orderBLL.UpdateOrderStatus(orderId, 2); // 2 là trạng thái "Xác nhận"

                    if (isUpdated)
                    {
                        MessageBox.Show("Đơn hàng đã được xác nhận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu sau khi cập nhật
                        LoadOrdersByStatus();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xác nhận đơn hàng. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo dòng được chọn là hợp lệ
            {
                try
                {
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = dataGridViewOrderDetails.Rows[e.RowIndex];


                    FillControlsFromSelectedRowOrder(selectedRow); // Điền thông tin vào các control
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void FillControlsFromSelectedRowOrder(DataGridViewRow selectedRow)
        {
            try
            {
                // Gán dữ liệu vào các control
                txtName.Text = selectedRow.Cells["CustomerName"].Value?.ToString() ?? string.Empty;
                dateOrderDate.Value = DateTime.TryParse(selectedRow.Cells["OrderDate"].Value?.ToString(), out DateTime orderDate) ? orderDate : DateTime.Now;
                txtAddressDeliver.Text = selectedRow.Cells["AddressDeliver"].Value?.ToString() ?? string.Empty;

                // Gán trạng thái vào ComboBox
                if (int.TryParse(selectedRow.Cells["StatusId"].Value?.ToString(), out int statusId))
                {
                    cboStatus.SelectedValue = statusId; // Gán giá trị theo `ValueMember`
                }
                else
                {
                    cboStatus.SelectedIndex = -1; // Nếu không hợp lệ, xóa lựa chọn
                }

                // Gán giá trị Amount vào CurrencyTextBox
                if (decimal.TryParse(selectedRow.Cells["Amount"].Value?.ToString(), out decimal amount))
                {
                    txtAmount.Value = amount;
                }
                else
                {
                    txtAmount.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi điền dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActionControl_FilterChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giá trị FilterValueMember
                if (actionControl.SelectedFilterValue is int selectedStatus && selectedStatus >= 1 && selectedStatus <= 4)
                {
                    // Tải dữ liệu với trạng thái được chọn
                    LoadOrders(selectedStatus);
                }
                else
                {
                    //MessageBox.Show("Không có trạng thái hợp lệ để tải dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewOrderDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStatusOptions()
        {
            // Tạo danh sách trạng thái thủ công
            var statusOptions = new[]
            {
                new { StatusId = 0, StatusName = "Hủy" },
                new { StatusId = 1, StatusName = "Chờ xử lý" },
                new { StatusId = 2, StatusName = "Xác nhận" },
                new { StatusId = 3, StatusName = "Giao hàng" },
                new { StatusId = 4, StatusName = "Hoàn tất" },


            }.ToList();

            // Gán danh sách vào ComboBox
            cboStatus.DataSource = statusOptions;
            cboStatus.DisplayMember = "StatusName";
            cboStatus.ValueMember = "StatusId";
        }
        private void LoadFilterOptions()
        {
            // Thêm các tùy chọn lọc trạng thái đơn hàng
            var filterOptions = new[]
            {
                new { status = 0, name = "Đơn hàng bị hủy" },
                new { status = 1, name = "Chờ xử lý" },
                new { status = 2, name = "Xác nhận" },
                new { status = 3, name = "Giao hàng" },
                new { status = 4, name = "Hoàn tất" }
            }.ToList();

            actionControl.FilterDataSource = filterOptions;
            actionControl.FilterDisplayMember = "name";
            actionControl.FilterValueMember = "status";

            // Đặt giá trị mặc định ban đầu cho bộ lọc
            actionControl.SetSelectedFilterValue(1); // Mặc định là "Chờ xử lý"
            LoadOrders(1); // Tải dữ liệu với trạng thái mặc định
        }

        private void LoadOrders(int? statusFilter = null)
        {
            try
            {
                // Kiểm tra nếu trạng thái không hợp lệ
                if (statusFilter.HasValue && (statusFilter < 1 || statusFilter > 4))
                {
                    MessageBox.Show("Trạng thái không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridViewOrderDetails.DataSource = null; // Xóa dữ liệu
                    return;
                }

                // Gọi BLL để lấy danh sách đơn hàng theo trạng thái
                var orders = orderBLL.GetOrderDetailsByStatus(statusFilter).Select(order => new
                {
                    OrderId = order.OrderId, // Cột ẩn
                    Username = order.Username,
                    CustomerName = order.CustomerName ?? "Không rõ",
                    OrderDate = order.OrderDate?.ToString("dd/MM/yyyy") ?? "Không có ngày đặt",
                    StatusText = GetStatusText(order.Status), // Hiển thị trạng thái dạng chữ
                    StatusId = order.Status, // Trạng thái nội bộ
                    PaymentDate = order.PaymentDate?.ToString("dd/MM/yyyy") ?? "Chưa thanh toán",
                    VoucherId = order.VoucherId, // Cột ẩn
                    VoucherName = order.VoucherName ?? "Không có",
                    Amount = order.Amount,
                    AddressDeliver = order.AddressDeliver,
                    VariantId = order.VariantId, // Cột ẩn
                    ProductName = order.ProductName,
                    Quantity = order.Quantity,
                    Subtotal = order.Subtotal,
                    ColorName = order.ColorName,
                    SizeName = order.SizeName
                }).ToList();

                // Kiểm tra nếu không có dữ liệu phù hợp
                if (!orders.Any())
                {
                    MessageBox.Show("Không có đơn hàng nào phù hợp với bộ lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewOrderDetails.DataSource = null; // Xóa dữ liệu
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dataGridViewOrderDetails.DataSource = orders;

                // Cấu hình cột hiển thị
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetStatusText(int status)
        {
            switch (status) {
                case 0:
                    return "Hủy đơn hàng";
                case 1:
                    return "Chờ xử lý";
                case 2:
                    return "Xác nhận";
                case 3:
                    return "Giao hàng";
                case 4:
                    return "Hoàn tất";
                default:
                    return "Không xác định";

            }         
        }
        private void LoadOrdersByStatus()
        {
            try
            {
                // Lấy danh sách đơn hàng theo trạng thái
                var pendingOrders = orderBLL.GetOrderDetailsByStatus(1); // Chờ xử lý
                var confirmedOrders = orderBLL.GetOrderDetailsByStatus(2); // Xác nhận
                var shippingOrders = orderBLL.GetOrderDetailsByStatus(3); // Giao hàng
                var completedOrders = orderBLL.GetOrderDetailsByStatus(4); // Hoàn tất

                // Gán dữ liệu vào từng DataGridView
                dataGridViewPendingOrders.DataSource = pendingOrders.Select(order => new
                {
                    order.OrderId,
                    order.CustomerName,
                    OrderDate = order.OrderDate?.ToString("dd/MM/yyyy") ?? "Không có ngày đặt",
                    StatusText = GetStatusText(order.Status),
                    PaymentDate = order.PaymentDate?.ToString("dd/MM/yyyy") ?? "Chưa thanh toán",
                    VoucherName = order.VoucherName ?? "Không có",
                    order.Amount,
                    order.AddressDeliver,
                    order.ProductName,
                    order.Quantity,
                    order.Subtotal
                }).ToList();

                dataGridViewConfirmedOrders.DataSource = confirmedOrders.Select(order => new
                {
                    order.OrderId,
                    order.CustomerName,
                    OrderDate = order.OrderDate?.ToString("dd/MM/yyyy") ?? "Không có ngày đặt",
                    StatusText = GetStatusText(order.Status),
                    PaymentDate = order.PaymentDate?.ToString("dd/MM/yyyy") ?? "Chưa thanh toán",
                    VoucherName = order.VoucherName ?? "Không có",
                    order.Amount,
                    order.AddressDeliver,
                    order.ProductName,
                    order.Quantity,
                    order.Subtotal
                }).ToList();

                dataGridViewShippingOrders.DataSource = shippingOrders.Select(order => new
                {
                    order.OrderId,
                    order.CustomerName,
                    OrderDate = order.OrderDate?.ToString("dd/MM/yyyy") ?? "Không có ngày đặt",
                    StatusText = GetStatusText(order.Status),
                    PaymentDate = order.PaymentDate?.ToString("dd/MM/yyyy") ?? "Chưa thanh toán",
                    VoucherName = order.VoucherName ?? "Không có",
                    order.Amount,
                    order.AddressDeliver,
                    order.ProductName,
                    order.Quantity,
                    order.Subtotal
                }).ToList();

                dataGridViewCompletedOrders.DataSource = completedOrders.Select(order => new
                {
                    order.OrderId,
                    order.CustomerName,
                    OrderDate = order.OrderDate?.ToString("dd/MM/yyyy") ?? "Không có ngày đặt",
                    StatusText = GetStatusText(order.Status),
                    PaymentDate = order.PaymentDate?.ToString("dd/MM/yyyy") ?? "Chưa thanh toán",
                    VoucherName = order.VoucherName ?? "Không có",
                    order.Amount,
                    order.AddressDeliver,
                    order.ProductName,
                    order.Quantity,
                    order.Subtotal
                }).ToList();

                // Cấu hình cột hiển thị cho từng DataGridView
                ConfigureDataGridViewColumns(dataGridViewPendingOrders);
                ConfigureDataGridViewColumns(dataGridViewConfirmedOrders);
                ConfigureDataGridViewColumns(dataGridViewShippingOrders);
                ConfigureDataGridViewColumns(dataGridViewCompletedOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureDataGridViewColumns(DataGridView dataGridView)
        {
            // Ẩn các cột không cần thiết
            dataGridView.Columns["OrderId"].Visible = false;

            // Đặt tên hiển thị cho các cột
            dataGridView.Columns["CustomerName"].HeaderText = "Khách hàng";
            dataGridView.Columns["OrderDate"].HeaderText = "Ngày đặt";
            dataGridView.Columns["StatusText"].HeaderText = "Trạng thái";
            dataGridView.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
            dataGridView.Columns["VoucherName"].HeaderText = "Voucher";
            dataGridView.Columns["Amount"].HeaderText = "Tổng tiền";
            dataGridView.Columns["AddressDeliver"].HeaderText = "Địa chỉ giao";
            dataGridView.Columns["ProductName"].HeaderText = "Sản phẩm";
            dataGridView.Columns["Quantity"].HeaderText = "Số lượng";
            dataGridView.Columns["Subtotal"].HeaderText = "Thành tiền";


            // Thiết lập độ rộng cột
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void ConfigureDataGridViewColumns()
        {
            // Ẩn các cột không cần thiết
            dataGridViewOrderDetails.Columns["OrderId"].Visible = false;
            dataGridViewOrderDetails.Columns["StatusId"].Visible = false;
            dataGridViewOrderDetails.Columns["VoucherId"].Visible = false;
            dataGridViewOrderDetails.Columns["VariantId"].Visible = false;

            // Đặt tên hiển thị cho các cột
            dataGridViewOrderDetails.Columns["CustomerName"].HeaderText = "Khách hàng";
            dataGridViewOrderDetails.Columns["OrderDate"].HeaderText = "Ngày đặt";
            dataGridViewOrderDetails.Columns["StatusText"].HeaderText = "Trạng thái";
            dataGridViewOrderDetails.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
            dataGridViewOrderDetails.Columns["VoucherName"].HeaderText = "Voucher";
            dataGridViewOrderDetails.Columns["Amount"].HeaderText = "Tổng tiền";
            dataGridViewOrderDetails.Columns["AddressDeliver"].HeaderText = "Địa chỉ giao";
            dataGridViewOrderDetails.Columns["ProductName"].HeaderText = "Sản phẩm";
            dataGridViewOrderDetails.Columns["Quantity"].HeaderText = "Số lượng";
            //dataGridViewOrderDetails.Columns["Subtotal"].HeaderText = "Thành tiền";
            //dataGridViewOrderDetails.Columns["ColorName"].HeaderText = "Màu sắc";
            //dataGridViewOrderDetails.Columns["SizeName"].HeaderText = "Kích cỡ";

            dataGridViewOrderDetails.Columns["Subtotal"].Visible = false;
            dataGridViewOrderDetails.Columns["ColorName"].Visible = false;
            dataGridViewOrderDetails.Columns["SizeName"].Visible = false;


            // Thiết lập độ rộng cột

            dataGridViewOrderDetails.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

    }
}
