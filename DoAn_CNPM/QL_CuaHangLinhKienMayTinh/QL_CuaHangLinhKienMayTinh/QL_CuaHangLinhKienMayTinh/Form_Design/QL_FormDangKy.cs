using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_CuaHangLinhKienMayTinh.Class;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormDangKy : Form
    {
        public QL_FormDangKy()
        {
            InitializeComponent();
        }

        private void QL_FormDangKy_Load(object sender, EventArgs e)
        {
            ActiveControl = txt_UserName;
            load_Cbb_NhanVien();
            load_Cbb_ChucVu();
        }
        private void load_Cbb_NhanVien()
        {
            List<NhanVien> nhanvien = NhanVien.GetNhanVien();
            cbb_MaNV.ValueMember = "MaNV";
            cbb_MaNV.DisplayMember = "TenNV";
            cbb_MaNV.DataSource = nhanvien;
        }
        private void load_Cbb_ChucVu()
        {
            List<string> chucVuList = new List<string> { "Quản Lý", "Nhân Viên" };
            cbb_chucVu.DataSource = chucVuList;
        }
        private void resetText()
        {
            txt_UserName.Clear();
            txt_passWord.Clear();
        }
        private void btn_dangKy_Click(object sender, EventArgs e)
        {
            string username = txt_UserName.Text.Trim();
            string password = txt_passWord.Text.Trim();
            int manv = int.Parse(cbb_MaNV.SelectedValue.ToString());
            string chucvu = cbb_chucVu.SelectedValue.ToString();
            if (username == string.Empty)
            {
                MessageBox.Show("Chưa nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UserName.Focus();
                return;
            }
            if (password == string.Empty)
            {
                MessageBox.Show("Chưa nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UserName.Focus();
                return;
            }
            if (manv.ToString() == string.Empty)
            {
                MessageBox.Show("Chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chucvu.ToString() == string.Empty)
            {
                MessageBox.Show("Chưa chọn chức vụ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaiKhoan tk = new TaiKhoan(manv, username, password);
            int check = tk.InsertTaiKhoan();
            if (check != -1)
            {
                MessageBox.Show("Thêm tài khoản thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetText();
                return;
            }
            else
            {
                MessageBox.Show("Thêm không thành công! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetText();
                return;
            }
        }
    }
}
