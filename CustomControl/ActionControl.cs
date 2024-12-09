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
        public event EventHandler SaveClicked;

        public string SelectedFilter { get; set; }


        private bool filterVisible = true; // Mặc định bộ lọc hiển thị
                                           // Thuộc tính Visible cho từng nút
        public bool AddButtonVisible
        {
            get => btnAdd.Visible;
            set => btnAdd.Visible = value;
        }

        public bool UpdateButtonVisible
        {
            get => btnUpdate.Visible;
            set => btnUpdate.Visible = value;
        }

        public bool DeleteButtonVisible
        {
            get => btnDelete.Visible;
            set => btnDelete.Visible = value;
        }
        public bool UpdateButtonVisble
        {
            get => btnUpdate.Visible;
            set => btnUpdate.Visible = value;
        }
        public bool SaveButtonVisible
        {
            get => btnSave.Visible;
            set => btnSave.Visible = value;
        }

        public bool ReloadButtonVisible
        {
            get => btnReload.Visible;
            set => btnReload.Visible = value;
        }

        public bool ExcelButtonVisible
        {
            get => btnExcel.Visible;
            set => btnExcel.Visible = value;
        }

        public bool PrintButtonVisible
        {
            get => btnPrint.Visible;
            set => btnPrint.Visible = value;
        }

        public bool SearchButtonVisible
        {
            get => btnSearch.Visible;
            set => btnSearch.Visible = value;
        }

        public bool FilterVisible
        {
            get => cbFilter.Visible;
            set
            {
                cbFilter.Visible = value;
                // Hiển thị/ẩn label đi kèm
            }
        }
        public ActionControl()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnSave.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnSearch.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnAdd.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnUpdate.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnDelete.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnReload.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnExcel.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnPrint.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
        }
        public void SetSelectedFilterValue(object value)
        {
            if (cbFilter.Items.Count > 0 && value != null)
            {
                cbFilter.SelectedValue = value;
            }
            else
            {
                // Đặt giá trị mặc định khi ComboBox chưa có giá trị hợp lệ
                cbFilter.SelectedIndex = 0; // Đặt mặc định là mục đầu tiên
            }
        }

        // Xử lý KeyDown
        private void ActionControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control) // Ctrl + S để Save
            {
                SaveClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.F && e.Control) // Ctrl + F để Search
            {
                SearchClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.N && e.Control) // Ctrl + N để Add
            {
                AddClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.U && e.Control) // Ctrl + U để Update
            {
                UpdateClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.D && e.Control) // Ctrl + D để Delete
            {
                DeleteClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.R && e.Control) // Ctrl + R để Reload
            {
                ReloadClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.E && e.Control) // Ctrl + E để Export Excel
            {
                ExcelExportClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.P && e.Control) // Ctrl + P để Print
            {
                PrintClicked?.Invoke(this, EventArgs.Empty);
            }
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

        // Xử lý nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
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
            if (cbFilter.SelectedValue != null)
            {
                FilterChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        // Thuộc tính để chỉnh vị trí và kích thước của ComboBox Filter
        public System.Drawing.Point FilterLocation
        {
            get => cbFilter.Location;
            set => cbFilter.Location = value;
        }

        public System.Drawing.Size FilterSize
        {
            get => cbFilter.Size;
            set => cbFilter.Size = value;
        }

        // Thuộc tính để chỉnh vị trí và kích thước của nút Tìm kiếm
        public System.Drawing.Point SearchButtonLocation
        {
            get => btnSearch.Location;
            set => btnSearch.Location = value;
        }

        public System.Drawing.Size SearchButtonSize
        {
            get => btnSearch.Size;
            set => btnSearch.Size = value;
        }

    }
}
