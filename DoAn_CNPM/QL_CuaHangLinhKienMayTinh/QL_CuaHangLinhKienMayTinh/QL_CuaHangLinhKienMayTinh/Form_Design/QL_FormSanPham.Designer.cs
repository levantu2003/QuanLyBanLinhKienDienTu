namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    partial class QL_FormSanPham
    {/// <summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QL_FormSanPham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataGridView_SanPham = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_Search_TenSP = new System.Windows.Forms.Button();
            this.txt_Search_tenSP = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button_Search_Gia = new System.Windows.Forms.Button();
            this.cbb_Search_Gia = new System.Windows.Forms.ComboBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_exits = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_MaNCC = new System.Windows.Forms.ComboBox();
            this.cbb_MaLoai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.txt_TrangThai = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_MoTa = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_maSP = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.text_tenSP = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_GB = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_SL = new System.Windows.Forms.TextBox();
            this.txt_GN = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ngaySX = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SanPham)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_save.png");
            this.imageList1.Images.SetKeyName(1, "icon_exits.png");
            this.imageList1.Images.SetKeyName(2, "icon_Search2.png");
            this.imageList1.Images.SetKeyName(3, "icon_add.png");
            this.imageList1.Images.SetKeyName(4, "icon_delete.png");
            this.imageList1.Images.SetKeyName(5, "icon_update.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 1050);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Location = new System.Drawing.Point(764, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 863);
            this.panel2.TabIndex = 46;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dataGridView_SanPham);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 69);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1015, 792);
            this.panel8.TabIndex = 2;
            // 
            // dataGridView_SanPham
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_SanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_SanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.Column1,
            this.Column2,
            this.TenSP,
            this.SoLuongSP,
            this.NgaySX,
            this.GiaNhap,
            this.GiaBan,
            this.ImageSP,
            this.MoTa,
            this.TrangThai,
            this.MaLoai,
            this.MaNCC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_SanPham.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_SanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SanPham.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_SanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_SanPham.Name = "dataGridView_SanPham";
            this.dataGridView_SanPham.RowHeadersWidth = 51;
            this.dataGridView_SanPham.RowTemplate.Height = 24;
            this.dataGridView_SanPham.Size = new System.Drawing.Size(1015, 792);
            this.dataGridView_SanPham.TabIndex = 1;
            this.dataGridView_SanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SanPham_CellClick);
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã Sản Phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TenLoai";
            this.Column1.HeaderText = "Tên Loại";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenNCC";
            this.Column2.HeaderText = "Tên Nhà Cung Cấp";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 125;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 125;
            // 
            // SoLuongSP
            // 
            this.SoLuongSP.DataPropertyName = "SoLuongSP";
            this.SoLuongSP.HeaderText = "Số Lượng";
            this.SoLuongSP.MinimumWidth = 6;
            this.SoLuongSP.Name = "SoLuongSP";
            this.SoLuongSP.Width = 125;
            // 
            // NgaySX
            // 
            this.NgaySX.DataPropertyName = "NgaySX";
            this.NgaySX.HeaderText = "Ngày Sản Xuất";
            this.NgaySX.MinimumWidth = 6;
            this.NgaySX.Name = "NgaySX";
            this.NgaySX.Width = 125;
            // 
            // GiaNhap
            // 
            this.GiaNhap.DataPropertyName = "GiaNhap";
            this.GiaNhap.HeaderText = "Giá Nhập";
            this.GiaNhap.MinimumWidth = 6;
            this.GiaNhap.Name = "GiaNhap";
            this.GiaNhap.Width = 125;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.MinimumWidth = 6;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Width = 125;
            // 
            // ImageSP
            // 
            this.ImageSP.DataPropertyName = "ImageSP";
            this.ImageSP.HeaderText = "Image";
            this.ImageSP.MinimumWidth = 6;
            this.ImageSP.Name = "ImageSP";
            this.ImageSP.Width = 125;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô Tả";
            this.MoTa.MinimumWidth = 6;
            this.MoTa.Name = "MoTa";
            this.MoTa.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 125;
            // 
            // MaLoai
            // 
            this.MaLoai.DataPropertyName = "MaLoai";
            this.MaLoai.HeaderText = "Mã Loại";
            this.MaLoai.MinimumWidth = 6;
            this.MaLoai.Name = "MaLoai";
            this.MaLoai.Width = 125;
            // 
            // MaNCC
            // 
            this.MaNCC.DataPropertyName = "MaNCC";
            this.MaNCC.HeaderText = "Mã Nhà Cung Cấp";
            this.MaNCC.MinimumWidth = 6;
            this.MaNCC.Name = "MaNCC";
            this.MaNCC.Width = 125;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1015, 69);
            this.panel7.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh Sách Sản Phẩm";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.groupBox9);
            this.panel5.Controls.Add(this.groupBox8);
            this.panel5.Controls.Add(this.btn_update);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.btn_delete);
            this.panel5.Controls.Add(this.btn_save);
            this.panel5.Controls.Add(this.btn_exits);
            this.panel5.Location = new System.Drawing.Point(16, 566);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(738, 345);
            this.panel5.TabIndex = 44;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox9.Controls.Add(this.btn_Search_TenSP);
            this.groupBox9.Controls.Add(this.txt_Search_tenSP);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(46, 56);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(321, 81);
            this.groupBox9.TabIndex = 36;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Theo Tên Sản Phẩm";
            // 
            // btn_Search_TenSP
            // 
            this.btn_Search_TenSP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Search_TenSP.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Search_TenSP.FlatAppearance.BorderSize = 0;
            this.btn_Search_TenSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search_TenSP.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search_TenSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search_TenSP.ImageKey = "icon_Search2.png";
            this.btn_Search_TenSP.ImageList = this.imageList1;
            this.btn_Search_TenSP.Location = new System.Drawing.Point(238, 23);
            this.btn_Search_TenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Search_TenSP.Name = "btn_Search_TenSP";
            this.btn_Search_TenSP.Size = new System.Drawing.Size(77, 48);
            this.btn_Search_TenSP.TabIndex = 24;
            this.btn_Search_TenSP.UseVisualStyleBackColor = true;
            this.btn_Search_TenSP.Click += new System.EventHandler(this.btn_Search_TenSP_Click);
            // 
            // txt_Search_tenSP
            // 
            this.txt_Search_tenSP.Location = new System.Drawing.Point(5, 30);
            this.txt_Search_tenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Search_tenSP.Name = "txt_Search_tenSP";
            this.txt_Search_tenSP.Size = new System.Drawing.Size(208, 30);
            this.txt_Search_tenSP.TabIndex = 21;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox8.Controls.Add(this.button_Search_Gia);
            this.groupBox8.Controls.Add(this.cbb_Search_Gia);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(389, 56);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(307, 81);
            this.groupBox8.TabIndex = 35;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Theo Giá Bán";
            // 
            // button_Search_Gia
            // 
            this.button_Search_Gia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Search_Gia.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_Search_Gia.FlatAppearance.BorderSize = 0;
            this.button_Search_Gia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Search_Gia.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Search_Gia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Search_Gia.ImageKey = "icon_Search2.png";
            this.button_Search_Gia.ImageList = this.imageList1;
            this.button_Search_Gia.Location = new System.Drawing.Point(219, 25);
            this.button_Search_Gia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Search_Gia.Name = "button_Search_Gia";
            this.button_Search_Gia.Size = new System.Drawing.Size(76, 48);
            this.button_Search_Gia.TabIndex = 23;
            this.button_Search_Gia.UseVisualStyleBackColor = true;
            this.button_Search_Gia.Click += new System.EventHandler(this.button_Search_Gia_Click);
            // 
            // cbb_Search_Gia
            // 
            this.cbb_Search_Gia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Search_Gia.FormattingEnabled = true;
            this.cbb_Search_Gia.Location = new System.Drawing.Point(6, 31);
            this.cbb_Search_Gia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_Search_Gia.Name = "cbb_Search_Gia";
            this.cbb_Search_Gia.Size = new System.Drawing.Size(207, 30);
            this.cbb_Search_Gia.TabIndex = 0;
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
            this.btn_update.Location = new System.Drawing.Point(270, 169);
            this.btn_update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(181, 54);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "Sửa";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(736, 51);
            this.panel6.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(293, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Chức Năng";
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
            this.btn_delete.Location = new System.Drawing.Point(47, 170);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(181, 54);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.ImageKey = "icon_save.png";
            this.btn_save.ImageList = this.imageList1;
            this.btn_save.Location = new System.Drawing.Point(526, 169);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(197, 54);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Lưu";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_exits
            // 
            this.btn_exits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_exits.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_exits.FlatAppearance.BorderSize = 0;
            this.btn_exits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exits.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exits.ImageKey = "icon_exits.png";
            this.btn_exits.ImageList = this.imageList1;
            this.btn_exits.Location = new System.Drawing.Point(267, 255);
            this.btn_exits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exits.Name = "btn_exits";
            this.btn_exits.Size = new System.Drawing.Size(207, 54);
            this.btn_exits.TabIndex = 0;
            this.btn_exits.Text = "Thoát";
            this.btn_exits.UseVisualStyleBackColor = true;
            this.btn_exits.Click += new System.EventHandler(this.btn_exits_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbb_MaNCC);
            this.panel3.Controls.Add(this.cbb_MaLoai);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.pictureBox_Image);
            this.panel3.Controls.Add(this.txt_TrangThai);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.txt_MoTa);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txt_maSP);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.text_tenSP);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.txt_GB);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txt_SL);
            this.panel3.Controls.Add(this.txt_GN);
            this.panel3.Controls.Add(this.maskedTextBox_ngaySX);
            this.panel3.Location = new System.Drawing.Point(15, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 535);
            this.panel3.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(319, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 33;
            this.label1.Text = "Giá Nhập";
            // 
            // cbb_MaNCC
            // 
            this.cbb_MaNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_MaNCC.FormattingEnabled = true;
            this.cbb_MaNCC.Location = new System.Drawing.Point(458, 468);
            this.cbb_MaNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_MaNCC.Name = "cbb_MaNCC";
            this.cbb_MaNCC.Size = new System.Drawing.Size(265, 30);
            this.cbb_MaNCC.TabIndex = 31;
            // 
            // cbb_MaLoai
            // 
            this.cbb_MaLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_MaLoai.FormattingEnabled = true;
            this.cbb_MaLoai.Location = new System.Drawing.Point(458, 419);
            this.cbb_MaLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_MaLoai.Name = "cbb_MaLoai";
            this.cbb_MaLoai.Size = new System.Drawing.Size(265, 30);
            this.cbb_MaLoai.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(319, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mã Loại";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(737, 69);
            this.panel4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thông Tin Sản Phẩm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(319, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 22);
            this.label6.TabIndex = 28;
            this.label6.Text = "Mã Loại";
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox_Image.Location = new System.Drawing.Point(47, 74);
            this.pictureBox_Image.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(250, 250);
            this.pictureBox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Image.TabIndex = 0;
            this.pictureBox_Image.TabStop = false;
            this.pictureBox_Image.Click += new System.EventHandler(this.pictureBox_Image_Click);
            // 
            // txt_TrangThai
            // 
            this.txt_TrangThai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TrangThai.Location = new System.Drawing.Point(458, 370);
            this.txt_TrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_TrangThai.Name = "txt_TrangThai";
            this.txt_TrangThai.Size = new System.Drawing.Size(265, 30);
            this.txt_TrangThai.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(82, 332);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 26);
            this.label17.TabIndex = 20;
            this.label17.Text = "Image Sản Phẩm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(319, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 22);
            this.label8.TabIndex = 29;
            this.label8.Text = "Trạng Thái";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(319, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 22);
            this.label22.TabIndex = 2;
            this.label22.Text = "Mã Sản Phẩm";
            // 
            // txt_MoTa
            // 
            this.txt_MoTa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MoTa.Location = new System.Drawing.Point(78, 366);
            this.txt_MoTa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MoTa.Multiline = true;
            this.txt_MoTa.Name = "txt_MoTa";
            this.txt_MoTa.Size = new System.Drawing.Size(233, 139);
            this.txt_MoTa.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(9, 428);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 22);
            this.label10.TabIndex = 23;
            this.label10.Text = "Mô Tả";
            // 
            // txt_maSP
            // 
            this.txt_maSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maSP.Location = new System.Drawing.Point(458, 91);
            this.txt_maSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_maSP.Name = "txt_maSP";
            this.txt_maSP.Size = new System.Drawing.Size(265, 30);
            this.txt_maSP.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(319, 140);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(122, 22);
            this.label21.TabIndex = 2;
            this.label21.Text = "Tên Sản Phẩm";
            // 
            // text_tenSP
            // 
            this.text_tenSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_tenSP.Location = new System.Drawing.Point(458, 137);
            this.text_tenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_tenSP.Name = "text_tenSP";
            this.text_tenSP.Size = new System.Drawing.Size(265, 30);
            this.text_tenSP.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(319, 233);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(127, 22);
            this.label20.TabIndex = 2;
            this.label20.Text = "Ngày Sản Xuất";
            // 
            // txt_GB
            // 
            this.txt_GB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GB.Location = new System.Drawing.Point(458, 323);
            this.txt_GB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_GB.Name = "txt_GB";
            this.txt_GB.Size = new System.Drawing.Size(265, 30);
            this.txt_GB.TabIndex = 12;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(319, 188);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 22);
            this.label19.TabIndex = 2;
            this.label19.Text = "Số Lượng";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(319, 328);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 22);
            this.label18.TabIndex = 10;
            this.label18.Text = "Giá Bán";
            // 
            // txt_SL
            // 
            this.txt_SL.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SL.Location = new System.Drawing.Point(458, 185);
            this.txt_SL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SL.Name = "txt_SL";
            this.txt_SL.Size = new System.Drawing.Size(265, 30);
            this.txt_SL.TabIndex = 7;
            this.txt_SL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SL_KeyPress);
            // 
            // txt_GN
            // 
            this.txt_GN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GN.Location = new System.Drawing.Point(458, 276);
            this.txt_GN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_GN.Name = "txt_GN";
            this.txt_GN.Size = new System.Drawing.Size(265, 30);
            this.txt_GN.TabIndex = 13;
            // 
            // maskedTextBox_ngaySX
            // 
            this.maskedTextBox_ngaySX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_ngaySX.Location = new System.Drawing.Point(458, 230);
            this.maskedTextBox_ngaySX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox_ngaySX.Mask = "00/00/0000";
            this.maskedTextBox_ngaySX.Name = "maskedTextBox_ngaySX";
            this.maskedTextBox_ngaySX.Size = new System.Drawing.Size(265, 30);
            this.maskedTextBox_ngaySX.TabIndex = 8;
            this.maskedTextBox_ngaySX.ValidatingType = typeof(System.DateTime);
            // 
            // QL_FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QL_FormSanPham";
            this.Text = "Sản Phẩm";
            this.Load += new System.EventHandler(this.QL_FormSanPham_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SanPham)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbb_MaLoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TrangThai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_MoTa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_GB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_GN;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ngaySX;
        private System.Windows.Forms.TextBox txt_SL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox text_tenSP;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_maSP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.Button btn_exits;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txt_Search_tenSP;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button_Search_Gia;
        private System.Windows.Forms.ComboBox cbb_Search_Gia;
        private System.Windows.Forms.Button btn_Search_TenSP;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_MaNCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dataGridView_SanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySX;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNCC;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
    }
}