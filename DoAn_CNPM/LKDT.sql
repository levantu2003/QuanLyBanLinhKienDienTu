CREATE DATABASE QL_CUA_HANG_LINH_KIEN_MAY_TINH_CNPM
go
USE QL_CUA_HANG_LINH_KIEN_MAY_TINH_CNPM

CREATE TABLE LOAISP
(
  MaLoai  INT IDENTITY(1,1),
  TenLoai NVARCHAR(50),
  CONSTRAINT PK_LoaiSP PRIMARY KEY (MaLoai)
);
GO

CREATE TABLE NHACUNGCAP
(
  MaNCC INT IDENTITY(1,1),
  TenNCC NVARCHAR(50),
  SDT CHAR(12),
  Email NVARCHAR(30),
  DiaChi NVARCHAR(100),
  CONSTRAINT PK_NHACC PRIMARY KEY (MaNCC)
);
GO

CREATE TABLE SANPHAM
(
  MaSP INT IDENTITY(1,1),
  TenSP NVARCHAR(50),
  SoLuongSP INT,
  NgaySX DATE,
  GiaBan FLOAT,
  GiaNhap float,
  ImageSP varbinary(Max),
  MoTa NVARCHAR(200),
  TrangThai NVARCHAR(20),
  MaLoai INT,
  CONSTRAINT PK_SP PRIMARY KEY (MaSP),
  CONSTRAINT FK_SP_LOAISP FOREIGN KEY (MaLoai) REFERENCES LOAISP(MaLoai),
);
GO

CREATE TABLE KHACHHANG
(
  MaKH INT IDENTITY(1,1),
  TenKH NVARCHAR(50),
  DiaChi NVARCHAR(100),
  SDT CHAR(12),
  GioiTinh NCHAR(5),
  CONSTRAINT PK_KH PRIMARY KEY (MaKH)
);
GO

CREATE TABLE NHANVIEN
(
  MaNV INT IDENTITY(1,1),
  TenNV NVARCHAR(50),
  Anh IMAGE,
  SDT CHAR(12),
  DiaChi NVARCHAR(100),
  GioiTinh NCHAR(5),
  NgaySinh DATE,
  ChucVu NVARCHAR(20),
  CONSTRAINT PK_NV PRIMARY KEY (MaNV)
);
GO

CREATE TABLE TAIKHOAN
( 
  MaNV INT,
  Username NVARCHAR(50) NOT NULL,
  Password NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_TK PRIMARY KEY (Username),
  CONSTRAINT FK_TK_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO

CREATE TABLE HOADON
(
  MaHD INT IDENTITY(1,1),
  MaKH INT,
  MaNV INT,
  NgayXuatHD DATE,
  TongTien FLOAT,
  CONSTRAINT PK_HD PRIMARY KEY (MaHD),
  CONSTRAINT FK_HD_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
  CONSTRAINT FK_HD_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO
select * from SANPHAM
CREATE TABLE CHITIETHD
(
  MaHD INT,
  MaSP INT,
  SoLuongBan INT,
  ThanhTien FLOAT,
  CONSTRAINT PK_CTHD PRIMARY KEY (MaHD, MaSP),
  CONSTRAINT FK_CTHD_HD FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD),
  CONSTRAINT FK_CTHD_SP FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);
GO



insert into HOADON(MaKH,MaNV,NgayXuatHD,TongTien)
values(2,2,'22-12-2023',300000)
insert into HOADON(MaKH,MaNV,NgayXuatHD,TongTien)
values(3,2,'21-12-2023',400000)
insert into HOADON(MaKH,MaNV,NgayXuatHD,TongTien)
values(4,2,'20-12-2023',500000)

insert into HOADON(MaKH,MaNV,NgayXuatHD,TongTien)
values(5,2,'20-11-2023',900000)
insert into HOADON(MaKH,MaNV,NgayXuatHD,TongTien)
values(6,2,'20-10-2023',1000000)
insert into HOADON(MaKH,MaNV,NgayXuatHD,TongTien)
values(7,2,'20-9-2023',1500000)

CREATE TABLE PHIEUNHAPHANG
(
  MaPhieu INT IDENTITY(1,1),
  MaNV INT,
  MaNCC INT,
  NgayNhap DATE,
  GhiChu NVARCHAR(100),
  TongTienNhap FLOAT,
  CONSTRAINT PK_PNH PRIMARY KEY (MaPhieu),
  CONSTRAINT FK_PNH_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
   CONSTRAINT FK_PNH_NCC FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC)
);
GO

-- Tạo bảng CHITIETPN
CREATE TABLE CHITIETPN
(
  MaPhieu INT,
  MaSP INT,
  SoLuongNhap INT,
  DonGiaNhap FLOAT,
  ThanhTien FLOAT,
  CONSTRAINT PK_CTPN PRIMARY KEY (MaPhieu, MaSP),
  CONSTRAINT FK_CTPN_PN FOREIGN KEY (MaPhieu) REFERENCES PHIEUNHAPHANG(MaPhieu),
  CONSTRAINT FK_CTPN_SP FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);
 SET DATEFORMAT DMY
GO
---------------------RÀNG BUỘC TOÀN VẸN DÙNG TRIGGER---------------------
--TRIGGER CẬP NHẬT TRẠNG THÁI SẢN PHẨM
CREATE TRIGGER update_TrangThai_SP
ON SANPHAM
AFTER INSERT, UPDATE
AS
BEGIN
-- Cập nhật trạng thái cho sản phẩm
	IF UPDATE(soluongSP)
    UPDATE SANPHAM
    SET TrangThai = 
        CASE
            WHEN SANPHAM.SoLuongSP >= 10 THEN N'Đang bán'
            WHEN SANPHAM.SoLuongSP < 10  AND  SANPHAM.SoLuongSP >0 THEN  N'Sắp hết hàng'
			WHEN SANPHAM.SoLuongSP = 0 THEN N'Tạm hết hàng'
        END
    FROM SANPHAM
    INNER JOIN inserted ON SANPHAM.MaSP = inserted.MaSP
