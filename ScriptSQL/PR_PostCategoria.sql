USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PostCategoria]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PostCategoria]
END

GO
CREATE PROCEDURE [dbo].[PR_PostCategoria]
(

 @Descricao varchar(200),
 @Titulo varchar(200),
 @Ativo bit

)
AS

BEGIN
	INSERT INTO [dbo].[Categoria]
           ([Descricao]
           ,[Titulo]
		   ,[Ativo])
     VALUES
           (@Descricao,
            @Titulo,
			@Ativo)

END

