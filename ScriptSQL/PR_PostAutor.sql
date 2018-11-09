USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PostAutor]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PostAutor]
END

GO
CREATE PROCEDURE [dbo].[PR_PostAutor]
(

 @Nome varchar(200),
 @Email varchar(200)

)
AS

BEGIN
	INSERT INTO [dbo].[Autor]
           ([Nome]
           ,[Email])
     VALUES
           (@Nome,
            @Email)

END

