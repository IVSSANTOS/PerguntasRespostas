USE [PerguntasRespostas]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[CC]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_DeleteCategoria]
END

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

