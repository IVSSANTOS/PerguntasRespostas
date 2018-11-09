USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PostPergunta]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PostPergunta]
END

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

