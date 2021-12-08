create database PTTKHDT

use PTTKHDT

create table PhanQuyen
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	TenPhanQuyen nvarchar(50),
)

create table TaiKhoan
(
	IDTaiKhoan int IDENTITY(1,1) PRIMARY KEY,
	TenTaiKhoan nvarchar(50) NOT NULL,
	MatKhau nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,
	SDT int,
	NgaySinh date,
	GioiTinh bit,

	ID int, 
	FOREIGN KEY (ID) REFERENCES PhanQuyen(ID), 
)


create table KhachHang
(
	IDKhachHang int IDENTITY(1,1) PRIMARY KEY,
	TenKhachHang nvarchar(50),
	SDT int,
	Email nvarchar(50),
	NgaySinh date,
	SoTienDaMua money,
	CapBac int,
	GioiTinh bit,
)


create table HoaDon
(
	IDHoaDon int IDENTITY(1,1) PRIMARY KEY,
	NgayInHoaDon date,
	GioInHoaDon time,
	IDTaiKhoan int,
	FOREIGN KEY (IDTaiKhoan) REFERENCES TaiKhoan(IDTaiKhoan),
)

create table Sach
(
	IDSach int IDENTITY(1,1) PRIMARY KEY,
	TenSach nvarchar(50) NOT NULL,
	NXB nvarchar(50) NOT NULL,
	TenTacGia nvarchar(50) NOT NULL,
	Gia float(2),
	SoLuong int NOT NULL,
)

create table ChiTietHoaDon
(
	IDChiTietHoaDon int IDENTITY(1,1) PRIMARY KEY,
	SoLuong int,
	IDHoaDon int,
	IDSach int,
	FOREIGN KEY (IDHoaDon) REFERENCES HoaDon(IDHoaDon),
	FOREIGN KEY (IDSach) REFERENCES Sach(IDSach),
)
insert into Sach values(N'123ã123456','cx@com',N'lakjnv',12000,15)
--Dữ liệu bảng Phân Quyền
insert into PhanQuyen values(N'Quản Lý')
insert into PhanQuyen values(N'Nhân Viên')

--Dữ liệu bảng Tài Khoản
insert into TaiKhoan(TenTaiKhoan,MatKhau,Email,ID) values(N'TuanUra','123456','nat@gmail.com',1)
insert into TaiKhoan(TenTaiKhoan,MatKhau,Email,ID) values(N'Ivantim','123456','ivamtim@gmail.com',2)
insert into TaiKhoan(TenTaiKhoan,MatKhau,Email,ID) values(N'TuBeo','123456','tubeo@gmail.com',2)

--Dữ liệu bảng Khách Hàng
insert into KhachHang(TenKhachHang,SDT,Email,SoTienDaMua) values(N'Phi Quân','0123456789','phiquan@gmail.com',150000)
insert into KhachHang(TenKhachHang,SDT,Email) values(N'Sỹ Khá','0123456987','sykha@gmail.com')

 delete from TaiKhoan where IDTaiKhoan=2