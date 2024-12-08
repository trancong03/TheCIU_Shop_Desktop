USE [QuanLyShop]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [varchar](10) NOT NULL,
	[password] [varchar](10) NULL,
	[status] [int] NULL,
	[name] [nvarchar](50) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](12) NULL,
	[address] [nvarchar](255) NULL,
	[gender] [nvarchar](5) NULL,
	[avatar] [varchar](20) NULL,
	[background] [varchar](20) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[color_id] [int] IDENTITY(1,1) NOT NULL,
	[color_name] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[color_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[product_id] [int] NOT NULL,
	[username] [varchar](10) NOT NULL,
	[rating] [int] NULL,
	[discription] [nvarchar](255) NULL,
	[dateFB] [date] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC,
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupUsers]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupUsers](
	[idGroup] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK_GroupUsers] PRIMARY KEY CLUSTERED 
(
	[idGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Url] [varchar](30) NOT NULL,
	[product_id] [int] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Url] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[order_id] [int] NOT NULL,
	[variant_id] [int] NOT NULL,
	[quantity] [int] NULL,
	[subtotal] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[variant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](10) NULL,
	[order_date] [date] NULL,
	[status] [int] NULL,
	[payment_date] [date] NULL,
	[voucher_id] [int] NULL,
	[amount] [float] NULL,
 CONSTRAINT [PK__Orders__46596229A2008424] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_voucher]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_voucher](
	[username] [varchar](10) NOT NULL,
	[voucher_id] [int] NOT NULL,
	[count] [int] NULL,
 CONSTRAINT [PK_product_voucher] PRIMARY KEY CLUSTERED 
(
	[username] ASC,
	[voucher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](100) NULL,
	[Title] [nvarchar](255) NULL,
	[price] [float] NULL,
	[category_id] [int] NULL,
	[ImageSP] [varchar](50) NULL,
	[rating] [float] NULL,
	[Dateadd] [date] NULL,
 CONSTRAINT [PK__Products__47027DF566617F9C] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductVariants]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductVariants](
	[variant_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[quantity] [int] NULL,
	[color_id] [int] NULL,
	[size_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[variant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLPhanQuyen]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLPhanQuyen](
	[idGroup] [varchar](10) NOT NULL,
	[idScreen] [varchar](10) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_QLPhanQuyen] PRIMARY KEY CLUSTERED 
(
	[idGroup] ASC,
	[idScreen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Screen]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Screen](
	[idScreen] [varchar](10) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Screen] PRIMARY KEY CLUSTERED 
(
	[idScreen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[size_id] [int] IDENTITY(1,1) NOT NULL,
	[size_name] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[size_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_GroupUser]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_GroupUser](
	[username] [varchar](10) NOT NULL,
	[idGroup] [varchar](10) NOT NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK_User_GroupUser] PRIMARY KEY CLUSTERED 
(
	[username] ASC,
	[idGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 10/5/2024 7:51:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[voucher_id] [int] NOT NULL,
	[dateStart] [nchar](10) NOT NULL,
	[dateEnd] [date] NULL,
	[discount] [int] NULL,
	[tiltle] [nvarchar](50) NULL,
	[discription] [nvarchar](255) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[voucher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([username], [password], [status], [name], [email], [phone], [address], [gender], [avatar], [background]) VALUES (N'admin', N'123456', 1, N'admin', N'admin123@gmail.com', N'0123456789', N'Tân Phú, Hồ Chí Minh', N'Nam', NULL, NULL)
INSERT [dbo].[Account] ([username], [password], [status], [name], [email], [phone], [address], [gender], [avatar], [background]) VALUES (N'cong', N'123456', 1, N'Trần Chí Công', N'chicong123@gmail.com', N'0123789654', N'144 lê Trọng Tấn, Tân Phú, Hồ Chí Minh', N'Nam', NULL, NULL)
INSERT [dbo].[Account] ([username], [password], [status], [name], [email], [phone], [address], [gender], [avatar], [background]) VALUES (N'hang', N'123456', 1, N'Nguyễn Thị Hằng', N'hang61350@gmail.com', N'0238751042', N'144 Lý Thường Kiệt, Phường 4, Gò Vấp, Hồ Chí Minh', N'Nữ', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (1, N'Áo Thun')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (2, N'Đầm')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (3, N'Chân Váy')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (4, N'Quần')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (5, N'Áo Sơ Mi')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (6, N'Áo Khoác')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (7, N'Áo Kiểu')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (8, N'Bộ')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (9, N'Áo Len')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (4, N'Black')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (12, N'Black mix white')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (9, N'Blue')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (11, N'Brown')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (3, N'Cream')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (6, N'Dark Blue')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (7, N'Grey')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (8, N'Jeans')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (10, N'Mint')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (5, N'Pink')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (2, N'Red')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (1, N'White')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
INSERT [dbo].[Feedback] ([product_id], [username], [rating], [discription], [dateFB]) VALUES (2, N'hang', 4, N'Quá đẹp', CAST(N'2024-05-10' AS Date))
GO
INSERT [dbo].[GroupUsers] ([idGroup], [Name], [Note]) VALUES (N'AD', N'ADMIN', NULL)
INSERT [dbo].[GroupUsers] ([idGroup], [Name], [Note]) VALUES (N'KH', N'KHACHHANG', NULL)
GO
INSERT [dbo].[OrderDetails] ([order_id], [variant_id], [quantity], [subtotal]) VALUES (1, 5, 1, 215000)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([order_id], [username], [order_date], [status], [payment_date], [voucher_id], [amount]) VALUES (1, N'hang', CAST(N'2024-10-05' AS Date), 1, CAST(N'2024-10-05' AS Date), 1, 215000)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (2, N'Áo thun tay ngắn cổ tròn đơn giản THE C.I.U - Dony Tee', N'Áo thun tay ngắn cổ tròn đơn giản THE C.I.U - Dony Tee là một item thời trang không thể thiếu trong tủ đồ hàng ngày của bạn. Chất liệu: Áo được làm từ vải cotton mềm mại, thoáng khí, mang lại cảm giác thoải mái suốt cả ngày.', 215000, 1, N'A001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (3, N'Áo tay phồng phối viền bèo nút kiểu THE C.I.U - Potia Top - C11', N'Chiếc áo tay phồng xinh xắn với viền bèo nút kiểu THE C.I.U - Potia Top - C11 sẽ là lựa chọn hoàn hảo cho các cô gái yêu thích phom dáng đẹp và nữ tính. Thiết kế độc đáo: Áo được thiết kế với tay phồng và viền bèo nút tinh tế, mang lại sự dễ thương.', 245000, 7, N'AK001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (4, N'Áo kiểu tay phồng tà xòe phối nơ THE C.I.U - Kristy Top', N'Áo kiểu tay phồng tà xòe phối nơ THE C.I.U - Kristy Top là một chiếc áo kiểu nữ tính và dễ thương cho phái đẹp. Thiết kế tay phồng và tà xòe Phối nơ nhẹ nhàng Sang trọng và dễ kết hợp với các trang phục khác', 255000, 7, N'AK006.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (5, N'Đầm babydoll tơ lưới caro đính hoa nổi THE C.I.U - Jordy Dress - C11', N'Mang đến sự thoải mái và dễ chịu cho phong cách thường ngày, Đầm babydoll tơ lưới caro đính hoa nổi THE C.I.U - Jordy Dress - C11 là lựa chọn hoàn hảo cho phái đẹp. Chất liệu tơ lưới mềm mại Thiết kế babydoll thoải mái Họa tiết caro trẻ trung.', 435000, 2, N'D001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (6, N'Đầm trễ vai dáng ngắn phồng xòe THE C.I.U - Marina Dress - C11', N'Chiếc đầm trễ vai dáng ngắn phồng xòe mang tên Marina Dress từ thương hiệu THE C.I.U sẽ là lựa chọn hoàn hảo cho những dịp quan trọng. Dáng ngắn phồng xòe: Tạo điểm nhấn nữ tính và quyến rũ. Thiết kế trễ vai: Tôn lên vẻ gợi cảm và thời thượng.', 350000, 2, N'D006.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (7, N'Đầm cúp ngực dáng xòe phối nơ THE C.I.U - Gemma Dress - C11', N'Chiếc đầm cúp ngực dáng xòe phối nơ THE C.I.U - Gemma Dress - C11 là lựa chọn hoàn hảo cho những buổi tiệc sang trọng. Dáng xòe thanh lịch Phối nơ tinh tế Thiết kế độc đáo từ thương hiệu THE C.I.U', 355000, 2, N'D011.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (8, N'Chân váy nhung mịn form chữ A THE C.I.U - Potia Skirt - C11', N'Chân váy nhung mịn form chữ A THE C.I.U - Potia Skirt - C11 là một lựa chọn hoàn hảo cho phong cách thời trang nữ tính và thanh lịch. Chất liệu: Chất liệu nhung mịn mang lại cảm giác thoải mái cho người mặc. Thiết kế form chữ A giúp che khuyết điểm.', 295000, 3, N'C001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (9, N'Đầm babydoll dây buộc cổ họa tiết viền đá + đính nơ THE C.I.U - Olena Dress - C11', N'Mang đến vẻ ngoại hình dễ thương và nữ tính, Đầm babydoll Olena từ THE C.I.U là lựa chọn hoàn hảo cho những cô gái yêu thích phong cách đơn giản nhưng không kém phần duyên dáng. Thiết kế Babydoll: Đầm được thiết kế babydoll thoải mái.', 380000, 2, N'D017.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (10, N'Đầm dài dáng xòe hai dây phối nơ THE C.I.U - Tamara Dress - C11', N'Mang đến cho bạn phong cách nữ tính và thanh lịch, chiếc đầm dài dáng xòe hai dây phối nơ THE C.I.U là lựa chọn hoàn hảo cho những buổi hẹn hay dạo phố. Thiết kế Elegance: Dáng xòe tôn vẻ đẹp quyến rũ của bạn.', 425000, 2, N'D022.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (11, N'Đầm hai dây dáng xòe đai đính nơ THE C.I.U - Britta Dress - C11', N'Mang đến phong cách thanh lị và nữ tính, đầm hai dây dáng xòe đai đính nơ THE C.I.U - Britta Dress - C11 là sự lựa chọn hoàn hảo cho những ngày dạo phố thoải mái. Dáng xòe thanh lị Thiết kế hai dây nữ tính Đính nơ tinh tế', 350000, 2, N'D027.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (12, N'Đầm suông tay phồng phối nơ lai bèo xếp tầng THE C.I.U - Dora Dress - C11', N'Mang đến sự trang nhã và lịch lãm, chiếc Đầm suông tay phồng phối nơ tà xòe THE C.I.U - Dora Dress - C11 là sự lựa chọn hoàn hảo cho những dịp quan trọng. Thiết kế đơn giản, sang trọng Chất liệu cao cấp, thoáng mát Tay phồng nữ tính Phối nơ tinh tế.', 450000, 2, N'D033.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (13, N'Đầm ngắn hai dây tafta đính đá phối nơ THE C.I.U - Baylor Dress - C11', N'Chiếc đầm ngắn hai dây tafta đính đá phối nơ THE C.I.U - Baylor Dress - C11 sẽ là lựa chọn hoàn hảo cho những buổi dạo phố hay hẹn hò cuối tuần. Chất liệu tafta cao cấp Thiết kế hai dây thanh lịch Họa tiết đá sang trọng Nơ xinh xắn phối điểm nhấn.', 350000, 2, N'D038.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (14, N'Quần dù ống rộng rút eo THE C.I.U - Jangmi Pants 2', N'Quần dù ống rộng rút eo THE C.I.U - Jangmi Pants 2 là lựa chọn hoàn hảo cho phong cách thời trang nữ tính và thoải mái. Chất liệu chất lượng: Được làm từ vải cao cấp, thoáng mát và dễ vận động. Thiết kế hiện đại: Quần dài, ôm vừa tạo điểm nhấn.', 295000, 4, N'Q001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (15, N'Quần dài ống rộng lưng chun phối bèo THE C.I.U - Glimmer Pants', N'Quần dài ống rộng lưng chun phối bèo THE C.I.U - Glimmer Pants', 395000, 4, N'Q002.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (16, N'Quần kaki ống rộng phong cách Hàn Quốc THE C.I.U - Devon Pants', N'Mang đến cho bạn phong cách Hàn Quốc đầy năng động và thoải mái với quần kaki ống rộng THE C.I.U - Devon Pants. Chất liệu kaki cao cấp, thoáng mát, thấm hút mồ hôi tốt. Thiết kế ống rộng giúp che khuyết điểm vòng 2 và tôn lên chiều cao của bạn.', 335000, 4, N'Q007.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (17, N'Quần dù ống rộng phối nơ THE C.I.U - Nathan Pants', N'Quần dù ống rộng phối nơ THE C.I.U - Nathan Pants là sản phẩm quần dài cho phụ nữ với kiểu dáng ống rộng và được phối thêm chi tiết nơ trang trí tinh tế. Kiểu dáng thoải mái: Quần được cắt rộng thoải mái cùng chất liệu vải mềm mại, mang lại sự thoải mái.', 335000, 4, N'Q012.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (18, N'Chân váy bí THE C.I.U - Lollipop Skirt 2', N'Chân váy bí THE C.I.U - Lollipop Skirt 2 là sự lựa chọn hoàn hảo cho phong cách thời trang cá nhân của bạn. Thiết kế độc đáo: Chân váy bí với họa tiết lollipop sẽ khiến bạn nổi bật trên mọi nơi. Chất liệu thoáng mát: Được làm từ vải cao cấp.', 265000, 3, N'C006.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (19, N'Chân váy ngắn dáng xòe cotton phối nơ THE C.I.U - Ida Skirt', N'Chân váy ngắn dáng xòe cotton phối nơ THE C.I.U - Ida Skirt là lựa chọn hoàn hảo cho phong cách thanh lịch và nữ tính. Chất liệu cotton thoáng mát, dễ chịu khi mặc cả ngày. Dáng xòe giúp tạo điểm nhấn cho vẻ đẹp của đôi chân.', 275000, 3, N'C012.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (20, N'Chân váy jeans ngắn túi hộp THE C.I.U - Orlando Skirt', N'Chân váy jeans ngắn túi hộp THE C.I.U - Orlando Skirt là lựa chọn hoàn hảo cho phong cách năng động và trẻ trung của bạn. Mẫu chân váy ngắn với thiết kế túi hộp độc đáo. Chất liệu jeans cao cấp, thoải mái và bền bỉ. Gọn gàng, dễ phối đồ với nhiều loại.', 320000, 3, N'C017.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (21, N'Chân váy ngắn xòe phối bèo nhún lưng thun THE C.I.U - Orion Skirt', N'Chân váy ngắn xòe phối bèo nhún lưng thun THE C.I.U - Orion Skirt là một chiếc chân váy dễ thương và cá tính dành cho phái đẹp. Thiết kế Xòe và Phối Bèo: Chân váy có kiểu dáng xòe giúp tạo điểm nhấn cho outfit của bạn, điểm nhấn bèo xinh xắn.', 255000, 3, N'C022.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (22, N'Áo sơ mi cổ tàu tay ngắn dáng babydoll THE C.I.U - Neema Top', N'Áo sơ mi cổ tàu tay ngắn dáng babydoll THE C.I.U - Neema Top là một mẫu áo sơ mi nữ mang phong cách babydoll đáng yêu và dễ thương. Thiết kế cổ tàu và tay ngắn mang lại vẻ trẻ trung và năng động. Dáng áo babydoll giúp che đi nhược điểm vòng bụng.', 275000, 5, N'S001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (23, N'Áo sơ mi tay dài croptop túi nơ THE C.I.U - Tyson Shirt - MN04', N'Áo sơ mi tay dài croptop túi nơ THE C.I.U - Tyson Shirt - MN04 là sự kết hợp hoàn hảo giữa phom dáng truyền thống và điểm nhấn hiện đại, phù hợp cho mọi cô gái. Thiết kế: Áo sơ mi tay dài với chiều dài croptop và túi nơ xinh xắn.', 265000, 5, N'S006.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (24, N'Áo sơ mi tay ngắn form ôm phối họa tiết ren THE C.I.U - Alice Shirt - MN04', N'Áo sơ mi tay ngắn form ôm phối họa tiết ren THE C.I.U - Alice Shirt là một chiếc áo sơ mi tay ngắn thanh lịch và sang trọng dành cho phái đẹp. Chất liệu: Áo được làm từ vải cao cấp, mềm mịn, thoáng khí, mang lại cảm giác thoải mái cho người mặc.', 265000, 5, N'S011.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (25, N'Áo hai dây cổ V phối nơ THE C.I.U - Alora Top', N'Áo hai dây cổ V phối nơ THE C.I.U - Alora Top là lựa chọn hoàn hảo cho các cô gái yêu thích phom áo tank top. Thiết kế thanh lịch: Áo với cổ V tạo điểm nhấn vừa giúp tôn dáng, vừa mang lại sự quyến rũ cho người mặc. Nhấn nơ phối: Chi tiết nơ xinh xắn.', 245000, 7, N'AK010.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (26, N'Áo hai dây babydoll họa tiết thêu THE C.I.U - Bowie Top', N'Áo hai dây babydoll họa tiết thêu THE C.I.U - Bowie Top là một chiếc áo hai dây nữ tinh tế và đáng yêu. Thiết kế babydoll: Tạo cảm giác thoải mái và nhẹ nhàng khi mặc. Họa tiết thêu độc đáo: Tạo điểm nhấn cho bộ áo, làm nổi bật vẻ đẹp của người phụ nữ.', 275000, 7, N'AK015.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (27, N'Áo croptop denim hai dây cột nơ THE C.I.U - Foster Top', N'Chiếc áo croptop denim hai dây cột nơ THE C.I.U - Foster Top là lựa chọn hoàn hảo cho phong cách thời trang năng động và cá tính. Thiết kế độc đáo: Chất liệu denim bền bỉ và thoáng khí.', 220000, 7, N'AK020.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (28, N'Áo quây bèo nhún phối nơ THE CIU - Nicola Top', N'Áo quây bèo nhún phối nơ THE CIU - Nicola Top là một trong những sản phẩm đầy nữ tính và dễ thương của bộ sưu tập áo phông dành cho nữ của THE CIU. Với thiết kế đơn giản nhưng tinh tế, chiếc áo này sẽ giúp bạn trông thật xinh xắn và duyên dáng.', 255000, 7, N'AK025.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (29, N'Áo croptop form ôm cổ tròn THE C.I.U - Feminist Crop Top', N'Chiếc áo croptop form ôm cổ tròn THE C.I.U - Feminist Crop Top sẽ là một lựa chọn tuyệt vời cho các nàng yêu thích phong cách năng động và cá tính. Thiết kế form ôm: Chiếc áo theo phong cách croptop form ôm sẽ giúp các nàng tôn lên được vóc dáng.', 195000, 7, N'AK030.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (30, N'Áo cardigan len nút cài THE C.I.U - Julian Cardigan', N'Mang lại phong cách thoải mái và tinh tế với Áo cardigan len nút cài THE C.I.U - Julian Cardigan. Chất liệu len chất lượng cao Thiết kế nút cài phối hợp với áo Có thể kết hợp dễ dàng với nhiều trang phục khác nhau', 450000, 6, N'K001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (31, N'Áo khoác tay dài croptop cổ tròn đính khuy nơ THE C.I.U - Gale Jacket - MN04', N'Áo khoác tay dài croptop cổ tròn đính khuy nơ THE C.I.U - Gale Jacket - MN04 là lựa chọn hoàn hảo cho các cô gái yêu thích phong cách năng động và cá tính. Thiết kế: Áo khoác tay dài với cổ tròn và đính khuy nơ tạo điểm nhấn duyên dáng.', 295000, 6, N'K006.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (32, N'Áo blazer tay dài nút kiểu THE C.I.U - Malva Blazer - MN04', N'Chiếc áo blazer tay dài nút kiểu THE C.I.U - Malva Blazer - MN04 là lựa chọn hoàn hảo cho phái đẹp khi cần một item thanh lịch và sang trọng. Thiết kế đẹp mắt: Áo blazer được thiết kế tinh tế với kiểu dáng trẻ trung, nút cài và cổ áo thanh lịch, phù hợp', 425000, 6, N'K011.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (33, N'Áo khoác dù THE C.I.U - Dana Jacket', N'Áo khoác dù THE C.I.U - Dana Jacket là một lựa chọn hoàn hảo cho những ngày đông lạnh giá. Với chất liệu dù cao cấp, sản phẩm đảm bảo sẽ giữ ấm cho bạn trong những ngày thời tiết khắc nghiệt. Thiết kế: Với kiểu dáng bomber trẻ trung và năng động.', 450000, 6, N'K016.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (34, N'Áo khoác dù xốp THE C.I.U - Campion Jacket', N'Mô tả: Áo khoác dù xốp THE C.I.U - Campion Jacket là một trong những sản phẩm thời trang nữ hàng đầu của chúng tôi. Với chất liệu dù xốp cao cấp, áo khoác này không chỉ giữ ấm mà còn rất nhẹ và thoải mái khi sử dụng.', 385000, 6, N'K021.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (35, N'Chân váy ngắn xòe cạp cao xếp ly bản to THE C.I.U - Laine Skirt - MN04', N'Chân váy ngắn xòe phối lưng chun THE C.I.U - Damon Skirt là một chiếc chân váy đáng yêu và nữ tính dành cho phái đẹp. Thiết kế xòe thoải mái: Chất liệu xốp nhẹ nhàng tạo cảm giác thoải mái cho người mặc. Lưng chun thời trang: Phối lưng chun tinh tế.', 275000, 3, N'C027.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (36, N'Chân váy ngắn xòe cạp cao xếp ly bản to THE C.I.U - Laine Skirt - MN04', N'Chân váy ngắn xòe cạp cao xếp ly bản to THE C.I.U - Laine Skirt - MN04. Thiết kế xòe và cạp cao Chất liệu thoáng mát và dễ di chuyển Họa tiết xếp ly bản to tạo điểm nhấn nổi bật', 265000, 3, N'C032.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (37, N'Chân váy ngắn xếp ly phối thắt lưng THE C.I.U - Vincent Skirt', N'Chân váy ngắn xếp ly phối thắt lưng THE C.I.U - Vincent Skirt là sự kết hợp hoàn hảo giữa phom dáng thời trang và chất liệu chất lượng. Thiết kế xếp ly: Chân váy được thiết kế xếp ly tinh tế, tạo điểm nhấn nữ tính và duyên dáng. Phối thắt lưng.', 325000, 3, N'C037.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (38, N'Chân váy midi xòe phối bèo nhún THE C.I.U - Anya Maxi Skirt', N'Chân váy midi xòe phối bèo nhún THE C.I.U - Anya Maxi Skirt là chiếc chân váy dài xu hướng, phối bèo nhún tinh tế, mang lại vẻ đẹp dịu dàng và nữ tính. Thiết kế Midi Xòe: Độ dài vừa giữa đầu gối và mắt cá chân, tạo điểm nhấn thanh lịch cho trang phục.', 350000, 3, N'C042.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (39, N'Chân váy jean đuôi cá dáng dài THE C.I.U - Gina Maxi Skirt', N'Chân váy jean đuôi cá dáng dài THE C.I.U - Gina Maxi Skirt là một trong những sản phẩm mới nhất của bộ sưu tập váy của chúng tôi. Được thiết kế với kiểu dáng đơn giản và hiện đại, chân váy này sẽ giúp bạn trông thật năng động và phong cách.', 375000, 3, N'C047.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (40, N'Set đồ denim sát nách cổ tròn + quần short lưng chun THE C.I.U - Emma Set - MN04', N'Bộ đồ denim sát nách cổ tròn + quần short lưng chun THE C.I.U - Emma Set - MN04 mang đến phong cách trẻ trung và năng động cho phái nữ. Chất liệu chất lượng: Sử dụng denim bền đẹp, thoáng mát cho cảm giác thoải mái suốt ngày dài.', 465000, 8, N'B001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (41, N'Set áo sơ mi tay ngắn phối nơ + chân váy bí THE C.I.U - Tyde Set', N'Mang đến sự thanh lị và tinh tế, Set áo sơ mi tay ngắn phối nơ + chân váy bí THE C.I.U - Tyde Set là lựa chọn hoàn hảo cho phong cách công sở sang trọng. Bộ trang phục độc đáo: Bao gồm áo sơ mi tay ngắn với nơ cổ xinh xắn kết hợp với chân váy bí điệu.', 425000, 8, N'B006.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (42, N'Set áo hai dây + chân váy xòe phối nơ THE C.I.U - Lovell Set', N'Set áo hai dây + chân váy xòe phối nơ THE C.I.U - Lovell Set là sự kết hợp hoàn hảo giữa áo hai dây nữ tính và chân váy xòe duyên dáng. Thiết kế thanh lịch: Áo hai dây tôn lên vẻ quý phái, kết hợp cùng chân váy xòe mang đến vẻ đẹp nữ tính và cuốn hút.', 385000, 8, N'B011.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (43, N'Set áo tay ngắn rút eo + quần short lưng chun THE C.I.U - Scoopy Set', N'Một set trang phục hoàn hảo cho phụ nữ hiện đại. Thiết kế đẹp mắt: Bộ áo tay ngắn rút eo kết hợp với quần short lưng chun mang lại sự thanh lịch và cá tính. Chất liệu thoáng mát: Được làm từ vải cao cấp, êm ái và thoải mái cho cả ngày dài hoạt động.', 525000, 8, N'B016.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (44, N'Quần short bí phối lưng chun THE C.I.U - Juniper Short - MN03', N'Quần short bí phối lưng chun THE C.I.U - Juniper Short - MN03 là một sự lựa chọn hoàn hảo cho phái đẹp trong mùa hè này. Với thiết kế đơn giản nhưng không kém phần tinh tế, chiếc quần short này sẽ giúp bạn nổi bật và tự tin trên mọi con đường.', 250000, 4, N'Q017.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (45, N'Quần short cạp cao form ôm THE C.I.U - Velvet Short', N'Với thiết kế cạp cao, chiếc quần short này giúp tôn lên đường cong chuẩn của bạn một cách hoàn hảo. Chất liệu vải velvet mềm mại và thoải mái, đem lại sự thoải mái khi di chuyển. Form ôm: Thiết kế form quần ôm sát giúp làm nổi bật vòng ba và đôi chân dài', 265000, 4, N'Q022.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (46, N'Quần short lưng thun họa tiết bèo nhún THE C.I.U - Liam Short', N'Mang đến sự thoải mái và thoáng mát cho mùa hè, Quần short lưng thun họa tiết bèo nhún THE C.I.U - Liam Short là lựa chọn hoàn hảo cho phong cách thời trang của bạn. Chất liệu: Lưng thun co giãn, tạo cảm giác thoải mái khi mặc.', 245000, 4, N'Q028.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (47, N'Đầm babydoll hai dây phối nơ THE C.I.U - Sunday Dress', N'Đầm babydoll hai dây phối nơ THE C.I.U - Sunday Dress là lựa chọn hoàn hảo cho những ngày cuối tuần. Thiết kế babydoll dễ thương Dây vai mảnh mai, tạo điểm nhấn quyến rũ Phối nơ xinh xắn ở phần ngực', 365000, 2, N'D043.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (48, N'Đầm xòe cổ sơ mi phối nơ THE C.I.U - Esther Dress', N'Mang phong cách trẻ trung và nữ tính, đầm xòe cổ sơ mi phối nơ THE C.I.U - Esther Dress sẽ là lựa chọn hoàn hảo cho những buổi dạo phố, hẹn hò hay đi làm. Chất liệu: vải tencel mềm mịn, thoáng mát', 350000, 2, N'D048.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (49, N'Áo gile thun len cổ tròn phối nơ THE C.I.U - Bliss Gile - MN04', N'Chiếc áo gile thun len cổ tròn phối nơ THE C.I.U - Bliss Gile - MN04 là sự kết hợp hoàn hảo giữa phong cách truyền thống và sự thoải mái hàng ngày. Chất liệu: Áo được làm từ len mềm mại, tạo cảm giác dễ chịu khi mặc. Thiết kế: Cổ tròn và phối nơ tinh tế', 195000, 9, N'AL001.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (50, N'Áo len cổ tròn phối nơ THE C.I.U - Stivie Top', N'Với thiết kế đơn giản nhưng không kém phần tinh tế, Áo len cổ tròn phối nơ THE C.I.U - Stivie Top là lựa chọn hoàn hảo cho những cô nàng yêu thích sự đơn giản, trẻ trung và thanh lịch. Chất liệu len cao cấp, mềm mại và thoải mái khi mặc.', 275000, 9, N'AL006.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (51, N'Áo thun len viên tay ngắn phối nơ THE C.I.U - Finley Top', N'Áo thun len viên tay ngắn phối nơ THE C.I.U - Finley Top là một chiếc áo thun len dễ mặc và thoải mái cho các cô nàng. Với thiết kế tay ngắn và phối nơ xinh xắn, chiếc áo này sẽ giúp bạn trông trẻ trung và duyên dáng cả khi đi làm hay đi chơi.', 250000, 9, N'AL011.jpg', NULL, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Products] ([product_id], [product_name], [Title], [price], [category_id], [ImageSP], [rating], [Dateadd]) VALUES (52, N'Áo gile len cổ tròn THE C.I.U - Cadie Gile', N'Một chiếc áo gile len cổ tròn THE C.I.U - Cadie Gile vô cùng ấm áp, phù hợp cho mùa đông lạnh giá. Thiết kế trẻ trung, năng động với phom dáng ôm gọn cơ thể. Chất liệu len cao cấp, mềm mại và bền chắc.', 295000, 9, N'AL016.jpg', NULL, CAST(N'2024-05-10' AS Date))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductVariants] ON 

INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (5, 2, 20, 1, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (6, 2, 20, 2, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (7, 2, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (8, 2, 20, 4, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (9, 3, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (10, 3, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (11, 4, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (12, 5, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (13, 5, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (14, 6, 20, 2, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (15, 6, 20, 2, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (16, 6, 20, 2, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (17, 7, 20, 2, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (18, 7, 20, 2, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (19, 7, 20, 2, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (20, 7, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (21, 7, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (22, 7, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (23, 8, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (24, 8, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (25, 8, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (26, 9, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (27, 9, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (28, 10, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (29, 10, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (30, 10, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (31, 11, 20, 2, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (32, 11, 20, 2, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (33, 11, 20, 2, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (34, 11, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (35, 11, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (36, 11, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (37, 12, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (38, 12, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (39, 13, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (40, 13, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (41, 13, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (43, 14, 20, 5, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (44, 15, 20, 6, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (45, 16, 20, 1, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (46, 16, 20, 1, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (47, 16, 20, 1, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (48, 17, 20, 7, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (49, 18, 20, 7, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (50, 18, 20, 1, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (51, 19, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (52, 19, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (53, 19, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (56, 20, 20, 8, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (57, 20, 20, 8, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (58, 20, 20, 8, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (59, 21, 20, 1, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (60, 22, 20, 9, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (62, 23, 20, 9, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (63, 24, 20, 1, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (64, 24, 20, 1, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (65, 25, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (66, 25, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (67, 25, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (68, 26, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (69, 27, 20, 8, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (70, 27, 20, 8, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (71, 28, 20, 4, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (72, 29, 20, 4, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (73, 30, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (74, 31, 20, 4, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (75, 31, 20, 4, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (76, 31, 20, 4, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (77, 32, 20, 6, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (78, 33, 20, 10, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (79, 34, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (80, 35, 20, 6, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (81, 35, 20, 6, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (82, 35, 20, 6, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (83, 36, 20, 1, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (84, 36, 20, 1, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (85, 36, 20, 1, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (86, 37, 20, 7, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (87, 37, 20, 7, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (88, 37, 20, 7, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (89, 38, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (90, 39, 20, 8, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (91, 39, 20, 8, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (92, 39, 20, 8, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (93, 40, 20, 8, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (95, 41, 20, 9, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (96, 41, 20, 9, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (97, 41, 20, 9, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (98, 42, 20, 3, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (99, 42, 20, 3, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (100, 42, 20, 3, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (101, 43, 20, 6, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (102, 44, 20, 11, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (103, 44, 20, 11, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (104, 45, 20, 3, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (105, 45, 20, 3, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (106, 45, 20, 3, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (107, 45, 20, 7, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (108, 45, 20, 7, 3)
GO
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (109, 45, 20, 7, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (110, 46, 20, 11, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (111, 46, 20, 11, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (112, 47, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (113, 47, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (114, 48, 20, 9, 2)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (115, 48, 20, 9, 3)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (116, 48, 20, 9, 4)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (117, 49, 20, 12, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (118, 50, 20, 12, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (120, 51, 20, 3, 1)
INSERT [dbo].[ProductVariants] ([variant_id], [product_id], [quantity], [color_id], [size_id]) VALUES (121, 52, 20, 7, 1)
SET IDENTITY_INSERT [dbo].[ProductVariants] OFF
GO
INSERT [dbo].[QLPhanQuyen] ([idGroup], [idScreen], [status]) VALUES (N'AD', N'SF001', NULL)
INSERT [dbo].[QLPhanQuyen] ([idGroup], [idScreen], [status]) VALUES (N'AD', N'SF002', NULL)
INSERT [dbo].[QLPhanQuyen] ([idGroup], [idScreen], [status]) VALUES (N'AD', N'SF003', NULL)
INSERT [dbo].[QLPhanQuyen] ([idGroup], [idScreen], [status]) VALUES (N'AD', N'SF004', NULL)
INSERT [dbo].[QLPhanQuyen] ([idGroup], [idScreen], [status]) VALUES (N'AD', N'SF005', NULL)
GO
INSERT [dbo].[Screen] ([idScreen], [name]) VALUES (N'SF001', N'NGUOI DUNG')
INSERT [dbo].[Screen] ([idScreen], [name]) VALUES (N'SF002', N'NHOM NGUOI DUNG')
INSERT [dbo].[Screen] ([idScreen], [name]) VALUES (N'SF003', N'MAN HINH CN')
INSERT [dbo].[Screen] ([idScreen], [name]) VALUES (N'SF004', N'THEM NGUOI DUNG VAO NHOM')
INSERT [dbo].[Screen] ([idScreen], [name]) VALUES (N'SF005', N'PHAN QUYEN')
GO
SET IDENTITY_INSERT [dbo].[Sizes] ON 

INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (1, N'Freesize')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (4, N'L')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (3, N'M')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (2, N'S')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (5, N'XL')
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO
INSERT [dbo].[User_GroupUser] ([username], [idGroup], [Note]) VALUES (N'admin', N'AD', NULL)
INSERT [dbo].[User_GroupUser] ([username], [idGroup], [Note]) VALUES (N'hang', N'KH', NULL)
GO
INSERT [dbo].[Voucher] ([voucher_id], [dateStart], [dateEnd], [discount], [tiltle], [discription], [status]) VALUES (1, N'2024-10-01', CAST(N'2024-10-31' AS Date), 20, N'Khuyến Mãi Mùa Đông', N'Khuyến mãi tất cả sản phẩm mùa đông', 1)
INSERT [dbo].[Voucher] ([voucher_id], [dateStart], [dateEnd], [discount], [tiltle], [discription], [status]) VALUES (2, N'2024-11-01', CAST(N'2024-11-30' AS Date), 15, N'Ưu Đãi Đặc Biệt Tháng 11', N'Giảm giá 15% khi mua hóa đơn trên 1 triệu đồng', 1)
INSERT [dbo].[Voucher] ([voucher_id], [dateStart], [dateEnd], [discount], [tiltle], [discription], [status]) VALUES (3, N'2024-12-01', CAST(N'2024-12-25' AS Date), 25, N'NULLKhuyến Mãi Giáng Sinh', N'Giảm giá 25% cho tất cả sản phẩm mùa đông', 1)
INSERT [dbo].[Voucher] ([voucher_id], [dateStart], [dateEnd], [discount], [tiltle], [discription], [status]) VALUES (4, N'2024-12-26', CAST(N'2025-01-05' AS Date), 30, N'Tết Dương Lịch', N'Ưu đãi 30% cho các sản phẩm thời trang nữ', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Colors__2F423AB817CCFB73]    Script Date: 10/5/2024 7:51:21 PM ******/
ALTER TABLE [dbo].[Colors] ADD UNIQUE NONCLUSTERED 
(
	[color_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Sizes__75FCE55652808145]    Script Date: 10/5/2024 7:51:21 PM ******/
ALTER TABLE [dbo].[Sizes] ADD UNIQUE NONCLUSTERED 
(
	[size_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__payment___5BE2A6F2]  DEFAULT (NULL) FOR [payment_date]
GO
ALTER TABLE [dbo].[ProductVariants] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Account] FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Account]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Products]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__order__5EBF139D] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__order__5EBF139D]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([variant_id])
REFERENCES [dbo].[ProductVariants] ([variant_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Account] FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Account]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Voucher] FOREIGN KEY([voucher_id])
REFERENCES [dbo].[Voucher] ([voucher_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Voucher]
GO
ALTER TABLE [dbo].[product_voucher]  WITH CHECK ADD  CONSTRAINT [FK_product_voucher_Account] FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[product_voucher] CHECK CONSTRAINT [FK_product_voucher_Account]
GO
ALTER TABLE [dbo].[product_voucher]  WITH CHECK ADD  CONSTRAINT [FK_product_voucher_Voucher] FOREIGN KEY([voucher_id])
REFERENCES [dbo].[Voucher] ([voucher_id])
GO
ALTER TABLE [dbo].[product_voucher] CHECK CONSTRAINT [FK_product_voucher_Voucher]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Products__catego__619B8048] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([category_id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Products__catego__619B8048]
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD FOREIGN KEY([color_id])
REFERENCES [dbo].[Colors] ([color_id])
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK__ProductVa__produ__628FA481] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[ProductVariants] CHECK CONSTRAINT [FK__ProductVa__produ__628FA481]
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD FOREIGN KEY([size_id])
REFERENCES [dbo].[Sizes] ([size_id])
GO
ALTER TABLE [dbo].[QLPhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_QLPhanQuyen_GroupUsers] FOREIGN KEY([idGroup])
REFERENCES [dbo].[GroupUsers] ([idGroup])
GO
ALTER TABLE [dbo].[QLPhanQuyen] CHECK CONSTRAINT [FK_QLPhanQuyen_GroupUsers]
GO
ALTER TABLE [dbo].[QLPhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_QLPhanQuyen_Screen] FOREIGN KEY([idScreen])
REFERENCES [dbo].[Screen] ([idScreen])
GO
ALTER TABLE [dbo].[QLPhanQuyen] CHECK CONSTRAINT [FK_QLPhanQuyen_Screen]
GO
ALTER TABLE [dbo].[User_GroupUser]  WITH CHECK ADD  CONSTRAINT [FK_User_GroupUser_Account] FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[User_GroupUser] CHECK CONSTRAINT [FK_User_GroupUser_Account]
GO
ALTER TABLE [dbo].[User_GroupUser]  WITH CHECK ADD  CONSTRAINT [FK_User_GroupUser_GroupUsers] FOREIGN KEY([idGroup])
REFERENCES [dbo].[GroupUsers] ([idGroup])
GO
ALTER TABLE [dbo].[User_GroupUser] CHECK CONSTRAINT [FK_User_GroupUser_GroupUsers]
GO
