USE [EmployeeBenefits]
GO
/****** Object:  Table [dbo].[DependentType]    Script Date: 1/27/2021 3:32:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DependentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dependent] [nvarchar](50) NOT NULL,
	[DependentType] [int] NOT NULL,
 CONSTRAINT [PK_DependentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DependentType] ON 

INSERT [dbo].[DependentType] ([Id], [Dependent], [DependentType]) VALUES (1, N'Children', 1)
INSERT [dbo].[DependentType] ([Id], [Dependent], [DependentType]) VALUES (2, N'Spouse', 2)
SET IDENTITY_INSERT [dbo].[DependentType] OFF
GO
