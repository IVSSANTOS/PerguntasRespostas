USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PutPergunta]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PutPergunta]
END

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

