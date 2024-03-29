USE [tutatu]
GO
/****** Object:  Table [dbo].[comentario]    Script Date: 27/01/2017 10:51:34 ******/
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
/****** Object:  Table [dbo].[empresa]    Script Date: 27/01/2017 10:51:34 ******/
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
/****** Object:  Table [dbo].[noticia]    Script Date: 27/01/2017 10:51:34 ******/
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
/****** Object:  Table [dbo].[tatuador]    Script Date: 27/01/2017 10:51:34 ******/
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
/****** Object:  Table [dbo].[tatuaje]    Script Date: 27/01/2017 10:51:34 ******/
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
/****** Object:  Table [dbo].[usuarios]    Script Date: 27/01/2017 10:51:34 ******/
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
/****** Object:  Table [dbo].[webuser]    Script Date: 27/01/2017 10:51:34 ******/
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
/****** Object:  Table [dbo].[zona]    Script Date: 27/01/2017 10:51:34 ******/
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
ALTER TABLE [dbo].[webuser]  WITH CHECK ADD  CONSTRAINT [FK_webuser_usuarios] FOREIGN KEY([id-u])
REFERENCES [dbo].[usuarios] ([id-u])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webuser] CHECK CONSTRAINT [FK_webuser_usuarios]
GO
