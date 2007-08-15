
/****** Object:  StoredProcedure [dbo].[omni_interest_list]    Script Date: 08/14/2007 20:49:23 ******/
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
		SELECT * FROM obj_interest ORDER BY obj_interest.name ASC
	ELSE
		SELECT * FROM obj_interest WHERE parent_id = @parent_id  ORDER BY obj_interest.name ASC
END

GO
/****** Object:  StoredProcedure [dbo].[omni_lang_list]    Script Date: 08/14/2007 20:49:25 ******/
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
	ORDER BY code ASC
END

GO
/****** Object:  StoredProcedure [dbo].[omni_message_get_by_id]    Script Date: 08/14/2007 20:49:26 ******/
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
	SELECT id, src_id, dst_id, dst_type, subject, body, date, unread FROM obj_message WHERE id = @msg_id
END



GO
/****** Object:  StoredProcedure [dbo].[omni_message_recv_by_user]    Script Date: 08/14/2007 20:49:27 ******/
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
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, src_id, dst_id, dst_type, subject, date, unread
		FROM obj_message 
		WHERE @user_id = dst_id AND dst_type = 1  ORDER BY date DESC
END


GO
/****** Object:  StoredProcedure [dbo].[omni_message_send]    Script Date: 08/14/2007 20:49:29 ******/
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
	@body ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Dst type is getting set wrong somewhere, too lazy to track it down

    -- Insert statements for procedure here
	INSERT INTO obj_message (src_id, dst_id, dst_type, subject, body, date, unread)
		VALUES ( @src_id, @dst_id, 1, @subject, @body, getdate(), 1)
	SELECT @@IDENTITY
	RETURN @@IDENTITY 
END


GO
/****** Object:  StoredProcedure [dbo].[omni_message_send_user]    Script Date: 08/14/2007 20:49:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_message_send_user]
	-- Add the parameters for the stored procedure here
	@src_id int,
	@dst_id int,
	@dst_type tinyint,
	@subject nvarchar(255),
	@body ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Dst type is getting set wrong somewhere, too lazy to track it down

    -- Insert statements for procedure here
	INSERT INTO obj_message (src_id, dst_id, dst_type, subject, body, date, unread)
		VALUES ( @src_id, @dst_id, 1, @subject, @body, getdate(), 1)
	SELECT @@IDENTITY
	RETURN @@IDENTITY 
END


GO
/****** Object:  StoredProcedure [dbo].[omni_message_sent_by_user]    Script Date: 08/14/2007 20:49:34 ******/
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
	SELECT id, src_id, dst_id, dst_type, subject, date, unread
		FROM obj_message 
		WHERE @user_id = src_id ORDER BY date DESC
END


GO
/****** Object:  StoredProcedure [dbo].[omni_trans_ans_add]    Script Date: 08/14/2007 20:49:35 ******/
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
		
		SELECT 0
		RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[omni_trans_ans_rate_by_id]    Script Date: 08/14/2007 20:49:37 ******/
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
	
	UPDATE obj_user
	SET user_rating = (SELECT SUM(net_rating) FROM rel_user_lang WHERE rel_user_lang.user_id = obj_user.id)
	UPDATE obj_user
	SET user_rating = (SELECT 0) WHERE user_rating IS null

END


GO
/****** Object:  StoredProcedure [dbo].[omni_trans_ans_rate_get_by_id]    Script Date: 08/14/2007 20:49:39 ******/
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
	DECLARE @rating int
	SELECT @rating = 0
	IF (SELECT COUNT(*) FROM rel_trans_ans_rating WHERE user_id = @user_id AND trans_ans_id = @ans_id )>0
		SELECT @rating =  (SELECT rating FROM rel_trans_ans_rating WHERE user_id = @user_id AND trans_ans_id = @ans_id)
    -- Insert statements for procedure here
	SELECT @rating AS rating
END

