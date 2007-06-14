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

        User currentUser = Common.GetCurrentUser();
        if (currentUser == null) return;

        string introduceCountString = Request.QueryString["introduceCount"];
        int introduceCount = 0;
        if (introduceCountString != null)
        {
            introduceCount = Convert.ToInt32(introduceCountString);
        }
        introduceCountText.Text = introduceCount.ToString();

        User[] introduceUsers = Common.GetWebService().UserIntroduce(
                currentUser.id, introduceCount);
        foreach (User introduceUser in introduceUsers)
        {
            HyperLink newLink = new HyperLink();
            newLink.Text = introduceUser.name;
            newLink.NavigateUrl = "~/ViewUser.aspx?id=" + introduceUser.id;
            TableCell newCell = new TableCell();
            newCell.Controls.Add(newLink);
            TableRow newRoll = new TableRow();
            newRoll.Cells.Add(newCell);
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
        Response.Redirect(Request.Url.ToString() + "?introduceCount=" + 
                introduceCountText.Text);
    }
}
