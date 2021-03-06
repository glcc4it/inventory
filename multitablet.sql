USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[tbl_AddBank]    Script Date: 29/10/2020 12:01:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_AddBank](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BankNo] [nvarchar](50) NULL,
	[Date] [varchar](50) NULL,
	[AccountType] [nvarchar](200) NULL,
	[CurrencyType] [nvarchar](200) NULL,
	[BankName] [nvarchar](200) NULL,
	[BranchName] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[Status] [nvarchar](50) NULL,
	[Balance] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tbl_AddBank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_AddRevenue]    Script Date: 29/10/2020 12:01:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AddRevenue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RevenueNumber] [numeric](18, 0) NULL,
	[RevenueNumber2] [numeric](18, 0) NULL,
	[Date] [nvarchar](50) NULL,
	[CurrencyType] [nvarchar](200) NULL,
	[RevenueName] [nvarchar](200) NULL,
	[TotalBeforeTax] [numeric](18, 0) NULL,
	[Amount] [numeric](18, 0) NULL,
	[PaymentMethods] [nvarchar](200) NULL,
	[Taxes] [numeric](18, 0) NULL,
	[Total] [numeric](18, 0) NULL,
	[Notes] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_AddRevenue] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_AddTreasury]    Script Date: 29/10/2020 12:01:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_AddTreasury](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TreasuryNumber] [int] NULL,
	[Date] [varchar](50) NULL,
	[TreasuryName] [nvarchar](200) NULL,
	[AccountType] [nvarchar](200) NULL,
	[CurrencyType] [nvarchar](200) NULL,
	[Notes] [nvarchar](500) NULL,
	[Status] [nvarchar](50) NULL,
	[Balance] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tbl_AddTreasury] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_AddWallet]    Script Date: 29/10/2020 12:01:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_AddWallet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WelletNumber] [int] NULL,
	[Date] [varchar](50) NULL,
	[AccountType] [nvarchar](200) NULL,
	[CurrencyType] [nvarchar](200) NULL,
	[WalletName] [nvarchar](200) NULL,
	[OpeningBalance] [numeric](18, 0) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_AddWallet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
