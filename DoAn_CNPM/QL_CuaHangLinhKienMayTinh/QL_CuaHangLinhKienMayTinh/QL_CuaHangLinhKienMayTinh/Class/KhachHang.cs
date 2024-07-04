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
    internal class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string GioiTinh { get; set; }

        public KhachHang()
        {
            MaKH = 0;
            TenKH = "";
            DiaChi = "";
            SDT = "";
            GioiTinh = "";
           // MaKH = 0;
        }
        public KhachHang(string tenkh,string diachi,string sdt,string gioitinh)
        {
            TenKH = tenkh;
            DiaChi = diachi;
            SDT = sdt;
            GioiTinh = gioitinh;
        }
        public static List<KhachHang> GetKhachHang()
        {
            List<KhachHang> lKhachHang = new List<KhachHang>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Get_KhachHang", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhachHang kh = new KhachHang();
                    kh.MaKH = int.Parse(reader["MaKH"].ToString());
                    kh.TenKH = reader["TenKH"].ToString();
                    kh.DiaChi = reader["DiaChi"].ToString();
                    kh.SDT = reader["SDT"].ToString();
                    kh.GioiTinh = reader["GioiTinh"].ToString();
                    lKhachHang.Add(kh);
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
            return lKhachHang;
        }
        public string searchTenKhachHang(string SDT)
        {
            string cusName = null;
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("TimKhachHangTheoSDT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SDT", SDT);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    cusName = rd["TenKH"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return cusName;
        }
        public int insertKhachHang()
        {
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertKhachHang", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenKH", TenKH);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi).ToString();
            cmd.Parameters.AddWithValue("@SDT", SDT).ToString();
            cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh).ToString();
            try
            {
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public int deleteKhachHang(int maKH)
        {
            SqlConnection con = new SqlConnection (ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteKhachHang",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            try
            {
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+  ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public int updateKhachHang(int maKH,string tenKH,string diaChi, string sdt, string gioitinh )
        {
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateKhachHang", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            cmd.Parameters.AddWithValue("@TenKH",tenKH);
            cmd.Parameters.AddWithValue("@DiaChi", diaChi).ToString();
            cmd.Parameters.AddWithValue("@SDT", sdt).ToString();
            cmd.Parameters.AddWithValue("@GioiTinh", gioitinh).ToString();
            try
            {
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public static int searchMaKH(string SDT)
        {
            int MaKH = 0;
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();
            SqlCommand cmd = new SqlCommand("TimMaKHTheoSDT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SDT", SDT);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
                MaKH = int.Parse(rd["MaKH"].ToString());
            return MaKH;
        }

        public int DemSoLuongKH()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                int count = 0;

                try
                {
                    SqlCommand cmd = new SqlCommand("select dbo.DemSoKhachHang()", con);
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
    }
}
