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
    public partial class QL_FormDangNhap : Form
    {
        public QL_FormDangNhap()
        {
            InitializeComponent();
        }
        private void QL_FormDangNhap_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
        }

        private void QL_FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát phần mềm không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void checkBox_showPass_CheckedChanged(object sender, EventArgs e)
        {
           txt_passWord.UseSystemPasswordChar = !checkBox_showPass.Checked;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            string userName = txt_useName.Text.Trim();
            string passWord = txt_passWord.Text.Trim();
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thông báp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool Login = tk.Login(userName, passWord);
            int MaNV = tk.FindMaNVByTK(userName);
            QL_FormIndex index = new QL_FormIndex(MaNV,userName,passWord);
            if (Login == true)
            {
                this.Visible = false;
                index.Show();
                index.FormClosed += (s, eventArgs) =>
                {
                    txt_useName.Clear();
                    txt_passWord.Clear();
                    txt_useName.Focus();
                    // Làm cho form hiện tại trở nên hiển thị khi frmTrangChu đóng
                    this.Visible = true;
                };
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại !!! \nSai tài khoản hoặc mật khẩu !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            QL_FormDangKy frm = new QL_FormDangKy();
            frm.ShowDialog();
        }
    }
}
