USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_user]    Script Date: 07/12/2024 8:34:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_user]
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[User]
    WHERE Id = @Id
END
GO
