using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_CuaHangLinhKienMayTinh.Class
{
    internal class ChiTietPhieuNhapHang
    {
        public int MaPhieu { get; set; }
        public int MaSP { get; set; }
        public int SoLuongNhap { get; set; }    
        public double DonGiaNhap { get; set; }
        public double ThanhTien { get; set; }

        public ChiTietPhieuNhapHang(int maPhieu, int maSP, int soLuong, double donGia, double thanhtien)
        {
            MaPhieu = maPhieu;
            MaSP = maSP;
            SoLuongNhap = soLuong;
            DonGiaNhap = donGia;
            ThanhTien = thanhtien;
        }

        public ChiTietPhieuNhapHang()
        {
        }

        public void insertCTPN()
        {
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("insertCTPhieuNhap", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieu", this.MaPhieu);
            cmd.Parameters.AddWithValue("@MaSP", this.MaSP);
            cmd.Parameters.AddWithValue("@SoLuong", this.SoLuongNhap);
            cmd.Parameters.AddWithValue("@DonGia", this.DonGiaNhap);
            cmd.Parameters.AddWithValue("@ThanhTien", this.ThanhTien);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public static List<ChiTietPhieuNhapHang> GetCTPhieuNhap()
        {
            List<ChiTietPhieuNhapHang> CTPhieuNhap = new List<ChiTietPhieuNhapHang>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DaTa_CTPhieuNhap", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietPhieuNhapHang ctpn = new ChiTietPhieuNhapHang();
                    ctpn.MaPhieu = int.Parse(reader["MaPhieu"].ToString());
                    ctpn.MaSP = int.Parse(reader["MaSP"].ToString());
                    ctpn.SoLuongNhap = int.Parse(reader["SoLuongNhap"].ToString());
                    ctpn.DonGiaNhap = double.Parse(reader["DonGiaNhap"].ToString());
                    ctpn.ThanhTien = double.Parse(reader["ThanhTien"].ToString());

                    CTPhieuNhap.Add(ctpn);
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
            return CTPhieuNhap;
        }

        public static List<ChiTietPhieuNhapHang> SearchMAPN(int mapn)
        {
            List<ChiTietPhieuNhapHang> lhd = new List<ChiTietPhieuNhapHang>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TimKiemTheoMAPN", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhieu", mapn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietPhieuNhapHang ctpn = new ChiTietPhieuNhapHang();
                    ctpn.MaPhieu = int.Parse(reader["MaPhieu"].ToString());
                    ctpn.MaSP = int.Parse(reader["MaSP"].ToString());
                    ctpn.SoLuongNhap = int.Parse(reader["SoLuongNhap"].ToString());
                    ctpn.DonGiaNhap = double.Parse(reader["DonGiaNhap"].ToString());
                    ctpn.ThanhTien = double.Parse(reader["ThanhTien"].ToString());
                    lhd.Add(ctpn);
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

    }
}
