USE [Test]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07/12/2024 8:34:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Age] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[DateofBirth] [date] NOT NULL,
	[Time] [datetime] NOT NULL,
	[IsAvailabele] [bit] NOT NULL,
	[Qualification] [varchar](50) NOT NULL,
	[Emirates] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
