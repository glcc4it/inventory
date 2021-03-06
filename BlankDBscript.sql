USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[CustomerLedgerBook]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[InvoiceInfo1]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[LedgerBooks]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[Logs]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[Payment]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[PurchaseReturnmaster]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[PurchaseReturnProduct]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[SaleReturnmaster]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[SaleReturnProduct]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[ServicesLedgerBook]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[Supplier]    Script Date: 13/10/2020 1:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [nchar](10) NULL,
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
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SupplierLedgerBook]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_AccountMaster]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_category]    Script Date: 13/10/2020 1:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_category](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[Categoryname] [varchar](200) NULL,
	[Color] [varchar](max) NULL,
	[Status] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_company]    Script Date: 13/10/2020 1:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_company](
	[Busid] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](200) NULL,
	[Mailingname] [varchar](200) NULL,
	[Startwork] [varchar](50) NULL,
	[Accountyear] [varchar](50) NULL,
	[Addressline1] [varchar](max) NULL,
	[Addressline2] [varchar](200) NULL,
	[Addressline3] [varchar](200) NULL,
	[Contact] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Website] [varchar](200) NULL,
	[Vatno] [varchar](200) NULL,
	[Capitalaccount] [varchar](200) NULL,
	[Basecurrencey] [varchar](max) NULL,
	[Currencycode] [varchar](max) NULL,
	[Footernotes] [varchar](max) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_ww] PRIMARY KEY CLUSTERED 
(
	[Busid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Finaceyear]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_godown]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_login]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_pricinglevel]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_pur_product]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_purchase]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_rackmaster]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_repair_order]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_sale_pro]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_salemaster]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_salesman]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_stock_product]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_tax_master]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_Temp_pur_product]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_Temp_sale_product]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[tbl_unitmaster]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[Temp_Stock]    Script Date: 13/10/2020 1:06:43 PM ******/
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
/****** Object:  Table [dbo].[UserGrants]    Script Date: 13/10/2020 1:06:43 PM ******/
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
