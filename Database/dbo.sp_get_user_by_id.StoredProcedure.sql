USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_user_by_id]    Script Date: 07/12/2024 8:34:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_user_by_id]
    @Id INT
AS
BEGIN
    SELECT [Id], [Name], [Age], [PhoneNumber], [DateofBirth], [Time], [IsAvailabele], [Qualification], [Emirates]
    FROM [dbo].[User]
    WHERE [Id] = @Id
END
GO
