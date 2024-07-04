using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangLinhKienMayTinh.Class
{
    internal class ChiTietHoaDon
    {
        public int MaHD {  get; set; }  
        public int MaSP { get; set; }
        public int SoLuongBan {  get; set; }
        public double ThanhTien { get; set; }
        public double GiaBan { get; set; }
        public string TenSP { get; set; }
       
        public ChiTietHoaDon(int mahd,int masp,int soluong,double thanhtien)
        {
            this.MaHD = mahd; 
            this.MaSP = masp;
            this.SoLuongBan = soluong;
            this.ThanhTien = thanhtien;
        }
        public ChiTietHoaDon()
        {

        }
        public void insertCTHD()
        {
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertCTHD", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaHD", this.MaHD);
            cmd.Parameters.AddWithValue("@MaSP", this.MaSP);
            cmd.Parameters.AddWithValue("@SoLuongBan", this.SoLuongBan);
            cmd.Parameters.AddWithValue("@ThanhTien", this.ThanhTien);
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
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

        public static List<ChiTietHoaDon> GetCTHoaDon()
        {
            List<ChiTietHoaDon> CTHoaDon = new List<ChiTietHoaDon>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DaTa_CTHoaDon", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon();
                    cthd.MaHD = int.Parse(reader["MaHD"].ToString());
                    cthd.MaSP = int.Parse(reader["MaSP"].ToString());
                    cthd.SoLuongBan = int.Parse(reader["SoLuongBan"].ToString());
                    cthd.ThanhTien = double.Parse(reader["ThanhTien"].ToString());

                    CTHoaDon.Add(cthd);
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
            return CTHoaDon;
        }

        public static List<ChiTietHoaDon> SearchMAHD(string mahd)
        {
            List<ChiTietHoaDon> lhd = new List<ChiTietHoaDon>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TimKiemHoaDon", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHD", mahd);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon();
                    cthd.MaHD = int.Parse(reader["MaHD"].ToString());
                    cthd.MaSP = int.Parse(reader["MaSP"].ToString());
                    cthd.SoLuongBan = int.Parse(reader["SoLuongBan"].ToString());
                    cthd.ThanhTien = double.Parse(reader["ThanhTien"].ToString());
                    cthd.GiaBan = double.Parse(reader["GiaBan"].ToString());
                    cthd.TenSP = reader["TenSP"].ToString();

                    lhd.Add(cthd);
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
