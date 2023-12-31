USE [fitnessCenter]
GO
/****** Object:  Database [fitnessCenter]    Script Date: 25.1.2022. 20:46:26 ******/
CREATE DATABASE [fitnessCenter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fitnessCenterUsers', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\fitnessCenterUsers.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fitnessCenterUsers_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\fitnessCenterUsers_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [fitnessCenter] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fitnessCenter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fitnessCenter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fitnessCenter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fitnessCenter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fitnessCenter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fitnessCenter] SET ARITHABORT OFF 
GO
ALTER DATABASE [fitnessCenter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [fitnessCenter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fitnessCenter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fitnessCenter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fitnessCenter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fitnessCenter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fitnessCenter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fitnessCenter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fitnessCenter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fitnessCenter] SET  ENABLE_BROKER 
GO
ALTER DATABASE [fitnessCenter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fitnessCenter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fitnessCenter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fitnessCenter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [fitnessCenter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fitnessCenter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [fitnessCenter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fitnessCenter] SET RECOVERY FULL 
GO
ALTER DATABASE [fitnessCenter] SET  MULTI_USER 
GO
ALTER DATABASE [fitnessCenter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fitnessCenter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [fitnessCenter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [fitnessCenter] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [fitnessCenter] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [fitnessCenter] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'fitnessCenter', N'ON'
GO
ALTER DATABASE [fitnessCenter] SET QUERY_STORE = OFF
GO
USE [fitnessCenter]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 25.1.2022. 20:46:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] NOT NULL,
	[Country] [nvarchar](55) NOT NULL,
	[City] [nvarchar](55) NOT NULL,
	[Street] [nvarchar](55) NOT NULL,
	[AddressNumber] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FitnessCenter]    Script Date: 25.1.2022. 20:46:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FitnessCenter](
	[FitnessCenterId] [nvarchar](7) NOT NULL,
	[Center] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.1.2022. 20:46:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[JMBG] [varchar](13) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[UserType] [varchar](20) NOT NULL,
	[IsRemoved] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Workouts]    Script Date: 25.1.2022. 20:46:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Workouts](
	[WorkoutId] [int] NOT NULL,
	[DateTimeStart] [datetime] NOT NULL,
	[DateTimeEnd] [datetime] NOT NULL,
	[Length] [int] NOT NULL,
	[WorkoutStatus] [varchar](10) NOT NULL,
	[InstructorUserName] [nvarchar](50) NOT NULL,
	[CustomerUserName] [nvarchar](50) NULL,
	[IsRemoved] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (100, N'Srbija', N'Novi Sad', N'Maksima Gorkog', N'11')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (101, N'Srbija', N'Beograd', N'Bulevar Kneza Lazara', N'76')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (102, N'Bosna i Hercegovina', N'Zvornik', N'Svetog Save', N'3')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (103, N'Hrvatska', N'Dubrovnik', N'Mihajla Hamzica', N'1')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (104, N'Srbija', N'Sabac', N'Masarikova', N'46')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (105, N'Srbija', N'Novi Sad', N'Bulevar Jase Tomica', N'22')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (106, N'Crna Gora', N'Niksic', N'Kocanska III', N'10')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (107, N'Srbija', N'Beograd', N'Bulevar Kneza Lazara', N'76')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (108, N'Bosna i Hercegovina', N'Sarajevo', N'Franjevacka', N'29')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (109, N'Srbija', N'Nis', N'Stojana Andrica', N'18')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (110, N'Makedonija', N'Skoplje', N'Maksut Sadikj', N'20')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (111, N'Srbija', N'Sabac', N'Lenjinova', N'20')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (112, N'Srbija', N'Sabac', N'Vladimira Stanimirovica', N'1')
INSERT [dbo].[Addresses] ([AddressId], [Country], [City], [Street], [AddressNumber]) VALUES (113, N'Crna Gora', N'Podgorica', N'Vasa Raickovica', N'27')
GO
INSERT [dbo].[FitnessCenter] ([FitnessCenterId], [Center], [AddressId]) VALUES (N'7133109', N'MagicBoost', 100)
GO
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Petar', N'Petrovic', N'1701988564788', N'petarpetrovic@web.com', 101, N'petar123', N'petar123', N'Male', N'Administrator', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Marina', N'Marinkovic', N'0112996104522', N'marinamarkovic@web.com', 102, N'marina123', N'marina123', N'Female', N'Administrator', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'David', N'Davidovic', N'2511980220300', N'daviddavidovic@web.com', 103, N'david123', N'david123', N'Male', N'Administrator', 1)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Branko', N'Brankovic', N'0607994198720', N'brankobrankovic@web.co', 104, N'branko123', N'branko123', N'Male', N'Instructor', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Milan', N'Milanovic', N'1010001522856', N'milanmilanovic@web.com', 105, N'milan123', N'milan123', N'Male', N'Instructor', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Jovana', N'Jovanic', N'2501992183099', N'jovanajovanic@web.com', 106, N'jovana123', N'jovana123', N'Female', N'Instructor', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Bojana', N'Bojanic', N'1010966174055', N'bojanabojanic@web.com', 107, N'bojana123', N'bojana123', N'Male', N'Customer', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Dragan', N'Dragišic', N'3011968774011', N'dragandragisic@web.com', 108, N'dragan123', N'dragan123', N'Male', N'Customer', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Jovan', N'Jovanovic', N'0210963105421', N'jovanjovanovic@web.com', 109, N'jovan123', N'jovan123', N'Male', N'Customer', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Dejan', N'Dejanic', N'1010995123741', N'dejandejanic@web.com', 110, N'dejan123', N'dejan123', N'Male', N'Customer', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Mirko', N'Mirkovic', N'0203997145855', N'mirkomirkovic@web.com', 111, N'mirkomirkovic2001', N'mirko123', N'Male', N'Instructor', 1)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Petar', N'Markovic', N'1010001522857', N'petarmarkovic001@web.com', 112, N'petarmarkovic', N'petarmarkovic', N'Male', N'Instructor', 0)
INSERT [dbo].[Users] ([Name], [Surname], [JMBG], [Email], [AddressId], [UserName], [Password], [Gender], [UserType], [IsRemoved]) VALUES (N'Klara', N'Ivkov', N'0101981242422', N'klaraivkov@web.com', 113, N'klaraivkov', N'klara123', N'Female', N'Customer', 1)
GO
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (100, CAST(N'2021-11-29T08:00:00.000' AS DateTime), CAST(N'2021-11-29T10:00:00.000' AS DateTime), 120, N'Available', N'branko123', N'', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (101, CAST(N'2021-11-29T10:15:00.000' AS DateTime), CAST(N'2021-11-29T11:15:00.000' AS DateTime), 60, N'Available', N'branko123', N'', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (102, CAST(N'2021-11-29T12:00:00.000' AS DateTime), CAST(N'2021-11-29T14:00:00.000' AS DateTime), 120, N'Available', N'branko123', N'', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (103, CAST(N'2021-11-29T14:15:00.000' AS DateTime), CAST(N'2021-11-29T16:15:00.000' AS DateTime), 120, N'Reserved', N'branko123', N'dragan123', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (104, CAST(N'2021-11-30T14:00:00.000' AS DateTime), CAST(N'2021-11-30T16:00:00.000' AS DateTime), 120, N'Available', N'jovana123', N'', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (105, CAST(N'2021-11-30T14:30:00.000' AS DateTime), CAST(N'2021-11-30T15:30:00.000' AS DateTime), 60, N'Reserved', N'jovana123', N'dragan123', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (106, CAST(N'2021-11-30T16:15:00.000' AS DateTime), CAST(N'2021-11-30T17:15:00.000' AS DateTime), 60, N'Available', N'jovana123', N'', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (107, CAST(N'2021-11-30T11:30:00.000' AS DateTime), CAST(N'2021-11-30T13:00:00.000' AS DateTime), 90, N'Available', N'branko123', N'', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (108, CAST(N'2021-11-30T13:45:00.000' AS DateTime), CAST(N'2021-11-30T15:45:00.000' AS DateTime), 120, N'Reserved', N'milan123', N'bojana123', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (109, CAST(N'2021-12-14T10:00:00.000' AS DateTime), CAST(N'2021-12-14T12:00:00.000' AS DateTime), 120, N'Reserved', N'petarmarkovic', N'bojana123', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (110, CAST(N'2021-12-14T10:30:00.000' AS DateTime), CAST(N'2021-12-14T11:30:00.000' AS DateTime), 60, N'Available', N'branko123', N'', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (111, CAST(N'2021-12-14T12:30:00.000' AS DateTime), CAST(N'2021-12-14T13:30:00.000' AS DateTime), 60, N'Reserved', N'petarmarkovic', N'bojana123', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (112, CAST(N'2021-12-14T15:00:00.000' AS DateTime), CAST(N'2021-12-14T19:00:00.000' AS DateTime), 240, N'Reserved', N'petarmarkovic', N'dejan123', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (113, CAST(N'2021-12-15T14:00:00.000' AS DateTime), CAST(N'2021-12-15T16:00:00.000' AS DateTime), 120, N'Reserved', N'petarmarkovic', N'jovan123', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (114, CAST(N'2021-12-14T02:44:00.000' AS DateTime), CAST(N'2021-12-14T04:44:00.000' AS DateTime), 120, N'Available', N'branko123', N'', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (115, CAST(N'2021-12-15T17:00:00.000' AS DateTime), CAST(N'2021-12-15T20:00:00.000' AS DateTime), 180, N'Available', N'petarmarkovic', N'', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (116, CAST(N'2021-12-15T02:50:00.000' AS DateTime), CAST(N'2021-12-15T04:50:00.000' AS DateTime), 120, N'Reserved', N'jovana123', N'jovan123', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (117, CAST(N'2021-12-11T06:00:00.000' AS DateTime), CAST(N'2021-12-14T08:00:00.000' AS DateTime), 120, N'Available', N'branko123', N'', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (121, CAST(N'2022-01-05T17:00:00.000' AS DateTime), CAST(N'2022-01-05T19:30:00.000' AS DateTime), 150, N'Reserved', N'branko123', N'dejan123', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (118, CAST(N'2021-12-23T03:14:00.000' AS DateTime), CAST(N'2021-12-23T05:14:00.000' AS DateTime), 120, N'Available', N'petarmarkovic', N'', 1)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (119, CAST(N'2021-12-15T18:30:00.000' AS DateTime), CAST(N'2021-12-15T21:00:00.000' AS DateTime), 150, N'Available', N'petarmarkovic', N'', 0)
INSERT [dbo].[Workouts] ([WorkoutId], [DateTimeStart], [DateTimeEnd], [Length], [WorkoutStatus], [InstructorUserName], [CustomerUserName], [IsRemoved]) VALUES (120, CAST(N'2021-12-15T03:00:00.000' AS DateTime), CAST(N'2021-12-15T07:00:00.000' AS DateTime), 240, N'Available', N'petarmarkovic', N'', 0)
GO
/****** Object:  Index [U_Addresses]    Script Date: 25.1.2022. 20:46:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [U_Addresses] ON [dbo].[Addresses]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [U_JMBG]    Script Date: 25.1.2022. 20:46:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [U_JMBG] ON [dbo].[Users]
(
	[JMBG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [U_UserName]    Script Date: 25.1.2022. 20:46:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [U_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [U_Workouts]    Script Date: 25.1.2022. 20:46:27 ******/
ALTER TABLE [dbo].[Workouts] ADD  CONSTRAINT [U_Workouts] UNIQUE NONCLUSTERED 
(
	[WorkoutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__Gender__276EDEB3] CHECK  (([Gender]='Other' OR [Gender]='Female' OR [Gender]='Male'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__Gender__276EDEB3]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__UserType__286302EC] CHECK  (([UserType]='Customer' OR [UserType]='Instructor' OR [UserType]='Administrator'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__UserType__286302EC]
GO
ALTER TABLE [dbo].[Workouts]  WITH CHECK ADD  CONSTRAINT [CK__Workouts__Workou__3B75D760] CHECK  (([WorkoutStatus]='Reserved' OR [WorkoutStatus]='Available'))
GO
ALTER TABLE [dbo].[Workouts] CHECK CONSTRAINT [CK__Workouts__Workou__3B75D760]
GO
USE [master]
GO
ALTER DATABASE [fitnessCenter] SET  READ_WRITE 
GO
