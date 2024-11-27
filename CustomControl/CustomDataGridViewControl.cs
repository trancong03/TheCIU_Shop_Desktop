using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class CustomDataGridViewControl : UserControl
    {
        // Sự kiện khi nhấn nút "Xem"
        public event EventHandler<int> ViewOrderClicked;

        public CustomDataGridViewControl()
        {
            InitializeComponent();
            ConfigureActionColumn();
        }

        // Gán hoặc lấy DataSource
        public object DataSource
        {
            get => customDataGridView.DataSource;
            set
            {
                customDataGridView.DataSource = value;

                // Gắn `Tag` cho từng hàng
                foreach (DataGridViewRow row in customDataGridView.Rows)
                {
                    if (row.DataBoundItem != null)
                    {
                        // Dùng Reflection hoặc dynamic để gắn `order_id`
                        var orderIdProperty = row.DataBoundItem.GetType().GetProperty("order_id");
                        if (orderIdProperty != null)
                        {
                            var orderIdValue = orderIdProperty.GetValue(row.DataBoundItem);
                            if (orderIdValue != null && int.TryParse(orderIdValue.ToString(), out int orderId))
                            {
                                row.Tag = orderId; // Gắn `order_id` vào `Tag` của hàng
                            }
                        }
                    }
                }

                ConfigureActionColumn(); // Thêm cột "Thao Tác"
            }
        }

        // Các thuộc tính tiện ích
        public DataGridViewRowCollection Rows => customDataGridView.Rows;

        public DataGridViewColumnCollection Columns => customDataGridView.Columns;

        public DataGridViewSelectedRowCollection SelectedRows => customDataGridView.SelectedRows;

        // Thêm hàng mới vào DataGridView
        public void AddRow(object[] values, object tag = null)
        {
            var row = new DataGridViewRow();
            row.CreateCells(customDataGridView, values);
            row.Tag = tag; // Lưu thông tin bổ sung vào Tag
            customDataGridView.Rows.Add(row);
        }

        // Xóa tất cả các hàng trong DataGridView
        public void ClearRows()
        {
            customDataGridView.Rows.Clear();
        }

        // Thêm cột "Thao Tác" (nếu chưa tồn tại)
        private void ConfigureActionColumn()
        {
            if (!customDataGridView.Columns.Contains("ActionColumn"))
            {
                var actionColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Thao Tác",
                    Name = "ActionColumn",
                    Text = "Xem",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                customDataGridView.Columns.Add(actionColumn); // Thêm cột vào cuối
            }
            else
            {
                // Nếu cột đã tồn tại, di chuyển nó về cuối
                customDataGridView.Columns["ActionColumn"].DisplayIndex = customDataGridView.Columns.Count - 1;
            }

            // Đăng ký lại sự kiện CellContentClick
            customDataGridView.CellContentClick -= CustomDataGridView_CellContentClick;
            customDataGridView.CellContentClick += CustomDataGridView_CellContentClick;
        }

        // Xử lý sự kiện khi nhấn nút "Xem"
        private void CustomDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == customDataGridView.Columns["ActionColumn"].Index)
            {
                var row = customDataGridView.Rows[e.RowIndex];

                // Lấy giá trị từ cột "order_id"
                var orderIdValue = row.Cells["order_id"].Value;
                if (orderIdValue != null && int.TryParse(orderIdValue.ToString(), out int orderId))
                {
                    ViewOrderClicked?.Invoke(this, orderId);
                }
                else
                {
                    MessageBox.Show("Không thể lấy mã đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void AddFilterButtons()
        {
            foreach (DataGridViewColumn column in customDataGridView.Columns)
            {
                column.HeaderCell = new DataGridViewColumnHeaderCell();
            }
        }
    }
}
