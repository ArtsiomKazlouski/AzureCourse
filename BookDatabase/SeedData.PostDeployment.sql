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

IF @Version = 0
BEGIN
  SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [Author], [Price]) VALUES (1, N'Война и мир', N'Л. Толстой', 220)

INSERT [dbo].[Books] ([Id], [Name], [Author], [Price]) VALUES (2, N'Отцы и дети', N'И. Тургенев', 180)

INSERT [dbo].[Books] ([Id], [Name], [Author], [Price]) VALUES (3, N'Чайка', N'А. Чехов', 150)

SET IDENTITY_INSERT [dbo].[Books] OFF

SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (1, N'Реал Мадрид ', N'Анчелотти')

INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (2, N'Барселона', N'Мартино')

INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (3, N'Бавария', N'Гуардиолла')

INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (4, N'Белоруссия', N'Клоп')

SET IDENTITY_INSERT [dbo].[Teams] OFF

SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (1, N'Месси', 26, N'Нападающий', 2)

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (2, N'Рональду', 29, N'Нападающий', 1)

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (3, N'Бейл', 24, N'Полузащитник', 2)

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (4, N'Неймар', 22, N'Нападающий', 1)

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (5, N'Иньеста', 29, N'Полузащитник', 2)

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (6, N'Рибери', 30, N'Полузащитник', 3)

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (7, N'Куприянов', 27, N'Вратарь', 4)

SET IDENTITY_INSERT [dbo].[Players] OFF


SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name]) VALUES (1, N'Операционные системы')

INSERT [dbo].[Courses] ([Id], [Name]) VALUES (2, N'Алгоритмы и структуры данных')

INSERT [dbo].[Courses] ([Id], [Name]) VALUES (3, N'Основы HTML и CSS')

SET IDENTITY_INSERT [dbo].[Courses] OFF

SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (1, N'Егор', N'Иванов')

INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (2, N'Мария', N'Васильева')

INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (3, N'Олег', N'Кузнецов')

INSERT [dbo].[Students] ([Id], [Name], [Surname]) VALUES (4, N'Ольга', N'Петрова')

SET IDENTITY_INSERT [dbo].[Students] OFF

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (1, 1)

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (3, 1)

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (1, 2)

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (2, 2)

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (1, 3)

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (3, 3)

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (2, 4)

INSERT [dbo].[CourseStudent] ([CourseId], [StudentId]) VALUES (3, 4)

INSERT [dbo].[DataDatabaseVersion]([Version]) VALUES (1)
END





