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

public partial class OmniMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool loggedIn = false;
        Omni.Web.org.omniproject.User user = Omni.Web.Common.GetWebService().UserCurrent();
        if (user != null)
        {
            Label username = (Label)userView.FindControl("usernameLabel2");
            username.Text = user.username;
            loggedIn = true;
        }

        if (loggedIn)
        {
            loginViewTop.ActiveViewIndex = 1;
            userNavLinkPanel.Visible = true;
        }
        else
        {
            loginViewTop.ActiveViewIndex = 0;
            userNavLinkPanel.Visible = false;
        }
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        Omni.Web.Common.GetWebService().UserLogout();
        Server.Transfer("~/Default.aspx");
    }
}
