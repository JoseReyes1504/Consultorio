CREATE DATABASE [CML]
USE [CML]

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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pantalla] [varchar](50) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Descripcion] [varchar](400) NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultorio]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultorio](
	[Id_Consultorio] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [int] NULL,
	[Antecedentes_Personales] [nvarchar](1000) NULL,
	[Id_Signos_Vitales_Consultorio] [int] NULL,
	[Historia_Enfermedad_Actual] [nvarchar](100) NULL,
	[Examen_Fisico] [nvarchar](100) NULL,
	[Impresion_Diagnostico] [nvarchar](100) NULL,
	[Tratamiento] [nvarchar](100) NULL,
	[Conducta] [nvarchar](100) NULL,
	[Incapacidad] [nvarchar](3) NULL,
	[Fecha_Consulta] [datetime2](7) NULL,
	[Motivo_Consulta] [nvarchar](100) NULL,
 CONSTRAINT [PK_Consultorio] PRIMARY KEY CLUSTERED 
(
	[Id_Consultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 26/5/2023 17:40:18 ******/
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
/****** Object:  Table [dbo].[Enfermedad_Heredo_Familiar]    Script Date: 26/5/2023 17:40:18 ******/
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
/****** Object:  Table [dbo].[Enfermedad_Personales_Patologicos]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enfermedad_Personales_Patologicos](
	[Id_Enfermedad_Personales_Patologicos] [int] IDENTITY(1,1) NOT NULL,
	[Enfermedades_Actuales] [int] NULL,
	[Desc_Actuales] [varchar](200) NULL,
	[Quirurgicos] [int] NULL,
	[Desc_Quirurgicas] [varchar](200) NULL,
	[Transfusionales] [int] NULL,
	[Desc_Transfusionales] [varchar](200) NULL,
	[Alergias] [int] NULL,
	[Desc_Alergias] [varchar](200) NULL,
	[Traumaticos] [int] NULL,
	[Desc_Traumaticos] [varchar](200) NULL,
	[Hospitalizaciones_Previas] [int] NULL,
	[Desc_Hospitalizaciones] [varchar](200) NULL,
	[Adicciones] [int] NULL,
	[Desc_Adicciones] [varchar](200) NULL,
	[Otros2] [int] NULL,
	[Desc_Otros2] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Enfermedad_Personales_Patologicos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrega_Medicinas]    Script Date: 26/5/2023 17:40:18 ******/
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
/****** Object:  Table [dbo].[Identificacion]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Identificacion](
	[Id_Identificacion] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Empleado] [nvarchar](15) NULL,
	[Nombre_Completo] [nvarchar](100) NULL,
	[Fecha_Nacimiento] [date] NULL,
	[No_Identidad] [nvarchar](13) NULL,
	[Sexo] [nvarchar](20) NULL,
	[Estado_Civil] [nvarchar](20) NULL,
	[Ocupacion] [nvarchar](30) NULL,
	[Origen] [nvarchar](20) NULL,
	[Reside] [nvarchar](20) NULL,
	[Domicilio] [nvarchar](100) NULL,
	[Telefono] [nvarchar](8) NULL,
	[Religion] [nvarchar](30) NULL,
	[Escolaridad] [nvarchar](30) NULL,
	[Email] [nvarchar](60) NULL,
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
/****** Object:  Table [dbo].[Incapacidad]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incapacidad](
	[Id_Incapacidad] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Incapacidad] [datetime] NULL,
	[Fecha_Incio] [date] NULL,
	[Fecha_Final] [date] NULL,
	[Id_Identificacion] [int] NULL,
	[Id_Puesto] [int] NULL,
	[Motivo] [nvarchar](100) NULL,
	[Centro_Medico] [nvarchar](100) NULL,
	[Tipo_Enfermedad] [nvarchar](100) NULL,
	[Refrendado] [nvarchar](100) NULL,
	[Dias] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Incapacidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id_Inventario] [int] IDENTITY(1,1) NOT NULL,
	[Id_Producto] [int] NULL,
	[Fecha_Ingreso] [nvarchar](100) NULL,
	[Fecha_Egreso] [nvarchar](100) NULL,
	[Fecha_Vencimiento] [nvarchar](100) NULL,
	[Ingreso] [int] NULL,
	[Egreso] [int] NULL,
	[Existencia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Inventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 26/5/2023 17:40:18 ******/
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
/****** Object:  Table [dbo].[Puesto]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[Id_Puesto] [int] IDENTITY(1,1) NOT NULL,
	[Area_Trabajo] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Signos_Vitales_Consultorio]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Signos_Vitales_Consultorio](
	[Id_Signos_Vitales_Consultorio] [int] IDENTITY(1,1) NOT NULL,
	[Presion_Arterial] [nvarchar](20) NULL,
	[Temperatura] [nvarchar](20) NULL,
	[Frecuencia_Cardiaca] [nvarchar](20) NULL,
	[Frecuencia_Respiratoria] [nvarchar](20) NULL,
	[Saturacion_Oxigeno] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Signos_Vitales_Consultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/5/2023 17:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](20) NULL,
	[Contrasena] [nvarchar](100) NULL,
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
ALTER TABLE [dbo].[Consultorio]  WITH CHECK ADD  CONSTRAINT [FK_Id_Empleado] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Consultorio] CHECK CONSTRAINT [FK_Id_Empleado]
GO
ALTER TABLE [dbo].[Consultorio]  WITH CHECK ADD  CONSTRAINT [FK_Signos] FOREIGN KEY([Id_Signos_Vitales_Consultorio])
REFERENCES [dbo].[Signos_Vitales_Consultorio] ([Id_Signos_Vitales_Consultorio])
GO
ALTER TABLE [dbo].[Consultorio] CHECK CONSTRAINT [FK_Signos]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Antecedentes] FOREIGN KEY([Id_Antecedentes])
REFERENCES [dbo].[Antecedentes] ([Id_Antecendentes])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Antecedentes]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Identificacion] FOREIGN KEY([Id_Identificacion])
REFERENCES [dbo].[Identificacion] ([Id_Identificacion])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Identificacion]
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
USE [master]
GO
ALTER DATABASE [CML] SET  READ_WRITE 
GO