END
GO

--Cập nhật số lượng sản phẩm khi bán
CREATE TRIGGER	Update_SL_SP
ON ChiTietHD
AFTER INSERT
AS 
BEGIN
	DECLARE @SLSP INT
	SET @SLSP=(SELECT SoLuongSP FROM dbo.SANPHAM WHERE MaSP=(SELECT MaSP FROM inserted))-(SELECT SoLuongBan FROM inserted)
    UPDATE dbo.SANPHAM
	SET SoLuongSP=@SLSP
	WHERE MaSP=(SELECT MaSP FROM inserted)
END
GO

--Cập nhật thành tiền của chi tiết phiếu nhập
CREATE TRIGGER Update_ThanhTien_PhieuNhap
ON ChiTietPN
FOR INSERT
AS 
BEGIN
	DECLARE @MaCTPN INT
	SET @MaCTPN =(SELECT MaPhieu FROM inserted)
	DECLARE @MaSP INT
	SET @MaSP =(SELECT Inserted.MaSP FROM inserted)
    UPDATE ChiTietPN
	SET ThanhTien=(SELECT SoLuongNhap FROM inserted)*(SELECT DonGiaNhap FROM inserted)
	WHERE dbo.CHITIETPN.MaPhieu=@MaCTPN AND CHITIETPN.MaSP=@MaSP
END
GO


CREATE FUNCTION Tinh_TongTienPhieuNhap (@MaPN int)
RETURNS FLOAT	
AS
	BEGIN
		DECLARE @TongTien FLOAT	
		SET @TongTien=   (SELECT  SUM(ThanhTien) FROM dbo.CHITIETPN WHERE MaPhieu=@MaPN)
		RETURN	 @TongTien
	END
GO	
--Cập nhật tổng thành tiền của phiếu nhập
CREATE TRIGGER Update_TongTien_PhieuNhap
ON CHITIETPN
FOR INSERT, UPDATE
AS 
BEGIN
    DECLARE @MaPhieu INT
    SELECT @MaPhieu = MaPhieu FROM inserted
    UPDATE dbo.PHIEUNHAPHANG
    SET TongTienNhap = dbo.Tinh_TongTienPhieuNhap(@MaPhieu)
    WHERE MaPhieu = @MaPhieu
END
GO




---------------------------------CÁC RÀNG BUỘC-----------------------
------------RÀNG BUỘC KIỂM TRA MIỀN GIÁ TRỊ(CHECK CONSTRAINT)-----------------
----1.BẢNG SẢN PHẨM---

ALTER TABLE SANPHAM
ADD CONSTRAINT CK_GIABAN CHECK(GiaBan>0)
GO

-----2.BẢNG CHITIETHD---
ALTER TABLE CHITIETHD
ADD CONSTRAINT CK_SOLUONG CHECK(SoLuongBan>0)
GO

-----3.BẢNG  CHITIETPN---
ALTER TABLE  CHITIETPN
ADD CONSTRAINT CK_SOLUONGNHAP CHECK(SoLuongNhap>0)
GO

ALTER TABLE  CHITIETPN
ADD CONSTRAINT CK_DONGIANHAP CHECK(DonGiaNhap>0)
GO
-----4.BẢNG  KHACHHANG---
ALTER TABLE KHACHHANG
ADD CONSTRAINT CK_GIOITINH_KH CHECK(GioiTinh IN(N'Nam', N'Nữ'))
GO

-----5.BẢNG  KHACHHANG---
ALTER TABLE NHANVIEN
ADD CONSTRAINT CK_GIOITINH_NV CHECK(GioiTinh IN(N'Nam', N'Nữ'))
GO

ALTER TABLE NHANVIEN
ADD CONSTRAINT CK_CHUCVU CHECK(ChucVu IN(N'Quản lý',N'Nhân viên'))
GO

--------RÀNG BUỘC KIỂM TRA TÍNH DUY NHẤT (UNIQUE CONSTRAINT)-----------------

----1.BẢNG LOAISP---
ALTER TABLE LOAISP
ADD CONSTRAINT UNI_TENLOAI UNIQUE(TenLoai)
GO

----2.BẢNG NHACUNGCAP---
ALTER TABLE NHACUNGCAP
ADD CONSTRAINT UNI_TENNCC UNIQUE(TenNcc)
GO

----3.BẢNG SANPHAM---
ALTER TABLE SANPHAM
ADD CONSTRAINT UNI_TENSP UNIQUE(TenSP)
GO

----4.BẢNG SANPHAM---
ALTER TABLE TAIKHOAN
ADD CONSTRAINT UNI_MANV UNIQUE(MaNV)
GO

--------RÀNG BUỘC KIỂM TRA GIÁ TRỊ MẶC ĐỊNH (DEFAULT CONSTRAINT)-----------------
 ----1.BẢNG NHANVIEN---
 ALTER TABLE NHANVIEN
 ADD CONSTRAINT DF_DIACHI_NV DEFAULT N'Chưa xác định' FOR DiaChi
GO

----2.BẢNG KHACHHANG---
ALTER TABLE KHACHHANG
ADD CONSTRAINT DF_DIACHI_KH DEFAULT N'Chưa xác định' FOR DiaChi
GO

