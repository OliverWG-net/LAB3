USE [master]
GO
/****** Object:  Database [LAB2]    Script Date: 05/01/2025 22:39:41 ******/
CREATE DATABASE [LAB2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LAB2', FILENAME = N'C:\Users\olive\LAB2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LAB2_log', FILENAME = N'C:\Users\olive\LAB2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LAB2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LAB2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LAB2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LAB2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LAB2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LAB2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LAB2] SET ARITHABORT OFF 
GO
ALTER DATABASE [LAB2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LAB2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LAB2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LAB2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LAB2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LAB2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LAB2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LAB2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LAB2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LAB2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LAB2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LAB2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LAB2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LAB2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LAB2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LAB2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LAB2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LAB2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LAB2] SET  MULTI_USER 
GO
ALTER DATABASE [LAB2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LAB2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LAB2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LAB2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LAB2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LAB2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LAB2] SET QUERY_STORE = OFF
GO
USE [LAB2]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[PersonalID] [int] IDENTITY(1,1) NOT NULL,
	[FNamn] [nvarchar](30) NULL,
	[LNamn] [nvarchar](30) NULL,
	[Personnummer] [nvarchar](20) NULL,
	[Position] [nvarchar](30) NULL,
	[Avdelning] [nvarchar](30) NULL,
	[Lön] [int] NULL,
	[Anställningsdatum] [date] NULL,
 CONSTRAINT [PK__Personal__283437138200A955] PRIMARY KEY CLUSTERED 
(
	[PersonalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PersonalLista]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PersonalLista] AS
