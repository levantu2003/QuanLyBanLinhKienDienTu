using QL_CuaHangLinhKienMayTinh.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormNhanVien : Form
    {
        public QL_FormNhanVien()
        {
            InitializeComponent();
        }
        private void load_datagirdview_NhanVien()
        {
            List<NhanVien> nv = NhanVien.GetNhanVien();
            dataGridView_nhanVien.DataSource = nv;
            dataGridView_nhanVien.Columns["Anh"].Visible = false;

        }
        public void load_Cbb_ChucVu()
        {
            List<string> chucVuList = new List<string> { "Quản Lý", "Nhân Viên" };

            cbb_chucVu.DataSource = chucVuList;


        }

        private void QL_FormNhanVien_Load(object sender, EventArgs e)
        {
            load_Cbb_ChucVu();
            load_datagirdview_NhanVien();
            //tất cả các textbox bị vô hiệu hóa//
            txt_diaChi.Enabled = txt_ngaySinh.Enabled = txt_SDT.Enabled = txt_tenNV.Enabled = cbb_chucVu.Enabled =txt_maNV.Enabled= false;
            rdio_Nam.Enabled = rdio_Nu.Enabled = false;
            //tbn thêm ảnh bị vô hiệu hóa//
            btn_themAnh.Enabled = false;
            //btn save bị vô hiệu hóa//
            btn_save.Enabled = false;
        }
        private void dataGridView_nhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_nhanVien.Rows[e.RowIndex];
                int maNV = int.Parse(selectedRow.Cells[0].Value.ToString());
                string tenNV = selectedRow.Cells[1].Value.ToString();
                byte[] imageBytes = selectedRow.Cells[2].Value as byte[];
                string sdt = selectedRow.Cells[3].Value.ToString();
                string diaChi = selectedRow.Cells[5].Value.ToString();
                string gioiTinh = selectedRow.Cells[4].Value.ToString().TrimEnd();
                DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells[6].Value.ToString());
                string chucVu = selectedRow.Cells[7].Value.ToString();

                txt_maNV.Text = maNV.ToString();
                txt_tenNV.Text = tenNV;
                txt_SDT.Text = sdt;
                txt_diaChi.Text = diaChi;

                if (gioiTinh == "Nam")
                {
                    rdio_Nam.Checked = true;
                    rdio_Nu.Checked = false;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdio_Nam.Checked = false;
                    rdio_Nu.Checked = true;
                }

                cbb_chucVu.Text = chucVu;
                txt_ngaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");



                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox_nhanvien.Image = Image.FromStream(ms);
                    }
                }
                else
                {

                    pictureBox_nhanvien.Image = Properties.Resources.icon_staff;
                }

            }
        }
        public void reset_btn()
        {
            btn_add.Enabled = btn_delete.Enabled = btn_update.Enabled = true;
            btn_save.Enabled = false;
        }
        public void reset_txt()
        {
            txt_maNV.Clear();
            txt_tenNV.Clear();
            txt_SDT.Clear();
            txt_diaChi.Clear();
            txt_ngaySinh.Clear();
            rdio_Nam.Checked = false; rdio_Nu.Checked = false;

        }
        private byte[] Img(PictureBox p)
        {
            MemoryStream m = new MemoryStream();
            pictureBox_nhanvien.Image.Save(m, pictureBox_nhanvien.Image.RawFormat);
            return m.ToArray();
        }
        private void btn_add_Click_1(object sender, EventArgs e)
        {
            reset_txt();
            //Các textbox có hiệu lực//
            txt_diaChi.Enabled = txt_ngaySinh.Enabled = txt_SDT.Enabled = txt_tenNV.Enabled = cbb_chucVu.Enabled = rdio_Nam.Enabled = rdio_Nu.Enabled = true;
            //Dấu nháy xuất hiện ở textbox Tên nhân viên//
            txt_tenNV.Focus();
            // btn xóa và btn sửa vô hiệu hóa//
           
            btn_delete.Enabled = btn_update.Enabled = false;
            //thêm ảnh có hiệu lực//
            btn_themAnh.Enabled = true;

            //lưu có hiệu lực//
            btn_save.Enabled = true;

        }
        private void btn_update_Click_1(object sender, EventArgs e)
        {
            //Dấu nháy xuất hiện ở textbox Mã nhân viên/
            txt_maNV.Focus();
            //btn thêm và xóa vô hiệu hóa//
            btn_add.Enabled = false;
            btn_delete.Enabled = false;
            //btn save có hiệu lực//
            btn_save.Enabled = true;
            //Các textbox có hiệu lực//
            txt_diaChi.Enabled = txt_ngaySinh.Enabled = txt_SDT.Enabled = txt_tenNV.Enabled = cbb_chucVu.Enabled = rdio_Nam.Enabled = rdio_Nu.Enabled = txt_maNV.Enabled = true;
            //thêm ảnh có hiệu lực//
            btn_themAnh.Enabled = true;
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            string TenNV = txt_tenNV.Text.Trim();
            byte[] anh = Img(pictureBox_nhanvien);
            string GioiTinh = (rdio_Nam.Checked ? rdio_Nam.Text : rdio_Nu.Text);
            string SDT = txt_SDT.Text.Trim();
            string DiaChi = txt_diaChi.Text.Trim();
            string ChucVu = cbb_chucVu.SelectedValue.ToString();
            DateTime NgaySinh;
            //kiểm tra các thông in xem đã nhập đẩy đủ chưa//
            if (TenNV == string.Empty)
            {
                MessageBox.Show("Chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(txt_ngaySinh.Text.Trim(), out NgaySinh))
            {
                MessageBox.Show("Vui lòng kiểm tra lại ngày sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (SDT == string.Empty)
            {
                MessageBox.Show("Chưa nhập SDT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DiaChi == string.Empty)
            {
                MessageBox.Show("Chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ChucVu == string.Empty)
            {
                MessageBox.Show("Chưa chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rdio_Nam.Checked == false && rdio_Nu.Checked == false)
            {
                MessageBox.Show("Chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (txt_maNV.Enabled == false && btn_update.Enabled == false)// thêm 1 nhân viên
            {
                NhanVien newNV = new NhanVien(TenNV, anh, SDT, GioiTinh, DiaChi, ChucVu, NgaySinh);
                int check = newNV.InsertNhanVien();

                if (check != -1)
                {
                    load_datagirdview_NhanVien();
                    MessageBox.Show("Thêm nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_delete.Enabled = btn_update.Enabled = true;
                    reset_txt();
                    reset_btn();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }


            else//sửa 1 nhân viên
            {
                int maNV;
                if (string.IsNullOrEmpty(txt_maNV.Text.Trim()))
                {
                    MessageBox.Show("Chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (int.TryParse(txt_maNV.Text, out maNV))
                {
                    NhanVien newNV = new NhanVien();
                    int check_MaNV = newNV.CheckMaNV(maNV);

                    if (check_MaNV > 0)
                    {
                        int check = newNV.UpdateNhanVien(maNV, TenNV, anh, SDT, DiaChi, GioiTinh, NgaySinh, ChucVu);

                        if (check > 0)
                        {
                            load_datagirdview_NhanVien();
                            MessageBox.Show("Sửa nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reset_txt();
                            reset_btn();
                        }
                        else
                        {
                            MessageBox.Show("Sửa không thành công! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại trong hệ thống! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Mã NV không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_maNV.Text))
            {
                int maNV = int.Parse(txt_maNV.Text);

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    NhanVien nv = new NhanVien();
                    int deleteResult = nv.DeleteNhanVien(maNV);

                    if (deleteResult != -1)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView_nhanVien.DataSource = NhanVien.GetNhanVien();
                        ////load_datagirdview_NhanVien();
                        reset_txt();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu tồn tại nên không thể xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reset_btn();
        }

        private void btn_themAnh_Click(object sender, EventArgs e)
        {
           
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn ảnh";
                openFileDialog.Filter = "Image Files(*.gif;*.jpg;*.bmp;*wmf;*.png)| *.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   pictureBox_nhanvien.ImageLocation = openFileDialog.FileName;
                }
            
        }

        private void btn_exits_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_searchTen_Click(object sender, EventArgs e)
        {
            string ten = txt_searchTen.Text.Trim();
            NhanVien nv = new NhanVien();
            DataTable searchResult = nv.SearchTenNV(ten);
            if (string.IsNullOrEmpty(txt_searchTen.Text.Trim()))
            {
                MessageBox.Show("Chưa nhập tên nhân viên để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (searchResult != null)
            {

                dataGridView_nhanVien.DataSource = searchResult;
            }
            else
            {

                dataGridView_nhanVien.DataSource = null;

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
            NhanVien nv = new NhanVien();
            DataTable searchResult = nv.SearchMaNV(ma);
            
            if (searchResult != null)
            {

                dataGridView_nhanVien.DataSource = searchResult;
            }
            else
            {

                dataGridView_nhanVien.DataSource = searchResult;
            }
        }

        private void txt_maNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập ký tự vào TextBox
            }
        }

        private void txt_ngaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập ký tự vào TextBox
            }
        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập ký tự vào TextBox
            }
        }
    }
}
