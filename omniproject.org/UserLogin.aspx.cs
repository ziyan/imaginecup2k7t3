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

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool authed = Common.IsUserLoggedIn();
        if (authed)
        {
            loginPanel.Visible = false;
            alreadyLoggedInLabel.Visible = true;
        }
        else
        {
            loginPanel.Visible = true;
            alreadyLoggedInLabel.Visible = false;
        }
    }
    protected void loginButton_Click(object sender, EventArgs e)
    {
        errorLabel.Visible = false;

        Object user = null;
        String username = usernameTB.Text;
        String password = passwordTB.Text;
        String md5password = Omni.Web.Common.GetMD5Hash(password);
        try
        {
            user = Omni.Web.Common.GetWebService().UserAuthorizeByUsername(username, md5password);
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            Exception ex2 = ex.InnerException;
            if (ex2 is InvalidOperationException)
            {
                alreadyLoggedInLabel.Visible = true;

            }
            //errorLabel.Text += ex.Message + "\n" + ex.StackTrace;
        }
        if (user != null)
        {
            Server.Transfer("~/Default.aspx", false);
        }
        else errorLabel.Visible = true;
    }
}
