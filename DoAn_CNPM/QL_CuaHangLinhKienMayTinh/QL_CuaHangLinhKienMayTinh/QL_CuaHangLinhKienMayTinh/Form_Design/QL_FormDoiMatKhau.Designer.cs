
namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    partial class QL_FormDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QL_FormDoiMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.checkPass = new System.Windows.Forms.CheckBox();
            this.checkNewPass = new System.Windows.Forms.CheckBox();
            this.txt_newPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkRecordNewPass = new System.Windows.Forms.CheckBox();
            this.txt_recordNewPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_xacNhan = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_exits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(292, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đổi Mật Khẩu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập Mật Khẩu Cũ:";
            // 
            // txt_pass
            // 
            this.txt_pass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_pass.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.Location = new System.Drawing.Point(299, 112);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(254, 34);
            this.txt_pass.TabIndex = 2;
            this.txt_pass.UseSystemPasswordChar = true;
            // 
            // checkPass
            // 
            this.checkPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkPass.AutoSize = true;
            this.checkPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPass.Location = new System.Drawing.Point(574, 116);
            this.checkPass.Name = "checkPass";
            this.checkPass.Size = new System.Drawing.Size(169, 26);
            this.checkPass.TabIndex = 3;
            this.checkPass.Text = "Hiển thị mật khẩu";
            this.checkPass.UseVisualStyleBackColor = true;
            this.checkPass.CheckedChanged += new System.EventHandler(this.checkPass_CheckedChanged);
            // 
            // checkNewPass
            // 
            this.checkNewPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkNewPass.AutoSize = true;
            this.checkNewPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNewPass.Location = new System.Drawing.Point(574, 177);
            this.checkNewPass.Name = "checkNewPass";
            this.checkNewPass.Size = new System.Drawing.Size(169, 26);
            this.checkNewPass.TabIndex = 6;
            this.checkNewPass.Text = "Hiển thị mật khẩu";
            this.checkNewPass.UseVisualStyleBackColor = true;
            this.checkNewPass.CheckedChanged += new System.EventHandler(this.checkNewPass_CheckedChanged);
            // 
            // txt_newPass
            // 
            this.txt_newPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_newPass.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newPass.Location = new System.Drawing.Point(299, 173);
            this.txt_newPass.Name = "txt_newPass";
            this.txt_newPass.Size = new System.Drawing.Size(254, 34);
            this.txt_newPass.TabIndex = 5;
            this.txt_newPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập Mật Khẩu Mới:";
            // 
            // checkRecordNewPass
            // 
            this.checkRecordNewPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkRecordNewPass.AutoSize = true;
            this.checkRecordNewPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRecordNewPass.Location = new System.Drawing.Point(574, 235);
            this.checkRecordNewPass.Name = "checkRecordNewPass";
            this.checkRecordNewPass.Size = new System.Drawing.Size(169, 26);
            this.checkRecordNewPass.TabIndex = 9;
            this.checkRecordNewPass.Text = "Hiển thị mật khẩu";
            this.checkRecordNewPass.UseVisualStyleBackColor = true;
            this.checkRecordNewPass.CheckedChanged += new System.EventHandler(this.checkRecordNewPass_CheckedChanged);
            // 
            // txt_recordNewPass
            // 
            this.txt_recordNewPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_recordNewPass.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_recordNewPass.Location = new System.Drawing.Point(299, 231);
            this.txt_recordNewPass.Name = "txt_recordNewPass";
            this.txt_recordNewPass.Size = new System.Drawing.Size(254, 34);
            this.txt_recordNewPass.TabIndex = 8;
            this.txt_recordNewPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nhập Lại Mật  Khẩu Mới:";
            // 
            // btn_xacNhan
            // 
            this.btn_xacNhan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_xacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_xacNhan.FlatAppearance.BorderSize = 2;
            this.btn_xacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xacNhan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xacNhan.ImageKey = "icon_tick.png";
            this.btn_xacNhan.ImageList = this.imageList1;
            this.btn_xacNhan.Location = new System.Drawing.Point(106, 320);
            this.btn_xacNhan.Name = "btn_xacNhan";
            this.btn_xacNhan.Size = new System.Drawing.Size(274, 63);
            this.btn_xacNhan.TabIndex = 10;
            this.btn_xacNhan.Text = "Xác Nhận";
            this.btn_xacNhan.UseVisualStyleBackColor = false;
            this.btn_xacNhan.Click += new System.EventHandler(this.btn_xacNhan_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_tick.png");
            this.imageList1.Images.SetKeyName(1, "icon_x.png");
            // 
            // btn_exits
            // 
            this.btn_exits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_exits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_exits.FlatAppearance.BorderSize = 2;
            this.btn_exits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exits.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exits.ImageKey = "icon_x.png";
            this.btn_exits.ImageList = this.imageList1;
            this.btn_exits.Location = new System.Drawing.Point(427, 320);
            this.btn_exits.Name = "btn_exits";
            this.btn_exits.Size = new System.Drawing.Size(274, 63);
            this.btn_exits.TabIndex = 11;
            this.btn_exits.Text = "Thoát";
            this.btn_exits.UseVisualStyleBackColor = false;
            this.btn_exits.Click += new System.EventHandler(this.btn_exits_Click);
            // 
            // QL_FormDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(805, 424);
            this.Controls.Add(this.btn_exits);
            this.Controls.Add(this.btn_xacNhan);
            this.Controls.Add(this.checkRecordNewPass);
            this.Controls.Add(this.txt_recordNewPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkNewPass);
            this.Controls.Add(this.txt_newPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkPass);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QL_FormDoiMatKhau";
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.CheckBox checkPass;
        private System.Windows.Forms.CheckBox checkNewPass;
        private System.Windows.Forms.TextBox txt_newPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkRecordNewPass;
        private System.Windows.Forms.TextBox txt_recordNewPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_xacNhan;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exits;
    }
}