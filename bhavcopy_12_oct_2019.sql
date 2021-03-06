USE [master]
GO
/****** Object:  Database [bhavcopy]    Script Date: 10/12/2019 12:24:01 PM ******/
CREATE DATABASE [bhavcopy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bhavcopy_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bhavcopy_Data.mdf' , SIZE = 3729984KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%), 
 FILEGROUP [memory_optimized_filegroup_0] CONTAINS MEMORY_OPTIMIZED_DATA  DEFAULT
( NAME = N'memory_optimized_file_87452209', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\memory_optimized_file_87452209' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'bhavcopy_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bhavcopy_Log.ldf' , SIZE = 6343680KB , MAXSIZE = 2048GB , FILEGROWTH = 1024KB )
GO
ALTER DATABASE [bhavcopy] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bhavcopy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bhavcopy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bhavcopy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bhavcopy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bhavcopy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bhavcopy] SET ARITHABORT OFF 
GO
ALTER DATABASE [bhavcopy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bhavcopy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bhavcopy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bhavcopy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bhavcopy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bhavcopy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bhavcopy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bhavcopy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bhavcopy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bhavcopy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bhavcopy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bhavcopy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bhavcopy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bhavcopy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bhavcopy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bhavcopy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bhavcopy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bhavcopy] SET RECOVERY FULL 
GO
ALTER DATABASE [bhavcopy] SET  MULTI_USER 
GO
ALTER DATABASE [bhavcopy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bhavcopy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bhavcopy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bhavcopy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bhavcopy] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'bhavcopy', N'ON'
GO
ALTER DATABASE [bhavcopy] SET QUERY_STORE = OFF
GO
USE [bhavcopy]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [bhavcopy]
GO
/****** Object:  Table [dbo].[betaStocks]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[betaStocks](
	[Symbol] [nvarchar](1000) NULL,
	[Series] [smalldatetime] NULL,
	[prev_close] [decimal](18, 2) NULL,
	[open_price] [decimal](18, 2) NULL,
	[high_price] [decimal](18, 2) NULL,
	[low_price] [decimal](18, 2) NULL,
	[last_price] [decimal](18, 2) NULL,
	[close_price] [decimal](18, 2) NULL,
	[vwap] [decimal](18, 2) NULL,
	[total_traded_qty] [decimal](18, 2) NULL,
	[turnover] [decimal](18, 2) NULL,
	[no_of_trades] [decimal](18, 2) NULL,
	[delivery_qty] [decimal](18, 2) NULL,
	[per_del_qty_to_traded_qty] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bhavcopy]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bhavcopy](
	[SYMBOL] [varchar](1000) NULL,
	[SERIES] [nvarchar](50) NULL,
	[OPEN] [decimal](18, 4) NULL,
	[HIGH] [decimal](18, 4) NULL,
	[LOW] [decimal](18, 4) NULL,
	[CLOSE] [decimal](18, 4) NULL,
	[LAST] [decimal](18, 4) NULL,
	[PREVCLOSE] [decimal](18, 4) NULL,
	[TOTTRDQTY] [decimal](18, 4) NULL,
	[TOTTRDVAL] [decimal](18, 4) NULL,
	[TIMESTAMP] [smalldatetime] NULL,
	[TOTALTRADES] [int] NULL,
	[ISIN] [nvarchar](1000) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CMVOLT]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMVOLT](
	[TIMESTAMP] [smalldatetime] NULL,
	[Symbol] [nvarchar](1000) NULL,
	[Underlying_Close_Price] [decimal](18, 4) NULL,
	[Underlying_Previous_Day_Close_Price] [decimal](18, 4) NULL,
	[Underlying_Log_Returns] [decimal](18, 4) NULL,
	[Previous_Day_Underlying_Volatility] [decimal](18, 4) NULL,
	[Current_Day_Underlying_Daily_Volatility] [decimal](18, 4) NULL,
	[Underlying_Annualised_Volatility] [decimal](18, 4) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Delivery_Position]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Position](
	[Record_Type] [int] NULL,
	[Sr_No] [int] NULL,
	[Name_of_Security] [nvarchar](1000) NULL,
	[series] [nvarchar](200) NULL,
	[Quantity_Traded] [int] NULL,
	[del_quantity_gross] [int] NULL,
	[percent_delivery] [int] NULL,
	[TIMESTAMP] [smalldatetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[equities_stock_watch]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equities_stock_watch](
	[stock_date] [date] NULL,
	[symbol] [nvarchar](1000) NULL,
	[open_val] [decimal](18, 2) NULL,
	[high_val] [decimal](18, 2) NULL,
	[low_val] [decimal](18, 2) NULL,
	[ltp] [decimal](18, 2) NULL,
	[chg] [decimal](18, 2) NULL,
	[percentage_chg] [decimal](18, 2) NULL,
	[volume] [decimal](18, 2) NULL,
	[turnover] [decimal](18, 2) NULL,
	[week_52_H] [decimal](18, 2) NULL,
	[week_52_L] [decimal](18, 2) NULL,
	[day_365_chg] [decimal](18, 2) NULL,
	[day_30_chg] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fao_participant_oi]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fao_participant_oi](
	[Client_Type] [nvarchar](1000) NULL,
	[Future_Index_Long] [int] NULL,
	[Future_Index_Short] [int] NULL,
	[Future_Stock_Long] [int] NULL,
	[Future_Stock_Short] [int] NULL,
	[Option_Index_Call_Long] [int] NULL,
	[Option_Index_Put_Long] [int] NULL,
	[Option_Index_Call_Short] [int] NULL,
	[Option_Index_Put_Short] [int] NULL,
	[Option_Stock_Call_Long] [int] NULL,
	[Option_Stock_Put_Long] [int] NULL,
	[Option_Stock_Call_Short] [int] NULL,
	[Option_Stock_Put_Short] [int] NULL,
	[Total_Long_Contracts] [int] NULL,
	[Total_Short_Contracts] [int] NULL,
	[timestamp] [smalldatetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fo_bhavcopy]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fo_bhavcopy](
	[INSTRUMENT] [nvarchar](1000) NULL,
	[SYMBOL] [nvarchar](100) NULL,
	[EXPIRY_DT] [smalldatetime] NULL,
	[STRIKE_PR] [decimal](18, 4) NULL,
	[OPTION_TYP] [varchar](100) NULL,
	[OPEN] [decimal](18, 4) NULL,
	[HIGH] [decimal](18, 4) NULL,
	[LOW] [decimal](18, 4) NULL,
	[CLOSE] [decimal](18, 4) NULL,
	[SETTLE_PR] [decimal](18, 4) NULL,
	[CONTRACTS] [int] NULL,
	[VAL_INLAKH] [decimal](18, 4) NULL,
	[OPEN_INT] [int] NULL,
	[CHG_IN_OI] [int] NULL,
	[TIMESTAMP] [smalldatetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [fo_bhavcopy_i1]    Script Date: 10/12/2019 12:24:02 PM ******/
CREATE CLUSTERED INDEX [fo_bhavcopy_i1] ON [dbo].[fo_bhavcopy]
(
	[TIMESTAMP] ASC,
	[INSTRUMENT] ASC,
	[SYMBOL] ASC,
	[EXPIRY_DT] ASC,
	[STRIKE_PR] ASC,
	[OPTION_TYP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FPI_Derivative_Daily]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FPI_Derivative_Daily](
	[Reporting_Date] [date] NULL,
	[Derivative_Products] [varchar](100) NULL,
	[buy_no_of_contracts] [decimal](18, 2) NULL,
	[buy_amt_cr] [decimal](18, 2) NULL,
	[sell_no_of_contracts] [decimal](18, 2) NULL,
	[sell_amt_cr] [decimal](18, 2) NULL,
	[oi_no_contracts] [decimal](18, 2) NULL,
	[oi_amt_cr] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FPI_Investments_Daily]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FPI_Investments_Daily](
	[Reporting_Date] [date] NULL,
	[Debt_Equity_Hybrid] [nvarchar](100) NULL,
	[Investment_Route] [nvarchar](100) NULL,
	[Gross_Purchases] [decimal](18, 2) NULL,
	[Gross_Sales] [decimal](18, 2) NULL,
	[Net_Investment_Cr] [decimal](18, 2) NULL,
	[Net_Investment_USD] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[holiday_list]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[holiday_list](
	[holiday_date] [smalldatetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[index_close]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[index_close](
	[index_name] [varchar](1000) NULL,
	[index_date] [smalldatetime] NULL,
	[open_index_value] [decimal](18, 2) NULL,
	[high_index_value] [decimal](18, 2) NULL,
	[low_index_value] [decimal](18, 2) NULL,
	[closing_index_value] [decimal](18, 2) NULL,
	[points_change] [decimal](18, 2) NULL,
	[change_per] [decimal](18, 2) NULL,
	[volume] [decimal](18, 2) NULL,
	[turnover] [decimal](18, 2) NULL,
	[P_E] [decimal](18, 2) NULL,
	[P_B] [decimal](18, 2) NULL,
	[div_yeild] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nifty_stock]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nifty_stock](
	[stock_name] [varchar](1000) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[optionchain]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[optionchain](
	[optiondate] [date] NULL,
	[option_name] [varchar](1000) NULL,
	[expiery_date] [date] NULL,
	[call_oi] [decimal](18, 2) NULL,
	[call_change_in_oi] [decimal](18, 2) NULL,
	[call_volume] [decimal](18, 2) NULL,
	[call_iv] [decimal](18, 2) NULL,
	[call_LTP] [decimal](18, 2) NULL,
	[call_net_change] [decimal](18, 2) NULL,
	[call_bid_qty] [decimal](18, 2) NULL,
	[call_bid_price] [decimal](18, 2) NULL,
	[call_ask_price] [decimal](18, 2) NULL,
	[call_ask_qty] [decimal](18, 2) NOT NULL,
	[strike_price] [decimal](18, 2) NULL,
	[put_bid_qty] [decimal](18, 2) NULL,
	[put_bid_price] [decimal](18, 2) NULL,
	[put_ask_price] [decimal](18, 2) NULL,
	[put_ask_qty] [decimal](18, 2) NULL,
	[put_net_change] [decimal](18, 2) NULL,
	[put_LTP] [decimal](18, 2) NULL,
	[put_iv] [decimal](18, 2) NULL,
	[put_volume] [decimal](18, 2) NULL,
	[put_change_in_oi] [decimal](18, 2) NULL,
	[put_oi] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [i1]    Script Date: 10/12/2019 12:24:02 PM ******/
CREATE CLUSTERED INDEX [i1] ON [dbo].[optionchain]
(
	[optiondate] ASC,
	[option_name] ASC,
	[expiery_date] ASC,
	[strike_price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[optionchain_closing]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[optionchain_closing](
	[optiondate] [date] NULL,
	[option_name] [varchar](1000) NULL,
	[expiery_date] [smalldatetime] NULL,
	[call_oi] [decimal](18, 2) NULL,
	[call_change_in_oi] [decimal](18, 2) NULL,
	[call_volume] [decimal](18, 2) NULL,
	[call_iv] [decimal](18, 2) NULL,
	[call_LTP] [decimal](18, 2) NULL,
	[call_net_change] [decimal](18, 2) NULL,
	[call_bid_qty] [decimal](18, 2) NULL,
	[call_bid_price] [decimal](18, 2) NULL,
	[call_ask_price] [decimal](18, 2) NULL,
	[call_ask_qty] [decimal](18, 2) NOT NULL,
	[strike_price] [decimal](18, 2) NULL,
	[put_bid_qty] [decimal](18, 2) NULL,
	[put_bid_price] [decimal](18, 2) NULL,
	[put_ask_price] [decimal](18, 2) NULL,
	[put_ask_qty] [decimal](18, 2) NULL,
	[put_net_change] [decimal](18, 2) NULL,
	[put_LTP] [decimal](18, 2) NULL,
	[put_iv] [decimal](18, 2) NULL,
	[put_volume] [decimal](18, 2) NULL,
	[put_change_in_oi] [decimal](18, 2) NULL,
	[put_oi] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[optionchain5Min]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[optionchain5Min](
	[optiondate] [smalldatetime] NULL,
	[option_name] [varchar](1000) NULL,
	[expiery_date] [smalldatetime] NULL,
	[call_oi] [decimal](18, 2) NULL,
	[call_change_in_oi] [decimal](18, 2) NULL,
	[call_volume] [decimal](18, 2) NULL,
	[call_iv] [decimal](18, 2) NULL,
	[call_LTP] [decimal](18, 2) NULL,
	[call_net_change] [decimal](18, 2) NULL,
	[call_bid_qty] [decimal](18, 2) NULL,
	[call_bid_price] [decimal](18, 2) NULL,
	[call_ask_price] [decimal](18, 2) NULL,
	[call_ask_qty] [decimal](18, 2) NOT NULL,
	[strike_price] [decimal](18, 2) NULL,
	[put_bid_qty] [decimal](18, 2) NULL,
	[put_bid_price] [decimal](18, 2) NULL,
	[put_ask_price] [decimal](18, 2) NULL,
	[put_ask_qty] [decimal](18, 2) NULL,
	[put_net_change] [decimal](18, 2) NULL,
	[put_LTP] [decimal](18, 2) NULL,
	[put_iv] [decimal](18, 2) NULL,
	[put_volume] [decimal](18, 2) NULL,
	[put_change_in_oi] [decimal](18, 2) NULL,
	[put_oi] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Participant_wise_Open_Interest]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant_wise_Open_Interest](
	[trading_date] [date] NULL,
	[Client_Type] [nvarchar](1000) NULL,
	[Future_Index_Long] [decimal](18, 2) NULL,
	[Future_Index_Short] [decimal](18, 2) NULL,
	[Future_Stock_Long] [decimal](18, 2) NULL,
	[Future_Stock_Short] [decimal](18, 2) NULL,
	[Option_Index_Call_Long] [decimal](18, 2) NULL,
	[Option_Index_Put_Long] [decimal](18, 2) NULL,
	[Option_Index_Call_Short] [decimal](18, 2) NULL,
	[Option_Index_Put_Short] [decimal](18, 2) NULL,
	[Option_Stock_Call_Long] [decimal](18, 2) NULL,
	[Option_Stock_Put_Long] [decimal](18, 2) NULL,
	[Option_Stock_Call_Short] [decimal](18, 2) NULL,
	[Option_Stock_Put_Short] [decimal](18, 2) NULL,
	[Total_Long_Contracts] [decimal](18, 2) NULL,
	[Total_Short_Contracts] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Participant_wise_Trading_Volume]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant_wise_Trading_Volume](
	[trading_date] [date] NULL,
	[Client_Type] [nvarchar](1000) NULL,
	[Future_Index_Long] [decimal](18, 2) NULL,
	[Future_Index_Short] [decimal](18, 2) NULL,
	[Future_Stock_Long] [decimal](18, 2) NULL,
	[Future_Stock_Short] [decimal](18, 2) NULL,
	[Option_Index_Call_Long] [decimal](18, 2) NULL,
	[Option_Index_Put_Long] [decimal](18, 2) NULL,
	[Option_Index_Call_Short] [decimal](18, 2) NULL,
	[Option_Index_Put_Short] [decimal](18, 2) NULL,
	[Option_Stock_Call_Long] [decimal](18, 2) NULL,
	[Option_Stock_Put_Long] [decimal](18, 2) NULL,
	[Option_Stock_Call_Short] [decimal](18, 2) NULL,
	[Option_Stock_Put_Short] [decimal](18, 2) NULL,
	[Total_Long_Contracts] [decimal](18, 2) NULL,
	[Total_Short_Contracts] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[pos_per_MWPL]    Script Date: 10/12/2019 12:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pos_per_MWPL](
	[MWPL_date] [date] NULL,
	[Underlying_Stock] [nvarchar](1000) NULL,
	[Client_1] [decimal](18, 2) NULL,
	[Client_2] [decimal](18, 2) NULL,
	[Client_3] [decimal](18, 2) NULL,
	[Client_4] [decimal](18, 2) NULL,
	[Client_5] [decimal](18, 2) NULL,
	[Client_6] [decimal](18, 2) NULL,
	[Client_7] [decimal](18, 2) NULL,
	[Client_8] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [fo_bhavcopy_i2]    Script Date: 10/12/2019 12:24:02 PM ******/
CREATE NONCLUSTERED INDEX [fo_bhavcopy_i2] ON [dbo].[fo_bhavcopy]
(
	[TIMESTAMP] ASC,
	[INSTRUMENT] ASC,
	[SYMBOL] ASC,
	[EXPIRY_DT] ASC,
	[STRIKE_PR] ASC,
	[OPTION_TYP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [bhavcopy] SET  READ_WRITE 
GO
