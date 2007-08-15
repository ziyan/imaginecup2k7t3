
/****** Object:  Table [dbo].[obj_group]    Script Date: 08/14/2007 20:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[description] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[user_id] [int] NOT NULL,
	[invitation_only] [bit] NOT NULL,
	[member_only] [bit] NOT NULL,
	[date] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[obj_interest]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[obj_interest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
	[name] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[obj_lang]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[obj_lang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[obj_message]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[src_id] [int] NOT NULL,
	[dst_id] [int] NOT NULL,
	[dst_type] [tinyint] NOT NULL,
	[subject] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[body] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[date] [datetime] NOT NULL,
	[unread] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[obj_trans_ans]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_trans_ans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[req_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[message] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[rating] [tinyint] NOT NULL,
	[date] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[obj_trans_req]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_trans_req](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[src_lang_id] [int] NOT NULL,
	[dst_lang_id] [int] NOT NULL,
	[subject] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[message] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[dst_type] [tinyint] NOT NULL,
	[dst_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[completed] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[obj_user]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[obj_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[password] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[email] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[name] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[description] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[reg_date] [datetime] NOT NULL,
	[log_date] [datetime] NULL,
	[sn_network] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sn_screenname] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[user_rating] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rel_group_interest]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_group_interest](
	[group_id] [int] NOT NULL,
	[interest_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rel_trans_ans_rating]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_trans_ans_rating](
	[user_id] [int] NOT NULL,
	[trans_ans_id] [int] NOT NULL,
	[rating] [tinyint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rel_user_group]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_group](
	[user_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[status] [tinyint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rel_user_interest]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_interest](
	[user_id] [int] NOT NULL,
	[interest_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rel_user_lang]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_lang](
	[user_id] [int] NOT NULL,
	[lang_id] [int] NOT NULL,
	[self_rating] [tinyint] NOT NULL,
	[net_rating] [float] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rel_user_user]    Script Date: 08/14/2007 20:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_user](
	[user_id] [int] NOT NULL,
	[favor_user_id] [int] NOT NULL
) ON [PRIMARY]
