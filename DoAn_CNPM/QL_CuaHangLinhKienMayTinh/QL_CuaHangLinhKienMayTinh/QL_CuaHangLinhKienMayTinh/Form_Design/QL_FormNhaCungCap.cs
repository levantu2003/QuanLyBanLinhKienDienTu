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
using QL_CuaHangLinhKienMayTinh.Class;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormNhaCungCap : Form
    {
        SqlConnection con = new SqlConnection(ConnectDB.conSql);
        public QL_FormNhaCungCap()
        {
            InitializeComponent();
        }

        private void QL_FormNhaCungCap_Load(object sender, EventArgs e)
        {
            Load_DataGirdView();
            txt_maNCC.Enabled = false;
        }

        private void Load_DataGirdView()
        {
            List<NhaCungCap> nhacc = NhaCungCap.GetNhaCungCap();
            dataGridView_NCC.Columns.Clear();
            dataGridView_NCC.DataSource = null;
            dataGridView_NCC.DataSource = nhacc;
            dataGridView_NCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public bool CheckTextBox()
        {
            if (string.IsNullOrWhiteSpace(text_tenNCC.Text) || string.IsNullOrWhiteSpace(txt_SDT.Text) || string.IsNullOrWhiteSpace(txt_Email.Text) || string.IsNullOrWhiteSpace(txt_DC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (CheckTextBox())
            {
                //int newMaNCC = int.Parse(txt_maNCC.Text);
                string newTenNCC = text_tenNCC.Text.Trim();
                string newSDT = txt_SDT.Text.Trim();
                string newEmail = txt_Email.Text.Trim();
                string newDiaChi = txt_DC.Text.Trim();

                NhaCungCap nhacc = new NhaCungCap( newTenNCC, newSDT, newEmail, newDiaChi);
                int check = nhacc.insertNhaCungCap();
                if (check != -1)
                {
                    MessageBox.Show("Bạn đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Không được thêm trùng tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
             MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                int maNCC = int.Parse(txt_maNCC.Text);
               

                NhaCungCap nhacc = new NhaCungCap();
                int check = nhacc.deleteNhaCungCap(maNCC);             
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (CheckTextBox())
            {
                int newMaNCC = int.Parse(txt_maNCC.Text);
                string newTenNCC = text_tenNCC.Text.Trim();
                string newSDT = txt_SDT.Text.Trim();
                string newEmail = txt_Email.Text.Trim();
                string newDiaChi = txt_DC.Text.Trim();

                NhaCungCap nhacc = new NhaCungCap();
                nhacc.updateNhaCungCap(newMaNCC, newTenNCC, newSDT, newEmail, newDiaChi);
                MessageBox.Show("Bạn đã Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button_Search_tenNCC_Click(object sender, EventArgs e)
        {
            string tenncc = txt_Search_tenNCC.Text.Trim();
            List<NhaCungCap> search = NhaCungCap.SearchTenNCC(tenncc);
            dataGridView_NCC.DataSource = search;
        }

        private void dataGridView_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_NCC.CurrentCell.RowIndex;
            txt_maNCC.Text = dataGridView_NCC.Rows[r].Cells[0].Value.ToString();
            text_tenNCC.Text = dataGridView_NCC.Rows[r].Cells[1].Value.ToString();
            txt_SDT.Text = dataGridView_NCC.Rows[r].Cells[2].Value.ToString();
            txt_DC.Text = dataGridView_NCC.Rows[r].Cells[3].Value.ToString();
            txt_Email.Text = dataGridView_NCC.Rows[r].Cells[4].Value.ToString();
           
        }

    }
}
