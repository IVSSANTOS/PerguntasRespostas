USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_GetResposta]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_GetResposta]
END

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

