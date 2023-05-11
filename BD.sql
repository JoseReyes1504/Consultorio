USE [master]
GO
/****** Object:  Database [CML]    Script Date: 5/5/2023 15:05:22 ******/
CREATE DATABASE [CML]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CML', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CML.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CML_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CML_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CML] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CML].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CML] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CML] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CML] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CML] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CML] SET ARITHABORT OFF 
GO
ALTER DATABASE [CML] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CML] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CML] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CML] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CML] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CML] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CML] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CML] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CML] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CML] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CML] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CML] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CML] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CML] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CML] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CML] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CML] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CML] SET RECOVERY FULL 
GO
ALTER DATABASE [CML] SET  MULTI_USER 
GO
ALTER DATABASE [CML] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CML] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CML] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CML] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CML] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CML] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CML', N'ON'
GO
ALTER DATABASE [CML] SET QUERY_STORE = OFF
GO
USE [CML]
GO
/****** Object:  Table [dbo].[Antecedentes]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antecedentes](
	[Id_Antecendentes] [int] IDENTITY(1,1) NOT NULL,
	[Id_Enfermedad_P] [int] NULL,
	[Id_Enfermedad_H] [int] NULL,
 CONSTRAINT [PK_Antecendentes] PRIMARY KEY CLUSTERED 
(
	[Id_Antecendentes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Pantalla] [nvarchar](20) NULL,
	[Id_Usuario] [int] NULL,
	[Descripcion] [nvarchar](80) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultorio]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultorio](
	[Id_Consultorio] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [int] NULL,
	[Antecedentes_Personales] [nvarchar](100) NULL,
	[Id_Signos_Vitales_Consultorio] [int] NULL,
	[Historia_Enfermedad_Actual] [nvarchar](100) NULL,
	[Examen_Fisico] [nvarchar](100) NULL,
	[Impresion_Diagnostico] [nvarchar](100) NULL,
	[Tratamiento] [nvarchar](100) NULL,
	[Conducta] [nvarchar](100) NULL,
	[Incapacidad] [int] NULL,
	[Fecha_Consulta] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Consultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Creacion] [date] NULL,
	[Id_Identificacion] [int] NULL,
	[Id_Antecedentes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enfermedad_Heredo_Familiar]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enfermedad_Heredo_Familiar](
	[Id_Enfermedad_Heredo_Familiar] [int] IDENTITY(1,1) NOT NULL,
	[Diabetes] [int] NULL,
	[Desc_Diabetes] [varchar](40) NULL,
	[Hepatopatia] [int] NULL,
	[Desc_Hepatopatia] [varchar](40) NULL,
	[Asma] [int] NULL,
	[Desc_Asma] [varchar](40) NULL,
	[Enfermedad_Endoctrina] [int] NULL,
	[Desc_Endoctrina] [varchar](40) NULL,
	[Interrogados_y_Negados] [int] NULL,
	[Desc_Interrogados] [varchar](40) NULL,
	[Hipertension] [int] NULL,
	[Desc_Hipertension] [varchar](40) NULL,
	[Nefropatia] [int] NULL,
	[Desc_Nefropatia] [varchar](40) NULL,
	[Cancer] [int] NULL,
	[Desc_Cancer] [varchar](40) NULL,
	[Cardiopatia] [int] NULL,
	[Desc_Cardiopatia] [varchar](40) NULL,
	[Enfermedad_Mental] [int] NULL,
	[Desc_Mental] [varchar](40) NULL,
	[Enfermedad_Alergicas] [int] NULL,
	[Desc_Alergicas] [varchar](40) NULL,
	[Otros] [int] NULL,
	[Desc_Otros] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Enfermedad_Heredo_Familiar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enfermedad_Personales_Patologicos]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enfermedad_Personales_Patologicos](
	[Id_Enfermedad_Personales_Patologicos] [int] IDENTITY(1,1) NOT NULL,
	[Enfermedades_Actuales] [int] NULL,
	[Desc_Otros] [varchar](40) NULL,
	[Quirurgicos] [int] NULL,
	[Desc_Quirurgicas] [varchar](40) NULL,
	[Transfusionales] [int] NULL,
	[Desc_Transfusionales] [varchar](40) NULL,
	[Alergias] [int] NULL,
	[Desc_Alergias] [varchar](40) NULL,
	[Traumaticos] [int] NULL,
	[Desc_Traumaticos] [varchar](40) NULL,
	[Hospitalizaciones_Previas] [int] NULL,
	[Desc_Hospitalizaciones] [varchar](40) NULL,
	[Adicciones] [int] NULL,
	[Desc_Adicciones] [varchar](40) NULL,
	[Otros] [int] NULL,
	[Desc_Otros2] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Enfermedad_Personales_Patologicos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrega_Medicinas]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrega_Medicinas](
	[Id_Entrega] [int] IDENTITY(1,1) NOT NULL,
	[Id_Producto] [int] NULL,
	[Id_Identificacion] [int] NULL,
	[Cantidad] [int] NULL,
	[Fecha_Entrega] [date] NULL,
	[Id_Puesto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Entrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Identificacion]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Identificacion](
	[Id_Identificacion] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Empleado] [nvarchar](15) NULL,
	[Nombre_Completo] [nvarchar](60) NULL,
	[Fecha_Nacimiento] [date] NULL,
	[No_Identidad] [nvarchar](13) NULL,
	[Sexo] [nvarchar](20) NULL,
	[Estado_Civil] [nvarchar](20) NULL,
	[Ocupacion] [nvarchar](30) NULL,
	[Origen] [nvarchar](20) NULL,
	[Reside] [nvarchar](20) NULL,
	[Domicilio] [nvarchar](20) NULL,
	[Telefono] [nvarchar](8) NULL,
	[Religion] [nvarchar](30) NULL,
	[Escolaridad] [nvarchar](30) NULL,
	[Email] [nvarchar](30) NULL,
	[Numero_Referencia] [nvarchar](8) NULL,
	[Id_Puesto] [int] NULL,
	[Imagen] [image] NULL,
	[Estado] [nvarchar](15) NULL,
	[Edad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incapacidad]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incapacidad](
	[Id_Incapacidad] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Incapacidad] [date] NULL,
	[Id_Identificacion] [int] NULL,
	[Id_Puesto] [int] NULL,
	[Motivo] [nvarchar](80) NULL,
	[Dias] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Incapacidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id_Inventario] [int] IDENTITY(1,1) NOT NULL,
	[Id_Producto] [int] NULL,
	[Id_Usuario] [int] NULL,
	[Fecha_Ingreso] [date] NULL,
	[Fecha_Egreso] [date] NULL,
	[Fecha_Vencimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Inventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](40) NULL,
	[Cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[Id_Puesto] [int] IDENTITY(1,1) NOT NULL,
	[Area_Trabajo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Signos_Vitales_Consultorio]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Signos_Vitales_Consultorio](
	[Id_Signos_Vitales_Consultorio] [int] IDENTITY(1,1) NOT NULL,
	[Presion_Arterial] [float] NULL,
	[Temperatura] [float] NULL,
	[Frecuencia_Cardiaca] [float] NULL,
	[Frecuencia_Respiratoria] [float] NULL,
	[Saturacion_Oxigeno] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Signos_Vitales_Consultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/5/2023 15:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](20) NULL,
	[Contrasena] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Antecedentes]  WITH CHECK ADD  CONSTRAINT [FK_Enfermedad_H] FOREIGN KEY([Id_Enfermedad_H])
REFERENCES [dbo].[Enfermedad_Heredo_Familiar] ([Id_Enfermedad_Heredo_Familiar])
GO
ALTER TABLE [dbo].[Antecedentes] CHECK CONSTRAINT [FK_Enfermedad_H]
GO
ALTER TABLE [dbo].[Antecedentes]  WITH CHECK ADD  CONSTRAINT [Fk_Enfermedad_P] FOREIGN KEY([Id_Enfermedad_P])
REFERENCES [dbo].[Enfermedad_Personales_Patologicos] ([Id_Enfermedad_Personales_Patologicos])
GO
ALTER TABLE [dbo].[Antecedentes] CHECK CONSTRAINT [Fk_Enfermedad_P]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Consultorio]  WITH CHECK ADD FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Consultorio]  WITH CHECK ADD FOREIGN KEY([Id_Signos_Vitales_Consultorio])
REFERENCES [dbo].[Signos_Vitales_Consultorio] ([Id_Signos_Vitales_Consultorio])
GO
ALTER TABLE [dbo].[Entrega_Medicinas]  WITH CHECK ADD FOREIGN KEY([Id_Identificacion])
REFERENCES [dbo].[Identificacion] ([Id_Identificacion])
GO
ALTER TABLE [dbo].[Entrega_Medicinas]  WITH CHECK ADD FOREIGN KEY([Id_Producto])
REFERENCES [dbo].[Producto] ([Id_Producto])
GO
ALTER TABLE [dbo].[Entrega_Medicinas]  WITH CHECK ADD FOREIGN KEY([Id_Puesto])
REFERENCES [dbo].[Puesto] ([Id_Puesto])
GO
ALTER TABLE [dbo].[Identificacion]  WITH CHECK ADD FOREIGN KEY([Id_Puesto])
REFERENCES [dbo].[Puesto] ([Id_Puesto])
GO
ALTER TABLE [dbo].[Incapacidad]  WITH CHECK ADD FOREIGN KEY([Id_Identificacion])
REFERENCES [dbo].[Identificacion] ([Id_Identificacion])
GO
ALTER TABLE [dbo].[Incapacidad]  WITH CHECK ADD FOREIGN KEY([Id_Puesto])
REFERENCES [dbo].[Puesto] ([Id_Puesto])
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD FOREIGN KEY([Id_Producto])
REFERENCES [dbo].[Producto] ([Id_Producto])
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
USE [master]
GO
ALTER DATABASE [CML] SET  READ_WRITE 
GO
