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

public partial class SearchUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);

        searchUserTable.Visible = false;
        searchUserNoneMessage.Visible = false;

        User currentUser = Common.GetCurrentUser();
        if (currentUser == null) return; // should not happen

        string searchString = Request.QueryString["search"];
        if (searchString == null) return;

        if (searchString.Length == 0)
        {
            searchUserNoneMessage.Visible = true;
            return;
        }

        User[] users = Common.GetWebService().UserSearch(searchString);
        if (users.Length == 0)
        {
            searchUserNoneMessage.Visible = true;
            return;
        }

        searchUserTable.Visible = true;
        int count = 0;
        foreach (User user in users)
        {
            Label usernameLabel = new Label();
            usernameLabel.Text = user.username;
            HyperLink usernameLink = new HyperLink();
            usernameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + user.id;
            usernameLink.Controls.Add(usernameLabel);
            TableCell usernameCell = new TableCell();
            usernameCell.Controls.Add(usernameLink);

            Label nameLabel = new Label();
            nameLabel.Text = user.name;
            HyperLink nameLink = new HyperLink();
            nameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + user.id;
            nameLink.Controls.Add(nameLabel);
            TableCell nameCell = new TableCell();
            nameCell.Controls.Add(nameLink);

            TableRow newRoll = new TableRow();
            newRoll.Cells.Add(usernameCell);
            newRoll.Cells.Add(nameCell);
            newRoll.CssClass = "row" + ((count % 2) + 1).ToString();

            searchUserTable.Rows.Add(newRoll);

            count++;
        }
    }

    protected void searchUserButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SearchUser.aspx?search=" + searchUserText.Text);
    }
}
