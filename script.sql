USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[tblItemMaster]    Script Date: 28/10/2020 11:50:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblItemMaster](
	[ID] [numeric](18, 0) NOT NULL,
	[Barcode1] [nvarchar](50) NULL,
	[Barcode2] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[StoreType] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[BrandName] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[NameArabic] [nvarchar](50) NULL,
	[NameEng] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[QtyPerUnit] [numeric](18, 0) NULL,
	[CompanyProduct] [nvarchar](50) NULL,
	[TaxPercentage] [decimal](18, 3) NULL,
	[TaxAmount] [nchar](10) NULL,
	[DiscountType] [nvarchar](50) NULL,
	[DiscountAmount] [nvarchar](50) NULL,
	[DirectDiscount] [decimal](18, 2) NULL,
	[NextShoppingDiscount] [decimal](18, 2) NULL,
	[VenderPreferred] [nvarchar](50) NULL,
	[ReorderLevel] [numeric](18, 0) NULL,
	[ManufacturingDate] [date] NULL,
	[ExpireDate] [date] NULL,
	[PurchaseCurrency] [nvarchar](50) NULL,
	[SellingCurrency] [nvarchar](50) NULL,
	[PurchasePrice] [decimal](18, 2) NULL,
	[WholeSalePrice] [decimal](18, 2) NULL,
	[RetailPrice] [decimal](18, 2) NULL,
	[CustomerPrice] [decimal](18, 2) NULL,
	[Location] [nvarchar](50) NULL,
	[AddProfit] [decimal](18, 2) NULL,
	[OpeningStock] [numeric](18, 0) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblItemMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