----3.BẢNG NHACUNGCAP---
ALTER TABLE NHACUNGCAP
ADD CONSTRAINT DF_DIACHI_NCC DEFAULT N'Chưa xác định' FOR DiaChi
GO


-------------------******************** THÊM DỮ LIỆU *********************************-----------------------------

--<** Loại Sản Phẩm **>--
INSERT INTO LOAISP
VALUES
( N'Chuột'),
( N'Màn Hình'),
(N'Bàn Phím'),
( N'Case PC'),
( N'Tai Nghe')
GO
--<** Loại Sản Phẩm **>--
INSERT INTO NHACUNGCAP
VALUES 
(N'SamSung','0988558234','SamSung@gmail.com',N'123 Lê Trọng Tấn,Tân Phú,TP.HCM'),
(N'Asus','0982839123','Asus@gmail.com',N'24/157 Nguyễn Trãi,Tân Đông,Quận 3,TP.HCM'),
(N'Dell','0388838223','Dell@gmail.com',N'40B Lê Lợi,Tân Hưng Thuận,Hà Nội'),
(N'Razer','0983774723','Razer@gmail.com',N'98 Nguyễn Diệu,Hội An,TP Đà Nẵng'),
(N'Logitech','0983772133','Logitech@gmail.com',N'293/43 Nguyễn Văn Minh, TP.HCM'),
(N'HyperX','0375674783','HyperX@gmail.com',N'40/12/22 Hoàng Sa,Phường 3, Bình Thạnh,TP HCM'),
(N'Gigabyte','0387645321','Giagabyte@gmail.com',N'430/12/1 CMT8,Phường 5, Tân Bình, TP.HCM'),
(N'Corsair','097644552','Corsair@gmail.com',N'250 Bùi Xuân Phái, Tây Thạnh, Tân Phú, TP.HCM'),
(N'Acer','09322111233','Acer@gmail.com',N'330/20/11A, Nguyễn Đình Chiểu, Phường 3 Tân Bình, TP.HCM')
GO

--<** Loại Sản Phẩm **>--
--INSERT INTO SANPHAM
--VALUES
--(N'Chuột Logitech G102 LightSync Black',0, '12-09-2022',200000, NULL, NULL,NULL,NUll,1,1),
--(N'PC GVN Intel i5-13400F/ VGA RTX 4060 Ti',0, '09-10-2019',150000, NULL, NULL, NULL,NULL,2,1),
--(N'Bàn phím cơ ASUS ROG Strix Flare II Nx Red Switch',0, '09-10-2019',150000, NULL, NULL, NULL,NULL,1,2),
--(N'Màn hình ASUS VA27EHF 27" IPS 100Hz viền mỏng',0, '09-10-2019',1200000, NULL, NULL, NULL,NUll,3,2)


--<** Khách Hàng **>--
INSERT INTO KHACHHANG
VALUES
( N'Nguyễn Thu Tâm', N'Tây Ninh', '0989751723',N'Nữ'),
( N'Đinh Bảo Lộc', N'Lâm Đồng', '0918234654',N'Nam'),
( N'Trần Thanh Diệu', N'TP.HCM', '0978123765',N'Nữ'),
( N'Nguyễn Văn Thanh', N'Quảng Nam', '0918373790',N'Nam'),
( N'Nguyễn Trần Khánh Vân', N'TP.HCM', '0746902764',N'Nữ'),
( N'Đỗ Minh Hải', N'Quảng Bình', '0397238143',N'Nam'),
( N'Nguyễn Hải Yến', N'Cà Mau', '0398571209',N'Nữ'),
( N'Hà Đức Tài', N'TP.Vinh', '0554970710',N'Nam'),
( N'Ngô Minh Hải', N'Nghệ An', '0387238143',N'Nam'),
( N'Đỗ Thị Tường Vy', N'Hà Nội', '0559708156',N'Nữ'),
( N'Hồ Lê Khoa', N'Quảng Ngãi', '0327890456',N'Nữ'),
( N'Nguyễn Khánh Hữu', N'TP.HCM', '0778990399',N'Nam'),
( N'Trần Minh Hải', N'TP.HCM', '035278910',N'Nữ')
GO

--<** Nhân Viên **>--
INSERT INTO NHANVIEN
VALUES
(N'Đỗ Bảo Toàn',NULL,'09477223664',N'Quảng Ngãi',N'Nam','19-12-1999',N'Quản lý'),
(N'Nguyễn Thị Thu Hà',NULL,'0988558043',N'TP.HCM',N'Nữ','21-01-2004',N'Nhân viên'),
(N'Trần Ngọc Thanh',NULL,'0647094638',N'TP.HCM',N'Nam','19-09-2003',N'Nhân viên'),
(N'Hồ Tuấn Thành',NULL,'0376103847',N'TP.Đà Nẵng',N'Nam','10-12-2003',N'Nhân viên'),
(N'Bùi Quỳnh Ly',NULL,'0758012637',N'TP.HCM',N'Nam','05-08-2002',N'Nhân viên')
GO

--<** Tài Khoản **>--
INSERT INTO TAIKHOAN
VALUES
(1,N'dobaotoan','123'),
(2,N'thuhanguyen','123'),
(3,N'ngocthanh','123')
GO


----***//--11<Những sản phẩm gần hết hàng> 
CREATE PROCEDURE GetCountSanPhamSapHetHang
AS
BEGIN
    SELECT COUNT(*) AS SoLuongSapHetHang
    FROM SANPHAM
    WHERE TrangThai = N'Sắp hết hàng';
