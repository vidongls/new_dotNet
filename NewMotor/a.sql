USE [ppMotor]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[macv] [int] IDENTITY(1,1) NOT NULL,
	[tencv] [nchar](10) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[macv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[LienHe] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_DoiTac] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Quyen] [int] NULL,
	[Email] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCC]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCC](
	[mancc] [int] IDENTITY(1,1) NOT NULL,
	[tenncc] [nvarchar](50) NULL,
	[diachi] [nvarchar](50) NULL,
	[lienhe] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaCC] PRIMARY KEY CLUSTERED 
(
	[mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Lienhe] [nvarchar](50) NULL,
	[MaCV] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanLoai]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanLoai](
	[maloai] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanLoai] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[idQuyen] [int] IDENTITY(1,1) NOT NULL,
	[tenQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[idQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[mapn] [int] IDENTITY(1,1) NOT NULL,
	[tenpn] [nvarchar](50) NULL,
	[sl] [decimal](18, 0) NULL,
	[dongia] [money] NULL,
	[manv] [int] NULL,
	[masp] [int] NULL,
	[tongtien] [money] NULL,
	[mancc] [int] NULL,
	[ngaylap] [datetime] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[mapn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuat](
	[mapx] [int] IDENTITY(1,1) NOT NULL,
	[tenpx] [nvarchar](50) NULL,
	[ngaylap] [datetime] NULL,
	[soluong] [decimal](18, 0) NULL,
	[dongia] [money] NULL,
	[manv] [int] NULL,
	[masp] [int] NULL,
	[tongtien] [money] NULL,
	[idKH] [int] NULL,
 CONSTRAINT [PK_PhieuXuat] PRIMARY KEY CLUSTERED 
(
	[mapx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 4/21/2021 9:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[Mau] [nvarchar](50) NULL,
	[Gia] [money] NULL,
	[maloai] [int] NULL,
	[mancc] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([macv], [tencv]) VALUES (1, N'Quản lý   ')
INSERT [dbo].[ChucVu] ([macv], [tencv]) VALUES (2, N'Nhân viên ')
INSERT [dbo].[ChucVu] ([macv], [tencv]) VALUES (3, N'Kế toán   ')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [LienHe], [DiaChi]) VALUES (1, N'Hoang Kien', N'0113215646', N'chua ha')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [LienHe], [DiaChi]) VALUES (5, N'Tuyến Nguyễn', N'0369716133', N'Hải Dương')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [LienHe], [DiaChi]) VALUES (6, N'Lã Quốc Nghị', N'01348444646', N'Ba Vì')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [LienHe], [DiaChi]) VALUES (12, N'Đông Vi', N'0399999362', N'Lạng Sơn')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [LienHe], [DiaChi]) VALUES (14, N'Hoang Kien', N'0113215646', N'chua ha')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [LienHe], [DiaChi]) VALUES (15, N'Lã Quốc Nghị', N'01348444646', N'Ba Vì')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [LienHe], [DiaChi]) VALUES (17, N'Quan Beo', N'0113215646', N'chua ha')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
INSERT [dbo].[NguoiDung] ([TaiKhoan], [MatKhau], [Quyen], [Email]) VALUES (N'admin', N'admin', 1, NULL)
INSERT [dbo].[NguoiDung] ([TaiKhoan], [MatKhau], [Quyen], [Email]) VALUES (N'nhanvien', N'a', 2, NULL)
INSERT [dbo].[NguoiDung] ([TaiKhoan], [MatKhau], [Quyen], [Email]) VALUES (N'ketoan', N'a', 3, NULL)
INSERT [dbo].[NguoiDung] ([TaiKhoan], [MatKhau], [Quyen], [Email]) VALUES (N'Dongvi', N'123456aA', NULL, N'a@email.com')
INSERT [dbo].[NguoiDung] ([TaiKhoan], [MatKhau], [Quyen], [Email]) VALUES (N'Helloworld', N'123456', 2, N'dongvi@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[NhaCC] ON 

INSERT [dbo].[NhaCC] ([mancc], [tenncc], [diachi], [lienhe]) VALUES (1, N'HonDa', N'SaiGon', N'0131568477')
INSERT [dbo].[NhaCC] ([mancc], [tenncc], [diachi], [lienhe]) VALUES (2, N'Yamaha', N'HaNoi', N'468979879')
INSERT [dbo].[NhaCC] ([mancc], [tenncc], [diachi], [lienhe]) VALUES (3, N'Kawasaki', N'Hanoi', N'1354684')
INSERT [dbo].[NhaCC] ([mancc], [tenncc], [diachi], [lienhe]) VALUES (4, N'Suzuki', N'HaNoi', N'54878')
INSERT [dbo].[NhaCC] ([mancc], [tenncc], [diachi], [lienhe]) VALUES (5, N'SYM', N'HaNoi', N'8487')
SET IDENTITY_INSERT [dbo].[NhaCC] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Lienhe], [MaCV]) VALUES (22, N'Long', N'Nam', CAST(N'1983-02-08T00:00:00.000' AS DateTime), N'Bắc Ninh', N'0984891561', 3)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Lienhe], [MaCV]) VALUES (23, N'Quan Beo', N'Nam', CAST(N'1983-02-08T00:00:00.000' AS DateTime), N'Bắc Ninh', N'0984891561', 3)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Lienhe], [MaCV]) VALUES (24, N'Hưng hà', N'Nam', CAST(N'1983-02-08T00:00:00.000' AS DateTime), N'Từ Sơn', N'0984891561', 2)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Lienhe], [MaCV]) VALUES (25, N'Vi Đông', N'Nam', CAST(N'2000-10-04T00:00:00.000' AS DateTime), N'Lạng Sơn', N'0399999362', 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Lienhe], [MaCV]) VALUES (27, N'Minh Tiến', N'Nam', CAST(N'1983-02-08T00:00:00.000' AS DateTime), N'Bắc Ninh', N'0984891561', 3)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Lienhe], [MaCV]) VALUES (31, N'Tuyến Nguyễn', N'Nam', CAST(N'2000-01-04T00:00:00.000' AS DateTime), N'Hải Dương', N'0984891561', 3)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Lienhe], [MaCV]) VALUES (32, N'Văn Hào', N'Nam', CAST(N'2000-07-11T00:00:00.000' AS DateTime), N'Vĩnh Phúc', N'32432432', 3)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanLoai] ON 

