create database DatPhongKhachSan
go
use DatPhongKhachSan
go

create table Quyen(
	Maquyen int primary key identity(1,1),
	Tenquyen varchar(50), 
)
create table TaiKhoan(
	MaTK int primary key identity(1,1),
	TaiKhoan varchar(50),
	MatKhau varchar(50),
	MaQuyen int foreign key references Quyen(Maquyen),
	HoTen nvarchar(max),
	NgaySinh date,
	GioiTinh nvarchar(50),
	TrangThai bit,	
)
create table Khachhang(
	MaKH int primary key identity(1,1),
	TaiKhoan varchar(50),
	MatKhau varchar(50),
	MaQuyen int foreign key references Quyen(MaQuyen),
	TenKh nvarchar(max),
	DiaChi nvarchar(max),
	SDT int,
	GioiTinh nvarchar(50),
	TrangThai bit,
)
create table KhachSan(
	MaKS int primary key identity(1,1),
	TenKS nvarchar(50),
	DiaChi nvarchar(50),
)
create table DichVu(
	MaDV int primary key identity(1,1),
	TenDV nvarchar(max),
	MaKS int foreign key references KhachSan(MaKS),
	GiaDV int,
)
create table Phong(
	MaPhong int primary key identity(1,1),
	TenPhong nvarchar(max),
	HinhAnh varchar(max),
	Gia int,
	MoTa nvarchar(max),
	TrangThai nvarchar(max),
	MaKS int foreign key references KhachSan(MaKS),
)
create table DatPhong(
	MaDP int primary key identity(1,1),
	MaPhong int foreign key references Phong(MaPhong),
	NgayDat date,
	NgayDen date,
	NgayDi date,
	MaKH int foreign key references KhachHang(MaKH),
	MaDV int foreign key references DichVu(MaDV),
)
create table DanhGia(
	MaDG int primary key identity(1 , 1),
	MaKH int foreign key references KhachHang(MaKH),
	MaPhong int foreign key references Phong(MaPhong),
	NoiDung nvarchar(max),
	NgayDG	date,
)