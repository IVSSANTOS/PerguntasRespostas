USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PutAutor]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PutAutor]
END

GO
CREATE PROCEDURE [dbo].[PR_PutAutor]
(
 @Id int,
 @Nome varchar(200),
 @Email varchar(200)

)
AS

BEGIN
	UPDATE  [dbo].[Autor]
	SET [Nome] = @Nome,
		[Email]= @Email
		
    WHERE Id = @Id

END

