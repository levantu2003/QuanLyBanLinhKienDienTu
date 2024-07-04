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
    public partial class QL_FormHangMoi : Form
    {
        private Image defaulIamges;
        private int MaNV = 0;
        public QL_FormHangMoi(int manv)
        {
            InitializeComponent();
            MaNV = manv;
            defaulIamges = picture_addImages.Image;
        }
        public QL_FormHangMoi()
        {
            InitializeComponent();
        }
        private void QL_FormHangMoi_Load(object sender, EventArgs e)
        {
            enable();
            autoSizeDataG();
            load_Cbb_LoaiSP();
            load_Cbb_NhaCC();
            cbb_nhaCC.Enabled = true;

        }
        private void enable()
        {
            txt_TongTien.Enabled = false;
            btn_delete.Enabled = false;
            btn_print.Enabled = false;
            btn_reset.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
            dataGridView_phieuNhap.ReadOnly = true;
            dataGridView_phieuNhap.AllowUserToAddRows = false;
        }
        private void autoSizeDataG()
        {
            dataGridView_phieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void load_Cbb_NhaCC()
        {
            List<NhaCungCap> ncc = NhaCungCap.GetNhaCungCap();
            cbb_nhaCC.ValueMember = "MaNCC";
            cbb_nhaCC.DisplayMember = "TenNCC";
            cbb_nhaCC.DataSource = ncc;
        }
        private void load_Cbb_LoaiSP()
        {
            List<LoaiSanPham> lsp = LoaiSanPham.GetLoaiSanPham();
            cbb_loaiSP.ValueMember = "MaLoai";
            cbb_loaiSP.DisplayMember = "TenLoai";
            cbb_loaiSP.DataSource = lsp;
        }


        private void picture_addImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                picture_addImages.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }
        private bool checkInformationProduct()
        {
            if (string.IsNullOrWhiteSpace(txt_tenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenSP.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_soLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soLuong.Focus();
                return false;
            }
            int soLuong = int.Parse(txt_soLuong.Text);
            if (soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm lớn hơn 0 !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soLuong.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_giaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập giá nhập sản phẩm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_giaNhap.Focus();
                return false;
            }
            double giaNhap = double.Parse(txt_giaNhap.Text);
            if (giaNhap <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá lớn hơn 0 !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_giaNhap.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_giaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập giá bán sản phẩm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_giaBan.Focus();
                return false;
            }
            double giaBan = double.Parse(txt_giaBan.Text);
            if (giaBan <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá lớn hơn 0 !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_giaBan.Focus();
                return false;
            }
            string ngaySX = maskedTB_ngaySX.Text;
            DateTime ngaySXSua;
            if (!DateTime.TryParseExact(ngaySX, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySXSua))
            {
                MessageBox.Show("Ngày sản xuất không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTB_ngaySX.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_moTa.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả sản phẩm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_moTa.Focus();
                return false;
            }
            return true;
        }
        private void reset_Text()
        {
            picture_addImages.Image = defaulIamges;
            txt_tenSP.ResetText();
            txt_soLuong.ResetText();
            txt_giaBan.ResetText();
            txt_giaNhap.ResetText();
            maskedTB_ngaySX.ResetText();
            txt_moTa.ResetText();
        }
        private void btn_nhapHang_Click(object sender, EventArgs e)
        {
            if (!checkInformationProduct())
            {
            }
            else
            {
                btn_print.Enabled = true;
                btn_reset.Enabled = true;

                int newMaNCC = int.Parse(cbb_nhaCC.SelectedValue.ToString());
                int newMaLoaiSP = int.Parse(cbb_loaiSP.SelectedValue.ToString());
                string newTenNhaCC = cbb_nhaCC.Text;
                string newTenLoaiSP = cbb_loaiSP.Text;
                string newTenSP = txt_tenSP.Text;
                int newSoLuong = int.Parse(txt_soLuong.Text);
                double newGiaBan = double.Parse(txt_giaBan.Text);
                double newGiaNhap = double.Parse(txt_giaNhap.Text);
                DateTime newNgaySX = DateTime.Parse(maskedTB_ngaySX.Text);
                byte[] newImageSP = ImageByArray(picture_addImages.Image);
                string newMoTa = txt_moTa.Text;
                double newThanhTien = ThanhTien();
                object[] row = { newMaLoaiSP, newImageSP, newMaNCC, newTenNhaCC, newTenLoaiSP, newTenSP, newGiaNhap, newSoLuong, newThanhTien.ToString("N0"), newGiaBan, newNgaySX, newMoTa };
                dataGridView_phieuNhap.Rows.Add(row);
                SumTongTien();
                reset_Text();
            }
        }
        private double ThanhTien()
        {
            int newSoLuong = int.Parse(txt_soLuong.Text);
            double newGiaNhap = double.Parse(txt_giaNhap.Text);
            double newThanhTien = newSoLuong * newGiaNhap;
            return newThanhTien;
        }
        private double SumTongTien()
        {
            double TongTien = 0;
            foreach (DataGridViewRow row in dataGridView_phieuNhap.Rows)
            {
                if (row.Cells["ColThanhTien"].Value != null)
                {
                    double thanhTien = double.Parse(row.Cells["ColThanhTien"].Value.ToString());
                    TongTien = TongTien + thanhTien;
                }
            }
            txt_TongTien.Text = TongTien.ToString("N0") + " VND";
            return TongTien;
        }
        private void reset_Money()
        {
            txt_TongTien.ResetText();
        }
        private void dataGridView_phieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_phieuNhap.SelectedRows.Count > 0)
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
        private void btn_reset_Click(object sender, EventArgs e)
        {
            dataGridView_phieuNhap.Rows.Clear();
            reset_Money();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            dataGridView_phieuNhap.ReadOnly = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_phieuNhap.Rows)
            {
                int newSoLuong;
                if (int.TryParse(row.Cells["ColSoLuong"].Value.ToString(), out newSoLuong))
                {
                    if (newSoLuong <= 0)
                    {
                        MessageBox.Show("Số lượng lớn hơn 0 !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (row.Cells["ColSoLuong"].Value != null)
                    {
                        int quantitys = Convert.ToInt32(row.Cells["ColSoLuong"].Value);
                        double price = Convert.ToDouble(row.Cells["ColGiaNhap"].Value);
                        row.Cells["ColThanhTien"].Value = quantitys * price;
                    }
                }
            }
            SumTongTien();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_phieuNhap.SelectedRows.Count > 0)
            {
                DataGridViewRow selectRow = dataGridView_phieuNhap.SelectedRows[0];
                dataGridView_phieuNhap.Rows.Remove(selectRow);
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SumTongTien();
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
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
        private void reset()
        {
            txt_TongTien.Clear();
            txt_ghiChu.Clear();
            dataGridView_phieuNhap.Rows.Clear();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            int newMaNV = MaNV;
            int newMaNCC = int.Parse(cbb_nhaCC.SelectedValue.ToString());
            DateTime newDayNow = DateTime.Now;
            string newGhiChu = txt_ghiChu.Text;
            float tongTien = (float) SumTongTien();

            // Insert Phiếu Nhập
            PhieuNhapHang phieuNhap = new PhieuNhapHang(newMaNV,newMaNCC, newDayNow, newGhiChu, 0);
            int newMaPhieu = phieuNhap.insertPhieuNhap();

            if (newMaPhieu != -1)
            {
                foreach (DataGridViewRow row in dataGridView_phieuNhap.Rows)
                {
                    string newTenSP = row.Cells["ColTenSP"].Value.ToString();
                    int newSoLuong = int.Parse(row.Cells["ColSoLuong"].Value.ToString());
                    DateTime newNgaySX = DateTime.Parse(row.Cells["ColNgaySX"].Value.ToString());
                    double newGiaBan = double.Parse(row.Cells["ColGiaBan"].Value.ToString());
                    double newGiaNhap = double.Parse(row.Cells["ColGiaNhap"].Value.ToString());
                    byte[] newImageSP = (byte[])row.Cells["ColImages"].Value;
                    string newMoTa = row.Cells["ColMoTa"].Value.ToString();
                    int newMaLoai = int.Parse(row.Cells["ColMaLoaiSP"].Value.ToString());
                    float thanhtien = float.Parse(row.Cells["ColThanhTien"].Value.ToString());
                    // Insert Sản Phẩm
                    SanPham sp = new SanPham(newTenSP, newSoLuong, newNgaySX, (float)newGiaBan,newImageSP, newMoTa, newMaLoai,(float)newGiaNhap);
                    int maSP = sp.insertSanPham();
                    if (maSP != -1)
                    {
                        //Insert Chi Tiết Phiếu Nhập Hàng
                        ChiTietPhieuNhapHang CTPN = new ChiTietPhieuNhapHang(newMaPhieu, maSP, newSoLuong, (float)newGiaNhap, 0);
                        CTPN.insertCTPN();
                    }

                }
                MessageBox.Show("In phiếu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("In phiếu thất bại! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Report Phiếu Nhập Hàng
            phieuNhap.inPhieuNhap(newMaPhieu);
            reset();
        }

        private void txt_soLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool nhacungcapDaDuocChon = false;

        private void cbb_nhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
           cbb_nhaCC.Enabled = false;
        }

        private void pictureBox_reset_NCC_Click(object sender, EventArgs e)
        {
            cbb_nhaCC.Enabled = true;
        }
    }

}
