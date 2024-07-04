using QL_CuaHangLinhKienMayTinh.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormTaiKhoan : Form
    {
        DataTable Dt_NV = new DataTable();
        public QL_FormTaiKhoan()
        {
            InitializeComponent();
        }

        private void QL_FormTaiKhoan_Load(object sender, EventArgs e)
        {
            dataGridView_taiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            btn_Save.Enabled = false;
            load_Cbb_ChucVu();
            load_Cbb_MaNhanVien();
            load_datagirdview_taiKhoan();
            txt_passWord.Enabled = txt_UserName.Enabled =cbb_chucVu.Enabled = cbb_MaNV.Enabled = false;
            cbb_chucVu.Enabled = false;
           
        }
        private void load_datagirdview_taiKhoan()
        {
            List<TaiKhoan> nv = TaiKhoan.GetTaiKhoan();
            dataGridView_taiKhoan.DataSource = nv;
            dataGridView_taiKhoan.Columns["Anh"].Visible = false;
            dataGridView_taiKhoan.Columns["PassWord"].Visible = false;
            dataGridView_taiKhoan.Columns["TenNV"].Visible = false;
        }
        public void load_Cbb_ChucVu()
        {
            List<string> chucVuList = new List<string> { "Quản Lý", "Nhân Viên" };

            cbb_chucVu.DataSource = chucVuList;
        }
        public void load_Cbb_MaNhanVien()
        {
            //List<NhanVien> nhanvien = NhanVien.GetNhanVien();
            //cbb_MaNV.ValueMember = "MaNV";
            //cbb_MaNV.DisplayMember = "TenNV";
            //cbb_MaNV.DataSource = nhanvien;

            string s = "select * from NHANVIEN";
            SqlDataAdapter da_NV = new SqlDataAdapter(s, ConnectDB.conSql);
            Dt_NV.Clear();
            da_NV.Fill(Dt_NV);

            cbb_MaNV.ValueMember = "MaNV";
            cbb_MaNV.DisplayMember = "TenNV";
            cbb_MaNV.DataSource = Dt_NV;



        }

        
        private bool isPasswordVisible = false;

        private void pictureBox_NV_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {

                pictureBox_ShowPass.Image = Properties.Resources.eye;
                isPasswordVisible = false;
                txt_passWord.UseSystemPasswordChar = true;
            }
            else if (isPasswordVisible == false)
            {
                pictureBox_ShowPass.Image = Properties.Resources.hide;
                isPasswordVisible = true;
                txt_passWord.UseSystemPasswordChar = false;
            }
            else
            {
                isPasswordVisible = true;
                txt_passWord.UseSystemPasswordChar = false;
            }
        }
        public void reset_btn()
        {
            btn_add.Enabled = btn_delete.Enabled = btn_update.Enabled = true;
            btn_Save.Enabled = false;
        }
        public void reset()
        {
            txt_passWord.Text = string.Empty;
            txt_UserName.Text = string.Empty;
            cbb_MaNV.Text = string.Empty;
            cbb_chucVu.Text = string.Empty;
            lb_TenNV.Text = string.Empty;
        }

        private void btn_exits_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_UserName.Focus();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            reset();
            cbb_chucVu.Enabled = true;
            txt_passWord.Enabled = txt_UserName.Enabled = cbb_MaNV.Enabled = true;
            btn_Save.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            txt_passWord.Enabled = txt_UserName.Enabled = false;
            string username = txt_UserName.Text;

            if (username != string.Empty)
            {

                TaiKhoan tk = new TaiKhoan();
                int check_user = tk.CheckUserName(username);
                if (check_user > 0)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản của nhân viên này?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int deleteResult = tk.DeleteTaiKhoan(username);

                        if (deleteResult != -1)
                        {
                            MessageBox.Show("Xóa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load_datagirdview_taiKhoan();
                            reset();

                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn tài khoản muốn xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

     
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            cbb_chucVu.Enabled = cbb_MaNV.Enabled = false;
            btn_add.Enabled = btn_delete.Enabled = false;
            btn_Save.Enabled = true;
            txt_UserName.Enabled = true;
            txt_passWord.Enabled = true;
            txt_passWord.Text = "";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string username = txt_UserName.Text.Trim();
            string password = txt_passWord.Text.Trim();
            int manv = int.Parse(cbb_MaNV.SelectedValue.ToString());
            string chucvu = cbb_chucVu.SelectedValue.ToString();
            if (username == string.Empty)
            {
                MessageBox.Show("Chưa nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password == string.Empty)
            {
                MessageBox.Show("Chưa nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (cbb_chucVu.Enabled == true && cbb_MaNV.Enabled == true)// thêm tk//
            {
                TaiKhoan tk = new TaiKhoan(manv, username, password);
                int check = tk.InsertTaiKhoan();
                if (check != -1)
                {

                    MessageBox.Show("Thêm tài khoản thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    reset_btn();
                    dataGridView_taiKhoan.DataSource = null;
                    load_datagirdview_taiKhoan();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm không thành công! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            else //sửa tài khoản//
            {

                TaiKhoan tk = new TaiKhoan();
                int check_user = tk.CheckUserName(username);

                if (check_user > 0)
                {
                    int check = tk.UpdateTaiKhoan(username, password);

                    if (check > 0)
                    {
                       
                        MessageBox.Show("Sửa tài khoản thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset_btn();
                        reset();
                        dataGridView_taiKhoan.DataSource = null;
                        load_datagirdview_taiKhoan();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Username không tồn tại trong hệ thống! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void pictureBox_ShowPass_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Ẩn mật khẩu và thay đổi hình ảnh
                pictureBox_ShowPass.Image = Properties.Resources.eye; // Thay đổi icon
                isPasswordVisible = false;
                txt_passWord.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
            else if (isPasswordVisible == false)
            {
                // Ẩn mật khẩu và thay đổi hình ảnh
                pictureBox_ShowPass.Image = Properties.Resources.hide; // Thay đổi icon
                isPasswordVisible = true;
                txt_passWord.UseSystemPasswordChar = false; // Ẩn mật khẩu
            }
            else
            {
                // Hiển thị mật khẩu

                isPasswordVisible = true;
                txt_passWord.UseSystemPasswordChar = false; // Hiển thị mật khẩu
            }
        }

        private void btn_searchMa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_searchMa.Text.Trim()))
            {
                MessageBox.Show("Chưa nhập mã nhân viên để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ma = int.Parse(txt_searchMa.Text.Trim());
            TaiKhoan tk = new TaiKhoan();
            DataTable searchResult = tk.SearchMaNV_TaiKhoan(ma);

            if (searchResult != null)
            {

                dataGridView_taiKhoan.DataSource = searchResult;
            }
            else
            {

                dataGridView_taiKhoan.DataSource = searchResult;
            }
        }

        private void dataGridView_taiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_taiKhoan.Rows[e.RowIndex];
                int maNV = int.Parse(selectedRow.Cells[0].Value.ToString());
                string UserName = selectedRow.Cells[1].Value.ToString();
                string passWord = selectedRow.Cells[2].Value.ToString();
                string chucVu = selectedRow.Cells[3].Value.ToString();
                string tenNV = selectedRow.Cells[4].Value.ToString();
                byte[] imageBytes = selectedRow.Cells[5].Value as byte[];
                txt_UserName.Text = UserName;
                cbb_MaNV.Text = maNV.ToString();
                txt_passWord.Text = passWord;
                cbb_chucVu.Text = chucVu;
                lb_TenNV.Text = tenNV.ToString();

                DataRow[] rows = Dt_NV.Select("MaNV = '" + maNV + "'");
                if (rows.Length > 0)
                {
                    string tennv = rows[0]["TenNV"].ToString();
                    cbb_MaNV.Text = tennv;
                }
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {

                        Image image = Image.FromStream(ms);
                        pictureBox_NV.Image = image;
                    }
                }
                else
                {

                    pictureBox_NV.Image = Properties.Resources.icon_staff;
                }
            }
        }

        private void txt_searchMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbb_MaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_MaNV.SelectedItem != null)
            {
                // Kiểm tra xem có giá trị được chọn không và có thể chuyển đổi sang chuỗi không
                if (cbb_MaNV.SelectedValue is string selectedValue)
                {
                    cbb_chucVu.SelectedItem = cbb_MaNV.SelectedValue.ToString();
                }
            }
        }
    }
}
