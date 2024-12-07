using System;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class ActionControlMini : UserControl
    {
        // Sự kiện cho các nút
        public event EventHandler SearchClicked;
        public event EventHandler AddClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler ReloadClicked;
        public event EventHandler SearchTextChanged;
        public event EventHandler FilterChanged;
        public event EventHandler SaveClicked;


        private bool filterVisible = true; // Mặc định bộ lọc hiển thị

        public ActionControlMini()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnSave.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnAdd.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnUpdate.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnDelete.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
            this.btnReload.KeyDown += new KeyEventHandler(ActionControl_KeyDown);
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
