using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Common methods for .aspx.cs code-behind
/// </summary>
public class WebSiteCommon
{
    public static void setLoginView(Control guest, Control user)
    {
        bool authed = Omni.Web.Common.GetWebService().UserIsLoggedIn();
        if (authed)
        {
            guest.Visible = false;
            user.Visible = true;
        }
        else
        {
            guest.Visible = true;
            user.Visible = false;
        }
    }
}
