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
    private struct HallOfFameUser
    {
        public int id;
        public string username;
        public string name;
        public string property;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        User currentUser = Common.GetCurrentUser();

        // do quantities first
        UserRankQuantity[] oneDayUsers = Common.GetWebService().UserRankByQuantity(1, 10);
        FillTable(GetHallOfFameUsers(oneDayUsers), oneDayTable, currentUser);
        UserRankQuantity[] sevenDayUsers = Common.GetWebService().UserRankByQuantity(7, 10);
        FillTable(GetHallOfFameUsers(sevenDayUsers), sevenDayTable, currentUser);
        UserRankQuantity[] allTimeUsers = Common.GetWebService().UserRankByQuantity(30, 10);
        FillTable(GetHallOfFameUsers(allTimeUsers), allTimeTable, currentUser);

        int preferredLanguage = Common.GetPreferredLanguage();
        if (preferredLanguage <= 0)
        {
            preferredLanguage = 1; // default to english
        }

        Language[] languages = Common.GetWebService().LanguageList();
        foreach (Language language in languages)
        {
            string languageString = Common.GetWebService().LanguageNameQueryById(language.id, preferredLanguage);
            // outter table
            Label titleLabel = new Label();
            titleLabel.Text = languageString; // FIXME: localize "Highest Rating"

            TableHeaderCell titleCell = new TableHeaderCell();
            titleCell.Controls.Add(titleLabel);

            TableHeaderRow titleRow = new TableHeaderRow();
            titleRow.Cells.Add(titleCell);

            Table newRatingTable = new Table();
            newRatingTable.Rows.Add(titleRow);

            // now for the actual table
            Label usernameLabel = new Label();
            usernameLabel.Text = "Username";
            TableHeaderCell usernameCell = new TableHeaderCell();
            usernameCell.Controls.Add(usernameLabel);

            Label displayNameLabel = new Label();
            displayNameLabel.Text = "Display Name";
            TableHeaderCell displayNameCell = new TableHeaderCell();
            displayNameCell.Controls.Add(displayNameLabel);

            Label ratingLabel = new Label();
            ratingLabel.Text = "Rating";
            TableHeaderCell ratingCell = new TableHeaderCell();
            ratingCell.Controls.Add(ratingLabel);

            TableHeaderRow hallOfFameHeaderRow = new TableHeaderRow();
            hallOfFameHeaderRow.Cells.Add(usernameCell);
            hallOfFameHeaderRow.Cells.Add(displayNameCell);
            hallOfFameHeaderRow.Cells.Add(ratingCell);

            Table hallOfFameTable = new Table();
            hallOfFameTable.Rows.Add(hallOfFameHeaderRow);
            hallOfFameTable.CssClass = "displayTable";

            UserRankRating[] users = Common.GetWebService().UserRankByRating(language.id, 10);
            FillTable(GetHallOfFameUsers(users), hallOfFameTable, currentUser);

            TableCell hallOfFameCell = new TableCell();
            hallOfFameCell.Controls.Add(hallOfFameTable);
            TableRow hallOfFameRow = new TableRow();
            hallOfFameRow.Cells.Add(hallOfFameCell);
            newRatingTable.Rows.Add(hallOfFameRow);

            ratingPlaceHolder.Controls.Add(newRatingTable);
            ratingPlaceHolder.Controls.Add(newLabel);
        }
    }

    private HallOfFameUser[] GetHallOfFameUsers(UserRankQuantity[] users)
    {
        HallOfFameUser[] hallOfFameUsers = new HallOfFameUser[users.Length];
        for (int i = 0; i < users.Length; i++)
        {
            HallOfFameUser newUser;
            newUser.name = users[i].user.name;
            newUser.username = users[i].user.username;
            newUser.property = users[i].quantity.ToString();
            newUser.id = users[i].user.id;
            hallOfFameUsers[i] = newUser;
        }
        return hallOfFameUsers;
    }

    private HallOfFameUser[] GetHallOfFameUsers(UserRankRating[] users)
    {
        HallOfFameUser[] hallOfFameUsers = new HallOfFameUser[users.Length];
        for (int i = 0; i < users.Length; i++)
        {
            HallOfFameUser newUser;
            newUser.name = users[i].user.name;
            newUser.username = users[i].user.username;
            newUser.property = users[i].net_rating.ToString();
            newUser.id = users[i].user.id;
            hallOfFameUsers[i] = newUser;
        }
        return hallOfFameUsers;
    }

    private void FillTable(HallOfFameUser[] users, Table table, User currentUser)
    {
        int count = 0;
        foreach (HallOfFameUser user in users)
        {
            TableCell usernameCell = new TableCell();
            TableCell displayNameCell = new TableCell();
            if (currentUser == null)
            {
                Label usernameLabel = new Label();
                usernameLabel.Text = user.username;
                usernameCell.Controls.Add(usernameLabel);

                Label displayNameLabel = new Label();
                displayNameLabel.Text = user.name;
                displayNameCell.Controls.Add(displayNameLabel);
            }
            else
            {
                HyperLink usernameLink = new HyperLink();
                usernameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + user.id;
                usernameLink.Text = user.username;
                usernameCell.Controls.Add(usernameLink);

                HyperLink displayNameLink = new HyperLink();
                displayNameLink.NavigateUrl = "~/ViewProfile.aspx?id=" + user.id;
                usernameLink.Text = user.name;
                displayNameCell.Controls.Add(displayNameLink);
            }

            Label quantityLabel = new Label();
            quantityLabel.Text = user.property;
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
