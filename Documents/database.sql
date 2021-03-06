USE [QuanLyCTDT]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[maMH] [varchar](10) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[sotinchi] [int] NULL,
	[mota] [nvarchar](1000) NULL,
	[id_chuyennganh] [int] NULL,
 CONSTRAINT [PK__MonHoc__7A3EDFA6145A7DF8] PRIMARY KEY CLUSTERED 
(
	[maMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuyenNganh]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenNganh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenCN] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonKhoa]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonKhoa](
	[maMH] [varchar](10) NOT NULL,
	[id_khoahoc] [int] NOT NULL,
	[manganh] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maMH] ASC,
	[id_khoahoc] ASC,
	[manganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[getMHByKhoa]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[getMHByKhoa](@id int,@nganh varchar(10) )
returns table
as
return select maMH,ten,sotinchi,mota,id_chuyennganh,tenCN from( select Monhoc.maMH,ten,sotinchi,mota,id_chuyennganh from Monhoc,(select maMH from MonKhoa where id_khoahoc=@id and manganh=@nganh ) as K where Monhoc.maMH=K.maMH) as Q LEFT OUTER JOIN ChuyenNganh
  ON id_chuyennganh=id
GO
/****** Object:  Table [dbo].[ChuanDauRa]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuanDauRa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mota] [nvarchar](500) NULL,
	[id_muctieu] [int] NULL,
	[maMH] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chuong]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chuong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[id_tuan] [int] NULL,
	[maMH] [varchar](10) NULL,
 CONSTRAINT [PK__Chuong__3213E83F4821CADA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[id] [int] NOT NULL,
	[tenKH] [nvarchar](20) NULL,
 CONSTRAINT [PK__KhoaHoc__3213E83FCA6A40D5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MHTienQuyet]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MHTienQuyet](
	[maMH] [varchar](10) NOT NULL,
	[maMHTQ] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maMH] ASC,
	[maMHTQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MucTieu]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MucTieu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mota] [nvarchar](500) NULL,
	[maMH] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[manganh] [varchar](10) NOT NULL,
	[tennganh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[manganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCongLop]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCongLop](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mota] [nvarchar](100) NULL,
	[id_chuong] [int] NULL,
 CONSTRAINT [PK__PhanCong__3213E83FF984B921] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCongNha]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCongNha](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mota] [nvarchar](100) NULL,
	[id_chuong] [int] NULL,
 CONSTRAINT [PK__PhanCong__3213E83FE25B2102] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NULL,
	[matkhau] [varchar](20) NULL,
	[ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tuan]    Script Date: 1/16/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tuan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [int] NULL,
 CONSTRAINT [PK__Tuan__3213E83F40CF8D1D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChuanDauRa] ON 

INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (13, N'Có kiến thức về cơ sở hạ tầng thương mại điện tử, nắm vững các phương thức bán hàng, maketing trên web;đấu giá, cộng đồng ảo và web portal', 15, N'ECOM430984')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (14, N'Có kiến thức về môi trường của thương mại điện tử, các vấn đề liên quan đến pháp luật, đạo đức và thuế', 15, N'ECOM430984')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (15, N'Phân tích, nhìn nhận vấn đề một cách khoa học, tư duy sáng tạo, không phiến diện hay tư duy theo lối mòn', 16, N'ECOM430984')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (16, N'Có kiến thức về các thư viện python', 17, N'lttt123')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (17, N'Thể hiện sự cẩn thận, tỉ mỉ khi l àm việc, có tinh thần, trách nhiệm, luôn cập nhật thông tin mới.', 18, N'lttt123')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (42, N'Vận dụng cơ bản', 1, N'ai12345')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (43, N'Có kiến thức cơ bản về trí tuệ nhân tạo', 1, N'ai12345')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (44, N'Biết cách phân chia công việc trong nhóm', 2, N'ai12345')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (46, N'Biết cách phòng tránh các mối nguy hại', 36, N'attt123')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (47, N'Vận dụng vào thực tế', 36, N'attt123')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (49, N'Có kiến thức cơ bản về thương mại điện tử,  hiểu, vận dụng và ứng dụng được trong thực  tế', 38, N'mobi123')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (50, N'Thể hiện sự cẩn thận, tỉ mỉ khi làm việc, có tinh  thần, trách nhiệm, luôn cập nhật thông tin mới.', 38, N'mobi123')
INSERT [dbo].[ChuanDauRa] ([id], [mota], [id_muctieu], [maMH]) VALUES (51, N'Phân tích, nhìn nhận vấn đề một cách khoa  học,tư duy sáng tạo, không phiến diện hay tư  duy theo lối mòn', 39, N'mobi123')
SET IDENTITY_INSERT [dbo].[ChuanDauRa] OFF
SET IDENTITY_INSERT [dbo].[Chuong] ON 

INSERT [dbo].[Chuong] ([id], [ten], [id_tuan], [maMH]) VALUES (4, N'Chương 1: Tổng quan thương mại điện tử', 1, N'ECOM430984')
INSERT [dbo].[Chuong] ([id], [ten], [id_tuan], [maMH]) VALUES (5, N'Chương 3: Bán hàng qua web', 2, N'ECOM430984')
INSERT [dbo].[Chuong] ([id], [ten], [id_tuan], [maMH]) VALUES (6, N'Chương 1: Tổng quan môn học', 1, N'lttt123')
INSERT [dbo].[Chuong] ([id], [ten], [id_tuan], [maMH]) VALUES (7, N'Chương 1: Thư viện numpy', 2, N'lttt123')
INSERT [dbo].[Chuong] ([id], [ten], [id_tuan], [maMH]) VALUES (15, N'Chương 1: Tổng quan về AI', 1, N'ai12345')
INSERT [dbo].[Chuong] ([id], [ten], [id_tuan], [maMH]) VALUES (16, N'Chương 2: Các bài toán cơ bản', 2, N'ai12345')
INSERT [dbo].[Chuong] ([id], [ten], [id_tuan], [maMH]) VALUES (18, N'Chương 1: Tổng quan  thương mại điện tử', 1, N'mobi123')
SET IDENTITY_INSERT [dbo].[Chuong] OFF
SET IDENTITY_INSERT [dbo].[ChuyenNganh] ON 

INSERT [dbo].[ChuyenNganh] ([id], [tenCN]) VALUES (1, N'Công nghệ phần mềm')
INSERT [dbo].[ChuyenNganh] ([id], [tenCN]) VALUES (2, N'Hệ thống thông tin')
INSERT [dbo].[ChuyenNganh] ([id], [tenCN]) VALUES (3, N'Mạng máy tính')
SET IDENTITY_INSERT [dbo].[ChuyenNganh] OFF
INSERT [dbo].[KhoaHoc] ([id], [tenKH]) VALUES (2018, N'Khóa 2018')
INSERT [dbo].[KhoaHoc] ([id], [tenKH]) VALUES (2019, N'Khóa 2019')
INSERT [dbo].[KhoaHoc] ([id], [tenKH]) VALUES (2020, N'Khóa 2020')
INSERT [dbo].[MHTienQuyet] ([maMH], [maMHTQ]) VALUES (N'deep123', N'ai12345')
INSERT [dbo].[MHTienQuyet] ([maMH], [maMHTQ]) VALUES (N'deep123', N'mach123')
INSERT [dbo].[MHTienQuyet] ([maMH], [maMHTQ]) VALUES (N'mach123', N'ai12345')
INSERT [dbo].[MHTienQuyet] ([maMH], [maMHTQ]) VALUES (N'mach123', N'math123')
INSERT [dbo].[MHTienQuyet] ([maMH], [maMHTQ]) VALUES (N'mobi123', N'lttt123')
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'ai12345', N'Trí tuệ nhân tạo', 3, N'Học phần cung cấp kiến thức về AI, bao gồm các giải thuật giải quyết vấn đề bằng tìm kiếm, các vấn đề quyết định', NULL)
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'attt123', N'An toàn thông tin', 4, N'Học phần cung cấp kiến thức về an toàn dữ liệu', NULL)
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'deep123', N'Học sâu', 3, N'Học phần cung cấp kiến thức về mạng nơron nhân tạo', NULL)
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'ECOM430984', N'Thương mại điện tử', 3, N'Cung cấp kiến thức cơ bản về thương mại điện tử, các mô hình kinh doanh, mô hình lợi nhuận, các quy trình kinh doanh; xác định các cơ hộithươngmạiđiện tử; bản chất quốctế của thương mại điện tử.', NULL)
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'lttt123', N'Ngôn ngữ lập trình tiên tiến', 3, N'Học phần cung cấp kiến thức về cách lập trình với Python', NULL)
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'mach123', N'Học máy', 3, N'Học phần cung cấp kiến thức về machine learning và các giải thuật', NULL)
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'math123', N'Toán 1', 3, N'Học phần cung cấp kiế thức về đạo hàm, tích phân', NULL)
INSERT [dbo].[MonHoc] ([maMH], [ten], [sotinchi], [mota], [id_chuyennganh]) VALUES (N'mobi123', N'Lập trình android', 3, N'Học phần cung cấp cách lập trình ứng dụng android', 1)
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'ai12345', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'ai12345', 2018, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'ai12345', 2019, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'ai12345', 2019, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'attt123', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'attt123', 2018, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'attt123', 2019, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'attt123', 2019, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'deep123', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'deep123', 2018, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'deep123', 2019, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'ECOM430984', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'ECOM430984', 2019, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'lttt123', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'lttt123', 2018, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'lttt123', 2019, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'lttt123', 2019, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'mach123', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'mach123', 2018, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'mach123', 2019, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'mach123', 2019, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'math123', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'math123', 2018, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'math123', 2019, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'math123', 2019, N'b123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'mobi123', 2018, N'a123')
INSERT [dbo].[MonKhoa] ([maMH], [id_khoahoc], [manganh]) VALUES (N'mobi123', 2019, N'a123')
SET IDENTITY_INSERT [dbo].[MucTieu] ON 

INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (1, N'Hiểu về trí tuệ nhân tạo', N'ai12345')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (2, N'Kỹ năng làm việc nhóm', N'ai12345')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (15, N'Kiến thức về thương mại điện tử', N'ECOM430984')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (16, N'Kỹ năng làm việc nhóm', N'ECOM430984')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (17, N'Năng lực tư duy hệ thống và hình thành phẩm chất cá nhân và nghề nghiệp', N'lttt123')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (18, N'Kỹ năng làm việc nhóm', N'lttt123')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (36, N'Hiểu được an toàn thông tin', N'attt123')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (38, N'Năng lực tư duy hệ thống và hình thành phẩm chất cá nhân  và nghề nghiệp', N'mobi123')
INSERT [dbo].[MucTieu] ([id], [mota], [maMH]) VALUES (39, N'Kỹ năng làm việc nhóm', N'mobi123')
SET IDENTITY_INSERT [dbo].[MucTieu] OFF
INSERT [dbo].[Nganh] ([manganh], [tennganh]) VALUES (N'a123', N'Công nghệ thông tin')
INSERT [dbo].[Nganh] ([manganh], [tennganh]) VALUES (N'b123', N'Kỹ thuật dữ liệu')
SET IDENTITY_INSERT [dbo].[PhanCongLop] ON 

INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (13, N'Giới thiệu về môn học, cách học, t ài liệu tham khảo,nguyên tắc làm việc', 6)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (14, N'Tổng kết, ôn tập;', 6)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (15, N'Tìm hiểu thư viện, cách ứng dụng', 7)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (16, N'Thực hành', 7)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (33, N'Giới thiệu về môn học, cách học, t ài liệu tham khảo, nguyên tắc làm việc', 4)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (34, N'Giới thiệu thương mại điện tử: làn sóng thứ 2', 4)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (35, N'Các mô hình lợi nhuận', 5)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (36, N'Các vấn đề trong chiến thuật lợi nhuận.', 5)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (39, N'Giới thiệu sơ lược về các ứng dụng AI', 15)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (40, N'Tổng quan về đề cương môn học', 15)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (41, N'Giới thiệu các thuật toán cơ bản', 16)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (43, N'Giới thiệu về môn học, cách học,  tài liệu tham khảo, nguyên tắc làm  việc', 18)
INSERT [dbo].[PhanCongLop] ([id], [mota], [id_chuong]) VALUES (44, N'Xác định cơ hội thương mại điện  tử', 18)
SET IDENTITY_INSERT [dbo].[PhanCongLop] OFF
SET IDENTITY_INSERT [dbo].[PhanCongNha] ON 

INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (8, N'Làm bài tập được giao', 6)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (9, N'Làm bài tập được giao', 7)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (24, N'Đọc các nội dung liên quan về kinh tế, kinh tế đại cương', 4)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (25, N'Chương 2: Hạ tầng công nghệ trong tài liệu [1].', 4)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (26, N'Làm các bài tập được giao', 5)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (28, N'Làm bài tập được giao', 15)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (29, N'Tìm hiểu chương 2', 15)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (30, N'Làm bài tập được giao', 16)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (32, N'Đọc các nội dung liên quan về kinh  tế, kinh tế đại cương', 18)
INSERT [dbo].[PhanCongNha] ([id], [mota], [id_chuong]) VALUES (33, N'Chương 2: Hạ tầng công nghệ  trong tài liệu [1]', 18)
SET IDENTITY_INSERT [dbo].[PhanCongNha] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([id], [username], [matkhau], [ten]) VALUES (1, N'admin', N'123', N'Admin')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[Tuan] ON 

INSERT [dbo].[Tuan] ([id], [ten]) VALUES (1, 1)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (2, 2)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (3, 3)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (4, 4)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (5, 5)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (6, 6)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (7, 7)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (8, 8)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (9, 9)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (10, 10)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (11, 11)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (12, 12)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (13, 13)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (14, 14)
INSERT [dbo].[Tuan] ([id], [ten]) VALUES (15, 15)
SET IDENTITY_INSERT [dbo].[Tuan] OFF
ALTER TABLE [dbo].[ChuanDauRa]  WITH CHECK ADD FOREIGN KEY([id_muctieu])
REFERENCES [dbo].[MucTieu] ([id])
GO
ALTER TABLE [dbo].[ChuanDauRa]  WITH CHECK ADD  CONSTRAINT [FK__ChuanDauRa__maMH__66603565] FOREIGN KEY([maMH])
REFERENCES [dbo].[MonHoc] ([maMH])
GO
ALTER TABLE [dbo].[ChuanDauRa] CHECK CONSTRAINT [FK__ChuanDauRa__maMH__66603565]
GO
ALTER TABLE [dbo].[Chuong]  WITH CHECK ADD  CONSTRAINT [FK__Chuong__id_tuan__51300E55] FOREIGN KEY([id_tuan])
REFERENCES [dbo].[Tuan] ([id])
GO
ALTER TABLE [dbo].[Chuong] CHECK CONSTRAINT [FK__Chuong__id_tuan__51300E55]
GO
ALTER TABLE [dbo].[Chuong]  WITH CHECK ADD  CONSTRAINT [FK__Chuong__maMH__5224328E] FOREIGN KEY([maMH])
REFERENCES [dbo].[MonHoc] ([maMH])
GO
ALTER TABLE [dbo].[Chuong] CHECK CONSTRAINT [FK__Chuong__maMH__5224328E]
GO
ALTER TABLE [dbo].[MHTienQuyet]  WITH CHECK ADD  CONSTRAINT [FK__MHTienQuy__maMHT__628FA481] FOREIGN KEY([maMHTQ])
REFERENCES [dbo].[MonHoc] ([maMH])
GO
ALTER TABLE [dbo].[MHTienQuyet] CHECK CONSTRAINT [FK__MHTienQuy__maMHT__628FA481]
GO
ALTER TABLE [dbo].[MHTienQuyet]  WITH CHECK ADD  CONSTRAINT [FK__MHTienQuye__maMH__619B8048] FOREIGN KEY([maMH])
REFERENCES [dbo].[MonHoc] ([maMH])
GO
ALTER TABLE [dbo].[MHTienQuyet] CHECK CONSTRAINT [FK__MHTienQuye__maMH__619B8048]
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK__MonHoc__id_chuye__5165187F] FOREIGN KEY([id_chuyennganh])
REFERENCES [dbo].[ChuyenNganh] ([id])
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK__MonHoc__id_chuye__5165187F]
GO
ALTER TABLE [dbo].[MonKhoa]  WITH CHECK ADD FOREIGN KEY([id_khoahoc])
REFERENCES [dbo].[KhoaHoc] ([id])
GO
ALTER TABLE [dbo].[MonKhoa]  WITH CHECK ADD FOREIGN KEY([manganh])
REFERENCES [dbo].[Nganh] ([manganh])
GO
ALTER TABLE [dbo].[MucTieu]  WITH CHECK ADD  CONSTRAINT [FK__MucTieu__maMH__5BE2A6F2] FOREIGN KEY([maMH])
REFERENCES [dbo].[MonHoc] ([maMH])
GO
ALTER TABLE [dbo].[MucTieu] CHECK CONSTRAINT [FK__MucTieu__maMH__5BE2A6F2]
GO
ALTER TABLE [dbo].[PhanCongLop]  WITH CHECK ADD  CONSTRAINT [FK__PhanCongL__id_ch__55009F39] FOREIGN KEY([id_chuong])
REFERENCES [dbo].[Chuong] ([id])
GO
ALTER TABLE [dbo].[PhanCongLop] CHECK CONSTRAINT [FK__PhanCongL__id_ch__55009F39]
GO
ALTER TABLE [dbo].[PhanCongNha]  WITH CHECK ADD  CONSTRAINT [FK__PhanCongN__id_ch__57DD0BE4] FOREIGN KEY([id_chuong])
REFERENCES [dbo].[Chuong] ([id])
GO
ALTER TABLE [dbo].[PhanCongNha] CHECK CONSTRAINT [FK__PhanCongN__id_ch__57DD0BE4]
GO
/****** Object:  StoredProcedure [dbo].[getChuongMH]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getChuongMH] @maMH varchar(10)
as
begin
select * from Chuong where maMH=@maMH 
end
GO
/****** Object:  StoredProcedure [dbo].[getMHhasTQ]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getMHhasTQ] 
as
begin
select distinct MHTienQuyet.maMH,ten from MHTienQuyet,MonHoc where MHTienQuyet.maMH=MonHoc.maMH
end
GO
/****** Object:  StoredProcedure [dbo].[getMHTQ]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getMHTQ] @maMh varchar(10)
as
begin
select maMHTQ from MHTienQuyet where maMH=@maMh
end
GO
/****** Object:  StoredProcedure [dbo].[getMonhoc]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getMonhoc]
as
begin
select* from MonHoc 
end
GO
/****** Object:  StoredProcedure [dbo].[getMuctieuByMH]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getMuctieuByMH] @maMh varchar(10)
as
begin
select * from MucTieu where maMH=@maMh
end
GO
/****** Object:  StoredProcedure [dbo].[getPhancongLop]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getPhancongLop] @id int
as
begin
select * from Phanconglop where id_chuong=@id 
end
GO
/****** Object:  StoredProcedure [dbo].[getPhancongNha]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getPhancongNha] @id int
as
begin
select * from Phancongnha where id_chuong=@id 
end
GO
/****** Object:  StoredProcedure [dbo].[searchSubject]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[searchSubject] @ten nvarchar(100)
as
begin
select* from MonHoc where ten like '%'+@ten+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[searchSubjects]    Script Date: 1/16/2022 11:13:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[searchSubjects] @idKH int,@idn varchar(10),@ten nvarchar(100)
as
begin
select* from dbo.getMHByKhoa(@idKH,@idn) where ten like '%'+@ten+'%'
end
GO
