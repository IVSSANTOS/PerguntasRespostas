USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PostResposta]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PostResposta]
END

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

