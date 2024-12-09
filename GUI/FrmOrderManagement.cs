using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmOrderManagement : Form
    {
        private readonly OrderBLL orderBLL = new OrderBLL();
        private readonly OrderDetailsBLL orderDetailsBLL = new OrderDetailsBLL();
        private readonly VoucherBLL voucherBLL = new VoucherBLL();

        public FrmOrderManagement()
        {
            InitializeComponent();
            this.Resize += FrmOrderManagement_Resize;
            // Tùy chỉnh vị trí và kích thước của Filter và Search
            actionControl.FilterLocation = new System.Drawing.Point(450, 10); // Vị trí ComboBox Filter
            actionControl.FilterSize = new System.Drawing.Size(150, 30); // Kích thước ComboBox Filter

            actionControl.SearchButtonLocation = new System.Drawing.Point(300, 10); // Vị trí nút Tìm kiếm
            actionControl.SearchButtonSize = new System.Drawing.Size(100, 30);
            // Đăng ký sự kiện cho ActionControl
            actionControl.AddButtonVisible = false;
            actionControl.UpdateButtonVisible = false;
            actionControl.DeleteButtonVisible = false;
            actionControl.SaveButtonVisible = false;
            actionControl.ReloadButtonVisible = false;
            actionControl.PrintButtonVisible = false;
            actionControl.ExcelButtonVisible = false;

            actionControl.FilterChanged += ActionControl_FilterChanged;
            actionControl.SearchClicked += ActionControl_SearchClicked;
            dataGridViewOrders.CellClick += DataGridViewOrders_CellClick;
            dataGridViewOrderDetails.CellClick += DataGridViewOrderDetails_CellClick;


            LoadFilterOptions();
            LoadStatusOptions();

        }

        private void FrmOrderManagement_Resize(object sender, EventArgs e)
        {
            AdjustControlLayout();
        }

        private void AdjustControlLayout()
        {
            int margin = 10;

            // Lấy kích thước form hiện tại
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Điều chỉnh kích thước và vị trí của GroupBox Order
            groupBoxOrder.Width = formWidth - 2 * margin;
            groupBoxOrder.Location = new System.Drawing.Point(margin, margin);

            // Điều chỉnh ActionControl
            actionControl.Width = formWidth - 2 * margin;
            actionControl.Location = new System.Drawing.Point(margin, groupBoxOrder.Bottom + margin);

            // Điều chỉnh DataGridView Orders
            dataGridViewOrders.Width = formWidth - 2 * margin;
            dataGridViewOrders.Height = (formHeight - actionControl.Bottom - margin) / 2 - 10;
            dataGridViewOrders.Location = new System.Drawing.Point(margin, actionControl.Bottom + margin);

            // Điều chỉnh GroupBox OrderDetails
            groupBoxOrderDetails.Width = formWidth - 2 * margin;
            groupBoxOrderDetails.Location = new System.Drawing.Point(margin, dataGridViewOrders.Bottom + margin);

            // Điều chỉnh DataGridView OrderDetails
            dataGridViewOrderDetails.Width = formWidth - 2 * margin;
            dataGridViewOrderDetails.Height = formHeight - groupBoxOrderDetails.Bottom - margin - 10;
            dataGridViewOrderDetails.Location = new System.Drawing.Point(margin, groupBoxOrderDetails.Bottom + margin);
        }

        private void ActionControl_SearchClicked(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox của ActionControl
                string keyword = actionControl.SearchText?.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi BLL để tìm kiếm đơn hàng
                var searchResults = orderBLL.SearchOrders(keyword).Select(order => new
                {
                    order.OrderId,
                    order.Username,
                    order.CustomerName,
                    OrderDate = order.OrderDate.HasValue ? order.OrderDate.Value.ToString("dd/MM/yyyy") : "Không có ngày đặt",
                    StatusText = GetStatusText(order.Status), // Hiển thị trạng thái
                    StatusId = order.Status, // Dùng để xử lý nội bộ
                    PaymentDate = order.PaymentDate.HasValue ? order.PaymentDate.Value.ToString("dd/MM/yyyy") : "Chưa hiển thị ngày",
                    VoucherId = order.VoucherId, // Dùng nội bộ
                    VoucherName = order.VoucherName ?? "Không có",
                    order.Amount,
                    order.AddressDeliver,
                    order.VariantId, // Ẩn cột này
                    order.ProductName, // Ẩn cột này
                    order.Quantity, // Ẩn cột này
                    order.Subtotal, // Ẩn cột này
                    order.ColorName, // Ẩn cột này
                    order.SizeName // Ẩn cột này
                }).ToList();

                // Kiểm tra nếu không có kết quả phù hợp
                if (!searchResults.Any())
                {
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewOrders.DataSource = null; // Xóa dữ liệu trên DataGridView
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dataGridViewOrders.DataSource = searchResults;

                // Cấu hình các cột hiển thị
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigureDataGridViewColumns()
        {
            // Kiểm tra và ẩn các cột không cần thiết
            if (dataGridViewOrders.Columns["OrderId"] != null)
                dataGridViewOrders.Columns["OrderId"].Visible = false;

            if (dataGridViewOrders.Columns["Username"] != null)
                dataGridViewOrders.Columns["Username"].Visible = false;

            if (dataGridViewOrders.Columns["StatusId"] != null)
                dataGridViewOrders.Columns["StatusId"].Visible = false;

            if (dataGridViewOrders.Columns["VoucherId"] != null)
                dataGridViewOrders.Columns["VoucherId"].Visible = false;

            if (dataGridViewOrders.Columns["VariantId"] != null)
                dataGridViewOrders.Columns["VariantId"].Visible = false;

            if (dataGridViewOrders.Columns["ProductName"] != null)
                dataGridViewOrders.Columns["ProductName"].Visible = false;

            if (dataGridViewOrders.Columns["Quantity"] != null)
                dataGridViewOrders.Columns["Quantity"].Visible = false;

            if (dataGridViewOrders.Columns["Subtotal"] != null)
                dataGridViewOrders.Columns["Subtotal"].Visible = false;

            if (dataGridViewOrders.Columns["ColorName"] != null)
                dataGridViewOrders.Columns["ColorName"].Visible = false;

            if (dataGridViewOrders.Columns["SizeName"] != null)
                dataGridViewOrders.Columns["SizeName"].Visible = false;

            // Tự động điều chỉnh kích thước cột
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt tiêu đề cho các cột hiển thị
            if (dataGridViewOrders.Columns["CustomerName"] != null)
                dataGridViewOrders.Columns["CustomerName"].HeaderText = "Tên khách hàng";

            if (dataGridViewOrders.Columns["OrderDate"] != null)
                dataGridViewOrders.Columns["OrderDate"].HeaderText = "Ngày đặt";

            if (dataGridViewOrders.Columns["StatusText"] != null)
                dataGridViewOrders.Columns["StatusText"].HeaderText = "Trạng thái";

            if (dataGridViewOrders.Columns["PaymentDate"] != null)
                dataGridViewOrders.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";

            if (dataGridViewOrders.Columns["VoucherName"] != null)
                dataGridViewOrders.Columns["VoucherName"].HeaderText = "Voucher";

            if (dataGridViewOrders.Columns["Amount"] != null)
                dataGridViewOrders.Columns["Amount"].HeaderText = "Tổng tiền";

            if (dataGridViewOrders.Columns["AddressDeliver"] != null)
                dataGridViewOrders.Columns["AddressDeliver"].HeaderText = "Địa chỉ giao hàng";
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

        private void DataGridViewOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng dòng được chọn là hợp lệ
            {
                try
                {
                    // Lấy dữ liệu từ dòng được chọn
                    DataGridViewRow selectedRow = dataGridViewOrderDetails.Rows[e.RowIndex];

                    // Gán dữ liệu vào các control chi tiết đơn hàng
                    txtProductName.Text = selectedRow.Cells["ProductName"].Value?.ToString() ?? string.Empty;
                    txtQuantity.Text = selectedRow.Cells["Quantity"].Value?.ToString() ?? string.Empty;

                    // Gán giá trị Subtotal vào CurrencyTextBox
                    if (decimal.TryParse(selectedRow.Cells["Subtotal"].Value?.ToString(), out decimal subtotal))
                    {
                        txtSubtotal.Value = subtotal; // Sử dụng thuộc tính `Value` của CurrencyTextBox
                    }
                    else
                    {
                        txtSubtotal.Clear(); // Nếu không hợp lệ, xóa nội dung
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi điền dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Đảm bảo dòng được chọn là hợp lệ
            {
                try
                {
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = dataGridViewOrders.Rows[e.RowIndex];

                    // Tải chi tiết đơn hàng và điền vào control
                    int orderId = Convert.ToInt32(selectedRow.Cells["OrderId"].Value);
                    LoadOrderDetails(orderId); // Tải chi tiết đơn hàng
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




        private void LoadFilterOptions()
        {
            // Thêm các tùy chọn lọc trạng thái đơn hàng
            var filterOptions = new[]
            {
                new { status = 1, name = "Chờ xử lý" },
                new { status = 2, name = "Xác nhận" },
                new { status = 3, name = "Giao hàng" },
                new { status = 4, name = "Hoàn tất" }
            }.ToList();

            actionControl.FilterDataSource = filterOptions;
            actionControl.FilterDisplayMember = "name";
            actionControl.FilterValueMember = "status";

            // Đặt giá trị mặc định ban đầu cho bộ lọc
            actionControl.SetSelectedFilterValue(1); // Sử dụng phương thức để đặt giá trị
            LoadOrders(1); // Tải dữ liệu với trạng thái mặc định
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
                    dataGridViewOrders.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadOrders(int? statusFilter = null)
        {
            try
            {
                // Kiểm tra nếu trạng thái không hợp lệ
                if (statusFilter.HasValue && (statusFilter < 1 || statusFilter > 4))
                {
                    MessageBox.Show("Trạng thái không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridViewOrders.DataSource = null; // Xóa dữ liệu
                    return;
                }

                // Gọi BLL để lấy danh sách đơn hàng theo trạng thái
                var orders = orderBLL.GetOrderDetailsByStatus(statusFilter).Select(order => new
                {
                    order.OrderId,
                    order.Username,
                    order.CustomerName,
                    OrderDate = order.OrderDate.HasValue ? order.OrderDate.Value.ToString("dd/MM/yyyy") : "Không có ngày đặt",
                    StatusText = GetStatusText(order.Status), // Hiển thị trạng thái
                    StatusId = order.Status, // Dùng để xử lý nội bộ
                    PaymentDate = order.PaymentDate.HasValue ? order.PaymentDate.Value.ToString("dd/MM/yyyy") : "Chưa hiển thị ngày",
                    VoucherId = order.VoucherId, // Dùng nội bộ
                    VoucherName = order.VoucherName ?? "Không có",
                    order.Amount,
                    order.AddressDeliver,
                    order.VariantId, // Ẩn cột này
                    order.ProductName, 
                    order.Quantity, 
                    order.Subtotal, 
                    order.ColorName, 
                    order.SizeName 
                }).ToList();

                // Kiểm tra nếu không có dữ liệu phù hợp
                if (!orders.Any())
                {
                    MessageBox.Show("Không có đơn hàng nào phù hợp với bộ lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewOrders.DataSource = null; // Xóa dữ liệu
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dataGridViewOrders.DataSource = orders;

                // Cấu hình cột hiển thị
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Tải chi tiết đơn hàng vào DataGridView
        /// </summary>
        /// <param name="orderId">Mã đơn hàng</param>
        private void LoadOrderDetails(int orderId)
        {
            try
            {
                var orderDetails = orderDetailsBLL.GetOrderDetailsByOrderId(orderId).Select(detail => new
                {
                    detail.VariantId,
                    detail.ProductName,
                    detail.Quantity,
                    detail.Subtotal
                }).ToList();

                dataGridViewOrderDetails.DataSource = orderDetails;
                dataGridViewOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ẩn cột không cần hiển thị
                if (dataGridViewOrderDetails.Columns["VariantId"] != null)
                    dataGridViewOrderDetails.Columns["VariantId"].Visible = false;

                // Thiết lập tiêu đề cột
                dataGridViewOrderDetails.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dataGridViewOrderDetails.Columns["Quantity"].HeaderText = "Số lượng";
                dataGridViewOrderDetails.Columns["Subtotal"].HeaderText = "Thành tiền";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lấy trạng thái đơn hàng dưới dạng chuỗi
        /// </summary>
        private string GetStatusText(int? status)
        {
            switch (status)
            {
                case 0:
                    return "Hủy";
                    
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






    }
}
