USE [BusinessDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 05/04/2023 17:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 05/04/2023 17:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] NOT NULL,
	[Nom] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[Adresse] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 05/04/2023 17:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] NOT NULL,
	[Nom] [nvarchar](50) NULL,
	[Salaire] [money] NULL,
	[Recrutement] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produits]    Script Date: 05/04/2023 17:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produits](
	[Id] [int] NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Prix] [money] NULL,
	[ClientId] [int] NULL,
	[EmployeeId] [int] NULL,
	[CategorieId] [int] NULL,
 CONSTRAINT [PK_Produits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Produits]  WITH CHECK ADD  CONSTRAINT [FK_Produits_Categories] FOREIGN KEY([CategorieId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[Produits] CHECK CONSTRAINT [FK_Produits_Categories]
GO
ALTER TABLE [dbo].[Produits]  WITH CHECK ADD  CONSTRAINT [FK_Produits_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Produits] CHECK CONSTRAINT [FK_Produits_Clients]
GO
ALTER TABLE [dbo].[Produits]  WITH CHECK ADD  CONSTRAINT [FK_Produits_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Produits] CHECK CONSTRAINT [FK_Produits_Employees]
GO
