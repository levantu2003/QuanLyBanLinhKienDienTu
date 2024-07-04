namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    partial class QL_FormTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QL_FormTaiKhoan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_left = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox_ShowPass = new System.Windows.Forms.PictureBox();
            this.cbb_chucVu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_MaNV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_passWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_TenNV = new System.Windows.Forms.Label();
            this.pictureBox_NV = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_button = new System.Windows.Forms.Panel();
            this.btn_exits = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_searchMa = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_searchMa = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_taiKhoan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_left.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ShowPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NV)).BeginInit();
            this.panel_button.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel_left.Controls.Add(this.groupBox1);
            this.panel_left.Controls.Add(this.panel2);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(576, 626);
            this.panel_left.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox_ShowPass);
            this.groupBox1.Controls.Add(this.cbb_chucVu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbb_MaNV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_passWord);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_UserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_TenNV);
            this.groupBox1.Controls.Add(this.pictureBox_NV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 356);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Tài Khoản";
            // 
            // pictureBox_ShowPass
            // 
            this.pictureBox_ShowPass.BackColor = System.Drawing.Color.White;
            this.pictureBox_ShowPass.Image = global::QL_CuaHangLinhKienMayTinh.Properties.Resources.hide;
            this.pictureBox_ShowPass.Location = new System.Drawing.Point(498, 127);
            this.pictureBox_ShowPass.Name = "pictureBox_ShowPass";
            this.pictureBox_ShowPass.Size = new System.Drawing.Size(37, 24);
            this.pictureBox_ShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ShowPass.TabIndex = 7;
            this.pictureBox_ShowPass.TabStop = false;
            this.pictureBox_ShowPass.Click += new System.EventHandler(this.pictureBox_ShowPass_Click);
            // 
            // cbb_chucVu
            // 
            this.cbb_chucVu.FormattingEnabled = true;
            this.cbb_chucVu.Location = new System.Drawing.Point(310, 244);
            this.cbb_chucVu.Name = "cbb_chucVu";
            this.cbb_chucVu.Size = new System.Drawing.Size(225, 31);
            this.cbb_chucVu.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(197, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chức Vụ";
            // 
            // cbb_MaNV
            // 
            this.cbb_MaNV.FormattingEnabled = true;
            this.cbb_MaNV.Location = new System.Drawing.Point(310, 179);
            this.cbb_MaNV.Name = "cbb_MaNV";
            this.cbb_MaNV.Size = new System.Drawing.Size(225, 31);
            this.cbb_MaNV.TabIndex = 6;
            this.cbb_MaNV.SelectedIndexChanged += new System.EventHandler(this.cbb_MaNV_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(197, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhân Viên";
            // 
            // txt_passWord
            // 
            this.txt_passWord.Location = new System.Drawing.Point(310, 123);
            this.txt_passWord.Name = "txt_passWord";
            this.txt_passWord.Size = new System.Drawing.Size(225, 30);
            this.txt_passWord.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(197, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "PassWord";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(310, 66);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(225, 30);
            this.txt_UserName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(197, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "UserName";
            // 
            // lb_TenNV
            // 
            this.lb_TenNV.AutoSize = true;
            this.lb_TenNV.Location = new System.Drawing.Point(12, 204);
            this.lb_TenNV.Name = "lb_TenNV";
            this.lb_TenNV.Size = new System.Drawing.Size(0, 23);
            this.lb_TenNV.TabIndex = 1;
            // 
            // pictureBox_NV
            // 
            this.pictureBox_NV.Image = global::QL_CuaHangLinhKienMayTinh.Properties.Resources.icon_staff;
            this.pictureBox_NV.Location = new System.Drawing.Point(25, 52);
            this.pictureBox_NV.Name = "pictureBox_NV";
            this.pictureBox_NV.Size = new System.Drawing.Size(155, 135);
            this.pictureBox_NV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_NV.TabIndex = 0;
            this.pictureBox_NV.TabStop = false;
            this.pictureBox_NV.Click += new System.EventHandler(this.pictureBox_NV_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(576, 49);
            this.panel2.TabIndex = 0;
            // 
            // panel_button
            // 
            this.panel_button.BackColor = System.Drawing.Color.Lavender;
            this.panel_button.Controls.Add(this.btn_exits);
            this.panel_button.Controls.Add(this.btn_Save);
            this.panel_button.Controls.Add(this.btn_update);
            this.panel_button.Controls.Add(this.btn_delete);
            this.panel_button.Controls.Add(this.btn_add);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_button.Location = new System.Drawing.Point(576, 0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(879, 86);
            this.panel_button.TabIndex = 1;
            // 
            // btn_exits
            // 
            this.btn_exits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_exits.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_exits.FlatAppearance.BorderSize = 0;
            this.btn_exits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exits.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exits.ImageKey = "icon_exits.png";
            this.btn_exits.ImageList = this.imageList1;
            this.btn_exits.Location = new System.Drawing.Point(747, 16);
            this.btn_exits.Name = "btn_exits";
            this.btn_exits.Size = new System.Drawing.Size(182, 54);
            this.btn_exits.TabIndex = 1;
            this.btn_exits.Text = "Thoát";
            this.btn_exits.UseVisualStyleBackColor = true;
            this.btn_exits.Click += new System.EventHandler(this.btn_exits_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_add.png");
            this.imageList1.Images.SetKeyName(1, "icon_delete.png");
            this.imageList1.Images.SetKeyName(2, "icon_exits.png");
            this.imageList1.Images.SetKeyName(3, "icon_save.png");
            this.imageList1.Images.SetKeyName(4, "icon_update.png");
            this.imageList1.Images.SetKeyName(5, "Zoom-icon.png");
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.ImageKey = "icon_save.png";
            this.btn_Save.ImageList = this.imageList1;
            this.btn_Save.Location = new System.Drawing.Point(505, 16);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(182, 54);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_update
            // 
            this.btn_update.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_update.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_update.ImageKey = "icon_update.png";
            this.btn_update.ImageList = this.imageList1;
            this.btn_update.Location = new System.Drawing.Point(344, 16);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(155, 54);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "Sửa";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.ImageKey = "icon_delete.png";
            this.btn_delete.ImageList = this.imageList1;
            this.btn_delete.Location = new System.Drawing.Point(179, 16);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(159, 54);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add.ImageKey = "icon_add.png";
            this.btn_add.ImageList = this.imageList1;
            this.btn_add.Location = new System.Drawing.Point(6, 16);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(182, 54);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 61);
            this.panel1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(247, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(371, 42);
            this.label6.TabIndex = 0;
            this.label6.Text = "Danh Sách Tài Khoản";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Linen;
            this.groupBox2.Controls.Add(this.btn_searchMa);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(879, 135);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm Tài Khoản";
            // 
            // btn_searchMa
            // 
            this.btn_searchMa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_searchMa.FlatAppearance.BorderSize = 0;
            this.btn_searchMa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_searchMa.ImageIndex = 5;
            this.btn_searchMa.ImageList = this.imageList1;
            this.btn_searchMa.Location = new System.Drawing.Point(518, 49);
            this.btn_searchMa.Name = "btn_searchMa";
            this.btn_searchMa.Size = new System.Drawing.Size(75, 45);
            this.btn_searchMa.TabIndex = 1;
            this.btn_searchMa.UseVisualStyleBackColor = true;
            this.btn_searchMa.Click += new System.EventHandler(this.btn_searchMa_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.txt_searchMa);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(232, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(267, 76);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Theo Mã Nhân Viên";
            // 
            // txt_searchMa
            // 
            this.txt_searchMa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_searchMa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchMa.Location = new System.Drawing.Point(23, 29);
            this.txt_searchMa.Name = "txt_searchMa";
            this.txt_searchMa.Size = new System.Drawing.Size(238, 30);
            this.txt_searchMa.TabIndex = 0;
            this.txt_searchMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_searchMa_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_taiKhoan);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(576, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(879, 540);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView_taiKhoan
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_taiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_taiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_taiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_taiKhoan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_taiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_taiKhoan.Location = new System.Drawing.Point(0, 196);
            this.dataGridView_taiKhoan.Name = "dataGridView_taiKhoan";
            this.dataGridView_taiKhoan.RowHeadersWidth = 51;
            this.dataGridView_taiKhoan.RowTemplate.Height = 24;
            this.dataGridView_taiKhoan.Size = new System.Drawing.Size(879, 344);
            this.dataGridView_taiKhoan.TabIndex = 5;
            this.dataGridView_taiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_taiKhoan_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaNV";
            this.Column1.HeaderText = "Mã NV";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserName";
            this.Column2.HeaderText = "UserName";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ChucVu";
            this.Column3.HeaderText = "Chức Vụ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // QL_FormTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_button);
            this.Controls.Add(this.panel_left);
            this.Name = "QL_FormTaiKhoan";
            this.Text = "Tài Khoản";
            this.Load += new System.EventHandler(this.QL_FormTaiKhoan_Load);
            this.panel_left.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ShowPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NV)).EndInit();
            this.panel_button.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox_NV;
        private System.Windows.Forms.Label lb_TenNV;
        private System.Windows.Forms.ComboBox cbb_MaNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_passWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_chucVu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exits;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.PictureBox pictureBox_ShowPass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_searchMa;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_searchMa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView_taiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}