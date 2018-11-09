USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_GetCategoria]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_GetCategoria]
END

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

