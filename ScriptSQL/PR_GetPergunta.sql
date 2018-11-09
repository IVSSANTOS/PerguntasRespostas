USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_GetPergunta]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_GetPergunta]
END

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

