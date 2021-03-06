USE [Pessoa]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/02/2020 08:28:15 ******/
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
/****** Object:  Table [dbo].[CategoriaContatos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaContatos](
	[CategoriaContatoId] [int] NOT NULL,
	[Descricao] [nvarchar](max) NULL,
 CONSTRAINT [PK_CategoriaContatos] PRIMARY KEY CLUSTERED 
(
	[CategoriaContatoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cidades]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cidades](
	[CidadeId] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](155) NOT NULL,
	[EstadoId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Cidades] PRIMARY KEY CLUSTERED 
(
	[CidadeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contatos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contatos](
	[ContatoId] [bigint] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[CategoriaContatoId] [int] NOT NULL,
	[TipoContatoId] [int] NOT NULL,
 CONSTRAINT [PK_Contatos] PRIMARY KEY CLUSTERED 
(
	[ContatoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentos](
	[DocumentoId] [bigint] IDENTITY(1,1) NOT NULL,
	[PessoaId] [bigint] NOT NULL,
	[TipoDocumentoId] [int] NOT NULL,
	[NumeroDocumento] [nvarchar](max) NULL,
 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
(
	[DocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enderecos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[EnderecoId] [bigint] IDENTITY(1,1) NOT NULL,
	[CEP] [nvarchar](max) NULL,
	[TipoEnderecoId] [int] NOT NULL,
	[Logradouro] [nvarchar](max) NOT NULL,
	[Numero] [nvarchar](5) NULL,
	[Bairro] [nvarchar](max) NULL,
	[Complemento] [nvarchar](max) NULL,
	[CidadeId] [bigint] NOT NULL,
 CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED 
(
	[EnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[UF] [nvarchar](450) NOT NULL,
	[Nome] [nvarchar](max) NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[UF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idiomas](
	[IdiomaId] [int] NOT NULL,
	[LinguaIdioma] [nvarchar](max) NULL,
 CONSTRAINT [PK_Idiomas] PRIMARY KEY CLUSTERED 
(
	[IdiomaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PessoaIdioma]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PessoaIdioma](
	[PessoaId] [bigint] NOT NULL,
	[IdiomaId] [int] NOT NULL,
 CONSTRAINT [PK_PessoaIdioma] PRIMARY KEY CLUSTERED 
(
	[PessoaId] ASC,
	[IdiomaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoas]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoas](
	[PessoaId] [bigint] IDENTITY(1,1) NOT NULL,
	[DataInclusao] [date] NOT NULL,
	[DataEdicao] [datetime2](7) NOT NULL,
	[Ativado] [bit] NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[SobreNome] [nvarchar](max) NOT NULL,
	[Pseudonimo] [nvarchar](max) NULL,
	[Sexo] [bit] NOT NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[DataObito] [datetime2](7) NOT NULL,
	[EnderecoId] [bigint] NOT NULL,
	[CelularId] [bigint] NOT NULL,
	[EmailId] [bigint] NOT NULL,
 CONSTRAINT [PK_Pessoas] PRIMARY KEY CLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relacionamentos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relacionamentos](
	[PessoaPropriaId] [bigint] NOT NULL,
	[PessoaRelacionadaId] [bigint] NOT NULL,
	[TipoRelacionamentoId] [int] NOT NULL,
 CONSTRAINT [PK_Relacionamentos] PRIMARY KEY CLUSTERED 
(
	[PessoaPropriaId] ASC,
	[PessoaRelacionadaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoContatos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoContatos](
	[TipoContatoId] [int] NOT NULL,
	[Descricao] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoContatos] PRIMARY KEY CLUSTERED 
(
	[TipoContatoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[TipoDocumentoId] [int] NOT NULL,
	[Documento] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[TipoDocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEnderecos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEnderecos](
	[TipoEnderecoId] [int] NOT NULL,
	[Descricao] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoEnderecos] PRIMARY KEY CLUSTERED 
(
	[TipoEnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoRelacionamentos]    Script Date: 10/02/2020 08:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRelacionamentos](
	[TipoRelacionamentoId] [int] NOT NULL,
	[Descricao] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoRelacionamentos] PRIMARY KEY CLUSTERED 
(
	[TipoRelacionamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200208183254_Initial-Create', N'3.1.1')
INSERT [dbo].[CategoriaContatos] ([CategoriaContatoId], [Descricao]) VALUES (0, N'Nenhum')
INSERT [dbo].[CategoriaContatos] ([CategoriaContatoId], [Descricao]) VALUES (1, N'Desconhecido')
INSERT [dbo].[CategoriaContatos] ([CategoriaContatoId], [Descricao]) VALUES (2, N'Comercio')
INSERT [dbo].[CategoriaContatos] ([CategoriaContatoId], [Descricao]) VALUES (3, N'Residencia')
SET IDENTITY_INSERT [dbo].[Cidades] ON 

INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (1, N'São José do Rio Preto', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (2, N'Mirassol', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (3, N'Bady Bassit', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (4, N'Cosmorama', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (5, N'Cedral', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (6, N'Ipigua', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (7, N'Barretos', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (8, N'Uchoa', N'SP')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (9, N'Rio de Janeiro', N'RJ')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (10, N'Curitiba', N'PR')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (11, N'Florianópolis', N'SC')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (12, N'Itajaí', N'SC')
INSERT [dbo].[Cidades] ([CidadeId], [Nome], [EstadoId]) VALUES (13, N'Brusque', N'SC')
SET IDENTITY_INSERT [dbo].[Cidades] OFF
SET IDENTITY_INSERT [dbo].[Contatos] ON 

INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (1, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (2, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (3, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (4, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (5, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (6, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (7, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (8, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (9, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (10, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (11, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (12, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (13, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (14, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (15, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (16, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (17, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (18, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (19, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (20, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (21, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (22, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (23, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (24, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (25, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (26, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (27, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (28, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (29, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (30, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (31, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (32, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (33, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (34, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (35, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (36, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (37, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (38, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (39, N'17992637301', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (40, N'alastor@gmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (41, N'17981515290', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (42, N'raphael_garbina@hotmail.com', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (43, N'17981515290', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (44, N'rttt', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (45, N'', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (46, N'', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (47, N'17981515290', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (48, N'teste', 0, 3)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (49, N'', 0, 2)
INSERT [dbo].[Contatos] ([ContatoId], [Descricao], [CategoriaContatoId], [TipoContatoId]) VALUES (50, N'', 0, 3)
SET IDENTITY_INSERT [dbo].[Contatos] OFF
SET IDENTITY_INSERT [dbo].[Documentos] ON 

INSERT [dbo].[Documentos] ([DocumentoId], [PessoaId], [TipoDocumentoId], [NumeroDocumento]) VALUES (1, 22, 2, N'4182064')
SET IDENTITY_INSERT [dbo].[Documentos] OFF
SET IDENTITY_INSERT [dbo].[Enderecos] ON 

INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (1, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (2, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (3, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (4, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (5, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (6, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (7, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (8, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (9, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (10, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (11, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (12, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (13, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (14, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (15, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (16, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (17, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (18, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (19, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (20, N'15047113', 2, N'Rua Joana Darc', N'750', N'Maria Lucia', NULL, 1)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (21, N'', 0, N'teste', N'750', N'maria lucia', NULL, 2)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (22, N'', 0, N'555', N'5555', N'', NULL, 2)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (23, N'', 0, N'teste', N'', N'', NULL, 3)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (24, N'', 0, N'teste', N'', N'', NULL, 11)
INSERT [dbo].[Enderecos] ([EnderecoId], [CEP], [TipoEnderecoId], [Logradouro], [Numero], [Bairro], [Complemento], [CidadeId]) VALUES (25, N'', 0, N'', N'', N'', NULL, 2)
SET IDENTITY_INSERT [dbo].[Enderecos] OFF
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'AC', N'Acre')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'AL', N'Alagoas')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'AM', N'Amazonas')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'AP', N'Amapá')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'BA', N'Bahia')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'CE', N'Ceará')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'DF', N'Distrito Federal')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'ES', N'Espírito Santo')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'GO', N'Goiás')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'MA', N'Maranhão')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'MG', N'Minas Gerais')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'MS', N'Mato Grosso do Sul')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'MT', N'Mato Grosso')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'PA', N'Pará')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'PB', N'Paraíba')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'PE', N'Pernambuco')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'PI', N'Piauí')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'PR', N'Paraná')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'RJ', N'Rio de Janeiro')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'RN', N'Rio Grande do Norte')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'RO', N'Rondônia')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'RR', N'Roraima')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'RS', N'Rio Grande do Sul')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'SC', N'Santa Catarina')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'SE', N'Sergipe')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'SP', N'São Paulo')
INSERT [dbo].[Estados] ([UF], [Nome]) VALUES (N'TO', N'Tocantins')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (0, N'Nenhum')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (1, N'Desconhecido')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (2, N'Portugues')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (3, N'Ingles')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (4, N'Frances')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (5, N'Chines')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (6, N'Russo')
INSERT [dbo].[Idiomas] ([IdiomaId], [LinguaIdioma]) VALUES (7, N'Japones')
INSERT [dbo].[PessoaIdioma] ([PessoaId], [IdiomaId]) VALUES (11, 2)
SET IDENTITY_INSERT [dbo].[Pessoas] ON 

INSERT [dbo].[Pessoas] ([PessoaId], [DataInclusao], [DataEdicao], [Ativado], [Nome], [SobreNome], [Pseudonimo], [Sexo], [DataNascimento], [DataObito], [EnderecoId], [CelularId], [EmailId]) VALUES (11, CAST(N'2020-02-08' AS Date), CAST(N'2020-02-08T22:51:10.4525084' AS DateTime2), 1, N'Raphael kyubi atualizado', N'Garbina gg', N'Alastor update', 1, CAST(N'1994-05-03T03:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 11, 21, 22)
INSERT [dbo].[Pessoas] ([PessoaId], [DataInclusao], [DataEdicao], [Ativado], [Nome], [SobreNome], [Pseudonimo], [Sexo], [DataNascimento], [DataObito], [EnderecoId], [CelularId], [EmailId]) VALUES (21, CAST(N'2020-02-10' AS Date), CAST(N'2020-02-10T07:40:36.0991990' AS DateTime2), 1, N'Testando', N'Novo', N'', 0, CAST(N'1994-03-05T03:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 21, 41, 42)
INSERT [dbo].[Pessoas] ([PessoaId], [DataInclusao], [DataEdicao], [Ativado], [Nome], [SobreNome], [Pseudonimo], [Sexo], [DataNascimento], [DataObito], [EnderecoId], [CelularId], [EmailId]) VALUES (22, CAST(N'2020-02-10' AS Date), CAST(N'2020-02-10T07:42:24.2503109' AS DateTime2), 1, N'teset', N'wwww', N'', 1, CAST(N'1994-03-05T03:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 22, 43, 44)
INSERT [dbo].[Pessoas] ([PessoaId], [DataInclusao], [DataEdicao], [Ativado], [Nome], [SobreNome], [Pseudonimo], [Sexo], [DataNascimento], [DataObito], [EnderecoId], [CelularId], [EmailId]) VALUES (23, CAST(N'2020-02-10' AS Date), CAST(N'2020-02-10T07:52:51.3864193' AS DateTime2), 1, N'teste', N'', N'', 1, CAST(N'1994-03-05T03:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 23, 45, 46)
INSERT [dbo].[Pessoas] ([PessoaId], [DataInclusao], [DataEdicao], [Ativado], [Nome], [SobreNome], [Pseudonimo], [Sexo], [DataNascimento], [DataObito], [EnderecoId], [CelularId], [EmailId]) VALUES (24, CAST(N'2020-02-10' AS Date), CAST(N'2020-02-10T07:58:58.0037358' AS DateTime2), 1, N'teste', N'teste', N'', 1, CAST(N'1994-03-05T03:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 24, 47, 48)
INSERT [dbo].[Pessoas] ([PessoaId], [DataInclusao], [DataEdicao], [Ativado], [Nome], [SobreNome], [Pseudonimo], [Sexo], [DataNascimento], [DataObito], [EnderecoId], [CelularId], [EmailId]) VALUES (25, CAST(N'2020-02-10' AS Date), CAST(N'2020-02-10T08:18:08.5552786' AS DateTime2), 1, N'teste', N'', N'', 0, CAST(N'1998-03-05T03:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 25, 49, 50)
SET IDENTITY_INSERT [dbo].[Pessoas] OFF
INSERT [dbo].[TipoContatos] ([TipoContatoId], [Descricao]) VALUES (0, N'Nenhum')
INSERT [dbo].[TipoContatos] ([TipoContatoId], [Descricao]) VALUES (1, N'Desconhecido')
INSERT [dbo].[TipoContatos] ([TipoContatoId], [Descricao]) VALUES (2, N'Celular')
INSERT [dbo].[TipoContatos] ([TipoContatoId], [Descricao]) VALUES (3, N'E-Mail')
INSERT [dbo].[TipoContatos] ([TipoContatoId], [Descricao]) VALUES (4, N'Rede Social')
INSERT [dbo].[TipoContatos] ([TipoContatoId], [Descricao]) VALUES (5, N'Telefone')
INSERT [dbo].[TipoDocumento] ([TipoDocumentoId], [Documento]) VALUES (0, N'Nenhum')
INSERT [dbo].[TipoDocumento] ([TipoDocumentoId], [Documento]) VALUES (1, N'Desconhecido')
INSERT [dbo].[TipoDocumento] ([TipoDocumentoId], [Documento]) VALUES (2, N'CPF')
INSERT [dbo].[TipoDocumento] ([TipoDocumentoId], [Documento]) VALUES (3, N'RG')
INSERT [dbo].[TipoDocumento] ([TipoDocumentoId], [Documento]) VALUES (4, N'RNE')
INSERT [dbo].[TipoEnderecos] ([TipoEnderecoId], [Descricao]) VALUES (0, N'Nenhum')
INSERT [dbo].[TipoEnderecos] ([TipoEnderecoId], [Descricao]) VALUES (1, N'Desconhecido')
INSERT [dbo].[TipoEnderecos] ([TipoEnderecoId], [Descricao]) VALUES (2, N'Casa')
INSERT [dbo].[TipoEnderecos] ([TipoEnderecoId], [Descricao]) VALUES (3, N'Apartamento')
INSERT [dbo].[TipoEnderecos] ([TipoEnderecoId], [Descricao]) VALUES (4, N'Industria')
INSERT [dbo].[TipoEnderecos] ([TipoEnderecoId], [Descricao]) VALUES (5, N'Rural')
INSERT [dbo].[TipoRelacionamentos] ([TipoRelacionamentoId], [Descricao]) VALUES (0, N'Nenhum')
INSERT [dbo].[TipoRelacionamentos] ([TipoRelacionamentoId], [Descricao]) VALUES (1, N'Desconhecido')
INSERT [dbo].[TipoRelacionamentos] ([TipoRelacionamentoId], [Descricao]) VALUES (2, N'Familiar')
INSERT [dbo].[TipoRelacionamentos] ([TipoRelacionamentoId], [Descricao]) VALUES (3, N'Amoroso')
INSERT [dbo].[TipoRelacionamentos] ([TipoRelacionamentoId], [Descricao]) VALUES (4, N'Amizade')
INSERT [dbo].[TipoRelacionamentos] ([TipoRelacionamentoId], [Descricao]) VALUES (5, N'Profissional')
ALTER TABLE [dbo].[Pessoas] ADD  DEFAULT (getdate()) FOR [DataInclusao]
GO
ALTER TABLE [dbo].[Pessoas] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Ativado]
GO
ALTER TABLE [dbo].[Cidades]  WITH CHECK ADD  CONSTRAINT [FK_Cidades_Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([UF])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cidades] CHECK CONSTRAINT [FK_Cidades_Estados_EstadoId]
GO
ALTER TABLE [dbo].[Contatos]  WITH CHECK ADD  CONSTRAINT [FK_Contatos_CategoriaContatos_CategoriaContatoId] FOREIGN KEY([CategoriaContatoId])
REFERENCES [dbo].[CategoriaContatos] ([CategoriaContatoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contatos] CHECK CONSTRAINT [FK_Contatos_CategoriaContatos_CategoriaContatoId]
GO
ALTER TABLE [dbo].[Contatos]  WITH CHECK ADD  CONSTRAINT [FK_Contatos_TipoContatos_TipoContatoId] FOREIGN KEY([TipoContatoId])
REFERENCES [dbo].[TipoContatos] ([TipoContatoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contatos] CHECK CONSTRAINT [FK_Contatos_TipoContatos_TipoContatoId]
GO
ALTER TABLE [dbo].[Documentos]  WITH CHECK ADD  CONSTRAINT [FK_Documentos_Pessoas_PessoaId] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoas] ([PessoaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentos] CHECK CONSTRAINT [FK_Documentos_Pessoas_PessoaId]
GO
ALTER TABLE [dbo].[Documentos]  WITH CHECK ADD  CONSTRAINT [FK_Documentos_TipoDocumento_TipoDocumentoId] FOREIGN KEY([TipoDocumentoId])
REFERENCES [dbo].[TipoDocumento] ([TipoDocumentoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentos] CHECK CONSTRAINT [FK_Documentos_TipoDocumento_TipoDocumentoId]
GO
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Enderecos_Cidades_CidadeId] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Cidades] ([CidadeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_Cidades_CidadeId]
GO
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Enderecos_TipoEnderecos_TipoEnderecoId] FOREIGN KEY([TipoEnderecoId])
REFERENCES [dbo].[TipoEnderecos] ([TipoEnderecoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_TipoEnderecos_TipoEnderecoId]
GO
ALTER TABLE [dbo].[PessoaIdioma]  WITH CHECK ADD  CONSTRAINT [FK_PessoaIdioma_Idiomas_IdiomaId] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idiomas] ([IdiomaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PessoaIdioma] CHECK CONSTRAINT [FK_PessoaIdioma_Idiomas_IdiomaId]
GO
ALTER TABLE [dbo].[PessoaIdioma]  WITH CHECK ADD  CONSTRAINT [FK_PessoaIdioma_Pessoas_PessoaId] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoas] ([PessoaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PessoaIdioma] CHECK CONSTRAINT [FK_PessoaIdioma_Pessoas_PessoaId]
GO
ALTER TABLE [dbo].[Pessoas]  WITH CHECK ADD  CONSTRAINT [FK_Pessoas_Contatos_CelularId] FOREIGN KEY([CelularId])
REFERENCES [dbo].[Contatos] ([ContatoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pessoas] CHECK CONSTRAINT [FK_Pessoas_Contatos_CelularId]
GO
ALTER TABLE [dbo].[Pessoas]  WITH CHECK ADD  CONSTRAINT [FK_Pessoas_Contatos_EmailId] FOREIGN KEY([EmailId])
REFERENCES [dbo].[Contatos] ([ContatoId])
GO
ALTER TABLE [dbo].[Pessoas] CHECK CONSTRAINT [FK_Pessoas_Contatos_EmailId]
GO
ALTER TABLE [dbo].[Pessoas]  WITH CHECK ADD  CONSTRAINT [FK_Pessoas_Enderecos_EnderecoId] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Enderecos] ([EnderecoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pessoas] CHECK CONSTRAINT [FK_Pessoas_Enderecos_EnderecoId]
GO
ALTER TABLE [dbo].[Relacionamentos]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamentos_Pessoas_PessoaPropriaId] FOREIGN KEY([PessoaPropriaId])
REFERENCES [dbo].[Pessoas] ([PessoaId])
GO
ALTER TABLE [dbo].[Relacionamentos] CHECK CONSTRAINT [FK_Relacionamentos_Pessoas_PessoaPropriaId]
GO
ALTER TABLE [dbo].[Relacionamentos]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamentos_Pessoas_PessoaRelacionadaId] FOREIGN KEY([PessoaRelacionadaId])
REFERENCES [dbo].[Pessoas] ([PessoaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Relacionamentos] CHECK CONSTRAINT [FK_Relacionamentos_Pessoas_PessoaRelacionadaId]
GO
ALTER TABLE [dbo].[Relacionamentos]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamentos_TipoRelacionamentos_TipoRelacionamentoId] FOREIGN KEY([TipoRelacionamentoId])
REFERENCES [dbo].[TipoRelacionamentos] ([TipoRelacionamentoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Relacionamentos] CHECK CONSTRAINT [FK_Relacionamentos_TipoRelacionamentos_TipoRelacionamentoId]
GO
