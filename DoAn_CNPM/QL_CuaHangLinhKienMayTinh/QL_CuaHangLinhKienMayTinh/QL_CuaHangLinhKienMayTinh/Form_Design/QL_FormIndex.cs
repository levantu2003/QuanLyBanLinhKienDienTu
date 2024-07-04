using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QL_CuaHangLinhKienMayTinh.Class;
using QL_CuaHangLinhKienMayTinh.Form_Design;


namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormIndex : Form
    {
        int MaNV = 0; string UserName = " ", PassWord = " ";
        public QL_FormIndex()
        {
            InitializeComponent();
        }
        public QL_FormIndex(int manv,string user,string pass)
        {
            InitializeComponent();
            MaNV = manv;
            UserName = user;
            PassWord = pass;
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            time.ResetText();
            string getTime = DateTime.Now.ToString();
            time.Text = getTime;
            return;
        }

        public void QL_FormIndex_Load(object sender, EventArgs e)
        {
            customDesign();
            ActiveControl = label1;
            phanQuyen();
            this.ControlBox = false;
            ThongKeCuaHang();
           
        }
        private void phanQuyen()
        {
            label_user.ResetText();
            label_chucvu.ResetText();
            NhanVien nv = new NhanVien();
            string chucVu = nv.findNhanVienByChucVu(MaNV);
            string tenNV = nv.findTenNhanVien(MaNV);
            label_chucvu.Text = chucVu.ToString();
            label_user.Text = tenNV.ToString();
        }
        public void customDesign()
        {
            panel_subMenuQLCT.Visible = false;
            panel_subMenuQLNH.Visible = false;
        }

        public void hideSubmenu()
        {
            if (panel_subMenuQLCT.Visible == true)
                panel_subMenuQLCT.Visible = false;
            if (panel_subMenuQLNH.Visible == true)
                panel_subMenuQLNH.Visible = false;
        }

        public void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        public void btn_QLNH_Click(object sender, EventArgs e)
        {
            if (label_chucvu.Text == "Nhân viên")
            {
                MessageBox.Show("Chức năng này chỉ dành cho Admin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowSubMenu(panel_subMenuQLNH);
        }

        public void btn_QLCT_Click(object sender, EventArgs e)
        {
            if (label_chucvu.Text == "Nhân viên")
            {
                MessageBox.Show("Chức năng này chỉ dành cho Admin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowSubMenu(panel_subMenuQLCT);
        }

        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_content.Controls.Add(childForm);
            panel_content.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void btn_QLNV_Click(object sender, EventArgs e)
        {
            if (label_chucvu.Text == "Nhân viên")
            {
                MessageBox.Show("Chức năng này chỉ dành cho Admin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            openChildForm(new QL_FormNhanVien());
        }

        public void btn_QLTK_Click(object sender, EventArgs e)
        {
            if (label_chucvu.Text == "Nhân viên")
            {
                MessageBox.Show("Chức năng này chỉ dành cho Admin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            openChildForm(new QL_FormTaiKhoan());
        }

        public void btn_QLHM_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormHangMoi(MaNV));
        }

        public void btn_QLHC_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormHangCu(MaNV));

        }

        public void btn_QLBH_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormBanHang(MaNV));

        }

        public void btn_QLPN_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormPhieuNhapHang());

        }

        public void btn_QLSP_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormSanPham());

        }

        public void btn_QLHD_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormHoaDon());

        }

        public void btn_QLNCC_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormNhaCungCap());

        }

        public void btn_QLLoaiSP_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormLoaiSanPham());

        }

        public void btn_QLDT_Click(object sender, EventArgs e)
        {
            if (label_chucvu.Text == "Nhân viên")
            {
                MessageBox.Show("Chức năng này chỉ dành cho Admin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            openChildForm(new QL_FormDoanhThu());
        }

        private void lab_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void btn_QLKH_Click(object sender, EventArgs e)
        {
            openChildForm(new QL_FormKhachHang());
        }
        private void btn_QLHT_Click(object sender, EventArgs e)
        {
            QL_FormDoiMatKhau qlf = new QL_FormDoiMatKhau(MaNV,UserName,PassWord);
            qlf.ShowDialog();
        }
        private void picture_logo_Click(object sender, EventArgs e)
        {
            this.Close();
            QL_FormIndex frm = new QL_FormIndex(MaNV, UserName, PassWord);
            frm.ShowDialog();
        }
        private int tongHoaDon()
        {
            HoaDon hd = new HoaDon();
            int result = hd.TongHoaDon();
            return result; 
        }
        private int tongHoaDonTrongNgay()
        {
            HoaDon hd = new HoaDon();
            int result = hd.TongHoaDonNgayHomNay();
            return result;
        }
        private double TongDoanhThu()
        {
            HoaDon hoadon = new HoaDon();
            double result =(double) hoadon.TongDoanhThu();
            return result;
        }
        private int DemSoLuongNV()
        {
            NhanVien nv = new NhanVien();
            int result = nv.DemSoLuongNV();
            return result;
        }
        private int DemSoLuongKH()
        {
            KhachHang kh = new KhachHang();
            int result = kh.DemSoLuongKH();
            return result;
        }
        private int DemSoLuongSP()
        {
            SanPham sp = new SanPham();
            int result = sp.DemSoLuongSP();
            return result;
        }
        private int DemSoLuongSPSapHetHang()
        {
            SanPham sp = new SanPham();
            int result = sp.DemSoLuongSPSapHetHang();
            return result;
        }
        private void load_SanPham_BanChay()
        {
            SanPham sp = new SanPham();
            DataTable dt = sp.LoadTop5SanPhamBanChay(); 
            Series series = new Series("Số Lượng SP");
            chart1.Series.Clear();
            series.ChartType = SeriesChartType.Column; 
            series.IsValueShownAsLabel = true; 
            foreach (DataRow row in dt.Rows)
            {
                string productName = row["TenSanPham"].ToString();
                int totalQuantity = Convert.ToInt32(row["TongSoLuongBan"]);
                series.Points.AddXY(productName, totalQuantity);
            }
            chart1.Series.Add(series); 
        }

        private void Load_TatCa_SanPham()
        {
            SanPham sanPham = new SanPham();
            DataTable dt = sanPham.LoadAllProducts();

            chart2.Series.Clear();
            Series series = new Series("Sản Phẩm");

            foreach (DataRow row in dt.Rows)
            {
                string productName = row["TenSP"].ToString();
                int quantity = Convert.ToInt32(row["SoLuongSP"]);

                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = productName;  
                dataPoint.YValues = new double[] { quantity };

                if (quantity < 10)
                {
                    dataPoint.Color = System.Drawing.Color.Red;
                }

                series.Points.Add(dataPoint);

                series.Points.Last().LegendText = $"{dataPoint.AxisLabel}: {dataPoint.YValues[0]}";
            }

            chart2.Series.Add(series);

            chart2.Series[0].ChartType = SeriesChartType.Pie;
            chart2.Series[0].IsValueShownAsLabel = true;
            chart2.Series[0].LabelForeColor = System.Drawing.Color.White;
            chart2.Series[0].LabelFormat = "#,##0";
        }


        private void ThongKeCuaHang()
        {
            lable_tongDonHang.ResetText();
            lable_tongDonHang.Text = tongHoaDon().ToString();

            label_tongDonHomNay.ResetText();
            label_tongDonHomNay.Text = tongHoaDonTrongNgay().ToString();

            label_tongDoanhThu.ResetText();
            label_tongDoanhThu.Text = TongDoanhThu().ToString("N0") +" VNĐ";

            label_tongNhanVien.ResetText();
            label_tongNhanVien.Text = DemSoLuongNV().ToString();

            label_tongKhachHang.ResetText();
            label_tongKhachHang.Text = DemSoLuongKH().ToString();

            label_tongSPKho.ResetText();
            label_tongSPKho.Text = DemSoLuongSP().ToString();

            label_tongSPGanHetHang.ResetText();
            label_tongSPGanHetHang.Text = DemSoLuongSPSapHetHang().ToString();

            load_SanPham_BanChay();
            Load_TatCa_SanPham();
        }

    }
}
