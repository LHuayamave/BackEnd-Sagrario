USE [master]
GO
/****** Object:  Database [Facturas]    Script Date: 13/7/2023 9:47:22 ******/
CREATE DATABASE [Facturas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Facturas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Facturas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Facturas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Facturas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Facturas] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Facturas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Facturas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Facturas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Facturas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Facturas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Facturas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Facturas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Facturas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Facturas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Facturas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Facturas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Facturas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Facturas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Facturas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Facturas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Facturas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Facturas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Facturas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Facturas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Facturas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Facturas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Facturas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Facturas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Facturas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Facturas] SET  MULTI_USER 
GO
ALTER DATABASE [Facturas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Facturas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Facturas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Facturas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Facturas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Facturas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Facturas] SET QUERY_STORE = ON
GO
ALTER DATABASE [Facturas] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Facturas]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/7/2023 9:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaCabecera]    Script Date: 13/7/2023 9:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaCabecera](
	[IdFacturaCabecera] [int] IDENTITY(1,1) NOT NULL,
	[FechaFacturaCreacion] [datetime] NOT NULL,
	[NumeroFactura] [varchar](50) NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[NombreCliente] [varchar](50) NOT NULL,
	[NombreEmpresa] [varchar](50) NOT NULL,
	[DireccionEmpresa] [varchar](50) NOT NULL,
	[TelefonoEmpresa] [varchar](50) NOT NULL,
	[Subtotal] [decimal](18, 2) NULL,
	[Iva] [float] NULL,
	[TotalFactura] [float] NULL,
	[EstadoFacturaCabecera] [varchar](1) NOT NULL,
 CONSTRAINT [PK__FacturaCabecera] PRIMARY KEY CLUSTERED 
(
	[IdFacturaCabecera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 13/7/2023 9:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[IdFacturaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdFacturaCabecera] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[SubtotalProducto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__FacturaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdFacturaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 13/7/2023 9:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[EstadoProducto] [varchar](1) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
	[FechaEliminacion] [datetime] NULL,
 CONSTRAINT [PK__Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_FacturaDetalle_IdFacturaCabecera]    Script Date: 13/7/2023 9:47:22 ******/
CREATE NONCLUSTERED INDEX [IX_FacturaDetalle_IdFacturaCabecera] ON [dbo].[FacturaDetalle]
(
	[IdFacturaCabecera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FacturaDetalle_IdProducto]    Script Date: 13/7/2023 9:47:22 ******/
CREATE NONCLUSTERED INDEX [IX_FacturaDetalle_IdProducto] ON [dbo].[FacturaDetalle]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FacturaCabecera] ADD  DEFAULT (getdate()) FOR [FechaFacturaCreacion]
GO
ALTER TABLE [dbo].[FacturaCabecera] ADD  DEFAULT ('A') FOR [EstadoFacturaCabecera]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ('A') FOR [EstadoProducto]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_FacturaCabecera] FOREIGN KEY([IdFacturaCabecera])
REFERENCES [dbo].[FacturaCabecera] ([IdFacturaCabecera])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_FacturaCabecera]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_Producto]
GO
USE [master]
GO
ALTER DATABASE [Facturas] SET  READ_WRITE 
GO