INSERT [dbo].[PhanLoai] ([maloai], [tenloai]) VALUES (1, N'Xe côn tay')
INSERT [dbo].[PhanLoai] ([maloai], [tenloai]) VALUES (2, N'Xe số')
INSERT [dbo].[PhanLoai] ([maloai], [tenloai]) VALUES (3, N'Xe tay ga')
SET IDENTITY_INSERT [dbo].[PhanLoai] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([idQuyen], [tenQuyen]) VALUES (1, N'Admin')
INSERT [dbo].[PhanQuyen] ([idQuyen], [tenQuyen]) VALUES (2, N'Nhân viên')
INSERT [dbo].[PhanQuyen] ([idQuyen], [tenQuyen]) VALUES (3, N'Kế toán')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 

INSERT [dbo].[PhieuNhap] ([mapn], [tenpn], [sl], [dongia], [manv], [masp], [tongtien], [mancc], [ngaylap]) VALUES (63, N'Mua tiếp xe', CAST(1 AS Decimal(18, 0)), 31000000.0000, 22, 34, 31000000.0000, 1, CAST(N'2021-01-05T22:01:31.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([mapn], [tenpn], [sl], [dongia], [manv], [masp], [tongtien], [mancc], [ngaylap]) VALUES (66, N'Nhập SH', CAST(10 AS Decimal(18, 0)), 279000000.0000, NULL, 36, 2790000000.0000, 1, CAST(N'2021-01-02T20:30:32.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([mapn], [tenpn], [sl], [dongia], [manv], [masp], [tongtien], [mancc], [ngaylap]) VALUES (68, N'Mua Janus', CAST(200 AS Decimal(18, 0)), 42000000.0000, 23, 19, 8400000000.0000, 1, CAST(N'2021-01-05T22:50:18.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([mapn], [tenpn], [sl], [dongia], [manv], [masp], [tongtien], [mancc], [ngaylap]) VALUES (69, N'Mua tiếp xe', CAST(1 AS Decimal(18, 0)), 31000000.0000, 22, 34, 31000000.0000, 1, CAST(N'2021-01-05T22:50:29.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuXuat] ON 

INSERT [dbo].[PhieuXuat] ([mapx], [tenpx], [ngaylap], [soluong], [dongia], [manv], [masp], [tongtien], [idKH]) VALUES (13, N'Bán Janus', CAST(N'2021-01-05T22:50:59.000' AS DateTime), CAST(23 AS Decimal(18, 0)), 2.0000, 25, 19, 80.0000, 6)
INSERT [dbo].[PhieuXuat] ([mapx], [tenpx], [ngaylap], [soluong], [dongia], [manv], [masp], [tongtien], [idKH]) VALUES (15, N'Bán Winner X', CAST(N'2021-01-05T22:01:37.000' AS DateTime), CAST(1 AS Decimal(18, 0)), 48000000.0000, 22, 37, 48000000.0000, 1)
SET IDENTITY_INSERT [dbo].[PhieuXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (19, N'Wave chiến', N'Đỏ', 100000000.0000, 2, 1, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (31, N'YZF-R3', N'Đỏ', 129200000.0000, 1, 1, 56)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (32, N'MT-15', N'Xanh', 69000000.0000, 1, 2, 50)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (33, N'Vision', N'Xanh Nâu Đen', 31790000.0000, 3, 1, 60)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (34, N'Air Blade 125/150', N'Trắng Đen', 42390000.0000, 3, 1, 81)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (35, N'Wave RSX FI 110', N'Đỏ đen', 21690000.0000, 3, 1, 30)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (36, N'SH300i ABS', N'Xám Đen', 276000000.0000, 3, 1, 19)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (37, N'WINNER X', N'Xanh - Đen - Bạc', 48990000.0000, 1, 1, -226)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (38, N'Wave Alpha 110cc', N'Xanh Đen Bạc', 17790000.0000, 2, 1, 57)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (40, N'NINJA ZX-25R SE', N'Đỏ-Xám', 189000000.0000, 1, 3, 999)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (41, N'NINJA ZX-10R ABS KRT', N'Xanh Đen', 571000000.0000, 1, 3, 78)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (42, N'GSX-S150', N'Xanh', 70000000.0000, 1, 4, 40)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (47, N'SIRIUS ', N'Đỏ Đen', 18800000.0000, 2, 2, 104)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (52, N'Exciter 150', N'Đỏ-Xám', 50000000.0000, 1, 2, 10)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Mau], [Gia], [maloai], [mancc], [SoLuong]) VALUES (53, N'Dream', N'Xanh', 20000000.0000, 2, 2, 10)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_ChucVu] FOREIGN KEY([Quyen])
REFERENCES [dbo].[ChucVu] ([macv])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_ChucVu]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_PhanQuyen] FOREIGN KEY([Quyen])
REFERENCES [dbo].[PhanQuyen] ([idQuyen])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_PhanQuyen]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([macv])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCC] FOREIGN KEY([mancc])
REFERENCES [dbo].[NhaCC] ([mancc])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCC]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([manv])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_SanPham1] FOREIGN KEY([masp])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_SanPham1]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_KhachHang] FOREIGN KEY([idKH])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_KhachHang]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_NhanVien] FOREIGN KEY([manv])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_NhanVien]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_SanPham] FOREIGN KEY([masp])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_SanPham]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [manv] FOREIGN KEY([manv])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [manv]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaCC] FOREIGN KEY([mancc])
REFERENCES [dbo].[NhaCC] ([mancc])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaCC]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_PhanLoai] FOREIGN KEY([maloai])
REFERENCES [dbo].[PhanLoai] ([maloai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_PhanLoai]
GO