END
GO


	
----***//--1<Top 5 sản phẩm bán chạy nhất> 
create proc Top5SanPhamBanChay
as
	  SELECT TOP 5 
        sp.TenSP AS TenSanPham,
        SUM(ct.SoLuongBan) AS TongSoLuongBan
    FROM 
        SANPHAM sp
    INNER JOIN 
        CHITIETHD ct ON sp.MaSP = ct.MaSP
    GROUP BY 
        sp.TenSP
    ORDER BY 
        SUM(ct.SoLuongBan) DESC
GO
----***//--2<Lấy danh sách sản phẩm và số lượng> 
CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT TenSP,SoLuongSP
    FROM SANPHAM;
END
GO
----***//--3<Lấy dữ liệu khách hàng> 
Create Proc Get_KhachHang
as
	select * from KHACHHANG
GO
----***//--4<Thêm dữ liệu khách hàng> 
CREATE PROCEDURE InsertKhachHang
    @TenKH NVARCHAR(50),
    @DiaChi NVARCHAR(100),
    @SDT CHAR(12),
    @GioiTinh NCHAR(5)
AS
BEGIN
    INSERT INTO KHACHHANG (TenKH, DiaChi, SDT, GioiTinh)
    VALUES (@TenKH, @DiaChi, @SDT, @GioiTinh)
END
GO
----***//--5<Xóa dữ liệu khách hàng> 
create procedure DeleteKhachHang
@MaKH int
as
	if exists (Select 1 from HoaDon where MaKH = @MaKH)
		return -1
	else
		delete from KhachHang where MaKH = @MaKH
GO
----***//--6<Update dữ liệu khách hàng> 
Create PROC UpdateKhachHang
 @MaKH int ,@TenKH NVARCHAR(50), @DiaChi NVARCHAR(100), @SDT CHAR(12), @GioiTinh NCHAR(5)
as
  begin
	update KHACHHANG set TenKH = @TenKH , DiaChi =@DiaChi, SDT =@SDT , GioiTinh = @GioiTinh where MaKH = @MaKH
  end
GO
----***//--7<Thêm dữ liệu hóa đơn>
CREATE PROCEDURE InsertHD
    @MaKH INT,
    @MaNV INT,
    @NgayXuatHD DATETIME,
	@TongTien FLOAT
    
AS
	BEGIN
		INSERT INTO HOADON(MaKH,MaNV,NgayXuatHD,TongTien)
		VALUES (@MaKH, @MaNV, @NgayXuatHD,@TongTien)
	END
GO
----***//--8<Lấy max mã hóa đơn>
CREATE PROC MAX_MAHD
AS
 BEGIN
	SELECT MAX(MaHD) AS MaxMaHD FROM HOADON
END
GO
----***//--9<In hóa đơn>
create Proc InHoaDon
@MaHD int
AS
	SELECT HOADON.MaHD, KHACHHANG.TenKH, KHACHHANG.SDT, NHANVIEN.TenNV, HOADON.NgayXuatHD,SANPHAM.TenSP, SANPHAM.GiaBan, CHITIETHD.SoLuongBan, CHITIETHD.ThanhTien,HOADON.TongTien
	FROM HOADON,CHITIETHD,KHACHHANG,SANPHAM,NHANVIEN
	where SANPHAM.MaSP = CHITIETHD.MaSP and KHACHHANG.MaKH = HOADON.MaKH and HOADON.MaHD = CHITIETHD.MaHD and NHANVIEN.MaNV = HOADON.MaNV and HOADON.MaHD = @MaHD
GO
----***//--10<Thêm dữ liệu chi tiết hóa đơn>
CREATE PROCEDURE InsertCTHD
    @MaHD INT,
    @MaSP INT,
    @SoLuongBan INT,
	@ThanhTien FLOAT  
AS
	BEGIN
		INSERT INTO CHITIETHD(MaHD,MaSP,SoLuongBan,ThanhTien)
		VALUES (@MaHD, @MaSP, @SoLuongBan,@ThanhTien)
	END
GO
----***//--11<Tìm kiếm sản phẩm theo tên> 
create proc TimKiemSPTheoTen
@TenSP nvarchar(50)
as
	Select * from SanPham where TenSP Like '%' + @TenSP + '%'
GO


----***//--12<Tìm kiếm sản phẩm theo loại> 
CREATE PROC TimKiemSPTheoLoai
    @MaLoai INT
AS
    SELECT *
    FROM SANPHAM
    WHERE MaLoai = @MaLoai
GO
----***//--13<Tìm tên khách hàng theo số điện thoại> 
CREATE PROC TimKhachHangTheoSDT
@SDT CHAR(12)
AS
	BEGIN
		SELECT TenKH FROM KHACHHANG WHERE SDT=@SDT
	END
GO
----***//--14<Tìm kiếm sản phẩm theo tên loại> 
create proc TimKiemTheoTenLoai
@TenLoai nvarchar(50)
as
	Select * from LOAISP where TenLoai Like '%' + @TenLoai + '%'
GO
----***//--15<Tìm mã khách hàng theo số điện thoại> 
CREATE PROC TimMaKHTheoSDT
@SDT CHAR(12)
AS
	BEGIN
		SELECT MAKH FROM KHACHHANG WHERE SDT=@SDT
	END
