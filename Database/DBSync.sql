CREATE TABLE [dbo].[RCGR_ResultcodeGroups](
	[RCGR_ResultcodeGroupNr] [int] IDENTITY(1,1) NOT NULL,
	[RCGR_ResultcodeGroupDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RCGR_ResultcodeGroups] PRIMARY KEY CLUSTERED 
(
	[RCGR_ResultcodeGroupNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[RCOD_Resultcodes](
	[RCOD_ResultcodeGroupNr] [int] NOT NULL,
	[RCOD_ResultcodeNr] [tinyint] NOT NULL,
	[RCOD_ResultcodeDescription] [nvarchar](max) NOT NULL,
	[RCOD_ResultcodePercentage] [bit] NOT NULL,
	[RCOD_ResultcodeAction] [tinyint] NOT NULL,
	[RCOD_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[RCOD_AutogradePercentage] [bit] NOT NULL,
	[RCOD_AutogradeScript] [varbinary](max) NULL,
	[RCOD_StagePosition] [int] NULL,
	[RCOD_CameraParameters] [varbinary](max) NULL,
	[RCOD_ResultcodeIndex] [tinyint] NOT NULL,
	[RCOD_Threshold] [float] NOT NULL,
	[RCOD_KeyIndex] [int] NULL,
 CONSTRAINT [PK_RCOD_Resultcodes_1] PRIMARY KEY CLUSTERED 
(
	[RCOD_Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[METH_Methods](
	[METH_MethodNr] [int] IDENTITY(1,1) NOT NULL,
	[METH_MethodName] [nvarchar](max) NOT NULL,
	[METH_MethodType] [nvarchar](100) NOT NULL,
	[METH_Destructive] [bit] NOT NULL,
	[METH_ResultcodeGroupNr] [int] NULL,
	[METH_AutoResultcode] [bit] NOT NULL,
	[METH_ResultcodeIndex] [bigint] NULL,
	[METH_CreationDate] [int] NULL,
	[METH_CreationTime] [int] NULL,
	[METH_ModificationDate] [int] NULL,
	[METH_ModificationTime] [int] NULL,
	[METH_UserHistoryNr] [int] NULL,
	[METH_MethodObject] [varbinary](max) NULL,
	[METH_SensorMaxForceRange] [float] NULL,
	[METH_AutomationMethods] [bit] NOT NULL,
	[METH_FormNr] [int] NOT NULL,
	[METH_MethodOrderNr] [int] NOT NULL,
 CONSTRAINT [PK_METH_Methods] PRIMARY KEY CLUSTERED 
(
	[METH_MethodNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Alter database DBSync SET CHANGE_TRACKING = ON (CHANGE_RETENTION = 14 DAYS, AUTO_CLEANUP = ON)