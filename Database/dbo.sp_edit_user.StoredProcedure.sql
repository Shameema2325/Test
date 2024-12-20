USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[sp_edit_user]    Script Date: 07/12/2024 8:34:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_edit_user]
    @Id INT,
    @Name NVARCHAR(100),
    @Age INT,
    @PhoneNumber NVARCHAR(15),
    @DateOfBirth DATE,
    @Time DATETIME,
    @IsAvailable BIT,
    @Qualification NVARCHAR(50),
    @Emirates NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[User]
    SET 
        [Name] = @Name,
        [Age] = @Age,
        [PhoneNumber] = @PhoneNumber,
        [DateofBirth] = @DateOfBirth,
        [Time] = @Time,
        [IsAvailabele] = @IsAvailable,
        [Qualification] = @Qualification,
        [Emirates] = @Emirates
    WHERE Id = @Id
END
GO
