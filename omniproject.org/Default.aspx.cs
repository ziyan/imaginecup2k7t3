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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(guestPanel, userPanel);

        User currentUser = Common.GetCurrentUser();
        if (currentUser == null) return;

        displayNameLabel.Text = currentUser.name;

        Table translationTable = new Table();
        translationTable.CssClass = "displayTable";
        userPanel.Controls.Add(translationTable);

        TableHeaderRow headerRow = translationHeader.getTranslationHeader();
        translationTable.Rows.Add(headerRow);

        Translation[] translationRequests =
                Common.GetWebService().TransReqFindGlobalForUser(currentUser.id);
        int count = 0;
        foreach (Translation translationRequest in translationRequests)
        {
            TableRow newRoll = translationHeader.getTableRowForTranslation(
                    translationRequest, translationHeader.TranslationRow_Click, "a");
            newRoll.CssClass = "row" + ((count % 2) + 1).ToString();
            translationTable.Rows.Add(newRoll);
            count++;
        }
    }
}
