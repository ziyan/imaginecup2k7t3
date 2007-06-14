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
        foreach (User favorite in favorites)
        {
            HyperLink newLink = new HyperLink();
            newLink.Text = favorite.name;
            newLink.NavigateUrl = "~/ViewProfile.aspx?id=" + favorite.id.ToString();
            TableCell newCell = new TableCell();
            newCell.Controls.Add(newLink);
            TableRow newRow = new TableRow();
            newRow.Cells.Add(newCell);
            favoritesTable.Rows.Add(newRow);
        }
    }
}
