using System;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class ActionControl : UserControl
    {
        // Sự kiện cho các nút
        public event EventHandler SearchClicked;
        public event EventHandler AddClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler ReloadClicked;
        public event EventHandler ExcelExportClicked; 
        public event EventHandler PrintClicked; // Sự kiện Print
        public event EventHandler SearchTextChanged;
        public event EventHandler FilterChanged;

        private bool filterVisible = true; // Mặc định bộ lọc hiển thị

        public ActionControl()
        {
            InitializeComponent();
        }

        // Thuộc tính TextBox tìm kiếm
        public string SearchText
        {
            get => txtSearch.Text;
        }

        // Thuộc tính DataSource cho ComboBox lọc
        public object FilterDataSource
        {
            get => cbFilter.DataSource;
            set => cbFilter.DataSource = value;
        }

        // Thuộc tính DisplayMember của ComboBox lọc
        public string FilterDisplayMember
        {
            get => cbFilter.DisplayMember;
            set => cbFilter.DisplayMember = value;
        }

        // Thuộc tính ValueMember của ComboBox lọc
        public string FilterValueMember
        {
            get => cbFilter.ValueMember;
            set => cbFilter.ValueMember = value;
        }

        // Thuộc tính SelectedValue của ComboBox lọc
        public object SelectedFilterValue
        {
            get => cbFilter.SelectedValue;
        }

        // Thuộc tính hiển thị/ẩn ComboBox và Label lọc
        public bool FilterVisible
        {
            get => filterVisible;
            set
            {
                filterVisible = value;
                cbFilter.Visible = filterVisible;
                lblFilter.Visible = filterVisible;
            }
        }

        // Xử lý nút Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý nút Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý nút Cập nhật
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý nút Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý nút Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý nút Export Excel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExportClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý nút Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý sự kiện thay đổi TextBox Tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchTextChanged?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý sự kiện thay đổi ComboBox Lọc
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