SELECT FNamn, LNamn, Position, Anställningsdatum, DATEDIFF(YEAR, Anställningsdatum, GETDATE())
AS 'Antal år'
FROM Personal;
GO
/****** Object:  Table [dbo].[Betyg]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Betyg](
	[BetygID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[FkKursID] [int] NULL,
	[LärareID] [int] NULL,
	[BetygsDatum] [date] NULL,
	[Betyg] [int] NULL,
 CONSTRAINT [PK__Betyg__E90ED04896A6D329] PRIMARY KEY CLUSTERED 
(
	[BetygID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klass]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klass](
	[KlassID] [int] IDENTITY(1,1) NOT NULL,
	[KlassNamn] [nvarchar](25) NULL,
 CONSTRAINT [PK__Klass__CF47A60D67C4207F] PRIMARY KEY CLUSTERED 
(
	[KlassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kurs]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kurs](
	[KursID] [int] IDENTITY(1,1) NOT NULL,
	[KursNamn] [nvarchar](30) NULL,
	[FkLärareID] [int] NULL,
	[Aktiv] [bit] NOT NULL,
 CONSTRAINT [PK__Kurs__BCCFFF3B29239B38] PRIMARY KEY CLUSTERED 
(
	[KursID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NULL,
	[Personnummer] [nvarchar](15) NOT NULL,
	[FkKlassID] [int] NULL,
 CONSTRAINT [PK__Student__32C52A79BB031664] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Betyg] ON 

INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (1, 1, 1, 1, CAST(N'2024-11-20' AS Date), 5)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (2, 2, 1, 1, CAST(N'2024-11-20' AS Date), 4)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (3, 3, 2, 3, CAST(N'2024-11-20' AS Date), 3)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (4, 4, 1, 1, CAST(N'2024-11-20' AS Date), 5)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (5, 5, 3, 5, CAST(N'2024-11-20' AS Date), 1)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (6, 6, 3, 5, CAST(N'2024-11-20' AS Date), 0)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (7, 7, 5, 7, CAST(N'2024-11-20' AS Date), 2)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (8, 8, 6, 10, CAST(N'2024-11-20' AS Date), 3)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (9, 9, 4, 3, CAST(N'2024-11-20' AS Date), 2)
INSERT [dbo].[Betyg] ([BetygID], [StudentID], [FkKursID], [LärareID], [BetygsDatum], [Betyg]) VALUES (10, 10, 5, 7, CAST(N'2024-11-20' AS Date), 4)
SET IDENTITY_INSERT [dbo].[Betyg] OFF
GO
SET IDENTITY_INSERT [dbo].[Klass] ON 

INSERT [dbo].[Klass] ([KlassID], [KlassNamn]) VALUES (1, N'NET24')
INSERT [dbo].[Klass] ([KlassID], [KlassNamn]) VALUES (2, N'NET23')
INSERT [dbo].[Klass] ([KlassID], [KlassNamn]) VALUES (3, N'NET22')
SET IDENTITY_INSERT [dbo].[Klass] OFF
GO
SET IDENTITY_INSERT [dbo].[Kurs] ON 

INSERT [dbo].[Kurs] ([KursID], [KursNamn], [FkLärareID], [Aktiv]) VALUES (1, N'C#', 1, 1)
INSERT [dbo].[Kurs] ([KursID], [KursNamn], [FkLärareID], [Aktiv]) VALUES (2, N'Databaser', 3, 1)
INSERT [dbo].[Kurs] ([KursID], [KursNamn], [FkLärareID], [Aktiv]) VALUES (3, N'API', 5, 1)
INSERT [dbo].[Kurs] ([KursID], [KursNamn], [FkLärareID], [Aktiv]) VALUES (4, N'JAVA', 3, 1)
INSERT [dbo].[Kurs] ([KursID], [KursNamn], [FkLärareID], [Aktiv]) VALUES (5, N'Agila Metoder', 7, 1)
INSERT [dbo].[Kurs] ([KursID], [KursNamn], [FkLärareID], [Aktiv]) VALUES (6, N'Azure', 10, 1)
SET IDENTITY_INSERT [dbo].[Kurs] OFF
GO
SET IDENTITY_INSERT [dbo].[Personal] ON 

INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (0, N'Johan', N'Rask                ', N'890611-4593', N'Väktare', N'Säkerhet', 24000, CAST(N'2010-08-06' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (1, N'Anna ', N'Johansson           ', N'720506-6321', N'Lärare', N'Skolverket', 22000, CAST(N'2011-06-02' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (2, N'Johan ', N'Ek                  ', N'821012-8652', N'Administration', N'Sekretess', 26000, CAST(N'2014-12-22' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (3, N'Magnus ', N'Svensson            ', N'900120-8541', N'Lärare', N'Skolverket', 22000, CAST(N'2016-09-10' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (4, N'Jonas ', N'Eliasson            ', N'950923-2412', N'Vaktmästare', N'Miljö', 20000, CAST(N'2019-01-30' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (5, N'Malin ', N'Alm                 ', N'991130-2589', N'Lärare', N'Skolverket', 22000, CAST(N'2022-09-26' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (6, N'Henric ', N'Ohlsson             ', N'680112-7786', N'Rektor', N'Skolverket', 34000, CAST(N'2015-02-14' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (7, N'Max', N'Tall                ', N'960310-3648', N'Lärare', N'Skolverket', 26000, CAST(N'2023-05-17' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (9, N'Erik', N'Eriksson            ', N'970522-8652', N'Väktare', N'Säkerhet', 24000, CAST(N'2016-03-28' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (10, N'Karin', N'Karinsson           ', N'1999-12-24', N'Lärare', N'Skolverket', 22000, CAST(N'2014-01-11' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (11, N'Monka', N'Micheal', N'810210-7862', N'Lärare', N'Skolverket', 28000, CAST(N'2024-11-01' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (12, N'Oliver', N'Garderud', N'8903254789', N'Lärare', N'Skolverket', 28000, CAST(N'2016-02-26' AS Date))
INSERT [dbo].[Personal] ([PersonalID], [FNamn], [LNamn], [Personnummer], [Position], [Avdelning], [Lön], [Anställningsdatum]) VALUES (13, N'Nathalie', N'Höst', N'0103085693', N'Lärare', N'Skolverket', 24000, CAST(N'2025-01-04' AS Date))
SET IDENTITY_INSERT [dbo].[Personal] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (0, N'Oliver', N'Williams', N'970310-5693', 1)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (1, N'Anna', N'Ek', N'060511-4593', 1)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (2, N'Johan', N'Johansson', N'051121-5352', 1)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (3, N'Emma', N'Sej', N'010117-5582', 2)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (4, N'Jesper', N'Tall', N'030415-5828', 2)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (5, N'Erik', N'Eriksson', N'030730-8424', 3)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (6, N'Johanna', N'Andersson', N'040611-4858', 1)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (7, N'Petter', N'Zoom', N'061928-9634', 1)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (8, N'Maja', N'Troj', N'051826-9752', 3)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (9, N'Jonas', N'Hamn', N'050817-4158', 2)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (10, N'Camilla', N'Ren', N'2004-02-23', 2)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (11, N'Johan', N'Karlsson', N'040826-7822', 1)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Personnummer], [FkKlassID]) VALUES (12, N'Jonas', N'Örn', N'0310248974', 1)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
ALTER TABLE [dbo].[Kurs] ADD  CONSTRAINT [DF_Kurs_Aktiv]  DEFAULT ((1)) FOR [Aktiv]
GO
ALTER TABLE [dbo].[Betyg]  WITH CHECK ADD  CONSTRAINT [FK__Betyg__KursID__3C69FB99] FOREIGN KEY([FkKursID])
REFERENCES [dbo].[Kurs] ([KursID])
GO
ALTER TABLE [dbo].[Betyg] CHECK CONSTRAINT [FK__Betyg__KursID__3C69FB99]
GO
ALTER TABLE [dbo].[Betyg]  WITH CHECK ADD  CONSTRAINT [FK__Betyg__LärareID__3D5E1FD2] FOREIGN KEY([LärareID])
REFERENCES [dbo].[Personal] ([PersonalID])
GO
ALTER TABLE [dbo].[Betyg] CHECK CONSTRAINT [FK__Betyg__LärareID__3D5E1FD2]
GO
ALTER TABLE [dbo].[Betyg]  WITH CHECK ADD  CONSTRAINT [FK__Betyg__StudentID__3B75D760] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Betyg] CHECK CONSTRAINT [FK__Betyg__StudentID__3B75D760]
GO
ALTER TABLE [dbo].[Kurs]  WITH CHECK ADD  CONSTRAINT [FK__Kurs__LärareID__38996AB5] FOREIGN KEY([FkLärareID])
REFERENCES [dbo].[Personal] ([PersonalID])
GO
ALTER TABLE [dbo].[Kurs] CHECK CONSTRAINT [FK__Kurs__LärareID__38996AB5]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK__Student__KlassID__35BCFE0A] FOREIGN KEY([FkKlassID])
REFERENCES [dbo].[Klass] ([KlassID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK__Student__KlassID__35BCFE0A]
GO
/****** Object:  StoredProcedure [dbo].[AddPersonel]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPersonel]
	@FNamn NVARCHAR(30),
	@LNamn NVARCHAR(30),
	@Personnummer NVARCHAR(20),
	@Position NVARCHAR (30),
	@Avdelning NVARCHAR(30),
	@Lön INT,
	@Anställningsdatum DATE
AS
BEGIN
	INSERT INTO Personal (Fnamn, LNamn, Personnummer, Position, Avdelning, Lön)
	VALUES(@FNamn, @LNamn, @Personnummer, @Position, @Avdelning, @Lön)
END;
GO
/****** Object:  StoredProcedure [dbo].[AddStudent]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStudent]
	@FirstName NVARCHAR(30),
	@LastName NVARCHAR(30),
	@Personnummer NVARCHAR(15),
	@FkKlassID INT
AS
GO
/****** Object:  StoredProcedure [dbo].[Studentinfo]    Script Date: 05/01/2025 22:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Studentinfo]
	@StudentID INT
	AS
	SELECT * FROM Student
	WHERE StudentID = @StudentID
GO
USE [master]
GO
ALTER DATABASE [LAB2] SET  READ_WRITE 
GO