GO
/****** Object:  StoredProcedure [dbo].[omni_trans_get_app_by_user]    Script Date: 08/14/2007 20:49:40 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_trans_get_by_ans_id]    Script Date: 08/14/2007 20:49:42 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_trans_get_by_req_id]    Script Date: 08/14/2007 20:49:43 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_trans_get_non_unapp_by_user]    Script Date: 08/14/2007 20:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_trans_get_non_unapp_by_user]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
-- For now, only need the main request, not each answer
--	SELECT obj_trans_req.user_id,
-- 		   obj_trans_req.src_lang_id,
-- 		   obj_trans_req.dst_lang_id,
-- 		   obj_trans_req.subject,
-- 		   obj_trans_req.dst_type,
-- 		   obj_trans_req.dst_id,
-- 		   obj_trans_req.date,
-- 		   obj_trans_req.completed,
-- 		   obj_trans_req.msg_id,
-- 		   obj_trans_ans.id AS ans_id,
-- 		   obj_trans_ans.req_id,
-- 		   obj_trans_ans.user_id AS ans_user_id,
-- 		   obj_trans_ans.date AS ans_date
-- 		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
-- 		WHERE obj_trans_req.completed = 0 AND obj_trans_req.user_id = @user_id
-- 		ORDER BY obj_trans_ans.date DESC
	SELECT obj_trans_req.id,
		   obj_trans_req.user_id,
		   obj_trans_req.src_lang_id,
		   obj_trans_req.dst_lang_id,
		   obj_trans_req.subject,
		   obj_trans_req.dst_type,
		   obj_trans_req.dst_id,
		   obj_trans_req.date,
		   obj_trans_req.completed
		FROM obj_trans_req WHERE (obj_trans_req.completed = 1 OR obj_trans_req.id NOT IN
			(SELECT obj_trans_ans.req_id FROM obj_trans_ans))
		AND obj_trans_req.user_id = @user_id
		ORDER BY obj_trans_req.date DESC
END



GO
/****** Object:  StoredProcedure [dbo].[omni_trans_get_pending_by_user]    Script Date: 08/14/2007 20:49:46 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_trans_get_unapp_by_user]    Script Date: 08/14/2007 20:49:47 ******/
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
-- For now, only need the main request, not each answer
--	SELECT obj_trans_req.user_id,
-- 		   obj_trans_req.src_lang_id,
-- 		   obj_trans_req.dst_lang_id,
-- 		   obj_trans_req.subject,
-- 		   obj_trans_req.dst_type,
-- 		   obj_trans_req.dst_id,
-- 		   obj_trans_req.date,
-- 		   obj_trans_req.completed,
-- 		   obj_trans_req.msg_id,
-- 		   obj_trans_ans.id AS ans_id,
-- 		   obj_trans_ans.req_id,
-- 		   obj_trans_ans.user_id AS ans_user_id,
-- 		   obj_trans_ans.date AS ans_date
-- 		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
-- 		WHERE obj_trans_req.completed = 0 AND obj_trans_req.user_id = @user_id
-- 		ORDER BY obj_trans_ans.date DESC
	SELECT DISTINCT obj_trans_req.id,
		   obj_trans_req.user_id,
		   obj_trans_req.src_lang_id,
		   obj_trans_req.dst_lang_id,
		   obj_trans_req.subject,
		   obj_trans_req.dst_type,
		   obj_trans_req.dst_id,
		   obj_trans_req.date,
		   obj_trans_req.completed
		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
		WHERE obj_trans_req.completed = 0 AND obj_trans_req.user_id = @user_id
		ORDER BY obj_trans_req.date DESC
END

GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_add]    Script Date: 08/14/2007 20:49:49 ******/
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
	@dst_type tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO obj_trans_req ( user_id, src_lang_id, dst_lang_id, subject, message, dst_id, dst_type, date, completed)
		VALUES ( @user_id, @src_lang_id, @dst_lang_id, @subject, @message, @dst_id, @dst_type, getdate(), 0)
	SELECT @@IDENTITY
	RETURN @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_close]    Script Date: 08/14/2007 20:49:51 ******/
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
	@user_id int,
	@req_id int,
	@ans_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    IF @user_id IN (SELECT user_id FROM obj_trans_req WHERE id = @req_id) -- Only close own requests
    BEGIN
		UPDATE obj_trans_req SET completed = 1 WHERE id = @req_id
		-- FIXME : Should really store the chosen answer somewhere, it isn't right now
	END
END

GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_find_global_for_user]    Script Date: 08/14/2007 20:49:53 ******/
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
	SELECT obj_trans_req.id, obj_trans_req.src_lang_id, obj_trans_req.dst_lang_id, obj_trans_req.subject, obj_trans_req.dst_type, obj_trans_req.dst_id, obj_trans_req.date, obj_trans_req.user_id , obj_trans_req.completed
		FROM obj_trans_req INNER JOIN rel_user_lang AS src_user_lang ON obj_trans_req.src_lang_id = src_user_lang.lang_id INNER JOIN rel_user_lang AS dst_user_lang ON obj_trans_req.dst_lang_id = dst_user_lang.lang_id
		WHERE obj_trans_req.completed = 0 AND dst_type = 0 AND src_user_lang.user_id = @user_id AND dst_user_lang.user_id = @user_id AND obj_trans_req.user_id != @user_id
		AND (SELECT COUNT(*) FROM obj_trans_ans WHERE req_id = obj_trans_req.id AND user_id = @user_id) = 0
		ORDER BY obj_trans_req.date DESC
END


GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_get_by_id]    Script Date: 08/14/2007 20:49:55 ******/
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
	SELECT * FROM obj_trans_req
		WHERE id = @req_id
END

GO
/****** Object:  StoredProcedure [dbo].[omni_trans_req_get_for_user]    Script Date: 08/14/2007 20:49:56 ******/
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
	SELECT * FROM obj_trans_req
		WHERE dst_id = @user_id AND dst_type = 1 AND completed = 0
	ORDER BY date DESC
END


GO
/****** Object:  StoredProcedure [dbo].[omni_trans_search]    Script Date: 08/14/2007 20:49:57 ******/
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

	SELECT DISTINCT obj_trans_req.id, obj_trans_req.src_lang_id, obj_trans_req.dst_lang_id, obj_trans_req.subject, obj_trans_req.date
		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
		WHERE ((@src_lang_id = obj_trans_req.src_lang_id AND @dst_lang_id = obj_trans_req.dst_lang_id ) OR
			   (@src_lang_id = obj_trans_req.dst_lang_id AND @dst_lang_id = obj_trans_req.src_lang_id )) AND
			   (obj_trans_req.subject LIKE @keyword OR obj_trans_req.message LIKE @keyword OR obj_trans_ans.message LIKE @keyword)
		ORDER BY obj_trans_req.date DESC
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_authorize_by_username]    Script Date: 08/14/2007 20:49:59 ******/
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
	@username varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,username,[name],email,[description],[sn_network],[sn_screenname],user_rating,reg_date,log_date FROM obj_user WHERE username = @username
	UPDATE obj_user SET log_date = getdate() WHERE username = @username
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_favor_check_pair]    Script Date: 08/14/2007 20:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[omni_user_favor_check_pair] 
	@user_id int,
	@favor_user_id int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM rel_user_user WHERE @user_id = rel_user_user.user_id AND @favor_user_id = rel_user_user.favor_user_id; 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[omni_user_favor_user_add_by_id]    Script Date: 08/14/2007 20:50:02 ******/
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
	BEGIN
		SELECT 0
		RETURN 0
	END
	INSERT INTO rel_user_user (user_id, favor_user_id) VALUES (@user_id, @favor_user_id)
	SELECT 1
	RETURN 1

