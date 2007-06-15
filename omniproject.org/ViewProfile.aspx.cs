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

public partial class ViewProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);

        string idString = Request.QueryString["id"];
        if (idString == null) return;

        int preferredLanguage = Common.GetPreferredLanguage();
        if (preferredLanguage <= 0) return;

        int userId = Convert.ToInt32(idString);
        User user = Common.GetWebService().UserGetById(userId);

        profileLabel.Text = user.username;
        profileEndingLabel.Visible = true;
        displayNameText.Text = user.name;
        emailText.Text = user.email;
        descriptionText.Text = user.description;

        UserLanguage[] languages = Common.GetWebService().UserLanguageListById(user.id);
        if (languages.Length == 0)
        {
            languagesTable.Visible = false;
            languagesNoneMessage.Visible = true;
        }
        int count = 0;
        foreach (UserLanguage language in languages)
        {
            string languageString = Common.GetWebService().LanguageNameQueryById(
                    language.lang_id, preferredLanguage);
            Label newLanguageLabel = new Label();
            newLanguageLabel.Text = languageString;
            TableCell newLanguageCell = new TableCell();
            newLanguageCell.Controls.Add(newLanguageLabel);

            Label newUserRatingLabel = new Label();
            newUserRatingLabel.Text = language.self_rating.ToString();
            TableCell newUserRatingCell = new TableCell();
            newUserRatingCell.Controls.Add(newUserRatingLabel);

            Label newSystemRatingLabel = new Label();
            newSystemRatingLabel.Text = language.net_rating.ToString();
            TableCell newSystemRatingCell = new TableCell();
            newSystemRatingCell.Controls.Add(newSystemRatingLabel);

            TableRow newRoll = new TableRow();
            newRoll.Cells.Add(newLanguageCell);
            newRoll.Cells.Add(newUserRatingCell);
            newRoll.Cells.Add(newSystemRatingCell);
            newRoll.CssClass = "row" + ((count % 2) + 1).ToString();

            languagesTable.Rows.Add(newRoll);
            count++;
        }

        Interest[] interests = Common.GetWebService().UserInterestList(user.id);
        if (interests.Length == 0)
        {
            interestsTable.Visible = false;
            interestsNoneMessage.Visible = true;
        }
        count = 0;
        foreach (Interest interest in interests)
        {
            string interestString = Common.GetWebService().InterestNameQueryById(
                    interest.id, preferredLanguage);
            Label newInterestLabel = new Label();
            newInterestLabel.Text = interestString;
            TableCell newInterestCell = new TableCell();
            newInterestCell.Controls.Add(newInterestLabel);

            TableRow newRoll = new TableRow();
            newRoll.Cells.Add(newInterestCell);
            newRoll.CssClass = "row" + ((count % 2) + 1).ToString();
            interestsTable.Rows.Add(newRoll);

            count++;
        }

        User currentUser = Common.GetCurrentUser();
        if (currentUser == null)
        {
            // should not happen, but if it does, nothing else we can do
            removeFavorite.Visible = false;
            addFavorite.Visible = false;
            return;
        }

        User[] favorites = Common.GetWebService().UserFavorUserListById(currentUser.id);
        bool found = false;
        foreach (User favorite in favorites)
        {
            if (favorite.id == userId)
            {
                found = true;
                break;
            }
        }
        if (currentUser.id == userId)
        {
            removeFavorite.Visible = false;
            addFavorite.Visible = false;
        }
        else if (found)
        {
            removeFavorite.Visible = true;
            addFavorite.Visible = false;
        }
        else
        {
            removeFavorite.Visible = false;
            addFavorite.Visible = true;
        }
    }

    protected void addFavorite_Click(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);

        User currentUser = Common.GetCurrentUser();
        if (currentUser != null)
        {
            string idString = Request.QueryString["id"];
            if (idString != null)
            {
                int userId = Convert.ToInt32(idString);
                Common.GetWebService().UserFavorUserAddById(currentUser.id, userId);
            }
        }
        Response.Redirect("~/MyFavorites.aspx");
    }

    protected void removeFavorite_Click(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);

        User currentUser = Common.GetCurrentUser();
        if (currentUser != null)
        {
            string idString = Request.QueryString["id"];
            if (idString != null)
            {
                int userId = Convert.ToInt32(idString);
                Common.GetWebService().UserFavorUserDeleteById(currentUser.id, userId);
            }
        }
        Response.Redirect("~/MyFavorites.aspx");
    }

    protected void sendMessage_Click(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);

        User currentUser = Common.GetCurrentUser();
        if (currentUser != null)
        {
            string userIdString = Request.QueryString["id"];
            if (userIdString != null)
            {
                try
                {
                    int userId = Convert.ToInt32(userIdString);
                    Response.Redirect("~/ComposeMessage.aspx?user_id=" + 
                            userId.ToString());
                }
                catch (Exception)
                {
                }
            }
        }
        Response.Redirect(Request.Url.ToString());
    }
}
