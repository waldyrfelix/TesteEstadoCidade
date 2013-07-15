USE [DbEstadoCidade]
GO

CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Pais] [nvarchar](50) NOT NULL,
	[Regiao] [nvarchar](50) NOT NULL,
	[Sigla] [char](2) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY (Id) ON [PRIMARY]
 )

 go 

CREATE TABLE [dbo].[Cidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Capital] [bit] NOT NULL default (0),
	[EstadoId] [int] NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY (Id) ON [PRIMARY],
 CONSTRAINT [FK_Cidade_Estado] FOREIGN KEY (EstadoId) REFERENCES Estado(Id),

) 


