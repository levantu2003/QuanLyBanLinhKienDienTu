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
    public partial class QL_FormHoaDon : Form
    {
        public QL_FormHoaDon()
        {
            InitializeComponent();
        }

        private void QL_FormHoaDon_Load(object sender, EventArgs e)
        {
            Load_DataGirdView_HD();
            Load_DataGirdView_CTHD();
            //DemSLHD();
            //TongTienALL();

        }

        private void Load_DataGirdView_HD()
        {

            List<HoaDon> hd = HoaDon.GetHoaDon();
            dataGridView_HD.Columns.Clear();
            dataGridView_HD.DataSource = null;
            dataGridView_HD.DataSource = hd;
            dataGridView_HD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_HD.Columns["TenKH"].Visible = false;
        }

        private void Load_DataGirdView_CTHD()
        {
            List<ChiTietHoaDon> cthd = ChiTietHoaDon.GetCTHoaDon();
            dataGridView_CTHD.Columns.Clear();
            dataGridView_CTHD.DataSource = null;
            dataGridView_CTHD.DataSource = cthd;
            dataGridView_CTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_CTHD.Columns["TenSP"].Visible = false;
            dataGridView_CTHD.Columns["GiaBan"].Visible = false;
        }

        //private void DemSLHD()
        //{
        //    int soLuongHoaDon = 0;

        //    string sql = "SELECT COUNT(*) FROM HoaDon";
        //    SqlConnection con = new SqlConnection(ConnectDB.conSql);
        //    con.Open();
        //    using (SqlCommand cmd = new SqlCommand(sql, con))
        //    {
        //        soLuongHoaDon += (int)cmd.ExecuteScalar();
        //    }


        //}

        //private void TongTienALL()
        //{
        //    decimal tongTien = 0;

        //    string sql = "SELECT SUM(TongTien) FROM HoaDon";
        //    SqlConnection con = new SqlConnection(ConnectDB.conSql);
        //    con.Open();
        //    using (SqlCommand cmd = new SqlCommand(sql, con))
        //    {
        //        tongTien = decimal.Parse(cmd.ExecuteScalar().ToString());
        //    }

        //}

        private void dataGridView_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_HD.CurrentCell.RowIndex;
            txt_maHD.Text = dataGridView_HD.Rows[r].Cells[0].Value.ToString();
            txt_maKH.Text = dataGridView_HD.Rows[r].Cells[1].Value.ToString();
            txt_maNV.Text = dataGridView_HD.Rows[r].Cells[2].Value.ToString();
            maskedTextBox_NgayXuatHD.Text = dataGridView_HD.Rows[r].Cells[3].Value.ToString();
            txt_TongTien.Text = dataGridView_HD.Rows[r].Cells[4].Value.ToString();
        }

        private void dataGridView_CTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_CTHD.CurrentCell.RowIndex;
            txt_mahd_CT.Text = dataGridView_CTHD.Rows[r].Cells[0].Value.ToString();
            txt_maSP.Text = dataGridView_CTHD.Rows[r].Cells[1].Value.ToString();
            txt_SLB.Text = dataGridView_CTHD.Rows[r].Cells[2].Value.ToString();
            txt_ThanhTien.Text = dataGridView_CTHD.Rows[r].Cells[3].Value.ToString();
        }

        private void btn_Search_KH_Click(object sender, EventArgs e)
        {
            dataGridView_HD.Columns["TenKH"].Visible = true;
            string tenkh = txt_Search_tenKH.Text.Trim();
            List<HoaDon> search = HoaDon.SearchTenKh(tenkh);
            dataGridView_HD.DataSource = search;

        }

        private void btn_Search_NgayMua_Click(object sender, EventArgs e)
        {
            dataGridView_HD.Columns["TenKH"].Visible = true;
            string ngaymua = maskedTextBox_ngayMua.Text;
            List<HoaDon> search = HoaDon.SearchNgayMua(ngaymua);
            dataGridView_HD.DataSource = search;

        }

        private void btn_Search_maHD_Click(object sender, EventArgs e)
        {
            dataGridView_CTHD.Columns["TenSP"].Visible = true;
            string mahd = txt_Search_maHD.Text;
            List<ChiTietHoaDon> search = ChiTietHoaDon.SearchMAHD(mahd);
            dataGridView_CTHD.DataSource = search;
            textBox_SLSPHD.Text = search.Count.ToString();
        }
    }
}
