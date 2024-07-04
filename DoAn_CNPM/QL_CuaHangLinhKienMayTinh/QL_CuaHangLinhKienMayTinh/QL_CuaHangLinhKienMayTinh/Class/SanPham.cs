using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_CuaHangLinhKienMayTinh.Class
{
    internal class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongSP { get; set; }
        public DateTime NgaySX { get; set; }
        public double GiaNhap { get; set; }
        public double GiaBan { get; set; }
        public byte[] ImageSP { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string TenNCC { get; set; }
        public string PrintMessage { get; set; }
        public SanPham( string tenSP, int soluongSP, DateTime ngaySX,double giaBan, byte[] imageSP, string moTa,int maLoai, double giaNhap)
        {
            TenSP = tenSP;
            SoLuongSP = soluongSP;
            NgaySX = ngaySX;
            GiaBan = giaBan;
            ImageSP = imageSP;
            MoTa = moTa;
            MaLoai = maLoai;
            GiaNhap = giaNhap;
        }
        public SanPham()
        {
        }

        public static List<SanPham> GetSanPham()
        {
            List<SanPham> lSanPham = new List<SanPham>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DaTa_SanPham", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    SanPham sp = new SanPham();
                    sp.MaSP = int.Parse(reader["MaSP"].ToString());
                    sp.TenSP = reader["TenSP"].ToString();
                    sp.SoLuongSP = int.Parse(reader["SoLuongSP"].ToString());
                    sp.NgaySX = DateTime.Parse(reader["NgaySX"].ToString());
                    sp.GiaBan = double.Parse(reader["GiaBan"].ToString());
                    sp.ImageSP = (byte[])reader["ImageSP"];
                    sp.MoTa = reader["MoTa"].ToString();
                    sp.TrangThai = reader["TrangThai"].ToString();
                    sp.MaLoai = int.Parse(reader["MaLoai"].ToString());
                    sp.GiaNhap = float.Parse(reader["GiaNhap"].ToString());

                    lSanPham.Add(sp);
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
            return lSanPham;
        }

        public static List<SanPham> GetSanPham_NhapHang()
        {
            List<SanPham> lSanPham = new List<SanPham>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Data_SanPham_PhieuNhap", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sp = new SanPham();
                    sp.MaSP = int.Parse(reader["MaSP"].ToString());
                    sp.TenSP = reader["TenSP"].ToString();
                    sp.SoLuongSP = int.Parse(reader["SoLuongSP"].ToString());
                    sp.ImageSP = (byte[])reader["ImageSP"];
                    sp.MaLoai = int.Parse(reader["MaLoai"].ToString());
                    sp.GiaNhap = double.Parse(reader["GiaNhap"].ToString());
                    sp.TenLoai = reader["TenLoai"].ToString();
                    sp.TenNCC = reader["TenNCC"].ToString();

                    lSanPham.Add(sp);
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
            return lSanPham;
        }
        public int insertSanPham()
        {
            int MaSP = -1;

            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Insert_SanPham", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenSP", TenSP);
                    cmd.Parameters.AddWithValue("@SoLuongSP", SoLuongSP);
                    cmd.Parameters.AddWithValue("@NgaySX", NgaySX);
                    cmd.Parameters.AddWithValue("@GiaBan", GiaBan);
                    cmd.Parameters.AddWithValue("@ImageSP", ImageSP);
                    cmd.Parameters.AddWithValue("@MoTa", MoTa);
                    cmd.Parameters.AddWithValue("@MaLoai", MaLoai);
                    cmd.Parameters.AddWithValue("@GiaNhap", GiaNhap);

                    cmd.ExecuteNonQuery();
                    SqlCommand cmdGetMaxMaSP = new SqlCommand("MAX_MASP", con);
                    cmdGetMaxMaSP.CommandType = CommandType.StoredProcedure;

                    object result = cmdGetMaxMaSP.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        MaSP = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: Thêm Sản Phẩm: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }

                return MaSP;
            }
        }

        public int updateSanPham(int MaSP)
        {
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();

            SqlCommand cmd = new SqlCommand("updateSanPhams", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaSP", MaSP);
            cmd.Parameters.AddWithValue("@TenSP", TenSP);
            cmd.Parameters.AddWithValue("@SoLuongSP", SoLuongSP);
            cmd.Parameters.AddWithValue("@NgaySX", NgaySX);
            cmd.Parameters.AddWithValue("@GiaNhap", GiaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", GiaBan);
            cmd.Parameters.AddWithValue("@ImageSP", ImageSP);
            cmd.Parameters.AddWithValue("@MoTa", MoTa);
            //cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
            cmd.Parameters.AddWithValue("@MaLoai", MaLoai);
            PrintMessage = "";
            con.InfoMessage += (object inforSender, SqlInfoMessageEventArgs inforArgs) =>
            {
                PrintMessage += inforArgs.Message + Environment.NewLine;
            };
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public int deleteSanPham(int MaSP)
        {
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            con.Open();

            SqlCommand cmd = new SqlCommand("DeleteSanPham", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSP", MaSP);
            PrintMessage = "";
            con.InfoMessage += (object inforSender, SqlInfoMessageEventArgs inforArgs) =>
            {
                PrintMessage += inforArgs.Message + Environment.NewLine;
            };
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        public void updateSoLuongSP(int maSP, int soLuong)
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateSanPham", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuongSP", soLuong);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: Update Sản Phẩm: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static List<SanPham> SearchSanPham(string TenSp)
        {
            List<SanPham> lSanPham = new List<SanPham>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TimKiemSPTheoTen", con); 
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenSP", TenSp);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sp = new SanPham();
                    //sp.MaSP = int.Parse(reader["MaSP"].ToString());
                    sp.TenSP = reader["TenSP"].ToString();
                    sp.SoLuongSP = int.Parse(reader["SoLuongSP"].ToString());
                   // sp.NgaySX = DateTime.Parse(reader["NgaySX"].ToString());
                    sp.GiaBan = double.Parse(reader["GiaBan"].ToString());
                    //sp.ImageSP = (byte[])reader["ImageSP"];
                    //sp.MoTa = reader["MoTa"].ToString();
                    sp.TrangThai = reader["TrangThai"].ToString();
                   // sp.MaLoai = int.Parse(reader["MaLoai"].ToString());
                    //sp.MaNCC = int.Parse(reader["MaNCC"].ToString());
                    sp.GiaNhap = double.Parse(reader["GiaNhap"].ToString());

                    lSanPham.Add(sp);
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
            return lSanPham;
        }

        public static List<SanPham> SearchGiaSanPham(string gia)
        {
            List<SanPham> lSanPham = new List<SanPham>();
            string connectionString = ConnectDB.conSql;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchGiaSP(@Gia)", con))
                {
                    cmd.Parameters.AddWithValue("@Gia", gia);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham sp = new SanPham();
                            sp.TenSP = reader["TenSP"].ToString();
                            sp.SoLuongSP = int.Parse(reader["SoLuongSP"].ToString());
                            sp.GiaBan = double.Parse(reader["GiaBan"].ToString());
                            sp.TrangThai = reader["TrangThai"].ToString();
                            sp.GiaNhap = double.Parse(reader["GiaNhap"].ToString());

                            lSanPham.Add(sp);
                        }
                    }
                }
            }

            return lSanPham;
        }


        public static List<SanPham> SearchSanPhamByLoai (int LoaiSp)
        {
            List<SanPham> lSanPham = new List<SanPham>();
            SqlConnection con = new SqlConnection(ConnectDB.conSql);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TimKiemSPTheoLoai", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLoai", LoaiSp);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sp = new SanPham();
                    sp.MaSP = int.Parse(reader["MaSP"].ToString());
                    sp.TenSP = reader["TenSP"].ToString();
                    sp.SoLuongSP = int.Parse(reader["SoLuongSP"].ToString());
                    sp.NgaySX = DateTime.Parse(reader["NgaySX"].ToString());
                    sp.GiaBan = double.Parse(reader["GiaBan"].ToString());
                    sp.ImageSP = (byte[])reader["ImageSP"];
                    sp.MoTa = reader["MoTa"].ToString();
                    sp.TrangThai = reader["TrangThai"].ToString();
                    sp.MaLoai = int.Parse(reader["MaLoai"].ToString());
                    sp.GiaNhap = double.Parse(reader["GiaNhap"].ToString());

                    lSanPham.Add(sp);
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
            return lSanPham;
        }
        public int DemSoLuongSP()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                int count = 0;

                try
                {
                    SqlCommand cmd = new SqlCommand("select dbo.DemSoLuongSP()", con);
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
        public int DemSoLuongSPSapHetHang()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                int count = 0;

                try
                {
                    SqlCommand cmd = new SqlCommand("select dbo.DemSoLuongSPSapHetHang()", con);
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
        public DataTable LoadTop5SanPhamBanChay()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Top5SanPhamBanChay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    dataTable.Load(cmd.ExecuteReader());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

            return dataTable;
        }
        public DataTable LoadAllProducts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetAllProducts", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return dt;
        }
    }
}
