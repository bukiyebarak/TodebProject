USE [GraduationProject]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Electricity] [real] NOT NULL,
	[Water] [real] NOT NULL,
	[NaturalGas] [real] NOT NULL,
	[Dues] [real] NOT NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Homes]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Homes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Block] [nvarchar](1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Floor] [nvarchar](max) NULL,
	[No] [int] NOT NULL,
	[ApartmentStatus] [int] NOT NULL,
 CONSTRAINT [PK_Homes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HomeId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Picture] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPasswords]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPasswords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
 CONSTRAINT [PK_UserPasswords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Permission] [int] NOT NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15.08.2022 02:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[LicensePlateNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220729152112_firstMigration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220804182919_AddUserAndUserPassword', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220804221050_UserPasswordChange', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220807094646_DatabaseEditting', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220807140236_AddBillApartmentMessageTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220807191807_AddImage', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808212420_EditApartment', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808213608_AddHome', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220809160528_EditBill', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220812201831_EditDatabase', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220814213717_AddUserPermission', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220814215726_EditUserPermission', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([Id], [UserId], [Electricity], [Water], [NaturalGas], [Dues]) VALUES (4, 1, 10, 10, 10, 10)
INSERT [dbo].[Bills] ([Id], [UserId], [Electricity], [Water], [NaturalGas], [Dues]) VALUES (18, 1, 10, 4.4, 5.6, 1.2)
INSERT [dbo].[Bills] ([Id], [UserId], [Electricity], [Water], [NaturalGas], [Dues]) VALUES (19, 2, 20, 50, 40, 70)
INSERT [dbo].[Bills] ([Id], [UserId], [Electricity], [Water], [NaturalGas], [Dues]) VALUES (20, 2, 10, 20, 50, 80)
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Homes] ON 

INSERT [dbo].[Homes] ([Id], [Block], [UserId], [Type], [Floor], [No], [ApartmentStatus]) VALUES (2, N'A', 1, N'2+1', N'4', 1, 1)
INSERT [dbo].[Homes] ([Id], [Block], [UserId], [Type], [Floor], [No], [ApartmentStatus]) VALUES (3, N'A', 1, N'2+1', N'4', 1, 1)
INSERT [dbo].[Homes] ([Id], [Block], [UserId], [Type], [Floor], [No], [ApartmentStatus]) VALUES (4, N'C', 2, N'2+1', N'4', 5, 1)
INSERT [dbo].[Homes] ([Id], [Block], [UserId], [Type], [Floor], [No], [ApartmentStatus]) VALUES (5, N'A', 2, N'5+1', N'5', 5, 1)
INSERT [dbo].[Homes] ([Id], [Block], [UserId], [Type], [Floor], [No], [ApartmentStatus]) VALUES (6, N'A', 2, N'5+1', N'5', 5, 1)
SET IDENTITY_INSERT [dbo].[Homes] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [Name], [Subject], [Email], [Phone], [Note]) VALUES (2, N'ali', N'bill', N'ali@gmal.com', N'1234567890', N'fatura ödendi')
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPasswords] ON 

INSERT [dbo].[UserPasswords] ([Id], [UserId], [PasswordSalt], [PasswordHash]) VALUES (1, 2, 0x97DCAA94EAB0A2276014F3DAC6D071876823C014423311BBC991A146D5B7F20607CAC69272F84EACA14C5E02E1C459D1E1A2990942F84C890AA37E971E07E0E191B74685A19727D76AD9686DE16A1C361BA861B1220661F219EF05AD46B885FA2E77F16B5D455CA42B29454B9B3928BF0E39AF5B74AE329BD98CC7B1B4F6485C, 0x53BABFA53553EE336230BD5D9DC61896D689BC860D4C5626D369F70A3DA4F1D0E9F470578122FEF9D6AECA373C51A11D26BC5620CC15E94D57B1F1101CEB9511)
INSERT [dbo].[UserPasswords] ([Id], [UserId], [PasswordSalt], [PasswordHash]) VALUES (2, 1, 0x2BA7383B836A3111AEBDCCBB5C02C75370A54982EF3602E620E447C7E698F3B093472E9EF495B6E9776E06F32F88766194BA1124EEC9D47944BCD5B2CE32646E87DED2ECC9FFF814E201CC54248E2A96266294CA5DDBCF06E239C422EA60AF444E1435A6B9B703E6994EEFBB65F101C035B1D2CF50FFD750C1F8ADA3A0839920, 0x3EE741D9BCE6E323201BF0D18CC80CEA813BCBD9E872621DB3676829CBAD4FA629B9AD4FA964949A22A296410C0281C623AA59104DC6BC53E5EEE07B6C9A2EC5)
INSERT [dbo].[UserPasswords] ([Id], [UserId], [PasswordSalt], [PasswordHash]) VALUES (5, 5, 0x3CDBAF124296D01A3D210DDFE11AEC58A602559F37CA9560E81D4D29E565D8C00950F47C12D2C226E22F228DEF6BFA01EE18B569017AEB911AA4827425C0BC4827F82D770294E4256FE5AB47D4D8B13857CB8D96B31BA54262663628FC278E71C91E924CD30A4D0A5AF8B8F818F160658057C6B3E887988866C92DA1E36CD43D, 0xE007D2A7F627D26D257D70760E35D2EB1118721E3FB4829854566EDCE466D149BE4951F1CD9EAED5737424FE97B87E42CEBA24601F5B490F6DB868E65B8189ED)
SET IDENTITY_INSERT [dbo].[UserPasswords] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPermissions] ON 

INSERT [dbo].[UserPermissions] ([Id], [UserId], [Permission]) VALUES (1, 5, 1)
INSERT [dbo].[UserPermissions] ([Id], [UserId], [Permission]) VALUES (2, 5, 2)
INSERT [dbo].[UserPermissions] ([Id], [UserId], [Permission]) VALUES (3, 5, 3)
INSERT [dbo].[UserPermissions] ([Id], [UserId], [Permission]) VALUES (4, 5, 4)
SET IDENTITY_INSERT [dbo].[UserPermissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Role], [Name], [Surname], [Email], [Phone], [LicensePlateNumber]) VALUES (1, 1, N'bukiye', NULL, N'b@gmail.com', NULL, NULL)
INSERT [dbo].[Users] ([Id], [Role], [Name], [Surname], [Email], [Phone], [LicensePlateNumber]) VALUES (2, 1, N'bukiye', NULL, N'b@gmail.com', NULL, NULL)
INSERT [dbo].[Users] ([Id], [Role], [Name], [Surname], [Email], [Phone], [LicensePlateNumber]) VALUES (5, 1, N'ali', NULL, N'a@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Users_UserId]
GO
ALTER TABLE [dbo].[Homes]  WITH CHECK ADD  CONSTRAINT [FK_Homes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Homes] CHECK CONSTRAINT [FK_Homes_Users_UserId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Homes_HomeId] FOREIGN KEY([HomeId])
REFERENCES [dbo].[Homes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Homes_HomeId]
GO
ALTER TABLE [dbo].[UserPasswords]  WITH CHECK ADD  CONSTRAINT [FK_UserPasswords_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPasswords] CHECK CONSTRAINT [FK_UserPasswords_Users_UserId]
GO
ALTER TABLE [dbo].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_Users_UserId]
GO
