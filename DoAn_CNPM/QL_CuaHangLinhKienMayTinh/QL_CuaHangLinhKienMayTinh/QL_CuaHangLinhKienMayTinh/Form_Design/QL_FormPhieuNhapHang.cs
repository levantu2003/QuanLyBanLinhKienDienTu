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
    public partial class QL_FormPhieuNhapHang : Form
    {
        public QL_FormPhieuNhapHang()
        {
            InitializeComponent();
        }

        private void QL_FormPhieuNhapHang_Load(object sender, EventArgs e)
        {
            Load_DataGirdView_CTPN();
            Load_DataGirdView_PN();
        }
        private void Load_DataGirdView_CTPN()
        {
            List<ChiTietPhieuNhapHang> ctpn = ChiTietPhieuNhapHang.GetCTPhieuNhap();
            dataGridView_CTPNH.Columns.Clear();
            dataGridView_CTPNH.DataSource = null;
            dataGridView_CTPNH.DataSource = ctpn;
            dataGridView_CTPNH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Load_DataGirdView_PN()
        {
            List<PhieuNhapHang> pn = PhieuNhapHang.GetPhieuNhap();
            dataGridView_PhieuNhap.Columns.Clear();
            dataGridView_PhieuNhap.DataSource = null;
            dataGridView_PhieuNhap.DataSource = pn;
            dataGridView_PhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btn_saves_Click(object sender, EventArgs e)
        {
            Load_DataGirdView_CTPN();
        }

        //private void btn_search_Click(object sender, EventArgs e)
        //{
        //    int mapn = int.Parse(txt_Search_maPhieu.Text.Trim());
        //    List<ChiTietPhieuNhapHang> search = ChiTietPhieuNhapHang.SearchMAPN(mapn);
        //    dataGridView_CTPNH.DataSource = search;
        //    textBox_SLPN.Text = search.Count.ToString();
            
        //}

        private void dataGridView_CTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_CTPNH.CurrentCell.RowIndex;
            txt_maPhieu.Text = dataGridView_CTPNH.Rows[r].Cells[0].Value.ToString();
            txt_maSP.Text = dataGridView_CTPNH.Rows[r].Cells[1].Value.ToString();
            txt_SLN.Text = dataGridView_CTPNH.Rows[r].Cells[2].Value.ToString();
            txt_DGN.Text = dataGridView_CTPNH.Rows[r].Cells[3].Value.ToString();
            txt_ThanhTien.Text = dataGridView_CTPNH.Rows[r].Cells[4].Value.ToString();
        }

        private void txt_SLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_DGN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_ThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Search_maPhieus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btn_Search_maPhieu_Click(object sender, EventArgs e)
        {
            int mapn = int.Parse(txt_Search_maPhieu.Text.Trim());
            List<ChiTietPhieuNhapHang> search = ChiTietPhieuNhapHang.SearchMAPN(mapn);
            dataGridView_CTPNH.DataSource = search;
            textBox_SLPN.Text = search.Count.ToString();
        }

        private void dataGridView_PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_PhieuNhap.CurrentCell.RowIndex;
            textBox_mp.Text = dataGridView_PhieuNhap.Rows[r].Cells[0].Value.ToString();
            textBox_manv.Text = dataGridView_PhieuNhap.Rows[r].Cells[1].Value.ToString();
            textBox_mancc.Text = dataGridView_PhieuNhap.Rows[r].Cells[2].Value.ToString();
            maskedTextBox_nn.Text = dataGridView_PhieuNhap.Rows[r].Cells[3].Value.ToString();
            textBox_gc.Text = dataGridView_PhieuNhap.Rows[r].Cells[4].Value.ToString();
            textBox_tt1.Text = dataGridView_PhieuNhap.Rows[r].Cells[5].Value.ToString();
        }

        private void btn_Search_NN_Click(object sender, EventArgs e)
        {
            string nn = maskedTextBox_NNH.Text;
            List<PhieuNhapHang> search = PhieuNhapHang.SearchNgayNhap(nn);
            dataGridView_PhieuNhap.DataSource = search;
        }
    }
}
