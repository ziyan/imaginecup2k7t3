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

        }
    }
    protected void sendButton_Click(object sender, EventArgs e)
    {
        User user = Common.GetCurrentUser();
        int userid = Common.GetWebService().UserIdGetByUsername(toTB.Text);
        Common.GetWebService().MessageSend(user.id, userid, MessageDestinationType.User, subjectTB.Text, messageTB.Text,false,0);
        Server.Transfer("MyMessages.aspx");
    }
}
