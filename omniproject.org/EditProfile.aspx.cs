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

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);
        if (usernameValueLabel.Text.Length == 0)
        {
            User currentUser = Common.GetCurrentUser();
            if (currentUser != null)
            {
                usernameValueLabel.Text = currentUser.username;
                displayNameText.Text = currentUser.name;
                emailText.Text = currentUser.email;
                descriptionText.Text = currentUser.description;
            }
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);

        User currentUser = Common.GetCurrentUser();
        if (currentUser != null)
        {
            String newEmail = emailText.Text;
            String newDisplayName = displayNameText.Text;
            String newDescription = descriptionText.Text;
            Common.GetWebService().UserUpdateById(currentUser.id, newEmail,
                    newDisplayName, newDescription);
            interestsPicker.SaveInterestsToUser(currentUser.id);
            languagePicker.SaveLanguagesToUser(currentUser.id);

            usernameValueLabel.Text = ""; // used to flag to see if loaded

            Response.Redirect(Request.Url.ToString());
        }
    }

    protected void cancelButton_Click(object sender, EventArgs e)
    {
        usernameValueLabel.Text = ""; // used to flag to see if loaded
        Response.Redirect(Request.Url.ToString());
    }
}
