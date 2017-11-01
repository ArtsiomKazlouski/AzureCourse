/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([Id], [Name], [Author], [Price]) VALUES (1, N'Война и мир', N'Л. Толстой', 220)
GO
INSERT [dbo].[Books] ([Id], [Name], [Author], [Price]) VALUES (2, N'Отцы и дети', N'И. Тургенев', 180)
GO
INSERT [dbo].[Books] ([Id], [Name], [Author], [Price]) VALUES (3, N'Чайка', N'А. Чехов', 150)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 
GO
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (1, N'Реал Мадрид ', N'Анчелотти')
GO
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (2, N'Барселона', N'Мартино')
GO
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (3, N'Бавария', N'Гуардиолла')
GO
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (4, N'Белоруссия', N'Клоп')
GO
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET IDENTITY_INSERT [dbo].[Players] ON 
GO
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (1, N'Месси', 26, N'Нападающий', 2)
GO
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (2, N'Рональду', 29, N'Нападающий', 1)
GO
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (3, N'Бейл', 24, N'Полузащитник', 2)
GO
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (4, N'Неймар', 22, N'Нападающий', 1)
GO
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (5, N'Иньеста', 29, N'Полузащитник', 2)
GO
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (6, N'Рибери', 30, N'Полузащитник', 3)
GO
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (7, N'Куприянов', 27, N'Вратарь', 4)
GO
SET IDENTITY_INSERT [dbo].[Players] OFF
GO

SET IDENTITY_INSERT [dbo].[Courses] ON 
GO
INSERT [dbo].[Courses] ([Id], [Name]) VALUES (1, N'Операционные системы')
GO
INSERT [dbo].[Courses] ([Id], [Name]) VALUES (2, N'Алгоритмы и структуры данных')
GO
INSERT [dbo].[Courses] ([Id], [Name]) VALUES (3, N'Основы HTML и CSS')
GO
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 
GO
INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (1, N'Егор', N'Иванов')
GO
INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (2, N'Мария', N'Васильева')
GO
INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (3, N'Олег', N'Кузнецов')
GO
INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (4, N'Ольга', N'Петрова')
GO
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (1, 1)
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (3, 1)
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (1, 2)
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (2, 2)
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (1, 3)
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (3, 3)
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (2, 4)
GO
INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (3, 4)
GO


