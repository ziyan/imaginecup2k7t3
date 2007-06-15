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

public partial class MyFavorites : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        WebSiteCommon.setLoginView(notAuthorizedControl, userPanel);

        User currentUser = Common.GetCurrentUser();
        if (currentUser == null) return;

        User[] favorites = Common.GetWebService().UserFavorUserListById(currentUser.id);
        int count = 0;
        foreach (User favorite in favorites)
        {
            HyperLink usernameLink = new HyperLink();
            usernameLink.Text = favorite.username;
            usernameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + favorite.id.ToString();
            TableCell usernameCell = new TableCell();
            usernameCell.Controls.Add(usernameLink);

            HyperLink nameLink = new HyperLink();
            nameLink.Text = favorite.name;
            nameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + favorite.id.ToString();
            TableCell nameCell = new TableCell();
            nameCell.Controls.Add(nameLink);

            TableRow newRow = new TableRow();
            newRow.Cells.Add(usernameCell);
            newRow.Cells.Add(nameCell);
            newRow.CssClass = "row" + ((count % 2) + 1).ToString();
            favoritesTable.Rows.Add(newRow);

            count++;
        }
    }
}
