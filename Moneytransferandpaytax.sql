USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[tbl_moneytransfer]    Script Date: 29/10/2020 12:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_moneytransfer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NULL,
	[TransactionNumber] [nvarchar](200) NULL,
	[TransactionName] [nvarchar](200) NULL,
	[Amount] [numeric](18, 3) NULL,
	[CurrencyType] [nvarchar](200) NULL,
	[TransferFrom] [nvarchar](200) NULL,
	[TransaferTo] [nvarchar](200) NULL,
	[Notes] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_moneytransfer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_paytaxes]    Script Date: 29/10/2020 12:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_paytaxes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PayTaxNumber] [nvarchar](50) NULL,
	[Date] [date] NULL,
	[AccountName] [nvarchar](200) NULL,
	[CurrencyTye] [nvarchar](200) NULL,
	[Amount] [numeric](18, 3) NULL,
	[DateFrom] [date] NULL,
	[DateTo] [date] NULL,
	[PayFrom] [nvarchar](200) NULL,
	[Notes] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_paytaxes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