END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_favor_user_delete_by_id]    Script Date: 08/14/2007 20:50:03 ******/
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
    IF (SELECT COUNT(*) FROM rel_user_user WHERE user_id = @user_id AND favor_user_id = @favor_user_id)<=0
	BEGIN
		SELECT 0
		RETURN 0
	END
	DELETE FROM rel_user_user WHERE user_id = @user_id AND favor_user_id = @favor_user_id
	SELECT 1
	RETURN 1
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_favor_user_list_by_id]    Script Date: 08/14/2007 20:50:05 ******/
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
	SELECT obj_user.id, obj_user.username, obj_user.name, obj_user.email, obj_user.description, obj_user.reg_date, obj_user.sn_network, obj_user.sn_screenname, obj_user.user_rating
	FROM rel_user_user INNER JOIN obj_user ON rel_user_user.favor_user_id = obj_user.id
	WHERE rel_user_user.user_id = @user_id
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_get_by_id]    Script Date: 08/14/2007 20:50:06 ******/
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
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, email, username, [name], [description], [sn_network], [sn_screenname], user_rating, reg_date FROM obj_user WHERE id = @user_id
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_get_summary]    Script Date: 08/14/2007 20:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_get_summary] 
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @has_updated_profile int
	DECLARE @unread_msgs int
	DECLARE @open_personal_trans_req int
	DECLARE @trans_req_to_approve int
	DECLARE @open_global_trans_req int
	
	
	SELECT @has_updated_profile = 0
	IF (SELECT COUNT(*) FROM rel_user_interest WHERE user_id = @user_id) > 0 AND (SELECT COUNT(*) FROM rel_user_interest WHERE user_id = @user_id) > 0
	BEGIN
		SELECT @has_updated_profile = 1
	END
	
	SELECT @unread_msgs = (SELECT COUNT(*)
		FROM obj_message 
		WHERE @user_id = dst_id AND dst_type = 1 AND unread = 1)
		
	SELECT @open_personal_trans_req = (SELECT COUNT(*) FROM obj_trans_req
		WHERE dst_id = @user_id AND dst_type = 1 AND completed = 0)
		
	SELECT @trans_req_to_approve = (SELECT COUNT(*) FROM obj_trans_req WHERE id IN (SELECT DISTINCT (obj_trans_req.id)
		FROM obj_trans_req INNER JOIN obj_trans_ans ON obj_trans_req.id = obj_trans_ans.req_id
		WHERE obj_trans_req.completed = 0 AND obj_trans_req.user_id = @user_id))
		
	SELECT @open_global_trans_req = (SELECT COUNT(*) FROM obj_trans_req WHERE id IN (SELECT DISTINCT (obj_trans_req.id)
		FROM obj_trans_req INNER JOIN rel_user_lang AS src_user_lang ON obj_trans_req.src_lang_id = src_user_lang.lang_id INNER JOIN rel_user_lang AS dst_user_lang ON obj_trans_req.dst_lang_id = dst_user_lang.lang_id
		WHERE obj_trans_req.completed = 0 AND dst_type = 0 AND src_user_lang.user_id = @user_id AND dst_user_lang.user_id = @user_id AND obj_trans_req.user_id != @user_id
		AND (SELECT COUNT(*) FROM obj_trans_ans WHERE req_id = obj_trans_req.id AND user_id = @user_id) = 0))

	SELECT @has_updated_profile AS has_updated_profile, @unread_msgs AS unread_msgs, @open_personal_trans_req AS open_personal_trans_req, @trans_req_to_approve AS trans_req_to_approve, @open_global_trans_req AS open_global_trans_req
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_id_get_by_username]    Script Date: 08/14/2007 20:50:09 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_user_interest_add_by_id]    Script Date: 08/14/2007 20:50:10 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_user_interest_delete_all]    Script Date: 08/14/2007 20:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_interest_delete_all]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM rel_user_interest WHERE user_id = @user_id
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_interest_delete_by_id]    Script Date: 08/14/2007 20:50:13 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_user_interest_list_by_id]    Script Date: 08/14/2007 20:50:15 ******/
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

    SELECT obj_interest.id, obj_interest.parent_id, obj_interest.name FROM obj_interest INNER JOIN rel_user_interest ON obj_interest.id = rel_user_interest.interest_id
		WHERE rel_user_interest.user_id = @user_id
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_intro_by_id]    Script Date: 08/14/2007 20:50:16 ******/
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

	SELECT obj_user.id, obj_user.username, obj_user.name, obj_user.email, obj_user.description, obj_user.user_rating, obj_user.reg_date, obj_user.sn_network, obj_user.sn_screenname, rel_user_lang.self_rating, rel_user_lang.net_rating, (cast(dbo.omni_user_intro_simil(@id, rel_user_lang.user_id) AS float)/cast(@interests AS float)) AS simil
	FROM rel_user_lang INNER JOIN obj_user ON obj_user.id = rel_user_lang.user_id
	WHERE rel_user_lang.user_id<>@id
	AND (SELECT COUNT(*) FROM rel_user_user WHERE user_id=@id AND favor_user_id = rel_user_lang.user_id) < 1
	AND rel_user_lang.lang_id = @lang_id ORDER BY (dbo.omni_user_intro_simil(@id, rel_user_lang.user_id)) DESC, rel_user_lang.self_rating DESC
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_lang_delete_all]    Script Date: 08/14/2007 20:50:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_lang_delete_all] 
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM rel_user_lang WHERE user_id = @user_id
	
	UPDATE obj_user
	SET user_rating = (SELECT 0) where id = @user_id
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_lang_delete_by_id]    Script Date: 08/14/2007 20:50:19 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_user_lang_list_by_id]    Script Date: 08/14/2007 20:50:20 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_user_lang_set_by_id]    Script Date: 08/14/2007 20:50:21 ******/
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
		INSERT INTO rel_user_lang (user_id, lang_id, self_rating, net_rating) VALUES (@user_id, @lang_id, @self_rating, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_password_get_by_id]    Script Date: 08/14/2007 20:50:23 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_user_password_get_by_username]    Script Date: 08/14/2007 20:50:24 ******/
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
	@username varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT obj_user.password FROM obj_user WHERE obj_user.username = @username
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_password_update_by_id]    Script Date: 08/14/2007 20:50:26 ******/
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
/****** Object:  StoredProcedure [dbo].[omni_user_rank_by_quantity]    Script Date: 08/14/2007 20:50:27 ******/
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
	SELECT TOP 100 id, username, name, email, description, sn_network, sn_screenname, reg_date, log_date, user_rating, (SELECT count(*) FROM obj_trans_ans WHERE obj_trans_ans.user_id = obj_user.id AND obj_trans_ans.date >= getdate() - @interval) AS quantity
	FROM obj_user ORDER BY (SELECT count(*) FROM obj_trans_ans WHERE obj_trans_ans.user_id = obj_user.id AND obj_trans_ans.date >= getdate() - @interval) DESC, username ASC
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_rank_by_rating]    Script Date: 08/14/2007 20:50:29 ******/
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
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 100 id, username, name, email, description, sn_network, sn_screenname, reg_date, log_date, user_rating
	FROM obj_user
	--WHERE rel_user_lang.lang_id = @lang_id OR @lang_id = 0
	ORDER BY user_rating DESC, reg_date ASC
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_register]    Script Date: 08/14/2007 20:50:30 ******/
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
	@username varchar(50),
	@password varchar(42),
	@email varchar(255),
	@name nvarchar(100)
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

	IF (SELECT COUNT(*) FROM obj_user WHERE obj_user.email = @email) >= 1
	BEGIN
		SELECT -2
		RETURN -2
	END	

    -- Insert statements for procedure here
	INSERT INTO obj_user (obj_user.username,obj_user.password,obj_user.email,obj_user.name,obj_user.reg_date,obj_user.user_rating)
		VALUES (@username, @password, @email, @name, getdate(), 0)
	SELECT @@IDENTITY
	RETURN @@IDENTITY
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_search]    Script Date: 08/14/2007 20:50:32 ******/
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
	SELECT id, username, [name], email, description, reg_date, sn_network, sn_screenname, user_rating FROM obj_user
	WHERE username like @keyword OR [name] like @keyword OR email like @keyword OR description like @keyword OR sn_screenname LIKE @keyword
	ORDER BY username ASC
