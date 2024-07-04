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
    public partial class QL_FormHangCu : Form
    {
        private int MaNV = 0;
        public QL_FormHangCu(int maNV)
        {
            InitializeComponent();
            MaNV = maNV;
        }
        public QL_FormHangCu()
        {
            InitializeComponent();
        }

        private void QL_FormHangCu_Load(object sender, EventArgs e)
        {
            enabled();
            autoSize();
            load_Cbb_LoaiSanPham();
            load_Cbb_NhaCungCap();
            load_Cbb_SanPham();
            cbb_nhaCC.Enabled = true;
        }
        private void load_Cbb_NhaCungCap()
        {
            List<NhaCungCap> ncc = NhaCungCap.GetNhaCungCap();
            cbb_nhaCC.ValueMember = "MaNCC";
            cbb_nhaCC.DisplayMember = "TenNCC";
            cbb_nhaCC.DataSource = ncc;
        }
        private void load_Cbb_LoaiSanPham()
        {
            List<LoaiSanPham> lsp = LoaiSanPham.GetLoaiSanPham();
            cbb_loaiSP.ValueMember = "MaLoai";
            cbb_loaiSP.DisplayMember = "TenLoai";
            cbb_loaiSP.DataSource = lsp;
        }
        private void load_Cbb_SanPham()
        {
            List<SanPham> lsp = SanPham.GetSanPham_NhapHang();
            cbb_tenSP.ValueMember = "MaSP";
            cbb_tenSP.DisplayMember = "TenSP";
            cbb_tenSP.DataSource = lsp;

        }
        private void load_Data_SanPham()
        {
            List<SanPham> lsp = SanPham.GetSanPham_NhapHang();
            dataGridView_DSSP.DataSource = lsp;
        }
        private void enabled()
        {
            cbb_tenSP.Enabled = false;
            cbb_loaiSP.Enabled = false;
            txt_TongTien.Enabled = false;
            txt_soLuongCu.Enabled = false;
            txt_GiaNhap.Enabled = false;
            btn_delete.Enabled = false;
            btn_reset.Enabled = false;
            btn_print.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
            datagirdview_DSPN.ReadOnly = true;
            datagirdview_DSPN.AllowUserToAddRows = false;
        }
        private void autoSize()
        {
            dataGridView_DSSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagirdview_DSPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private byte[] ImageByArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        Image ByteArrayToImage(byte[] newImages)
        {
            MemoryStream memory = new MemoryStream(newImages);
            return Image.FromStream(memory);
        }
        private void dataGridView_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_DSSP.Rows[e.RowIndex];


                cbb_nhaCC.Text = selectedRow.Cells["ColTenNhaCC"].Value.ToString();
                cbb_loaiSP.Text = selectedRow.Cells["ColTenLoai"].Value.ToString();
                cbb_tenSP.Text = selectedRow.Cells["ColTenSP"].Value.ToString();

                txt_GiaNhap.Text = selectedRow.Cells["ColGiaNhap"].Value.ToString();
                txt_soLuongCu.Text = selectedRow.Cells["ColSoLuong"].Value.ToString();

                byte[] newImage = (byte[])selectedRow.Cells["ColImage"].Value;
                pictureBox_SP.Image = ByteArrayToImage(newImage);
            }
        }

        private void resetText()
        {
            txt_GiaNhap.Clear();
            txt_soLuongMoi.Clear();
            txt_soLuongCu.Clear();
            pictureBox_SP.Image = null;
            cbb_loaiSP.SelectedIndex = cbb_tenSP.SelectedIndex = -1;
        }
        private void btn_nhapHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_soLuongMoi.Text) || string.IsNullOrWhiteSpace(txt_soLuongCu.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soLuongMoi.Focus();
                return;
            }
            btn_print.Enabled = true;
            btn_reset.Enabled = true;

            int newMaSP = int.Parse(cbb_tenSP.SelectedValue.ToString());
            string newTenNCC = cbb_nhaCC.Text;
            string newTenLoaiSP = cbb_loaiSP.Text;
            string newTenSP = cbb_tenSP.Text;

            float newGiaNhap = float.Parse(txt_GiaNhap.Text);
            int newSoLuong = int.Parse(txt_soLuongMoi.Text);
            int newSoLuongCu = int.Parse(txt_soLuongCu.Text);
            float newThanhTien = thanhTien();

            object[] row = {  newTenNCC, newSoLuongCu, newTenLoaiSP, newTenSP, newGiaNhap, newSoLuong,(double)newThanhTien , newMaSP};
            datagirdview_DSPN.Rows.Add(row);
            sumTongTien();
            resetText();
        }
        private float thanhTien()
        {
            int newSoLuong = int.Parse(txt_soLuongMoi.Text);
            float newGiaNhap = float.Parse(txt_GiaNhap.Text);
            float newThanhTien = newSoLuong * newGiaNhap;
            return newThanhTien;
        }
        private float sumTongTien()
        {
            float tongTien = 0;
            foreach (DataGridViewRow row in datagirdview_DSPN.Rows)
            {
                if (row.Cells["ColThanhTiens"].Value != null)
                {
                    float thanhTien = float.Parse(row.Cells["ColThanhTiens"].Value.ToString());
                    tongTien = tongTien + thanhTien;
                }
            }
            txt_TongTien.Text = tongTien.ToString("N0") + " VNĐ";
            return tongTien;
        }
        private void datagirdview_DSPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagirdview_DSPN.SelectedRows.Count > 0)
            {
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }
            else
            {
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
            }
        }
        public void reset_Money()
        {
            txt_TongTien.Clear();
        }
        private void resetFinal()
        {
            txt_ghiChu.Clear();
            txt_TongTien.Clear();
            datagirdview_DSPN.Rows.Clear();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            datagirdview_DSPN.Rows.Clear();
            reset_Money();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagirdview_DSPN.Rows)
            {
                int newSoLuong;
                if (int.TryParse(row.Cells["ColSoLuongs"].Value.ToString(), out newSoLuong))
                {
                    if (newSoLuong <= 0)
                    {
                        MessageBox.Show("Số lượng lớn hơn 0 !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (row.Cells["ColSoLuongs"].Value != null)
                    {
                        int quantitys = Convert.ToInt32(row.Cells["ColSoLuongs"].Value);
                        double price = Convert.ToDouble(row.Cells["ColGiaNhaps"].Value);
                        row.Cells["ColThanhTiens"].Value = quantitys * price;
                    }
                }
            }
            sumTongTien();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            datagirdview_DSPN.ReadOnly = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (datagirdview_DSPN.SelectedRows.Count > 0)
            {
                DataGridViewRow selectRow = datagirdview_DSPN.SelectedRows[0];
                datagirdview_DSPN.Rows.Remove(selectRow);
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            sumTongTien();
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            int newMaNV = MaNV;
            int newMaNCC = int.Parse(cbb_nhaCC.SelectedValue.ToString());
            DateTime newNgayNhap = DateTime.Now;
            string newGhiChu = txt_ghiChu.Text;
            float TongTien = sumTongTien();

            //Insert Phiếu Nhập
            PhieuNhapHang phieuNhap = new PhieuNhapHang(newMaNV,newMaNCC ,newNgayNhap, newGhiChu,0);
            int newMaPhieu = phieuNhap.insertPhieuNhap();

            if (newMaPhieu != -1)
            {
                foreach (DataGridViewRow row in datagirdview_DSPN.Rows)
                {
                    int newMaSP = int.Parse(row.Cells["ColMaSPs"].Value.ToString());
                    int newSoLuongMoi = int.Parse(row.Cells["ColSoLuongs"].Value.ToString());
                    int newSoLuongCu = int.Parse(row.Cells["ColSoLuongCus"].Value.ToString());
                    int newSumSoLuong = newSoLuongCu + newSoLuongMoi;
                    double newGiaNhap = double.Parse(row.Cells["ColGiaNhaps"].Value.ToString());
                    float thanhtien = float.Parse(row.Cells["ColThanhTiens"].Value.ToString());
                    // Insert Sản Phẩm
                    SanPham sp = new SanPham();
                    sp.updateSoLuongSP(newMaSP,newSumSoLuong);
                    //Insert Chi Tiết Phiếu Nhập Hàng
                    ChiTietPhieuNhapHang CTPN = new ChiTietPhieuNhapHang(newMaPhieu, newMaSP, newSoLuongMoi, (float)newGiaNhap,0);
                    CTPN.insertCTPN();
                }
                MessageBox.Show("In phiếu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("In phiếu thất bại! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Report Phiếu Nhập Hàng
            phieuNhap.inPhieuNhap(newMaPhieu);
            resetFinal();
        }
        private void txt_soLuongMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbb_nhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            int newMaNCC = int.Parse(cbb_nhaCC.SelectedValue.ToString());
            DataTable db = ncc.SearchNhaCungCap(newMaNCC);
            dataGridView_DSSP.DataSource = db;
            dataGridView_DSSP.Columns["MaNCC"].Visible = false;
            cbb_nhaCC.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cbb_nhaCC.Enabled = true;
        }
    }
}
