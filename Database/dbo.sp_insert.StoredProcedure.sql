USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert]    Script Date: 07/12/2024 8:34:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert]
    @Name NVARCHAR(100),
    @Age INT,
    @PhoneNumber NVARCHAR(15),
    @DateOfBirth DATE,
    @Time DATETIME,
    @IsAvailable BIT,
    @Qualification NVARCHAR(200),
    @Emirates NVARCHAR(50)
AS
BEGIN
    INSERT INTO [User] (Name, Age, PhoneNumber, DateOfBirth, Time, IsAvailabele, Qualification, Emirates)
    VALUES (@Name, @Age, @PhoneNumber, @DateOfBirth, @Time, @IsAvailable, @Qualification, @Emirates)
END
GO