END


GO
/****** Object:  StoredProcedure [dbo].[omni_user_update_by_id]    Script Date: 08/14/2007 20:50:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	0 for success, -1 for duplicate email
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_update_by_id]
-- Add the parameters for the stored procedure here
	@id int,
	@email varchar(255),
	@name nvarchar(100),
	@description ntext,
	@sn_network nvarchar(100),
	@sn_screenname nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- No duplicate emails, unless this user has it
	IF (SELECT COUNT(*) FROM obj_user WHERE obj_user.email = @email AND obj_user.id <> @id) >= 1
	BEGIN
		SELECT -1
		RETURN -1
	END		
	
	UPDATE obj_user SET	obj_user.email = @email,
						obj_user.name = @name,
						obj_user.description = @description,
						obj_user.sn_network = @sn_network,
						obj_user.sn_screenname = @sn_screenname
		WHERE id = @id
	SELECT 0
	RETURN 0	
				
END

GO
/****** Object:  StoredProcedure [dbo].[omni_user_username_get_by_id]    Script Date: 08/14/2007 20:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[omni_user_username_get_by_id]
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT username FROM obj_user WHERE id = @user_id
END

































/****** Object:  UserDefinedFunction [dbo].[omni_user_intro_simil]    Script Date: 08/14/2007 20:52:52 ******/
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
