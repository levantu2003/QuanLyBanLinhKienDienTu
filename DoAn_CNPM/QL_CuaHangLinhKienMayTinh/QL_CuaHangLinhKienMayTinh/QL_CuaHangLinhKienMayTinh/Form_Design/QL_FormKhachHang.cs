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
    public partial class QL_FormKhachHang : Form
    {
        public QL_FormKhachHang()
        {
            InitializeComponent();
        }

        private void QL_FormKhachHang_Load(object sender, EventArgs e)
        {
            txt_MaKH.Enabled = false;
            dataGridView_khachHang.ReadOnly = true;
            dataGridView_khachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDaTa_KhachHang();
        }
        private void loadDaTa_KhachHang()
        {
            List<KhachHang> lkhach = KhachHang.GetKhachHang();
            dataGridView_khachHang.DataSource = lkhach;
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            string newTenKH = txt_tenKH.Text.Trim();
            string newDiaChi = txt_diaChi.Text.Trim();
            string newSDT = txt_phone.Text.Trim();
            string newGioiTinh;
            if (rdio_Nam.Checked == true)
            {
                newGioiTinh = "Nam";
            }
            else
                newGioiTinh = "Nữ";
            if (string.IsNullOrWhiteSpace(newTenKH) || string.IsNullOrEmpty(newDiaChi) || string.IsNullOrEmpty(newSDT) || (rdio_Nam.Checked == false && rdio_Nu.Checked == false))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang khachHang = new KhachHang(newTenKH,newDiaChi,newSDT,newGioiTinh);
            int check = khachHang.insertKhachHang();
            if (check != -1)
            {
                MessageBox.Show("Thêm khách hàng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm khách hàng không thành công! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int newMaKH = int.Parse(txt_MaKH.Text);
            string newTenKH = txt_tenKH.Text.Trim();
            string newDiaChi = txt_diaChi.Text.Trim();
            string newSDT = txt_phone.Text.Trim();
            string newGioiTinh;
            if (rdio_Nam.Checked == true)
            {
                newGioiTinh = "Nam";
            }
            else
                newGioiTinh = "Nữ";
            if (string.IsNullOrWhiteSpace(newTenKH) || string.IsNullOrEmpty(newDiaChi) || string.IsNullOrEmpty(newSDT) || (rdio_Nam.Checked == false && rdio_Nu.Checked == false))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang khachHang = new KhachHang();
            int check = khachHang.updateKhachHang(newMaKH, newTenKH, newDiaChi, newSDT, newGioiTinh);
            if (check != -1)
            {
                MessageBox.Show("Sửa khách hàng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa khách hàng không thành công! Vui lòng kiểm tra lại các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaKH.Text))
            {
                MessageBox.Show("Vui lòng không để trống mã khách hàng ? ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            int newMaKH = int.Parse(txt_MaKH.Text.Trim());
            KhachHang khachHang = new KhachHang();
            int check = khachHang.deleteKhachHang(newMaKH);
            if (check != -1) 
            {
                MessageBox.Show("Xóa khách hàng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    

        }
        private void dataGridView_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_khachHang.Rows[e.RowIndex];

                int maKH = int.Parse(selectedRow.Cells[0].Value.ToString());
                string tenKH = selectedRow.Cells[1].Value.ToString();
                string sdt = selectedRow.Cells[3].Value.ToString();
                string diaChi = selectedRow.Cells[2].Value.ToString();
                string gioiTinh = selectedRow.Cells[4].Value.ToString().Trim();

                txt_MaKH.Text = maKH.ToString();
                txt_tenKH.Text = tenKH.ToString();
                txt_diaChi.Text =diaChi.ToString();
                txt_phone.Text = sdt.ToString();

                if (gioiTinh == "Nam") 
                {
                    rdio_Nam.Checked = true;
                    rdio_Nu.Checked = false;
                }
                else if (gioiTinh =="Nữ")
                {
                    rdio_Nam.Checked = false;
                    rdio_Nu.Checked = true;
                }    
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            loadDaTa_KhachHang();
        }

        private void reset_text()
        {
            txt_diaChi.Clear();
            txt_MaKH.Clear();
            txt_phone.Clear();
            txt_tenKH.Clear();
            rdio_Nam.Checked = false;
            rdio_Nu.Checked = false;
        }    
        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset_text();
        }
    }
}