GO
----***//--16<Tìm mã nhà cung cấp> 
CREATE PROC Search_MaNCC
@MaNCC int
 AS
	SELECT DISTINCT NHACUNGCAP.MaNCC,LOAISP.MaLoai,SANPHAM.MaSP,SANPHAM.TenSP,SANPHAM.SoLuongSP,SANPHAM.ImageSP,SANPHAM.GiaNhap,NHACUNGCAP.TenNCC,LOAISP.TenLoai
	FROM NHACUNGCAP,LOAISP,PHIEUNHAPHANG,SANPHAM,CHITIETPN
	where NHACUNGCAP.MaNCC = PHIEUNHAPHANG.MaNCC and LOAISP.MaLoai = SANPHAM.MaLoai and SANPHAM.MaSP = CHITIETPN.MaSP and PHIEUNHAPHANG.MaPhieu = CHITIETPN.MaPhieu and PHIEUNHAPHANG.MaNCC = @MaNCC
GO
-----------------------FUNCTION---------------------------
--1.Tính tổng tất cả đơn hàng
CREATE FUNCTION TongDonHang()
RETURNS INT
AS
	BEGIN
		DECLARE @count INT
		Select @count = COUNT(*) FROM HOADON
		RETURN @count
	END
GO


--2.Tính tổng đơn hàng ngày hôm nay
create function TongDonHangHomNay()
returns int
as
	begin
		declare @count int
		declare @dayNow date
		set @dayNow = getdate()
		select @count = Count(*) from HOADON where NgayXuatHD = @dayNow
		return @count
	end
GO


--3. Tính tổng doanh thu
create function TongDoanhThu()
returns float
as
	begin 
		declare @sumMoney float
		select @sumMoney = sum(TongTien) from HOADON
		return @sumMoney
	end
GO

--4. Đếm số lượng  nhân viên
create function DemSoNhanVien()
returns int
as
	begin 
		declare @count int
		select @count = COUNT(*) from NHANVIEN where CHUCVU =N'Nhân Viên'
		return @count
	end
GO

--5 Đếm số lượng khách hàng
create function DemSoKhachHang()
returns int
as
	begin 
		declare @count int
		select @count = COUNT(*) from KHACHHANG 
		return @count
	end
GO
--6 Đếm số lượng sản phẩm
create function DemSoLuongSP()
returns int
as
	begin 
		declare @count int
		select @count = COUNT(*) from SANPHAM 
		return @count
	end
GO
--8 Đếm số lượng sản phẩm sắp hết hàng
create function DemSoLuongSPSapHetHang()
returns int
as
	begin
		declare @count int
		select @count = COUNT(*) from SANPHAM where TrangThai =N'Sắp hết hàng'
		return @count
	end
GO
---------------------------------TRẦN NGỌC THANH--------------------------------------
----***//--1.<Đọc dữ liệu loại sản phẩm>
create Proc Data_LoaiSanPham
 AS
	SELECT *
	FROM LOAISP 
GO
----***//--2.<Cập nhật loại sản phẩm>
CREATE PROCEDURE updateLoaiSanPham
@MaLoai INT,
@TenLoai NVARCHAR(100)
AS
BEGIN

	    UPDATE LOAISP
    SET TenLoai = @TenLoai     
   WHERE MaLoai = @MaLoai
END
GO
----***//--3.<Xóa một loại sản phẩm>
CREATE PROCEDURE DeleteLoaiSanPham
@MaLoai INT
AS    
    IF EXISTS (SELECT 1 FROM SANPHAM WHERE MaLoai = @MaLoai)        
			Return -1
	Else
    DELETE FROM LOAISP WHERE MaLoai = @MaLoai;
GO
----***//--4.<Thêm một loại sản phẩm>
CREATE PROC insertLoaiSanPham
  @TenLoai NVARCHAR(50)
AS
BEGIN
  INSERT INTO LOAISP(TenLoai)
  VALUES (@TenLoai)  
  PRINT N'SẢN PHẨM ĐÃ ĐƯỢC THÊM'
  return 1;
END
GO
----***//--5.<Đọc dữ liệu nhà cung cấp>
  CREATE PROC Data_NhaCungCap
 AS
	SELECT *
	FROM NHACUNGCAP
GO
----***//--6.<Update nhà cung cấp>
CREATE PROCEDURE updateNhaCungCap
@MaNCC INT,
@TenNCC NVARCHAR(100),
@SDT char(12),
@Email char(50),
@DiaChi Nvarchar(100)
AS
BEGIN
	    UPDATE NHACUNGCAP
    SET TenNCC = @TenNCC,
		SDT=@SDT,
		Email=@Email,
		DiaChi=@DiaChi    
   WHERE MaNCC = @MaNCC
END
GO
----***//--7.<Xóa nhà cung cấp>
CREATE PROCEDURE DeleteNhaCungCap
@MaNCC INT
AS    
    IF EXISTS (SELECT 1 FROM PHIEUNHAPHANG WHERE MaNCC = @MaNCC)        
			Return -1
	Else
    DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC;
GO
----***//--8.<Thêm dữ liệu  nhà cung cấp>
CREATE PROC insertNhaCungCap
 @TenNCC NVARCHAR(100),
@SDT char(12),
@Email char(50),
@DiaChi Nvarchar(100)
AS
BEGIN
  INSERT INTO NHACUNGCAP(TenNCC,SDT,Email,DiaChi)
  VALUES (@TenNCC,@SDT,@Email,@DiaChi)  
  PRINT N'NHÀ CUNG CẤP ĐÃ ĐƯỢC THÊM'
  return 1;
END
GO
----***//--9.<Tìm kiếm theo tên nhà cung cấp>
create proc TimKiemTheoTenNCC
@TenNCC nvarchar(50)
as
	Select * from NHACUNGCAP where TenNCC Like '%' + @TenNCC + '%'
