USE [NganHang]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](150) NOT NULL,
	[DepartmentNo] [nchar](10) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [DepartmentNo]) VALUES (1, N'Computer', N'1002      ')
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [DepartmentNo]) VALUES (2, N'Math', N'1003      ')
SET IDENTITY_INSERT [dbo].[Departments] OFF
/****** Object:  Table [dbo].[Operations]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OperationName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Operations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Operations] ON
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (1, N'Teachers')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (2, N'Students')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (3, N'Subjects')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (4, N'SubjectClass')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (5, N'Department')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (6, N'TestComposer')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (7, N'Questions')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (8, N'AssignTest')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (9, N'CustomQuestion')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (10, N'MultiTest')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (11, N'StudentTestResults')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (12, N'Profiles')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (13, N'UserPermistion')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (14, N'DataBackup')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (15, N'Themes')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (16, N'EditSchoolInfo')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (17, N'MixedTest')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (18, N'LimitedTest')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (19, N'DataRestore')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (20, N'SharingQuestion')
INSERT [dbo].[Operations] ([ID], [OperationName]) VALUES (21, N'UpdateQuestion')
SET IDENTITY_INSERT [dbo].[Operations] OFF
/****** Object:  Table [dbo].[MultiTests]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MultiTests](
	[MultiTestId] [bigint] IDENTITY(1,1) NOT NULL,
	[MultiTestNo] [nchar](20) NOT NULL,
	[MultiTestName] [nvarchar](250) NOT NULL,
	[MultiTestDate] [datetime] NOT NULL,
	[Time] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[UpdatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Purpose] [int] NOT NULL,
	[CopyTestNo] [int] NOT NULL,
	[TotalQuestions] [int] NOT NULL,
	[IsMixedTest] [bit] NOT NULL,
 CONSTRAINT [PK_MultiTests] PRIMARY KEY CLUSTERED 
(
	[MultiTestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MultiTests] ON
INSERT [dbo].[MultiTests] ([MultiTestId], [MultiTestNo], [MultiTestName], [MultiTestDate], [Time], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Purpose], [CopyTestNo], [TotalQuestions], [IsMixedTest]) VALUES (5, N'004                 ', N'Full Test', CAST(0x0000A24400E436DD AS DateTime), 30, N'admin', N'admin', CAST(0x0000A24400E45A74 AS DateTime), CAST(0x0000A24400E45A7B AS DateTime), 0, 2, 30, 0)
INSERT [dbo].[MultiTests] ([MultiTestId], [MultiTestNo], [MultiTestName], [MultiTestDate], [Time], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Purpose], [CopyTestNo], [TotalQuestions], [IsMixedTest]) VALUES (6, N'005                 ', N'Thi thu', CAST(0x0000A244015DDEF2 AS DateTime), 30, N'admin', N'admin', CAST(0x0000A24401600A08 AS DateTime), CAST(0x0000A24401600A0F AS DateTime), 0, 4, 30, 0)
INSERT [dbo].[MultiTests] ([MultiTestId], [MultiTestNo], [MultiTestName], [MultiTestDate], [Time], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Purpose], [CopyTestNo], [TotalQuestions], [IsMixedTest]) VALUES (8, N'HH001               ', N'de hon hop', CAST(0x0000A24D00000000 AS DateTime), 11, N'admin', N'admin', CAST(0x0000A24D00BB601B AS DateTime), CAST(0x0000A24D00BB6022 AS DateTime), 4, 2, 23, 1)
INSERT [dbo].[MultiTests] ([MultiTestId], [MultiTestNo], [MultiTestName], [MultiTestDate], [Time], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Purpose], [CopyTestNo], [TotalQuestions], [IsMixedTest]) VALUES (9, N'006                 ', N'Thi giua ky', CAST(0x0000A24D00000000 AS DateTime), 10, N'admin', N'admin', CAST(0x0000A24D0107C333 AS DateTime), CAST(0x0000A24D0107C33A AS DateTime), 4, 2, 30, 0)
SET IDENTITY_INSERT [dbo].[MultiTests] OFF
/****** Object:  Table [dbo].[Students]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentNo] [varchar](10) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[BirthDay] [datetime] NOT NULL,
	[Address] [nvarchar](250) NULL,
	[CMND] [varchar](10) NULL,
	[Phone] [varchar](11) NULL,
	[HomePhone] [varchar](11) NULL,
	[Email] [nvarchar](50) NULL,
	[UserName] [nvarchar](20) NULL,
	[PassWord] [nvarchar](50) NULL,
	[SchoolYear] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[Images] [nvarchar](250) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON
INSERT [dbo].[Students] ([StudentId], [StudentNo], [FirstName], [LastName], [BirthDay], [Address], [CMND], [Phone], [HomePhone], [Email], [UserName], [PassWord], [SchoolYear], [IsActive], [Images]) VALUES (1, N'MT05BK02', N'Toan', N'Nguyen', CAST(0x00007CB000EF577C AS DateTime), N'Tp.HCM', N'024062943', N'0962699244', NULL, N'ntt.cse@gmail.com', N'toannt', N'1', 2013, 1, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
/****** Object:  Table [dbo].[SchoolInfos]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SchoolInfos](
	[SchoolInfoId] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [nvarchar](250) NOT NULL,
	[HomePhone] [varchar](11) NULL,
	[Phone] [varchar](11) NULL,
	[Email] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SchoolInfos] PRIMARY KEY CLUSTERED 
(
	[SchoolInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SchoolInfos] ON
INSERT [dbo].[SchoolInfos] ([SchoolInfoId], [SchoolName], [HomePhone], [Phone], [Email], [IsActive]) VALUES (1, N'Trường đại học Bách Khoa tp.Hồ Chí Minh', N'08-09874389', N'0909090909', N'hcmut.university@edu.vn.com', 1)
SET IDENTITY_INSERT [dbo].[SchoolInfos] OFF
/****** Object:  Table [dbo].[Tests]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tests](
	[TestId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestNo] [nchar](20) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[FK_SubjectId] [int] NOT NULL,
	[TestDate] [datetime] NOT NULL,
	[Time] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[UpdatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Purpose] [int] NOT NULL,
	[CopyNo] [int] NOT NULL,
	[EasyNo] [int] NOT NULL,
	[NormalNo] [int] NOT NULL,
	[HardNo] [int] NOT NULL,
	[IsLimited] [bit] NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tests] ON
INSERT [dbo].[Tests] ([TestId], [TestNo], [Name], [FK_SubjectId], [TestDate], [Time], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Purpose], [CopyNo], [EasyNo], [NormalNo], [HardNo], [IsLimited]) VALUES (4, N'004                 ', N'Thi tin hoc', 1, CAST(0x0000A1F10014D620 AS DateTime), 20, N'admin', N'admin', CAST(0x0000A24300E051B1 AS DateTime), CAST(0x0000A24300E051B1 AS DateTime), 0, 0, 0, 0, 0, NULL)
INSERT [dbo].[Tests] ([TestId], [TestNo], [Name], [FK_SubjectId], [TestDate], [Time], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Purpose], [CopyNo], [EasyNo], [NormalNo], [HardNo], [IsLimited]) VALUES (5, N'005                 ', N'Thi thu', 1, CAST(0x0000A1F10014D620 AS DateTime), 1, N'admin', N'admin', CAST(0x0000A244016267CA AS DateTime), CAST(0x0000A244016267CA AS DateTime), 0, 0, 0, 0, 0, NULL)
INSERT [dbo].[Tests] ([TestId], [TestNo], [Name], [FK_SubjectId], [TestDate], [Time], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Purpose], [CopyNo], [EasyNo], [NormalNo], [HardNo], [IsLimited]) VALUES (7, N'GH001               ', N'Thi hoc ky I', 1, CAST(0x0000A1F10014D620 AS DateTime), 27, N'admin', N'admin', CAST(0x0000A24E00CB192F AS DateTime), CAST(0x0000A24E00CB192F AS DateTime), 0, 0, 0, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Tests] OFF
/****** Object:  Table [dbo].[Subjects]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectNo] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[IsDel] [bit] NULL,
	[SubjectGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON
INSERT [dbo].[Subjects] ([SubjectId], [SubjectNo], [Name], [IsDel], [SubjectGuid]) VALUES (1, N'CSE-001', N'Tin Hoc Dai Cuong', NULL, N'051eb51f-45d9-412b-a2bf-719c5f4d3b18')
INSERT [dbo].[Subjects] ([SubjectId], [SubjectNo], [Name], [IsDel], [SubjectGuid]) VALUES (2, N'CSE-002', N'Cau Truc Du Lieu', 0, N'00000000-0000-0000-0000-000000000000')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
/****** Object:  Table [dbo].[TeacherOperations]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherOperations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[OperationName] [nvarchar](100) NOT NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_TeacherOperations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TeacherOperations] ON
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (1, 1, N'Teachers', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (2, 1, N'Students', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (3, 1, N'Subjects', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (4, 1, N'SubjectClass', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (5, 1, N'Department', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (6, 1, N'TestComposer', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (7, 1, N'Questions', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (8, 1, N'AssignTest', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (9, 1, N'CustomQuestion', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (10, 1, N'MultiTest', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (11, 1, N'StudentTestResults', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (12, 1, N'Profiles', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (13, 1, N'UserPermistion', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (14, 1, N'DataBackup', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (15, 1, N'Themes', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (16, 1, N'EditSchoolInfo', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (17, 1, N'MixedTest', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (18, 1, N'LimitedTest', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (19, 1, N'SharingQuestion', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (20, 1, N'UpdateQuestion', 1)
INSERT [dbo].[TeacherOperations] ([Id], [TeacherId], [OperationName], [Enable]) VALUES (21, 1, N'DataRestore', 1)
SET IDENTITY_INSERT [dbo].[TeacherOperations] OFF
/****** Object:  Table [dbo].[SubjectsMultiTests]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectsMultiTests](
	[FK_SubjectId] [int] NOT NULL,
	[FK_MultiTestId] [bigint] NOT NULL,
	[EasyNo] [int] NOT NULL,
	[NormalNo] [int] NOT NULL,
	[HardNo] [int] NOT NULL,
	[EasyNo1] [int] NOT NULL,
	[NormalNo1] [int] NOT NULL,
	[HardNo1] [int] NOT NULL,
 CONSTRAINT [PK_SubjectsMultiTests] PRIMARY KEY CLUSTERED 
(
	[FK_SubjectId] ASC,
	[FK_MultiTestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SubjectsMultiTests] ([FK_SubjectId], [FK_MultiTestId], [EasyNo], [NormalNo], [HardNo], [EasyNo1], [NormalNo1], [HardNo1]) VALUES (1, 5, 30, 0, 0, 0, 0, 0)
INSERT [dbo].[SubjectsMultiTests] ([FK_SubjectId], [FK_MultiTestId], [EasyNo], [NormalNo], [HardNo], [EasyNo1], [NormalNo1], [HardNo1]) VALUES (1, 6, 30, 0, 0, 0, 0, 0)
INSERT [dbo].[SubjectsMultiTests] ([FK_SubjectId], [FK_MultiTestId], [EasyNo], [NormalNo], [HardNo], [EasyNo1], [NormalNo1], [HardNo1]) VALUES (1, 8, 20, 1, 0, 1, 1, 0)
INSERT [dbo].[SubjectsMultiTests] ([FK_SubjectId], [FK_MultiTestId], [EasyNo], [NormalNo], [HardNo], [EasyNo1], [NormalNo1], [HardNo1]) VALUES (1, 9, 29, 1, 0, 0, 0, 0)
/****** Object:  Table [dbo].[StudentTests]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTests](
	[FK_StudenId] [bigint] NOT NULL,
	[FK_TestId] [bigint] NOT NULL,
	[Score] [float] NULL,
	[Description] [nvarchar](250) NULL,
	[QuestionStructure] [xml] NULL,
	[CorrectNo] [int] NULL,
	[WrongNo] [int] NULL,
	[NotDone] [int] NULL,
	[DoneTime] [int] NULL,
 CONSTRAINT [PK_StudentTests] PRIMARY KEY CLUSTERED 
(
	[FK_StudenId] ASC,
	[FK_TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCopies]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCopies](
	[TestCopyId] [int] IDENTITY(1,1) NOT NULL,
	[FK_TestId] [bigint] NOT NULL,
	[TestCopyStructure] [xml] NOT NULL,
 CONSTRAINT [PK_TestCopies] PRIMARY KEY CLUSTERED 
(
	[TestCopyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TestCopies] ON
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (11, 4, N'<TestCopy><Q qOrder="1" qId="36"><A aOrder="1" aId="141" /><A aOrder="2" aId="144" /><A aOrder="3" aId="142" /><A aOrder="4" aId="143" /></Q><Q qOrder="2" qId="9"><A aOrder="1" aId="34" /><A aOrder="2" aId="36" /><A aOrder="3" aId="33" /><A aOrder="4" aId="35" /></Q><Q qOrder="3" qId="30"><A aOrder="1" aId="119" /><A aOrder="2" aId="120" /><A aOrder="3" aId="117" /><A aOrder="4" aId="118" /></Q><Q qOrder="4" qId="32"><A aOrder="1" aId="125" /><A aOrder="2" aId="127" /><A aOrder="3" aId="128" /><A aOrder="4" aId="126" /></Q><Q qOrder="5" qId="22"><A aOrder="1" aId="87" /><A aOrder="2" aId="85" /><A aOrder="3" aId="88" /><A aOrder="4" aId="86" /></Q><Q qOrder="6" qId="17"><A aOrder="1" aId="65" /><A aOrder="2" aId="68" /><A aOrder="3" aId="66" /><A aOrder="4" aId="67" /></Q><Q qOrder="7" qId="25"><A aOrder="1" aId="98" /><A aOrder="2" aId="97" /><A aOrder="3" aId="99" /><A aOrder="4" aId="100" /></Q><Q qOrder="8" qId="31"><A aOrder="1" aId="124" /><A aOrder="2" aId="121" /><A aOrder="3" aId="123" /><A aOrder="4" aId="122" /></Q><Q qOrder="9" qId="23"><A aOrder="1" aId="90" /><A aOrder="2" aId="91" /><A aOrder="3" aId="92" /><A aOrder="4" aId="89" /></Q><Q qOrder="10" qId="15"><A aOrder="1" aId="60" /><A aOrder="2" aId="58" /><A aOrder="3" aId="57" /><A aOrder="4" aId="59" /></Q><Q qOrder="11" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="78" /><A aOrder="3" aId="80" /><A aOrder="4" aId="79" /></Q><Q qOrder="12" qId="11"><A aOrder="1" aId="41" /><A aOrder="2" aId="42" /><A aOrder="3" aId="43" /><A aOrder="4" aId="44" /></Q><Q qOrder="13" qId="34"><A aOrder="1" aId="133" /><A aOrder="2" aId="136" /><A aOrder="3" aId="134" /><A aOrder="4" aId="135" /></Q><Q qOrder="14" qId="21"><A aOrder="1" aId="84" /><A aOrder="2" aId="81" /><A aOrder="3" aId="82" /><A aOrder="4" aId="83" /></Q><Q qOrder="15" qId="38"><A aOrder="1" aId="150" /><A aOrder="2" aId="149" /><A aOrder="3" aId="151" /><A aOrder="4" aId="152" /></Q><Q qOrder="16" qId="14"><A aOrder="1" aId="54" /><A aOrder="2" aId="53" /><A aOrder="3" aId="56" /><A aOrder="4" aId="55" /></Q><Q qOrder="17" qId="8"><A aOrder="1" aId="32" /><A aOrder="2" aId="30" /><A aOrder="3" aId="31" /><A aOrder="4" aId="29" /></Q><Q qOrder="18" qId="29"><A aOrder="1" aId="114" /><A aOrder="2" aId="115" /><A aOrder="3" aId="113" /><A aOrder="4" aId="116" /></Q><Q qOrder="19" qId="35"><A aOrder="1" aId="137" /><A aOrder="2" aId="138" /><A aOrder="3" aId="140" /><A aOrder="4" aId="139" /></Q><Q qOrder="20" qId="13"><A aOrder="1" aId="51" /><A aOrder="2" aId="50" /><A aOrder="3" aId="52" /><A aOrder="4" aId="49" /></Q><Q qOrder="21" qId="12"><A aOrder="1" aId="48" /><A aOrder="2" aId="47" /><A aOrder="3" aId="45" /><A aOrder="4" aId="46" /></Q><Q qOrder="22" qId="16"><A aOrder="1" aId="64" /><A aOrder="2" aId="61" /><A aOrder="3" aId="62" /><A aOrder="4" aId="63" /></Q><Q qOrder="23" qId="27"><A aOrder="1" aId="108" /><A aOrder="2" aId="105" /><A aOrder="3" aId="106" /><A aOrder="4" aId="107" /></Q><Q qOrder="24" qId="37"><A aOrder="1" aId="148" /><A aOrder="2" aId="145" /><A aOrder="3" aId="146" /><A aOrder="4" aId="147" /></Q><Q qOrder="25" qId="28"><A aOrder="1" aId="110" /><A aOrder="2" aId="111" /><A aOrder="3" aId="109" /><A aOrder="4" aId="112" /></Q><Q qOrder="26" qId="26"><A aOrder="1" aId="103" /><A aOrder="2" aId="104" /><A aOrder="3" aId="101" /><A aOrder="4" aId="102" /></Q><Q qOrder="27" qId="10"><A aOrder="1" aId="39" /><A aOrder="2" aId="38" /><A aOrder="3" aId="40" /><A aOrder="4" aId="37" /></Q><Q qOrder="28" qId="33"><A aOrder="1" aId="131" /><A aOrder="2" aId="132" /><A aOrder="3" aId="129" /><A aOrder="4" aId="130" /></Q><Q qOrder="29" qId="18"><A aOrder="1" aId="71" /><A aOrder="2" aId="70" /><A aOrder="3" aId="69" /><A aOrder="4" aId="72" /></Q><Q qOrder="30" qId="19"><A aOrder="1" aId="74" /><A aOrder="2" aId="73" /><A aOrder="3" aId="76" /><A aOrder="4" aId="75" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (12, 4, N'<TestCopy><Q qOrder="1" qId="29"><A aOrder="1" aId="113" /><A aOrder="2" aId="114" /><A aOrder="3" aId="115" /><A aOrder="4" aId="116" /></Q><Q qOrder="2" qId="11"><A aOrder="1" aId="41" /><A aOrder="2" aId="44" /><A aOrder="3" aId="42" /><A aOrder="4" aId="43" /></Q><Q qOrder="3" qId="38"><A aOrder="1" aId="151" /><A aOrder="2" aId="152" /><A aOrder="3" aId="149" /><A aOrder="4" aId="150" /></Q><Q qOrder="4" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="110" /><A aOrder="3" aId="111" /><A aOrder="4" aId="112" /></Q><Q qOrder="5" qId="13"><A aOrder="1" aId="52" /><A aOrder="2" aId="50" /><A aOrder="3" aId="49" /><A aOrder="4" aId="51" /></Q><Q qOrder="6" qId="26"><A aOrder="1" aId="102" /><A aOrder="2" aId="101" /><A aOrder="3" aId="104" /><A aOrder="4" aId="103" /></Q><Q qOrder="7" qId="32"><A aOrder="1" aId="125" /><A aOrder="2" aId="126" /><A aOrder="3" aId="127" /><A aOrder="4" aId="128" /></Q><Q qOrder="8" qId="18"><A aOrder="1" aId="72" /><A aOrder="2" aId="69" /><A aOrder="3" aId="71" /><A aOrder="4" aId="70" /></Q><Q qOrder="9" qId="23"><A aOrder="1" aId="89" /><A aOrder="2" aId="91" /><A aOrder="3" aId="92" /><A aOrder="4" aId="90" /></Q><Q qOrder="10" qId="14"><A aOrder="1" aId="53" /><A aOrder="2" aId="55" /><A aOrder="3" aId="56" /><A aOrder="4" aId="54" /></Q><Q qOrder="11" qId="8"><A aOrder="1" aId="29" /><A aOrder="2" aId="30" /><A aOrder="3" aId="32" /><A aOrder="4" aId="31" /></Q><Q qOrder="12" qId="19"><A aOrder="1" aId="76" /><A aOrder="2" aId="73" /><A aOrder="3" aId="74" /><A aOrder="4" aId="75" /></Q><Q qOrder="13" qId="35"><A aOrder="1" aId="138" /><A aOrder="2" aId="139" /><A aOrder="3" aId="140" /><A aOrder="4" aId="137" /></Q><Q qOrder="14" qId="25"><A aOrder="1" aId="97" /><A aOrder="2" aId="98" /><A aOrder="3" aId="99" /><A aOrder="4" aId="100" /></Q><Q qOrder="15" qId="9"><A aOrder="1" aId="34" /><A aOrder="2" aId="35" /><A aOrder="3" aId="36" /><A aOrder="4" aId="33" /></Q><Q qOrder="16" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="57" /><A aOrder="3" aId="60" /><A aOrder="4" aId="59" /></Q><Q qOrder="17" qId="30"><A aOrder="1" aId="120" /><A aOrder="2" aId="119" /><A aOrder="3" aId="118" /><A aOrder="4" aId="117" /></Q><Q qOrder="18" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="79" /><A aOrder="3" aId="78" /><A aOrder="4" aId="80" /></Q><Q qOrder="19" qId="37"><A aOrder="1" aId="147" /><A aOrder="2" aId="148" /><A aOrder="3" aId="145" /><A aOrder="4" aId="146" /></Q><Q qOrder="20" qId="33"><A aOrder="1" aId="131" /><A aOrder="2" aId="129" /><A aOrder="3" aId="130" /><A aOrder="4" aId="132" /></Q><Q qOrder="21" qId="27"><A aOrder="1" aId="106" /><A aOrder="2" aId="107" /><A aOrder="3" aId="105" /><A aOrder="4" aId="108" /></Q><Q qOrder="22" qId="34"><A aOrder="1" aId="136" /><A aOrder="2" aId="135" /><A aOrder="3" aId="134" /><A aOrder="4" aId="133" /></Q><Q qOrder="23" qId="12"><A aOrder="1" aId="48" /><A aOrder="2" aId="47" /><A aOrder="3" aId="45" /><A aOrder="4" aId="46" /></Q><Q qOrder="24" qId="10"><A aOrder="1" aId="39" /><A aOrder="2" aId="40" /><A aOrder="3" aId="38" /><A aOrder="4" aId="37" /></Q><Q qOrder="25" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="82" /><A aOrder="3" aId="83" /><A aOrder="4" aId="84" /></Q><Q qOrder="26" qId="31"><A aOrder="1" aId="122" /><A aOrder="2" aId="124" /><A aOrder="3" aId="121" /><A aOrder="4" aId="123" /></Q><Q qOrder="27" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="63" /><A aOrder="3" aId="62" /><A aOrder="4" aId="64" /></Q><Q qOrder="28" qId="22"><A aOrder="1" aId="87" /><A aOrder="2" aId="88" /><A aOrder="3" aId="86" /><A aOrder="4" aId="85" /></Q><Q qOrder="29" qId="17"><A aOrder="1" aId="67" /><A aOrder="2" aId="65" /><A aOrder="3" aId="66" /><A aOrder="4" aId="68" /></Q><Q qOrder="30" qId="36"><A aOrder="1" aId="142" /><A aOrder="2" aId="143" /><A aOrder="3" aId="144" /><A aOrder="4" aId="141" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (13, 4, N'<TestCopy><Q qOrder="1" qId="23"><A aOrder="1" aId="92" /><A aOrder="2" aId="89" /><A aOrder="3" aId="91" /><A aOrder="4" aId="90" /></Q><Q qOrder="2" qId="19"><A aOrder="1" aId="74" /><A aOrder="2" aId="73" /><A aOrder="3" aId="75" /><A aOrder="4" aId="76" /></Q><Q qOrder="3" qId="34"><A aOrder="1" aId="136" /><A aOrder="2" aId="133" /><A aOrder="3" aId="135" /><A aOrder="4" aId="134" /></Q><Q qOrder="4" qId="25"><A aOrder="1" aId="100" /><A aOrder="2" aId="99" /><A aOrder="3" aId="98" /><A aOrder="4" aId="97" /></Q><Q qOrder="5" qId="8"><A aOrder="1" aId="31" /><A aOrder="2" aId="32" /><A aOrder="3" aId="29" /><A aOrder="4" aId="30" /></Q><Q qOrder="6" qId="37"><A aOrder="1" aId="148" /><A aOrder="2" aId="147" /><A aOrder="3" aId="146" /><A aOrder="4" aId="145" /></Q><Q qOrder="7" qId="16"><A aOrder="1" aId="64" /><A aOrder="2" aId="61" /><A aOrder="3" aId="62" /><A aOrder="4" aId="63" /></Q><Q qOrder="8" qId="32"><A aOrder="1" aId="128" /><A aOrder="2" aId="127" /><A aOrder="3" aId="126" /><A aOrder="4" aId="125" /></Q><Q qOrder="9" qId="29"><A aOrder="1" aId="116" /><A aOrder="2" aId="115" /><A aOrder="3" aId="114" /><A aOrder="4" aId="113" /></Q><Q qOrder="10" qId="28"><A aOrder="1" aId="110" /><A aOrder="2" aId="112" /><A aOrder="3" aId="109" /><A aOrder="4" aId="111" /></Q><Q qOrder="11" qId="18"><A aOrder="1" aId="72" /><A aOrder="2" aId="70" /><A aOrder="3" aId="71" /><A aOrder="4" aId="69" /></Q><Q qOrder="12" qId="22"><A aOrder="1" aId="88" /><A aOrder="2" aId="86" /><A aOrder="3" aId="85" /><A aOrder="4" aId="87" /></Q><Q qOrder="13" qId="12"><A aOrder="1" aId="48" /><A aOrder="2" aId="47" /><A aOrder="3" aId="46" /><A aOrder="4" aId="45" /></Q><Q qOrder="14" qId="36"><A aOrder="1" aId="141" /><A aOrder="2" aId="142" /><A aOrder="3" aId="144" /><A aOrder="4" aId="143" /></Q><Q qOrder="15" qId="13"><A aOrder="1" aId="49" /><A aOrder="2" aId="52" /><A aOrder="3" aId="50" /><A aOrder="4" aId="51" /></Q><Q qOrder="16" qId="15"><A aOrder="1" aId="59" /><A aOrder="2" aId="58" /><A aOrder="3" aId="57" /><A aOrder="4" aId="60" /></Q><Q qOrder="17" qId="9"><A aOrder="1" aId="36" /><A aOrder="2" aId="35" /><A aOrder="3" aId="33" /><A aOrder="4" aId="34" /></Q><Q qOrder="18" qId="31"><A aOrder="1" aId="123" /><A aOrder="2" aId="124" /><A aOrder="3" aId="121" /><A aOrder="4" aId="122" /></Q><Q qOrder="19" qId="10"><A aOrder="1" aId="37" /><A aOrder="2" aId="40" /><A aOrder="3" aId="38" /><A aOrder="4" aId="39" /></Q><Q qOrder="20" qId="26"><A aOrder="1" aId="101" /><A aOrder="2" aId="102" /><A aOrder="3" aId="103" /><A aOrder="4" aId="104" /></Q><Q qOrder="21" qId="14"><A aOrder="1" aId="54" /><A aOrder="2" aId="56" /><A aOrder="3" aId="53" /><A aOrder="4" aId="55" /></Q><Q qOrder="22" qId="33"><A aOrder="1" aId="132" /><A aOrder="2" aId="129" /><A aOrder="3" aId="130" /><A aOrder="4" aId="131" /></Q><Q qOrder="23" qId="30"><A aOrder="1" aId="119" /><A aOrder="2" aId="120" /><A aOrder="3" aId="117" /><A aOrder="4" aId="118" /></Q><Q qOrder="24" qId="11"><A aOrder="1" aId="43" /><A aOrder="2" aId="42" /><A aOrder="3" aId="41" /><A aOrder="4" aId="44" /></Q><Q qOrder="25" qId="17"><A aOrder="1" aId="66" /><A aOrder="2" aId="67" /><A aOrder="3" aId="65" /><A aOrder="4" aId="68" /></Q><Q qOrder="26" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="83" /><A aOrder="3" aId="84" /><A aOrder="4" aId="82" /></Q><Q qOrder="27" qId="35"><A aOrder="1" aId="137" /><A aOrder="2" aId="140" /><A aOrder="3" aId="138" /><A aOrder="4" aId="139" /></Q><Q qOrder="28" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="108" /><A aOrder="3" aId="107" /><A aOrder="4" aId="106" /></Q><Q qOrder="29" qId="38"><A aOrder="1" aId="152" /><A aOrder="2" aId="151" /><A aOrder="3" aId="149" /><A aOrder="4" aId="150" /></Q><Q qOrder="30" qId="20"><A aOrder="1" aId="80" /><A aOrder="2" aId="79" /><A aOrder="3" aId="78" /><A aOrder="4" aId="77" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (14, 4, N'<TestCopy><Q qOrder="1" qId="30"><A aOrder="1" aId="120" /><A aOrder="2" aId="119" /><A aOrder="3" aId="118" /><A aOrder="4" aId="117" /></Q><Q qOrder="2" qId="32"><A aOrder="1" aId="125" /><A aOrder="2" aId="128" /><A aOrder="3" aId="127" /><A aOrder="4" aId="126" /></Q><Q qOrder="3" qId="12"><A aOrder="1" aId="47" /><A aOrder="2" aId="48" /><A aOrder="3" aId="46" /><A aOrder="4" aId="45" /></Q><Q qOrder="4" qId="22"><A aOrder="1" aId="88" /><A aOrder="2" aId="85" /><A aOrder="3" aId="87" /><A aOrder="4" aId="86" /></Q><Q qOrder="5" qId="11"><A aOrder="1" aId="42" /><A aOrder="2" aId="41" /><A aOrder="3" aId="44" /><A aOrder="4" aId="43" /></Q><Q qOrder="6" qId="25"><A aOrder="1" aId="99" /><A aOrder="2" aId="98" /><A aOrder="3" aId="97" /><A aOrder="4" aId="100" /></Q><Q qOrder="7" qId="35"><A aOrder="1" aId="138" /><A aOrder="2" aId="140" /><A aOrder="3" aId="137" /><A aOrder="4" aId="139" /></Q><Q qOrder="8" qId="13"><A aOrder="1" aId="50" /><A aOrder="2" aId="49" /><A aOrder="3" aId="51" /><A aOrder="4" aId="52" /></Q><Q qOrder="9" qId="8"><A aOrder="1" aId="29" /><A aOrder="2" aId="31" /><A aOrder="3" aId="32" /><A aOrder="4" aId="30" /></Q><Q qOrder="10" qId="19"><A aOrder="1" aId="76" /><A aOrder="2" aId="75" /><A aOrder="3" aId="74" /><A aOrder="4" aId="73" /></Q><Q qOrder="11" qId="15"><A aOrder="1" aId="57" /><A aOrder="2" aId="60" /><A aOrder="3" aId="58" /><A aOrder="4" aId="59" /></Q><Q qOrder="12" qId="36"><A aOrder="1" aId="144" /><A aOrder="2" aId="143" /><A aOrder="3" aId="141" /><A aOrder="4" aId="142" /></Q><Q qOrder="13" qId="18"><A aOrder="1" aId="70" /><A aOrder="2" aId="72" /><A aOrder="3" aId="71" /><A aOrder="4" aId="69" /></Q><Q qOrder="14" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="79" /><A aOrder="3" aId="78" /><A aOrder="4" aId="80" /></Q><Q qOrder="15" qId="31"><A aOrder="1" aId="122" /><A aOrder="2" aId="121" /><A aOrder="3" aId="123" /><A aOrder="4" aId="124" /></Q><Q qOrder="16" qId="34"><A aOrder="1" aId="136" /><A aOrder="2" aId="133" /><A aOrder="3" aId="135" /><A aOrder="4" aId="134" /></Q><Q qOrder="17" qId="23"><A aOrder="1" aId="92" /><A aOrder="2" aId="89" /><A aOrder="3" aId="90" /><A aOrder="4" aId="91" /></Q><Q qOrder="18" qId="14"><A aOrder="1" aId="56" /><A aOrder="2" aId="54" /><A aOrder="3" aId="55" /><A aOrder="4" aId="53" /></Q><Q qOrder="19" qId="37"><A aOrder="1" aId="146" /><A aOrder="2" aId="148" /><A aOrder="3" aId="147" /><A aOrder="4" aId="145" /></Q><Q qOrder="20" qId="27"><A aOrder="1" aId="108" /><A aOrder="2" aId="107" /><A aOrder="3" aId="106" /><A aOrder="4" aId="105" /></Q><Q qOrder="21" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="84" /><A aOrder="3" aId="83" /><A aOrder="4" aId="82" /></Q><Q qOrder="22" qId="38"><A aOrder="1" aId="151" /><A aOrder="2" aId="152" /><A aOrder="3" aId="149" /><A aOrder="4" aId="150" /></Q><Q qOrder="23" qId="9"><A aOrder="1" aId="34" /><A aOrder="2" aId="35" /><A aOrder="3" aId="36" /><A aOrder="4" aId="33" /></Q><Q qOrder="24" qId="17"><A aOrder="1" aId="67" /><A aOrder="2" aId="66" /><A aOrder="3" aId="65" /><A aOrder="4" aId="68" /></Q><Q qOrder="25" qId="10"><A aOrder="1" aId="38" /><A aOrder="2" aId="40" /><A aOrder="3" aId="37" /><A aOrder="4" aId="39" /></Q><Q qOrder="26" qId="28"><A aOrder="1" aId="112" /><A aOrder="2" aId="110" /><A aOrder="3" aId="111" /><A aOrder="4" aId="109" /></Q><Q qOrder="27" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="62" /><A aOrder="3" aId="64" /><A aOrder="4" aId="63" /></Q><Q qOrder="28" qId="33"><A aOrder="1" aId="129" /><A aOrder="2" aId="132" /><A aOrder="3" aId="131" /><A aOrder="4" aId="130" /></Q><Q qOrder="29" qId="26"><A aOrder="1" aId="103" /><A aOrder="2" aId="101" /><A aOrder="3" aId="104" /><A aOrder="4" aId="102" /></Q><Q qOrder="30" qId="29"><A aOrder="1" aId="116" /><A aOrder="2" aId="115" /><A aOrder="3" aId="113" /><A aOrder="4" aId="114" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (15, 5, N'<TestCopy><Q qOrder="1" qId="36"><A aOrder="1" aId="141" /><A aOrder="2" aId="142" /><A aOrder="3" aId="143" /><A aOrder="4" aId="144" /></Q><Q qOrder="2" qId="23"><A aOrder="1" aId="89" /><A aOrder="2" aId="90" /><A aOrder="3" aId="91" /><A aOrder="4" aId="92" /></Q><Q qOrder="3" qId="29"><A aOrder="1" aId="114" /><A aOrder="2" aId="115" /><A aOrder="3" aId="113" /><A aOrder="4" aId="116" /></Q><Q qOrder="4" qId="30"><A aOrder="1" aId="118" /><A aOrder="2" aId="119" /><A aOrder="3" aId="120" /><A aOrder="4" aId="117" /></Q><Q qOrder="5" qId="32"><A aOrder="1" aId="128" /><A aOrder="2" aId="126" /><A aOrder="3" aId="127" /><A aOrder="4" aId="125" /></Q><Q qOrder="6" qId="25"><A aOrder="1" aId="98" /><A aOrder="2" aId="100" /><A aOrder="3" aId="99" /><A aOrder="4" aId="97" /></Q><Q qOrder="7" qId="33"><A aOrder="1" aId="129" /><A aOrder="2" aId="131" /><A aOrder="3" aId="132" /><A aOrder="4" aId="130" /></Q><Q qOrder="8" qId="27"><A aOrder="1" aId="106" /><A aOrder="2" aId="105" /><A aOrder="3" aId="107" /><A aOrder="4" aId="108" /></Q><Q qOrder="9" qId="42"><A aOrder="1" aId="165" /><A aOrder="2" aId="166" /><A aOrder="3" aId="167" /><A aOrder="4" aId="168" /></Q><Q qOrder="10" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="110" /><A aOrder="3" aId="111" /><A aOrder="4" aId="112" /></Q><Q qOrder="11" qId="22"><A aOrder="1" aId="85" /><A aOrder="2" aId="87" /><A aOrder="3" aId="86" /><A aOrder="4" aId="88" /></Q><Q qOrder="12" qId="39"><A aOrder="1" aId="155" /><A aOrder="2" aId="156" /><A aOrder="3" aId="154" /><A aOrder="4" aId="153" /></Q><Q qOrder="13" qId="37"><A aOrder="1" aId="146" /><A aOrder="2" aId="145" /><A aOrder="3" aId="148" /><A aOrder="4" aId="147" /></Q><Q qOrder="14" qId="17"><A aOrder="1" aId="67" /><A aOrder="2" aId="68" /><A aOrder="3" aId="65" /><A aOrder="4" aId="66" /></Q><Q qOrder="15" qId="26"><A aOrder="1" aId="102" /><A aOrder="2" aId="104" /><A aOrder="3" aId="103" /><A aOrder="4" aId="101" /></Q><Q qOrder="16" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="182" /><A aOrder="3" aId="183" /><A aOrder="4" aId="184" /></Q><Q qOrder="17" qId="44"><A aOrder="1" aId="174" /><A aOrder="2" aId="175" /><A aOrder="3" aId="173" /><A aOrder="4" aId="176" /></Q><Q qOrder="18" qId="38"><A aOrder="1" aId="149" /><A aOrder="2" aId="152" /><A aOrder="3" aId="150" /><A aOrder="4" aId="151" /></Q><Q qOrder="19" qId="40"><A aOrder="1" aId="160" /><A aOrder="2" aId="159" /><A aOrder="3" aId="158" /><A aOrder="4" aId="157" /></Q><Q qOrder="20" qId="34"><A aOrder="1" aId="133" /><A aOrder="2" aId="134" /><A aOrder="3" aId="135" /><A aOrder="4" aId="136" /></Q><Q qOrder="21" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="180" /><A aOrder="4" aId="179" /></Q><Q qOrder="22" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="80" /><A aOrder="3" aId="78" /><A aOrder="4" aId="79" /></Q><Q qOrder="23" qId="41"><A aOrder="1" aId="163" /><A aOrder="2" aId="161" /><A aOrder="3" aId="164" /><A aOrder="4" aId="162" /></Q><Q qOrder="24" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="123" /><A aOrder="3" aId="122" /><A aOrder="4" aId="124" /></Q><Q qOrder="25" qId="21"><A aOrder="1" aId="83" /><A aOrder="2" aId="82" /><A aOrder="3" aId="81" /><A aOrder="4" aId="84" /></Q><Q qOrder="26" qId="35"><A aOrder="1" aId="137" /><A aOrder="2" aId="139" /><A aOrder="3" aId="140" /><A aOrder="4" aId="138" /></Q><Q qOrder="27" qId="18"><A aOrder="1" aId="69" /><A aOrder="2" aId="70" /><A aOrder="3" aId="71" /><A aOrder="4" aId="72" /></Q><Q qOrder="28" qId="47"><A aOrder="1" aId="188" /><A aOrder="2" aId="187" /><A aOrder="3" aId="185" /><A aOrder="4" aId="186" /></Q><Q qOrder="29" qId="19"><A aOrder="1" aId="73" /><A aOrder="2" aId="76" /><A aOrder="3" aId="75" /><A aOrder="4" aId="74" /></Q><Q qOrder="30" qId="43"><A aOrder="1" aId="169" /><A aOrder="2" aId="170" /><A aOrder="3" aId="171" /><A aOrder="4" aId="172" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (16, 5, N'<TestCopy><Q qOrder="1" qId="35"><A aOrder="1" aId="139" /><A aOrder="2" aId="137" /><A aOrder="3" aId="138" /><A aOrder="4" aId="140" /></Q><Q qOrder="2" qId="46"><A aOrder="1" aId="183" /><A aOrder="2" aId="182" /><A aOrder="3" aId="181" /><A aOrder="4" aId="184" /></Q><Q qOrder="3" qId="21"><A aOrder="1" aId="84" /><A aOrder="2" aId="83" /><A aOrder="3" aId="82" /><A aOrder="4" aId="81" /></Q><Q qOrder="4" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="180" /><A aOrder="4" aId="179" /></Q><Q qOrder="5" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="123" /><A aOrder="3" aId="122" /><A aOrder="4" aId="124" /></Q><Q qOrder="6" qId="34"><A aOrder="1" aId="135" /><A aOrder="2" aId="134" /><A aOrder="3" aId="133" /><A aOrder="4" aId="136" /></Q><Q qOrder="7" qId="32"><A aOrder="1" aId="128" /><A aOrder="2" aId="125" /><A aOrder="3" aId="126" /><A aOrder="4" aId="127" /></Q><Q qOrder="8" qId="44"><A aOrder="1" aId="173" /><A aOrder="2" aId="174" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="9" qId="28"><A aOrder="1" aId="110" /><A aOrder="2" aId="111" /><A aOrder="3" aId="109" /><A aOrder="4" aId="112" /></Q><Q qOrder="10" qId="39"><A aOrder="1" aId="155" /><A aOrder="2" aId="153" /><A aOrder="3" aId="154" /><A aOrder="4" aId="156" /></Q><Q qOrder="11" qId="22"><A aOrder="1" aId="87" /><A aOrder="2" aId="86" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="12" qId="20"><A aOrder="1" aId="78" /><A aOrder="2" aId="80" /><A aOrder="3" aId="79" /><A aOrder="4" aId="77" /></Q><Q qOrder="13" qId="33"><A aOrder="1" aId="131" /><A aOrder="2" aId="132" /><A aOrder="3" aId="129" /><A aOrder="4" aId="130" /></Q><Q qOrder="14" qId="42"><A aOrder="1" aId="167" /><A aOrder="2" aId="166" /><A aOrder="3" aId="168" /><A aOrder="4" aId="165" /></Q><Q qOrder="15" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="108" /><A aOrder="4" aId="107" /></Q><Q qOrder="16" qId="26"><A aOrder="1" aId="102" /><A aOrder="2" aId="103" /><A aOrder="3" aId="104" /><A aOrder="4" aId="101" /></Q><Q qOrder="17" qId="38"><A aOrder="1" aId="149" /><A aOrder="2" aId="152" /><A aOrder="3" aId="150" /><A aOrder="4" aId="151" /></Q><Q qOrder="18" qId="17"><A aOrder="1" aId="67" /><A aOrder="2" aId="65" /><A aOrder="3" aId="68" /><A aOrder="4" aId="66" /></Q><Q qOrder="19" qId="40"><A aOrder="1" aId="159" /><A aOrder="2" aId="157" /><A aOrder="3" aId="160" /><A aOrder="4" aId="158" /></Q><Q qOrder="20" qId="47"><A aOrder="1" aId="187" /><A aOrder="2" aId="188" /><A aOrder="3" aId="186" /><A aOrder="4" aId="185" /></Q><Q qOrder="21" qId="43"><A aOrder="1" aId="169" /><A aOrder="2" aId="170" /><A aOrder="3" aId="172" /><A aOrder="4" aId="171" /></Q><Q qOrder="22" qId="29"><A aOrder="1" aId="116" /><A aOrder="2" aId="114" /><A aOrder="3" aId="113" /><A aOrder="4" aId="115" /></Q><Q qOrder="23" qId="18"><A aOrder="1" aId="71" /><A aOrder="2" aId="72" /><A aOrder="3" aId="69" /><A aOrder="4" aId="70" /></Q><Q qOrder="24" qId="19"><A aOrder="1" aId="75" /><A aOrder="2" aId="76" /><A aOrder="3" aId="74" /><A aOrder="4" aId="73" /></Q><Q qOrder="25" qId="37"><A aOrder="1" aId="148" /><A aOrder="2" aId="147" /><A aOrder="3" aId="145" /><A aOrder="4" aId="146" /></Q><Q qOrder="26" qId="36"><A aOrder="1" aId="144" /><A aOrder="2" aId="141" /><A aOrder="3" aId="142" /><A aOrder="4" aId="143" /></Q><Q qOrder="27" qId="41"><A aOrder="1" aId="163" /><A aOrder="2" aId="162" /><A aOrder="3" aId="161" /><A aOrder="4" aId="164" /></Q><Q qOrder="28" qId="23"><A aOrder="1" aId="90" /><A aOrder="2" aId="89" /><A aOrder="3" aId="92" /><A aOrder="4" aId="91" /></Q><Q qOrder="29" qId="30"><A aOrder="1" aId="118" /><A aOrder="2" aId="120" /><A aOrder="3" aId="117" /><A aOrder="4" aId="119" /></Q><Q qOrder="30" qId="25"><A aOrder="1" aId="100" /><A aOrder="2" aId="99" /><A aOrder="3" aId="97" /><A aOrder="4" aId="98" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (17, 5, N'<TestCopy><Q qOrder="1" qId="41"><A aOrder="1" aId="164" /><A aOrder="2" aId="161" /><A aOrder="3" aId="162" /><A aOrder="4" aId="163" /></Q><Q qOrder="2" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="82" /><A aOrder="3" aId="84" /><A aOrder="4" aId="83" /></Q><Q qOrder="3" qId="35"><A aOrder="1" aId="138" /><A aOrder="2" aId="139" /><A aOrder="3" aId="140" /><A aOrder="4" aId="137" /></Q><Q qOrder="4" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="108" /><A aOrder="4" aId="107" /></Q><Q qOrder="5" qId="28"><A aOrder="1" aId="111" /><A aOrder="2" aId="109" /><A aOrder="3" aId="110" /><A aOrder="4" aId="112" /></Q><Q qOrder="6" qId="31"><A aOrder="1" aId="123" /><A aOrder="2" aId="122" /><A aOrder="3" aId="121" /><A aOrder="4" aId="124" /></Q><Q qOrder="7" qId="37"><A aOrder="1" aId="147" /><A aOrder="2" aId="145" /><A aOrder="3" aId="148" /><A aOrder="4" aId="146" /></Q><Q qOrder="8" qId="25"><A aOrder="1" aId="99" /><A aOrder="2" aId="97" /><A aOrder="3" aId="98" /><A aOrder="4" aId="100" /></Q><Q qOrder="9" qId="32"><A aOrder="1" aId="126" /><A aOrder="2" aId="127" /><A aOrder="3" aId="125" /><A aOrder="4" aId="128" /></Q><Q qOrder="10" qId="38"><A aOrder="1" aId="152" /><A aOrder="2" aId="150" /><A aOrder="3" aId="151" /><A aOrder="4" aId="149" /></Q><Q qOrder="11" qId="33"><A aOrder="1" aId="130" /><A aOrder="2" aId="132" /><A aOrder="3" aId="131" /><A aOrder="4" aId="129" /></Q><Q qOrder="12" qId="23"><A aOrder="1" aId="91" /><A aOrder="2" aId="89" /><A aOrder="3" aId="90" /><A aOrder="4" aId="92" /></Q><Q qOrder="13" qId="43"><A aOrder="1" aId="169" /><A aOrder="2" aId="170" /><A aOrder="3" aId="172" /><A aOrder="4" aId="171" /></Q><Q qOrder="14" qId="34"><A aOrder="1" aId="135" /><A aOrder="2" aId="133" /><A aOrder="3" aId="134" /><A aOrder="4" aId="136" /></Q><Q qOrder="15" qId="20"><A aOrder="1" aId="80" /><A aOrder="2" aId="79" /><A aOrder="3" aId="77" /><A aOrder="4" aId="78" /></Q><Q qOrder="16" qId="19"><A aOrder="1" aId="76" /><A aOrder="2" aId="75" /><A aOrder="3" aId="73" /><A aOrder="4" aId="74" /></Q><Q qOrder="17" qId="44"><A aOrder="1" aId="173" /><A aOrder="2" aId="174" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="18" qId="47"><A aOrder="1" aId="186" /><A aOrder="2" aId="188" /><A aOrder="3" aId="185" /><A aOrder="4" aId="187" /></Q><Q qOrder="19" qId="45"><A aOrder="1" aId="177" /><A aOrder="2" aId="178" /><A aOrder="3" aId="180" /><A aOrder="4" aId="179" /></Q><Q qOrder="20" qId="29"><A aOrder="1" aId="114" /><A aOrder="2" aId="116" /><A aOrder="3" aId="113" /><A aOrder="4" aId="115" /></Q><Q qOrder="21" qId="30"><A aOrder="1" aId="119" /><A aOrder="2" aId="117" /><A aOrder="3" aId="120" /><A aOrder="4" aId="118" /></Q><Q qOrder="22" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="182" /><A aOrder="3" aId="183" /><A aOrder="4" aId="184" /></Q><Q qOrder="23" qId="40"><A aOrder="1" aId="157" /><A aOrder="2" aId="158" /><A aOrder="3" aId="160" /><A aOrder="4" aId="159" /></Q><Q qOrder="24" qId="39"><A aOrder="1" aId="155" /><A aOrder="2" aId="153" /><A aOrder="3" aId="156" /><A aOrder="4" aId="154" /></Q><Q qOrder="25" qId="26"><A aOrder="1" aId="102" /><A aOrder="2" aId="104" /><A aOrder="3" aId="103" /><A aOrder="4" aId="101" /></Q><Q qOrder="26" qId="42"><A aOrder="1" aId="168" /><A aOrder="2" aId="166" /><A aOrder="3" aId="167" /><A aOrder="4" aId="165" /></Q><Q qOrder="27" qId="36"><A aOrder="1" aId="144" /><A aOrder="2" aId="142" /><A aOrder="3" aId="143" /><A aOrder="4" aId="141" /></Q><Q qOrder="28" qId="17"><A aOrder="1" aId="65" /><A aOrder="2" aId="67" /><A aOrder="3" aId="68" /><A aOrder="4" aId="66" /></Q><Q qOrder="29" qId="22"><A aOrder="1" aId="86" /><A aOrder="2" aId="85" /><A aOrder="3" aId="87" /><A aOrder="4" aId="88" /></Q><Q qOrder="30" qId="18"><A aOrder="1" aId="69" /><A aOrder="2" aId="70" /><A aOrder="3" aId="72" /><A aOrder="4" aId="71" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (18, 5, N'<TestCopy><Q qOrder="1" qId="30"><A aOrder="1" aId="117" /><A aOrder="2" aId="120" /><A aOrder="3" aId="118" /><A aOrder="4" aId="119" /></Q><Q qOrder="2" qId="37"><A aOrder="1" aId="146" /><A aOrder="2" aId="148" /><A aOrder="3" aId="147" /><A aOrder="4" aId="145" /></Q><Q qOrder="3" qId="34"><A aOrder="1" aId="134" /><A aOrder="2" aId="133" /><A aOrder="3" aId="135" /><A aOrder="4" aId="136" /></Q><Q qOrder="4" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="123" /><A aOrder="3" aId="122" /><A aOrder="4" aId="124" /></Q><Q qOrder="5" qId="47"><A aOrder="1" aId="188" /><A aOrder="2" aId="185" /><A aOrder="3" aId="186" /><A aOrder="4" aId="187" /></Q><Q qOrder="6" qId="21"><A aOrder="1" aId="84" /><A aOrder="2" aId="83" /><A aOrder="3" aId="81" /><A aOrder="4" aId="82" /></Q><Q qOrder="7" qId="46"><A aOrder="1" aId="183" /><A aOrder="2" aId="181" /><A aOrder="3" aId="182" /><A aOrder="4" aId="184" /></Q><Q qOrder="8" qId="18"><A aOrder="1" aId="69" /><A aOrder="2" aId="70" /><A aOrder="3" aId="72" /><A aOrder="4" aId="71" /></Q><Q qOrder="9" qId="38"><A aOrder="1" aId="149" /><A aOrder="2" aId="152" /><A aOrder="3" aId="150" /><A aOrder="4" aId="151" /></Q><Q qOrder="10" qId="29"><A aOrder="1" aId="115" /><A aOrder="2" aId="114" /><A aOrder="3" aId="116" /><A aOrder="4" aId="113" /></Q><Q qOrder="11" qId="26"><A aOrder="1" aId="101" /><A aOrder="2" aId="104" /><A aOrder="3" aId="102" /><A aOrder="4" aId="103" /></Q><Q qOrder="12" qId="41"><A aOrder="1" aId="163" /><A aOrder="2" aId="162" /><A aOrder="3" aId="164" /><A aOrder="4" aId="161" /></Q><Q qOrder="13" qId="25"><A aOrder="1" aId="97" /><A aOrder="2" aId="99" /><A aOrder="3" aId="100" /><A aOrder="4" aId="98" /></Q><Q qOrder="14" qId="22"><A aOrder="1" aId="85" /><A aOrder="2" aId="87" /><A aOrder="3" aId="86" /><A aOrder="4" aId="88" /></Q><Q qOrder="15" qId="23"><A aOrder="1" aId="90" /><A aOrder="2" aId="89" /><A aOrder="3" aId="91" /><A aOrder="4" aId="92" /></Q><Q qOrder="16" qId="33"><A aOrder="1" aId="129" /><A aOrder="2" aId="132" /><A aOrder="3" aId="130" /><A aOrder="4" aId="131" /></Q><Q qOrder="17" qId="35"><A aOrder="1" aId="138" /><A aOrder="2" aId="139" /><A aOrder="3" aId="140" /><A aOrder="4" aId="137" /></Q><Q qOrder="18" qId="44"><A aOrder="1" aId="174" /><A aOrder="2" aId="173" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="19" qId="42"><A aOrder="1" aId="167" /><A aOrder="2" aId="165" /><A aOrder="3" aId="168" /><A aOrder="4" aId="166" /></Q><Q qOrder="20" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="107" /><A aOrder="4" aId="108" /></Q><Q qOrder="21" qId="36"><A aOrder="1" aId="144" /><A aOrder="2" aId="141" /><A aOrder="3" aId="143" /><A aOrder="4" aId="142" /></Q><Q qOrder="22" qId="40"><A aOrder="1" aId="157" /><A aOrder="2" aId="160" /><A aOrder="3" aId="159" /><A aOrder="4" aId="158" /></Q><Q qOrder="23" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="180" /><A aOrder="4" aId="179" /></Q><Q qOrder="24" qId="20"><A aOrder="1" aId="79" /><A aOrder="2" aId="80" /><A aOrder="3" aId="78" /><A aOrder="4" aId="77" /></Q><Q qOrder="25" qId="43"><A aOrder="1" aId="170" /><A aOrder="2" aId="169" /><A aOrder="3" aId="172" /><A aOrder="4" aId="171" /></Q><Q qOrder="26" qId="17"><A aOrder="1" aId="66" /><A aOrder="2" aId="65" /><A aOrder="3" aId="68" /><A aOrder="4" aId="67" /></Q><Q qOrder="27" qId="39"><A aOrder="1" aId="156" /><A aOrder="2" aId="155" /><A aOrder="3" aId="153" /><A aOrder="4" aId="154" /></Q><Q qOrder="28" qId="32"><A aOrder="1" aId="127" /><A aOrder="2" aId="126" /><A aOrder="3" aId="128" /><A aOrder="4" aId="125" /></Q><Q qOrder="29" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="111" /><A aOrder="3" aId="110" /><A aOrder="4" aId="112" /></Q><Q qOrder="30" qId="19"><A aOrder="1" aId="74" /><A aOrder="2" aId="76" /><A aOrder="3" aId="75" /><A aOrder="4" aId="73" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (23, 7, N'<TestCopy><Q qOrder="1" qId="26"><A aOrder="1" aId="101" /><A aOrder="2" aId="102" /><A aOrder="3" aId="104" /><A aOrder="4" aId="103" /></Q><Q qOrder="2" qId="20"><A aOrder="1" aId="80" /><A aOrder="2" aId="77" /><A aOrder="3" aId="79" /><A aOrder="4" aId="78" /></Q><Q qOrder="3" qId="5"><A aOrder="1" aId="19" /><A aOrder="2" aId="20" /><A aOrder="3" aId="17" /><A aOrder="4" aId="18" /></Q><Q qOrder="4" qId="7"><A aOrder="1" aId="27" /><A aOrder="2" aId="28" /><A aOrder="3" aId="25" /><A aOrder="4" aId="26" /></Q><Q qOrder="5" qId="18"><A aOrder="1" aId="71" /><A aOrder="2" aId="69" /><A aOrder="3" aId="70" /><A aOrder="4" aId="72" /></Q><Q qOrder="6" qId="35"><A aOrder="1" aId="140" /><A aOrder="2" aId="138" /><A aOrder="3" aId="139" /><A aOrder="4" aId="137" /></Q><Q qOrder="7" qId="16"><A aOrder="1" aId="62" /><A aOrder="2" aId="64" /><A aOrder="3" aId="61" /><A aOrder="4" aId="63" /></Q><Q qOrder="8" qId="39"><A aOrder="1" aId="155" /><A aOrder="2" aId="154" /><A aOrder="3" aId="153" /><A aOrder="4" aId="156" /></Q><Q qOrder="9" qId="19"><A aOrder="1" aId="74" /><A aOrder="2" aId="73" /><A aOrder="3" aId="76" /><A aOrder="4" aId="75" /></Q><Q qOrder="10" qId="34"><A aOrder="1" aId="135" /><A aOrder="2" aId="133" /><A aOrder="3" aId="134" /><A aOrder="4" aId="136" /></Q><Q qOrder="11" qId="32"><A aOrder="1" aId="127" /><A aOrder="2" aId="126" /><A aOrder="3" aId="125" /><A aOrder="4" aId="128" /></Q><Q qOrder="12" qId="48"><A aOrder="1" aId="190" /><A aOrder="2" aId="189" /><A aOrder="3" aId="191" /><A aOrder="4" aId="192" /></Q><Q qOrder="13" qId="8"><A aOrder="1" aId="29" /><A aOrder="2" aId="31" /><A aOrder="3" aId="32" /><A aOrder="4" aId="30" /></Q><Q qOrder="14" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="60" /><A aOrder="3" aId="59" /><A aOrder="4" aId="57" /></Q><Q qOrder="15" qId="33"><A aOrder="1" aId="130" /><A aOrder="2" aId="132" /><A aOrder="3" aId="129" /><A aOrder="4" aId="131" /></Q><Q qOrder="16" qId="12"><A aOrder="1" aId="48" /><A aOrder="2" aId="47" /><A aOrder="3" aId="46" /><A aOrder="4" aId="45" /></Q><Q qOrder="17" qId="43"><A aOrder="1" aId="169" /><A aOrder="2" aId="170" /><A aOrder="3" aId="172" /><A aOrder="4" aId="171" /></Q><Q qOrder="18" qId="36"><A aOrder="1" aId="142" /><A aOrder="2" aId="141" /><A aOrder="3" aId="143" /><A aOrder="4" aId="144" /></Q><Q qOrder="19" qId="53"><A aOrder="1" aId="209" /><A aOrder="2" aId="211" /><A aOrder="3" aId="212" /><A aOrder="4" aId="210" /></Q><Q qOrder="20" qId="49"><A aOrder="1" aId="195" /><A aOrder="2" aId="193" /><A aOrder="3" aId="194" /><A aOrder="4" aId="196" /></Q><Q qOrder="21" qId="10"><A aOrder="1" aId="40" /><A aOrder="2" aId="38" /><A aOrder="3" aId="39" /><A aOrder="4" aId="37" /></Q><Q qOrder="22" qId="2"><A aOrder="1" aId="7" /><A aOrder="2" aId="8" /><A aOrder="3" aId="5" /><A aOrder="4" aId="6" /></Q><Q qOrder="23" qId="22"><A aOrder="1" aId="86" /><A aOrder="2" aId="87" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="24" qId="51"><A aOrder="1" aId="204" /><A aOrder="2" aId="201" /><A aOrder="3" aId="202" /><A aOrder="4" aId="203" /></Q><Q qOrder="25" qId="47"><A aOrder="1" aId="186" /><A aOrder="2" aId="188" /><A aOrder="3" aId="185" /><A aOrder="4" aId="187" /></Q><Q qOrder="26" qId="44"><A aOrder="1" aId="174" /><A aOrder="2" aId="173" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="27" qId="11"><A aOrder="1" aId="44" /><A aOrder="2" aId="41" /><A aOrder="3" aId="42" /><A aOrder="4" aId="43" /></Q><Q qOrder="28" qId="23"><A aOrder="1" aId="92" /><A aOrder="2" aId="90" /><A aOrder="3" aId="91" /><A aOrder="4" aId="89" /></Q><Q qOrder="29" qId="52"><A aOrder="1" aId="207" /><A aOrder="2" aId="206" /><A aOrder="3" aId="208" /><A aOrder="4" aId="205" /></Q><Q qOrder="30" qId="37"><A aOrder="1" aId="148" /><A aOrder="2" aId="147" /><A aOrder="3" aId="146" /><A aOrder="4" aId="145" /></Q><Q qOrder="31" qId="30"><A aOrder="1" aId="119" /><A aOrder="2" aId="120" /><A aOrder="3" aId="118" /><A aOrder="4" aId="117" /></Q><Q qOrder="32" qId="31"><A aOrder="1" aId="122" /><A aOrder="2" aId="123" /><A aOrder="3" aId="121" /><A aOrder="4" aId="124" /></Q><Q qOrder="33" qId="46"><A aOrder="1" aId="183" /><A aOrder="2" aId="182" /><A aOrder="3" aId="181" /><A aOrder="4" aId="184" /></Q><Q qOrder="34" qId="25"><A aOrder="1" aId="97" /><A aOrder="2" aId="98" /><A aOrder="3" aId="99" /><A aOrder="4" aId="100" /></Q><Q qOrder="35" qId="4"><A aOrder="1" aId="16" /><A aOrder="2" aId="14" /><A aOrder="3" aId="13" /><A aOrder="4" aId="15" /></Q><Q qOrder="36" qId="42"><A aOrder="1" aId="166" /><A aOrder="2" aId="165" /><A aOrder="3" aId="168" /><A aOrder="4" aId="167" /></Q><Q qOrder="37" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="179" /><A aOrder="4" aId="180" /></Q><Q qOrder="38" qId="13"><A aOrder="1" aId="50" /><A aOrder="2" aId="51" /><A aOrder="3" aId="49" /><A aOrder="4" aId="52" /></Q><Q qOrder="39" qId="28"><A aOrder="1" aId="110" /><A aOrder="2" aId="109" /><A aOrder="3" aId="111" /><A aOrder="4" aId="112" /></Q><Q qOrder="40" qId="24"><A aOrder="1" aId="94" /><A aOrder="2" aId="95" /><A aOrder="3" aId="93" /><A aOrder="4" aId="96" /></Q><Q qOrder="41" qId="41"><A aOrder="1" aId="162" /><A aOrder="2" aId="163" /><A aOrder="3" aId="164" /><A aOrder="4" aId="161" /></Q><Q qOrder="42" qId="9"><A aOrder="1" aId="35" /><A aOrder="2" aId="33" /><A aOrder="3" aId="34" /><A aOrder="4" aId="36" /></Q><Q qOrder="43" qId="1"><A aOrder="1" aId="4" /><A aOrder="2" aId="3" /><A aOrder="3" aId="1" /><A aOrder="4" aId="2" /></Q><Q qOrder="44" qId="50"><A aOrder="1" aId="200" /><A aOrder="2" aId="198" /><A aOrder="3" aId="199" /><A aOrder="4" aId="197" /></Q><Q qOrder="45" qId="40"><A aOrder="1" aId="157" /><A aOrder="2" aId="160" /><A aOrder="3" aId="158" /><A aOrder="4" aId="159" /></Q><Q qOrder="46" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="108" /><A aOrder="4" aId="107" /></Q><Q qOrder="47" qId="3"><A aOrder="1" aId="9" /><A aOrder="2" aId="10" /><A aOrder="3" aId="11" /><A aOrder="4" aId="12" /></Q><Q qOrder="48" qId="14"><A aOrder="1" aId="54" /><A aOrder="2" aId="53" /><A aOrder="3" aId="55" /><A aOrder="4" aId="56" /></Q><Q qOrder="49" qId="17"><A aOrder="1" aId="67" /><A aOrder="2" aId="65" /><A aOrder="3" aId="68" /><A aOrder="4" aId="66" /></Q><Q qOrder="50" qId="29"><A aOrder="1" aId="114" /><A aOrder="2" aId="115" /><A aOrder="3" aId="113" /><A aOrder="4" aId="116" /></Q><Q qOrder="51" qId="54"><A aOrder="1" aId="215" /><A aOrder="2" aId="216" /><A aOrder="3" aId="213" /><A aOrder="4" aId="214" /></Q><Q qOrder="52" qId="6"><A aOrder="1" aId="21" /><A aOrder="2" aId="22" /><A aOrder="3" aId="23" /><A aOrder="4" aId="24" /></Q><Q qOrder="53" qId="38"><A aOrder="1" aId="150" /><A aOrder="2" aId="149" /><A aOrder="3" aId="151" /><A aOrder="4" aId="152" /></Q><Q qOrder="54" qId="21"><A aOrder="1" aId="83" /><A aOrder="2" aId="82" /><A aOrder="3" aId="81" /><A aOrder="4" aId="84" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (24, 7, N'<TestCopy><Q qOrder="1" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="84" /><A aOrder="3" aId="83" /><A aOrder="4" aId="82" /></Q><Q qOrder="2" qId="14"><A aOrder="1" aId="55" /><A aOrder="2" aId="53" /><A aOrder="3" aId="56" /><A aOrder="4" aId="54" /></Q><Q qOrder="3" qId="40"><A aOrder="1" aId="158" /><A aOrder="2" aId="157" /><A aOrder="3" aId="160" /><A aOrder="4" aId="159" /></Q><Q qOrder="4" qId="38"><A aOrder="1" aId="150" /><A aOrder="2" aId="152" /><A aOrder="3" aId="151" /><A aOrder="4" aId="149" /></Q><Q qOrder="5" qId="42"><A aOrder="1" aId="168" /><A aOrder="2" aId="167" /><A aOrder="3" aId="165" /><A aOrder="4" aId="166" /></Q><Q qOrder="6" qId="2"><A aOrder="1" aId="7" /><A aOrder="2" aId="6" /><A aOrder="3" aId="5" /><A aOrder="4" aId="8" /></Q><Q qOrder="7" qId="24"><A aOrder="1" aId="93" /><A aOrder="2" aId="95" /><A aOrder="3" aId="94" /><A aOrder="4" aId="96" /></Q><Q qOrder="8" qId="43"><A aOrder="1" aId="170" /><A aOrder="2" aId="169" /><A aOrder="3" aId="172" /><A aOrder="4" aId="171" /></Q><Q qOrder="9" qId="9"><A aOrder="1" aId="33" /><A aOrder="2" aId="35" /><A aOrder="3" aId="36" /><A aOrder="4" aId="34" /></Q><Q qOrder="10" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="108" /><A aOrder="4" aId="107" /></Q><Q qOrder="11" qId="33"><A aOrder="1" aId="131" /><A aOrder="2" aId="129" /><A aOrder="3" aId="130" /><A aOrder="4" aId="132" /></Q><Q qOrder="12" qId="32"><A aOrder="1" aId="127" /><A aOrder="2" aId="128" /><A aOrder="3" aId="126" /><A aOrder="4" aId="125" /></Q><Q qOrder="13" qId="19"><A aOrder="1" aId="75" /><A aOrder="2" aId="74" /><A aOrder="3" aId="73" /><A aOrder="4" aId="76" /></Q><Q qOrder="14" qId="50"><A aOrder="1" aId="198" /><A aOrder="2" aId="199" /><A aOrder="3" aId="197" /><A aOrder="4" aId="200" /></Q><Q qOrder="15" qId="29"><A aOrder="1" aId="113" /><A aOrder="2" aId="114" /><A aOrder="3" aId="115" /><A aOrder="4" aId="116" /></Q><Q qOrder="16" qId="26"><A aOrder="1" aId="104" /><A aOrder="2" aId="103" /><A aOrder="3" aId="101" /><A aOrder="4" aId="102" /></Q><Q qOrder="17" qId="54"><A aOrder="1" aId="213" /><A aOrder="2" aId="216" /><A aOrder="3" aId="215" /><A aOrder="4" aId="214" /></Q><Q qOrder="18" qId="11"><A aOrder="1" aId="43" /><A aOrder="2" aId="41" /><A aOrder="3" aId="42" /><A aOrder="4" aId="44" /></Q><Q qOrder="19" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="60" /><A aOrder="3" aId="57" /><A aOrder="4" aId="59" /></Q><Q qOrder="20" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="78" /><A aOrder="3" aId="79" /><A aOrder="4" aId="80" /></Q><Q qOrder="21" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="179" /><A aOrder="4" aId="180" /></Q><Q qOrder="22" qId="28"><A aOrder="1" aId="110" /><A aOrder="2" aId="109" /><A aOrder="3" aId="111" /><A aOrder="4" aId="112" /></Q><Q qOrder="23" qId="17"><A aOrder="1" aId="66" /><A aOrder="2" aId="65" /><A aOrder="3" aId="67" /><A aOrder="4" aId="68" /></Q><Q qOrder="24" qId="35"><A aOrder="1" aId="138" /><A aOrder="2" aId="140" /><A aOrder="3" aId="139" /><A aOrder="4" aId="137" /></Q><Q qOrder="25" qId="44"><A aOrder="1" aId="174" /><A aOrder="2" aId="175" /><A aOrder="3" aId="173" /><A aOrder="4" aId="176" /></Q><Q qOrder="26" qId="48"><A aOrder="1" aId="190" /><A aOrder="2" aId="191" /><A aOrder="3" aId="189" /><A aOrder="4" aId="192" /></Q><Q qOrder="27" qId="25"><A aOrder="1" aId="97" /><A aOrder="2" aId="99" /><A aOrder="3" aId="100" /><A aOrder="4" aId="98" /></Q><Q qOrder="28" qId="49"><A aOrder="1" aId="193" /><A aOrder="2" aId="194" /><A aOrder="3" aId="195" /><A aOrder="4" aId="196" /></Q><Q qOrder="29" qId="36"><A aOrder="1" aId="144" /><A aOrder="2" aId="141" /><A aOrder="3" aId="143" /><A aOrder="4" aId="142" /></Q><Q qOrder="30" qId="30"><A aOrder="1" aId="120" /><A aOrder="2" aId="119" /><A aOrder="3" aId="118" /><A aOrder="4" aId="117" /></Q><Q qOrder="31" qId="41"><A aOrder="1" aId="164" /><A aOrder="2" aId="161" /><A aOrder="3" aId="163" /><A aOrder="4" aId="162" /></Q><Q qOrder="32" qId="5"><A aOrder="1" aId="20" /><A aOrder="2" aId="17" /><A aOrder="3" aId="18" /><A aOrder="4" aId="19" /></Q><Q qOrder="33" qId="7"><A aOrder="1" aId="26" /><A aOrder="2" aId="28" /><A aOrder="3" aId="27" /><A aOrder="4" aId="25" /></Q><Q qOrder="34" qId="23"><A aOrder="1" aId="89" /><A aOrder="2" aId="92" /><A aOrder="3" aId="90" /><A aOrder="4" aId="91" /></Q><Q qOrder="35" qId="6"><A aOrder="1" aId="23" /><A aOrder="2" aId="21" /><A aOrder="3" aId="22" /><A aOrder="4" aId="24" /></Q><Q qOrder="36" qId="12"><A aOrder="1" aId="46" /><A aOrder="2" aId="47" /><A aOrder="3" aId="45" /><A aOrder="4" aId="48" /></Q><Q qOrder="37" qId="47"><A aOrder="1" aId="188" /><A aOrder="2" aId="187" /><A aOrder="3" aId="185" /><A aOrder="4" aId="186" /></Q><Q qOrder="38" qId="18"><A aOrder="1" aId="71" /><A aOrder="2" aId="72" /><A aOrder="3" aId="69" /><A aOrder="4" aId="70" /></Q><Q qOrder="39" qId="52"><A aOrder="1" aId="208" /><A aOrder="2" aId="206" /><A aOrder="3" aId="207" /><A aOrder="4" aId="205" /></Q><Q qOrder="40" qId="1"><A aOrder="1" aId="3" /><A aOrder="2" aId="2" /><A aOrder="3" aId="1" /><A aOrder="4" aId="4" /></Q><Q qOrder="41" qId="39"><A aOrder="1" aId="154" /><A aOrder="2" aId="156" /><A aOrder="3" aId="155" /><A aOrder="4" aId="153" /></Q><Q qOrder="42" qId="13"><A aOrder="1" aId="50" /><A aOrder="2" aId="52" /><A aOrder="3" aId="51" /><A aOrder="4" aId="49" /></Q><Q qOrder="43" qId="22"><A aOrder="1" aId="86" /><A aOrder="2" aId="87" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="44" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="183" /><A aOrder="3" aId="182" /><A aOrder="4" aId="184" /></Q><Q qOrder="45" qId="53"><A aOrder="1" aId="210" /><A aOrder="2" aId="212" /><A aOrder="3" aId="211" /><A aOrder="4" aId="209" /></Q><Q qOrder="46" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="62" /><A aOrder="3" aId="63" /><A aOrder="4" aId="64" /></Q><Q qOrder="47" qId="10"><A aOrder="1" aId="38" /><A aOrder="2" aId="39" /><A aOrder="3" aId="40" /><A aOrder="4" aId="37" /></Q><Q qOrder="48" qId="34"><A aOrder="1" aId="135" /><A aOrder="2" aId="133" /><A aOrder="3" aId="134" /><A aOrder="4" aId="136" /></Q><Q qOrder="49" qId="3"><A aOrder="1" aId="11" /><A aOrder="2" aId="10" /><A aOrder="3" aId="9" /><A aOrder="4" aId="12" /></Q><Q qOrder="50" qId="8"><A aOrder="1" aId="29" /><A aOrder="2" aId="32" /><A aOrder="3" aId="31" /><A aOrder="4" aId="30" /></Q><Q qOrder="51" qId="31"><A aOrder="1" aId="122" /><A aOrder="2" aId="121" /><A aOrder="3" aId="123" /><A aOrder="4" aId="124" /></Q><Q qOrder="52" qId="37"><A aOrder="1" aId="146" /><A aOrder="2" aId="147" /><A aOrder="3" aId="145" /><A aOrder="4" aId="148" /></Q><Q qOrder="53" qId="51"><A aOrder="1" aId="203" /><A aOrder="2" aId="202" /><A aOrder="3" aId="201" /><A aOrder="4" aId="204" /></Q><Q qOrder="54" qId="4"><A aOrder="1" aId="16" /><A aOrder="2" aId="15" /><A aOrder="3" aId="14" /><A aOrder="4" aId="13" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (25, 7, N'<TestCopy><Q qOrder="1" qId="41"><A aOrder="1" aId="163" /><A aOrder="2" aId="164" /><A aOrder="3" aId="162" /><A aOrder="4" aId="161" /></Q><Q qOrder="2" qId="33"><A aOrder="1" aId="130" /><A aOrder="2" aId="132" /><A aOrder="3" aId="129" /><A aOrder="4" aId="131" /></Q><Q qOrder="3" qId="13"><A aOrder="1" aId="49" /><A aOrder="2" aId="50" /><A aOrder="3" aId="51" /><A aOrder="4" aId="52" /></Q><Q qOrder="4" qId="53"><A aOrder="1" aId="211" /><A aOrder="2" aId="212" /><A aOrder="3" aId="209" /><A aOrder="4" aId="210" /></Q><Q qOrder="5" qId="46"><A aOrder="1" aId="183" /><A aOrder="2" aId="181" /><A aOrder="3" aId="182" /><A aOrder="4" aId="184" /></Q><Q qOrder="6" qId="6"><A aOrder="1" aId="21" /><A aOrder="2" aId="23" /><A aOrder="3" aId="22" /><A aOrder="4" aId="24" /></Q><Q qOrder="7" qId="24"><A aOrder="1" aId="94" /><A aOrder="2" aId="95" /><A aOrder="3" aId="93" /><A aOrder="4" aId="96" /></Q><Q qOrder="8" qId="2"><A aOrder="1" aId="8" /><A aOrder="2" aId="7" /><A aOrder="3" aId="5" /><A aOrder="4" aId="6" /></Q><Q qOrder="9" qId="35"><A aOrder="1" aId="140" /><A aOrder="2" aId="138" /><A aOrder="3" aId="139" /><A aOrder="4" aId="137" /></Q><Q qOrder="10" qId="37"><A aOrder="1" aId="147" /><A aOrder="2" aId="145" /><A aOrder="3" aId="146" /><A aOrder="4" aId="148" /></Q><Q qOrder="11" qId="8"><A aOrder="1" aId="32" /><A aOrder="2" aId="31" /><A aOrder="3" aId="29" /><A aOrder="4" aId="30" /></Q><Q qOrder="12" qId="49"><A aOrder="1" aId="193" /><A aOrder="2" aId="194" /><A aOrder="3" aId="195" /><A aOrder="4" aId="196" /></Q><Q qOrder="13" qId="36"><A aOrder="1" aId="142" /><A aOrder="2" aId="144" /><A aOrder="3" aId="141" /><A aOrder="4" aId="143" /></Q><Q qOrder="14" qId="9"><A aOrder="1" aId="35" /><A aOrder="2" aId="34" /><A aOrder="3" aId="36" /><A aOrder="4" aId="33" /></Q><Q qOrder="15" qId="54"><A aOrder="1" aId="213" /><A aOrder="2" aId="214" /><A aOrder="3" aId="215" /><A aOrder="4" aId="216" /></Q><Q qOrder="16" qId="43"><A aOrder="1" aId="169" /><A aOrder="2" aId="170" /><A aOrder="3" aId="172" /><A aOrder="4" aId="171" /></Q><Q qOrder="17" qId="16"><A aOrder="1" aId="64" /><A aOrder="2" aId="61" /><A aOrder="3" aId="62" /><A aOrder="4" aId="63" /></Q><Q qOrder="18" qId="40"><A aOrder="1" aId="159" /><A aOrder="2" aId="158" /><A aOrder="3" aId="157" /><A aOrder="4" aId="160" /></Q><Q qOrder="19" qId="39"><A aOrder="1" aId="154" /><A aOrder="2" aId="155" /><A aOrder="3" aId="153" /><A aOrder="4" aId="156" /></Q><Q qOrder="20" qId="5"><A aOrder="1" aId="17" /><A aOrder="2" aId="18" /><A aOrder="3" aId="20" /><A aOrder="4" aId="19" /></Q><Q qOrder="21" qId="51"><A aOrder="1" aId="203" /><A aOrder="2" aId="204" /><A aOrder="3" aId="202" /><A aOrder="4" aId="201" /></Q><Q qOrder="22" qId="42"><A aOrder="1" aId="165" /><A aOrder="2" aId="167" /><A aOrder="3" aId="166" /><A aOrder="4" aId="168" /></Q><Q qOrder="23" qId="12"><A aOrder="1" aId="47" /><A aOrder="2" aId="46" /><A aOrder="3" aId="48" /><A aOrder="4" aId="45" /></Q><Q qOrder="24" qId="23"><A aOrder="1" aId="90" /><A aOrder="2" aId="91" /><A aOrder="3" aId="92" /><A aOrder="4" aId="89" /></Q><Q qOrder="25" qId="30"><A aOrder="1" aId="117" /><A aOrder="2" aId="119" /><A aOrder="3" aId="120" /><A aOrder="4" aId="118" /></Q><Q qOrder="26" qId="44"><A aOrder="1" aId="174" /><A aOrder="2" aId="173" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="27" qId="22"><A aOrder="1" aId="87" /><A aOrder="2" aId="86" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="28" qId="47"><A aOrder="1" aId="185" /><A aOrder="2" aId="186" /><A aOrder="3" aId="188" /><A aOrder="4" aId="187" /></Q><Q qOrder="29" qId="48"><A aOrder="1" aId="191" /><A aOrder="2" aId="190" /><A aOrder="3" aId="189" /><A aOrder="4" aId="192" /></Q><Q qOrder="30" qId="10"><A aOrder="1" aId="40" /><A aOrder="2" aId="38" /><A aOrder="3" aId="39" /><A aOrder="4" aId="37" /></Q><Q qOrder="31" qId="14"><A aOrder="1" aId="56" /><A aOrder="2" aId="53" /><A aOrder="3" aId="54" /><A aOrder="4" aId="55" /></Q><Q qOrder="32" qId="15"><A aOrder="1" aId="57" /><A aOrder="2" aId="59" /><A aOrder="3" aId="58" /><A aOrder="4" aId="60" /></Q><Q qOrder="33" qId="45"><A aOrder="1" aId="177" /><A aOrder="2" aId="178" /><A aOrder="3" aId="180" /><A aOrder="4" aId="179" /></Q><Q qOrder="34" qId="29"><A aOrder="1" aId="116" /><A aOrder="2" aId="114" /><A aOrder="3" aId="115" /><A aOrder="4" aId="113" /></Q><Q qOrder="35" qId="31"><A aOrder="1" aId="122" /><A aOrder="2" aId="121" /><A aOrder="3" aId="123" /><A aOrder="4" aId="124" /></Q><Q qOrder="36" qId="3"><A aOrder="1" aId="9" /><A aOrder="2" aId="12" /><A aOrder="3" aId="10" /><A aOrder="4" aId="11" /></Q><Q qOrder="37" qId="38"><A aOrder="1" aId="152" /><A aOrder="2" aId="149" /><A aOrder="3" aId="151" /><A aOrder="4" aId="150" /></Q><Q qOrder="38" qId="27"><A aOrder="1" aId="106" /><A aOrder="2" aId="105" /><A aOrder="3" aId="108" /><A aOrder="4" aId="107" /></Q><Q qOrder="39" qId="25"><A aOrder="1" aId="99" /><A aOrder="2" aId="97" /><A aOrder="3" aId="98" /><A aOrder="4" aId="100" /></Q><Q qOrder="40" qId="20"><A aOrder="1" aId="80" /><A aOrder="2" aId="77" /><A aOrder="3" aId="78" /><A aOrder="4" aId="79" /></Q><Q qOrder="41" qId="17"><A aOrder="1" aId="68" /><A aOrder="2" aId="66" /><A aOrder="3" aId="65" /><A aOrder="4" aId="67" /></Q><Q qOrder="42" qId="1"><A aOrder="1" aId="3" /><A aOrder="2" aId="2" /><A aOrder="3" aId="1" /><A aOrder="4" aId="4" /></Q><Q qOrder="43" qId="32"><A aOrder="1" aId="126" /><A aOrder="2" aId="128" /><A aOrder="3" aId="127" /><A aOrder="4" aId="125" /></Q><Q qOrder="44" qId="7"><A aOrder="1" aId="27" /><A aOrder="2" aId="28" /><A aOrder="3" aId="26" /><A aOrder="4" aId="25" /></Q><Q qOrder="45" qId="18"><A aOrder="1" aId="69" /><A aOrder="2" aId="70" /><A aOrder="3" aId="72" /><A aOrder="4" aId="71" /></Q><Q qOrder="46" qId="34"><A aOrder="1" aId="133" /><A aOrder="2" aId="135" /><A aOrder="3" aId="134" /><A aOrder="4" aId="136" /></Q><Q qOrder="47" qId="11"><A aOrder="1" aId="44" /><A aOrder="2" aId="42" /><A aOrder="3" aId="43" /><A aOrder="4" aId="41" /></Q><Q qOrder="48" qId="26"><A aOrder="1" aId="101" /><A aOrder="2" aId="104" /><A aOrder="3" aId="102" /><A aOrder="4" aId="103" /></Q><Q qOrder="49" qId="52"><A aOrder="1" aId="205" /><A aOrder="2" aId="207" /><A aOrder="3" aId="208" /><A aOrder="4" aId="206" /></Q><Q qOrder="50" qId="21"><A aOrder="1" aId="84" /><A aOrder="2" aId="82" /><A aOrder="3" aId="81" /><A aOrder="4" aId="83" /></Q><Q qOrder="51" qId="4"><A aOrder="1" aId="16" /><A aOrder="2" aId="13" /><A aOrder="3" aId="15" /><A aOrder="4" aId="14" /></Q><Q qOrder="52" qId="50"><A aOrder="1" aId="199" /><A aOrder="2" aId="200" /><A aOrder="3" aId="197" /><A aOrder="4" aId="198" /></Q><Q qOrder="53" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="111" /><A aOrder="3" aId="110" /><A aOrder="4" aId="112" /></Q><Q qOrder="54" qId="19"><A aOrder="1" aId="73" /><A aOrder="2" aId="75" /><A aOrder="3" aId="74" /><A aOrder="4" aId="76" /></Q></TestCopy>')
INSERT [dbo].[TestCopies] ([TestCopyId], [FK_TestId], [TestCopyStructure]) VALUES (26, 7, N'<TestCopy><Q qOrder="1" qId="37"><A aOrder="1" aId="147" /><A aOrder="2" aId="145" /><A aOrder="3" aId="146" /><A aOrder="4" aId="148" /></Q><Q qOrder="2" qId="47"><A aOrder="1" aId="187" /><A aOrder="2" aId="188" /><A aOrder="3" aId="185" /><A aOrder="4" aId="186" /></Q><Q qOrder="3" qId="21"><A aOrder="1" aId="84" /><A aOrder="2" aId="83" /><A aOrder="3" aId="82" /><A aOrder="4" aId="81" /></Q><Q qOrder="4" qId="24"><A aOrder="1" aId="93" /><A aOrder="2" aId="94" /><A aOrder="3" aId="95" /><A aOrder="4" aId="96" /></Q><Q qOrder="5" qId="52"><A aOrder="1" aId="206" /><A aOrder="2" aId="208" /><A aOrder="3" aId="205" /><A aOrder="4" aId="207" /></Q><Q qOrder="6" qId="38"><A aOrder="1" aId="152" /><A aOrder="2" aId="150" /><A aOrder="3" aId="151" /><A aOrder="4" aId="149" /></Q><Q qOrder="7" qId="42"><A aOrder="1" aId="168" /><A aOrder="2" aId="165" /><A aOrder="3" aId="167" /><A aOrder="4" aId="166" /></Q><Q qOrder="8" qId="12"><A aOrder="1" aId="48" /><A aOrder="2" aId="47" /><A aOrder="3" aId="45" /><A aOrder="4" aId="46" /></Q><Q qOrder="9" qId="26"><A aOrder="1" aId="102" /><A aOrder="2" aId="103" /><A aOrder="3" aId="104" /><A aOrder="4" aId="101" /></Q><Q qOrder="10" qId="3"><A aOrder="1" aId="9" /><A aOrder="2" aId="11" /><A aOrder="3" aId="10" /><A aOrder="4" aId="12" /></Q><Q qOrder="11" qId="18"><A aOrder="1" aId="72" /><A aOrder="2" aId="70" /><A aOrder="3" aId="71" /><A aOrder="4" aId="69" /></Q><Q qOrder="12" qId="6"><A aOrder="1" aId="23" /><A aOrder="2" aId="24" /><A aOrder="3" aId="21" /><A aOrder="4" aId="22" /></Q><Q qOrder="13" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="78" /><A aOrder="3" aId="79" /><A aOrder="4" aId="80" /></Q><Q qOrder="14" qId="19"><A aOrder="1" aId="76" /><A aOrder="2" aId="73" /><A aOrder="3" aId="74" /><A aOrder="4" aId="75" /></Q><Q qOrder="15" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="107" /><A aOrder="4" aId="108" /></Q><Q qOrder="16" qId="35"><A aOrder="1" aId="140" /><A aOrder="2" aId="139" /><A aOrder="3" aId="138" /><A aOrder="4" aId="137" /></Q><Q qOrder="17" qId="46"><A aOrder="1" aId="182" /><A aOrder="2" aId="183" /><A aOrder="3" aId="181" /><A aOrder="4" aId="184" /></Q><Q qOrder="18" qId="30"><A aOrder="1" aId="117" /><A aOrder="2" aId="120" /><A aOrder="3" aId="119" /><A aOrder="4" aId="118" /></Q><Q qOrder="19" qId="41"><A aOrder="1" aId="161" /><A aOrder="2" aId="163" /><A aOrder="3" aId="162" /><A aOrder="4" aId="164" /></Q><Q qOrder="20" qId="25"><A aOrder="1" aId="99" /><A aOrder="2" aId="98" /><A aOrder="3" aId="97" /><A aOrder="4" aId="100" /></Q><Q qOrder="21" qId="43"><A aOrder="1" aId="170" /><A aOrder="2" aId="169" /><A aOrder="3" aId="172" /><A aOrder="4" aId="171" /></Q><Q qOrder="22" qId="54"><A aOrder="1" aId="216" /><A aOrder="2" aId="214" /><A aOrder="3" aId="215" /><A aOrder="4" aId="213" /></Q><Q qOrder="23" qId="5"><A aOrder="1" aId="18" /><A aOrder="2" aId="19" /><A aOrder="3" aId="17" /><A aOrder="4" aId="20" /></Q><Q qOrder="24" qId="11"><A aOrder="1" aId="42" /><A aOrder="2" aId="43" /><A aOrder="3" aId="44" /><A aOrder="4" aId="41" /></Q><Q qOrder="25" qId="34"><A aOrder="1" aId="134" /><A aOrder="2" aId="135" /><A aOrder="3" aId="133" /><A aOrder="4" aId="136" /></Q><Q qOrder="26" qId="53"><A aOrder="1" aId="209" /><A aOrder="2" aId="212" /><A aOrder="3" aId="210" /><A aOrder="4" aId="211" /></Q><Q qOrder="27" qId="29"><A aOrder="1" aId="114" /><A aOrder="2" aId="113" /><A aOrder="3" aId="116" /><A aOrder="4" aId="115" /></Q><Q qOrder="28" qId="44"><A aOrder="1" aId="174" /><A aOrder="2" aId="175" /><A aOrder="3" aId="173" /><A aOrder="4" aId="176" /></Q><Q qOrder="29" qId="49"><A aOrder="1" aId="193" /><A aOrder="2" aId="195" /><A aOrder="3" aId="194" /><A aOrder="4" aId="196" /></Q><Q qOrder="30" qId="16"><A aOrder="1" aId="63" /><A aOrder="2" aId="64" /><A aOrder="3" aId="62" /><A aOrder="4" aId="61" /></Q><Q qOrder="31" qId="32"><A aOrder="1" aId="126" /><A aOrder="2" aId="128" /><A aOrder="3" aId="125" /><A aOrder="4" aId="127" /></Q><Q qOrder="32" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="111" /><A aOrder="3" aId="110" /><A aOrder="4" aId="112" /></Q><Q qOrder="33" qId="7"><A aOrder="1" aId="25" /><A aOrder="2" aId="26" /><A aOrder="3" aId="27" /><A aOrder="4" aId="28" /></Q><Q qOrder="34" qId="23"><A aOrder="1" aId="92" /><A aOrder="2" aId="91" /><A aOrder="3" aId="89" /><A aOrder="4" aId="90" /></Q><Q qOrder="35" qId="51"><A aOrder="1" aId="203" /><A aOrder="2" aId="204" /><A aOrder="3" aId="201" /><A aOrder="4" aId="202" /></Q><Q qOrder="36" qId="10"><A aOrder="1" aId="37" /><A aOrder="2" aId="39" /><A aOrder="3" aId="38" /><A aOrder="4" aId="40" /></Q><Q qOrder="37" qId="1"><A aOrder="1" aId="1" /><A aOrder="2" aId="3" /><A aOrder="3" aId="2" /><A aOrder="4" aId="4" /></Q><Q qOrder="38" qId="48"><A aOrder="1" aId="190" /><A aOrder="2" aId="189" /><A aOrder="3" aId="191" /><A aOrder="4" aId="192" /></Q><Q qOrder="39" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="57" /><A aOrder="3" aId="59" /><A aOrder="4" aId="60" /></Q><Q qOrder="40" qId="13"><A aOrder="1" aId="51" /><A aOrder="2" aId="52" /><A aOrder="3" aId="50" /><A aOrder="4" aId="49" /></Q><Q qOrder="41" qId="9"><A aOrder="1" aId="36" /><A aOrder="2" aId="33" /><A aOrder="3" aId="34" /><A aOrder="4" aId="35" /></Q><Q qOrder="42" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="180" /><A aOrder="4" aId="179" /></Q><Q qOrder="43" qId="39"><A aOrder="1" aId="153" /><A aOrder="2" aId="154" /><A aOrder="3" aId="155" /><A aOrder="4" aId="156" /></Q><Q qOrder="44" qId="2"><A aOrder="1" aId="7" /><A aOrder="2" aId="8" /><A aOrder="3" aId="6" /><A aOrder="4" aId="5" /></Q><Q qOrder="45" qId="33"><A aOrder="1" aId="132" /><A aOrder="2" aId="130" /><A aOrder="3" aId="131" /><A aOrder="4" aId="129" /></Q><Q qOrder="46" qId="22"><A aOrder="1" aId="85" /><A aOrder="2" aId="87" /><A aOrder="3" aId="86" /><A aOrder="4" aId="88" /></Q><Q qOrder="47" qId="17"><A aOrder="1" aId="65" /><A aOrder="2" aId="68" /><A aOrder="3" aId="67" /><A aOrder="4" aId="66" /></Q><Q qOrder="48" qId="14"><A aOrder="1" aId="54" /><A aOrder="2" aId="55" /><A aOrder="3" aId="53" /><A aOrder="4" aId="56" /></Q><Q qOrder="49" qId="8"><A aOrder="1" aId="29" /><A aOrder="2" aId="30" /><A aOrder="3" aId="31" /><A aOrder="4" aId="32" /></Q><Q qOrder="50" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="123" /><A aOrder="3" aId="122" /><A aOrder="4" aId="124" /></Q><Q qOrder="51" qId="40"><A aOrder="1" aId="160" /><A aOrder="2" aId="158" /><A aOrder="3" aId="157" /><A aOrder="4" aId="159" /></Q><Q qOrder="52" qId="4"><A aOrder="1" aId="16" /><A aOrder="2" aId="15" /><A aOrder="3" aId="13" /><A aOrder="4" aId="14" /></Q><Q qOrder="53" qId="50"><A aOrder="1" aId="198" /><A aOrder="2" aId="200" /><A aOrder="3" aId="199" /><A aOrder="4" aId="197" /></Q><Q qOrder="54" qId="36"><A aOrder="1" aId="143" /><A aOrder="2" aId="142" /><A aOrder="3" aId="144" /><A aOrder="4" aId="141" /></Q></TestCopy>')
SET IDENTITY_INSERT [dbo].[TestCopies] OFF
/****** Object:  Table [dbo].[Teachers]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[Phone] [varchar](11) NULL,
	[HomePhone] [varchar](11) NULL,
	[Email] [nvarchar](50) NULL,
	[Username] [nvarchar](20) NOT NULL,
	[PassWord] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[FK_DepartmentId] [int] NOT NULL,
	[Roles] [int] NOT NULL,
	[Images] [nvarchar](250) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON
INSERT [dbo].[Teachers] ([TeacherId], [FirstName], [LastName], [Birthday], [Phone], [HomePhone], [Email], [Username], [PassWord], [IsActive], [FK_DepartmentId], [Roles], [Images]) VALUES (1, N'ADMIN', N'Administrator', CAST(0x00007B4C00000000 AS DateTime), N'123456789', N'123456789', N'abc@yahoo.com', N'admin', N'1', 1, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
/****** Object:  Table [dbo].[Questions]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [bigint] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](500) NULL,
	[Level] [int] NOT NULL,
	[FK_SubjectId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[CreatedBy] [varchar](20) NULL,
	[UpdatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Time] [float] NOT NULL,
	[Purpose] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[QuestionGuid] [uniqueidentifier] NOT NULL,
	[IsAnswerRandom] [bit] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (1, N'Dùng phím tắt nào để phóng to thu nhỏ màn hình trong Microsoft word 2003?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F58 AS DateTime), CAST(0x0000A242003D4F58 AS DateTime), 0.5, 0, 0, N'3d00146d-ae43-4f30-98e0-13c9a698dce2', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (2, N'Mạng Internet ra đời vào năm nào sau đây:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'4a761ff9-a00a-454a-bfe5-ba9a1fe31e9a', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (3, N'Dịch vụ nào cho phép chuyển các file từ trạm này sang trạm khác bất kể yếu tố địa lý hay hệ điều hành sử dụng:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'238e7a43-aa1a-4cfe-8405-eb3a6c46d596', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (4, N'Mục nào sau đây trong Windows XP dùng để kiểm tra các thiết bị đã được cài đặt driver hay chưa?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'89e6976d-a6f6-4fb6-807f-bfb38c57ce7f', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (5, N'Lệnh nào sau đây trong MS-DOS dùng để khôi phục bản ghi khởi động chính (Master Boot Record)?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'f967730c-6868-453e-88b3-0db60dfb7eec', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (6, N'Tốc độ truyền dữ liệu tối đa của chuẩn USB 2.0 là?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'e7b1a939-bd17-4a02-9004-8e4fd1b7c6a0', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (7, N'Đâu là thành phần quan trọng nhất trong các thành phần dưới đây của máy tính?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'e9ea93c0-8e9e-4311-97a7-9d8d7e4a39a9', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (8, N'Thực thi đoạn chương trình Pascal sau:
Var S, i, j : Integer; 
Begin 
S := 0; 
for i:= 1 to 3 do 
for j:= 1 to 4 do S := S + 1 ; 
End/ 
Giá trị sau cùng của S là :', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'76fd24aa-8d98-4b98-bfb6-d5026270306d', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (9, N'Trong Pascal, biến SS kiểu Boolean, lệnh nào sau đây làm SS có giá trị là True', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'f62f70a7-98b9-4b7e-8b7b-76b70439a6e7', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (10, N'Để có thể cuộn chữ thành nhiều dòng trong ô, ta dùng', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'f9b66f5e-de2f-41f5-92eb-82998ebb1490', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (11, N'Tốc độ 1x chuẩn của ổ đĩa CD-ROM thường có giá trị là:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'4876678b-4644-481f-b1cb-83b280bd60be', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (12, N'Trong ngôn ngữ  HTML (Hyper Text Markup Language)  thẻ  <MARQUEE></ MARQUEE >  tác động thế nào lên các đối tượng nằm trong nó?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'ddab3e83-857a-4ed5-b6ff-8d36853152ec', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (13, N'Tổ hợp phím nào sau đây giúp truy cập “Command prompt” trong quá trình cài đặt Hệ điều hành Windows XP?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'a05f35d4-e1b5-4272-b98f-d032673dd8ac', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (14, N'DVD Combo có các chức năng nào sau đây?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'171a6781-2713-4c80-865e-3f08596493dd', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (15, N'Trong Windows XP, cách nào sau đây không thể mở Task Manager?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'4f4701f5-1efb-48b0-b2d2-202fece06f94', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (16, N'Chuẩn ATAPI dùng để kết nối với thiết bị nào sau đây?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'bac133cc-3f30-4169-9086-272d08fdf4f1', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (17, N'Hệ điều hành mã nguồn mở thông dụng nhấthiện nay là?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'ff639460-06f4-46d2-8f4c-62716f8b2420', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (18, N'Chuột không dây sử dụng công nghệ nào để kết nối tín hiệu với máy tính?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'65c6d52f-64df-4d76-9a9f-013eac54074c', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (19, N'/ Muốn cài đặt Hệ điều hành Windows Vista
thì phân vùng cài đặt phải được định dạng theo hệ thống tập tin?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'e98da61c-6a82-4dd7-b186-689e73fc9fbe', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (20, N'Modem gắn ngoài được kết nối với máy tính thông qua cổng nào sau đây?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'df38fc4b-d588-4068-a362-3b90f8c91e30', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (21, N'Card âm thanh rời không gắn được trên khe cắm mở rộng nào sau đây?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'8bfec943-ae30-420f-a9bb-9f525955181d', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (22, N'Windows Explorer có các thành phần: Explorer bar, Explorer view, Tool bar, menu bar. Còn lại là gì?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'9bbdeff0-51d5-4cef-8e88-d0da485d54af', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (23, N'Các loại hệ điều hà nh Windows đều có khả năng tự động nhận biết các thiết bị phần cứng và tự động cà i đặt cấu hình của các thiết bị dây là chức năng:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'2f3c5352-0145-483b-a4c8-067125042f6c', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (24, N'Danh sách các mục chọn trong thực đơn gọi là :', 1, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 1, 0, 0, N'8c6fd2c3-f77a-4826-83ea-0d221f3f2c0c', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (25, N'Hộp điều khiển việc phóng to, thu nhỏ, đóng cửa sổ gọi là :', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'961a018e-ded3-4f2c-adb6-ee657e189e9d', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (26, N'Shortcut là biểu tượng đại diện cho một chương trình hay một tập tin để khởi động một chương trình hay một tập tin. Vậy có mấy loại shortcut', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'97d70818-e9f9-4124-a562-ae411d5daebf', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (27, N'Để chạy một ứng dụng trong Windows, bạn là m thế nà o?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'f78d6f5d-ce37-4a37-b104-4bfe0fbd0ad2', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (28, N'Chương trình cho phép định lại cấu hình hệ thống thay đổi môi trườ ng làm việc cho phù hợp', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'a5dc2776-a633-412a-895e-1645c4333c28', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (29, N'Có mấy cách tạo mới một văn bản trong Word:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'fcb04423-2343-475d-95e7-7baeee6749e4', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (30, N'Sử dụng Office Clipboard, bạn có thể lưu trữ tối đa bao nhiêu clipboard trong đấy:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'b70688d0-d17c-429b-8aba-cf5bf13bbad4', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (31, N'Thao tác Shift + Enter có chức năng gì?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'edb2e535-f611-44d0-b30d-3d8b1e552edf', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (32, N'Phím nóng Ctrl + Shift + =, có chức năng gì?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'24fd75f2-f78e-4edd-8548-b01cb2273d6d', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (33, N'Để gạch dưới mỗi từ một nét đơn, ngoà i việc vào Format/Font, ta có thể dùng tổ hợp phím nà o:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'378f4ef0-f74f-4433-a0e3-2b591a565b48', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (34, N'trong hộp thoại Format/Paragraph ngoài việc có thể hiệu chỉnh lề cho đoạn, khoảng cách các đoạn, các dòng, còn dùng làm chức năng nào sau đây:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'e2b0d960-f264-4170-bef8-7eb3795dac6c', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (35, N'Trong phần File/ Page Setup mục Gutter có chức năng gì?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'8dc91131-e088-42d6-933c-50aa796042dd', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (36, N'Để thay đổi đơn vị đo của thức, ta chọn:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'e2fe2656-d67a-44b4-a126-36832704b411', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (37, N'Ký hiệu này trên thanh thước có nghĩa là gì?', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'7565ebd8-46a3-45e4-b10c-653c905fbf9f', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (38, N'Trong trang Format/Bullets and Numbering, nếu muốn chọn thông số khác ta vào mục Customize. Trong nà y, phần Number Format dù ng để:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'38db7eb6-ab5c-44a9-8f3d-000924cd1298', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (39, N'Trong mục Format/Drop Cap, phần Distance form text dù ng để xác định khoảng cách:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'2340de2c-5b19-4fca-b858-01d80c67e5bb', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (40, N'Trong hộp thoại File/Page Setup khung Margins, mục Mirror Margins dù ng để', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'58bd2232-3cb5-424d-bca1-83696a1afb67', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (41, N'Bạn có thể chú thích các thuật ngữ cho 1 từ , 1 câu, bằng Footnote. Như vậy Footnote có nghĩa là :', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'1c4d4359-f30d-4191-afb4-d9629a48c4f4', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (42, N'Để di chuyển con trỏ trong bảng Table, ta dùng phím nóng. Vậy phím nóng Shift + Tab dù ng để:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'b12c45c1-6a5c-4e09-8837-6ba96ccd09e5', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (43, N'Chọn cả bảng Table ta nhấn hợp phím', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'e6cd3d9c-6638-4c6b-a8ba-782cc5e0b807', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (44, N'Ví dụ ta gõ chữ n và nhấn phím spacebar, máy sẽ hiện ra cụm từ thông tin. Đây là chức năng:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'61e29706-17c4-422f-8e08-a015eefa1d3f', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (45, N'Trong Format/ Tabs, mục Tab Stop position dù ng để xác định khoảng cách:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'7c8a4844-0b19-4849-ad88-d4f8d08acd73', 0)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (46, N'Khi in phong bì, ta chọn Tools/Envelopes and Label, mục Clockwise rotation trong đây có chức năng:', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'8c89a837-173c-48e3-941c-71d0e6ba84b9', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (47, N'Một bảng tính worksheet bao gồm', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'a7dbd123-a980-4ac4-bfd9-e4369aa11aa9', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (48, N'Các địa chỉ sau đây là địa chỉ gì: $A1, B$5, C6, $L9, $DS7', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'91b8a434-43ce-44b8-b03d-17d075610535', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (49, N'Phép toán : ngày Số sẽ cho kết quả là :', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'c1164ab9-6376-4694-8011-b57928ad9c3b', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (50, N'Khi gõ công thức xong, rồi Enter, máy hiện ra #N/A có nghĩa là :', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'6aab170f-f91e-4fc1-8bb7-6a44f317d515', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (51, N'Khi gõ công thức xong, rồi Enter, máy hiện ra #REF! có nghĩa là', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'f35ccc44-77ba-4996-8bbf-5e14763d4596', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (52, N'Để có thể cuộn chữ thà nh nhiều dò ng trong ô, ta dù ng', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'f1c93ba4-bf2e-4cf7-80a7-c623d5cf0bf5', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (53, N'Công thức sau : = ROUND(136485.22m-3) sẽ cho kết quả là :', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0.5, 0, 0, N'6b87a41c-5d1f-4940-8edb-fba2b39c46ae', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (54, N'Khi ta nhập công thức sau: = SUMF(D31:D35, > = 50000, C31:C35), kết quả là :', 0, 1, 1, N'abc', N'abc', CAST(0x0000A242003D4F59 AS DateTime), CAST(0x0000A242003D4F59 AS DateTime), 0, 0, 0, N'b430f81c-39c3-43da-93e0-37d84d15e6e6', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (55, N'Lập trình hướng đối tượng là gì?', 0, 1, 0, N'admin', N'admin', CAST(0x0000A24D006B38A1 AS DateTime), CAST(0x0000A24D006B38A1 AS DateTime), 0.5, 0, 0, N'00000000-0000-0000-0000-000000000000', NULL)
INSERT [dbo].[Questions] ([QuestionId], [Content], [Level], [FK_SubjectId], [Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate], [Time], [Purpose], [IsDelete], [QuestionGuid], [IsAnswerRandom]) VALUES (56, N'Nêu các hệ số có trong máy tính.', 1, 1, 0, N'admin', N'admin', CAST(0x0000A24D006B5BE2 AS DateTime), CAST(0x0000A24D006B5BE2 AS DateTime), 1, 0, 0, N'00000000-0000-0000-0000-000000000000', NULL)
SET IDENTITY_INSERT [dbo].[Questions] OFF
/****** Object:  Table [dbo].[MultiTestCopies]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiTestCopies](
	[MultiTestCopyId] [int] IDENTITY(1,1) NOT NULL,
	[FK_MultiTestId] [bigint] NOT NULL,
	[MultiTestCopyStructure] [xml] NOT NULL,
 CONSTRAINT [PK_MultiTestCopies] PRIMARY KEY CLUSTERED 
(
	[MultiTestCopyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MultiTestCopies] ON
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (7, 5, N'<MultiTestCopy><Q qOrder="1" qId="34"><A aOrder="1" aId="133" /><A aOrder="2" aId="134" /><A aOrder="3" aId="135" /><A aOrder="4" aId="136" /></Q><Q qOrder="2" qId="37"><A aOrder="1" aId="146" /><A aOrder="2" aId="145" /><A aOrder="3" aId="148" /><A aOrder="4" aId="147" /></Q><Q qOrder="3" qId="36"><A aOrder="1" aId="143" /><A aOrder="2" aId="142" /><A aOrder="3" aId="141" /><A aOrder="4" aId="144" /></Q><Q qOrder="4" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="182" /><A aOrder="3" aId="183" /><A aOrder="4" aId="184" /></Q><Q qOrder="5" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="122" /><A aOrder="3" aId="123" /><A aOrder="4" aId="124" /></Q><Q qOrder="6" qId="27"><A aOrder="1" aId="106" /><A aOrder="2" aId="105" /><A aOrder="3" aId="107" /><A aOrder="4" aId="108" /></Q><Q qOrder="7" qId="30"><A aOrder="1" aId="120" /><A aOrder="2" aId="117" /><A aOrder="3" aId="119" /><A aOrder="4" aId="118" /></Q><Q qOrder="8" qId="8"><A aOrder="1" aId="29" /><A aOrder="2" aId="30" /><A aOrder="3" aId="32" /><A aOrder="4" aId="31" /></Q><Q qOrder="9" qId="49"><A aOrder="1" aId="193" /><A aOrder="2" aId="195" /><A aOrder="3" aId="194" /><A aOrder="4" aId="196" /></Q><Q qOrder="10" qId="32"><A aOrder="1" aId="126" /><A aOrder="2" aId="127" /><A aOrder="3" aId="125" /><A aOrder="4" aId="128" /></Q><Q qOrder="11" qId="2"><A aOrder="1" aId="8" /><A aOrder="2" aId="5" /><A aOrder="3" aId="6" /><A aOrder="4" aId="7" /></Q><Q qOrder="12" qId="33"><A aOrder="1" aId="130" /><A aOrder="2" aId="132" /><A aOrder="3" aId="131" /><A aOrder="4" aId="129" /></Q><Q qOrder="13" qId="16"><A aOrder="1" aId="63" /><A aOrder="2" aId="64" /><A aOrder="3" aId="62" /><A aOrder="4" aId="61" /></Q><Q qOrder="14" qId="10"><A aOrder="1" aId="38" /><A aOrder="2" aId="37" /><A aOrder="3" aId="39" /><A aOrder="4" aId="40" /></Q><Q qOrder="15" qId="29"><A aOrder="1" aId="114" /><A aOrder="2" aId="113" /><A aOrder="3" aId="115" /><A aOrder="4" aId="116" /></Q><Q qOrder="16" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="60" /><A aOrder="3" aId="59" /><A aOrder="4" aId="57" /></Q><Q qOrder="17" qId="39"><A aOrder="1" aId="155" /><A aOrder="2" aId="156" /><A aOrder="3" aId="154" /><A aOrder="4" aId="153" /></Q><Q qOrder="18" qId="26"><A aOrder="1" aId="104" /><A aOrder="2" aId="101" /><A aOrder="3" aId="102" /><A aOrder="4" aId="103" /></Q><Q qOrder="19" qId="41"><A aOrder="1" aId="164" /><A aOrder="2" aId="162" /><A aOrder="3" aId="161" /><A aOrder="4" aId="163" /></Q><Q qOrder="20" qId="7"><A aOrder="1" aId="27" /><A aOrder="2" aId="28" /><A aOrder="3" aId="25" /><A aOrder="4" aId="26" /></Q><Q qOrder="21" qId="28"><A aOrder="1" aId="110" /><A aOrder="2" aId="111" /><A aOrder="3" aId="112" /><A aOrder="4" aId="109" /></Q><Q qOrder="22" qId="21"><A aOrder="1" aId="82" /><A aOrder="2" aId="83" /><A aOrder="3" aId="81" /><A aOrder="4" aId="84" /></Q><Q qOrder="23" qId="23"><A aOrder="1" aId="92" /><A aOrder="2" aId="91" /><A aOrder="3" aId="90" /><A aOrder="4" aId="89" /></Q><Q qOrder="24" qId="53"><A aOrder="1" aId="211" /><A aOrder="2" aId="210" /><A aOrder="3" aId="212" /><A aOrder="4" aId="209" /></Q><Q qOrder="25" qId="52"><A aOrder="1" aId="205" /><A aOrder="2" aId="208" /><A aOrder="3" aId="207" /><A aOrder="4" aId="206" /></Q><Q qOrder="26" qId="51"><A aOrder="1" aId="204" /><A aOrder="2" aId="202" /><A aOrder="3" aId="201" /><A aOrder="4" aId="203" /></Q><Q qOrder="27" qId="12"><A aOrder="1" aId="46" /><A aOrder="2" aId="45" /><A aOrder="3" aId="47" /><A aOrder="4" aId="48" /></Q><Q qOrder="28" qId="17"><A aOrder="1" aId="68" /><A aOrder="2" aId="66" /><A aOrder="3" aId="65" /><A aOrder="4" aId="67" /></Q><Q qOrder="29" qId="14"><A aOrder="1" aId="53" /><A aOrder="2" aId="54" /><A aOrder="3" aId="55" /><A aOrder="4" aId="56" /></Q><Q qOrder="30" qId="13"><A aOrder="1" aId="51" /><A aOrder="2" aId="50" /><A aOrder="3" aId="49" /><A aOrder="4" aId="52" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (8, 5, N'<MultiTestCopy><Q qOrder="1" qId="39"><A aOrder="1" aId="155" /><A aOrder="2" aId="156" /><A aOrder="3" aId="153" /><A aOrder="4" aId="154" /></Q><Q qOrder="2" qId="51"><A aOrder="1" aId="201" /><A aOrder="2" aId="202" /><A aOrder="3" aId="204" /><A aOrder="4" aId="203" /></Q><Q qOrder="3" qId="30"><A aOrder="1" aId="120" /><A aOrder="2" aId="118" /><A aOrder="3" aId="119" /><A aOrder="4" aId="117" /></Q><Q qOrder="4" qId="34"><A aOrder="1" aId="135" /><A aOrder="2" aId="133" /><A aOrder="3" aId="134" /><A aOrder="4" aId="136" /></Q><Q qOrder="5" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="82" /><A aOrder="3" aId="84" /><A aOrder="4" aId="83" /></Q><Q qOrder="6" qId="10"><A aOrder="1" aId="39" /><A aOrder="2" aId="38" /><A aOrder="3" aId="37" /><A aOrder="4" aId="40" /></Q><Q qOrder="7" qId="14"><A aOrder="1" aId="56" /><A aOrder="2" aId="53" /><A aOrder="3" aId="55" /><A aOrder="4" aId="54" /></Q><Q qOrder="8" qId="8"><A aOrder="1" aId="29" /><A aOrder="2" aId="30" /><A aOrder="3" aId="32" /><A aOrder="4" aId="31" /></Q><Q qOrder="9" qId="49"><A aOrder="1" aId="194" /><A aOrder="2" aId="193" /><A aOrder="3" aId="195" /><A aOrder="4" aId="196" /></Q><Q qOrder="10" qId="36"><A aOrder="1" aId="141" /><A aOrder="2" aId="142" /><A aOrder="3" aId="144" /><A aOrder="4" aId="143" /></Q><Q qOrder="11" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="108" /><A aOrder="4" aId="107" /></Q><Q qOrder="12" qId="16"><A aOrder="1" aId="63" /><A aOrder="2" aId="64" /><A aOrder="3" aId="62" /><A aOrder="4" aId="61" /></Q><Q qOrder="13" qId="41"><A aOrder="1" aId="164" /><A aOrder="2" aId="162" /><A aOrder="3" aId="161" /><A aOrder="4" aId="163" /></Q><Q qOrder="14" qId="28"><A aOrder="1" aId="111" /><A aOrder="2" aId="110" /><A aOrder="3" aId="109" /><A aOrder="4" aId="112" /></Q><Q qOrder="15" qId="2"><A aOrder="1" aId="5" /><A aOrder="2" aId="6" /><A aOrder="3" aId="7" /><A aOrder="4" aId="8" /></Q><Q qOrder="16" qId="15"><A aOrder="1" aId="60" /><A aOrder="2" aId="58" /><A aOrder="3" aId="59" /><A aOrder="4" aId="57" /></Q><Q qOrder="17" qId="12"><A aOrder="1" aId="47" /><A aOrder="2" aId="45" /><A aOrder="3" aId="48" /><A aOrder="4" aId="46" /></Q><Q qOrder="18" qId="7"><A aOrder="1" aId="25" /><A aOrder="2" aId="28" /><A aOrder="3" aId="26" /><A aOrder="4" aId="27" /></Q><Q qOrder="19" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="123" /><A aOrder="3" aId="122" /><A aOrder="4" aId="124" /></Q><Q qOrder="20" qId="23"><A aOrder="1" aId="92" /><A aOrder="2" aId="89" /><A aOrder="3" aId="91" /><A aOrder="4" aId="90" /></Q><Q qOrder="21" qId="53"><A aOrder="1" aId="210" /><A aOrder="2" aId="212" /><A aOrder="3" aId="209" /><A aOrder="4" aId="211" /></Q><Q qOrder="22" qId="13"><A aOrder="1" aId="52" /><A aOrder="2" aId="51" /><A aOrder="3" aId="49" /><A aOrder="4" aId="50" /></Q><Q qOrder="23" qId="17"><A aOrder="1" aId="67" /><A aOrder="2" aId="65" /><A aOrder="3" aId="66" /><A aOrder="4" aId="68" /></Q><Q qOrder="24" qId="46"><A aOrder="1" aId="182" /><A aOrder="2" aId="183" /><A aOrder="3" aId="181" /><A aOrder="4" aId="184" /></Q><Q qOrder="25" qId="52"><A aOrder="1" aId="206" /><A aOrder="2" aId="208" /><A aOrder="3" aId="205" /><A aOrder="4" aId="207" /></Q><Q qOrder="26" qId="32"><A aOrder="1" aId="127" /><A aOrder="2" aId="125" /><A aOrder="3" aId="126" /><A aOrder="4" aId="128" /></Q><Q qOrder="27" qId="37"><A aOrder="1" aId="148" /><A aOrder="2" aId="147" /><A aOrder="3" aId="145" /><A aOrder="4" aId="146" /></Q><Q qOrder="28" qId="33"><A aOrder="1" aId="131" /><A aOrder="2" aId="130" /><A aOrder="3" aId="132" /><A aOrder="4" aId="129" /></Q><Q qOrder="29" qId="29"><A aOrder="1" aId="115" /><A aOrder="2" aId="113" /><A aOrder="3" aId="114" /><A aOrder="4" aId="116" /></Q><Q qOrder="30" qId="26"><A aOrder="1" aId="104" /><A aOrder="2" aId="101" /><A aOrder="3" aId="102" /><A aOrder="4" aId="103" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (9, 6, N'<MultiTestCopy><Q qOrder="1" qId="2"><A aOrder="1" aId="8" /><A aOrder="2" aId="6" /><A aOrder="3" aId="7" /><A aOrder="4" aId="5" /></Q><Q qOrder="2" qId="45"><A aOrder="1" aId="177" /><A aOrder="2" aId="178" /><A aOrder="3" aId="180" /><A aOrder="4" aId="179" /></Q><Q qOrder="3" qId="41"><A aOrder="1" aId="164" /><A aOrder="2" aId="163" /><A aOrder="3" aId="161" /><A aOrder="4" aId="162" /></Q><Q qOrder="4" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="182" /><A aOrder="3" aId="183" /><A aOrder="4" aId="184" /></Q><Q qOrder="5" qId="1"><A aOrder="1" aId="2" /><A aOrder="2" aId="3" /><A aOrder="3" aId="1" /><A aOrder="4" aId="4" /></Q><Q qOrder="6" qId="36"><A aOrder="1" aId="143" /><A aOrder="2" aId="144" /><A aOrder="3" aId="141" /><A aOrder="4" aId="142" /></Q><Q qOrder="7" qId="15"><A aOrder="1" aId="59" /><A aOrder="2" aId="57" /><A aOrder="3" aId="60" /><A aOrder="4" aId="58" /></Q><Q qOrder="8" qId="40"><A aOrder="1" aId="158" /><A aOrder="2" aId="157" /><A aOrder="3" aId="159" /><A aOrder="4" aId="160" /></Q><Q qOrder="9" qId="29"><A aOrder="1" aId="115" /><A aOrder="2" aId="116" /><A aOrder="3" aId="114" /><A aOrder="4" aId="113" /></Q><Q qOrder="10" qId="16"><A aOrder="1" aId="63" /><A aOrder="2" aId="64" /><A aOrder="3" aId="61" /><A aOrder="4" aId="62" /></Q><Q qOrder="11" qId="47"><A aOrder="1" aId="186" /><A aOrder="2" aId="185" /><A aOrder="3" aId="188" /><A aOrder="4" aId="187" /></Q><Q qOrder="12" qId="5"><A aOrder="1" aId="19" /><A aOrder="2" aId="18" /><A aOrder="3" aId="20" /><A aOrder="4" aId="17" /></Q><Q qOrder="13" qId="30"><A aOrder="1" aId="117" /><A aOrder="2" aId="120" /><A aOrder="3" aId="119" /><A aOrder="4" aId="118" /></Q><Q qOrder="14" qId="22"><A aOrder="1" aId="85" /><A aOrder="2" aId="86" /><A aOrder="3" aId="87" /><A aOrder="4" aId="88" /></Q><Q qOrder="15" qId="19"><A aOrder="1" aId="76" /><A aOrder="2" aId="74" /><A aOrder="3" aId="73" /><A aOrder="4" aId="75" /></Q><Q qOrder="16" qId="35"><A aOrder="1" aId="139" /><A aOrder="2" aId="140" /><A aOrder="3" aId="137" /><A aOrder="4" aId="138" /></Q><Q qOrder="17" qId="39"><A aOrder="1" aId="154" /><A aOrder="2" aId="153" /><A aOrder="3" aId="156" /><A aOrder="4" aId="155" /></Q><Q qOrder="18" qId="53"><A aOrder="1" aId="209" /><A aOrder="2" aId="210" /><A aOrder="3" aId="211" /><A aOrder="4" aId="212" /></Q><Q qOrder="19" qId="14"><A aOrder="1" aId="55" /><A aOrder="2" aId="54" /><A aOrder="3" aId="56" /><A aOrder="4" aId="53" /></Q><Q qOrder="20" qId="44"><A aOrder="1" aId="173" /><A aOrder="2" aId="174" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="21" qId="18"><A aOrder="1" aId="70" /><A aOrder="2" aId="72" /><A aOrder="3" aId="71" /><A aOrder="4" aId="69" /></Q><Q qOrder="22" qId="6"><A aOrder="1" aId="22" /><A aOrder="2" aId="21" /><A aOrder="3" aId="24" /><A aOrder="4" aId="23" /></Q><Q qOrder="23" qId="3"><A aOrder="1" aId="10" /><A aOrder="2" aId="9" /><A aOrder="3" aId="12" /><A aOrder="4" aId="11" /></Q><Q qOrder="24" qId="10"><A aOrder="1" aId="40" /><A aOrder="2" aId="38" /><A aOrder="3" aId="37" /><A aOrder="4" aId="39" /></Q><Q qOrder="25" qId="7"><A aOrder="1" aId="25" /><A aOrder="2" aId="27" /><A aOrder="3" aId="26" /><A aOrder="4" aId="28" /></Q><Q qOrder="26" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="82" /><A aOrder="3" aId="84" /><A aOrder="4" aId="83" /></Q><Q qOrder="27" qId="12"><A aOrder="1" aId="45" /><A aOrder="2" aId="46" /><A aOrder="3" aId="48" /><A aOrder="4" aId="47" /></Q><Q qOrder="28" qId="48"><A aOrder="1" aId="191" /><A aOrder="2" aId="189" /><A aOrder="3" aId="190" /><A aOrder="4" aId="192" /></Q><Q qOrder="29" qId="31"><A aOrder="1" aId="123" /><A aOrder="2" aId="122" /><A aOrder="3" aId="121" /><A aOrder="4" aId="124" /></Q><Q qOrder="30" qId="38"><A aOrder="1" aId="150" /><A aOrder="2" aId="149" /><A aOrder="3" aId="152" /><A aOrder="4" aId="151" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (10, 6, N'<MultiTestCopy><Q qOrder="1" qId="2"><A aOrder="1" aId="8" /><A aOrder="2" aId="7" /><A aOrder="3" aId="6" /><A aOrder="4" aId="5" /></Q><Q qOrder="2" qId="19"><A aOrder="1" aId="73" /><A aOrder="2" aId="74" /><A aOrder="3" aId="76" /><A aOrder="4" aId="75" /></Q><Q qOrder="3" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="179" /><A aOrder="4" aId="180" /></Q><Q qOrder="4" qId="10"><A aOrder="1" aId="38" /><A aOrder="2" aId="40" /><A aOrder="3" aId="37" /><A aOrder="4" aId="39" /></Q><Q qOrder="5" qId="41"><A aOrder="1" aId="163" /><A aOrder="2" aId="162" /><A aOrder="3" aId="164" /><A aOrder="4" aId="161" /></Q><Q qOrder="6" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="60" /><A aOrder="3" aId="59" /><A aOrder="4" aId="57" /></Q><Q qOrder="7" qId="40"><A aOrder="1" aId="157" /><A aOrder="2" aId="160" /><A aOrder="3" aId="158" /><A aOrder="4" aId="159" /></Q><Q qOrder="8" qId="6"><A aOrder="1" aId="22" /><A aOrder="2" aId="21" /><A aOrder="3" aId="24" /><A aOrder="4" aId="23" /></Q><Q qOrder="9" qId="46"><A aOrder="1" aId="182" /><A aOrder="2" aId="181" /><A aOrder="3" aId="183" /><A aOrder="4" aId="184" /></Q><Q qOrder="10" qId="5"><A aOrder="1" aId="17" /><A aOrder="2" aId="20" /><A aOrder="3" aId="18" /><A aOrder="4" aId="19" /></Q><Q qOrder="11" qId="38"><A aOrder="1" aId="152" /><A aOrder="2" aId="151" /><A aOrder="3" aId="150" /><A aOrder="4" aId="149" /></Q><Q qOrder="12" qId="16"><A aOrder="1" aId="64" /><A aOrder="2" aId="62" /><A aOrder="3" aId="61" /><A aOrder="4" aId="63" /></Q><Q qOrder="13" qId="14"><A aOrder="1" aId="55" /><A aOrder="2" aId="54" /><A aOrder="3" aId="53" /><A aOrder="4" aId="56" /></Q><Q qOrder="14" qId="1"><A aOrder="1" aId="2" /><A aOrder="2" aId="3" /><A aOrder="3" aId="1" /><A aOrder="4" aId="4" /></Q><Q qOrder="15" qId="35"><A aOrder="1" aId="139" /><A aOrder="2" aId="137" /><A aOrder="3" aId="138" /><A aOrder="4" aId="140" /></Q><Q qOrder="16" qId="47"><A aOrder="1" aId="188" /><A aOrder="2" aId="186" /><A aOrder="3" aId="187" /><A aOrder="4" aId="185" /></Q><Q qOrder="17" qId="53"><A aOrder="1" aId="211" /><A aOrder="2" aId="210" /><A aOrder="3" aId="212" /><A aOrder="4" aId="209" /></Q><Q qOrder="18" qId="22"><A aOrder="1" aId="87" /><A aOrder="2" aId="86" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="19" qId="39"><A aOrder="1" aId="156" /><A aOrder="2" aId="155" /><A aOrder="3" aId="153" /><A aOrder="4" aId="154" /></Q><Q qOrder="20" qId="7"><A aOrder="1" aId="28" /><A aOrder="2" aId="26" /><A aOrder="3" aId="27" /><A aOrder="4" aId="25" /></Q><Q qOrder="21" qId="48"><A aOrder="1" aId="189" /><A aOrder="2" aId="190" /><A aOrder="3" aId="191" /><A aOrder="4" aId="192" /></Q><Q qOrder="22" qId="30"><A aOrder="1" aId="119" /><A aOrder="2" aId="120" /><A aOrder="3" aId="117" /><A aOrder="4" aId="118" /></Q><Q qOrder="23" qId="29"><A aOrder="1" aId="113" /><A aOrder="2" aId="116" /><A aOrder="3" aId="115" /><A aOrder="4" aId="114" /></Q><Q qOrder="24" qId="36"><A aOrder="1" aId="141" /><A aOrder="2" aId="144" /><A aOrder="3" aId="142" /><A aOrder="4" aId="143" /></Q><Q qOrder="25" qId="44"><A aOrder="1" aId="174" /><A aOrder="2" aId="173" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="26" qId="21"><A aOrder="1" aId="82" /><A aOrder="2" aId="81" /><A aOrder="3" aId="83" /><A aOrder="4" aId="84" /></Q><Q qOrder="27" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="123" /><A aOrder="3" aId="122" /><A aOrder="4" aId="124" /></Q><Q qOrder="28" qId="12"><A aOrder="1" aId="48" /><A aOrder="2" aId="47" /><A aOrder="3" aId="46" /><A aOrder="4" aId="45" /></Q><Q qOrder="29" qId="3"><A aOrder="1" aId="12" /><A aOrder="2" aId="10" /><A aOrder="3" aId="9" /><A aOrder="4" aId="11" /></Q><Q qOrder="30" qId="18"><A aOrder="1" aId="70" /><A aOrder="2" aId="72" /><A aOrder="3" aId="69" /><A aOrder="4" aId="71" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (11, 6, N'<MultiTestCopy><Q qOrder="1" qId="1"><A aOrder="1" aId="4" /><A aOrder="2" aId="3" /><A aOrder="3" aId="2" /><A aOrder="4" aId="1" /></Q><Q qOrder="2" qId="31"><A aOrder="1" aId="123" /><A aOrder="2" aId="122" /><A aOrder="3" aId="121" /><A aOrder="4" aId="124" /></Q><Q qOrder="3" qId="41"><A aOrder="1" aId="161" /><A aOrder="2" aId="164" /><A aOrder="3" aId="163" /><A aOrder="4" aId="162" /></Q><Q qOrder="4" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="59" /><A aOrder="3" aId="60" /><A aOrder="4" aId="57" /></Q><Q qOrder="5" qId="19"><A aOrder="1" aId="73" /><A aOrder="2" aId="74" /><A aOrder="3" aId="76" /><A aOrder="4" aId="75" /></Q><Q qOrder="6" qId="6"><A aOrder="1" aId="22" /><A aOrder="2" aId="23" /><A aOrder="3" aId="21" /><A aOrder="4" aId="24" /></Q><Q qOrder="7" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="183" /><A aOrder="3" aId="182" /><A aOrder="4" aId="184" /></Q><Q qOrder="8" qId="18"><A aOrder="1" aId="70" /><A aOrder="2" aId="71" /><A aOrder="3" aId="69" /><A aOrder="4" aId="72" /></Q><Q qOrder="9" qId="38"><A aOrder="1" aId="149" /><A aOrder="2" aId="151" /><A aOrder="3" aId="150" /><A aOrder="4" aId="152" /></Q><Q qOrder="10" qId="5"><A aOrder="1" aId="20" /><A aOrder="2" aId="18" /><A aOrder="3" aId="17" /><A aOrder="4" aId="19" /></Q><Q qOrder="11" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="64" /><A aOrder="3" aId="63" /><A aOrder="4" aId="62" /></Q><Q qOrder="12" qId="12"><A aOrder="1" aId="48" /><A aOrder="2" aId="47" /><A aOrder="3" aId="45" /><A aOrder="4" aId="46" /></Q><Q qOrder="13" qId="30"><A aOrder="1" aId="118" /><A aOrder="2" aId="117" /><A aOrder="3" aId="120" /><A aOrder="4" aId="119" /></Q><Q qOrder="14" qId="36"><A aOrder="1" aId="143" /><A aOrder="2" aId="142" /><A aOrder="3" aId="144" /><A aOrder="4" aId="141" /></Q><Q qOrder="15" qId="47"><A aOrder="1" aId="188" /><A aOrder="2" aId="185" /><A aOrder="3" aId="187" /><A aOrder="4" aId="186" /></Q><Q qOrder="16" qId="7"><A aOrder="1" aId="28" /><A aOrder="2" aId="27" /><A aOrder="3" aId="25" /><A aOrder="4" aId="26" /></Q><Q qOrder="17" qId="48"><A aOrder="1" aId="191" /><A aOrder="2" aId="189" /><A aOrder="3" aId="190" /><A aOrder="4" aId="192" /></Q><Q qOrder="18" qId="53"><A aOrder="1" aId="211" /><A aOrder="2" aId="210" /><A aOrder="3" aId="212" /><A aOrder="4" aId="209" /></Q><Q qOrder="19" qId="40"><A aOrder="1" aId="160" /><A aOrder="2" aId="158" /><A aOrder="3" aId="157" /><A aOrder="4" aId="159" /></Q><Q qOrder="20" qId="22"><A aOrder="1" aId="86" /><A aOrder="2" aId="87" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="21" qId="39"><A aOrder="1" aId="153" /><A aOrder="2" aId="156" /><A aOrder="3" aId="154" /><A aOrder="4" aId="155" /></Q><Q qOrder="22" qId="29"><A aOrder="1" aId="116" /><A aOrder="2" aId="114" /><A aOrder="3" aId="113" /><A aOrder="4" aId="115" /></Q><Q qOrder="23" qId="35"><A aOrder="1" aId="139" /><A aOrder="2" aId="138" /><A aOrder="3" aId="137" /><A aOrder="4" aId="140" /></Q><Q qOrder="24" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="84" /><A aOrder="3" aId="82" /><A aOrder="4" aId="83" /></Q><Q qOrder="25" qId="3"><A aOrder="1" aId="11" /><A aOrder="2" aId="9" /><A aOrder="3" aId="12" /><A aOrder="4" aId="10" /></Q><Q qOrder="26" qId="44"><A aOrder="1" aId="175" /><A aOrder="2" aId="174" /><A aOrder="3" aId="173" /><A aOrder="4" aId="176" /></Q><Q qOrder="27" qId="14"><A aOrder="1" aId="55" /><A aOrder="2" aId="56" /><A aOrder="3" aId="53" /><A aOrder="4" aId="54" /></Q><Q qOrder="28" qId="45"><A aOrder="1" aId="177" /><A aOrder="2" aId="178" /><A aOrder="3" aId="179" /><A aOrder="4" aId="180" /></Q><Q qOrder="29" qId="2"><A aOrder="1" aId="7" /><A aOrder="2" aId="8" /><A aOrder="3" aId="5" /><A aOrder="4" aId="6" /></Q><Q qOrder="30" qId="10"><A aOrder="1" aId="38" /><A aOrder="2" aId="40" /><A aOrder="3" aId="39" /><A aOrder="4" aId="37" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (12, 6, N'<MultiTestCopy><Q qOrder="1" qId="48"><A aOrder="1" aId="190" /><A aOrder="2" aId="191" /><A aOrder="3" aId="189" /><A aOrder="4" aId="192" /></Q><Q qOrder="2" qId="47"><A aOrder="1" aId="186" /><A aOrder="2" aId="188" /><A aOrder="3" aId="187" /><A aOrder="4" aId="185" /></Q><Q qOrder="3" qId="12"><A aOrder="1" aId="45" /><A aOrder="2" aId="48" /><A aOrder="3" aId="47" /><A aOrder="4" aId="46" /></Q><Q qOrder="4" qId="53"><A aOrder="1" aId="209" /><A aOrder="2" aId="212" /><A aOrder="3" aId="210" /><A aOrder="4" aId="211" /></Q><Q qOrder="5" qId="46"><A aOrder="1" aId="183" /><A aOrder="2" aId="181" /><A aOrder="3" aId="182" /><A aOrder="4" aId="184" /></Q><Q qOrder="6" qId="36"><A aOrder="1" aId="144" /><A aOrder="2" aId="143" /><A aOrder="3" aId="142" /><A aOrder="4" aId="141" /></Q><Q qOrder="7" qId="1"><A aOrder="1" aId="1" /><A aOrder="2" aId="4" /><A aOrder="3" aId="3" /><A aOrder="4" aId="2" /></Q><Q qOrder="8" qId="22"><A aOrder="1" aId="87" /><A aOrder="2" aId="86" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="9" qId="35"><A aOrder="1" aId="139" /><A aOrder="2" aId="140" /><A aOrder="3" aId="137" /><A aOrder="4" aId="138" /></Q><Q qOrder="10" qId="40"><A aOrder="1" aId="158" /><A aOrder="2" aId="157" /><A aOrder="3" aId="160" /><A aOrder="4" aId="159" /></Q><Q qOrder="11" qId="41"><A aOrder="1" aId="163" /><A aOrder="2" aId="164" /><A aOrder="3" aId="162" /><A aOrder="4" aId="161" /></Q><Q qOrder="12" qId="10"><A aOrder="1" aId="39" /><A aOrder="2" aId="37" /><A aOrder="3" aId="40" /><A aOrder="4" aId="38" /></Q><Q qOrder="13" qId="29"><A aOrder="1" aId="116" /><A aOrder="2" aId="113" /><A aOrder="3" aId="114" /><A aOrder="4" aId="115" /></Q><Q qOrder="14" qId="38"><A aOrder="1" aId="150" /><A aOrder="2" aId="151" /><A aOrder="3" aId="149" /><A aOrder="4" aId="152" /></Q><Q qOrder="15" qId="39"><A aOrder="1" aId="153" /><A aOrder="2" aId="156" /><A aOrder="3" aId="154" /><A aOrder="4" aId="155" /></Q><Q qOrder="16" qId="15"><A aOrder="1" aId="60" /><A aOrder="2" aId="58" /><A aOrder="3" aId="57" /><A aOrder="4" aId="59" /></Q><Q qOrder="17" qId="7"><A aOrder="1" aId="28" /><A aOrder="2" aId="25" /><A aOrder="3" aId="26" /><A aOrder="4" aId="27" /></Q><Q qOrder="18" qId="45"><A aOrder="1" aId="178" /><A aOrder="2" aId="177" /><A aOrder="3" aId="179" /><A aOrder="4" aId="180" /></Q><Q qOrder="19" qId="3"><A aOrder="1" aId="12" /><A aOrder="2" aId="10" /><A aOrder="3" aId="11" /><A aOrder="4" aId="9" /></Q><Q qOrder="20" qId="21"><A aOrder="1" aId="81" /><A aOrder="2" aId="83" /><A aOrder="3" aId="82" /><A aOrder="4" aId="84" /></Q><Q qOrder="21" qId="6"><A aOrder="1" aId="23" /><A aOrder="2" aId="22" /><A aOrder="3" aId="24" /><A aOrder="4" aId="21" /></Q><Q qOrder="22" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="62" /><A aOrder="3" aId="63" /><A aOrder="4" aId="64" /></Q><Q qOrder="23" qId="44"><A aOrder="1" aId="173" /><A aOrder="2" aId="175" /><A aOrder="3" aId="174" /><A aOrder="4" aId="176" /></Q><Q qOrder="24" qId="18"><A aOrder="1" aId="71" /><A aOrder="2" aId="72" /><A aOrder="3" aId="69" /><A aOrder="4" aId="70" /></Q><Q qOrder="25" qId="19"><A aOrder="1" aId="74" /><A aOrder="2" aId="73" /><A aOrder="3" aId="76" /><A aOrder="4" aId="75" /></Q><Q qOrder="26" qId="14"><A aOrder="1" aId="53" /><A aOrder="2" aId="56" /><A aOrder="3" aId="54" /><A aOrder="4" aId="55" /></Q><Q qOrder="27" qId="2"><A aOrder="1" aId="6" /><A aOrder="2" aId="7" /><A aOrder="3" aId="8" /><A aOrder="4" aId="5" /></Q><Q qOrder="28" qId="30"><A aOrder="1" aId="120" /><A aOrder="2" aId="118" /><A aOrder="3" aId="119" /><A aOrder="4" aId="117" /></Q><Q qOrder="29" qId="5"><A aOrder="1" aId="18" /><A aOrder="2" aId="17" /><A aOrder="3" aId="20" /><A aOrder="4" aId="19" /></Q><Q qOrder="30" qId="31"><A aOrder="1" aId="123" /><A aOrder="2" aId="121" /><A aOrder="3" aId="122" /><A aOrder="4" aId="124" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (15, 8, N'<MultiTestCopy><Q qOrder="1" qId="4"><A aOrder="1" aId="15" /><A aOrder="2" aId="14" /><A aOrder="3" aId="16" /><A aOrder="4" aId="13" /></Q><Q qOrder="2" qId="14"><A aOrder="1" aId="56" /><A aOrder="2" aId="54" /><A aOrder="3" aId="55" /><A aOrder="4" aId="53" /></Q><Q qOrder="3" qId="15"><A aOrder="1" aId="58" /><A aOrder="2" aId="57" /><A aOrder="3" aId="59" /><A aOrder="4" aId="60" /></Q><Q qOrder="4" qId="13"><A aOrder="1" aId="51" /><A aOrder="2" aId="52" /><A aOrder="3" aId="49" /><A aOrder="4" aId="50" /></Q><Q qOrder="5" qId="51"><A aOrder="1" aId="203" /><A aOrder="2" aId="201" /><A aOrder="3" aId="202" /><A aOrder="4" aId="204" /></Q><Q qOrder="6" qId="24"><A aOrder="1" aId="93" /><A aOrder="2" aId="95" /><A aOrder="3" aId="94" /><A aOrder="4" aId="96" /></Q><Q qOrder="7" qId="21"><A aOrder="1" aId="83" /><A aOrder="2" aId="84" /><A aOrder="3" aId="81" /><A aOrder="4" aId="82" /></Q><Q qOrder="8" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="110" /><A aOrder="3" aId="111" /><A aOrder="4" aId="112" /></Q><Q qOrder="9" qId="2"><A aOrder="1" aId="5" /><A aOrder="2" aId="6" /><A aOrder="3" aId="8" /><A aOrder="4" aId="7" /></Q><Q qOrder="10" qId="22"><A aOrder="1" aId="86" /><A aOrder="2" aId="87" /><A aOrder="3" aId="85" /><A aOrder="4" aId="88" /></Q><Q qOrder="11" qId="18"><A aOrder="1" aId="69" /><A aOrder="2" aId="71" /><A aOrder="3" aId="70" /><A aOrder="4" aId="72" /></Q><Q qOrder="12" qId="7"><A aOrder="1" aId="26" /><A aOrder="2" aId="27" /><A aOrder="3" aId="25" /><A aOrder="4" aId="28" /></Q><Q qOrder="13" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="63" /><A aOrder="3" aId="62" /><A aOrder="4" aId="64" /></Q><Q qOrder="14" qId="17"><A aOrder="1" aId="65" /><A aOrder="2" aId="66" /><A aOrder="3" aId="67" /><A aOrder="4" aId="68" /></Q><Q qOrder="15" qId="26"><A aOrder="1" aId="103" /><A aOrder="2" aId="101" /><A aOrder="3" aId="104" /><A aOrder="4" aId="102" /></Q><Q qOrder="16" qId="29"><A aOrder="1" aId="114" /><A aOrder="2" aId="116" /><A aOrder="3" aId="113" /><A aOrder="4" aId="115" /></Q><Q qOrder="17" qId="11"><A aOrder="1" aId="44" /><A aOrder="2" aId="42" /><A aOrder="3" aId="43" /><A aOrder="4" aId="41" /></Q><Q qOrder="18" qId="39"><A aOrder="1" aId="153" /><A aOrder="2" aId="154" /><A aOrder="3" aId="156" /><A aOrder="4" aId="155" /></Q><Q qOrder="19" qId="23"><A aOrder="1" aId="91" /><A aOrder="2" aId="90" /><A aOrder="3" aId="89" /><A aOrder="4" aId="92" /></Q><Q qOrder="20" qId="45"><A aOrder="1" aId="177" /><A aOrder="2" aId="178" /><A aOrder="3" aId="179" /><A aOrder="4" aId="180" /></Q><Q qOrder="21" qId="49"><A aOrder="1" aId="194" /><A aOrder="2" aId="195" /><A aOrder="3" aId="193" /><A aOrder="4" aId="196" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (16, 8, N'<MultiTestCopy><Q qOrder="1" qId="21"><A aOrder="1" aId="83" /><A aOrder="2" aId="81" /><A aOrder="3" aId="82" /><A aOrder="4" aId="84" /></Q><Q qOrder="2" qId="51"><A aOrder="1" aId="201" /><A aOrder="2" aId="204" /><A aOrder="3" aId="202" /><A aOrder="4" aId="203" /></Q><Q qOrder="3" qId="26"><A aOrder="1" aId="104" /><A aOrder="2" aId="103" /><A aOrder="3" aId="101" /><A aOrder="4" aId="102" /></Q><Q qOrder="4" qId="14"><A aOrder="1" aId="54" /><A aOrder="2" aId="53" /><A aOrder="3" aId="55" /><A aOrder="4" aId="56" /></Q><Q qOrder="5" qId="29"><A aOrder="1" aId="115" /><A aOrder="2" aId="114" /><A aOrder="3" aId="116" /><A aOrder="4" aId="113" /></Q><Q qOrder="6" qId="45"><A aOrder="1" aId="177" /><A aOrder="2" aId="178" /><A aOrder="3" aId="179" /><A aOrder="4" aId="180" /></Q><Q qOrder="7" qId="2"><A aOrder="1" aId="7" /><A aOrder="2" aId="5" /><A aOrder="3" aId="6" /><A aOrder="4" aId="8" /></Q><Q qOrder="8" qId="16"><A aOrder="1" aId="62" /><A aOrder="2" aId="64" /><A aOrder="3" aId="61" /><A aOrder="4" aId="63" /></Q><Q qOrder="9" qId="7"><A aOrder="1" aId="26" /><A aOrder="2" aId="28" /><A aOrder="3" aId="25" /><A aOrder="4" aId="27" /></Q><Q qOrder="10" qId="24"><A aOrder="1" aId="93" /><A aOrder="2" aId="94" /><A aOrder="3" aId="95" /><A aOrder="4" aId="96" /></Q><Q qOrder="11" qId="4"><A aOrder="1" aId="14" /><A aOrder="2" aId="13" /><A aOrder="3" aId="16" /><A aOrder="4" aId="15" /></Q><Q qOrder="12" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="111" /><A aOrder="3" aId="110" /><A aOrder="4" aId="112" /></Q><Q qOrder="13" qId="17"><A aOrder="1" aId="66" /><A aOrder="2" aId="65" /><A aOrder="3" aId="67" /><A aOrder="4" aId="68" /></Q><Q qOrder="14" qId="39"><A aOrder="1" aId="153" /><A aOrder="2" aId="154" /><A aOrder="3" aId="156" /><A aOrder="4" aId="155" /></Q><Q qOrder="15" qId="15"><A aOrder="1" aId="59" /><A aOrder="2" aId="60" /><A aOrder="3" aId="57" /><A aOrder="4" aId="58" /></Q><Q qOrder="16" qId="22"><A aOrder="1" aId="86" /><A aOrder="2" aId="85" /><A aOrder="3" aId="87" /><A aOrder="4" aId="88" /></Q><Q qOrder="17" qId="13"><A aOrder="1" aId="50" /><A aOrder="2" aId="49" /><A aOrder="3" aId="51" /><A aOrder="4" aId="52" /></Q><Q qOrder="18" qId="49"><A aOrder="1" aId="194" /><A aOrder="2" aId="193" /><A aOrder="3" aId="195" /><A aOrder="4" aId="196" /></Q><Q qOrder="19" qId="23"><A aOrder="1" aId="92" /><A aOrder="2" aId="89" /><A aOrder="3" aId="91" /><A aOrder="4" aId="90" /></Q><Q qOrder="20" qId="11"><A aOrder="1" aId="41" /><A aOrder="2" aId="43" /><A aOrder="3" aId="42" /><A aOrder="4" aId="44" /></Q><Q qOrder="21" qId="18"><A aOrder="1" aId="70" /><A aOrder="2" aId="72" /><A aOrder="3" aId="69" /><A aOrder="4" aId="71" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (17, 9, N'<MultiTestCopy><Q qOrder="1" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="122" /><A aOrder="3" aId="123" /><A aOrder="4" aId="124" /></Q><Q qOrder="2" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="78" /><A aOrder="3" aId="79" /><A aOrder="4" aId="80" /></Q><Q qOrder="3" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="110" /><A aOrder="3" aId="111" /><A aOrder="4" aId="112" /></Q><Q qOrder="4" qId="25"><A aOrder="1" aId="97" /><A aOrder="2" aId="98" /><A aOrder="3" aId="99" /><A aOrder="4" aId="100" /></Q><Q qOrder="5" qId="11"><A aOrder="1" aId="41" /><A aOrder="2" aId="42" /><A aOrder="3" aId="43" /><A aOrder="4" aId="44" /></Q><Q qOrder="6" qId="2"><A aOrder="1" aId="5" /><A aOrder="2" aId="6" /><A aOrder="3" aId="7" /><A aOrder="4" aId="8" /></Q><Q qOrder="7" qId="51"><A aOrder="1" aId="201" /><A aOrder="2" aId="202" /><A aOrder="3" aId="203" /><A aOrder="4" aId="204" /></Q><Q qOrder="8" qId="40"><A aOrder="1" aId="157" /><A aOrder="2" aId="158" /><A aOrder="3" aId="159" /><A aOrder="4" aId="160" /></Q><Q qOrder="9" qId="24"><A aOrder="1" aId="93" /><A aOrder="2" aId="94" /><A aOrder="3" aId="95" /><A aOrder="4" aId="96" /></Q><Q qOrder="10" qId="5"><A aOrder="1" aId="17" /><A aOrder="2" aId="18" /><A aOrder="3" aId="19" /><A aOrder="4" aId="20" /></Q><Q qOrder="11" qId="50"><A aOrder="1" aId="197" /><A aOrder="2" aId="198" /><A aOrder="3" aId="199" /><A aOrder="4" aId="200" /></Q><Q qOrder="12" qId="39"><A aOrder="1" aId="153" /><A aOrder="2" aId="154" /><A aOrder="3" aId="155" /><A aOrder="4" aId="156" /></Q><Q qOrder="13" qId="12"><A aOrder="1" aId="45" /><A aOrder="2" aId="46" /><A aOrder="3" aId="47" /><A aOrder="4" aId="48" /></Q><Q qOrder="14" qId="23"><A aOrder="1" aId="89" /><A aOrder="2" aId="90" /><A aOrder="3" aId="91" /><A aOrder="4" aId="92" /></Q><Q qOrder="15" qId="34"><A aOrder="1" aId="133" /><A aOrder="2" aId="134" /><A aOrder="3" aId="135" /><A aOrder="4" aId="136" /></Q><Q qOrder="16" qId="43"><A aOrder="1" aId="169" /><A aOrder="2" aId="170" /><A aOrder="3" aId="171" /><A aOrder="4" aId="172" /></Q><Q qOrder="17" qId="18"><A aOrder="1" aId="69" /><A aOrder="2" aId="70" /><A aOrder="3" aId="71" /><A aOrder="4" aId="72" /></Q><Q qOrder="18" qId="47"><A aOrder="1" aId="185" /><A aOrder="2" aId="186" /><A aOrder="3" aId="187" /><A aOrder="4" aId="188" /></Q><Q qOrder="19" qId="53"><A aOrder="1" aId="209" /><A aOrder="2" aId="210" /><A aOrder="3" aId="211" /><A aOrder="4" aId="212" /></Q><Q qOrder="20" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="107" /><A aOrder="4" aId="108" /></Q><Q qOrder="21" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="62" /><A aOrder="3" aId="63" /><A aOrder="4" aId="64" /></Q><Q qOrder="22" qId="7"><A aOrder="1" aId="25" /><A aOrder="2" aId="26" /><A aOrder="3" aId="27" /><A aOrder="4" aId="28" /></Q><Q qOrder="23" qId="44"><A aOrder="1" aId="173" /><A aOrder="2" aId="174" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="24" qId="38"><A aOrder="1" aId="149" /><A aOrder="2" aId="150" /><A aOrder="3" aId="151" /><A aOrder="4" aId="152" /></Q><Q qOrder="25" qId="32"><A aOrder="1" aId="125" /><A aOrder="2" aId="126" /><A aOrder="3" aId="127" /><A aOrder="4" aId="128" /></Q><Q qOrder="26" qId="3"><A aOrder="1" aId="9" /><A aOrder="2" aId="10" /><A aOrder="3" aId="11" /><A aOrder="4" aId="12" /></Q><Q qOrder="27" qId="26"><A aOrder="1" aId="101" /><A aOrder="2" aId="102" /><A aOrder="3" aId="103" /><A aOrder="4" aId="104" /></Q><Q qOrder="28" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="182" /><A aOrder="3" aId="183" /><A aOrder="4" aId="184" /></Q><Q qOrder="29" qId="4"><A aOrder="1" aId="13" /><A aOrder="2" aId="14" /><A aOrder="3" aId="15" /><A aOrder="4" aId="16" /></Q><Q qOrder="30" qId="35"><A aOrder="1" aId="137" /><A aOrder="2" aId="138" /><A aOrder="3" aId="139" /><A aOrder="4" aId="140" /></Q></MultiTestCopy>')
INSERT [dbo].[MultiTestCopies] ([MultiTestCopyId], [FK_MultiTestId], [MultiTestCopyStructure]) VALUES (18, 9, N'<MultiTestCopy><Q qOrder="1" qId="39"><A aOrder="1" aId="153" /><A aOrder="2" aId="154" /><A aOrder="3" aId="155" /><A aOrder="4" aId="156" /></Q><Q qOrder="2" qId="20"><A aOrder="1" aId="77" /><A aOrder="2" aId="78" /><A aOrder="3" aId="79" /><A aOrder="4" aId="80" /></Q><Q qOrder="3" qId="7"><A aOrder="1" aId="25" /><A aOrder="2" aId="26" /><A aOrder="3" aId="27" /><A aOrder="4" aId="28" /></Q><Q qOrder="4" qId="5"><A aOrder="1" aId="17" /><A aOrder="2" aId="18" /><A aOrder="3" aId="19" /><A aOrder="4" aId="20" /></Q><Q qOrder="5" qId="32"><A aOrder="1" aId="125" /><A aOrder="2" aId="126" /><A aOrder="3" aId="127" /><A aOrder="4" aId="128" /></Q><Q qOrder="6" qId="3"><A aOrder="1" aId="9" /><A aOrder="2" aId="10" /><A aOrder="3" aId="11" /><A aOrder="4" aId="12" /></Q><Q qOrder="7" qId="35"><A aOrder="1" aId="137" /><A aOrder="2" aId="138" /><A aOrder="3" aId="139" /><A aOrder="4" aId="140" /></Q><Q qOrder="8" qId="2"><A aOrder="1" aId="5" /><A aOrder="2" aId="6" /><A aOrder="3" aId="7" /><A aOrder="4" aId="8" /></Q><Q qOrder="9" qId="34"><A aOrder="1" aId="133" /><A aOrder="2" aId="134" /><A aOrder="3" aId="135" /><A aOrder="4" aId="136" /></Q><Q qOrder="10" qId="4"><A aOrder="1" aId="13" /><A aOrder="2" aId="14" /><A aOrder="3" aId="15" /><A aOrder="4" aId="16" /></Q><Q qOrder="11" qId="25"><A aOrder="1" aId="97" /><A aOrder="2" aId="98" /><A aOrder="3" aId="99" /><A aOrder="4" aId="100" /></Q><Q qOrder="12" qId="50"><A aOrder="1" aId="197" /><A aOrder="2" aId="198" /><A aOrder="3" aId="199" /><A aOrder="4" aId="200" /></Q><Q qOrder="13" qId="24"><A aOrder="1" aId="93" /><A aOrder="2" aId="94" /><A aOrder="3" aId="95" /><A aOrder="4" aId="96" /></Q><Q qOrder="14" qId="16"><A aOrder="1" aId="61" /><A aOrder="2" aId="62" /><A aOrder="3" aId="63" /><A aOrder="4" aId="64" /></Q><Q qOrder="15" qId="43"><A aOrder="1" aId="169" /><A aOrder="2" aId="170" /><A aOrder="3" aId="171" /><A aOrder="4" aId="172" /></Q><Q qOrder="16" qId="38"><A aOrder="1" aId="149" /><A aOrder="2" aId="150" /><A aOrder="3" aId="151" /><A aOrder="4" aId="152" /></Q><Q qOrder="17" qId="11"><A aOrder="1" aId="41" /><A aOrder="2" aId="42" /><A aOrder="3" aId="43" /><A aOrder="4" aId="44" /></Q><Q qOrder="18" qId="12"><A aOrder="1" aId="45" /><A aOrder="2" aId="46" /><A aOrder="3" aId="47" /><A aOrder="4" aId="48" /></Q><Q qOrder="19" qId="23"><A aOrder="1" aId="89" /><A aOrder="2" aId="90" /><A aOrder="3" aId="91" /><A aOrder="4" aId="92" /></Q><Q qOrder="20" qId="27"><A aOrder="1" aId="105" /><A aOrder="2" aId="106" /><A aOrder="3" aId="107" /><A aOrder="4" aId="108" /></Q><Q qOrder="21" qId="18"><A aOrder="1" aId="69" /><A aOrder="2" aId="70" /><A aOrder="3" aId="71" /><A aOrder="4" aId="72" /></Q><Q qOrder="22" qId="31"><A aOrder="1" aId="121" /><A aOrder="2" aId="122" /><A aOrder="3" aId="123" /><A aOrder="4" aId="124" /></Q><Q qOrder="23" qId="53"><A aOrder="1" aId="209" /><A aOrder="2" aId="210" /><A aOrder="3" aId="211" /><A aOrder="4" aId="212" /></Q><Q qOrder="24" qId="46"><A aOrder="1" aId="181" /><A aOrder="2" aId="182" /><A aOrder="3" aId="183" /><A aOrder="4" aId="184" /></Q><Q qOrder="25" qId="51"><A aOrder="1" aId="201" /><A aOrder="2" aId="202" /><A aOrder="3" aId="203" /><A aOrder="4" aId="204" /></Q><Q qOrder="26" qId="44"><A aOrder="1" aId="173" /><A aOrder="2" aId="174" /><A aOrder="3" aId="175" /><A aOrder="4" aId="176" /></Q><Q qOrder="27" qId="26"><A aOrder="1" aId="101" /><A aOrder="2" aId="102" /><A aOrder="3" aId="103" /><A aOrder="4" aId="104" /></Q><Q qOrder="28" qId="28"><A aOrder="1" aId="109" /><A aOrder="2" aId="110" /><A aOrder="3" aId="111" /><A aOrder="4" aId="112" /></Q><Q qOrder="29" qId="40"><A aOrder="1" aId="157" /><A aOrder="2" aId="158" /><A aOrder="3" aId="159" /><A aOrder="4" aId="160" /></Q><Q qOrder="30" qId="47"><A aOrder="1" aId="185" /><A aOrder="2" aId="186" /><A aOrder="3" aId="187" /><A aOrder="4" aId="188" /></Q></MultiTestCopy>')
SET IDENTITY_INSERT [dbo].[MultiTestCopies] OFF
/****** Object:  Table [dbo].[UserSubjectRights]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSubjectRights](
	[FK_TeacherId] [int] NOT NULL,
	[FK_SubjectId] [int] NOT NULL,
	[Right] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationRights] PRIMARY KEY CLUSTERED 
(
	[FK_TeacherId] ASC,
	[FK_SubjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UserSubjectRights] ([FK_TeacherId], [FK_SubjectId], [Right]) VALUES (1, 1, 255)
/****** Object:  Table [dbo].[MultiTestQuestions]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiTestQuestions](
	[FK_MultiTestId] [bigint] NOT NULL,
	[FK_QuestionId] [bigint] NOT NULL,
	[Mark] [float] NULL,
 CONSTRAINT [PK_MultiTestQuestions] PRIMARY KEY CLUSTERED 
(
	[FK_MultiTestId] ASC,
	[FK_QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 2, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 7, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 8, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 10, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 12, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 13, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 14, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 15, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 16, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 17, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 21, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 23, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 26, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 27, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 28, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 29, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 30, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 31, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 32, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 33, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 34, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 36, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 37, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 39, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 41, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 46, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 49, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 51, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 52, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (5, 53, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 1, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 2, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 3, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 5, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 6, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 7, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 10, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 12, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 14, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 15, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 16, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 18, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 19, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 21, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 22, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 29, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 30, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 31, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 35, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 36, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 38, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 39, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 40, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 41, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 44, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 45, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 46, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 47, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 48, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (6, 53, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 2, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 4, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 7, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 11, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 13, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 14, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 15, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 16, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 17, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 18, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 21, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 22, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 23, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 24, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 26, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 28, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 29, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 39, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 45, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 49, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 51, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 55, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (8, 56, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 2, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 3, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 4, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 5, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 7, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 11, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 12, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 16, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 18, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 20, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 23, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 24, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 25, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 26, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 27, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 28, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 31, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 32, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 34, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 35, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 38, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 39, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 40, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 43, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 44, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 46, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 47, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 50, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 51, NULL)
INSERT [dbo].[MultiTestQuestions] ([FK_MultiTestId], [FK_QuestionId], [Mark]) VALUES (9, 53, NULL)
/****** Object:  Table [dbo].[Answers]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [bigint] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](250) NOT NULL,
	[FK_QuestionId] [bigint] NOT NULL,
	[IsAnswer] [bit] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answers] ON
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (1, N'Ctrl +Shift', 1, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (2, N'Alt + F2', 1, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (3, N'Ctrl + Alt + M', 1, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (4, N'Alt + F10', 1, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (5, N'1960', 2, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (6, N'1969', 2, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (7, N'1975', 2, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (8, N'1979', 2, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (9, N'FTP', 3, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (10, N'Telnet', 3, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (11, N'Email', 3, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (12, N'WWW', 3, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (13, N'System Infomation', 4, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (14, N'Device Manager', 4, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (15, N'System Configuration Utility', 4, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (16, N'Registry Editor', 4, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (17, N'Format C:/s', 5, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (18, N'Fdisk', 5, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (19, N'Dir', 5, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (20, N'Fdisk /mbr', 5, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (21, N'1.5 Mbps', 6, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (22, N'12 Mbps', 6, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (23, N'400 Mbps', 6, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (24, N'480 Mbps', 6, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (25, N'Key-board', 7, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (26, N'VGA-Card', 7, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (27, N'Mainboard', 7, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (28, N'Monitor', 7, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (29, N'0', 8, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (30, N'12', 8, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (31, N'3', 8, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (32, N'4', 8, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (33, N'SS:= ’a’<’A’;', 9, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (34, N'SS:= ’A’=’a’;', 9, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (35, N'SS:= ‘an’ < ‘a’;', 9, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (36, N'SS:= ‘PASCAL’ < ‘pascal’;', 9, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (37, N'Format Cells, chọn Wrap Text', 10, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (38, N'Format Cells, Chọn Shrink to fit', 10, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (39, N'Format Cells, chọn Onentation', 10, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (40, N'Alt + Enter', 10, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (41, N'1024 KBps', 11, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (42, N'150 KBps', 11, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (43, N'1500 KBps', 11, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (44, N'2048 KBps', 11, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (45, N'Canh giữa  đối tượng', 12, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (46, N'Thay đổi mầu cho đối tượng', 12, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (47, N'Thay đổi kích thước của đối tượng', 12, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (48, N'Đối tượng tự động di chuyển theo chiều ngang, dọc/', 12, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (49, N'Ctrl+ ALT + Delete', 13, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (50, N'Ctrl+ A', 13, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (51, N'Shift+ F5', 13, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (52, N'Shift + F10', 13, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (53, N'Đọc, ghi đĩa CD', 14, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (54, N'Đọc, ghi đĩa DVD', 14, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (55, N'Đọc đĩa CD, DVD và ghi đĩa CD', 14, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (56, N'Đọc đĩa CD, DVD và ghi đĩa DVD', 14, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (57, N'Nhấn tổ hợp phím: Ctrl, Alt, Del', 15, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (58, N'Nhấn tổ hợp phím: Ctrl, Shift, Esc', 15, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (59, N'Click chuột phải vào thanh Taskbar chọn TaskManager', 15, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (60, N'Chạy lệnh “taskmanager” trong hộp thoại Run', 15, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (61, N'Tape', 16, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (62, N'HDD', 16, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (63, N'CDROM Drive', 16, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (64, N'FDD', 16, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (65, N'Mac', 17, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (66, N'Windows Vista', 17, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (67, N'Windows XP', 17, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (68, N'Linux', 17, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (69, N'Infrared', 18, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (70, N'Bluetooth', 18, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (71, N'WiFi', 18, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (72, N'WiMax', 18, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (73, N'FAT32', 19, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (74, N'HPFS', 19, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (75, N'NTFS', 19, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (76, N'EXT3', 19, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (77, N'COM', 20, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (78, N'LPT', 20, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (79, N'IEEE 1394', 20, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (80, N'RJ45', 20, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (81, N'ISA', 21, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (82, N'PCI', 21, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (83, N'CNR', 21, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (84, N'PCI', 21, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (85, N'Status bar', 22, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (86, N'Menu bar', 22, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (87, N'Task bar', 22, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (88, N'tất cả đều sai', 22, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (89, N'Plug and Play', 23, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (90, N'Windows Explorer', 23, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (91, N'Desktop', 23, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (92, N'Multimedia', 23, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (93, N'Menu bar', 24, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (94, N'Menu pad', 24, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (95, N'Menu options', 24, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (96, N'Tất cả đều sai', 24, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (97, N'Dialog box', 25, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (98, N'list box', 25, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (99, N'Control box', 25, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (100, N'Text box', 25, 0)
GO
print 'Processed 100 total records'
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (101, N'1 loại', 26, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (102, N'3 loại', 26, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (103, N'2 loại', 26, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (104, N'4 loại', 26, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (105, N'Click vao bieu tuong', 27, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (106, N'Nhấp đúp vào biểu tượng', 27, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (107, N'Tất cả đều đúng', 27, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (108, N'Tất cả đều sai', 27, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (109, N'Display', 28, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (110, N'Control panel', 28, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (111, N'Sreen Saver', 28, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (112, N'Tất cả đều có thể', 28, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (113, N'2', 29, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (114, N'3', 29, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (115, N'4', 29, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (116, N'5', 29, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (117, N'10', 30, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (118, N'12', 30, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (119, N'16', 30, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (120, N'20', 30, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (121, N'Xuống hàng chưa kết thúc paragraph', 31, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (122, N'Nhập dữ liệu theo hà ng dọc', 31, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (123, N'Xuống một trang mà n hình', 31, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (124, N'Tất cả đều sai', 31, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (125, N'Bật hoặc tắt gạch dưới nét đôi', 32, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (126, N'Bật hoặc tắt chỉ số trên', 32, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (127, N'Bật hoặc tắt chỉ số dưới', 32, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (128, N'Trả về dạng mặc định', 32, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (129, N'Ctrl + Shift + D', 33, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (130, N'Ctrl + Shift + A', 33, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (131, N'Ctrl + Shift + W', 33, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (132, N'Ctrl + Shift + K', 33, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (133, N'Định dạng cột', 34, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (134, N'Thay đổi font chữ', 34, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (135, N'Canh chỉnh Tab', 34, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (136, N'Tất cả đều sai', 34, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (137, N'Quy định khoảng cách từ mép đến trang in', 35, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (138, N'Chia văn bản thà nh số đoạn theo ý muốn', 35, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (139, N'Phần chừa trống để đóng thành tập.', 35, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (140, N'Quy định lề của trang in.', 35, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (141, N'Format/Tabs', 36, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (142, N'Format/Object', 36, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (143, N'Tools/Option/General', 36, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (144, N'Tools/Option/View', 36, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (145, N'Bar tab', 37, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (146, N'Decinal Tab', 37, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (147, N'Frist line indent', 37, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (148, N'Hanging indent', 37, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (149, N'Hiệu chỉnh ký hiệu của Number', 38, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (150, N'Thêm văn bản ở trước, sau dấu hoa thị', 38, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (151, N'Hiệu chỉnh ký hiệu của Bullets', 38, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (152, N'Thay đổi font chữ', 38, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (153, N'Giữ a ký tự Drop Cap với lề trái', 39, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (154, N'Giữ a ký tự Drop Cap với ký tự tiếp theo', 39, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (155, N'Giữ a ký tự Drop Cap với lề phải', 39, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (156, N'Giữ a ký tự Drop Cap với toà n văn bản', 39, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (157, N'Đặt lề cho văn bản cân xứng', 40, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (158, N'Đặt lề cho các trang chẳn và lẻ đối xứng', 40, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (159, N'Đặt cho tiêu đề cân xứng với văn bản', 40, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (160, N'Đặt lề cho các section đối xứng nhau', 40, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (161, N'chú thích được trình bà y ở cuối từ cần chú thích', 41, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (162, N'chú thích được trình bà y ở cuối trang', 41, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (163, N'chú thích được trình bà y ở cuối văn bản', 41, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (164, N'chú thích được trình bà y ở cuối toàn bộ', 41, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (165, N'Di chuyển con trỏ đến ô liền trước', 42, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (166, N'Thêm một tab và o ô', 42, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (167, N'Di chuyển con trỏ đến hà ng trên', 42, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (168, N'Phím nóng trên không có chức năng gì', 42, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (169, N'Alt + Shift + 5 (5 trên bà ng phím số)', 43, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (170, N'Alt + 5 (5 trên phím số và tắt numlock)', 43, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (171, N'a và b đều đúng', 43, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (172, N'a và b đều sai', 43, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (173, N'auto correct', 44, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (174, N'auto Format', 44, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (175, N'auto text', 44, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (176, N'Tất cả đều sai', 44, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (177, N'Từ lề trái đến vị trí Tab đã nhập', 45, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (178, N'Từ lề phải đến vị trí Tab đã nhập', 45, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (179, N'Cả a và b đều đúng', 45, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (180, N'a và b đều sai', 45, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (181, N'Quay ngược phong bì 180 độ', 46, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (182, N'Quay theo chiều của phong bì', 46, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (183, N'Quay theo chiều máy in', 46, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (184, N'Tất cả đều sai', 46, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (185, N'265 cột và 65563 dò ng', 47, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (186, N'266 cột và 65365 dò ng', 47, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (187, N'256 cột và 65536 dò ng', 47, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (188, N'256 cột và 65365 dò ng', 47, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (189, N'Địa chỉ tương đối', 48, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (190, N'Địa chỉ tuyệt đối', 48, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (191, N'Địa chỉ hỗn hợp', 48, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (192, N'Tất cả đều đúng', 48, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (193, N'Ngày', 49, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (194, N'Số', 49, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (195, N'Cả ngày và số', 49, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (196, N'Tất cả đều sai', 49, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (197, N'Không tìm thấy tên hàm', 50, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (198, N'Giá trị tham chiếu không tồn tại', 50, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (199, N'Không tham chiếu đến được', 50, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (200, N'Tập hợp rỗng', 50, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (201, N'Không tìm thấy tên hàm', 51, 0)
GO
print 'Processed 200 total records'
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (202, N'Giá trị tham chiếu không tồn tại', 51, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (203, N'Không tham chiếu đến được', 51, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (204, N'Tập hợp rỗng.', 51, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (205, N'Format Cells, chọn Wrap Text', 52, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (206, N'Format Cells, Chọn Shrink to fit', 52, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (207, N'Format Cells, chọn Onentation', 52, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (208, N'Alt + Enter', 52, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (209, N'136,000.22', 53, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (210, N'136000', 53, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (211, N'137,000.22', 53, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (212, N'137000', 53, 1)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (213, N'17', 54, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (214, N'25', 54, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (215, N'13', 54, 0)
INSERT [dbo].[Answers] ([AnswerId], [Content], [FK_QuestionId], [IsAnswer]) VALUES (216, N'Báo lỗi vì công thức sai', 54, 1)
SET IDENTITY_INSERT [dbo].[Answers] OFF
/****** Object:  Table [dbo].[TestQuestions]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestQuestions](
	[TestId] [bigint] NOT NULL,
	[QuestionId] [bigint] NOT NULL,
	[Mark] [float] NULL,
 CONSTRAINT [PK_TestQuestions_1] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 8, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 9, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 10, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 11, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 12, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 13, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 14, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 15, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 16, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 17, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 18, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 19, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 20, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 21, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 22, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 23, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 25, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 26, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 27, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 28, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 29, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 30, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 31, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 32, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 33, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 34, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 35, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 36, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 37, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (4, 38, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 17, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 18, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 19, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 20, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 21, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 22, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 23, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 25, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 26, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 27, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 28, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 29, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 30, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 31, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 32, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 33, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 34, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 35, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 36, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 37, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 38, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 39, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 40, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 41, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 42, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 43, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 44, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 45, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 46, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (5, 47, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 1, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 2, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 3, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 4, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 5, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 6, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 7, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 8, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 9, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 10, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 11, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 12, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 13, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 14, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 15, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 16, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 17, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 18, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 19, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 20, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 21, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 22, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 23, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 24, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 25, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 26, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 27, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 28, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 29, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 30, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 31, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 32, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 33, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 34, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 35, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 36, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 37, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 38, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 39, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 40, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 41, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 42, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 43, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 44, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 45, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 46, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 47, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 48, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 49, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 50, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 51, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 52, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 53, NULL)
INSERT [dbo].[TestQuestions] ([TestId], [QuestionId], [Mark]) VALUES (7, 54, NULL)
/****** Object:  Table [dbo].[StudentTestDetails]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTestDetails](
	[FK_TestId] [bigint] NOT NULL,
	[FK_StudentId] [bigint] NOT NULL,
	[FK_QuestionId] [bigint] NOT NULL,
	[FK_AnserId] [bigint] NULL,
 CONSTRAINT [PK_StudentTestDetails] PRIMARY KEY CLUSTERED 
(
	[FK_TestId] ASC,
	[FK_StudentId] ASC,
	[FK_QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectsClass]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubjectsClass](
	[SubjectsClassId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectsClassNo] [varchar](50) NOT NULL,
	[SubjectsClassName] [nvarchar](250) NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[FK_TeacherIdMain] [int] NOT NULL,
	[FK_TeacherIdSubject] [int] NOT NULL,
	[Partner] [nvarchar](250) NULL,
	[ContractValue] [int] NOT NULL,
	[FK_SubjectId] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[OpenOut] [bit] NOT NULL,
	[FK_DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_SubjectsClass] PRIMARY KEY CLUSTERED 
(
	[SubjectsClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SubjectsClass] ON
INSERT [dbo].[SubjectsClass] ([SubjectsClassId], [SubjectsClassNo], [SubjectsClassName], [FromDate], [ToDate], [FK_TeacherIdMain], [FK_TeacherIdSubject], [Partner], [ContractValue], [FK_SubjectId], [IsDelete], [OpenOut], [FK_DepartmentId]) VALUES (3, N'MT05BK02', N'Máy tính k05', CAST(0x00007B4C00000000 AS DateTime), CAST(0x00007B4C00000000 AS DateTime), 1, 1, N'Trường ĐH Bách Khoa Tp.Hồ Chí Minh', 5, 1, 0, 0, 2)
INSERT [dbo].[SubjectsClass] ([SubjectsClassId], [SubjectsClassNo], [SubjectsClassName], [FromDate], [ToDate], [FK_TeacherIdMain], [FK_TeacherIdSubject], [Partner], [ContractValue], [FK_SubjectId], [IsDelete], [OpenOut], [FK_DepartmentId]) VALUES (5, N'MT05BK01', N'May tinh Linh Trung', CAST(0x0000A246011E0810 AS DateTime), CAST(0x0000A2A1011E0810 AS DateTime), 1, 1, NULL, 0, 1, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[SubjectsClass] OFF
/****** Object:  Table [dbo].[SubjectsClassStudents]    Script Date: 10/06/2013 00:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectsClassStudents](
	[FK_SubjectClassId] [int] NOT NULL,
	[FK_StudentId] [bigint] NOT NULL,
 CONSTRAINT [PK_SubjectsClassStudents] PRIMARY KEY CLUSTERED 
(
	[FK_SubjectClassId] ASC,
	[FK_StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SubjectsClassStudents] ([FK_SubjectClassId], [FK_StudentId]) VALUES (3, 1)
INSERT [dbo].[SubjectsClassStudents] ([FK_SubjectClassId], [FK_StudentId]) VALUES (5, 1)
/****** Object:  Default [DF_Answers_IsAnswer]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Answers] ADD  CONSTRAINT [DF_Answers_IsAnswer]  DEFAULT ((0)) FOR [IsAnswer]
GO
/****** Object:  Default [DF_MultiTests_MultiTestDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[MultiTests] ADD  CONSTRAINT [DF_MultiTests_MultiTestDate]  DEFAULT (getdate()) FOR [MultiTestDate]
GO
/****** Object:  Default [DF_MultiTests_Time]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[MultiTests] ADD  CONSTRAINT [DF_MultiTests_Time]  DEFAULT ((0)) FOR [Time]
GO
/****** Object:  Default [DF_MultiTests_CreatedDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[MultiTests] ADD  CONSTRAINT [DF_MultiTests_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_MultiTests_UpdatedDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[MultiTests] ADD  CONSTRAINT [DF_MultiTests_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_Questions_Type]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_Type]  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF_Questions_CreatedDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_Questions_UpdatedDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_Questions_Time]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_Time]  DEFAULT ((0)) FOR [Time]
GO
/****** Object:  Default [DF_Questions_Purpose]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_Purpose]  DEFAULT ((0)) FOR [Purpose]
GO
/****** Object:  Default [DF_Questions_IsDelete]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_Questions_QuestionGuid]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_QuestionGuid]  DEFAULT (newid()) FOR [QuestionGuid]
GO
/****** Object:  Default [DF_SchoolInfos_IsActive]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SchoolInfos] ADD  CONSTRAINT [DF_SchoolInfos_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_Students_BirthDay]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Students_BirthDay]  DEFAULT (getdate()) FOR [BirthDay]
GO
/****** Object:  Default [DF_Students_SchoolYear]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Students_SchoolYear]  DEFAULT ((2010)) FOR [SchoolYear]
GO
/****** Object:  Default [DF_Subjects_SubjectGuid]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Subjects] ADD  CONSTRAINT [DF_Subjects_SubjectGuid]  DEFAULT (newid()) FOR [SubjectGuid]
GO
/****** Object:  Default [DF_SubjectsClass_FromDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass] ADD  CONSTRAINT [DF_SubjectsClass_FromDate]  DEFAULT (getdate()) FOR [FromDate]
GO
/****** Object:  Default [DF_SubjectsClass_ToDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass] ADD  CONSTRAINT [DF_SubjectsClass_ToDate]  DEFAULT (getdate()) FOR [ToDate]
GO
/****** Object:  Default [DF_SubjectsClass_ContractValue]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass] ADD  CONSTRAINT [DF_SubjectsClass_ContractValue]  DEFAULT ((0)) FOR [ContractValue]
GO
/****** Object:  Default [DF_SubjectsClass_OpenOut]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass] ADD  CONSTRAINT [DF_SubjectsClass_OpenOut]  DEFAULT ((0)) FOR [OpenOut]
GO
/****** Object:  Default [DF_SubjectsMultiTests_EasyNo1]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsMultiTests] ADD  CONSTRAINT [DF_SubjectsMultiTests_EasyNo1]  DEFAULT ((0)) FOR [EasyNo1]
GO
/****** Object:  Default [DF_SubjectsMultiTests_NormalNo1]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsMultiTests] ADD  CONSTRAINT [DF_SubjectsMultiTests_NormalNo1]  DEFAULT ((0)) FOR [NormalNo1]
GO
/****** Object:  Default [DF_SubjectsMultiTests_HardNo1]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsMultiTests] ADD  CONSTRAINT [DF_SubjectsMultiTests_HardNo1]  DEFAULT ((0)) FOR [HardNo1]
GO
/****** Object:  Default [DF_Teachers_Birthday]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [DF_Teachers_Birthday]  DEFAULT (getdate()) FOR [Birthday]
GO
/****** Object:  Default [DF_Tests_TestDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_TestDate]  DEFAULT (getdate()) FOR [TestDate]
GO
/****** Object:  Default [DF_Tests_Time]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_Time]  DEFAULT ((60)) FOR [Time]
GO
/****** Object:  Default [DF_Tests_CreatedDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_Tests_UpdatedDate]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_Tests_Purpose]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_Purpose]  DEFAULT ((0)) FOR [Purpose]
GO
/****** Object:  Default [DF_Tests_CopyNo]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_CopyNo]  DEFAULT ((0)) FOR [CopyNo]
GO
/****** Object:  Default [DF_Tests_EasyNo]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_EasyNo]  DEFAULT ((0)) FOR [EasyNo]
GO
/****** Object:  Default [DF_Tests_NormalNo]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_NormalNo]  DEFAULT ((0)) FOR [NormalNo]
GO
/****** Object:  Default [DF_Tests_HardNo]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_Tests_HardNo]  DEFAULT ((0)) FOR [HardNo]
GO
/****** Object:  ForeignKey [FK_Answers_Questions]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([FK_QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
/****** Object:  ForeignKey [FK_MultiTestCopies_MultiTests]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[MultiTestCopies]  WITH CHECK ADD  CONSTRAINT [FK_MultiTestCopies_MultiTests] FOREIGN KEY([FK_MultiTestId])
REFERENCES [dbo].[MultiTests] ([MultiTestId])
GO
ALTER TABLE [dbo].[MultiTestCopies] CHECK CONSTRAINT [FK_MultiTestCopies_MultiTests]
GO
/****** Object:  ForeignKey [FK_MultiTestQuestions_MultiTests]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[MultiTestQuestions]  WITH CHECK ADD  CONSTRAINT [FK_MultiTestQuestions_MultiTests] FOREIGN KEY([FK_MultiTestId])
REFERENCES [dbo].[MultiTests] ([MultiTestId])
GO
ALTER TABLE [dbo].[MultiTestQuestions] CHECK CONSTRAINT [FK_MultiTestQuestions_MultiTests]
GO
/****** Object:  ForeignKey [FK_MultiTestQuestions_Questions]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[MultiTestQuestions]  WITH CHECK ADD  CONSTRAINT [FK_MultiTestQuestions_Questions] FOREIGN KEY([FK_QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[MultiTestQuestions] CHECK CONSTRAINT [FK_MultiTestQuestions_Questions]
GO
/****** Object:  ForeignKey [FK_Questions_Subjects]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Subjects] FOREIGN KEY([FK_SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Subjects]
GO
/****** Object:  ForeignKey [FK_StudentTestDetails_Questions]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[StudentTestDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentTestDetails_Questions] FOREIGN KEY([FK_QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[StudentTestDetails] CHECK CONSTRAINT [FK_StudentTestDetails_Questions]
GO
/****** Object:  ForeignKey [FK_StudentTestDetails_Students]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[StudentTestDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentTestDetails_Students] FOREIGN KEY([FK_StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[StudentTestDetails] CHECK CONSTRAINT [FK_StudentTestDetails_Students]
GO
/****** Object:  ForeignKey [FK_StudentTestDetails_Tests]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[StudentTestDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentTestDetails_Tests] FOREIGN KEY([FK_TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO
ALTER TABLE [dbo].[StudentTestDetails] CHECK CONSTRAINT [FK_StudentTestDetails_Tests]
GO
/****** Object:  ForeignKey [FK_StudentTests_Students]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[StudentTests]  WITH CHECK ADD  CONSTRAINT [FK_StudentTests_Students] FOREIGN KEY([FK_StudenId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[StudentTests] CHECK CONSTRAINT [FK_StudentTests_Students]
GO
/****** Object:  ForeignKey [FK_StudentTests_Tests]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[StudentTests]  WITH CHECK ADD  CONSTRAINT [FK_StudentTests_Tests] FOREIGN KEY([FK_TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO
ALTER TABLE [dbo].[StudentTests] CHECK CONSTRAINT [FK_StudentTests_Tests]
GO
/****** Object:  ForeignKey [FK_SubjectsClass_Departments]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsClass_Departments] FOREIGN KEY([FK_DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[SubjectsClass] CHECK CONSTRAINT [FK_SubjectsClass_Departments]
GO
/****** Object:  ForeignKey [FK_SubjectsClass_MainTeachers]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsClass_MainTeachers] FOREIGN KEY([FK_TeacherIdMain])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[SubjectsClass] CHECK CONSTRAINT [FK_SubjectsClass_MainTeachers]
GO
/****** Object:  ForeignKey [FK_SubjectsClass_Subjects]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsClass_Subjects] FOREIGN KEY([FK_SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[SubjectsClass] CHECK CONSTRAINT [FK_SubjectsClass_Subjects]
GO
/****** Object:  ForeignKey [FK_SubjectsClass_SubjectTeachers]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsClass_SubjectTeachers] FOREIGN KEY([FK_TeacherIdSubject])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[SubjectsClass] CHECK CONSTRAINT [FK_SubjectsClass_SubjectTeachers]
GO
/****** Object:  ForeignKey [FK_SubjectsClassStudents_Students]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClassStudents]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsClassStudents_Students] FOREIGN KEY([FK_StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[SubjectsClassStudents] CHECK CONSTRAINT [FK_SubjectsClassStudents_Students]
GO
/****** Object:  ForeignKey [FK_SubjectsClassStudents_Subjects]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsClassStudents]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsClassStudents_Subjects] FOREIGN KEY([FK_SubjectClassId])
REFERENCES [dbo].[SubjectsClass] ([SubjectsClassId])
GO
ALTER TABLE [dbo].[SubjectsClassStudents] CHECK CONSTRAINT [FK_SubjectsClassStudents_Subjects]
GO
/****** Object:  ForeignKey [FK_SubjectsMultiTests_MultiTests]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsMultiTests]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsMultiTests_MultiTests] FOREIGN KEY([FK_MultiTestId])
REFERENCES [dbo].[MultiTests] ([MultiTestId])
GO
ALTER TABLE [dbo].[SubjectsMultiTests] CHECK CONSTRAINT [FK_SubjectsMultiTests_MultiTests]
GO
/****** Object:  ForeignKey [FK_SubjectsMultiTests_Subjects]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[SubjectsMultiTests]  WITH CHECK ADD  CONSTRAINT [FK_SubjectsMultiTests_Subjects] FOREIGN KEY([FK_SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[SubjectsMultiTests] CHECK CONSTRAINT [FK_SubjectsMultiTests_Subjects]
GO
/****** Object:  ForeignKey [FK_Teachers_Departments]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Departments] FOREIGN KEY([FK_DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Departments]
GO
/****** Object:  ForeignKey [FK_TestCopies_Tests]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[TestCopies]  WITH CHECK ADD  CONSTRAINT [FK_TestCopies_Tests] FOREIGN KEY([FK_TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO
ALTER TABLE [dbo].[TestCopies] CHECK CONSTRAINT [FK_TestCopies_Tests]
GO
/****** Object:  ForeignKey [FK_TestQuestions_Questions]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[TestQuestions]  WITH CHECK ADD  CONSTRAINT [FK_TestQuestions_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[TestQuestions] CHECK CONSTRAINT [FK_TestQuestions_Questions]
GO
/****** Object:  ForeignKey [FK_TestQuestions_Tests]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[TestQuestions]  WITH CHECK ADD  CONSTRAINT [FK_TestQuestions_Tests] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO
ALTER TABLE [dbo].[TestQuestions] CHECK CONSTRAINT [FK_TestQuestions_Tests]
GO
/****** Object:  ForeignKey [FK_UserSubjectRights_Subjects]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[UserSubjectRights]  WITH CHECK ADD  CONSTRAINT [FK_UserSubjectRights_Subjects] FOREIGN KEY([FK_SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[UserSubjectRights] CHECK CONSTRAINT [FK_UserSubjectRights_Subjects]
GO
/****** Object:  ForeignKey [FK_UserSubjectRights_Teachers]    Script Date: 10/06/2013 00:38:56 ******/
ALTER TABLE [dbo].[UserSubjectRights]  WITH CHECK ADD  CONSTRAINT [FK_UserSubjectRights_Teachers] FOREIGN KEY([FK_TeacherId])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[UserSubjectRights] CHECK CONSTRAINT [FK_UserSubjectRights_Teachers]
GO
