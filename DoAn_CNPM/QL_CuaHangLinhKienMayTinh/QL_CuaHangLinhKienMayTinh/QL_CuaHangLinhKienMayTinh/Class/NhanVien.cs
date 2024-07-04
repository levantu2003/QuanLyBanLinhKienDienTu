using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Web;

namespace QL_CuaHangLinhKienMayTinh.Class
{
    internal class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public byte[] Anh { get; set; }
        public string SDT { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucVu { get; set; }

        public NhanVien()
        {
            MaNV = 0;
            TenNV = "";
            Anh = new byte[0];
            SDT = "";
            GioiTinh = "";
            DiaChi = "";
            ChucVu = "";
            NgaySinh = DateTime.Now;

        }
        public NhanVien(string tenNV, byte[] anh, string sDT, string gioiTinh, string diaChi, string chucVu, DateTime ngaySinh)
        {


            TenNV = tenNV;
            Anh = anh;
            SDT = sDT;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            ChucVu = chucVu;
            NgaySinh = ngaySinh;
        }
        public static List<NhanVien> GetNhanVien() //lấy toàn bộ danh sách nhân viên//
        {
            List<NhanVien> Nhanvienlist = new List<NhanVien>();

            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GET_NV", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Nhanvienlist.Add(new NhanVien()
                        {
                            MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                            TenNV = reader.GetString(reader.GetOrdinal("TenNV")),
                            Anh = reader.IsDBNull(reader.GetOrdinal("Anh")) ? null : (byte[])reader["Anh"],
                            SDT = reader.GetString(reader.GetOrdinal("SDT")),
                            DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                            GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                            NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                            ChucVu = reader.GetString(reader.GetOrdinal("ChucVu"))
                        });
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
            }
            return Nhanvienlist;
        }
        public int InsertNhanVien() //THÊM NHÂN VIÊN//
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("ThemNhanVien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenNV", TenNV);
                cmd.Parameters.AddWithValue("@Anh", Anh);
                cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                cmd.Parameters.AddWithValue("@SDT", SDT);
                cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                cmd.Parameters.AddWithValue("@ChucVu", ChucVu);
                cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return -1;
                }

            }
        }
        public int CheckMaNV(int maNV)
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CHECK_MANV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", maNV);


                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count;
            }
        }
        //chỉnh sửa thông tin  nhân viên//
        public int UpdateNhanVien(int maNV, string tenNV, byte[] anh, string sDT, string diaChi, string gioiTinh, DateTime ngaySinh, string chucVu)
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateNhanVien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@TenNV", tenNV);
                cmd.Parameters.AddWithValue("@Anh", anh);
                cmd.Parameters.AddWithValue("@SDT", sDT);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);


                return cmd.ExecuteNonQuery();
            }
        }
        //xóa nhân viên//
        public int DeleteNhanVien(int manv)
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DeleteNhanVien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", manv);
                int count = cmd.ExecuteNonQuery();
                return count;

            }
        }
        //tìm nhân viên theo tên//
        public DataTable SearchTenNV(string tennv)
        {
            DataTable result = new DataTable();

            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SearchTenNV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenNV", tennv);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }
            return result;
        }
        //tìm nhân viên theo mã nhân viên//
        public DataTable SearchMaNV(int manv)
        {
            DataTable result = new DataTable();

            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SearchMaNV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", manv);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }

            return result;
        }
        public string findNhanVienByChucVu(int maNV)
        {
            foreach (var item in NhanVien.GetNhanVien())
            {
                if (item.MaNV == maNV)
                {
                    return item.ChucVu;
                }
            }
            return null;    
        }
        public string findTenNhanVien(int maNV)
        {
            foreach (var item in NhanVien.GetNhanVien())
            {
                if (item.MaNV == maNV)
                {
                    return item.TenNV;
                }
            }
            return null;
        }

        public int DemSoLuongNV()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                int count = 0;

                try
                {
                    SqlCommand cmd = new SqlCommand("select dbo.DemSoNhanVien()", con);
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
