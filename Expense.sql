USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[tbl_AddExpenses]    Script Date: 25/10/2020 6:49:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_AddExpenses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenseNumber] [nvarchar](50) NULL,
	[Date] [varchar](50) NULL,
	[InvoiceNumber] [numeric](18, 0) NULL,
	[ExpenseType] [nvarchar](200) NULL,
	[ExpensesName] [nvarchar](200) NULL,
	[CurrencyType] [nvarchar](200) NULL,
	[TransactionType] [nvarchar](200) NULL,
	[Amount] [numeric](18, 0) NULL,
	[Notes] [nvarchar](200) NULL,
	[PaymentMethods] [nvarchar](200) NULL,
	[TaxAmount] [numeric](18, 0) NULL,
	[TotalAmount] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tbl_AddExpenses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
