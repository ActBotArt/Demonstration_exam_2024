USE [partner_system_db]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeId] [int] NULL,
	[ProductName] [nvarchar](200) NOT NULL,
	[ArticleNumber] [nvarchar](50) NOT NULL,
	[MinCostForPartner] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[PartnerId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NOT NULL,
	[SaleDate] [date] NOT NULL,
	[SalePrice] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_PartnerSalesHistory]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Представление для истории продаж партнеров
CREATE VIEW [dbo].[vw_PartnerSalesHistory] AS
SELECT 
    s.SaleId,
    s.PartnerId,
    p.ProductName,
    s.Quantity,
    s.SaleDate,
    s.SalePrice,
    (s.Quantity * s.SalePrice) as TotalAmount
FROM Sales s
JOIN Products p ON p.ProductId = s.ProductId;
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partners](
	[PartnerId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyType] [nvarchar](10) NOT NULL,
	[CompanyName] [nvarchar](200) NOT NULL,
	[DirectorName] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
	[INN] [nvarchar](12) NOT NULL,
	[Rating] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PartnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_PartnerDiscounts]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Представление для расчета скидок партнеров
CREATE VIEW [dbo].[vw_PartnerDiscounts] AS
SELECT 
    p.PartnerId,
    p.CompanyName,
    SUM(s.Quantity) as TotalQuantity,
    CASE 
        WHEN SUM(s.Quantity) > 300000 THEN 15
        WHEN SUM(s.Quantity) > 50000 THEN 10
        WHEN SUM(s.Quantity) > 10000 THEN 5
        ELSE 0
    END as DiscountPercent
