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

public partial class MyMessages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(NotAuthedControl1, userPanel);

        if (userPanel.Visible)
        {
            populateMessages();
        }
    }

    private void populateMessages()
    {
        User user = Common.GetCurrentUser();
        Message[] msgs = Common.GetWebService().MessageRecvByUser(user.id, MessageDestinationType.User);
        throw new Exception("Length: " + msgs.Length);
    }
    protected void composeMsgLabel_Click(object sender, EventArgs e)
    {
        Server.Transfer("ComposeMessage.aspx");
    }
}
