using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Omni.Web;
using Omni.Web.org.omniproject;

public partial class ComposeMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(NotAuthedControl1, userPanel);

        if (userPanel.Visible)
        {
            int curUserId = Common.GetCurrentUser().id;

            String idStr = Request.QueryString["id"];
            if (idStr != null && idStr.Length > 0)
            {
                int intId = Convert.ToInt32(idStr);
                Message msg = Common.GetWebService().MessageGetById(intId);
                if (msg.dst_id == curUserId || msg.src_id == curUserId)
                {
                    int userid = msg.src_id;
                    String un = Common.GetWebService().UserGetById(userid).username;
                    toTB.Text = un;
                    String title = msg.subject;
                    if (!title.StartsWith("Re: "))
                        title = "Re: " + title;
                    subjectTB.Text = title;
                }
            }
            else
            {
                String idStr2 = Request.QueryString["ans_id"];
                if (idStr2 != null && idStr2.Length > 0)
                {
                    int intId = Convert.ToInt32(idStr2);
                    Translation t = Common.GetWebService().TransGetByAnsId(intId);
                    //int userid = msg.src_id;
                    //String un = Common.GetWebService().UserGetById(userid).username;
                    //toTB.Text = un;
                    subjectTB.Text = t.subject;
                    messageTB.Text = t.trans_body;
                }
                else
                {
                    String idStr3 = Request.QueryString["req_id"];
                    if (idStr3 != null && idStr3.Length > 0)
                    {
                        int intId = Convert.ToInt32(idStr3);
                        //Translation t = Common.GetWebService().TransGetByReqId(intId);
                        //int userid = msg.src_id;
                        //String un = Common.GetWebService().UserGetById(userid).username;
                        //toTB.Text = un;
                        //subjectTB.Text = t.subject;
                        //messageTB.Text = t.orig_body;
                    }
                }
            }

            if (!IsPostBack)
            {
                String userIdStr = Request.QueryString["user_id"];
                if (userIdStr != null && userIdStr.Length > 0)
                {
                    int intId = Convert.ToInt32(userIdStr);
                    User u = Common.GetWebService().UserGetById(intId);
                    if (u != null)
                    {
                        toTB.Text = u.username;
                    }
                }
            }

            User user = Common.GetCurrentUser();
            User[] favorites = Common.GetWebService().UserFavorUserListById(user.id);
            if (favorites.Length == 0)
            {
                toDDL.Visible = false;
            }
            else
            {
                if (toDDL.SelectedIndex == 0)
                {
                    for (int i = toDDL.Items.Count -1 ; i>0; i--)
                        toDDL.Items.RemoveAt(i);
                    for (int i = 0; i < favorites.Length; i++)
                    {
                        String favUsername = favorites[i].username;
                        toDDL.Items.Add(new ListItem(favUsername, favUsername));
                    }
                }
            }
        }
    }
    protected void sendButton_Click(object sender, EventArgs e)
    {
        User user = Common.GetCurrentUser();
        int userid = Common.GetWebService().UserIdGetByUsername(toTB.Text);

        bool pendingTrans = ((Button)sender).ID.Equals("requestTransButton");

        bool error = false;
        int msgId = -1;
        try
        {
            msgId = Common.GetWebService().MessageSend(user.id, userid, MessageDestinationType.User, subjectTB.Text, messageTB.Text, pendingTrans, 0);
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            Exception ie = ex.InnerException;
            if (ie is ArgumentNullException || ex.Message.Contains("ArgumentNullException"))
            {
                missingSubjectLabel.Visible = true;
                invalidUsernameLabel.Visible = false;
            }
            if (ie is ArgumentOutOfRangeException || ex.Message.Contains("ArgumentOutOfRangeException"))
            {
                invalidUsernameLabel.Visible = true;
                missingSubjectLabel.Visible = false;
            }
            error = true;
        }
        if (!error)
        {
            missingSubjectLabel.Visible = false;
            invalidUsernameLabel.Visible = false;

            if (pendingTrans)
            {
                Response.Redirect("RequestTranslation.aspx?msg_pending_id=" + msgId);
            }
            else
            {
                Response.Redirect("MyMessages.aspx");
            }
        }
    }
    protected void toDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (toDDL.SelectedIndex > 0)
        {
            toTB.Text = toDDL.SelectedValue;
            toTB.Enabled = false;
        }
        else toTB.Enabled = true;

    }
}
