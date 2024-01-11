create database QLLuong
use QlLuong

create table DonVi(
	madonvi int primary key,
	tendonvi nvarchar(30)
)

create table NhanVien(
	manv int primary key,
	hoten nvarchar(30),
	gioitinh nvarchar(10),
	hsluong int,
	madonvi int
)

-- Tạo bản ghi cho bảng Donvi
INSERT INTO DonVi (madonvi, tendonvi) VALUES
(1, N'Kinh doanh'),
(2, N'Marketing'),
(3, N'Lập trình');

-- Tạo bản ghi cho bảng NhanVien

INSERT INTO NhanVien (manv, hoten, gioitinh, hsluong, madonvi) VALUES
(1, N'Trần Đình Tuấn', N'Nam', 1000000, 1),
(2, N'Trần Đình Huân', N'Nam', 2000000, 1),
(3, N'Phùng Hải', N'Nữ', 3000000, 2),
(4, N'Adeline Kuti', N'Nữ', 4000000, 2),
(5, N'Mỹ Anh', N'Nữ', 5000000, 3);

select*from DonVi
select*from NhanVien
