using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace QL_CuaHangLinhKienMayTinh.Class
{
    internal class TaiKhoan
    {
        public int MANV {  get; set; }
        public string UserName {  get; set; }
        public string Password {  get; set; }
        public string ChucVu { get; set; }
        public string TenNV { get; set; }
        public byte[] Anh { get; set; }
        public TaiKhoan()
        {
            MANV = 0;
            UserName = string.Empty;
            Password = string.Empty;
        }
        public TaiKhoan(int maNv, string userName, string password)
        {
            MANV = maNv;
            UserName = userName;
            Password = password;
        }
        public static List<TaiKhoan> GetTaiKhoan()
        {
            List<TaiKhoan> Taikhoanlist = new List<TaiKhoan>();

            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GET_TK", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Taikhoanlist.Add(new TaiKhoan()
                        {
                            MANV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                            TenNV = reader.GetString(reader.GetOrdinal("TenNV")),
                            UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            Password = reader.GetString(reader.GetOrdinal("PassWord")),
                            Anh = reader.IsDBNull(reader.GetOrdinal("Anh")) ? null : (byte[])reader["Anh"],
                            ChucVu = reader.GetString(reader.GetOrdinal("ChucVu")),
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
            return Taikhoanlist;

        }

        public bool Login(string user, string pass)
        {
            foreach (var item in TaiKhoan.GetTaiKhoan())
            {
                if (user == item.UserName && pass == item.Password)
                {
                    return true;
                }
            }
            return false;
        }
        public int FindMaNVByTK(string user)
        {
            foreach (var item in TaiKhoan.GetTaiKhoan())
            {
                if (user == item.UserName)
                {
                    return item.MANV;
                }
            }
            return 0;
        }
        public int InsertTaiKhoan()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                if (IsTaiKhoanExists())
                {
                    MessageBox.Show("Nhân viên đã có tài khoản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                SqlCommand cmd = new SqlCommand("ThemTaiKhoan", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", MANV);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@PassWord", Password);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private bool IsTaiKhoanExists()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE MaNV = @MaNV", con);
                cmd.Parameters.AddWithValue("@MaNV", MANV);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public int CheckUserName(string username)
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CHECK_USERNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);


                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count;
            }
        }
        public int UpdateTaiKhoan(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdatePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@NewPassword", password);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteTaiKhoan(string username)
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE_TK", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);
                int count = cmd.ExecuteNonQuery();
                return count;

            }
        }
        public DataTable SearchMaNV_TaiKhoan(int manv)
        {
            DataTable result = new DataTable();

            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Search_TaiKhoan(@MaNV)", con);
                cmd.Parameters.AddWithValue("@MaNV", manv);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }

            return result;
        }



    }
}
