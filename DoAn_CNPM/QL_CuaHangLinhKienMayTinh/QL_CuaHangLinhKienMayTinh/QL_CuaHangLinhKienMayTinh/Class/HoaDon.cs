using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QL_CuaHangLinhKienMayTinh.Crystal_Reports;
using QL_CuaHangLinhKienMayTinh.Form_Design;
using System.Globalization;

namespace QL_CuaHangLinhKienMayTinh.Class
{
    internal class HoaDon
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayXuatHD { get; set; }
        public double TongTien { get; set; }
        public string TenKH { get; set; }
        public HoaDon(int MaKH, int MaNV, DateTime NXHD, double tt)
        {
            this.MaKH = MaKH;
            this.MaNV = MaNV;
            NgayXuatHD = NXHD;
            this.TongTien = tt;
        }
        public HoaDon()
        {

        }
        public int insertHD()
        {
            int MaHD = -1;
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertHD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaKH", this.MaKH);
            cmd.Parameters.AddWithValue("@MaNV", this.MaNV);
            cmd.Parameters.AddWithValue("@NgayXuatHD", this.NgayXuatHD);
            cmd.Parameters.AddWithValue("@TongTien", this.TongTien);

            try
            {
                cmd.ExecuteNonQuery();
                SqlCommand cmdGetMaxMaHD = new SqlCommand("MAX_MAHD", con);
                cmdGetMaxMaHD.CommandType = CommandType.StoredProcedure;

                object result = cmdGetMaxMaHD.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    MaHD = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Thêm Hóa Đơn: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return MaHD;
        }
        public void inHoaDon(int maHD, string tienKH, string tienThua)
        {
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            SqlCommand cmd = new SqlCommand("InHoaDon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaHD", maHD);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            rptInHoaDon rpt = new rptInHoaDon();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue("TienMat", tienKH);
            rpt.SetParameterValue("TienThua", tienThua);
            QL_FormInHoaDon frmIn = new QL_FormInHoaDon();
            frmIn.crystalReportViewer1.ReportSource = rpt;
            frmIn.ShowDialog();
        }

        public static List<HoaDon> GetHoaDon()
        {
            List<HoaDon> lHoaDon = new List<HoaDon>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DaTa_HoaDon", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hd = new HoaDon();
                    hd.MaHD = int.Parse(reader["MaHD"].ToString());
                    hd.MaKH = int.Parse(reader["MaKH"].ToString());
                    hd.MaNV = int.Parse(reader["MaNV"].ToString());
                    hd.NgayXuatHD = DateTime.Parse(reader["NgayXuatHD"].ToString());
                    hd.TongTien = double.Parse(reader["TongTien"].ToString());

                    lHoaDon.Add(hd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return lHoaDon;
        }
        public static List<HoaDon> SearchTenKh(string Tenkh)
        {
            List<HoaDon> lhd = new List<HoaDon>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TimKiemTheoTenKH", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenKH", Tenkh);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hd = new HoaDon();
                    hd.MaHD = int.Parse(reader["MaHD"].ToString());
                    hd.MaNV = int.Parse(reader["MaNV"].ToString());
                    hd.MaKH = int.Parse(reader["MaKH"].ToString());
                    hd.NgayXuatHD = DateTime.Parse(reader["NgayXuatHD"].ToString());
                    hd.TongTien = double.Parse(reader["TongTien"].ToString());
                    hd.TenKH = reader["Tenkh"].ToString();

                    lhd.Add(hd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return lhd;
        }

        public static List<HoaDon> SearchNgayMua(string ngaymua)
        {
            List<HoaDon> lhd = new List<HoaDon>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TimKiemTheoNgayMua", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DateTime ngayMua = DateTime.ParseExact(ngaymua, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@ngaymua", ngayMua);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hd = new HoaDon();
                    hd.MaHD = int.Parse(reader["MaHD"].ToString());
                    hd.MaNV = int.Parse(reader["MaNV"].ToString());
                    hd.MaKH = int.Parse(reader["MaKH"].ToString());
                    hd.NgayXuatHD = DateTime.Parse(reader["NgayXuatHD"].ToString());
                    hd.TongTien = double.Parse(reader["TongTien"].ToString());
                    hd.TenKH = reader["Tenkh"].ToString();

                    lhd.Add(hd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return lhd;
        }
        public int TongHoaDon()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                int count = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("select dbo.TongDonHang()", con);
                    object result = cmd.ExecuteScalar();
                    count = (int)result;
                    return count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public int TongHoaDonNgayHomNay()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                int count = 0;

                try
                {
                    SqlCommand cmd = new SqlCommand("select dbo.TongDonHangHomNay()", con);
                    object result = cmd.ExecuteScalar();
                    count = (int)result;
                    return count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public double TongDoanhThu()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("select ISNULL(dbo.TongDoanhThu(), 0)", con);
                    object result = cmd.ExecuteScalar();
                    return Convert.ToDouble(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
