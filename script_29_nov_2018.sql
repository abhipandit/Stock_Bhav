USE [master]
GO
/****** Object:  Database [bhavcopy]    Script Date: 11/30/2018 7:50:40 PM ******/
CREATE DATABASE [bhavcopy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bhavcopy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bhavcopy.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bhavcopy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bhavcopy_log.ldf' , SIZE = 598016KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [bhavcopy] SET  DISABLE_BROKER 
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
/****** Object:  Table [dbo].[betaStocks]    Script Date: 11/30/2018 7:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[betaStocks](
	[Symbol] [nvarchar](1000) NULL,
	[Series] [datetime] NULL,
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
/****** Object:  Table [dbo].[bhavcopy]    Script Date: 11/30/2018 7:50:41 PM ******/
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
	[TIMESTAMP] [datetime] NULL,
	[TOTALTRADES] [int] NULL,
	[ISIN] [nvarchar](1000) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CMVOLT]    Script Date: 11/30/2018 7:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMVOLT](
	[TIMESTAMP] [datetime] NULL,
	[Symbol] [nvarchar](1000) NULL,
	[Underlying_Close_Price] [decimal](18, 4) NULL,
	[Underlying_Previous_Day_Close_Price] [decimal](18, 4) NULL,
	[Underlying_Log_Returns] [decimal](18, 4) NULL,
	[Previous_Day_Underlying_Volatility] [decimal](18, 4) NULL,
	[Current_Day_Underlying_Daily_Volatility] [decimal](18, 4) NULL,
	[Underlying_Annualised_Volatility] [decimal](18, 4) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Delivery_Position]    Script Date: 11/30/2018 7:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Position](
	[Record_Type] [int] NULL,
	[Sr_No] [int] NULL,
	[Name_of_Security] [nvarchar](1000) NULL,
	[Quantity_Traded] [nvarchar](100) NULL,
	[del_quantity_gross] [int] NULL,
	[percent_delivery] [int] NULL,
	[TIMESTAMP] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fo_bhavcopy]    Script Date: 11/30/2018 7:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fo_bhavcopy](
	[INSTRUMENT] [nvarchar](1000) NULL,
	[SYMBOL] [nvarchar](100) NULL,
	[EXPIRY_DT] [datetime] NULL,
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
	[TIMESTAMP] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[index_close]    Script Date: 11/30/2018 7:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[index_close](
	[index_name] [varchar](1000) NULL,
	[index_date] [datetime] NULL,
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
USE [master]
GO
ALTER DATABASE [bhavcopy] SET  READ_WRITE 
GO
