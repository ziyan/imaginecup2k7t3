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

public partial class Introduce : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);
        introduceTable.Visible = false; // we'll make visible if needed
        introduceNoneMessage.Visible = false; // we'll make visible if needed

        User currentUser = Common.GetCurrentUser();
        if (currentUser == null) return;

        int preferredLanguageId = Common.GetPreferredLanguage();
        if (preferredLanguageId <= 0) return; // should not happen

        UserLanguage[] languages = 
                Common.GetWebService().UserLanguageListById(currentUser.id);
        foreach (UserLanguage language in languages)
        {
            string languageString = Common.GetWebService().LanguageNameQueryById(
                    language.lang_id, preferredLanguageId);
            ListItem item = new ListItem(languageString, language.lang_id.ToString());
            introduceLanguageDropDown.Items.Add(item);
        }

        string introduceCountString = Request.QueryString["introduceCount"];
        int introduceCount = 0;
        if (introduceCountString != null)
        {
            introduceCount = Convert.ToInt32(introduceCountString);
        }
        introduceCountText.Text = introduceCount.ToString();
        if (introduceCount == 0)
        {
            introduceCountText.Text = "10";
            return; // save a call to the webservice
        }

        string introduceLanguageString = Request.QueryString["introduceLanguage"];
        if (introduceLanguageString == null) return; // save a call to the webservice

        int introduceLanguageId = Convert.ToInt32(introduceLanguageString);
        UserSimil[] introduceUsers = Common.GetWebService().UserIntroById(
                currentUser.id, introduceLanguageId, introduceCount);
        if (introduceUsers.Length == 0)
        {
            introduceNoneMessage.Visible = true;
        }
        else
        {
            introduceTable.Visible = true;
        }
        foreach (UserSimil introduceUser in introduceUsers)
        {
            HyperLink newLink = new HyperLink();
            newLink.Text = introduceUser.user.name;
            newLink.NavigateUrl = "~/ViewProfile.aspx?id=" + introduceUser.user.id;
            TableCell newUsernameCell = new TableCell();
            newUsernameCell.Controls.Add(newLink);

            Label newUserRatingLabel = new Label();
            newUserRatingLabel.Text = introduceUser.self_rating.ToString();
            TableCell newUserRatingCell = new TableCell();
            newUserRatingCell.Controls.Add(newUserRatingLabel);

            Label newSystemRatingLabel = new Label();
            newSystemRatingLabel.Text = introduceUser.net_rating.ToString();
            TableCell newSystemRatingCell = new TableCell();
            newSystemRatingCell.Controls.Add(newSystemRatingLabel);

            Label newSimilarityLabel = new Label();
            double similarityRating = introduceUser.simil*100;
            newSimilarityLabel.Text = similarityRating.ToString("0.00");
            TableCell newSimilarityCell = new TableCell();
            newSimilarityCell.Controls.Add(newSimilarityLabel);

            TableRow newRoll = new TableRow();
            newRoll.Cells.Add(newUsernameCell);
            newRoll.Cells.Add(newUserRatingCell);
            newRoll.Cells.Add(newSystemRatingCell);
            newRoll.Cells.Add(newSimilarityCell);
            introduceTable.Rows.Add(newRoll);
        }
    }

    protected void introduceButton_Click(object sender, EventArgs e)
    {
        int introduceCount;
        try
        {
            introduceCount = Convert.ToInt32(introduceCountText.Text);
        }
        catch (Exception)
        {
            introduceCount = 0; // fail silently
        }
        
        ListItem languageItem = 
                introduceLanguageDropDown.Items[introduceLanguageDropDown.SelectedIndex];
        Response.Redirect("~/Introduce.aspx?introduceCount=" + 
                introduceCountText.Text + "&introduceLanguage=" + 
                Convert.ToInt32(languageItem.Value));
    }
}
