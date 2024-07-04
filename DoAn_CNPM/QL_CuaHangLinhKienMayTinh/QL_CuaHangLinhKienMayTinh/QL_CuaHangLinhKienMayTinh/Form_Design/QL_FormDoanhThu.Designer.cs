namespace QL_CuaHangLinhKienMayTinh.Form_Design
{
    partial class QL_FormDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QL_FormDoanhThu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_printExcel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_checkMonth = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_checkYear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpk_thang = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpk_nam = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_doanhThu = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chart_month = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chart_years = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_doanhThu)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_month)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_years)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_printExcel);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpk_thang);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dtpk_nam);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(16, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 302);
            this.panel1.TabIndex = 0;
            // 
            // btn_printExcel
            // 
            this.btn_printExcel.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_printExcel.FlatAppearance.BorderSize = 0;
            this.btn_printExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_printExcel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printExcel.ForeColor = System.Drawing.Color.White;
            this.btn_printExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_printExcel.ImageKey = "icon_excels.png";
            this.btn_printExcel.ImageList = this.imageList1;
            this.btn_printExcel.Location = new System.Drawing.Point(249, 231);
            this.btn_printExcel.Name = "btn_printExcel";
            this.btn_printExcel.Size = new System.Drawing.Size(265, 55);
            this.btn_printExcel.TabIndex = 10;
            this.btn_printExcel.Text = "Xuất Excel";
            this.btn_printExcel.UseVisualStyleBackColor = false;
            this.btn_printExcel.Click += new System.EventHandler(this.btn_printExcel_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_chart.png");
            this.imageList1.Images.SetKeyName(1, "icon_excels.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_checkMonth);
            this.groupBox2.Location = new System.Drawing.Point(414, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 111);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doanh Thu Theo Tháng";
            // 
            // btn_checkMonth
            // 
            this.btn_checkMonth.BackColor = System.Drawing.Color.DarkRed;
            this.btn_checkMonth.FlatAppearance.BorderSize = 0;
            this.btn_checkMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_checkMonth.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkMonth.ForeColor = System.Drawing.Color.White;
            this.btn_checkMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_checkMonth.ImageKey = "icon_chart.png";
            this.btn_checkMonth.ImageList = this.imageList1;
            this.btn_checkMonth.Location = new System.Drawing.Point(19, 45);
            this.btn_checkMonth.Name = "btn_checkMonth";
            this.btn_checkMonth.Size = new System.Drawing.Size(265, 53);
            this.btn_checkMonth.TabIndex = 10;
            this.btn_checkMonth.Text = "Kiểm Tra";
            this.btn_checkMonth.UseVisualStyleBackColor = false;
            this.btn_checkMonth.Click += new System.EventHandler(this.btn_checkMonth_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_checkYear);
            this.groupBox1.Location = new System.Drawing.Point(43, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 111);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh Thu Theo Năm";
            // 
            // btn_checkYear
            // 
            this.btn_checkYear.BackColor = System.Drawing.Color.DarkRed;
            this.btn_checkYear.FlatAppearance.BorderSize = 0;
            this.btn_checkYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_checkYear.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkYear.ForeColor = System.Drawing.Color.White;
            this.btn_checkYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_checkYear.ImageKey = "icon_chart.png";
            this.btn_checkYear.ImageList = this.imageList1;
            this.btn_checkYear.Location = new System.Drawing.Point(22, 43);
            this.btn_checkYear.Name = "btn_checkYear";
            this.btn_checkYear.Size = new System.Drawing.Size(257, 56);
            this.btn_checkYear.TabIndex = 10;
            this.btn_checkYear.Text = "Kiểm Tra";
            this.btn_checkYear.UseVisualStyleBackColor = false;
            this.btn_checkYear.Click += new System.EventHandler(this.btn_checkYear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chọn Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Chọn Năm";
            // 
            // dtpk_thang
            // 
            this.dtpk_thang.CustomFormat = "MM";
            this.dtpk_thang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_thang.Location = new System.Drawing.Point(160, 58);
            this.dtpk_thang.Name = "dtpk_thang";
            this.dtpk_thang.ShowUpDown = true;
            this.dtpk_thang.Size = new System.Drawing.Size(201, 34);
            this.dtpk_thang.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 41);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(243, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kiểm Tra Doanh Thu";
            // 
            // dtpk_nam
            // 
            this.dtpk_nam.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_nam.CausesValidation = false;
            this.dtpk_nam.CustomFormat = "yyyy";
            this.dtpk_nam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_nam.Location = new System.Drawing.Point(531, 57);
            this.dtpk_nam.Name = "dtpk_nam";
            this.dtpk_nam.ShowUpDown = true;
            this.dtpk_nam.Size = new System.Drawing.Size(201, 34);
            this.dtpk_nam.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView_doanhThu);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(843, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(882, 302);
            this.panel3.TabIndex = 11;
            // 
            // dataGridView_doanhThu
            // 
            this.dataGridView_doanhThu.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_doanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_doanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_doanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_doanhThu.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView_doanhThu.Location = new System.Drawing.Point(0, 41);
            this.dataGridView_doanhThu.Name = "dataGridView_doanhThu";
            this.dataGridView_doanhThu.RowHeadersWidth = 51;
            this.dataGridView_doanhThu.RowTemplate.Height = 24;
            this.dataGridView_doanhThu.Size = new System.Drawing.Size(880, 259);
            this.dataGridView_doanhThu.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(880, 41);
            this.panel4.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(352, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Bảng Doanh Thu";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.chart_month);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(843, 335);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(882, 576);
            this.panel5.TabIndex = 13;
            // 
            // chart_month
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_month.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_month.Legends.Add(legend1);
            this.chart_month.Location = new System.Drawing.Point(3, 47);
            this.chart_month.Name = "chart_month";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_month.Series.Add(series1);
            this.chart_month.Size = new System.Drawing.Size(874, 524);
            this.chart_month.TabIndex = 2;
            this.chart_month.Text = "chart2";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LimeGreen;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(880, 41);
            this.panel6.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(352, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Doanh Thu Theo Tháng";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.chart_years);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(16, 334);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(804, 577);
            this.panel7.TabIndex = 12;
            // 
            // chart_years
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_years.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_years.Legends.Add(legend2);
            this.chart_years.Location = new System.Drawing.Point(3, 47);
            this.chart_years.Name = "chart_years";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Thang";
            series2.YValuesPerPoint = 3;
            this.chart_years.Series.Add(series2);
            this.chart_years.Size = new System.Drawing.Size(796, 525);
            this.chart_years.TabIndex = 1;
            this.chart_years.Text = "chart1";
            title1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Biểu Đồ Doanh Thu Theo Năm";
            this.chart_years.Titles.Add(title1);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LimeGreen;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label8);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(802, 41);
            this.panel8.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(243, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Doanh Thu Theo Năm";
            // 
            // QL_FormDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1798, 1055);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Name = "QL_FormDoanhThu";
            this.Text = "Doanh thu";
            this.Load += new System.EventHandler(this.QL_FormDoanhThu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_doanhThu)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_month)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_years)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpk_thang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpk_nam;
        private System.Windows.Forms.Button btn_checkYear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_printExcel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_checkMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView_doanhThu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_month;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_years;
    }
}