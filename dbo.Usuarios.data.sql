SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Contrasenia], [Rol], [Estado]) VALUES (1, N'Maverick', N'Patron', N'mavericklopez@gmail.com', N'mavericklopez', 1, 1)
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Contrasenia], [Rol], [Estado]) VALUES (3, N'Maverick', N'Lopez', N'maverick@gmail.com', N'maverick', 0, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
