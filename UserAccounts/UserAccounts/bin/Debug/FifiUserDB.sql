USE [master]
GO
/****** Object:  Database [UserDB]    Script Date: 19.01.2017 17:20:40 ******/
CREATE DATABASE [UserDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserDB', FILENAME = N'C:\Users\fina.meranzova\UserDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UserDB_log', FILENAME = N'C:\Users\fina.meranzova\UserDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UserDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UserDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UserDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UserDB] SET  MULTI_USER 
GO
ALTER DATABASE [UserDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UserDB] SET QUERY_STORE = OFF
GO
USE [UserDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [UserDB]
GO
/****** Object:  Table [dbo].[ADUsers]    Script Date: 19.01.2017 17:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ADName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ADUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Branch]    Script Date: 19.01.2017 17:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[ID] [int] NOT NULL,
	[BranchName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KSC]    Script Date: 19.01.2017 17:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KSC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserID] [int] NOT NULL,
	[TermID] [varchar](20) NOT NULL,
	[UID] [int] NOT NULL,
	[AllowFC] [bit] NOT NULL,
 CONSTRAINT [PK_KSC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 19.01.2017 17:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserMasterData]    Script Date: 19.01.2017 17:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMasterData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[BranchID] [int] NOT NULL,
	[PositionID] [int] NULL,
	[PharmosUserName] [varchar](50) NULL,
	[UADMUserName] [varchar](50) NULL,
	[GI] [bit] NULL,
	[Purchase] [bit] NULL,
	[Tender] [bit] NULL,
	[Phibra] [bit] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_UserMasterData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ADUsers] ON 

INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (1, 1, N'yavor.georgiev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (3, 2, N'fina.meranzova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (4, 3, N'adriana.hristova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (5, 4, N'aishe.parusheva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (6, 5, N'alexandra.doneva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (7, 6, N'aleksandar.nikolov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (8, 7, N'adriana.georgieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (9, 8, N'anzhela.gencheva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (10, 9, N'ani.brezalieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (11, 10, N'anita.hristova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (12, 11, N'bojidar.bojilov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (13, 12, N'boryana.panayotova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (14, 13, N'boryana.sabcheva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (15, 15, N'valya.vladimirova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (16, 16, N'velislav.ivanov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (17, 17, N'velichka.stoilova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (18, 18, N'veselina.vasileva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (19, 19, N'veselina.lukanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (20, 20, N'veska.dimitrova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (21, 21, N'vilislav.dimitrov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (22, 22, N'violeta.uicheva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (23, 23, N'violina.velikova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (24, 24, N'gancho.nyagolov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (25, 25, N'georgi.hantov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (26, 26, N'gergana.zlateva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (27, 27, N'daniela.nikolova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (28, 28, N'desislava.dancheva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (29, 29, N'desislava.lubenova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (30, 30, N'desislava.stefanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (31, 31, N'desislava.todorova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (32, 32, N'diana.georgieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (33, 33, N'dragi.klyankov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (34, 34, N'evelina.petrova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (35, 35, N'elina.todorova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (36, 36, N'eliyana.vladova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (37, 37, N'elka.boyarova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (38, 38, N'emil.tonchev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (39, 39, N'emilia.popova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (40, 40, N'zornica.romova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (41, 41, N'iva.naydenova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (42, 42, N'ivan.kolchakov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (43, 43, N'ivanka.zhekova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (44, 44, N'iveta.isaeva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (45, 45, N'ivo.videnov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (46, 46, N'yoncho.yonchev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (47, 47, N'iskra.atanasova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (48, 48, N'kaloyan.petrov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (49, 49, N'kapka.nikolova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (50, 50, N'katya.jordanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (51, 51, N'krassimir.nikolaev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (52, 52, N'lora.georgieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (53, 53, N'lyubomira.ivanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (54, 54, N'magdalena.tsenova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (55, 55, N'marin.bogdanov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (56, 56, N'marina.dimitrova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (57, 57, N'mariya.alexieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (58, 58, N'maria.gergushka')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (59, 59, N'maria.kisova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (60, 60, N'milena.kelova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (61, 61, N'milena.milcheva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (62, 62, N'miroslava.ruskova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (63, 63, N'nadejda.jelyazkova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (64, 64, N'nadia.ivanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (65, 66, N'nikolay.borisov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (66, 67, N'nikolai.kolev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (67, 68, N'nikolai.staikov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (68, 69, N'novomir.nenchev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (69, 70, N'petranka.vasileva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (70, 71, N'petar.angelov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (71, 72, N'petya.ivanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (72, 73, N'petya.kacarova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (73, 74, N'petya.hristova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (74, 75, N'plamen.hristov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (75, 76, N'radoslav.chelov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (76, 77, N'radostin.dimitrov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (77, 78, N'radostina.pavlova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (78, 79, N'ralica.ivanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (79, 80, N'rosica.gerasimova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (80, 81, N'rositsa.gyushlieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (81, 82, N'svetlana.zahova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (82, 83, N'stanislav.jordanov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (83, 84, N'stanislav.chaushev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (84, 86, N'stela.andreeva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (85, 87, N'stefan.natev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (86, 88, N'stoyan.grachenliev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (87, 89, N'suzana.ilieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (88, 90, N'tanya.angelova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (89, 91, N'theodora.ivanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (90, 92, N'tihomir.tiholov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (91, 93, N'todor.dimitrov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (92, 94, N'fani.dimova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (93, 95, N'hristina.izova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (94, 96, N'hristina.yanakieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (95, 97, N'tzvetanka.vasileva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (96, 98, N'tsvetelina.popovska')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (97, 99, N'julian.nedelchev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (98, 101, N'yavor.todorov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (99, 102, N'yasen.gensuzov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (100, 104, N'vasil.lyutskanov')
GO
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (101, 106, N'daniela.zhelyazkova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (102, 107, N'd.chavdarova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (103, 108, N'ivelina.jotova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (104, 109, N'yordanka.vasileva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (105, 110, N'katya.todorova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (106, 113, N'rositsa.georgieva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (107, 114, N'svetoslav.grabchev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (108, 115, N'hristina.angelova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (110, 117, N'violeta.chobanova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (112, 119, N'detelina.andonova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (113, 120, N'emanuil.kavrakov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (114, 121, N'emil.piperevski')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (115, 122, N'iva.aneva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (116, 123, N'ivan.yurukov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (117, 125, N'marina.kostova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (118, 126, N'petar.kanchev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (119, 127, N'svetla.ninova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (120, 128, N'toni.tonchev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (121, 129, N'hristina.stamenova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (122, 130, N'aneta.preplyuvkova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (123, 131, N'antoaneta.yurukova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (124, 132, N'desislava.hristova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (125, 133, N'diana.popova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (126, 135, N'ivailo.vladimirov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (127, 136, N'ivanka.simeonova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (128, 137, N'ilian.stoev')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (129, 138, N'lachezar.ivanov')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (130, 139, N'lyuba.encheva')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (131, 140, N'maria.i.petrova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (132, 141, N'neli.nikolova')
INSERT [dbo].[ADUsers] ([ID], [UserID], [ADName]) VALUES (133, 142, N'tsvetomir.tsvetkov')
SET IDENTITY_INSERT [dbo].[ADUsers] OFF
INSERT [dbo].[Branch] ([ID], [BranchName]) VALUES (22, N'София')
INSERT [dbo].[Branch] ([ID], [BranchName]) VALUES (23, N'Бургас')
INSERT [dbo].[Branch] ([ID], [BranchName]) VALUES (25, N'Пловдив')
INSERT [dbo].[Branch] ([ID], [BranchName]) VALUES (26, N'Велико Търново')
INSERT [dbo].[Branch] ([ID], [BranchName]) VALUES (28, N'Централ')
SET IDENTITY_INSERT [dbo].[KSC] ON 

INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (2, 22, N'22whgeor', 1, N'226Q
', 772, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (3, 22, N'23ksfina', 2, N'225V
', 741, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (4, 23, N'23ksfina', 2, N'234J
', 675, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (6, 25, N'23ksfina', 2, N'255E
', 719, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (7, 26, N'23ksfina', 2, N'2605
', 675, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (8, 22, N'22ksahri', 3, N'226W', 778, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (9, 22, N'22ksashi', 4, N'224M', 678, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (10, 22, N'22ksdone', 5, N'224G', 672, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (11, 22, N'22ksanik', 6, N'225S', 738, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (12, 22, N'22ksadri', 7, N'224I', 674, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (13, 22, N'26anjela', 8, N'227N', 805, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (14, 22, N'22ksbrez', 9, N'2269', 755, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (15, 22, N'22ksani', 10, N'229L', 875, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (16, 22, N'bojidar', 11, N'225B', 703, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (17, 22, N'boryana', 12, N'225C', 704, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (18, 22, N'26bobi', 13, N'227P', 807, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (19, 22, N'26valia', 15, N'227U', 812, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (20, 22, N'22ksvili', 16, N'229P', 879, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (21, 22, N'22ksveli', 17, N'2286', 824, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (22, 22, N'22ksvesi', 18, N'224R', 683, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (23, 22, N'22ksluka', 19, N'228I', 836, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (24, 22, N'22ksvesk', 20, N'226S', 774, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (25, 22, N'22whdimi', 21, N'2292', 856, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (26, 22, N'25vili', 22, N'2283', 821, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (27, 22, N'24ksvili', 23, N'227C', 794, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (28, 22, N'22whnyg', 24, N'228W', 850, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (29, 22, N'22kshant', 25, N'228J', 837, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (30, 22, N'22sfgeri', 26, N'226E', 760, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (31, 22, N'22dani', 27, N'229C', 866, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (32, 22, N'22fsdesi', 28, N'229I', 872, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (33, 22, N'22desilu', 29, N'2247', 663, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (34, 22, N'22desi', 30, N'228L', 839, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (35, 22, N'22ksdesi', 31, N'224P', 681, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (36, 22, N'22ksdidi', 32, N'225I', 728, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (37, 22, N'22ksdrag', 33, N'2279', 791, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (38, 22, N'22eva', 34, N'229?', 864, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (39, 22, N'23kseli', 35, N'227A', 792, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (40, 22, N'22kseli', 36, N'2297', 861, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (41, 22, N'26elka', 37, N'227Q', 808, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (42, 22, N'22ksemo', 38, N'228C', 830, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (43, 22, N'22kspopo', 39, N'224N', 679, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (44, 22, N'zornitsa', 40, N'2250', 692, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (45, 22, N'22whinay', 41, N'227D', 795, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (46, 22, N'22kskolc', 42, N'224J', 675, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (47, 22, N'22fsdebt', 43, N'226F', 761, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (48, 22, N'22ksivet', 44, N'227F', 797, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (49, 22, N'22ksivo', 45, N'228D', 831, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (50, 22, N'22ksyon', 46, N'228R', 845, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (51, 22, N'22ksiskr', 47, N'228U', 848, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (52, 22, N'22kaloyn', 48, N'2246', 662, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (53, 22, N'22kapka', 49, N'2248', 664, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (54, 22, N'22kskaty', 50, N'2278', 790, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (55, 22, N'22kskras', 51, N'229O', 878, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (56, 22, N'22kslora', 52, N'228E', 832, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (57, 22, N'22ksluba', 53, N'226H', 763, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (58, 22, N'22ksmagi', 54, N'224Q', 682, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (59, 22, N'22whmari', 55, N'226P', 771, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (60, 22, N'22ksdimi', 56, N'229B', 865, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (61, 22, N'22ksalek', 57, N'228K', 838, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (62, 22, N'22ksmari', 58, N'224W', 688, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (63, 22, N'22kskis', 59, N'229N', 877, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (64, 22, N'22whkelo', 60, N'2272', 784, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (65, 22, N'26milena', 61, N'227S', 810, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (66, 22, N'25mira', 62, N'2280', 818, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (67, 22, N'22ksdobr', 63, N'226U', 776, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (68, 22, N'22ksnadi', 64, N'2251', 693, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (69, 22, N'22ksniko', 66, N'228Q', 844, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (70, 22, N'kolev', 67, N'228x', 851, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (71, 22, N'22ksniki', 68, N'228T', 847, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (72, 22, N'22ksnovo', 69, N'2284', 822, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (73, 22, N'22kspetr', 70, N'228B', 829, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (74, 22, N'para', 71, N'224X', 689, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (75, 22, N'26petia', 72, N'227T', 811, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (76, 22, N'22kspeti', 73, N'2271', 783, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (77, 22, N'22kshris', 74, N'2260', 746, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (78, 22, N'22whhri2', 75, N'226I', 764, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (79, 22, N'itrado', 76, N'228Y', 852, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (80, 22, N'r.dimitr', 77, N'229G', 870, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (81, 22, N'22radost', 78, N'228S', 846, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (82, 22, N'22ksrali', 79, N'2287', 825, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (83, 22, N'22fsgera', 80, N'229D', 867, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (84, 22, N'23ksguch', 81, N'227B', 793, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (85, 22, N'itsvetla', 82, N'2259', 701, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (86, 22, N'22kssani', 83, N'226X', 779, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (87, 22, N'itstani', 84, N'225D', 705, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (88, 22, N'22ksstel', 86, N'229Q', 880, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (89, 22, N'22ksnat', 87, N'229K', 874, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (90, 22, N'22itgrac', 88, N'2264', 750, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (91, 22, N'28kssuzi', 89, N'226A', 756, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (92, 22, N'22tanya', 90, N'2298', 862, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (93, 22, N'22ksivan', 91, N'2290', 854, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (94, 22, N'22kstiho', 92, N'227L', 803, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (95, 22, N'22fsdimi', 93, N'229H', 871, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (96, 22, N'25fsdimo', 94, N'229E', 868, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (97, 22, N'23ksfina', 2, N'225V', 741, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (98, 22, N'22ksizov', 95, N'229R', 881, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (99, 22, N'22kshri2', 96, N'228P', 843, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (100, 22, N'24ksceca', 97, N'227H', 799, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (101, 22, N'22KSPOPA', 98, N'228H', 835, 0)
GO
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (102, 22, N'nedelche', 99, N'2244', 660, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (103, 22, N'22whgeor', 1, N'226Q', 772, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (104, 22, N'22whyavo', 101, N'226O', 770, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (105, 23, N'22ksahri', 3, N'2385', 805, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (106, 23, N'22ksashi', 4, N'235Z', 727, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (107, 23, N'22ksdone', 5, N'235S', 720, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (108, 23, N'22ksanik', 6, N'2366', 734, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (109, 23, N'22ksadri', 7, N'2362', 730, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (110, 23, N'26anjela', 8, N'236X', 761, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (111, 23, N'23ksani', 10, N'238I', 818, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (112, 23, N'26bobi', 13, N'236Z', 763, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (113, 23, N'26valia', 15, N'2373', 767, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (114, 23, N'23ksvase', 104, N'234M', 678, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (115, 23, N'22ksvili', 16, N'238M', 822, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (116, 23, N'22ksveli', 17, N'2376', 770, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (117, 23, N'22ksluka', 19, N'237F', 779, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (118, 23, N'22ksvesk', 20, N'2360', 728, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (119, 23, N'25vili', 22, N'236W', 760, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (120, 23, N'24ksvili', 23, N'236G', 744, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (121, 23, N'23dani', 106, N'237U', 794, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (122, 23, N'22dani', 27, N'2387', 807, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (123, 23, N'22desilu', 29, N'235Y', 726, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (124, 23, N'22desi', 30, N'238D', 813, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (125, 23, N'22ksdesi', 31, N'236B', 739, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (126, 23, N'22ksdidi', 32, N'235X', 725, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (127, 23, N'23fschav', 107, N'2350', 692, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (128, 23, N'22ksdrag', 33, N'236F', 743, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (129, 23, N'23kseli', 35, N'234V', 687, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (130, 23, N'22kseli', 36, N'2381', 801, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (131, 23, N'26elka', 37, N'2370', 764, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (132, 23, N'22ksemo', 38, N'237C', 776, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (133, 23, N'22kspopo', 39, N'2364', 732, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (134, 23, N'zornitsa', 40, N'2388', 808, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (135, 23, N'22kskolc', 42, N'235V', 723, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (136, 23, N'22fsdebt', 43, N'235B', 703, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (137, 23, N'28ksiva', 108, N'2353', 695, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (138, 23, N'22ksivet', 44, N'235K', 712, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (139, 23, N'22ksivo', 45, N'237D', 777, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (140, 23, N'23whvasi', 109, N'236H', 745, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (141, 23, N'22ksiskr', 47, N'237N', 787, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (142, 23, N'22kapka', 49, N'235O', 716, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (143, 23, N'22kskaty', 50, N'236E', 742, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (144, 23, N'23kskati', 110, N'234L', 677, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (145, 23, N'22kskras', 51, N'238L', 821, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (146, 23, N'22ksluba', 53, N'2369', 737, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (147, 23, N'22ksmagi', 54, N'2365', 733, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (148, 23, N'22ksdimi', 56, N'2386', 806, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (149, 23, N'22ksalek', 57, N'237G', 780, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (150, 23, N'22ksmari', 58, N'237E', 778, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (151, 23, N'22kskis', 59, N'238K', 820, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (152, 23, N'22whkelo', 60, N'238J', 819, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (153, 23, N'26milena', 61, N'2371', 765, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (154, 23, N'25mira', 62, N'236T', 757, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (155, 23, N'22ksdobr', 63, N'235T', 721, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (156, 23, N'22ksnadi', 64, N'236A', 738, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (157, 23, N'22ksniko', 66, N'237L', 785, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (158, 23, N'22kspetr', 70, N'237B', 775, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (159, 23, N'26petia', 72, N'2372', 766, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (160, 23, N'22kspeti', 73, N'235Q', 718, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (161, 23, N'r.dimitr', 77, N'238E', 814, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (162, 23, N'22radost', 78, N'237T', 793, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (163, 23, N'22ksrali', 79, N'2377', 771, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (164, 23, N'23ksrosi', 113, N'2347', 663, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (165, 23, N'22fsgera', 80, N'2389', 809, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (166, 23, N'23ksguch', 81, N'2356', 698, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (167, 23, N'23svet', 114, N'237M', 786, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (168, 23, N'22kssani', 83, N'235L', 713, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (169, 23, N'22ksstel', 86, N'238N', 823, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (170, 23, N'22ksnat', 87, N'238H', 817, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (171, 23, N'28kssuzi', 89, N'2351', 693, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (172, 23, N'22tanya', 90, N'2382', 802, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (173, 23, N'22kstiho', 92, N'236N', 751, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (174, 23, N'22fsdimi', 93, N'238F', 815, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (175, 23, N'25fsdimo', 94, N'238A', 810, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (176, 23, N'23ksfina', 2, N'234J', 675, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (177, 23, N'23kshris', 115, N'234K', 676, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (178, 23, N'22kshri2', 96, N'237K', 784, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (179, 23, N'24ksceca', 97, N'236I', 746, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (180, 23, N'22KSPOPA', 98, N'238C', 812, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (181, 23, N'nedelche', 99, N'2342', 658, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (182, 25, N'22ksahri', 3, N'258J', 832, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (183, 25, N'22ksashi', 4, N'256G', 757, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (184, 25, N'22ksdone', 5, N'256K', 761, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (185, 25, N'22ksanik', 6, N'256F', 756, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (186, 25, N'22ksadri', 7, N'256E', 755, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (187, 25, N'26anjela', 8, N'2759', 786, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (188, 25, N'22ksani', 10, N'258W', 845, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (189, 25, N'25whanto', 116, N'255K', 725, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (190, 25, N'26bobi', 13, N'257B', 788, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (191, 25, N'26valia', 15, N'257F', 792, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (192, 25, N'22ksvili', 16, N'2590', 849, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (193, 25, N'22ksveli', 17, N'257M', 799, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (194, 25, N'22ksluka', 19, N'257V', 808, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (195, 25, N'22ksvesk', 20, N'256W', 773, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (196, 25, N'25vili', 22, N'2551', 706, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (197, 25, N'25whchob', 117, N'255H', 722, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (198, 25, N'24ksvili', 23, N'257I', 795, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (199, 25, N'25whgena', 118, N'255N', 728, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (200, 25, N'22dani', 27, N'258L', 834, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (201, 25, N'22desilu', 29, N'256C', 753, 0)
GO
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (202, 25, N'22desi', 30, N'258Q', 839, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (203, 25, N'22ksdesi', 31, N'256H', 758, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (204, 25, N'25whnado', 119, N'2571', 778, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (205, 25, N'22ksdidi', 32, N'256I', 759, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (206, 25, N'22ksdrag', 33, N'2570', 777, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (207, 25, N'23kseli', 35, N'257G', 793, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (208, 25, N'22kseli', 36, N'258F', 828, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (209, 25, N'26elka', 37, N'257C', 789, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (210, 25, N'25whkavr', 120, N'255P', 730, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (211, 25, N'25itpipe', 121, N'254Z', 704, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (212, 25, N'22ksemo', 38, N'257S', 805, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (213, 25, N'22kspopo', 39, N'256T', 770, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (214, 25, N'zornitsa', 40, N'258M', 835, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (215, 25, N'25ksiva', 122, N'254S', 697, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (216, 25, N'22kskolc', 42, N'256N', 764, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (217, 25, N'25whyuru', 123, N'255F', 720, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (218, 25, N'22fsdebt', 43, N'255S', 733, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (219, 25, N'22ksivet', 44, N'2566', 747, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (220, 25, N'22ksivo', 45, N'257T', 806, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (221, 25, N'22ksiskr', 47, N'2584', 817, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (222, 25, N'22kapka', 49, N'256D', 754, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (223, 25, N'22kskaty', 50, N'256Z', 776, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (224, 25, N'22kskras', 51, N'258Z', 848, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (225, 25, N'22ksluba', 53, N'256O', 765, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (226, 25, N'22ksmagi', 54, N'256P', 766, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (227, 25, N'22ksdimi', 56, N'258K', 833, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (228, 25, N'25whkost', 125, N'2572', 779, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (229, 25, N'22ksalek', 57, N'257X', 810, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (230, 25, N'22ksmari', 58, N'257U', 807, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (231, 25, N'22kskis', 59, N'258Y', 847, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (232, 25, N'22whkelo', 60, N'258X', 846, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (233, 25, N'26milena', 61, N'257D', 790, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (234, 25, N'25mira', 62, N'2557', 712, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (235, 25, N'22ksdobr', 63, N'256J', 760, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (236, 25, N'22ksnadi', 64, N'256R', 768, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (237, 25, N'22ksniko', 66, N'2582', 815, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (238, 25, N'22kspetr', 70, N'257R', 804, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (239, 25, N'25itkanc', 126, N'254Y', 703, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (240, 25, N'26petia', 72, N'257E', 791, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (241, 25, N'22kspeti', 73, N'256S', 769, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (242, 25, N'r.dimitr', 77, N'258S', 841, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (243, 25, N'22radost', 78, N'2588', 821, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (244, 25, N'22ksrali', 79, N'257N', 800, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (245, 25, N'22fsgera', 80, N'258N', 836, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (246, 25, N'23ksguch', 81, N'257H', 794, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (247, 25, N'25svetla', 127, N'257W', 713, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (248, 25, N'22kssani', 83, N'2567', 748, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (249, 25, N'22ksstel', 86, N'2591', 850, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (250, 25, N'22ksnat', 87, N'258V', 844, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (251, 25, N'22itgrac', 88, N'2569', 750, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (252, 25, N'28kssuzi', 89, N'255R', 732, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (253, 25, N'22tanya', 90, N'258G', 829, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (254, 25, N'22kstiho', 92, N'2577', 784, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (255, 25, N'22fsdimi', 93, N'258T', 842, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (256, 25, N'25ittoni', 128, N'258I', 831, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (257, 25, N'25fsdimo', 94, N'258O', 837, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (258, 25, N'23ksfina', 2, N'255E', 719, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (259, 25, N'25fsstam', 129, N'2576', 783, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (260, 25, N'22kshri2', 96, N'2581', 814, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (261, 25, N'24ksceca', 97, N'257J', 796, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (262, 25, N'22KSPOPA', 98, N'258P', 838, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (263, 25, N'nedelche', 99, N'2542', 658, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (264, 25, N'22whyavo', 101, N'2583', 816, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (265, 26, N'22ksahri', 3, N'263T', 807, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (266, 26, N'22ksashi', 4, N'261M', 728, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (267, 26, N'22ksdone', 5, N'261Q', 732, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (268, 26, N'22ksanik', 6, N'261L', 727, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (269, 26, N'22ksadri', 7, N'261K', 726, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (270, 26, N'26aneta', 130, N'260D', 683, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (271, 26, N'26anjela', 8, N'260O', 694, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (272, 26, N'26toni', 131, N'2615', 711, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (273, 26, N'26bobi', 13, N'260J', 689, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (274, 26, N'26valia', 15, N'260M', 692, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (275, 26, N'22ksvili', 16, N'264A', 824, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (276, 26, N'22ksveli', 17, N'262V', 773, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (277, 26, N'22ksluka', 19, N'2634', 782, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (278, 26, N'22ksvesk', 20, N'2622', 744, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (279, 26, N'25vili', 22, N'262S', 770, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (280, 26, N'24ksvili', 23, N'2629', 751, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (281, 26, N'22dani', 27, N'263V', 809, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (282, 26, N'22desilu', 29, N'261I', 724, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (283, 26, N'22desi', 30, N'2640', 814, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (284, 26, N'22ksdesi', 31, N'261N', 729, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (285, 26, N'26desi', 132, N'260C', 682, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (286, 26, N'22ksdidi', 32, N'261O', 730, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (287, 26, N'26diana', 133, N'260A', 680, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (288, 26, N'22ksdrag', 33, N'2626', 748, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (289, 26, N'26elena', 134, N'2617', 713, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (290, 26, N'23kseli', 35, N'262A', 752, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (291, 26, N'22kseli', 36, N'263Q', 804, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (292, 26, N'26elka', 37, N'260K', 690, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (293, 26, N'22ksemo', 38, N'2631', 779, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (294, 26, N'22kspopo', 39, N'261Z', 741, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (295, 26, N'zornitsa', 40, N'2618', 714, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (296, 26, N'26ivailo', 135, N'260E', 684, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (297, 26, N'22kskolc', 42, N'261T', 735, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (298, 26, N'22fsdebt', 43, N'263L', 799, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (299, 26, N'26ivanka', 136, N'260F', 685, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (300, 26, N'22ksivet', 44, N'261D', 719, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (301, 26, N'22ksivo', 45, N'2632', 780, 0)
GO
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (302, 26, N'26itstoe', 137, N'263J', 797, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (303, 26, N'22ksiskr', 47, N'263D', 791, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (304, 26, N'22kapka', 49, N'261J', 725, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (305, 26, N'22kskaty', 50, N'2625', 747, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (306, 26, N'22kskras', 51, N'2649', 823, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (307, 26, N'24itivan', 138, N'263I', 796, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (308, 26, N'26whench', 139, N'263F', 793, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (309, 26, N'22ksluba', 53, N'261U', 736, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (310, 26, N'22ksmagi', 54, N'261V', 737, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (311, 26, N'22ksdimi', 56, N'263U', 808, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (312, 26, N'22ksalek', 57, N'2635', 783, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (313, 26, N'22ksmari', 58, N'2633', 781, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (314, 26, N'22kskis', 59, N'2648', 822, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (315, 26, N'26maria', 140, N'260G', 686, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (316, 26, N'22whkelo', 60, N'2647', 821, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (317, 26, N'26milena', 61, N'260I', 688, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (318, 26, N'25mira', 62, N'262P', 767, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (319, 26, N'22ksdobr', 63, N'261P', 731, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (320, 26, N'22ksnadi', 64, N'261X', 739, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (321, 26, N'26neli', 141, N'263A', 788, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (322, 26, N'22ksniko', 66, N'263B', 789, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (323, 26, N'22kspetr', 70, N'2630', 778, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (324, 26, N'26petia', 72, N'260L', 691, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (325, 26, N'22kspeti', 73, N'261Y', 740, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (326, 26, N'22kshris', 74, N'261A', 716, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (327, 26, N'22radost', 78, N'263H', 795, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (328, 26, N'22ksrali', 79, N'262W', 774, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (329, 26, N'22fsgera', 80, N'263W', 810, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (330, 26, N'23ksguch', 81, N'262B', 753, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (331, 26, N'22kssani', 83, N'261F', 721, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (332, 26, N'22ksstel', 86, N'264B', 825, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (333, 26, N'22ksnat', 87, N'2645', 819, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (334, 26, N'22tanya', 90, N'263R', 805, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (335, 26, N'22kstiho', 92, N'262I', 760, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (336, 26, N'22fsdimi', 93, N'2643', 817, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (337, 26, N'25fsdimo', 94, N'263X', 811, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (338, 26, N'23ksfina', 2, N'2605', 675, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (339, 26, N'22kshri2', 96, N'2639', 787, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (340, 26, N'24ksceca', 97, N'2627', 749, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (341, 26, N'22KSPOPA', 98, N'263Z', 813, 0)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (342, 26, N'26ittsve', 142, N'2608', 678, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (343, 26, N'nedelche', 99, N'260B', 681, 1)
INSERT [dbo].[KSC] ([ID], [BranchID], [UserName], [UserID], [TermID], [UID], [AllowFC]) VALUES (344, 26, N'22whyavo', 101, N'263C', 790, 0)
SET IDENTITY_INSERT [dbo].[KSC] OFF
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([ID], [Position]) VALUES (1, N'CSC')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (2, N'HR')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (3, N'Аптечен софтуер')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (4, N'Асистент')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (5, N'Бар')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (6, N'Болничен пазар')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (7, N'Дебиторен мениджмънт')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (8, N'Директор логистика')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (9, N'Директор продажби')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (10, N'Доставки')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (11, N'ИСО')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (12, N'ИТ')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (13, N'Контакт център')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (14, N'Контролинг')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (15, N'Отговорен Фармацевт')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (16, N'Манипулант')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (17, N'Маркетинг')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (18, N'Медицинско представителство')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (19, N'Поддръжка')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (20, N'Правен отдел')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (21, N'Приемане на стока')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (22, N'Регионален директор продажби')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (23, N'Рекламации')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (24, N'Рецепция')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (25, N'Регионален мениджър логистика')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (26, N'Регионалем мениджър продажби')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (27, N'Склад')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (28, N'Склад Люлин')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (29, N'Спедиция')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (30, N'Супервайзор')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (31, N'Счетоводство')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (32, N'Телемаркетинг')
INSERT [dbo].[Positions] ([ID], [Position]) VALUES (33, N'Финансов директор')
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[UserMasterData] ON 

INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (1, N'Явор Георгиев', N'y.georgiev@phoenixpharma.bg', 22, 12, N'22WHGEOR', N'y.georgi', 0, 1, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (2, N'Фина Меранзова', N'f.meranzova@phoenixpharma.bg', 23, 12, N'23ITMERA', N'f.meranz', 1, 1, 1, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (3, N'Адриана Христова', N'a.hristova@phoenixpharma.bg', 22, 4, N'22WHRIST', N'a.hristova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (4, N'Айше Парушева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (5, N'Александрина Донева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (6, N'Александър Николов', N'a.nikolov@phoenixpharma.bg', 22, 10, NULL, NULL, 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (7, N'Андриана Георгиева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (8, N'Анжела Генчева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (9, N'Ани Брезалиева', N'a.brezalieva@phoenixpharma.bg', 22, 10, NULL, NULL, 1, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (10, N'Анита Христова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (11, N'Божидар Божилов', N'b.bojilov@phoenixpharma.bg', 22, 29, N'22WHBOJI', N'b.bojilov', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (12, N'Боряна Панайотова', N'b.panayotova@phoenixpharma.bg', 22, 23, N'22WHPANA', N'b.panayotova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (13, N'Боряна Събчева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (14, N'Валерия Назърова', N'v.nazarova@phoenixpharma.bg', 22, 7, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (15, N'Валя Владимирова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (16, N'Велислав Иванов', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (17, N'Величка Стоилова', N'dealers.sf@phoenixpharma.bg', 22, 32, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (18, N'Веселина Василева', N'veselina.vasileva@phoenixpharma.bg', 22, 26, NULL, NULL, 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (19, N'Веселина Луканова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (20, N'Веска Димитрова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (21, N'Вилислав Димитров', N'v.dimitrov@phoenixpharma.bg', 22, 30, N'22WHDIMI', N'v.dimitr', 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (22, N'Виолета Уйчева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (23, N'Виолина Великова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (24, N'Ганчо Нягулов', N'g.nyagolov@phoenixpharma.bg', 22, 30, N'22WHNYAG', N'g.nyagol', 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (25, N'Георги Хантов', N'g.hantov@phoenixpharma.bg', 22, NULL, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (26, N'Гергана Златева', N'g.zlateva@phoenixpharma.bg', 22, 31, N'22FSGERI', N'g.zlateva', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (27, N'Даниела Николова', N'd.nikolova@phoenixpharma.bg', 22, 6, N'22WHNIKO ', N'd.nikolova', 0, 0, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (28, N'Десислава Данчева', N'accounting.sf@phoenixpharma.bg', 22, 31, N'22FSDESI', N'd.dancheva', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (29, N'Десислава Любенова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (30, N'Десислава Стефанова', N'd.stefanova@phoenixpharma.bg', 22, 6, N'22KSSTEF', N'd.stefanova', 0, 0, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (31, N'Десислава Тодорова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (32, N'Диана Георгиева', N'd.georgieva@phoenixpharma.bg', 22, 10, NULL, NULL, 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (33, N'Драги Клянков', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (34, N'Евелина Петрова', N'accounting.sf@phoenixpharma.bg', 22, 31, N'22FSPETR', N'e.petrova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (35, N'Елина Тодорова', N'e.todorova@phoenixpharma.bg', 22, 1, N'23KSTODO', N'e.todorv', 0, 1, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (36, N'Елияна Владова', N'e.vladova@phoenixpharma.bg', 22, 15, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (37, N'Елка Боярова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (38, N'Емил Тончев', N'e.tonchev@phoenixpharma.bg', 22, 22, N'23MGTONC ', N'e.tonchev', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (39, N'Емилия Попова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (40, N'Зорница Ромова', N'z.romova@phoenixpharma.bg', 22, 6, N'22WHROMO', N'z.romova', 0, 1, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (41, N'Ива Найденова', N'i.naydenova@phoenixpharma.bg', 22, 23, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (42, N'Иван Колчаков', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (43, N'Иванка Жекова', N'i.zhekova@phoenixpharma.bg', 22, 7, N'22FSDEBT', N'i.zhekova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (44, N'Ивета Исаева', N'i.isaeva@phoenixpharma.bg', 22, 32, N'22KSISAE', N'i.isaeva', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (45, N'Иво Виденов', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (46, N'Йончо Йончев', N'y.yonchev@phoenixpharma.bg', 22, 26, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (47, N'Искра Атанасова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (48, N'Калоян Петров', N'k.petrov@phoenixpharma.bg', 22, 26, N'23WHPETR', N'k.petrov', 1, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (49, N'Капка Николова', N'k.nikolova@phoenixpharma.bg', 22, 1, N'22KSKAPK', N'k.nikolo', 0, 1, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (50, N'Катя Йорданова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (51, N'Красимир Николаев', N'kr.nikolaev@phoenixpharma.bg', 22, 6, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (52, N'Лора Георгиева', N'l.georgieva@phoenixpharma.bg', 22, 1, N'22KSGEOR', N'l.georgi', 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (53, N'Любомира Иванова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (54, N'Магдалена Ценова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (55, N'Марин Богданов', N'm.bogdanov@phoenixpharma.bg', 22, 27, N'22WHMARI', N'm.bogdanov', 1, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (56, N'Марина Димитрова', N'm.dimitrova@phoenixpharma.bg', 22, 10, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (57, N'Мария Алексиева', N'm.alexieva@phoenixpharma.bg', 22, 10, NULL, NULL, 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (58, N'Мария Гергушка', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (59, N'Мария Кисьова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (60, N'Милена Келова', N'm.kelova@phoenixpharma.bg', 22, 10, N'22WHKELO', N'm.kelova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (61, N'Милена Милчева', N'm.milcheva@phoenixpharma.bg', 22, 6, N'22KSMILC', N'm.milche', 0, 1, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (62, N'Мирослава Рускова', N'm.ruskova@phoenixpharma.bg', 25, 1, N'25KSRUSK', N'm.ruskov', 0, 1, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (63, N'Надежда Желязкова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (64, N'Надя Иванова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (65, N'Нели Ангелова', N'n.kozhuharova@phoenixpharma.bg', 22, 17, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (66, N'Николай Борисов', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (67, N'Николай Колев', N'n.kolev@phoenixpharma.bg', 22, 26, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (68, N'Николай Стайков', N'n.staykov@phoenixpharma.bg', 22, 10, NULL, NULL, 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (69, N'Новомир Ненчев', N'n.nenchev@phoenixpharma.bg', 22, 26, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (70, N'Петранка Василева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (71, N'Петър Ангелов', N'p.angelov@phoenixpharma.bg', 22, 12, N'22ITANGE', N'p.angelov', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (72, N'Петя Иванова', N'dealers.sf@phoenixpharma.bg', 22, 13, N'26KSIVAN', N'p.ivanova', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (73, N'Петя Кацарова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (74, N'Петя Христова', N'p.hristova@phoenixpharma.bg', 22, 6, N'22WHHRIS', N'p.hristova', 0, 0, 1, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (75, N'Пламен Христов', N'p.hristov@phoenixpharma.bg', 22, 10, N'22WHHRI2', N'p.hristo', 0, 1, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (76, N'Радослав Челов', N'r.chelov@phoenixpharma.bg', 22, 12, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (77, N'Радостин Димитров', N'r.dimitrov@phoenixpharma.bg', 22, 33, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (78, N'Радостина Павлова', N'r.pavlova@phoenixpharma.bg', 22, 10, NULL, NULL, 0, 1, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (79, N'Ралица Иванова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (80, N'Росица Герасимова', N'accounting.sf@phoenixpharma.bg', 22, 31, N'22FSGERA', N'r.gerasimova', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (81, N'Росица Гюшлиева', N'dealers.sf@phoenixpharma.bg', 23, 13, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (82, N'Светлана Захова', N's.zahova@phoenixpharma.bg', 22, 12, N'22ITZAHO', N's.zahova', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (83, N'Станислав Йорданов', N'telemarketing@phoenixpharma.bg', 22, 32, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (84, N'Станислав Чаушев', N's.chaushev@phoenixpharma.bg', 22, 12, N'22ITCHAU', N's.chaushev', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (85, N'Старт/пускане на поръчки', NULL, 22, 27, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (86, N'Стела Андреева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (87, N'Стефан Натев', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (88, N'Стоян Граченлиев', N's.grachenliev@phoenixpharma.bg', 22, 12, N'22ITGRAC', N's.granchenliev', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (89, N'Сузана Илиева', N's.ilieva@phoenixpharma.bg', 22, 10, NULL, NULL, 1, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (90, N'Таня Ангелова', N't.angelova@phoenixpharma.bg', 22, 11, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (91, N'Теодора Иванова', N't.ivanova@phoenixpharma.bg', 22, 4, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (92, N'Тихомир Тихолов', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (93, N'Тодор Димитров', N't.dimitrov@phoenixpharma.bg', 22, 7, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (94, N'Фани Димова', N'f.dimova@phoenixpharma.bg', 22, 7, N'25FSDIMO', N'f.dimova', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (95, N'Христина Изова', N'h.izova@phoenixpharma.bg', 22, 6, N'22KSIZOV', N'h.izova', 0, 0, 1, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (96, N'Христина Янакиева', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (97, N'Цветанка Василева', N'c.vasileva@phoenixpharma.bg', 22, 1, N'24KSVASI', N't.vasile', 0, 1, 1, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (98, N'Цветелина Поповска', N't.popovska@phoenixpharma.bg', 22, 6, N'22KSPOPT', N't.popovs', 0, 1, 1, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (99, N'Юлиан Неделчев', N'ju.nedelchev@phoenixpharma.bg', 22, 8, N'22WHNEDE', N'j.nedelchev', 1, 1, 1, 1, 1)
GO
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (100, N'Юлиета Гергова', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (101, N'Явор Тодоров', N'y.todorov@phoenixpharma.bg', 22, 25, N'22WHYAVO', N'y.todorov', 1, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (102, N'Ясен Гeнсузов', N'dealers.sf@phoenixpharma.bg', 22, 13, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (103, N'Валерия Назарова', N'v.nazarova@phoenixpharma.bg', 23, 7, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (104, N'Васил Люцканов', N'v.lyutskanov@phoenixpharma.bg', 23, 12, N'23ITLYUT', N'v.lutzkanov', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (105, N'Габриела Кръстева', N'-', 23, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (106, N'Даниела Желязкова', N'd.zhelyazkova@phoenixpharma.bg', 23, 4, N'23MGZHEL', N'd.zhelyazkova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (107, N'Димитринка Чавдарова', N'd.chavdarova@phoenixpharma.bg', 23, 31, N'23FSCHAV', N'd.chavdarova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (108, N'Ивелина Йотова', N'i.jotova@phoenixpharma.bg', 23, 10, NULL, NULL, 1, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (109, N'Йорданка Василева', N'-', 23, 30, N'23WHVASI', N'y.vasile', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (110, N'Катя Тодорова', N'k.todorova@phoenixpharma.bg', 23, 23, N'23WHTODO', N'k.todorva', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (111, N'Контрола 1', N'-', 23, 27, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (112, N'Контрола 2', N'-', 23, 27, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (113, N'Росица Георгиева', N'r.georgieva@phoenixpharma.bg', 23, 26, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (114, N'Светослав Грабчев', N's.grabchev@phoenixpharma.bg', 23, 26, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (115, N'Христина Ангелова', N'h.angelova@phoenixpharma.bg', 23, 25, N'23WHANGE', N'h.angelova', 1, 1, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (116, N'Антон Чекърлиев', N'-', 25, 27, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (117, N'Виолета Чобанова', N'v.chobanova@phoenixpharma.bg', 25, 23, N'25WHCHOB', N'v.chobanova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (118, N'Генади Николов', N'-', 25, NULL, N'25GINIKO', N'genadi.nikolov', 1, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (119, N'Детелина Андонова', N'd.andonova@phoenixpharma.bg', 25, 15, N'25WHANDO', N'd.andono', 1, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (120, N'Емануил Кавръков', N'returns.pl@phoenixpharma.bg', 25, 27, N'25WHKAVR', N'e.kavrakov', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (121, N'Емил Пиперевски', N'e.piperevski@phoenixgroup.eu', 25, 12, N'25ITPIPE', N'e.piperevski', 0, 1, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (122, N'Ива Анева', N'i.aneva@phoenixpharma.bg', 25, 1, N'25KSANEV', N'i.aneva', 0, 0, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (123, N'Иван Юруков', N'i.yurukov@phoenixpharma.bg', 25, 25, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (124, N'Контрола', N'-', 25, 27, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (125, N'Марина Костова', N'returns.pl@phoenixpharma.bg', 25, 23, N'25WHKOST', N'm.kostova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (126, N'Петър Кънчев', N'p.kanchev@phoenixpharma.bg', 25, 12, N'25ITKANC', N'p.kanchev', 0, 1, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (127, N'Светла Нинова', N's.ninova@phoenixpharma.bg', 25, NULL, N'25MGNINO', N's.ninova', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (128, N'Тони Тончев', N't.tonchev@phoenixpharma.bg', 25, 12, NULL, NULL, 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (129, N'Христина Стаменова', N'h.stamenova@phoenixpharma.bg', 25, 31, N'25FSSTAM', N'h.stamenova', 0, 0, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (130, N'Анета Преплювкова', N'a.preplyuvkova@phoenixpharma.bg', 26, 31, N'26WHPREP', N'a.preplyuvkova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (131, N'Антоанета Юрукова', N'a.yurukova@phoenixpharma.bg', 26, 22, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (132, N'Десислава Христова', N'd.hristova@phoenixpharma.bg', 26, NULL, N'26FSHRIS', N'd.hristova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (133, N'Диана Попова', N'd.popova@phoenixpharma.bg', 26, 1, N'26KSPOPO', N'd.popova', 0, 1, 1, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (134, N'Елена Паневска ', N'returns.vt@phoenixpharma.bg', 26, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (135, N'Ивайло Владимиров', N'i.vladimirov@phoenixpharma.bg', 26, 25, N'26WHVLAD', N'i.vladimirov', 1, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (136, N'Иванка Симеонова', N'i.simeonova@phoenixpharma.bg', 26, 27, N'26WHSIME', N'i.simeonova', 1, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (137, N'Илиан Стоев', N'i.stoev@phoenixpharma.bg', 26, 12, N'26ITSTOE', N'i.stoev', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (138, N'Лъчезар Иванов', N'l.ivanov@phoenixpharma.bg', 26, 12, NULL, NULL, 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (139, N'Люба Енчева', N'returns.vt@phoenixpharma.bg', 26, 23, N'26WHENCH', N'l.enchev', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (140, N'Мария Петрова', N'm.i.petrova@phoenixpharma.bg', 26, 4, N'26MGPETR', N'm.i.petrova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (141, N'Нели Николова', N'returns.vt@phoenixpharma.bg', 26, NULL, N'26WHNIKO', N'n.nikolova', 0, 0, 0, 0, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (142, N'Цветомир Цветков', N'ts.tsvetkov@phoenixpharma.bg', 26, 3, N'26ITTSVE', N't.tsvetk', 0, 1, 0, 1, 1)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (146, N'pesho peshev ', N'blq@blq', 26, 2, N'', N'', 0, 0, 0, 0, 0)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (147, N'delete from UserMasterData where id = 146', N'blq', 28, 2, N'', N'', 0, 0, 0, 0, 0)
INSERT [dbo].[UserMasterData] ([ID], [UserName], [Email], [BranchID], [PositionID], [PharmosUserName], [UADMUserName], [GI], [Purchase], [Tender], [Phibra], [Active]) VALUES (148, N'delete from UserMasterData where id = 146', N'blqq', 25, 2, N'', N'', 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[UserMasterData] OFF
ALTER TABLE [dbo].[ADUsers]  WITH CHECK ADD  CONSTRAINT [FK_ADUsers_UserMasterData] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserMasterData] ([ID])
GO
ALTER TABLE [dbo].[ADUsers] CHECK CONSTRAINT [FK_ADUsers_UserMasterData]
GO
ALTER TABLE [dbo].[KSC]  WITH CHECK ADD  CONSTRAINT [FK_KSC_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([ID])
GO
ALTER TABLE [dbo].[KSC] CHECK CONSTRAINT [FK_KSC_Branch]
GO
ALTER TABLE [dbo].[KSC]  WITH CHECK ADD  CONSTRAINT [FK_KSC_UserMasterData] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserMasterData] ([ID])
GO
ALTER TABLE [dbo].[KSC] CHECK CONSTRAINT [FK_KSC_UserMasterData]
GO
ALTER TABLE [dbo].[UserMasterData]  WITH CHECK ADD  CONSTRAINT [FK_UserMasterData_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([ID])
GO
ALTER TABLE [dbo].[UserMasterData] CHECK CONSTRAINT [FK_UserMasterData_Branch]
GO
ALTER TABLE [dbo].[UserMasterData]  WITH CHECK ADD  CONSTRAINT [FK_UserMasterData_Positions] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Positions] ([ID])
GO
ALTER TABLE [dbo].[UserMasterData] CHECK CONSTRAINT [FK_UserMasterData_Positions]
GO
USE [master]
GO
ALTER DATABASE [UserDB] SET  READ_WRITE 
GO
