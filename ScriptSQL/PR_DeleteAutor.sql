USE [PerguntasRespostas]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_DeleteAutor]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_DeleteAutor]
END

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

