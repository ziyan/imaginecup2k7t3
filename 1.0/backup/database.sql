USE [omniproject_db1]
GO
/****** Object:  Table [dbo].[obj_lang]    Script Date: 06/16/2007 19:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[obj_lang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](3) NOT NULL,
 CONSTRAINT [PK_obj_lang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[obj_message]    Script Date: 06/16/2007 19:14:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[src_id] [int] NOT NULL,
	[dst_id] [int] NOT NULL,
	[dst_type] [tinyint] NOT NULL,
	[subject] [nvarchar](255) NOT NULL,
	[body] [ntext] NOT NULL,
	[date] [datetime] NOT NULL CONSTRAINT [DF_obj_message_date]  DEFAULT (getdate()),
	[unread] [bit] NOT NULL,
	[pending_trans] [bit] NOT NULL,
	[trans_req_id] [int] NOT NULL,
 CONSTRAINT [PK_obj_message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[obj_trans_ans]    Script Date: 06/16/2007 19:15:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_trans_ans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[req_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[message] [ntext] NOT NULL,
	[rating] [tinyint] NOT NULL,
	[date] [datetime] NOT NULL CONSTRAINT [DF_obj_trans_ans_date]  DEFAULT (getdate()),
 CONSTRAINT [PK_obj_transans] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[obj_trans_req]    Script Date: 06/16/2007 19:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_trans_req](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[src_lang_id] [int] NOT NULL,
	[dst_lang_id] [int] NOT NULL,
	[subject] [nvarchar](50) NOT NULL,
	[message] [ntext] NOT NULL,
	[dst_type] [tinyint] NOT NULL,
	[dst_id] [int] NOT NULL,
	[date] [datetime] NOT NULL CONSTRAINT [DF_obj_trans_req_date]  DEFAULT (getdate()),
	[completed] [bit] NOT NULL,
	[msg_id] [int] NOT NULL,
 CONSTRAINT [PK_obj_trans_req] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[obj_user]    Script Date: 06/16/2007 19:15:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nchar](42) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [ntext] NULL,
	[reg_date] [datetime] NOT NULL CONSTRAINT [DF_obj_user_reg_date]  DEFAULT (getdate()),
	[log_date] [datetime] NULL,
 CONSTRAINT [PK_obj_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_group_interest]    Script Date: 06/16/2007 19:15:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_group_interest](
	[group_id] [int] NOT NULL,
	[interest_id] [int] NOT NULL,
 CONSTRAINT [PK_rel_group_interest] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC,
	[interest_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_interest_lang]    Script Date: 06/16/2007 19:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_interest_lang](
	[interest_id] [int] NOT NULL,
	[lang_id] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_rel_interest_lang] PRIMARY KEY CLUSTERED 
(
	[interest_id] ASC,
	[lang_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_lang_lang]    Script Date: 06/16/2007 19:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_lang_lang](
	[lang_id] [int] NOT NULL,
	[dst_lang_id] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_rel_lang_lang] PRIMARY KEY CLUSTERED 
(
	[lang_id] ASC,
	[dst_lang_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_trans_ans_rating]    Script Date: 06/16/2007 19:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_trans_ans_rating](
	[user_id] [int] NOT NULL,
	[trans_ans_id] [int] NOT NULL,
	[rating] [tinyint] NOT NULL,
 CONSTRAINT [PK_rel_obj_rating_1] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[trans_ans_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_user_group]    Script Date: 06/16/2007 19:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_group](
	[user_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[status] [tinyint] NOT NULL,
 CONSTRAINT [PK_rel_user_group] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[group_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_user_interest]    Script Date: 06/16/2007 19:15:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_interest](
	[user_id] [int] NOT NULL,
	[interest_id] [int] NOT NULL,
 CONSTRAINT [PK_rel_user_interest] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[interest_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[omni_user_favor_user_add_by_id]    Script Date: 06/16/2007 19:14:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_favor_user_add_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@favor_user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (SELECT COUNT(*) FROM rel_user_user WHERE user_id = @user_id AND favor_user_id = @favor_user_id)>=1
		RETURN 0
	INSERT INTO rel_user_user (user_id, favor_user_id) VALUES (@user_id, @favor_user_id)

END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_favor_user_delete_by_id]    Script Date: 06/16/2007 19:14:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_favor_user_delete_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@favor_user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM rel_user_user WHERE user_id = @user_id AND favor_user_id = @favor_user_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_lang_delete_by_id]    Script Date: 06/16/2007 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_lang_delete_by_id] 
	-- Add the parameters for the stored procedure here
	@user_id int,
	@lang_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM rel_user_lang WHERE user_id = @user_id AND lang_id = @lang_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_lang_list_by_id]    Script Date: 06/16/2007 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_lang_list_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT lang_id, self_rating, net_rating FROM rel_user_lang WHERE rel_user_lang.user_id = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_lang_set_by_id]    Script Date: 06/16/2007 19:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_lang_set_by_id] 
	-- Add the parameters for the stored procedure here
	@user_id int,
	@lang_id int,
	@self_rating tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (SELECT COUNT(*) FROM rel_user_lang WHERE user_id = @user_id AND lang_id = @lang_id) > 0
		UPDATE rel_user_lang SET self_rating = @self_rating WHERE  user_id = @user_id AND lang_id = @lang_id
	ELSE
		INSERT INTO rel_user_lang (user_id, lang_id, self_rating) VALUES (@user_id, @lang_id, @self_rating)
END
GO
/****** Object:  Table [dbo].[rel_user_user]    Script Date: 06/16/2007 19:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_user](
	[user_id] [int] NOT NULL,
	[favor_user_id] [int] NOT NULL,
 CONSTRAINT [PK_rel_user_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[favor_user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_user_lang]    Script Date: 06/16/2007 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_user_lang](
	[user_id] [int] NOT NULL,
	[lang_id] [int] NOT NULL,
	[self_rating] [tinyint] NOT NULL,
	[net_rating] [float] NOT NULL CONSTRAINT [DF_rel_user_lang_net_rating]  DEFAULT ((0))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[obj_group]    Script Date: 06/16/2007 19:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[user_id] [int] NOT NULL,
	[invitation_only] [bit] NOT NULL,
	[member_only] [bit] NOT NULL,
	[date] [datetime] NOT NULL CONSTRAINT [DF_obj_group_date]  DEFAULT (getdate()),
 CONSTRAINT [PK_obj_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[obj_interest]    Script Date: 06/16/2007 19:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obj_interest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
 CONSTRAINT [PK_obj_interest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[omni_lang_lang_query_by_code]    Script Date: 06/16/2007 19:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_lang_lang_query_by_code]
	-- Add the parameters for the stored procedure here
	@lang_code varchar(3),
	@dst_lang_code varchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_lang.id,rel_lang_lang.dst_lang_id,rel_lang_lang.name FROM rel_lang_lang INNER JOIN obj_lang ON obj_lang.id = rel_lang_lang.lang_id
		WHERE obj_lang.code = @lang_code AND rel_lang_lang.dst_lang_id = (SELECT id FROM obj_lang WHERE code = @dst_lang_code)
END
GO
/****** Object:  StoredProcedure [dbo].[omni_lang_lang_query_by_id]    Script Date: 06/16/2007 19:14:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_lang_lang_query_by_id]
	-- Add the parameters for the stored procedure here
	@lang_id int,
	@dst_lang_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_lang.code,rel_lang_lang.name FROM rel_lang_lang INNER JOIN obj_lang ON obj_lang.id = rel_lang_lang.lang_id
		WHERE obj_lang.id = @lang_id AND rel_lang_lang.dst_lang_id = @dst_lang_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_lang_list]    Script Date: 06/16/2007 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_lang_list]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, code FROM obj_lang
END
GO
/****** Object:  StoredProcedure [dbo].[omni_message_get_by_id]    Script Date: 06/16/2007 19:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_message_get_by_id]
	@msg_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE obj_message SET unread = 0 WHERE id = @msg_id
	SELECT src_id, dst_id, dst_type, subject, body, date, pending_trans, unread, trans_req_id FROM obj_message WHERE id = @msg_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_message_recv_by_user]    Script Date: 06/16/2007 19:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_message_recv_by_user]
	-- Add the parameters for the stored procedure here
	@dst_id int,
	@dst_type tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, src_id, dst_id, subject, date, unread, pending_trans, trans_req_id
		FROM obj_message 
		WHERE @dst_id = dst_id AND @dst_type = dst_type AND pending_trans = 0 ORDER BY date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_message_send]    Script Date: 06/16/2007 19:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_message_send]
	-- Add the parameters for the stored procedure here
	@src_id int,
	@dst_id int,
	@dst_type tinyint,
	@subject nvarchar(255),
	@body ntext,
	@pending_trans bit,
	@trans_req_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO obj_message (src_id, dst_id, dst_type, subject, body, date, unread, pending_trans, trans_req_id )
		VALUES ( @src_id, @dst_id, @dst_type, @subject, @body, getdate(), 1, @pending_trans, @trans_req_id )
	SELECT @@IDENTITY
	RETURN @@IDENTITY 
END
GO
/****** Object:  StoredProcedure [dbo].[omni_message_sent_by_user]    Script Date: 06/16/2007 19:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_message_sent_by_user]
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, src_id, dst_id, dst_type, subject, date, pending_trans, unread, trans_req_id
		FROM obj_message 
		WHERE @user_id = src_id AND pending_trans = 0 ORDER BY date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_close]    Script Date: 06/16/2007 19:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_req_close] 
	-- Add the parameters for the stored procedure here
	@req_id int,
	@ans_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE obj_trans_req SET completed = 1 WHERE id = @req_id
	
	DECLARE @msg_id int
	SELECT @msg_id = (SELECT msg_id FROM obj_trans_req WHERE @req_id = id)

	IF @msg_id > 0 UPDATE obj_message SET pending_trans = 0, body = cast(body AS nvarchar(4000))
	+ '\r\n\r\n' + cast((SELECT message FROM obj_trans_ans WHERE id = @ans_id) AS nvarchar(4000)) WHERE id = @msg_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_message_pending_by_user]    Script Date: 06/16/2007 19:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_message_pending_by_user]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, src_id, dst_id, dst_type, subject, date, pending_trans, unread, trans_req_id
		FROM obj_message 
		WHERE @user_id = src_id AND pending_trans = 1
		ORDER BY date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_get_by_ans_id]    Script Date: 06/16/2007 19:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_get_by_ans_id]
	-- Add the parameters for the stored procedure here
	@ans_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_trans_req.user_id,
		   obj_trans_req.src_lang_id,
		   obj_trans_req.dst_lang_id,
		   obj_trans_req.subject,
		   obj_trans_req.message,
		   obj_trans_req.dst_type,
		   obj_trans_req.dst_id,
		   obj_trans_req.date,
		   obj_trans_req.completed,
		   obj_trans_req.msg_id,
		   obj_trans_ans.id AS ans_id,
		   obj_trans_ans.req_id,
		   obj_trans_ans.message AS trans_message,
		   obj_trans_ans.user_id AS ans_user_id,
		   obj_trans_ans.rating,
		   obj_trans_ans.date AS ans_date
		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
		WHERE obj_trans_ans.id = @ans_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_search]    Script Date: 06/16/2007 19:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_search] 
	-- Add the parameters for the stored procedure here
	@keyword nvarchar(255),
	@src_lang_id int,
	@dst_lang_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @keyword = '%' + @keyword + '%'

	SELECT obj_trans_req.id, obj_trans_req.src_lang_id, obj_trans_req.dst_lang_id, obj_trans_req.subject, obj_trans_req.date
		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
		WHERE ((@src_lang_id = obj_trans_req.src_lang_id AND @dst_lang_id = obj_trans_req.dst_lang_id ) OR
			   (@src_lang_id = obj_trans_req.dst_lang_id AND @dst_lang_id = obj_trans_req.src_lang_id )) AND
			   (obj_trans_req.subject LIKE @keyword OR obj_trans_req.message LIKE @keyword OR obj_trans_ans.message LIKE @keyword)
		ORDER BY obj_trans_req.date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_ans_rate_get_by_id]    Script Date: 06/16/2007 19:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_ans_rate_get_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@ans_id int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @rated bit
	SELECT @rated = 0
	IF (SELECT COUNT(*) FROM rel_trans_ans_rating WHERE user_id = @user_id AND trans_ans_id = @ans_id )>0 OR @user_id = 0
		SELECT @rated = 1
    -- Insert statements for procedure here
	SELECT @rated AS rated, rating FROM obj_trans_ans WHERE id = @ans_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_rank_by_quantity]    Script Date: 06/16/2007 19:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_rank_by_quantity]
	-- Add the parameters for the stored procedure here
	@interval float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 100 id, username, name, email, description, reg_date, log_date, (SELECT count(*) FROM obj_trans_ans WHERE obj_trans_ans.user_id = obj_user.id AND obj_trans_ans.date >= getdate() - @interval) AS quantity
	FROM obj_user ORDER BY (SELECT count(*) FROM obj_trans_ans WHERE obj_trans_ans.user_id = obj_user.id AND obj_trans_ans.date >= getdate() - @interval) DESC, username ASC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_get_unapp_by_user]    Script Date: 06/16/2007 19:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_get_unapp_by_user]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_trans_req.user_id,
		   obj_trans_req.src_lang_id,
		   obj_trans_req.dst_lang_id,
		   obj_trans_req.subject,
		   obj_trans_req.dst_type,
		   obj_trans_req.dst_id,
		   obj_trans_req.date,
		   obj_trans_req.completed,
		   obj_trans_req.msg_id,
		   obj_trans_ans.id AS ans_id,
		   obj_trans_ans.req_id,
		   obj_trans_ans.user_id AS ans_user_id,
		   obj_trans_ans.date AS ans_date
		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
		WHERE obj_trans_req.completed = 0 AND obj_trans_req.user_id = @user_id
		ORDER BY obj_trans_ans.date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_get_by_req_id]    Script Date: 06/16/2007 19:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_get_by_req_id]
	-- Add the parameters for the stored procedure here
	@req_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_trans_req.user_id,
		   obj_trans_req.src_lang_id,
		   obj_trans_req.dst_lang_id,
		   obj_trans_req.subject,
		   obj_trans_req.message,
		   obj_trans_req.dst_type,
		   obj_trans_req.dst_id,
		   obj_trans_req.date,
		   obj_trans_req.completed,
		   obj_trans_req.msg_id,
		   obj_trans_ans.id AS ans_id,
		   obj_trans_ans.req_id,
		   obj_trans_ans.message AS trans_message,
		   obj_trans_ans.user_id AS ans_user_id,
		   obj_trans_ans.rating,
		   obj_trans_ans.date AS ans_date
		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
		WHERE obj_trans_req.id = @req_id
		ORDER BY obj_trans_ans.date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_ans_add]    Script Date: 06/16/2007 19:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_ans_add] 
	-- Add the parameters for the stored procedure here
	@req_id int,
	@user_id int,
	@message ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO obj_trans_ans ( req_id, user_id, message, rating, date )
		VALUES ( @req_id, @user_id, @message, 0, getdate() )
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_ans_rate_by_id]    Script Date: 06/16/2007 19:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_ans_rate_by_id] 
	-- Add the parameters for the stored procedure here
	@user_id int,
	@trans_ans_id int,
	@rating	tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF (SELECT COUNT(*) FROM rel_trans_ans_rating WHERE user_id = @user_id AND trans_ans_id = @trans_ans_id) >0
	RETURN 0
    -- Insert statements for procedure here
	INSERT INTO rel_trans_ans_rating ( user_id, trans_ans_id, rating ) 
			VALUES ( @user_id, @trans_ans_id, @rating )
	

	UPDATE obj_trans_ans 
		SET rating = 
		( SELECT AVG(cast(rating AS float)) FROM rel_trans_ans_rating WHERE trans_ans_id = @trans_ans_id )
		WHERE id = @trans_ans_id


	DECLARE @ans_user_id int
	SELECT @ans_user_id = (SELECT user_id FROM obj_trans_ans WHERE id = @trans_ans_id)

	UPDATE rel_user_lang
		SET net_rating = ( SELECT AVG(cast(rel_trans_ans_rating.rating AS float))
		FROM rel_trans_ans_rating INNER JOIN obj_trans_ans ON rel_trans_ans_rating.trans_ans_id = obj_trans_ans.id
		WHERE obj_trans_ans.user_id = @ans_user_id)
		WHERE rel_user_lang.user_id = @ans_user_id
		AND rel_user_lang.lang_id = (SELECT lang_id FROM obj_trans_ans WHERE id = @trans_ans_id)
	
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_get_pending_by_user]    Script Date: 06/16/2007 19:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_get_pending_by_user] 
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, src_lang_id, dst_lang_id, subject, dst_type, dst_id, date, msg_id FROM obj_trans_req
		WHERE completed = 0 AND user_id = @user_id
		ORDER BY date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_get_by_id]    Script Date: 06/16/2007 19:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_req_get_by_id]
	-- Add the parameters for the stored procedure here
	@req_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT src_lang_id, dst_lang_id, subject, message, dst_type, dst_id, date, completed, msg_id, user_id FROM obj_trans_req
		WHERE id = @req_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_add]    Script Date: 06/16/2007 19:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_req_add]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@src_lang_id int,
	@dst_lang_id int,
	@subject nvarchar(50),
	@message ntext,
	@dst_id int,
	@dst_type tinyint,
	@msg_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO obj_trans_req ( user_id, src_lang_id, dst_lang_id, subject, message, dst_id, dst_type, date, completed, msg_id )
		VALUES ( @user_id, @src_lang_id, @dst_lang_id, @subject, @message, @dst_id, @dst_type, getdate(), 0, @msg_id )
	SELECT @@IDENTITY
	RETURN @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_get_app_by_user]    Script Date: 06/16/2007 19:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_get_app_by_user]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_trans_req.user_id,
		   obj_trans_req.src_lang_id,
		   obj_trans_req.dst_lang_id,
		   obj_trans_req.subject,
		   obj_trans_req.dst_type,
		   obj_trans_req.dst_id,
		   obj_trans_req.date,
		   obj_trans_req.completed,
		   obj_trans_req.msg_id,
		   obj_trans_req.id AS req_id
		FROM obj_trans_req
		WHERE obj_trans_req.completed = 1 AND obj_trans_req.user_id = @user_id
		ORDER BY obj_trans_req.date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_get_for_user]    Script Date: 06/16/2007 19:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_req_get_for_user]
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, src_lang_id, dst_lang_id, subject, dst_type, dst_id, date, completed, msg_id FROM obj_trans_req
		WHERE dst_id = @user_id AND dst_type = 1 AND completed = 0
	ORDER BY date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_find_global_for_user]    Script Date: 06/16/2007 19:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_req_find_global_for_user]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_trans_req.id, obj_trans_req.src_lang_id, obj_trans_req.dst_lang_id, obj_trans_req.subject, obj_trans_req.dst_type, obj_trans_req.dst_id, date, obj_trans_req.msg_id, obj_trans_req.user_id 
		FROM obj_trans_req INNER JOIN rel_user_lang AS src_user_lang ON obj_trans_req.src_lang_id = src_user_lang.lang_id INNER JOIN rel_user_lang AS dst_user_lang ON obj_trans_req.dst_lang_id = dst_user_lang.lang_id
		WHERE obj_trans_req.completed = 0 AND dst_type = 0 AND src_user_lang.user_id = @user_id AND dst_user_lang.user_id = @user_id AND obj_trans_req.user_id != @user_id
		ORDER BY obj_trans_req.date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_message_upd_trans_req_id]    Script Date: 06/16/2007 19:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_message_upd_trans_req_id]
	-- Add the parameters for the stored procedure here
	@msg_id int,
	@req_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE obj_trans_req SET msg_id = @msg_id WHERE id = @req_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_search]    Script Date: 06/16/2007 19:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_search]
	-- Add the parameters for the stored procedure here
	@keyword nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @keyword = '%' + @keyword + '%'

    -- Insert statements for procedure here
	SELECT id, username, name, email, description, reg_date, log_date FROM obj_user
	WHERE username like @keyword OR name like @keyword OR email like @keyword OR description like @keyword
	ORDER BY username ASC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_rank_by_rating]    Script Date: 06/16/2007 19:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_rank_by_rating]
	-- Add the parameters for the stored procedure here
	@lang_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 100 id, username, name, email, description, reg_date, log_date, rel_user_lang.lang_id, rel_user_lang.net_rating
	FROM obj_user INNER JOIN rel_user_lang ON obj_user.id = rel_user_lang.user_id
	WHERE rel_user_lang.lang_id = @lang_id OR @lang_id = 0
	ORDER BY rel_user_lang.net_rating DESC, username ASC
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_password_get_by_id]    Script Date: 06/16/2007 19:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_password_get_by_id]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_user.password FROM obj_user WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_password_get_by_username]    Script Date: 06/16/2007 19:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_password_get_by_username] 
	-- Add the parameters for the stored procedure here
	@username nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_user.password FROM obj_user WHERE obj_user.username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_password_update_by_id]    Script Date: 06/16/2007 19:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_password_update_by_id]
	-- Add the parameters for the stored procedure here
	@id int,
	@password varchar(42)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE obj_user SET obj_user.password = @password WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_update_by_id]    Script Date: 06/16/2007 19:14:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_update_by_id]
-- Add the parameters for the stored procedure here
	@id int,
	@email nvarchar(255),
	@name nvarchar(100),
	@description ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE obj_user SET	obj_user.email = @email,
						obj_user.name = @name,
						obj_user.description = @description
		WHERE id = @id
				
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_get_by_id]    Script Date: 06/16/2007 19:14:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_get_by_id]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT email, username, [name], [description], reg_date, log_date FROM obj_user WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_id_get_by_username]    Script Date: 06/16/2007 19:14:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_id_get_by_username]
	-- Add the parameters for the stored procedure here
	@username nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id FROM obj_user WHERE obj_user.username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_authorize_by_username]    Script Date: 06/16/2007 19:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_authorize_by_username]
	-- Add the parameters for the stored procedure here
	@username nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,username,[name],email,[description],reg_date,log_date FROM obj_user WHERE username = @username
	UPDATE obj_user SET log_date = getdate() WHERE username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_favor_user_list_by_id]    Script Date: 06/16/2007 19:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_favor_user_list_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_user.id, obj_user.username, obj_user.name, obj_user.email, obj_user.description, obj_user.reg_date, obj_user.log_date
	FROM rel_user_user INNER JOIN obj_user ON rel_user_user.favor_user_id = obj_user.id
	WHERE rel_user_user.user_id = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_register]    Script Date: 06/16/2007 19:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ziyan Zhou
-- Create date: 06/11/2007
-- Description:	user registration
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_register] 
	-- Add the parameters for the stored procedure here
	@username nvarchar(100),
	@password varchar(42),
	@email nvarchar(255),
	@name nvarchar(100),
	@description ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF (SELECT COUNT(*) FROM obj_user WHERE obj_user.username = @username) >= 1
	BEGIN
		SELECT -1
		RETURN -1
	END	

    -- Insert statements for procedure here
	INSERT INTO obj_user (obj_user.username,obj_user.password,obj_user.email,obj_user.name,obj_user.description)
		VALUES (@username, @password, @email, @name, @description)
	SELECT @@IDENTITY
	RETURN @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[omni_interest_lang_list]    Script Date: 06/16/2007 19:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_interest_lang_list]
	-- Add the parameters for the stored procedure here
	@parent_id int = -1,
	@lang_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_interest.id,obj_interest.parent_id,rel_interest_lang.name FROM obj_interest INNER JOIN rel_interest_lang ON obj_interest.id = rel_interest_lang.interest_id
		WHERE (obj_interest.parent_id = @parent_id OR @parent_id = -1) AND rel_interest_lang.lang_id = @lang_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_interest_lang_query_by_id]    Script Date: 06/16/2007 19:14:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_interest_lang_query_by_id]
	-- Add the parameters for the stored procedure here
	@interest_id int,
	@lang_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT rel_interest_lang.name FROM rel_interest_lang WHERE interest_id = @interest_id AND lang_id = @lang_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_interest_add_by_id]    Script Date: 06/16/2007 19:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_interest_add_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@interest_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (SELECT COUNT(*) FROM rel_user_interest WHERE user_id = @user_id AND interest_id = @interest_id) = 0
		INSERT INTO rel_user_interest (user_id, interest_id) VALUES (@user_id, @interest_id)
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_interest_delete_by_id]    Script Date: 06/16/2007 19:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_interest_delete_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@interest_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM rel_user_interest WHERE user_id = @user_id AND interest_id = @interest_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_interest_list_by_id]    Script Date: 06/16/2007 19:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_interest_list_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT obj_interest.id, obj_interest.parent_id FROM obj_interest INNER JOIN rel_user_interest ON obj_interest.id = rel_user_interest.interest_id
		WHERE rel_user_interest.user_id = @user_id
END
GO
/****** Object:  UserDefinedFunction [dbo].[omni_user_intro_simil]    Script Date: 06/16/2007 19:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[omni_user_intro_simil] 
(
	-- Add the parameters for the function here
	@id int,
	@user_id int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result int

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = (SELECT COUNT(*) FROM rel_user_interest AS ta INNER JOIN rel_user_interest AS tb on ta.interest_id = tb.interest_id WHERE ta.user_id = @id AND tb.user_id = @user_id)


	-- Return the result of the function
	RETURN @Result

END
GO
/****** Object:  StoredProcedure [dbo].[omni_interest_list]    Script Date: 06/16/2007 19:14:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_interest_list]
	@parent_id int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @parent_id = -1
		SELECT id, parent_id FROM obj_interest
	ELSE
		SELECT id, parent_id FROM obj_interest WHERE parent_id = @parent_id
END
GO
/****** Object:  StoredProcedure [dbo].[omni_user_intro_by_id]    Script Date: 06/16/2007 19:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_intro_by_id]
	-- Add the parameters for the stored procedure here
	@id int,
	@lang_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @interests int
	SELECT @interests = (SELECT COUNT(*) FROM rel_user_interest WHERE user_id = @id)

	SELECT obj_user.id, obj_user.username, obj_user.name, obj_user.email, obj_user.description, obj_user.reg_date, obj_user.log_date, rel_user_lang.self_rating, rel_user_lang.net_rating, (cast(dbo.omni_user_intro_simil(@id, rel_user_lang.user_id) AS float)/cast(@interests AS float)) AS simil
	FROM rel_user_lang INNER JOIN obj_user ON obj_user.id = rel_user_lang.user_id
	WHERE rel_user_lang.user_id<>@id
	AND (SELECT COUNT(*) FROM rel_user_user WHERE user_id=@id AND favor_user_id = rel_user_lang.user_id) < 1
	AND rel_user_lang.lang_id = @lang_id ORDER BY (dbo.omni_user_intro_simil(@id, rel_user_lang.user_id)) DESC, rel_user_lang.self_rating DESC
END
GO
