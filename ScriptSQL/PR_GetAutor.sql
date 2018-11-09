USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_GetAutor]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_GetAutor]
END

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

