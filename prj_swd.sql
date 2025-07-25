USE [master]
GO
/****** Object:  Database [PRJ_SWD]    Script Date: 6/23/2025 10:22:17 AM ******/
CREATE DATABASE [PRJ_SWD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRJ_SWD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.QUY\MSSQL\DATA\PRJ_SWD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRJ_SWD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.QUY\MSSQL\DATA\PRJ_SWD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PRJ_SWD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRJ_SWD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRJ_SWD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRJ_SWD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRJ_SWD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRJ_SWD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRJ_SWD] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRJ_SWD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRJ_SWD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRJ_SWD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRJ_SWD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRJ_SWD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRJ_SWD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRJ_SWD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRJ_SWD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRJ_SWD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRJ_SWD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRJ_SWD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRJ_SWD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRJ_SWD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRJ_SWD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRJ_SWD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRJ_SWD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRJ_SWD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRJ_SWD] SET RECOVERY FULL 
GO
ALTER DATABASE [PRJ_SWD] SET  MULTI_USER 
GO
ALTER DATABASE [PRJ_SWD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRJ_SWD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRJ_SWD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRJ_SWD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRJ_SWD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRJ_SWD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRJ_SWD', N'ON'
GO
ALTER DATABASE [PRJ_SWD] SET QUERY_STORE = OFF
GO
USE [PRJ_SWD]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](1000) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](1000) NOT NULL,
	[Created_Date] [date] NOT NULL,
	[Image] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[PersonId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](255) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[StarRating] [int] NOT NULL,
	[ResponseFeedback] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalExamination]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalExamination](
	[MEId] [int] IDENTITY(1,1) NOT NULL,
	[ReservationId] [int] NOT NULL,
	[ExaminationDate] [date] NOT NULL,
	[Symptoms] [nvarchar](255) NOT NULL,
	[Diagnosis] [nvarchar](255) NOT NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[ExaminationFee] [float] NOT NULL,
	[StaffId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_MedicalExamination] PRIMARY KEY CLUSTERED 
(
	[MEId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[MedicineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Medicine] PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Bill]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Bill](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[PaymentMethod] [int] NOT NULL,
	[ReservationId] [int] NOT NULL,
	[ScheduleId] [int] NOT NULL,
 CONSTRAINT [PK_Order_Bill] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[Currency] [float] NOT NULL,
	[Status] [int] NOT NULL,
	[Create_At] [date] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[PersonName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [bit] NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](1000) NULL,
	[Image] [nvarchar](1000) NULL,
	[StaffStatus] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons_Services]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons_Services](
	[PersonId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_Persons_Services] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC,
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[PrescriptionId] [int] IDENTITY(1,1) NOT NULL,
	[ExaminationId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[MedicineId] [int] NOT NULL,
	[Dosage] [nvarchar](255) NOT NULL,
	[Note] [nvarchar](255) NOT NULL,
	[TotalCost] [float] NOT NULL,
 CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED 
(
	[PrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription_Order]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription_Order](
	[PrescriptionId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_Prescription_Order] PRIMARY KEY CLUSTERED 
(
	[PrescriptionId] ASC,
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[Created_Date] [date] NULL,
	[Status] [int] NOT NULL,
	[ReservationDate] [date] NULL,
	[Note] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[SlotId] [int] NOT NULL,
	[WeekNumber] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[StaffId] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Status] [int] NOT NULL,
	[Image] [nvarchar](1000) NOT NULL,
	[Duration] [nvarchar](50) NULL,
	[Detail] [nvarchar](1000) NULL,
	[ManagerId] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services_Orders]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services_Orders](
	[ServiceId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_Services_Orders] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC,
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services_Prescriptions]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services_Prescriptions](
	[ServiceId] [int] NOT NULL,
	[PrescriptionId] [int] NOT NULL,
 CONSTRAINT [PK_Services_Prescriptions] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC,
	[PrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services_Reservations]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services_Reservations](
	[ServiceId] [int] NOT NULL,
	[ReservationId] [int] NOT NULL,
 CONSTRAINT [PK_Services_Reservations] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC,
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 6/23/2025 10:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[SliderId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Image] [nvarchar](1000) NOT NULL,
	[Backlink] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[Status] [varchar](1) NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[SliderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (1, N'david.brown@example.com', N'123', 1, 5, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (2, N'emily.johnson@example.com', N'hashedpassword2', 2, 2, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (3, N'michael.lee@childcare.com', N'hashedpassword3', 1, 3, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (4, N'sarah.williams@childcare.com', N'hashedpassword4', 2, 4, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (5, N'nguyenbachhg@gmail.com', N'hoangbachhg123', 3, 1, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (6, N'sophia.miller@example.com', N'hashedpassword6', 2, 6, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (7, N'daniel.harris@example.com', N'hashedpassword7', 2, 7, 0)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (8, N'olivia.clark@example.com', N'hashedpassword8', 3, 8, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (9, N'james.anderson@example.com', N'hashedpassword9', 2, 9, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (10, N'isabella.thomas@example.com', N'hashedpassword10', 1, 10, 0)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (11, N'benjamin.jackson@example.com', N'hashedpassword11', 1, 11, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (12, N'charlotte.white@example.com', N'hashedpassword12', 1, 12, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (13, N'henry.harris@example.com', N'hashedpassword13', 3, 13, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (14, N'amelia.lewis@example.com', N'hashedpassword14', 4, 14, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId], [PersonId], [Status]) VALUES (15, N'lucas.robinson@example.com', N'hashedpassword15', 2, 15, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([BlogId], [Title], [Content], [Created_Date], [Image], [Description], [PersonId], [CategoryId]) VALUES (1, N'Importance of Child Nutrition', N'Detailed guide on proper nutrition for children...', CAST(N'2024-01-15' AS Date), N'1HLTH111-1.jpg', N'Learn about balanced diet for kids', 8, 2)
INSERT [dbo].[Blog] ([BlogId], [Title], [Content], [Created_Date], [Image], [Description], [PersonId], [CategoryId]) VALUES (2, N'Understanding Child Development Stages', N'Comprehensive overview of child growth milestones...', CAST(N'2024-02-20' AS Date), N'1734079440559_childrendCare2.jpg
', N'Key stages of child development', 8, 5)
INSERT [dbo].[Blog] ([BlogId], [Title], [Content], [Created_Date], [Image], [Description], [PersonId], [CategoryId]) VALUES (3, N'Mental Health in Children', N'Insights into child psychological well-being...', CAST(N'2024-03-10' AS Date), N'1734079514070_child-care-page-header-photo.jpg
', N'Supporting your child''s emotional health', 8, 3)
INSERT [dbo].[Blog] ([BlogId], [Title], [Content], [Created_Date], [Image], [Description], [PersonId], [CategoryId]) VALUES (4, N'Vaccination: Protecting Your Child', N'Everything you need to know about childhood vaccines...', CAST(N'2024-04-05' AS Date), N'4childrendCare2.jpg
', N'Comprehensive vaccine guide', 3, 4)
INSERT [dbo].[Blog] ([BlogId], [Title], [Content], [Created_Date], [Image], [Description], [PersonId], [CategoryId]) VALUES (10, N'ChildrenCare', N'Health care for Children', CAST(N'2024-03-15' AS Date), N'10childrenCare1.jpg
', N'Cham soc suc khoe cho tre', 3, 5)
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Pediatric Care')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Child Nutrition')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Child Psychology')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Vaccination')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (5, N'Child Development')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackId], [Content], [CustomerId], [ServiceId], [StarRating], [ResponseFeedback]) VALUES (1, N'Great service and caring staff', 2, 1, 5, N'Thank you for your positive feedback!')
INSERT [dbo].[Feedback] ([FeedbackId], [Content], [CustomerId], [ServiceId], [StarRating], [ResponseFeedback]) VALUES (2, N'Helpful nutrition advice', 3, 3, 4, N'We''re glad we could help you.')
INSERT [dbo].[Feedback] ([FeedbackId], [Content], [CustomerId], [ServiceId], [StarRating], [ResponseFeedback]) VALUES (3, N'Professional and thorough examination', 1, 2, 5, N'We appreciate your kind words.')
INSERT [dbo].[Feedback] ([FeedbackId], [Content], [CustomerId], [ServiceId], [StarRating], [ResponseFeedback]) VALUES (4, N'Good psychological support', 5, 4, 4, N'Thank you for sharing your experience.')
INSERT [dbo].[Feedback] ([FeedbackId], [Content], [CustomerId], [ServiceId], [StarRating], [ResponseFeedback]) VALUES (7, N'Helpful nutrition advice', 12, 3, 5, N'We''re glad we could help you.')
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (1, N'Nguyen Hoang Bach', CAST(N'2003-10-12' AS Date), 1, N'0914087034', N'nguyenbachhg@gmail.com', N'Ha Giang', N'78-786207_user-avatar-png-user-avatar-icon-png-transparent.png', NULL)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (2, N'Emily Johnson', CAST(N'1985-08-22' AS Date), 0, N'0987654321', N'emily.johnson@example.com', N'456 Oak Road, Townsburg', N'163-1636340_user-avatar-icon-avatar-transparent-user-icon-png.png', 1)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (3, N'Michael Lee', CAST(N'1995-03-10' AS Date), 1, N'0567890123', N'michael.lee@childcare.com', N'789 Maple Ave, Villagetown', N'meo.jpg', 1)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (4, N'Sarah Williams', CAST(N'1988-11-30' AS Date), 0, N'0234567890', N'sarah.williams@childcare.com', N'101 Pine Street, Cityburg', N'sarah.jpg', 2)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (5, N'David Brown', CAST(N'1992-07-18' AS Date), 1, N'0345678901', N'david.brown@example.com', N'202 Elm Lane, Metropolis', N'david.jpg', NULL)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (6, N'Sophia Miller', CAST(N'1993-04-25' AS Date), 0, N'0123456790', N'sophia.miller@example.com', N'303 Birchwood Dr, Lakeside', N'sophia.jpg', NULL)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (7, N'Daniel Harris', CAST(N'1991-09-12' AS Date), 1, N'0212345678', N'daniel.harris@example.com', N'404 Cedar Road, Hilltop', N'daniel.jpg', 1)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (8, N'Olivia Clark', CAST(N'1986-02-07' AS Date), 0, N'0334567890', N'olivia.clark@example.com', N'505 Willow St, Riverside', N'olivia.jpg', 2)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (9, N'James Anderson', CAST(N'1994-11-14' AS Date), 1, N'0456789012', N'james.anderson@example.com', N'606 Pine Rd, Northwood', N'james.jpg', NULL)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (10, N'Isabella Thomas', CAST(N'1992-01-28' AS Date), 0, N'0567890123', N'isabella.thomas@example.com', N'707 Maple St, Eastwood', N'isabella.jpg', 1)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (11, N'Benjamin Jackson', CAST(N'1990-06-13' AS Date), 1, N'0678901234', N'benjamin.jackson@example.com', N'808 Oak Ave, Westfield', N'benjamin.jpg', 2)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (12, N'Charlotte White', CAST(N'1989-12-22' AS Date), 0, N'0789012345', N'charlotte.white@example.com', N'909 Birch St, Seaside', N'charlotte.jpg', 1)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (13, N'Henry Harris', CAST(N'1996-07-19' AS Date), 1, N'0890123456', N'henry.harris@example.com', N'1010 Maple Dr, Brookdale', N'henry.jpg', NULL)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (14, N'Amelia Lewis', CAST(N'1987-03-30' AS Date), 0, N'0912345678', N'amelia.lewis@example.com', N'2020 Oak Dr, Clearview', N'amelia.jpg', 1)
INSERT [dbo].[Person] ([PersonId], [PersonName], [DateOfBirth], [Gender], [Phone], [Email], [Address], [Image], [StaffStatus]) VALUES (15, N'Lucas Robinson', CAST(N'1994-08-09' AS Date), 1, N'1023456789', N'lucas.robinson@example.com', N'3030 Elm St, Ridgewood', N'lucas.jpg', 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (2, 1)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (2, 3)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (4, 1)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (4, 4)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (4, 10)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (6, 2)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (6, 5)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (6, 10)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (7, 2)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (9, 1)
INSERT [dbo].[Persons_Services] ([PersonId], [ServiceId]) VALUES (9, 3)
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [StaffId], [Created_Date], [Status], [ReservationDate], [Note]) VALUES (1, 1, 2, CAST(N'2025-06-20' AS Date), 1, CAST(N'2025-06-25' AS Date), N'General health consultation')
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [StaffId], [Created_Date], [Status], [ReservationDate], [Note]) VALUES (2, 1, 2, CAST(N'2025-06-21' AS Date), 0, CAST(N'2025-06-26' AS Date), N'Routine medical checkup')
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [StaffId], [Created_Date], [Status], [ReservationDate], [Note]) VALUES (3, 1, 2, CAST(N'2025-06-22' AS Date), 1, CAST(N'2025-06-27' AS Date), N'Nutrition advice')
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [StaffId], [Created_Date], [Status], [ReservationDate], [Note]) VALUES (4, 1, 2, CAST(N'2025-06-23' AS Date), 0, CAST(N'2025-06-28' AS Date), N'Lab test result consultation')
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Customer')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Staff')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Manager')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (4, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ServiceId], [ServiceName], [Price], [Description], [Status], [Image], [Duration], [Detail], [ManagerId]) VALUES (1, N'Annual Child Checkup', 150, N'Comprehensive health examination for children', 1, N'Annual Physicals for Kids-min.jpg', N'60-90 minutes', N'A comprehensive health examination for children assesses overall well-being and development through medical history, physical exams, and growth evaluations. It includes checks of vital signs, vision, hearing, and developmental milestones, along with screenings for anemia, lead, and other conditions. Nutritional and behavioral assessments address diet, emotional health, and social interactions, while immunizations are updated as needed. Parents receive guidance on injury prevention, healthy habits, and developmental transitions, with lab tests or specialist referrals provided if necessary to ensure the child’s health and growth.', 8)
INSERT [dbo].[Service] ([ServiceId], [ServiceName], [Price], [Description], [Status], [Image], [Duration], [Detail], [ManagerId]) VALUES (2, N'Vaccination Package', 200, N'Complete vaccination series for children', 1, N'web-thumbnail-1-5x-100.jpg', N'45-60 minutes', N'A complete vaccination series for children ensures protection against various diseases by following the recommended immunization schedule. It includes vaccines for hepatitis B, diphtheria, tetanus, pertussis, polio, measles, mumps, rubella, varicella, and Haemophilus influenzae type B. Additional vaccines may cover rotavirus, pneumococcal disease, meningitis, influenza, and hepatitis A. Depending on age and risk factors, children may also receive the HPV, COVID-19, and meningococcal vaccines. Regular follow-ups ensure doses are administered at the correct intervals, providing long-term immunity and safeguarding public health.






', 1)
INSERT [dbo].[Service] ([ServiceId], [ServiceName], [Price], [Description], [Status], [Image], [Duration], [Detail], [ManagerId]) VALUES (3, N'Child Nutrition Consultation', 100, N'Personalized nutrition guidance', 1, N'iStock-636653206.jpg', N'20-30 minutes', N'Personalized nutrition guidance for children focuses on tailoring dietary recommendations to their age, growth needs, and health status. It includes creating balanced meal plans rich in essential nutrients, addressing dietary restrictions or allergies, and promoting healthy eating habits. Guidance emphasizes appropriate portion sizes, hydration, and limiting sugar and processed foods. Parents receive advice on managing picky eating, supporting growth milestones, and fostering a positive relationship with food to ensure optimal health and development.', 1)
INSERT [dbo].[Service] ([ServiceId], [ServiceName], [Price], [Description], [Status], [Image], [Duration], [Detail], [ManagerId]) VALUES (4, N'Child Psychology Assessment', 250, N'Comprehensive psychological evaluation', 1, N'private-versus-public-evaluations.jpg', N'30-45 minutes', N'A comprehensive psychological evaluation assesses a child’s emotional, behavioral, and cognitive functioning. It involves interviews with the child and parents, observation, and standardized tests to identify strengths, challenges, and potential mental health concerns. The evaluation covers emotional well-being, social interactions, learning abilities, and behavioral patterns. Parents receive a detailed report with insights and tailored recommendations for therapy, interventions, or educational support to promote the child’s mental health and overall development.', 13)
INSERT [dbo].[Service] ([ServiceId], [ServiceName], [Price], [Description], [Status], [Image], [Duration], [Detail], [ManagerId]) VALUES (5, N'Dental Care for Kids', 180, N'Child-friendly dental checkup and cleaning', 1, N'kids-dentistry-min-925x425.jpg', N'30 minutes', N'A child-friendly dental checkup and cleaning focuses on maintaining oral health in a comfortable environment. It includes examining teeth, gums, and jaw for any issues, cleaning to remove plaque and tartar, and applying fluoride for cavity prevention. Dentists use gentle techniques and educate children on proper brushing, flossing, and healthy eating habits, ensuring a positive experience that encourages lifelong dental care.', 13)
INSERT [dbo].[Service] ([ServiceId], [ServiceName], [Price], [Description], [Status], [Image], [Duration], [Detail], [ManagerId]) VALUES (10, N'adada', 500, N'qweqweqw', 0, N'pediatric-care.jpg', N'3 hours', N'zxczxczxc', 1)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([SliderId], [Title], [Image], [Backlink], [Description], [Status], [PersonId]) VALUES (2, N'6 Common Health Problems & Diseases in Babies', N'babys-disease-article-768x432.jpg', N'https://childandwellnesscare.com/6-common-diseases-in-babies/', N'After birth, almost all babies go through different health problems frequently. Though it is difficult to see your baby struggling with diseases, your pediatric doctors will guide you to keep your baby healthy.', N'1', 1)
INSERT [dbo].[Slider] ([SliderId], [Title], [Image], [Backlink], [Description], [Status], [PersonId]) VALUES (3, N'The impact of COVID-19 on infant and child health care, beyond missed vaccinations', N'gty-child-flu-er-170403.jpg', N'https://www.goodmorningamerica.com/wellness/story/impact-covid-19-infant-child-health-care-missed-70316384', N'Families are keeping children safe at home by heeding warnings to stay inside during the COVID-19 pandemic. But in spite of parents'' best intentions, strict adherence to home quarantine has created a new problem that puts kids at risk: missed doctor''s visits.', N'1', 1)
INSERT [dbo].[Slider] ([SliderId], [Title], [Image], [Backlink], [Description], [Status], [PersonId]) VALUES (4, N'Why Children''s Health Matters', N'1680874404201.png', N'https://www.linkedin.com/pulse/world-health-day-why-childrens-matters-urgent-care-for-children', N'World Health Day is an annual event that raises awareness about important health issues and highlights the need for global action to improve health outcomes for everyone, everywhere. Here are some reasons why children''s health matters.', N'1', 1)
INSERT [dbo].[Slider] ([SliderId], [Title], [Image], [Backlink], [Description], [Status], [PersonId]) VALUES (6, N'abc', N'Weil_Exhibit1_Final-1648814413530.jpg', N'ấd', N'abczxc', N'0', 1)
SET IDENTITY_INSERT [dbo].[Slider] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Person]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_Category]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_Person]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Person] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Person]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Service]
GO
ALTER TABLE [dbo].[MedicalExamination]  WITH CHECK ADD  CONSTRAINT [FK_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[MedicalExamination] CHECK CONSTRAINT [FK_CustomerId]
GO
ALTER TABLE [dbo].[MedicalExamination]  WITH CHECK ADD  CONSTRAINT [FK_StaffId] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[MedicalExamination] CHECK CONSTRAINT [FK_StaffId]
GO
ALTER TABLE [dbo].[Order_Bill]  WITH CHECK ADD  CONSTRAINT [FK_Order_Bill_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([ReservationId])
GO
ALTER TABLE [dbo].[Order_Bill] CHECK CONSTRAINT [FK_Order_Bill_Reservation]
GO
ALTER TABLE [dbo].[Order_Bill]  WITH CHECK ADD  CONSTRAINT [FK_Order_Bill_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([ScheduleId])
GO
ALTER TABLE [dbo].[Order_Bill] CHECK CONSTRAINT [FK_Order_Bill_Schedule]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Person]
GO
ALTER TABLE [dbo].[Persons_Services]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Services_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Persons_Services] CHECK CONSTRAINT [FK_Persons_Services_Person]
GO
ALTER TABLE [dbo].[Persons_Services]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Services_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Persons_Services] CHECK CONSTRAINT [FK_Persons_Services_Service]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_MedicalExamination] FOREIGN KEY([ExaminationId])
REFERENCES [dbo].[MedicalExamination] ([MEId])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_Prescription_MedicalExamination]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Medicine] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicine] ([MedicineId])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_Prescription_Medicine]
GO
ALTER TABLE [dbo].[Prescription_Order]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Order_Order_Bill] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order_Bill] ([OrderId])
GO
ALTER TABLE [dbo].[Prescription_Order] CHECK CONSTRAINT [FK_Prescription_Order_Order_Bill]
GO
ALTER TABLE [dbo].[Prescription_Order]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Order_Prescription] FOREIGN KEY([PrescriptionId])
REFERENCES [dbo].[Prescription] ([PrescriptionId])
GO
ALTER TABLE [dbo].[Prescription_Order] CHECK CONSTRAINT [FK_Prescription_Order_Prescription]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Person] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Person]
GO
ALTER TABLE [dbo].[Services_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Services_Orders_Order_Bill] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order_Bill] ([OrderId])
GO
ALTER TABLE [dbo].[Services_Orders] CHECK CONSTRAINT [FK_Services_Orders_Order_Bill]
GO
ALTER TABLE [dbo].[Services_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Services_Orders_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Services_Orders] CHECK CONSTRAINT [FK_Services_Orders_Service]
GO
ALTER TABLE [dbo].[Services_Prescriptions]  WITH CHECK ADD  CONSTRAINT [FK_Services_Prescriptions_Prescription] FOREIGN KEY([PrescriptionId])
REFERENCES [dbo].[Prescription] ([PrescriptionId])
GO
ALTER TABLE [dbo].[Services_Prescriptions] CHECK CONSTRAINT [FK_Services_Prescriptions_Prescription]
GO
ALTER TABLE [dbo].[Services_Prescriptions]  WITH CHECK ADD  CONSTRAINT [FK_Services_Prescriptions_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Services_Prescriptions] CHECK CONSTRAINT [FK_Services_Prescriptions_Service]
GO
ALTER TABLE [dbo].[Services_Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Services_Reservations_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([ReservationId])
GO
ALTER TABLE [dbo].[Services_Reservations] CHECK CONSTRAINT [FK_Services_Reservations_Reservation]
GO
ALTER TABLE [dbo].[Services_Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Services_Reservations_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Services_Reservations] CHECK CONSTRAINT [FK_Services_Reservations_Service]
GO
ALTER TABLE [dbo].[Slider]  WITH CHECK ADD  CONSTRAINT [FK_Slider_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Slider] CHECK CONSTRAINT [FK_Slider_Person]
GO
USE [master]
GO
ALTER DATABASE [PRJ_SWD] SET  READ_WRITE 
GO
