using Microsoft.Office.Interop.Excel;
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
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using App = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using QL_CuaHangLinhKienMayTinh.Class;

namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    public partial class QL_FormDoanhThu : Form
    {
        public QL_FormDoanhThu()
        {
            InitializeComponent();
        }
        System.Data.DataTable dt_dt = new System.Data.DataTable();
        public void load_Datagird()
        {
            using (SqlConnection con = new SqlConnection(ConnectDB.conSql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GET_DOANHTHU", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt_dt);
                dataGridView_doanhThu.DataSource = dt_dt;
                dataGridView_doanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void btn_checkYear_Click(object sender, EventArgs e)
        {
            DoanhThu doanhThu = new DoanhThu();
            try
            {
                int nam = dtpk_nam.Value.Year;
                dt_dt = doanhThu.GetDoanhThuTheoThang(nam);

                chart_years.Series.Clear();

                chart_years.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                chart_years.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";

                var lineSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh Thu")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
                    IsValueShownAsLabel = true
                };

                for (int i = 0; i < dt_dt.Rows.Count; i++)
                {
                    double doanhThuValue = Convert.ToDouble(dt_dt.Rows[i]["DT"]);
                    lineSeries.Points.AddXY(dt_dt.Rows[i]["Thang"].ToString(), doanhThuValue);
                }
                chart_years.Series.Add(lineSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void QL_FormDoanhThu_Load(object sender, EventArgs e)
        {
            load_Datagird();
        }

        private void btn_checkMonth_Click(object sender, EventArgs e)
        {
            DoanhThu doanhThu = new DoanhThu();

            try
            {
                int thang = dtpk_thang.Value.Month;
                int nam = dtpk_nam.Value.Year;

                dt_dt = doanhThu.GetDoanhThuTheoNgay(thang, nam);

                chart_month.Series.Clear();

                chart_month.ChartAreas["ChartArea1"].AxisX.Title = "Ngày - Tháng";
                chart_month.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";

                var lineSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh Thu")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
                    IsValueShownAsLabel = true
                };

                for (int i = 0; i < dt_dt.Rows.Count; i++)
                {
                    double doanhThuValue = Convert.ToDouble(dt_dt.Rows[i]["DT"]);
                    string ngayThang = $"{dt_dt.Rows[i]["Ngay"]} - {dt_dt.Rows[i]["Thang"]}";

                    lineSeries.Points.AddXY(ngayThang, doanhThuValue);
                }

                chart_month.Series.Add(lineSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void xuatExcel(DataGridView g, string duongdan, string tentap)
        {
            Excel.Application obj = new Excel.Application();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;

            // Tạo phần Tiêu đề
            Excel.Range head = obj.Range["A1", "E1"];
            head.MergeCells = true;
            head.Value2 = "BÁO CÁO DOANH THU CỬA HÀNG LINK KIỆN ĐIỆN TỪ H2T";
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = 20;
            // Tô màu nền cho dòng tiêu đề
            head.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

            // Duyệt lấy tiêu đề
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[2, i] = g.Columns[i - 1].HeaderText;
            }

            // Duyệt lấy dữ liệu
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 3, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            string tenTapMoi = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string tenDuongDanMoi = Path.Combine(duongdan, tenTapMoi + ".xlsx");

            // Lưu bảng tính với tên mới
            obj.ActiveWorkbook.SaveCopyAs(tenDuongDanMoi);
            obj.ActiveWorkbook.Saved = true;


            // Đóng ứng dụng Excel
            obj.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

        }
        private void btn_printExcel_Click(object sender, EventArgs e)
        {
            xuatExcel(dataGridView_doanhThu, @"C:\Users\Kaiser\Desktop\", "Baocaodoanhthu");
            MessageBox.Show("Đã xuất file Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
