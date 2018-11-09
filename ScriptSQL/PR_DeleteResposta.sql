USE [PerguntasRespostas]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_DeleteResposta]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_DeleteResposta]
END

GO
CREATE PROCEDURE [dbo].[PR_DeleteResposta]
(
 @Id int
 
)
AS

BEGIN
	DELETE FROM  [dbo].[Resposta]
		  
    WHERE Id = @Id
 
END

