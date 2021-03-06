USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[tbl_Transaction]    Script Date: 24/10/2020 6:03:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Transaction](
	[T_ID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[AccountID] [int] NULL,
	[PaymentMode] [nvarchar](50) NULL,
	[DiscountType] [nvarchar](50) NULL,
	[DiscountAmount] [decimal](18, 3) NULL,
	[CurrencyType] [nvarchar](50) NULL,
	[PaymentModeDetails] [varchar](max) NULL,
	[Oldbalance] [decimal](18, 3) NULL,
	[Amount] [decimal](18, 3) NULL,
	[Balanceamount] [decimal](18, 3) NULL,
	[Notes] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_Transaction] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