GO
----***//--10.<Đọc dữ liệu sản phẩm>
CREATE PROC Data_SanPham
 AS
	SELECT *
	FROM SANPHAM
GO
----***//--11<Sửa dữ liệu sản phẩm>
CREATE PROCEDURE updateSanPhams
@MaSP INT,
@TenSP NVARCHAR(100),
@SoLuongSP INT,
@NgaySX DATE,
@GiaNhap FLOAT,
@GiaBan FLOAT,
@ImageSP varbinary(max)=null,
@MoTa NVARCHAR(500),
@MaLoai INT
AS
BEGIN
	    UPDATE SANPHAM
    SET TenSP = @TenSP, 
        SoLuongSP = @SoLuongSP,
        NgaySX = @NgaySX,
        GiaNhap = @GiaNhap, 
        GiaBan = @GiaBan,
		ImageSP=@ImageSP,
        MoTa = @MoTa,     
        MaLoai = @MaLoai
  WHERE MaSP = @MaSP
END
GO
----***//--12<Xóa dữ liệu sản phẩm>
CREATE PROC DeleteSanPham
@MaSP INT
AS    
    IF EXISTS (SELECT 1 FROM CHITIETHD WHERE MaSP = @MaSP)
        OR EXISTS (SELECT 1 FROM CHITIETPN WHERE MaSP = @MaSP)       
			Return -1
	Else
    DELETE FROM SANPHAM WHERE MaSP = @MaSP;
GO
----***//--13<Update dữ liệu sản phẩm> 
create proc UpdateSanPham
@MaSP int ,@SoLuongSP int
as
update SANPHAM set SoLuongSP = @SoLuongSP where MaSP = @MaSP
GO
----***//--14<Lấy dữ liệu hóa đơn>
 CREATE PROC Data_HoaDon
 AS
	SELECT *
	FROM HOADON
GO

----***//--15<Tìm kiếm hóa đơn theo ngày mua>
create proc TimKiemTheoNgayMua
@ngaymua nvarchar(50)
as
	SELECT HOADON.* ,TENKH FROM HoaDon,KHACHHANG WHERE HoaDon.MaKH=KHACHHANG.MaKH  AND CONVERT(DATE, NgayXuatHD) = @ngaymua;
GO
----***//--16<Tìm kiếm hóa đơn và tính tổng số lượng>
CREATE PROCEDURE TimKiemHoaDon
@MaHD nvarchar(50)
AS
BEGIN
    SELECT  h.MaHD,ct.MaSP,ct.SoLuongBan,ct.ThanhTien,k.TenKH,s.TenSP,s.GiaBan
   FROM HoaDon h INNER JOIN KhachHang k ON h.MaKH = k.MaKH  INNER JOIN ChiTietHD ct ON h.MaHD = ct.MaHD INNER JOIN SanPham s ON ct.MaSP = s.MaSP
    WHERE h.MaHD = @MaHD
END
GO
----***//--17<Tìm kiếm phiếu nhập>
create proc TimKiemTheoMAPN
@MaPhieu int
as
	Select * from CHITIETPN where MaPhieu= @MaPhieu
GO
----***//--18<Tìm khách hàng theo tên> 
create proc TimKiemTheoTenKH
@TenKH nvarchar(50)
as
	SELECT HOADON.*,TENKH FROM HoaDon,KHACHHANG WHERE HoaDon.MaKH=KHACHHANG.MaKH and TenKh LIKE '%' + @tenkh + '%'
GO
----***//--19<Lấy dữ liệu chi tiết hóa đơn>
  CREATE PROC Data_CTHoaDon
 AS
	SELECT *
	FROM CHITIETHD 
GO
----***//--20<Lấy dữ liệu chi tiết phiếu nhập>
  CREATE PROC Data_CTPhieuNhap
 AS
	SELECT *
	FROM CHITIETPN 
GO
----***//--21<Lấy dữ liệu phiếu nhập>
  CREATE PROC Data_PhieuNhap
 AS
	SELECT *
	FROM PHIEUNHAPHANG 
GO

----***//--22<Tìm kiếm hóa đơn theo ngày nhập>
create proc TimKiemTheoNgayNhap
@ngaynhap nvarchar(50)
as
	select * from PHIEUNHAPHANG where CONVERT(DATE, NgayNhap) = @ngaynhap;
GO
------------------------FUNCTION----------------------------------
--1 Tìm kiếm giá sản phẩm
CREATE FUNCTION SearchGiaSP
(
    @GiaBan NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM SANPHAM
    WHERE
    (
        (@GiaBan = '0-100.000' AND GiaBan BETWEEN 10000 AND 100000) OR
        (@GiaBan = '100.000-500.000' AND GiaBan BETWEEN 100000 AND 500000) OR
        (@GiaBan = '500.000-1.000.000' AND GiaBan BETWEEN 500000 AND 1000000) OR
        (@GiaBan = 'Trên 1.000.000' AND GiaBan > 1000000)
    )
)
GO

---------------------------------- NGUYỄN PHƯƠNG ĐIỀN ------------------------------------
----***//--1.<Thêm dữ liệu sản phẩm>
CREATE PROC Insert_SanPham
  @TenSP NVARCHAR(50),
  @SoLuongSP INT,
  @NgaySX DATE,
  @GiaBan FLOAT,
  @GiaNhap FLOAT,
  @ImageSP varbinary(max), 
  @MoTa NVARCHAR(200),
  @MaLoai INT