FROM Partners p
LEFT JOIN Sales s ON p.PartnerId = s.PartnerId
GROUP BY p.PartnerId, p.CompanyName;
GO
/****** Object:  Table [dbo].[MaterialTypes]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialTypes](
	[MaterialTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
	[DefectPercent] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaterialTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[ProductTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
	[TypeCoefficient] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26.03.2025 12:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MaterialTypes] ON 

INSERT [dbo].[MaterialTypes] ([MaterialTypeId], [TypeName], [DefectPercent]) VALUES (1, N'Тип материала 1', CAST(0.10 AS Decimal(10, 2)))
INSERT [dbo].[MaterialTypes] ([MaterialTypeId], [TypeName], [DefectPercent]) VALUES (2, N'Тип материала 2', CAST(0.95 AS Decimal(10, 2)))
INSERT [dbo].[MaterialTypes] ([MaterialTypeId], [TypeName], [DefectPercent]) VALUES (3, N'Тип материала 3', CAST(0.28 AS Decimal(10, 2)))
INSERT [dbo].[MaterialTypes] ([MaterialTypeId], [TypeName], [DefectPercent]) VALUES (4, N'Тип материала 4', CAST(0.55 AS Decimal(10, 2)))
INSERT [dbo].[MaterialTypes] ([MaterialTypeId], [TypeName], [DefectPercent]) VALUES (5, N'Тип материала 5', CAST(0.34 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[MaterialTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Partners] ON 

INSERT [dbo].[Partners] ([PartnerId], [CompanyType], [CompanyName], [DirectorName], [Email], [Phone], [Address], [INN], [Rating]) VALUES (1, N'ЗАО', N'База Строитель', N'Иванова Александра Ивановна', N'aleksandraivanova@ml.ru', N'493 123 45 67', N'652050, Кемеровская область, город Юрга, ул. Лесная, 15', N'2222455179', 7)
INSERT [dbo].[Partners] ([PartnerId], [CompanyType], [CompanyName], [DirectorName], [Email], [Phone], [Address], [INN], [Rating]) VALUES (2, N'ООО', N'Паркет 29', N'Петров Василий Петрович', N'vppetrov@vl.ru', N'987 123 56 78', N'164500, Архангельская область, город Северодвинск, ул. Строителей, 18', N'3333888520', 7)
INSERT [dbo].[Partners] ([PartnerId], [CompanyType], [CompanyName], [DirectorName], [Email], [Phone], [Address], [INN], [Rating]) VALUES (3, N'ПАО', N'Стройсервис', N'Соловьев Андрей Николаевич', N'ansolovev@st.ru', N'812 223 32 00', N'188910, Ленинградская область, город Приморск, ул. Парковая, 21', N'4440391035', 7)
INSERT [dbo].[Partners] ([PartnerId], [CompanyType], [CompanyName], [DirectorName], [Email], [Phone], [Address], [INN], [Rating]) VALUES (4, N'ОАО', N'Ремонт и отделка', N'Воробьева Екатерина Валерьевна', N'ekaterina.vorobeva@ml.ru', N'444 222 33 11', N'143960, Московская область, город Реутов, ул. Свободы, 51', N'1111520857', 5)
INSERT [dbo].[Partners] ([PartnerId], [CompanyType], [CompanyName], [DirectorName], [Email], [Phone], [Address], [INN], [Rating]) VALUES (5, N'ЗАО', N'МонтажПро', N'Степанов Степан Сергеевич', N'stepanov@stepan.ru', N'912 888 33 33', N'309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122', N'5552431140', 10)
SET IDENTITY_INSERT [dbo].[Partners] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductTypeId], [ProductName], [ArticleNumber], [MinCostForPartner]) VALUES (1, 3, N'Паркетная доска Ясень темный однополосная 14 мм', N'8758385', CAST(4456.90 AS Decimal(10, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductTypeId], [ProductName], [ArticleNumber], [MinCostForPartner]) VALUES (2, 3, N'Инженерная доска Дуб Французская елка однополосная 12 мм', N'8858958', CAST(7330.99 AS Decimal(10, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductTypeId], [ProductName], [ArticleNumber], [MinCostForPartner]) VALUES (3, 1, N'Ламинат Дуб дымчато-белый 33 класс 12 мм', N'7750282', CAST(1799.33 AS Decimal(10, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductTypeId], [ProductName], [ArticleNumber], [MinCostForPartner]) VALUES (4, 1, N'Ламинат Дуб серый 32 класс 8 мм с фаской', N'7028748', CAST(3890.41 AS Decimal(10, 2)))
INSERT [dbo].[Products] ([ProductId], [ProductTypeId], [ProductName], [ArticleNumber], [MinCostForPartner]) VALUES (5, 4, N'Пробковое напольное клеевое покрытие 32 класс 4 мм', N'5012543', CAST(5450.59 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 

INSERT [dbo].[ProductTypes] ([ProductTypeId], [TypeName], [TypeCoefficient]) VALUES (1, N'Ламинат', CAST(2.35 AS Decimal(10, 2)))
INSERT [dbo].[ProductTypes] ([ProductTypeId], [TypeName], [TypeCoefficient]) VALUES (2, N'Массивная доска', CAST(5.15 AS Decimal(10, 2)))
INSERT [dbo].[ProductTypes] ([ProductTypeId], [TypeName], [TypeCoefficient]) VALUES (3, N'Паркетная доска', CAST(4.34 AS Decimal(10, 2)))
INSERT [dbo].[ProductTypes] ([ProductTypeId], [TypeName], [TypeCoefficient]) VALUES (4, N'Пробковое покрытие', CAST(1.50 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([SaleId], [PartnerId], [ProductId], [Quantity], [SaleDate], [SalePrice]) VALUES (1, 1, 1, 15500, CAST(N'2023-03-23' AS Date), CAST(4456.90 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Login], [Password], [Role]) VALUES (1, N'admin', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Partners__C490CCF5EFEDECB4]    Script Date: 26.03.2025 12:11:42 ******/
ALTER TABLE [dbo].[Partners] ADD UNIQUE NONCLUSTERED 
(
	[INN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Products__3C991142F9FBBC7C]    Script Date: 26.03.2025 12:11:42 ******/
ALTER TABLE [dbo].[Products] ADD UNIQUE NONCLUSTERED 
(
	[ArticleNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__5E55825BFD88CFE1]    Script Date: 26.03.2025 12:11:42 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([ProductTypeId])
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([PartnerId])
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Partners]  WITH CHECK ADD CHECK  (([Rating]>=(0) AND [Rating]<=(10)))
GO
