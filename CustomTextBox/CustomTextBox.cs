using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomTextBox
{
    public class CustomTextBox : TextBox
    {
        private Image _icon;
        private string _placeholderText = "Placeholder"; // Mặc định placeholder.

        public CustomTextBox()
        {
            // Xử lý sự kiện để hiển thị và ẩn Placeholder.
            this.GotFocus += RemovePlaceholder;
            this.LostFocus += ShowPlaceholder;
            ShowPlaceholder(null, null);
        }

        // Thuộc tính Icon cho phép đặt hình ảnh.
        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                this.Invalidate(); // Làm mới control để vẽ lại.
            }
        }

        // Thuộc tính PlaceholderText.
        public string Placeholder
        {
            get { return _placeholderText; }
            set
            {
                _placeholderText = value;
                ShowPlaceholder(null, null); // Cập nhật lại khi thay đổi Placeholder.
            }
        }

        // Hiển thị Placeholder khi TextBox trống và không có focus.
        private void ShowPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                this.ForeColor = Color.Gray;
                this.Text = _placeholderText;
            }
        }

        // Xóa Placeholder khi người dùng bắt đầu nhập dữ liệu.
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (this.Text == _placeholderText)
            {
                this.ForeColor = Color.Black;
                this.Text = string.Empty;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_icon != null)
            {
                // Vẽ icon ở bên trái TextBox.
                e.Graphics.DrawImage(_icon, new Point(3, (this.Height - _icon.Height) / 2));

                // Tạo khoảng trống giữa icon và nội dung TextBox.
                this.Padding = new Padding(_icon.Width + 10, 0, 0, 0);
            }
        }
    }
}
