using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class CustomDataGridViewControl : UserControl
    {
        // Sự kiện được kích hoạt khi người dùng nhấp vào nút "Xem"
        public event EventHandler<int> ViewOrderClicked;

        public object DataSource
        {
            get => customDataGridView.DataSource;
            set
            {
                customDataGridView.DataSource = value;
                ConfigureActionColumn(); // Thêm cột "Thao Tác"
                AddFilterButtons(); // Thêm bộ lọc trên header
            }
        }

        public DataGridViewColumnCollection Columns
        {
            get => customDataGridView.Columns;
        }

        public CustomDataGridViewControl()
        {
            InitializeComponent();
        }

        private void ConfigureActionColumn()
        {
            // Kiểm tra nếu đã có cột "Thao Tác", không thêm lại
            if (!customDataGridView.Columns.Contains("ActionColumn"))
            {
                var actionColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Thao Tác",
                    Name = "ActionColumn",
                    Text = "Xem",
                    UseColumnTextForButtonValue = true // Hiển thị "Xem" trong mọi hàng
                };

                // Thêm cột "Thao Tác" vào cuối
                customDataGridView.Columns.Add(actionColumn);
            }

            // Đăng ký sự kiện CellContentClick
            customDataGridView.CellContentClick -= CustomDataGridView_CellContentClick;
            customDataGridView.CellContentClick += CustomDataGridView_CellContentClick;
        }

        public void AddFilterButtons()
        {
            // Xóa các nút lọc cũ nếu đã thêm
            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Tag != null && control.Tag.ToString() == "FilterButton")
                {
                    this.Controls.Remove(control);
                }
            }

            // Thêm nút lọc trên header của từng cột
            foreach (DataGridViewColumn column in customDataGridView.Columns)
            {
                if (column.Name != "ActionColumn") // Bỏ qua cột "Thao Tác"
                {
                    // Tạo nút lọc
                    Button filterButton = new Button
                    {
                        Text = "🔽", // Biểu tượng lọc
                        Width = 20,
                        Height = 20,
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.White,
                        Tag = "FilterButton" // Đánh dấu để quản lý
                    };

                    filterButton.Click += (s, e) =>
                    {
                        ShowFilterMenu(column.Name); // Hiển thị menu lọc khi nhấp
                    };

                    // Xác định vị trí của nút trên header
                    var headerRect = customDataGridView.GetCellDisplayRectangle(column.Index, -1, true);
                    filterButton.Location = new Point(headerRect.Right - filterButton.Width - 5, headerRect.Top + 5);

                    // Thêm nút vào UserControl
                    this.Controls.Add(filterButton);
                }
            }
        }

        private void ShowFilterMenu(string columnName)
        {
            // Hiển thị menu ngữ cảnh cho bộ lọc
            ContextMenuStrip filterMenu = new ContextMenuStrip();
            filterMenu.Items.Add("Lọc Theo Giá Trị 1", null, (s, e) => ApplyFilter(columnName, "Giá Trị 1"));
            filterMenu.Items.Add("Lọc Theo Giá Trị 2", null, (s, e) => ApplyFilter(columnName, "Giá Trị 2"));
            filterMenu.Show(Cursor.Position);
        }

        private void ApplyFilter(string columnName, string filterOption)
        {
            MessageBox.Show($"Đang áp dụng bộ lọc '{filterOption}' trên cột '{columnName}'");
        }

        private void CustomDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customDataGridView.Columns["ActionColumn"].Index && e.RowIndex >= 0)
            {
                var orderIdCell = customDataGridView.Rows[e.RowIndex].Cells["order_id"];
                if (orderIdCell != null && int.TryParse(orderIdCell.Value?.ToString(), out int orderId))
                {
                    ViewOrderClicked?.Invoke(this, orderId);
                }
                else
                {
                    MessageBox.Show("Không thể lấy mã đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
