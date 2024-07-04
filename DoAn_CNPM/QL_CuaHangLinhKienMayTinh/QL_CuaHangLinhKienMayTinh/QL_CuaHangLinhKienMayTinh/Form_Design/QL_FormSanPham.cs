using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using QL_CuaHangLinhKienMayTinh.Class;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormSanPham : Form
    {
        SqlConnection con = new SqlConnection(ConnectDB.conSql);
        public QL_FormSanPham()
        {
            InitializeComponent();
        }

        private void QL_FormSanPham_Load(object sender, EventArgs e)
        {
            Load_DataGirdView();
            Load_CBB_LSP();
            Load_CBB_NCC();
            Load_CBB_GIA();
        }

        private void Load_CBB_LSP()
        {
            List<LoaiSanPham> lsp = LoaiSanPham.GetLoaiSanPham();
            cbb_MaLoai.DisplayMember = "MaLoai";
            cbb_MaLoai.ValueMember = "TenLoai";
            cbb_MaLoai.DataSource = lsp;
        }

        private void Load_CBB_NCC()
        {
            List<NhaCungCap> lncc = NhaCungCap.GetNhaCungCap();
            cbb_MaNCC.DisplayMember = "MaNCC";
            cbb_MaNCC.ValueMember = "TenNCC";
            cbb_MaNCC.DataSource = lncc;
        }

        private void Load_DataGirdView()
        {
            List<SanPham> sanpham = SanPham.GetSanPham();
            dataGridView_SanPham.Columns.Clear();
            dataGridView_SanPham.DataSource = null;
            dataGridView_SanPham.DataSource = sanpham;
            dataGridView_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_SanPham.Columns["TenLoai"].Visible = false;
            dataGridView_SanPham.Columns["TenNCC"].Visible = false;

            dataGridView_SanPham.Columns["MaSP"].Visible = false;
            dataGridView_SanPham.Columns["NgaySX"].Visible = false;
            dataGridView_SanPham.Columns["ImageSP"].Visible = false;
            dataGridView_SanPham.Columns["TenNCC"].Visible = false;
            dataGridView_SanPham.Columns["MoTa"].Visible = false;
            dataGridView_SanPham.Columns["MaLoai"].Visible = false;
            dataGridView_SanPham.Columns["PrintMessage"].Visible = false;

        }

        private void Load_CBB_GIA()
        {
            cbb_Search_Gia.Items.Add("Tất Cả");
            cbb_Search_Gia.Items.Add("0-100.000");
            cbb_Search_Gia.Items.Add("100.000-500.000");
            cbb_Search_Gia.Items.Add("500.000-1.000.000");
            cbb_Search_Gia.Items.Add("1.000.000-5.000.000");
            cbb_Search_Gia.Items.Add("Trên 1.000.000");
            cbb_Search_Gia.SelectedIndex = 0;
        }

        private void pictureBox_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Image.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        Image ByteArrayToImage(byte[] newImage)
        {
            MemoryStream m = new MemoryStream(newImage);
            return Image.FromStream(m);
        }

        private void btn_exits_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Thoát?", "Thông báo",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
              MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        private void btn_Search_TenSP_Click(object sender, EventArgs e)
        {
            string TenSP = txt_Search_tenSP.Text.Trim();
            List<SanPham> search = SanPham.SearchSanPham(TenSP);
            dataGridView_SanPham.DataSource = search;

        }

        private void button_Search_Gia_Click(object sender, EventArgs e)
        {
            string khoangGia = cbb_Search_Gia.SelectedItem.ToString();
            if (khoangGia == "Tất Cả")
            {
                // Hiển thị tất cả dữ liệu
                Load_DataGirdView();
            }
            else
            {
                List<SanPham> search = SanPham.SearchGiaSanPham(khoangGia);
                dataGridView_SanPham.DataSource = search;
            }
            
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            Load_DataGirdView();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                //int newMaSP = int.Parse(txt_maSP.Text);
                string newTenSP = text_tenSP.Text.Trim();
                int newSoLuongSP = int.Parse(txt_SL.Text);
                DateTime newNgaySX = DateTime.Parse(maskedTextBox_ngaySX.Text);              
                double newGiaBan = double.Parse(txt_GB.Text);
                byte[] newImageSP = ImageToByteArray(pictureBox_Image.Image);
                string newMoTa = txt_MoTa.Text.Trim();
                //string newTrangThai = txt_TrangThai.Text.Trim();
                int newMaLoai = int.Parse(cbb_MaLoai.Text);
               // int newMaNCC = int.Parse(cbb_MaNCC.Text);
                double newGiaNhap = double.Parse(txt_GN.Text);

                SanPham sanpham = new SanPham( newTenSP, newSoLuongSP, newNgaySX, newGiaBan, newImageSP, newMoTa, newMaLoai, newGiaNhap);
                int check = sanpham.deleteSanPham(int.Parse(txt_maSP.Text));
                if (check == -1)
                {

                    MessageBox.Show("Dữ liệu đang sử dụng ,không thể xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Bạn đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }


        }
        public bool CheckTextBox()
        {
            if (string.IsNullOrWhiteSpace(text_tenSP.Text) || string.IsNullOrWhiteSpace(txt_SL.Text) || string.IsNullOrWhiteSpace(txt_GN.Text) || string.IsNullOrWhiteSpace(txt_GB.Text) || string.IsNullOrWhiteSpace(pictureBox_Image.ToString()) || string.IsNullOrWhiteSpace(txt_MoTa.Text) || string.IsNullOrWhiteSpace(cbb_MaLoai.Text) || string.IsNullOrWhiteSpace(cbb_MaNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            DateTime newNgaySanXuat;
            if (!DateTime.TryParse(maskedTextBox_ngaySX.Text.Trim(), out newNgaySanXuat))
            {
                MessageBox.Show("Vui lòng nhập ngày sinh hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (CheckTextBox())
            {
                string newTenSP = text_tenSP.Text.Trim();
                int newSoLuongSP = int.Parse(txt_SL.Text);
                DateTime newNgaySX = DateTime.Parse(maskedTextBox_ngaySX.Text);             
                double newGiaBan = double.Parse(txt_GB.Text);
                byte[] newImageSP = ImageToByteArray(pictureBox_Image.Image);
                string newMoTa = txt_MoTa.Text.Trim();
                int newMaLoai = int.Parse(cbb_MaLoai.Text);
                double newGiaNhap = double.Parse(txt_GN.Text);
                SanPham sanpham = new SanPham( newTenSP, newSoLuongSP, newNgaySX, newGiaBan, newImageSP, newMoTa, newMaLoai, newGiaNhap);
                sanpham.updateSanPham(int.Parse(txt_maSP.Text));
                MessageBox.Show("Bạn đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_SanPham.CurrentCell.RowIndex;
            txt_maSP.Text = dataGridView_SanPham.Rows[r].Cells["MaSP"].Value.ToString();
            text_tenSP.Text = dataGridView_SanPham.Rows[r].Cells["TenSP"].Value.ToString();
            txt_SL.Text = dataGridView_SanPham.Rows[r].Cells["SoLuongSP"].Value.ToString();
            maskedTextBox_ngaySX.Text = dataGridView_SanPham.Rows[r].Cells["NgaySX"].Value.ToString();
            txt_GN.Text = dataGridView_SanPham.Rows[r].Cells["GiaNhap"].Value.ToString();
            txt_GB.Text = dataGridView_SanPham.Rows[r].Cells["GiaBan"].Value.ToString();
            byte[] newImage = (byte[])dataGridView_SanPham.Rows[r].Cells["ImageSP"].Value;
            pictureBox_Image.Image = ByteArrayToImage(newImage);
            txt_MoTa.Text = dataGridView_SanPham.Rows[r].Cells["MoTa"].Value.ToString();
            txt_TrangThai.Text = dataGridView_SanPham.Rows[r].Cells["TrangThai"].Value.ToString();
            cbb_MaLoai.Text = dataGridView_SanPham.Rows[r].Cells["MaLoai"].Value.ToString();
        }

        private void txt_SL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
