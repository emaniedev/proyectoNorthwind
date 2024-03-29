USE [master]
GO
/****** Object:  Database [tutatu]    Script Date: 02/11/2016 21:23:00 ******/
CREATE DATABASE [tutatu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tutatu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\tutatu.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'tutatu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\tutatu_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [tutatu] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tutatu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tutatu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tutatu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tutatu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tutatu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tutatu] SET ARITHABORT OFF 
GO
ALTER DATABASE [tutatu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tutatu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tutatu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tutatu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tutatu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tutatu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tutatu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tutatu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tutatu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tutatu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tutatu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tutatu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tutatu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tutatu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tutatu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tutatu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tutatu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tutatu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tutatu] SET  MULTI_USER 
GO
ALTER DATABASE [tutatu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tutatu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tutatu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tutatu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [tutatu] SET DELAYED_DURABILITY = DISABLED 
GO
USE [tutatu]
GO
/****** Object:  Table [dbo].[comentario]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[comentario](
	[id-com] [smallint] IDENTITY(1,1) NOT NULL,
	[id-u] [smallint] NOT NULL,
	[date] [datetime] NOT NULL,
	[zone-id] [smallint] NOT NULL,
	[cont-id] [smallint] NULL,
	[content] [varchar](max) NULL,
 CONSTRAINT [PK_comentario] PRIMARY KEY CLUSTERED 
(
	[id-com] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[empresa]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[empresa](
	[id-emp] [smallint] IDENTITY(1,1) NOT NULL,
	[id-u] [smallint] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[cif] [varchar](10) NOT NULL,
	[address] [varchar](200) NULL,
	[phone] [varchar](15) NULL,
	[owner] [varchar](50) NOT NULL,
	[email] [varchar](100) NULL,
	[web] [varchar](100) NULL,
	[services] [varchar](max) NOT NULL,
	[trayectoria] [varchar](max) NOT NULL,
 CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED 
(
	[id-emp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[noticia]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[noticia](
	[id-not] [smallint] IDENTITY(1,1) NOT NULL,
	[id-u] [smallint] NOT NULL,
	[date] [datetime] NOT NULL,
	[zone-id] [smallint] NOT NULL,
	[cont-id] [smallint] NULL,
	[content] [varchar](max) NULL,
 CONSTRAINT [PK_noticia] PRIMARY KEY CLUSTERED 
(
	[id-not] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tatuador]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tatuador](
	[id-tat] [smallint] IDENTITY(1,1) NOT NULL,
	[id-u] [smallint] NOT NULL,
	[id-emp] [smallint] NOT NULL CONSTRAINT [DF_tatuador_id-emp]  DEFAULT ((1)),
	[fname-tat] [varchar](50) NOT NULL,
	[sname-tat] [varchar](50) NOT NULL,
	[email-tat] [varchar](100) NULL,
	[phone-tat] [varchar](15) NULL,
	[style-tat] [varchar](max) NULL,
	[ink-tat] [varchar](200) NOT NULL,
	[designer-tat] [bit] NOT NULL,
	[trayectory-tat] [varchar](max) NULL,
	[study-tat] [varchar](100) NULL,
 CONSTRAINT [PK_tatuador] PRIMARY KEY CLUSTERED 
(
	[id-tat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tatuaje]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tatuaje](
	[id-tatoo] [smallint] IDENTITY(1,1) NOT NULL,
	[id-wu] [smallint] NULL,
	[id-tat] [smallint] NULL,
	[style-tatoo] [varchar](100) NULL,
	[color-tatoo] [bit] NOT NULL,
	[date-tatoo] [datetime] NOT NULL,
	[time-tatoo] [time](7) NOT NULL,
	[price-tatoo] [money] NULL,
	[shoot-date] [datetime] NOT NULL,
 CONSTRAINT [PK_tatuaje] PRIMARY KEY CLUSTERED 
(
	[id-tatoo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[id-u] [smallint] IDENTITY(10,1) NOT NULL,
	[nickname] [varchar](50) NOT NULL,
	[pass1] [varchar](100) NOT NULL,
	[pass2] [varchar](100) NOT NULL,
	[date-reg] [datetime] NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id-u] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webuser]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[webuser](
	[id-wu] [smallint] IDENTITY(1,1) NOT NULL,
	[id-u] [smallint] NOT NULL,
	[fname] [varchar](50) NOT NULL,
	[sname] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[b-date] [datetime] NULL,
	[sexo] [varchar](10) NULL,
 CONSTRAINT [PK_webuser] PRIMARY KEY CLUSTERED 
(
	[id-wu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[zona]    Script Date: 02/11/2016 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[zona](
	[id-zone] [smallint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_zona] PRIMARY KEY CLUSTERED 
(
	[id-zone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[empresa] ON 

INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (2, 10, N'La embajada Tattoo', N'b45785632', N'barcelona', N'111-111-111', N'Embajada', N'embajada@embajada.com', N'www.embajada.com', N'Neotradicional, puntillismo', N'8 años')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (3, 11, N'Black Jack Tatto by Jaggo', N'c45963478', N'Murcia', N'222-222-222', N'Jack', N'jack@blackjack.com', N'www.blacktatoo.com', N'ByG, realismo, tradicional', N'2 años')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (4, 12, N'Siha tatto', N'd12457896', N'Barcelona', N'333-333-333', N'Siha', N'sihta@hotmail.com', N'www.sihatat.net', N'Acuarela, geometrico, Neotradicional', N'6 años')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (5, 13, N'Tatto Center', N'f36541282', N'Madrid', N'444-444-444-', N'Uno', N'tacen@outlook.es', N'www.tattocenter.net', N'Old school, new school', N'16 años')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (8, 14, N'Saints and Sinners', N'g78562319', N'Guadalajara', N'555-555-555', N'Santos', N'sands@sands.com', N'www.sands.es', N'Realismo, puntillismo', N'12 años')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (11, 15, N'Addicted Tatto', N'h57913711', N'Barcelona', N'666-666-666', N'Eddy', N'info@additto.com', N'www.additto.com', N'tatto, piercing', N'1 año')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (13, 16, N'La mano Zurda', N'j33446287', N'Madrid', N'777-777-777', N'Manos', N'manoplas@hotmail.com', N'www.lamanozurda.com', N'Old School', N'nuevo')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (14, 17, N'LTW', N'k87556349', N'Barcelona', N'888-888-888', N'Lele', NULL, NULL, N'tribal, japones', N'2 años')
INSERT [dbo].[empresa] ([id-emp], [id-u], [name], [cif], [address], [phone], [owner], [email], [web], [services], [trayectoria]) VALUES (15, 1, N'autonomos', N'a12345678', N'elMundo', N'000-000-000', N'yo', NULL, NULL, N'todos', N'mucho')
SET IDENTITY_INSERT [dbo].[empresa] OFF
SET IDENTITY_INSERT [dbo].[tatuador] ON 

INSERT [dbo].[tatuador] ([id-tat], [id-u], [id-emp], [fname-tat], [sname-tat], [email-tat], [phone-tat], [style-tat], [ink-tat], [designer-tat], [trayectory-tat], [study-tat]) VALUES (5, 18, 15, N'israel', N'solano', N'solano@tatoo.com', N'111-111-111', N'realismo', N'buena', 0, N'larga', N'no')
INSERT [dbo].[tatuador] ([id-tat], [id-u], [id-emp], [fname-tat], [sname-tat], [email-tat], [phone-tat], [style-tat], [ink-tat], [designer-tat], [trayectory-tat], [study-tat]) VALUES (8, 19, 2, N'Adrian', N'hidalgo', N'hidalgo@tatoo.com', N'222-222-222', N'retratos', N'regular', 1, N'poca', N'no')
INSERT [dbo].[tatuador] ([id-tat], [id-u], [id-emp], [fname-tat], [sname-tat], [email-tat], [phone-tat], [style-tat], [ink-tat], [designer-tat], [trayectory-tat], [study-tat]) VALUES (9, 20, 3, N'Aitor', N'Jimenez', N'jimen@tatoo.com', N'333-333-333', N'new school', N'mala', 0, N'nuevo', N'The Last Monkey')
INSERT [dbo].[tatuador] ([id-tat], [id-u], [id-emp], [fname-tat], [sname-tat], [email-tat], [phone-tat], [style-tat], [ink-tat], [designer-tat], [trayectory-tat], [study-tat]) VALUES (10, 21, 4, N'Alejandro', N'Legaza', NULL, N'444-444-444', N'ByG', N'excelente', 0, N'4 años', NULL)
INSERT [dbo].[tatuador] ([id-tat], [id-u], [id-emp], [fname-tat], [sname-tat], [email-tat], [phone-tat], [style-tat], [ink-tat], [designer-tat], [trayectory-tat], [study-tat]) VALUES (13, 22, 11, N'Amayra', N'amayra', N'ama@tatoo.com', NULL, NULL, N'buena', 1, N'10 años', NULL)
INSERT [dbo].[tatuador] ([id-tat], [id-u], [id-emp], [fname-tat], [sname-tat], [email-tat], [phone-tat], [style-tat], [ink-tat], [designer-tat], [trayectory-tat], [study-tat]) VALUES (15, 23, 15, N'Angel', N'de la Concha', NULL, NULL, N'all', N'no sabe', 0, N'nuevo', N'Promise Tatto')
SET IDENTITY_INSERT [dbo].[tatuador] OFF
SET IDENTITY_INSERT [dbo].[tatuaje] ON 

INSERT [dbo].[tatuaje] ([id-tatoo], [id-wu], [id-tat], [style-tatoo], [color-tatoo], [date-tatoo], [time-tatoo], [price-tatoo], [shoot-date]) VALUES (1, 8, 5, N'realista', 1, CAST(N'2016-11-02 00:00:00.000' AS DateTime), CAST(N'02:00:00' AS Time), 10.0000, CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[tatuaje] ([id-tatoo], [id-wu], [id-tat], [style-tatoo], [color-tatoo], [date-tatoo], [time-tatoo], [price-tatoo], [shoot-date]) VALUES (2, 10, 10, N'BYG', 0, CAST(N'2016-11-02 00:00:00.000' AS DateTime), CAST(N'01:00:00' AS Time), 25.0000, CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[tatuaje] ([id-tatoo], [id-wu], [id-tat], [style-tatoo], [color-tatoo], [date-tatoo], [time-tatoo], [price-tatoo], [shoot-date]) VALUES (3, 11, 13, N'new School', 1, CAST(N'1995-06-07 00:00:00.000' AS DateTime), CAST(N'05:00:00' AS Time), 100.0000, CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[tatuaje] ([id-tatoo], [id-wu], [id-tat], [style-tatoo], [color-tatoo], [date-tatoo], [time-tatoo], [price-tatoo], [shoot-date]) VALUES (4, 8, 5, N'japones', 0, CAST(N'2016-06-07 00:00:00.000' AS DateTime), CAST(N'03:00:00' AS Time), 50.0000, CAST(N'2017-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[tatuaje] ([id-tatoo], [id-wu], [id-tat], [style-tatoo], [color-tatoo], [date-tatoo], [time-tatoo], [price-tatoo], [shoot-date]) VALUES (5, 8, 10, N'BYG', 1, CAST(N'2016-11-02 00:00:00.000' AS DateTime), CAST(N'00:30:00' AS Time), 10.0000, CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[tatuaje] ([id-tatoo], [id-wu], [id-tat], [style-tatoo], [color-tatoo], [date-tatoo], [time-tatoo], [price-tatoo], [shoot-date]) VALUES (6, 8, 13, N'japones', 1, CAST(N'2016-11-02 00:00:00.000' AS DateTime), CAST(N'10:10:00' AS Time), 250.0000, CAST(N'2016-11-02 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tatuaje] OFF
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (1, N'autonomo', N'sinpenanigloria', N'sinpenanigloria', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (10, N'laembajada', N'laembajada', N'laembajada', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (11, N'blackjack', N'blackjack', N'blackjack', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (12, N'sihatatto', N'sihatatto', N'sihatatto', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (13, N'tattocenter', N'tattocenter', N'tatoocenter', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (14, N'sands', N'sands', N'sands', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (15, N'addicted', N'addicted', N'addicted', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (16, N'lamano', N'lamano', N'lamano', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (17, N'ltw', N'ltw', N'ltw', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (18, N'israel', N'israel', N'israel', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (19, N'Adrian', N'adrian', N'adrian', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (20, N'aitor', N'aitor', N'aitor', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (21, N'Alejandro', N'alejandro', N'alejandro', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (22, N'amayra', N'amayra', N'amayra', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (23, N'angel', N'angel', N'angel', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (24, N'masticapilas', N'yo', N'yo', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (25, N'rocii', N'rocii', N'rocii', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[usuarios] ([id-u], [nickname], [pass1], [pass2], [date-reg]) VALUES (26, N'juan', N'juan', N'juan', CAST(N'2016-11-02 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[usuarios] OFF
SET IDENTITY_INSERT [dbo].[webuser] ON 

INSERT [dbo].[webuser] ([id-wu], [id-u], [fname], [sname], [email], [b-date], [sexo]) VALUES (8, 24, N'Edgar', N'Maniega', N'maniega@outlook.es', CAST(N'2016-11-02 00:00:00.000' AS DateTime), N'hombre')
INSERT [dbo].[webuser] ([id-wu], [id-u], [fname], [sname], [email], [b-date], [sexo]) VALUES (10, 25, N'Rocio', N'Maestro Montolla', N'xxx', CAST(N'1990-12-24 00:00:00.000' AS DateTime), N'mujer')
INSERT [dbo].[webuser] ([id-wu], [id-u], [fname], [sname], [email], [b-date], [sexo]) VALUES (11, 26, N'Juan Manuel', N'Maniega Vega', N'cepas@cepas.es', CAST(N'2016-11-02 00:00:00.000' AS DateTime), N'no gracias')
SET IDENTITY_INSERT [dbo].[webuser] OFF
ALTER TABLE [dbo].[comentario]  WITH CHECK ADD  CONSTRAINT [FK_comentario_usuarios] FOREIGN KEY([id-u])
REFERENCES [dbo].[usuarios] ([id-u])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[comentario] CHECK CONSTRAINT [FK_comentario_usuarios]
GO
ALTER TABLE [dbo].[comentario]  WITH CHECK ADD  CONSTRAINT [FK_comentario_zona] FOREIGN KEY([zone-id])
REFERENCES [dbo].[zona] ([id-zone])
GO
ALTER TABLE [dbo].[comentario] CHECK CONSTRAINT [FK_comentario_zona]
GO
ALTER TABLE [dbo].[empresa]  WITH CHECK ADD  CONSTRAINT [FK_empresa_usuarios] FOREIGN KEY([id-u])
REFERENCES [dbo].[usuarios] ([id-u])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[empresa] CHECK CONSTRAINT [FK_empresa_usuarios]
GO
ALTER TABLE [dbo].[noticia]  WITH CHECK ADD  CONSTRAINT [FK_noticia_usuarios] FOREIGN KEY([id-u])
REFERENCES [dbo].[usuarios] ([id-u])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[noticia] CHECK CONSTRAINT [FK_noticia_usuarios]
GO
ALTER TABLE [dbo].[noticia]  WITH CHECK ADD  CONSTRAINT [FK_noticia_zona] FOREIGN KEY([zone-id])
REFERENCES [dbo].[zona] ([id-zone])
GO
ALTER TABLE [dbo].[noticia] CHECK CONSTRAINT [FK_noticia_zona]
GO
ALTER TABLE [dbo].[tatuador]  WITH CHECK ADD  CONSTRAINT [FK_tatuador_empresa] FOREIGN KEY([id-emp])
REFERENCES [dbo].[empresa] ([id-emp])
GO
ALTER TABLE [dbo].[tatuador] CHECK CONSTRAINT [FK_tatuador_empresa]
GO
ALTER TABLE [dbo].[tatuador]  WITH CHECK ADD  CONSTRAINT [FK_tatuador_usuarios] FOREIGN KEY([id-u])
REFERENCES [dbo].[usuarios] ([id-u])
GO
ALTER TABLE [dbo].[tatuador] CHECK CONSTRAINT [FK_tatuador_usuarios]
GO
ALTER TABLE [dbo].[tatuaje]  WITH CHECK ADD  CONSTRAINT [FK_tatuaje_tatuador] FOREIGN KEY([id-tat])
REFERENCES [dbo].[tatuador] ([id-tat])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tatuaje] CHECK CONSTRAINT [FK_tatuaje_tatuador]
GO
ALTER TABLE [dbo].[tatuaje]  WITH CHECK ADD  CONSTRAINT [FK_tatuaje_webuser] FOREIGN KEY([id-wu])
REFERENCES [dbo].[webuser] ([id-wu])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tatuaje] CHECK CONSTRAINT [FK_tatuaje_webuser]
GO
ALTER TABLE [dbo].[webuser]  WITH CHECK ADD  CONSTRAINT [FK_webuser_usuarios] FOREIGN KEY([id-u])
REFERENCES [dbo].[usuarios] ([id-u])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webuser] CHECK CONSTRAINT [FK_webuser_usuarios]
GO
USE [master]
GO
ALTER DATABASE [tutatu] SET  READ_WRITE 
GO
