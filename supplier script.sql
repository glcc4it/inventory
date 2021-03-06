USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 15/10/2020 10:11:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [nvarchar](50) NULL,
	[Date] [date] NULL,
	[Name] [nvarchar](200) NULL,
	[AccountNature] [nvarchar](200) NULL,
	[CurrencyType] [nvarchar](200) NULL,
	[OpeningBalance] [numeric](18, 0) NULL,
	[OpeningBalanceType] [numeric](18, 0) NULL,
	[Address] [nvarchar](500) NULL,
	[EmailID] [nvarchar](200) NULL,
	[Mobileno] [nvarchar](200) NULL,
	[CreditLimit] [numeric](18, 0) NULL,
	[AccountName] [nvarchar](500) NULL,
	[Branch] [nvarchar](500) NULL,
	[AccountNumber] [nvarchar](500) NULL,
	[DefultTransaction] [nvarchar](500) NULL,
	[Pricinglevel] [nvarchar](500) NULL,
	[Status] [nvarchar](500) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
