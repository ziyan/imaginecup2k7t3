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

public partial class HallOfFame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        User currentUser = Common.GetCurrentUser();

        // do quantities first
        UserRankQuantity[] oneDayUsers = Common.GetWebService().UserRankByQuantity(1, 10);
        FillTable(oneDayUsers, oneDayTable, currentUser);
        UserRankQuantity[] sevenDayUsers = Common.GetWebService().UserRankByQuantity(7, 10);
        FillTable(sevenDayUsers, sevenDayTable, currentUser);
        UserRankQuantity[] allTimeUsers = Common.GetWebService().UserRankByQuantity(30, 10);
        FillTable(allTimeUsers, allTimeTable, currentUser);

        Language[] languages = Common.GetWebService().LanguageList();
        foreach (Language language in languages)
        {
            //Common.GetWebService().UserRankByRating(lan
            //Common.GetWebService().UserRankByQuantity(0
        }
    }

    private void FillTable(UserRankQuantity[] users, Table table, User currentUser)
    {
        int count = 0;
        foreach (UserRankQuantity user in users)
        {
            TableCell usernameCell = new TableCell();
            TableCell displayNameCell = new TableCell();
            if (currentUser == null)
            {
                Label usernameLabel = new Label();
                usernameLabel.Text = user.user.username;
                usernameCell.Controls.Add(usernameLabel);

                Label displayNameLabel = new Label();
                displayNameLabel.Text = user.user.name;
                displayNameCell.Controls.Add(displayNameLabel);
            }
            else
            {
                HyperLink usernameLink = new HyperLink();
                usernameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + user.user.id;
                usernameLink.Text = user.user.username;
                usernameCell.Controls.Add(usernameLink);

                HyperLink displayNameLink = new HyperLink();
                displayNameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + user.user.id;
                usernameLink.Text = user.user.name;
                displayNameCell.Controls.Add(displayNameLink);
            }

            Label quantityLabel = new Label();
            quantityLabel.Text = user.quantity.ToString();
            TableCell quantityCell = new TableCell();
            quantityCell.Controls.Add(quantityLabel);

            TableRow newRoll = new TableRow();
            newRoll.Cells.Add(usernameCell);
            newRoll.Cells.Add(displayNameCell);
            newRoll.Cells.Add(quantityCell);
            newRoll.CssClass = "row" + ((count % 2) + 1).ToString();
            table.Rows.Add(newRoll);

            count++;
        }
    }
}
