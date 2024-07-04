using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QL_CuaHangLinhKienMayTinh.Class;
namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormLoaiSanPham : Form
    {
        SqlConnection con = new SqlConnection(ConnectDB.conSql);
        public QL_FormLoaiSanPham()
        {
            InitializeComponent();
        }

        private void QL_FormLoaiSanPham_Load(object sender, EventArgs e)
        {
            Load_DataGirdView();
            txt_maLoai.Enabled = false;
        }

        private void Load_DataGirdView()
        {
            List<LoaiSanPham> loaisp = LoaiSanPham.GetLoaiSanPham();
            dataGridView_LoaiSP.Columns.Clear();
            dataGridView_LoaiSP.DataSource = null;
            dataGridView_LoaiSP.DataSource = loaisp;
            dataGridView_LoaiSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public bool CheckTextBox()
        {
            if (string.IsNullOrWhiteSpace(text_tenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
     
        private void dataGridView_LoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_LoaiSP.CurrentCell.RowIndex;
            txt_maLoai.Text = dataGridView_LoaiSP.Rows[r].Cells[0].Value.ToString();
            text_tenLoai.Text = dataGridView_LoaiSP.Rows[r].Cells[1].Value.ToString();
        }

        private void button_Search_tenLoaiSP_Click(object sender, EventArgs e)
        {
            string LoaiSp = txt_Search_tenLoai.Text.Trim();
            List<LoaiSanPham> search = LoaiSanPham.SearchTenLoai(LoaiSp);
            dataGridView_LoaiSP.DataSource = search;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (CheckTextBox())
            {
                //int newMaSP = int.Parse(txt_maLoai.Text);
                string newTenLoai = text_tenLoai.Text.Trim();

                LoaiSanPham loaisanpham = new LoaiSanPham( newTenLoai);
                int check = loaisanpham.insertLoaiSanPham();
                if (check != -1)
                {
                    MessageBox.Show("Bạn đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Không được thêm trùng tên loại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
             MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                int maLoai = int.Parse(txt_maLoai.Text);

                LoaiSanPham loaisanpham = new LoaiSanPham();
                int check = loaisanpham.deleteLoaiSanPham(maLoai);
                //int check = loaisanpham.deleteLoaiSanPham();
                if (check != -1)
                {
                    MessageBox.Show("Bạn đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                    return;
                }
                else
                {
                    MessageBox.Show("Dữ liệu đang sử dụng ,không thể xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

            if (CheckTextBox())
            {
                int newMaLSP = int.Parse(txt_maLoai.Text);
                string newTenLSP = text_tenLoai.Text.Trim();

               
                LoaiSanPham loaisanpham = new LoaiSanPham();
                loaisanpham.updateLoaiSanPham(newMaLSP,newTenLSP);
                MessageBox.Show("Bạn đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Load_DataGirdView();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Thoát?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