AS
BEGIN
  INSERT INTO SANPHAM (TenSP,SoLuongSP,NgaySX,GiaBan,GiaNhap,ImageSP,MoTa,MaLoai)
  VALUES (@TenSP, @SoLuongSP, @NgaySX,@GiaBan,@GiaNhap, @ImageSP,@MoTa,@MaLoai)
END
GO

----***//--2<Lấy dữ liệu mã sản phẩm max> 
CREATE PROC MAX_MASP
AS
 BEGIN
	SELECT MAX(MaSP) AS MaxMaSP FROM SANPHAM
END
GO
----***//--3<Lấy dữ liệu sản phẩm trong phiếu nhập> 
CREATE PROC Data_SanPham_PhieuNhap
 AS
	SELECT DISTINCT NHACUNGCAP.MaNCC,LOAISP.MaLoai,SANPHAM.MaSP,SANPHAM.TenSP,SANPHAM.SoLuongSP,SANPHAM.ImageSP,SANPHAM.GiaNhap,NHACUNGCAP.TenNCC,TenLoai
	FROM NHACUNGCAP,LOAISP,PHIEUNHAPHANG,SANPHAM,CHITIETPN
	where NHACUNGCAP.MaNCC = PHIEUNHAPHANG.MaNCC and LOAISP.MaLoai = SANPHAM.MaLoai and SANPHAM.MaSP = CHITIETPN.MaSP and PHIEUNHAPHANG.MaPhieu = CHITIETPN.MaPhieu
GO


----***//--4<Lấy dữ liệu tài khoản>
CREATE PROC GET_TK
AS
	BEGIN
		SELECT TAIKHOAN.MaNV,NHANVIEN.TenNV,TAIKHOAN.Username,TAIKHOAN.Password,NHANVIEN.Anh,NHANVIEN.ChucVu FROM TAIKHOAN,NHANVIEN	WHERE NHANVIEN.MaNV=TAIKHOAN.MaNV
	END
GO
----***//--5<Thêm dữ liệu tài khoản>
CREATE PROCEDURE ThemTaiKhoan
  @MaNV INT,
  @UserName NVARCHAR(50),
  @PassWord NVARCHAR(50)
 AS
	BEGIN 
		INSERT INTO TAIKHOAN(MaNV,Username,Password)
		VALUES(@MaNV,@UserName,@PassWord)
	END
GO
----***//--6<Kiểm tra user>
CREATE PROC CHECK_USERNAME
 @UserName	NVARCHAR(50)
 AS
	BEGIN
		SELECT COUNT(*) FROM TAIKHOAN WHERE Username=@UserName
	END
GO
----***//--7<Xóa dữ liệu tài khoản>
CREATE PROC DELETE_TK
@UserName NVARCHAR(50)
AS
	BEGIN
		DELETE FROM TAIKHOAN WHERE Username=@UserName 
	END
GO
----***//--8<Update dữ liệu tài khoản đổi mật khẩu>
CREATE PROCEDURE UpdatePassword
    @Username NVARCHAR(50),
    @NewPassword NVARCHAR(50)
AS
	BEGIN
		UPDATE TAIKHOAN
		SET Password = @NewPassword
		WHERE Username = @Username;
	END;
GO
----***//--9<Lấy max mã phiếu nhập>
CREATE PROC MAX_MAPN
AS
	 BEGIN
		SELECT MAX(MaPhieu) AS MaxMaPN FROM PHIEUNHAPHANG
	END
GO
----***//--10<Thêm dữ liệu phiếu nhập>
create proc insertPhieuNhap
@MaNV int,@MaNCC int,@NgayNhap Datetime,@GhiChu nvarchar(100),@TongTienNhap float
as
begin
	insert into PHIEUNHAPHANG(MaNV,MaNCC,NgayNhap,GhiChu,TongTienNhap)
	values (@MaNV,@MaNCC,@NgayNhap,@GhiChu,@TongTienNhap)
end
GO
----***//--11<In dữ liệu phiếu nhập>
create proc InPhieuNhap
@MaPhieu int
as
select PHIEUNHAPHANG.MaPhieu,PHIEUNHAPHANG.NgayNhap,PHIEUNHAPHANG.GhiChu,PHIEUNHAPHANG.TongTienNhap,CHITIETPN.SoLuongNhap,CHITIETPN.DonGiaNhap,CHITIETPN.ThanhTien,
SANPHAM.TenSP,NHACUNGCAP.TenNCC,LOAISP.TenLoai,NHANVIEN.TenNV
from PHIEUNHAPHANG,NHANVIEN,SANPHAM,CHITIETPN,NHACUNGCAP,LOAISP
where PHIEUNHAPHANG.MaPhieu = CHITIETPN.MaPhieu and PHIEUNHAPHANG.MaNV = NHANVIEN.MaNV and CHITIETPN.MaSP = SANPHAM.MaSP and PHIEUNHAPHANG.MaNCC = NHACUNGCAP.MaNCC and SANPHAM.MaLoai = LOAISP.MaLoai
and PHIEUNHAPHANG.MaPhieu =@MaPhieu
GO
----***//--12<Thêm dữ liệu chi tiết phiếu nhập>
create proc insertCTPhieuNhap
@MaPhieu int,@MaSP int,@SoLuong int,@DonGia float, @ThanhTien float
as
	begin
		insert into CHITIETPN(MaPhieu,MaSP,SoLuongNhap,DonGiaNhap,ThanhTien)
		values (@MaPhieu,@MaSP,@SoLuong,@DonGia, @ThanhTien)
	end
