using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using QL_CuaHangLinhKienMayTinh.Class;
using QL_CuaHangLinhKienMayTinh.Form_Design;
using QL_CuaHangLinhKienMayTinh.Crystal_Reports;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormBanHang : Form
    {
        private int MaNV = 0;
        public QL_FormBanHang(int manv)
        {
            InitializeComponent();
            MaNV = manv;
        }
        public QL_FormBanHang()
        {
            InitializeComponent();
        }

        private int stt = 1;
        private void QL_FormBanHang_Load(object sender, EventArgs e)
        {
            EnabledStart();
            dataGridView_listSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_hoaDon.AllowUserToAddRows = false;
            loadList_SanPham();
            load_cbb_LoaiSP();
        }
        private void EnabledStart()
        {
            txt_tienThua.Enabled = false;
            txt_maSP.Enabled = false;
            txt_giaBan.Enabled = false;
            txt_slHienCo.Enabled = false;
            txt_tenSP.Enabled = false;
            txt_TenKH.Enabled = false;
            btn_addKH.Enabled = false;
            dataGridView_hoaDon.ReadOnly = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            btn_reset.Enabled = false;
            btn_save.Enabled = false;
            dataGridView_listSP.ReadOnly = true;
            dataGridView_listSP.AllowUserToAddRows = false;
        }
        private void loadList_SanPham()
        {
            List<SanPham> lSanPham = SanPham.GetSanPham();
            dataGridView_listSP.DataSource = lSanPham;
        }
        private void load_cbb_LoaiSP()
        {

            // Get the list of LoaiSanPham
            List<LoaiSanPham> lsp = LoaiSanPham.GetLoaiSanPham();
            LoaiSanPham loaiSP = new LoaiSanPham();
            loaiSP.MaLoai = -1;
            loaiSP.TenLoai = "Tất cả SP";
            lsp.Insert(0, loaiSP);
            // Set display and value members
            cbb_searchTheoLoai.DisplayMember = "TenLoai";
            cbb_searchTheoLoai.ValueMember = "MaLoai";
            cbb_searchTheoLoai.DataSource = lsp;
        }

        private void tbn_addKH_Click(object sender, EventArgs e)
        {
            QL_FormKhachHang qlkh = new QL_FormKhachHang();
            qlkh.ShowDialog();
        }
        private void addKhacHangNew()
        {
            if (radio_KHMoi.Checked == true)
            {
                btn_addKH.Enabled = true;
            }
            else
                btn_addKH.Enabled = false;
        }
        Image ByteArrayToImage(byte[] newImages)
        {
            MemoryStream memory = new MemoryStream(newImages);
            return Image.FromStream(memory);
        }
        private void dataGridView_listSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_listSP.Rows[e.RowIndex];

                int maSP = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());
                string tenSP = selectedRow.Cells["TenSP"].Value.ToString();
                string soLuongSP = selectedRow.Cells["SoLuongSP"].Value.ToString();
                string giaBan = selectedRow.Cells["GiaBan"].Value.ToString();
                byte[] newImage = (byte[])selectedRow.Cells["Images"].Value;

                pictureBox_sanPham.Image = ByteArrayToImage(newImage);
                txt_maSP.Text = maSP.ToString();
                txt_tenSP.Text = tenSP.ToString();
                txt_slHienCo.Text = soLuongSP.ToString();
                txt_giaBan.Text = giaBan.ToString();
                txt_slMua.ResetText();
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            string phoneNumber = txt_SDT.Text; 

            try
            {
                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    string customerName = kh.searchTenKhachHang(phoneNumber);
                    txt_TenKH.Text = customerName;
                }
                else
                {
                    txt_TenKH.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_muaHang_Click(object sender, EventArgs e)
        {
            btn_reset.Enabled = true;
            string maSP = txt_maSP.Text;
            string tenSP = txt_tenSP.Text;
            string soLuongHC = txt_slHienCo.Text;
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(txt_slHienCo.Text) || string.IsNullOrEmpty(txt_giaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txt_slMua.Text))
            {
                MessageBox.Show("Vui lòng điền số lượng cần mua !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_slMua.Focus();
                return;
            }
            int soLuong = int.Parse(txt_slMua.Text);
            int soLuongHienCo = int.Parse(txt_slHienCo.Text);
            double giaBan = double.Parse(txt_giaBan.Text);
            if (soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_slMua.Clear();
                txt_slMua.Focus();
                return;
            }
            if (soLuong > soLuongHienCo)
            {
                MessageBox.Show("Số lượng mua vượt mức hiện tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_slMua.Clear();
                txt_slMua.Focus();
                return;
            }
            foreach (DataGridViewRow rows in dataGridView_hoaDon.Rows)
            {
                int i = int.Parse(txt_maSP.Text);
                int j = Convert.ToInt32(rows.Cells["MaSanPham"].Value);
                if (i == j)
                {
                    int sl_hienco = Convert.ToInt32(rows.Cells["ColSoLuong"].Value);
                    int sl_mua = Convert.ToInt32(txt_slMua.Text);
                    rows.Cells["ColSoLuong"].Value = sl_hienco + sl_mua;
                    int quantitys = Convert.ToInt32(rows.Cells[2].Value);
                    double price = Convert.ToDouble(rows.Cells[3].Value);
                    rows.Cells[4].Value = quantitys * price;
                    sumTongTien();
                    return;
                }
            }
            double thanhTien = giaBan * soLuong;
            object[] row = { stt, tenSP,(double)giaBan, soLuong,thanhTien.ToString("N0"),maSP,soLuongHC };
            dataGridView_hoaDon.Rows.Add(row);
            sumTongTien();
            stt++;
            txt_slMua.Clear();
        }
        private float sumTongTien()
        {
            float tongTien = 0;
            foreach (DataGridViewRow row in dataGridView_hoaDon.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    float thanhTien = float.Parse(row.Cells[4].Value.ToString());
                    tongTien =tongTien + thanhTien;
                }
            }
            string formattedTongTien = tongTien.ToString("N0");
            lable_tongHoaDon.ResetText();
            lable_tongHoaDon.Text = formattedTongTien + " VNĐ";
            if (double.TryParse(txt_tienKH.Text, out double tienKH))
            {
                double tienThua = tienKH - tongTien;
                txt_tienThua.Text = tienThua.ToString("N0");
            }
            return tongTien;
        }
        private void txt_tienKH_TextChanged(object sender, EventArgs e)
        {
            sumTongTien();
        }
        private void radio_KHMoi_CheckedChanged(object sender, EventArgs e)
        {
            addKhacHangNew();
        }
        private void dataGridView_hoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_hoaDon.SelectedRows.Count > 0)
            {
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }
            else
            {
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_hoaDon.Rows[e.RowIndex];

                string maSP = selectedRow.Cells["MaSanPham"].Value.ToString();
                string soLuongSPHienCo = selectedRow.Cells["SoLuongHC"].Value.ToString();
                string tenSP = selectedRow.Cells[1].Value.ToString();
                string soLuongSP = selectedRow.Cells[3].Value.ToString();
                double giaBan = double.Parse(selectedRow.Cells[2].Value.ToString());
                
                txt_maSP.Text= maSP;
                txt_tenSP.Text = tenSP.ToString();
                txt_slMua.Text = soLuongSP.ToString();
                txt_slHienCo.Text = soLuongSPHienCo.ToString();
                txt_giaBan.Text = giaBan.ToString();
            }
        }
        private void resetMoney()
        {
            lable_tongHoaDon.ResetText();
            txt_tienKH.Clear();
            txt_tienThua.Clear();
        }
        private void resetALL()
        {
            txt_SDT.Clear();   
            txt_TenKH.Clear();
            pictureBox_sanPham.ResetText();
            txt_maSP.Clear();
            txt_tenSP.Clear();
            txt_giaBan.Clear();
            txt_slMua.Clear();
            txt_slHienCo.Clear();
            dataGridView_hoaDon.Rows.Clear();
            resetMoney();
            lable_tongHoaDon.Text = "0 VNĐ";
            radio_KHCu.Checked = false;
            radio_KHMoi.Checked = false;

        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            dataGridView_hoaDon.Rows.Clear();
            resetMoney();
            lable_tongHoaDon.Text = "0 VNĐ";
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_hoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectRow = dataGridView_hoaDon.SelectedRows[0];
                dataGridView_hoaDon.Rows.Remove(selectRow);
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            sumTongTien();
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            dataGridView_hoaDon.ReadOnly = false;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_hoaDon.Rows)
            {
                if (int.TryParse(row.Cells["ColSoLuong"].Value.ToString(), out int quantitynew))
                {
                    if (quantitynew < 0)
                    {
                        MessageBox.Show("Số lượng không được âm !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (int.TryParse(row.Cells["SoLuongHC"].Value.ToString(), out int quantity))
                {
                    if (quantity < quantitynew)
                    {
                        MessageBox.Show("Số lượng vượt quá số lượng hiện có !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (row.Cells["ColSoLuong"].Value != null && row.Cells[3].Value != null)
                {
                    int quantitys = Convert.ToInt32(row.Cells[2].Value);
                    double price = Convert.ToDouble(row.Cells[3].Value);
                    row.Cells[4].Value = quantitys * price;
                }
            }
            sumTongTien();
        }
        private void btn_inVatThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_SDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SDT.Focus();
                return;
            }
            if (dataGridView_hoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để in hóa đơn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_tienKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tiền khách hàng để in hóa đơn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tienKH.Focus();
                return;
            }
            string phoneNumber = txt_SDT.Text;
            int MaKhachHang = KhachHang.searchMaKH(phoneNumber);
            int MaNhanVien = MaNV;
            DateTime NgayXuatHoaDon = DateTime.Now;
            float TongTien = sumTongTien();
            //Insert Hóa Đơn
            HoaDon HD = new HoaDon(MaKhachHang, MaNhanVien, NgayXuatHoaDon,TongTien);
            int MaHoaDon = HD.insertHD(); 
            //Insert CTHD
            if (MaHoaDon != -1)
            {
                int MaSanPham, SoLuongBan;
                float ThanhTien;
               foreach(DataGridViewRow rows in dataGridView_hoaDon.Rows)
                {
                    if (rows.Cells["MaSanPham"].Value != null && int.TryParse(rows.Cells["MaSanPham"].Value.ToString(), out MaSanPham) &&
                        rows.Cells["ColSoLuong"].Value != null && int.TryParse(rows.Cells["ColSoLuong"].Value.ToString(), out SoLuongBan) &&
                        rows.Cells["ColThanhTien"].Value != null && float.TryParse(rows.Cells["ColThanhTien"].Value.ToString(), out ThanhTien ) )
                    {
                        ChiTietHoaDon CTHD = new ChiTietHoaDon(MaHoaDon, MaSanPham, SoLuongBan, ThanhTien);
                        CTHD.insertCTHD();
                    }
                }
                MessageBox.Show("Thanh toán và in thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadList_SanPham();
            }
            else
            {
                MessageBox.Show("Thanh toán và in thất bại! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // In Hóa Đơn
            HD.inHoaDon(MaHoaDon, txt_tienKH.Text, txt_tienThua.Text);
            resetALL();
        }

        private void txt_searchByTen_TextChanged(object sender, EventArgs e)
        {
            string productName = txt_searchByTen.Text.Trim();
            List<SanPham> searchResult = SanPham.SearchSanPham(productName);
            dataGridView_listSP.DataSource = searchResult;
        }
        private void cbb_searchTheoLoai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int MaLoaiSP = int.Parse(cbb_searchTheoLoai.SelectedValue.ToString());
            if (MaLoaiSP == -1) 
            {
                loadList_SanPham();
                return;
            }
            List<SanPham> searchResult = SanPham.SearchSanPhamByLoai(MaLoaiSP);
            dataGridView_listSP.DataSource = searchResult;
        }

        private void txt_slMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
