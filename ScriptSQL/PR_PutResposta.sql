USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PutResposta]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PutResposta]
END

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

