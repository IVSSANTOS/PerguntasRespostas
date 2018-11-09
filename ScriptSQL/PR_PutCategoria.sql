USE [PerguntasRespostas]
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[PR_PutCategoria]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[PR_PutCategoria]
END

GO
CREATE PROCEDURE [dbo].[PR_PutCategoria]
(
 @Id int,
 @Descricao varchar(200),
 @Titulo varchar(200),
 @Ativo bit

)
AS

BEGIN
	UPDATE [dbo].[Categoria]
	SET
            [Descricao] =   @Descricao,
            [Titulo]	=  @Titulo,
		    [Ativo] 	=  @Ativo

     WHERE Id = @Id
            			

END

