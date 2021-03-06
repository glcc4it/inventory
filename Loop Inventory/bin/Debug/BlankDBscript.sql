USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nchar](10) NULL,
	[Date] [varchar](50) NULL,
	[Name] [varchar](500) NULL,
	[OpeningBalance] [int] NULL,
	[OpeningBalanceType] [varchar](200) NULL,
	[Address] [varchar](max) NULL,
	[EmailID] [varchar](200) NULL,
	[Phoneno] [varchar](100) NULL,
	[Mobileno] [varchar](50) NULL,
	[Creditperiod] [int] NULL,
	[AccountName] [varchar](500) NULL,
	[Branch] [varchar](500) NULL,
	[AccountNumber] [nchar](150) NULL,
	[Remarks] [varchar](max) NULL,
	[Pricinglevel] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerLedgerBook]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerLedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[LedgerNo] [varchar](50) NULL,
	[Label] [varchar](50) NULL,
	[Debit] [int] NULL,
	[Credit] [int] NULL,
	[Mobileno] [varchar](50) NULL,
 CONSTRAINT [PK_CustomerLedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceInfo1]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InvoiceInfo1](
	[T_ID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [nchar](10) NULL,
	[Date] [varchar](50) NULL,
	[AccountID] [int] NULL,
	[AccountName] [varchar](200) NULL,
	[Mobile] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Outdate] [varchar](50) NULL,
	[PaymentMode] [varchar](50) NULL,
	[Oldbalance] [int] NULL,
	[Amount] [int] NULL,
	[Balance] [int] NULL,
	[Remarks] [varchar](200) NULL,
 CONSTRAINT [PK_InvoiceInfo1] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LedgerBooks]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LedgerBooks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [varchar](50) NULL,
	[Name] [varchar](200) NULL,
	[LedgerNo] [varchar](200) NULL,
	[Label] [varchar](200) NULL,
	[Debit] [int] NULL,
	[Credit] [int] NULL,
	[Mobileno] [varchar](50) NULL,
 CONSTRAINT [PK_LedgerBooks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](100) NULL,
	[Operation] [nvarchar](max) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payment](
	[T_ID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [nchar](10) NULL,
	[Date] [varchar](50) NULL,
	[PaymentMode] [varchar](500) NULL,
	[AccountID] [int] NULL,
	[Oldbalance] [int] NULL,
	[Amount] [int] NULL,
	[Balanceamount] [int] NULL,
	[PaymentModeDetails] [varchar](max) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseReturnmaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseReturnmaster](
	[PR_ID] [int] IDENTITY(1,1) NOT NULL,
	[PRNo] [int] NULL,
	[Date] [varchar](50) NULL,
	[Purchasetype] [varchar](200) NOT NULL,
	[PurchaseID] [int] NULL,
	[Suppliername] [varchar](200) NULL,
	[Mobileno] [varchar](50) NULL,
	[Purchaseinvoice] [int] NULL,
	[Grandtotal] [int] NULL,
	[Discount] [int] NULL,
	[Discountamount] [int] NULL,
	[Tax] [int] NULL,
	[Taxamount] [int] NULL,
	[Netamount] [int] NULL,
	[Oldbalance] [int] NULL,
	[Newbalance] [int] NULL,
	[Suppliernotes] [varchar](200) NULL,
 CONSTRAINT [PK_PurchaseReturnmaster] PRIMARY KEY CLUSTERED 
(
	[PR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseReturnProduct]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseReturnProduct](
	[PRJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseReturnID] [int] NULL,
	[Returnno] [int] NULL,
	[Date] [varchar](50) NULL,
	[Purchaseinvoice] [int] NULL,
	[Suppliername] [varchar](200) NULL,
	[Mobileno] [varchar](50) NULL,
	[Productname] [varchar](200) NULL,
	[Typeofunit] [varchar](200) NULL,
	[Purchaseprice] [int] NULL,
	[PurQty] [int] NULL,
	[Purchasetotal] [int] NULL,
	[ReturnQty] [int] NULL,
	[Returntotal] [int] NULL,
	[Grandtotal] [int] NULL,
 CONSTRAINT [PK_PurchaseReturnProduct] PRIMARY KEY CLUSTERED 
(
	[PRJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaleReturnmaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaleReturnmaster](
	[SR_ID] [int] IDENTITY(1,1) NOT NULL,
	[SRNo] [int] NULL,
	[Date] [varchar](50) NULL,
	[Saletype] [varchar](200) NULL,
	[SalesID] [int] NULL,
	[Customername] [varchar](200) NULL,
	[Mobileno] [varchar](200) NULL,
	[Saleinvoice] [int] NULL,
	[Grandtotal] [int] NULL,
	[Discount] [int] NULL,
	[Discountamount] [int] NULL,
	[Tax] [int] NULL,
	[Taxamount] [int] NULL,
	[Netamount] [int] NULL,
	[Oldbalance] [int] NULL,
	[Newbalance] [int] NULL,
	[Customernotes] [varchar](200) NULL,
 CONSTRAINT [PK_SaleReturnmaster] PRIMARY KEY CLUSTERED 
(
	[SR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaleReturnProduct]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaleReturnProduct](
	[SRJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[SalesReturnID] [int] NULL,
	[Returnno] [int] NULL,
	[Date] [varchar](50) NULL,
	[Saleinvoice] [int] NULL,
	[Customername] [varchar](200) NULL,
	[Mobileno] [varchar](200) NULL,
	[Productname] [varchar](200) NULL,
	[Typeofunit] [varchar](200) NULL,
	[Saleprice] [int] NULL,
	[SaleQty] [int] NULL,
	[Saletotal] [int] NULL,
	[ReturnQty] [int] NULL,
	[Returntotal] [int] NULL,
	[Grandtotal] [int] NULL,
 CONSTRAINT [PK_SaleReturnProduct] PRIMARY KEY CLUSTERED 
(
	[SRJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServicesLedgerBook]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServicesLedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[LedgerNo] [varchar](50) NULL,
	[Label] [varchar](50) NULL,
	[Debit] [int] NULL,
	[Credit] [int] NULL,
	[Mobileno] [varchar](50) NULL,
 CONSTRAINT [PK_ServicesLedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 15/10/2020 11:43:56 PM ******/
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
	[OpeningBalance] [nvarchar](200) NULL,
	[OpeningBalanceType] [nvarchar](200) NULL,
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
/****** Object:  Table [dbo].[SupplierLedgerBook]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupplierLedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[LedgerNo] [varchar](50) NULL,
	[Label] [varchar](50) NULL,
	[Debit] [int] NULL,
	[Credit] [int] NULL,
	[Mobileno] [varchar](50) NULL,
 CONSTRAINT [PK_SupplierLedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_AccountMaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_AccountMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [varchar](300) NULL,
	[Date] [varchar](50) NULL,
	[Accounttype] [varchar](300) NULL,
	[AccountName] [varchar](300) NULL,
	[SubAccountof] [varchar](300) NULL,
	[AccountRules] [varchar](500) NULL,
	[AccountCurrency] [varchar](300) NULL,
	[Notes] [varchar](300) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_AccountMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_AddBank]    Script Date: 15/10/2020 11:43:56 PM ******/
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
/****** Object:  Table [dbo].[tbl_AddExpenses]    Script Date: 15/10/2020 11:43:56 PM ******/
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
/****** Object:  Table [dbo].[tbl_AddRevenue]    Script Date: 15/10/2020 11:43:56 PM ******/
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
/****** Object:  Table [dbo].[tbl_AddTreasury]    Script Date: 15/10/2020 11:43:56 PM ******/
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
/****** Object:  Table [dbo].[tbl_AddWallet]    Script Date: 15/10/2020 11:43:56 PM ******/
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
/****** Object:  Table [dbo].[tbl_BrandMaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_BrandMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](200) NULL,
	[Manufacturer] [nvarchar](200) NULL,
	[Status] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_BrandMaster] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Categoryname] [nvarchar](200) NULL,
	[Color] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_company]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_company](
	[Busid] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](200) NULL,
	[Mailingname] [nvarchar](200) NULL,
	[Startwork] [date] NULL,
	[Accountyear] [date] NULL,
	[Addressline1] [nvarchar](500) NULL,
	[Addressline2] [nvarchar](500) NULL,
	[Addressline3] [nvarchar](500) NULL,
	[Contact] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[Website] [nvarchar](200) NULL,
	[Vatno] [nvarchar](200) NULL,
	[Capitalaccount] [nchar](10) NULL,
	[Basecurrencey] [nvarchar](200) NULL,
	[Currencycode] [nvarchar](200) NULL,
	[Footernotes] [nvarchar](500) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_tbl_company] PRIMARY KEY CLUSTERED 
(
	[Busid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Currency]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Currency](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[value] [decimal](18, 3) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Currency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ExpenseMaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ExpenseMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenseType] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Notes] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_ExpenseMaster] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Finaceyear]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Finaceyear](
	[Financeid] [int] IDENTITY(1,1) NOT NULL,
	[Fromdate] [varchar](50) NULL,
	[Todate] [varchar](50) NULL,
	[Finaceyearname] [varchar](400) NULL,
 CONSTRAINT [PK_tbl_Finaceyear] PRIMARY KEY CLUSTERED 
(
	[Financeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_godown]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_godown](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[godownname] [varchar](200) NULL,
	[date] [varchar](50) NULL,
	[narration] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_godown] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_login]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_login](
	[UserID] [nchar](10) NOT NULL,
	[UserType] [varchar](200) NULL,
	[Name] [varchar](200) NULL,
	[Password] [nvarchar](500) NULL,
	[Address] [varchar](500) NULL,
	[Email] [varchar](200) NULL,
	[Mobile] [varchar](200) NULL,
	[JoiningDate] [date] NULL,
	[Active] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_login] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_pricinglevel]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_pricinglevel](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[Pricingname] [varchar](200) NULL,
	[Date] [varchar](50) NULL,
	[narration] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_pricinglevel] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_pur_product]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_pur_product](
	[SP_ID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NULL,
	[Productcode] [nchar](10) NULL,
	[Barcode] [int] NULL,
	[Invoiceno] [nchar](10) NULL,
	[Date] [varchar](50) NULL,
	[Suppliername] [varchar](200) NULL,
	[Productname] [varchar](200) NULL,
	[Typeofunit] [varchar](200) NULL,
	[Description] [varchar](500) NULL,
	[Purchaseprice] [int] NULL,
	[Qty] [int] NULL,
	[Total] [int] NULL,
	[Mfd] [varchar](50) NULL,
	[Expdate] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_pur_product] PRIMARY KEY CLUSTERED 
(
	[SP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_purchase]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_purchase](
	[ST_ID] [int] NOT NULL,
	[Invoiceno] [nchar](10) NOT NULL,
	[Invoicedate] [varchar](50) NULL,
	[Venderinvoice] [int] NULL,
	[Venderinvoicedate] [varchar](50) NULL,
	[PurchaseType] [varchar](50) NULL,
	[SupplierID] [int] NULL,
	[Suppliercode] [nchar](10) NULL,
	[Suppliername] [varchar](200) NULL,
	[Grandtotal] [int] NULL,
	[Discount] [int] NULL,
	[Discountvalue] [int] NULL,
	[Tax] [int] NULL,
	[Taxvalue] [int] NULL,
	[Netamount] [int] NULL,
	[Oldbalance] [int] NULL,
	[Newbalance] [int] NULL,
	[Paidamount] [int] NULL,
	[Duesamount] [int] NULL,
	[Comments] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_purchase] PRIMARY KEY CLUSTERED 
(
	[ST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_rackmaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_rackmaster](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[rackname] [varchar](200) NULL,
	[godown] [varchar](200) NULL,
	[narration] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_rackmaster] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_repair_order]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_repair_order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Servicesid] [nchar](10) NOT NULL,
	[Job_no] [int] NOT NULL,
	[Invoicedate] [varchar](50) NOT NULL,
	[cus_name] [varchar](200) NOT NULL,
	[cus_number] [varchar](50) NOT NULL,
	[Mobile_brand] [varchar](100) NOT NULL,
	[Mobile_model] [varchar](100) NOT NULL,
	[Mobile_fault] [varchar](50) NOT NULL,
	[Other_fault] [varchar](50) NOT NULL,
	[worker] [varchar](50) NOT NULL,
	[Estimate] [varchar](50) NOT NULL,
	[mobile_acccess] [nvarchar](50) NOT NULL,
	[Reciveid_by] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Market] [varchar](50) NOT NULL,
	[Out_date] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[Total_payment] [int] NOT NULL,
	[Advance] [int] NOT NULL,
	[Balance] [int] NOT NULL,
 CONSTRAINT [PK_tbl_repair_order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sale_pro]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sale_pro](
	[IPo_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[Productcode] [nchar](10) NULL,
	[Barcode] [nchar](10) NULL,
	[Invoiceno] [int] NOT NULL,
	[Date] [date] NULL,
	[Customer] [varchar](200) NULL,
	[Productname] [varchar](200) NULL,
	[Price] [int] NULL,
	[Qty] [int] NULL,
	[Typeofunit] [varchar](200) NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK_tbl_sale_pro] PRIMARY KEY CLUSTERED 
(
	[IPo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_salemaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_salemaster](
	[Inv_ID] [int] NOT NULL,
	[Invoiceno] [int] NULL,
	[Date] [date] NULL,
	[Salesman] [varchar](200) NULL,
	[Saletype] [varchar](500) NULL,
	[CustomerID] [int] NULL,
	[Customer] [varchar](400) NULL,
	[Grandtotal] [int] NULL,
	[Discount] [int] NULL,
	[Discountvalue] [int] NULL,
	[Tax] [int] NULL,
	[Taxvalue] [int] NULL,
	[Netamount] [int] NULL,
	[Oldbalance] [int] NULL,
	[Newbalance] [int] NULL,
	[Receivedamount] [int] NULL,
	[Balance] [int] NULL,
	[Comments] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_salemaster] PRIMARY KEY CLUSTERED 
(
	[Inv_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_salesman]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_salesman](
	[Salesmancode] [int] IDENTITY(1,1) NOT NULL,
	[Date] [varchar](200) NULL,
	[Salesmanname] [varchar](200) NULL,
	[Address] [varchar](500) NULL,
	[City] [varchar](200) NULL,
	[Email] [varchar](200) NULL,
	[Mobile] [varchar](200) NULL,
	[CNIC] [varchar](200) NULL,
	[Narration] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_salesman] PRIMARY KEY CLUSTERED 
(
	[Salesmancode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_stock_product]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_stock_product](
	[Productcode] [nchar](10) NOT NULL,
	[Barcodeno] [int] NULL,
	[Category] [varchar](200) NULL,
	[Product] [varchar](200) NULL,
	[Typeofunit] [varchar](200) NULL,
	[Description] [varchar](500) NULL,
	[Rackno] [varchar](200) NULL,
	[Godown] [varchar](200) NULL,
	[Purchaseprice] [int] NULL,
	[Saleprice] [int] NULL,
	[Quantity] [int] NULL,
	[Total] [int] NULL,
	[Stockdate] [varchar](200) NULL,
	[Mfd] [varchar](200) NULL,
	[Expdate] [varchar](200) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_tbl_stock_product] PRIMARY KEY CLUSTERED 
(
	[Productcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Tax]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Tax](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[value] [decimal](18, 3) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Tax] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_tax_master]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_tax_master](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[Taxname] [varchar](200) NULL,
	[Taxpercent] [varchar](max) NULL,
	[Status] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_tax_master] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Temp_pur_product]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Temp_pur_product](
	[SP_ID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NULL,
	[Productcode] [nchar](10) NULL,
	[Barcode] [int] NULL,
	[Invoiceno] [nchar](10) NULL,
	[Date] [varchar](50) NULL,
	[Suppliername] [varchar](200) NULL,
	[Productname] [varchar](200) NULL,
	[Typeofunit] [varchar](200) NULL,
	[Description] [varchar](500) NULL,
	[Purchaseprice] [int] NULL,
	[Qty] [int] NULL,
	[Total] [int] NULL,
	[Mfd] [varchar](50) NULL,
	[Expdate] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Temp_pur_product] PRIMARY KEY CLUSTERED 
(
	[SP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Temp_sale_product]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Temp_sale_product](
	[IPo_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[Productcode] [nchar](10) NULL,
	[Barcode] [nchar](10) NULL,
	[Invoiceno] [int] NOT NULL,
	[Date] [date] NULL,
	[Customer] [varchar](200) NULL,
	[Productname] [varchar](200) NULL,
	[Price] [int] NULL,
	[Qty] [int] NULL,
	[Typeofunit] [varchar](200) NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK_tbl_Temp_sale_product] PRIMARY KEY CLUSTERED 
(
	[IPo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_unitmaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_unitmaster](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[Date] [varchar](50) NULL,
	[Unit_type] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_unitmaster] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_VenderPayment]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_VenderPayment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[VenderCode] [int] NULL,
	[Date] [varchar](50) NULL,
	[VenderName] [varchar](200) NULL,
	[Amount] [int] NULL,
	[DiscountType] [varchar](200) NULL,
	[CurrencyType] [varchar](200) NULL,
	[PaymentFrom] [varchar](200) NULL,
	[TotalAmountAfterDiscount] [int] NULL,
	[Notes] [varchar](300) NULL,
 CONSTRAINT [PK_tbl_VenderPayment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBonusQuantity]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBonusQuantity](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[ItemName] [nvarchar](50) NULL,
	[TypeOfUnit] [nvarchar](50) NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[OfferQuantity] [numeric](18, 0) NULL,
	[Bonus] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tblBonusQuantity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblItemMaster]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblItemMaster](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Barcode1] [nvarchar](50) NULL,
	[Barcode2] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[NameArabic] [nvarchar](50) NULL,
	[NameEng] [nvarchar](50) NULL,
	[StoreType] [nvarchar](50) NULL,
	[BrandName] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[QtyPerUnit] [numeric](18, 0) NULL,
	[Company] [nvarchar](50) NULL,
	[Vender] [nvarchar](50) NULL,
	[DiscountType] [nvarchar](50) NULL,
	[DirectDiscount] [decimal](18, 2) NULL,
	[NextShoppingDiscount] [decimal](18, 2) NULL,
	[TaxPercent] [decimal](18, 2) NULL,
	[ReorderLevel] [numeric](18, 0) NULL,
	[ManufacturingDate] [date] NULL,
	[ExpireDate] [date] NULL,
	[PurchaseCurrency] [nvarchar](50) NULL,
	[SellingCurrency] [nvarchar](50) NULL,
	[WholeSalePrice] [decimal](18, 2) NULL,
	[PurchasePrice] [decimal](18, 2) NULL,
	[CustomPrice] [decimal](18, 2) NULL,
	[RetailPrice] [decimal](18, 2) NULL,
	[CustomerPrice] [decimal](18, 2) NULL,
	[AddProfit] [decimal](18, 2) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblItemMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblStore]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStore](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[DateCreated] [date] NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[EmailAddress] [nvarchar](500) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblStore] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Temp_Stock]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Temp_Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Productcode] [nchar](10) NOT NULL,
	[Barcodeno] [nvarchar](50) NULL,
	[Category] [varchar](200) NULL,
	[Product] [varchar](200) NULL,
	[Typeofunit] [varchar](200) NULL,
	[Description] [varchar](500) NULL,
	[Rackno] [varchar](200) NULL,
	[Godown] [varchar](200) NULL,
	[Purchaseprice] [int] NULL,
	[Saleprice] [int] NULL,
	[Quantity] [int] NULL,
	[Stockdate] [varchar](200) NULL,
	[Mfd] [varchar](200) NULL,
	[Expdate] [varchar](200) NULL,
 CONSTRAINT [PK_Temp_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGrants]    Script Date: 15/10/2020 11:43:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGrants](
	[Forms] [varchar](500) NULL,
	[ViewRecord] [nchar](10) NULL,
	[Saves] [nchar](10) NULL,
	[Updates] [nchar](10) NULL,
	[Deletes] [nchar](10) NULL,
	[Getdata] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
