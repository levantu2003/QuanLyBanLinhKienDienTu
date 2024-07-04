using QL_CuaHangLinhKienMayTinh.Class;
using QL_CuaHangLinhKienMayTinh.Form_Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormDoiMatKhau : Form
    {
        private int MaNV = 0;
        private string UserName = "", PassWord = "";
        public QL_FormDoiMatKhau(int manv,string username,string pass)
        {
            InitializeComponent();
            MaNV = manv;
            UserName = username;
            PassWord = pass;
        }
        public QL_FormDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_exits_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r=MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == r)
            {
                this.Close();
            }
        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            txt_pass.UseSystemPasswordChar = !checkPass.Checked;
        }

        private void checkNewPass_CheckedChanged(object sender, EventArgs e)
        {
            txt_newPass.UseSystemPasswordChar = !checkNewPass.Checked;
        }
        private void checkRecordNewPass_CheckedChanged(object sender, EventArgs e)
        {
            txt_recordNewPass.UseSystemPasswordChar = !checkRecordNewPass.Checked;
        }
        private void checkText()
        {
            if (string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẫu cũ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pass.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_newPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẫu mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_newPass.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_recordNewPass.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_recordNewPass.Focus();
                return;
            }
        }
        private void reset()
        {
            txt_newPass.Clear();
            txt_pass.Clear();
            txt_recordNewPass.Clear();
        }
        private void btn_xacNhan_Click(object sender, EventArgs e)
        {
            checkText();
            string oldPass = txt_pass.Text.Trim();
            string newPass = txt_newPass.Text.Trim();
            string recordNewPass = txt_recordNewPass.Text.Trim();
            if (PassWord == oldPass)
            {
                if (newPass == recordNewPass)
                {
                    TaiKhoan taiKhoan = new TaiKhoan();
                    taiKhoan.UpdateTaiKhoan(UserName, newPass);
                    MessageBox.Show("Đổi Mật Khẩu Thành Công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu không trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_recordNewPass.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nhập mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pass.Focus();
                return;
            }
        }


    }
}
