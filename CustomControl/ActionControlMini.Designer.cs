namespace CustomControl
{
    partial class ActionControlMini
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ToolTip toolTip;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(190, 3);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(150, 28);
            this.cbFilter.TabIndex = 6;
            this.toolTip.SetToolTip(this.cbFilter, "Chọn điều kiện lọc dữ liệu");
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::CustomControl.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(144, -3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 11;
            this.toolTip.SetToolTip(this.btnSave, "Nhấn để lưu thay đổi dữ liệu (Ctrl + S)");
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Transparent;
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Image = global::CustomControl.Properties.Resources.reload;
            this.btnReload.Location = new System.Drawing.Point(350, -5);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(40, 40);
            this.btnReload.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnReload, "Nhấn để tải lại dữ liệu (Ctrl + R)");
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::CustomControl.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(2, -3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnAdd, "Nhấn để thêm mới dữ liệu (Ctrl + N)");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::CustomControl.Properties.Resources.edit;
            this.btnUpdate.Location = new System.Drawing.Point(52, -3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(40, 40);
            this.btnUpdate.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnUpdate, "Nhấn để cập nhật dữ liệu (Ctrl + U)");
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::CustomControl.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(98, -3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnDelete, "Nhấn để xóa dữ liệu đã chọn (Ctrl + D)");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ActionControlMini
            // 
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Name = "ActionControlMini";
            this.Size = new System.Drawing.Size(409, 39);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReload;
    }
}
