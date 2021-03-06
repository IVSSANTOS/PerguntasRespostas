USE [master]
GO
/****** Object:  Database [PerguntasRespostas]    Script Date: 09/11/2018 19:17:45 ******/
CREATE DATABASE [PerguntasRespostas]
 
GO
USE [PerguntasRespostas]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Email] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[Descricao] [varchar](200) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pergunta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pergunta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAutor] [int] NOT NULL,
	[Descricao] [varchar](200) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
 CONSTRAINT [PK_Pergunta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resposta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resposta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPergunta] [int] NOT NULL,
	[IdAutor] [int] NOT NULL,
	[Descricao] [varchar](200) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[RespostaAceita] [bit] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
 CONSTRAINT [PK_Resposta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pergunta]  WITH CHECK ADD  CONSTRAINT [FK_Pergunta_Autor] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([Id])
GO
ALTER TABLE [dbo].[Pergunta] CHECK CONSTRAINT [FK_Pergunta_Autor]
GO
ALTER TABLE [dbo].[Pergunta]  WITH CHECK ADD  CONSTRAINT [FK_Pergunta_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Pergunta] CHECK CONSTRAINT [FK_Pergunta_Categoria]
GO
ALTER TABLE [dbo].[Resposta]  WITH CHECK ADD  CONSTRAINT [FK_Resposta_Autor] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([Id])
GO
ALTER TABLE [dbo].[Resposta] CHECK CONSTRAINT [FK_Resposta_Autor]
GO
ALTER TABLE [dbo].[Resposta]  WITH CHECK ADD  CONSTRAINT [FK_Resposta_Pergunta] FOREIGN KEY([IdPergunta])
REFERENCES [dbo].[Pergunta] ([Id])
GO
ALTER TABLE [dbo].[Resposta] CHECK CONSTRAINT [FK_Resposta_Pergunta]
GO
/****** Object:  StoredProcedure [dbo].[PR_DeleteAutor]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_DeleteAutor]
(
 @Id int
 
)
AS

BEGIN
	DELETE FROM  [dbo].[Autor]
		  
    WHERE Id = @Id
 
END

GO
/****** Object:  StoredProcedure [dbo].[PR_DeleteCategoria]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_DeleteCategoria]
(
 @Id int
 
)
AS

BEGIN
	UPDATE  [dbo].[Categoria]
	SET
           [Ativo] = 0
		  
     WHERE Id = @Id
 
END

GO
/****** Object:  StoredProcedure [dbo].[PR_DeletePergunta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_DeletePergunta]
(
 @Id int
 
)
AS

BEGIN
	UPDATE  [dbo].[Pergunta]
	SET
           [Ativo] = 0
		  
     WHERE Id = @Id
 
END

GO
/****** Object:  StoredProcedure [dbo].[PR_DeleteResposta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_DeleteResposta]
(
 @Id int
 
)
AS

BEGIN
	DELETE FROM  [dbo].[Resposta]
		  
    WHERE Id = @Id
 
END

GO
/****** Object:  StoredProcedure [dbo].[PR_GetAutor]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_GetAutor]
(
 @Id INT = null
)
AS

BEGIN
	SELECT [Id]
		  ,[Nome]
		  ,[Email]
	  FROM [dbo].[Autor] with(nolock)
	  WHERE ID = @Id OR @Id IS NULL

END

GO
/****** Object:  StoredProcedure [dbo].[PR_GetCategoria]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_GetCategoria]
(
 @Id INT = null
)
AS

BEGIN
	SELECT [Id]
      ,[Titulo]
      ,[Descricao]
      ,[Ativo]
      FROM [dbo].[Categoria] with(nolock)
	  WHERE ID = @Id OR @Id IS NULL

END

GO
/****** Object:  StoredProcedure [dbo].[PR_GetPergunta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_GetPergunta]
(
 @Id INT = null
)
AS

BEGIN
	SELECT [Id]
      ,[IdAutor]
      ,[Descricao]
      ,[IdCategoria]
      ,[Ativo]
      ,[DataCriacao]
      FROM [dbo].[Pergunta]
	  WHERE ID = @Id OR @Id IS NULL

END

GO
/****** Object:  StoredProcedure [dbo].[PR_GetResposta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_GetResposta]
(
 @Id INT = null
)
AS

BEGIN
	SELECT [Id]
      ,[IdPergunta]
      ,[IdAutor]
      ,[Descricao]
      ,[Ativo]
      ,[RespostaAceita]
      ,[DataCriacao]
      FROM [dbo].[Resposta]
	  WHERE ID = @Id OR @Id IS NULL

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PostAutor]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PostAutor]
(

 @Nome varchar(200),
 @Email varchar(200)

)
AS

BEGIN
	INSERT INTO [dbo].[Autor]
           ([Nome]
           ,[Email])
     VALUES
           (@Nome,
            @Email)

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PostCategoria]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PostCategoria]
(

 @Descricao varchar(200),
 @Titulo varchar(200),
 @Ativo bit

)
AS

BEGIN
	INSERT INTO [dbo].[Categoria]
           ([Descricao]
           ,[Titulo]
		   ,[Ativo])
     VALUES
           (@Descricao,
            @Titulo,
			@Ativo)

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PostPergunta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PostPergunta]
(

 @Descricao varchar(200),
 @IdAutor int,
 @IdCategoria int,
 @Ativo bit,
 @DataCriacao datetime

)
AS

BEGIN
	INSERT INTO [dbo].[Pergunta]
           ([Descricao]
           ,[IdAutor]
		   ,[IdCategoria]
		   ,[Ativo]
		   ,[DataCriacao])
     VALUES
           (@Descricao,
            @IdAutor,
			@IdCategoria,
			@Ativo,
			@DataCriacao)

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PostResposta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PostResposta]
(

 @Descricao varchar(200),
 @IdPergunta int,
 @IdAutor int,
 @Ativo bit,
 @RespostaAceita bit,
 @DataCriacao datetime

)
AS

BEGIN
	INSERT INTO [dbo].[Resposta]
           ([Descricao]
		   ,[IdPergunta]
           ,[IdAutor]
		   ,[Ativo]
		   ,[RespostaAceita]
		   ,[DataCriacao])
     VALUES
           (@Descricao,
		    @IdPergunta,
            @IdAutor,
			@Ativo,
			@RespostaAceita,
			@DataCriacao)

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PutAutor]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PutAutor]
(
 @Id int,
 @Nome varchar(200),
 @Email varchar(200)

)
AS

BEGIN
	UPDATE  [dbo].[Autor]
	SET [Nome] = @Nome,
		[Email]= @Email
		
    WHERE Id = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PutCategoria]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PutCategoria]
(
 @Id int,
 @Descricao varchar(200),
 @Titulo varchar(200),
 @Ativo bit

)
AS

BEGIN
	UPDATE [dbo].[Categoria]
	SET
            [Descricao] =   @Descricao,
            [Titulo]	=  @Titulo,
		    [Ativo] 	=  @Ativo

     WHERE Id = @Id
            			

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PutPergunta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PutPergunta]
(
 
 @Id int,
 @Descricao varchar(200),
 @IdAutor int,
 @IdCategoria int,
 @Ativo bit,
 @DataCriacao datetime

)
AS

BEGIN
	UPDATE [dbo].[Pergunta]
	SET
           [Descricao]   = @Descricao,
           [IdAutor]	  = @IdAutor,
		   [IdCategoria] =	@IdCategoria,
		   [Ativo]		  = @Ativo,
		   [DataCriacao] = @DataCriacao
    
	WHERE Id = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[PR_PutResposta]    Script Date: 09/11/2018 19:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_PutResposta]
(
 @Id int,
 @Descricao varchar(200),
 @IdPergunta int,
 @IdAutor int,
 @Ativo bit,
 @RespostaAceita bit,
 @DataCriacao datetime

)
AS

BEGIN
	UPDATE  [dbo].[Resposta]
	SET
            [Descricao]       = @Descricao
		   ,[IdPergunta]	  = @IdPergunta
           ,[IdAutor]		  = @IdAutor
		   ,[Ativo]			  = @Ativo
		   ,[RespostaAceita]  = @RespostaAceita
		   ,[DataCriacao]	  = @DataCriacao 

     WHERE Id = @Id

            
		    
            
			
			
			

END

GO
USE [master]
GO
ALTER DATABASE [PerguntasRespostas] SET  READ_WRITE 
GO