GO
----------------------FUNCTION-----------------
--12 Tìm kiếm tài khoản theo mã
CREATE FUNCTION Search_TaiKhoan(@MaNV int)
RETURNS TABLE
AS
RETURN (
					SELECT NHANVIEN.MaNV,Username,NHANVIEN.ChucVu FROM TAIKHOAN,NHANVIEN 
					WHERE NHANVIEN.MaNV=TAIKHOAN.MaNV and NHANVIEN.MaNV=@MaNV
)
GO	

----------------------------NGUYỄN THỊ THU HÀ-------------------------
----***//--1<Lây dữ liệu nhân viên>
CREATE PROC GET_NV
AS
BEGIN
     SELECT *FROM NHANVIEN
END
GO
----***//--2<Thêm dữ liệu nhân viên>
CREATE PROCEDURE ThemNhanVien
  @TenNV NVARCHAR(50),
  @Anh Image,
  @SDT CHAR(12),
  @DiaChi NVARCHAR(100),
  @GioiTinh NCHAR(5),
  @NgaySinh DATE,
  @ChucVu NVARCHAR(20)
AS
BEGIN
  INSERT INTO NHANVIEN (TenNV,Anh,SDT, DiaChi, GioiTinh, NgaySinh, ChucVu)
  VALUES (@TenNV,@Anh, @SDT, @DiaChi, @GioiTinh, @NgaySinh, @ChucVu)
END
GO
----***//--3<Kiểm tra mã nhân viên có tồn tại>
CREATE PROC CHECK_MANV
 @MaNV int
 AS
	BEGIN
		SELECT COUNT(*) FROM NHANVIEN WHERE @MaNV=MaNV
	END
GO
----***//--4<Sữa dữ liệu nhân viên>
CREATE PROCEDURE UpdateNhanVien
    @MaNV INT,
    @TenNV NVARCHAR(50),
	@Anh image,
    @SDT CHAR(12),
    @GioiTinh NCHAR(5),
    @DiaChi NVARCHAR(100),
    @ChucVu NVARCHAR(20),
    @NgaySinh DATE
AS
BEGIN
    UPDATE NHANVIEN
    SET
        TenNV = @TenNV,
		Anh=@Anh,
        SDT = @SDT,
        GioiTinh = @GioiTinh,
        DiaChi = @DiaChi,
        ChucVu = @ChucVu,
        NgaySinh = @NgaySinh
    WHERE MaNV = @MaNV
END 
GO
----***//--5<Xóa dữ liệu nhân viên>
CREATE PROCEDURE DeleteNhanVien
    @MaNV INT
AS
    IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE MaNV = @MaNV)
        OR EXISTS (SELECT 1 FROM HOADON WHERE MaNV = @MaNV)
        OR EXISTS (SELECT 1 FROM PHIEUNHAPHANG WHERE MaNV = @MaNV)
		Return -1
	Else
	  DELETE FROM NHANVIEN WHERE MaNV = @MaNV
GO
----***//--6<Tìm nhân viên theo tên nhân viên>
CREATE PROCEDURE SearchTenNV
@TenNV nvarchar(50)
AS
	BEGIN
		Select * from NHANVIEN where TenNV Like '%' + @TenNV + '%'
	END
GO
----***//--7<Tìm nhân viên theo mã nhân viên>
CREATE PROCEDURE SearchMaNV
@MaNV int
AS
	BEGIN
		SELECT * FROM NHANVIEN WHERE MaNV = @MaNV
	END
GO
----***//--8<Xuất doanh thu>
CREATE PROC GET_DOANHTHU
AS
	BEGIN
		SELECT  NHANVIEN.TenNV as N' Tên NV',NHANVIEN.ChucVu as N'Chức Vụ',NgayXuatHD as N'Ngày Bán',TongTien N'Tổng Tiền' FROM HOADON,NHANVIEN WHERE NHANVIEN.MaNV=HOADON.MaNV
	END
GO
-----------------FUNCTION-----------------------
--1 Tính doanh thu theo tháng
 CREATE FUNCTION GET_DOANHTHUTHEOTHANG(@NAM INT)
 RETURNS TABLE
 AS
	RETURN select MONTH(HOADON.NgayXuatHD) as Thang, YEAR(HOADON.NgayXuatHD) as Nam, SUM(HOADON.TongTien) as DT from HOADON where  YEAR(NgayXuatHD)=@nam
	group by MONTH(HOADON.NgayXuatHD),YEAR(HOADON.NgayXuatHD)
GO

--2 Tính doanh thu theo ngày
CREATE FUNCTION GET_DOANHTHUTHEONGAY(@thang int,@nam int)
 RETURNS TABLE
 AS
	RETURN select  DAY(HOADON.NgayXuatHD) as Ngay, MONTH(HOADON.NgayXuatHD) as Thang, YEAR(HOADON.NgayXuatHD) as Nam, SUM(HOADON.TongTien) as DT from HOADON where  MONTH(NgayXuatHD)=@thang and YEAR(NgayXuatHD)=@nam
	group by DAY(HOADON.NgayXuatHD),MONTH(HOADON.NgayXuatHD),YEAR(HOADON.NgayXuatHD)
GO

	---------------------**************************************************************************************************---------------------
---------------------////////============ ************** PHÂN QUYỀN  =============**************/////////---------------------

--Viết hàm kiểm tra nhân viên đó có chức vụ là gì
CREATE FUNCTION Get_ChucVu_NhanVien (@MaNV INT)
RETURNS NVARCHAR(50)
AS
	BEGIN
	    DECLARE @ChucVu NVARCHAR(50)
		SELECT @ChucVu =ChucVu FROM dbo.NHANVIEN WHERE MaNV=@MaNV
		RETURN @ChucVu
	END
GO	

