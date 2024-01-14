USE [master]
GO
/****** Object:  Database [Web_Trung_Gian]    Script Date: 1/14/2024 11:41:06 PM ******/
CREATE DATABASE [Web_Trung_Gian]
 CONTAINMENT = NONE

ALTER DATABASE [Web_Trung_Gian] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Web_Trung_Gian].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Web_Trung_Gian] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET ARITHABORT OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Web_Trung_Gian] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Web_Trung_Gian] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Web_Trung_Gian] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Web_Trung_Gian] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET RECOVERY FULL 
GO
ALTER DATABASE [Web_Trung_Gian] SET  MULTI_USER 
GO
ALTER DATABASE [Web_Trung_Gian] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Web_Trung_Gian] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Web_Trung_Gian] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Web_Trung_Gian] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Web_Trung_Gian] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Web_Trung_Gian] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Web_Trung_Gian', N'ON'
GO
ALTER DATABASE [Web_Trung_Gian] SET QUERY_STORE = OFF
GO
USE [Web_Trung_Gian]
GO
/****** Object:  Table [dbo].[account]    Script Date: 1/14/2024 11:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[avatar] [varchar](500) NULL,
	[username] [varchar](50) NULL,
	[email] [varchar](500) NULL,
	[password] [varchar](200) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[is_delete] [bit] NULL,
	[id_role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_roles]    Script Date: 1/14/2024 11:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_roles](
	[id] [int] NOT NULL,
	[role] [nvarchar](50) NULL,
	[is_delete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 1/14/2024 11:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[avatar] [varchar](100) NULL,
	[username] [varchar](50) NULL,
	[email] [varchar](500) NULL,
	[password] [varchar](200) NULL,
	[id_role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT ((0)) FOR [is_delete]
GO
ALTER TABLE [dbo].[account_roles] ADD  DEFAULT ((0)) FOR [is_delete]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD FOREIGN KEY([id_role])
REFERENCES [dbo].[account_roles] ([id])
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD FOREIGN KEY([id_role])
REFERENCES [dbo].[account_roles] ([id])
GO
USE [master]
GO
ALTER DATABASE [Web_Trung_Gian] SET  READ_WRITE 
GO
