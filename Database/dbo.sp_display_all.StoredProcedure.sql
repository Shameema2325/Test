USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[sp_display_all]    Script Date: 07/12/2024 8:34:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_display_all]
AS
BEGIN
    SELECT * FROM [dbo].[User]
END
GO
