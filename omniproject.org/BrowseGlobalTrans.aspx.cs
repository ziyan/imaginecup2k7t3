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

public partial class BrowseGlobalTrans : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        int preferredLanguageId = Common.GetPreferredLanguage();
        if (preferredLanguageId <= 0)
        {
            preferredLanguageId = 1; // should not happen
        }

        Language[] languages = Common.GetWebService().LanguageList();

        foreach (Language language in languages)
        {
            ListItem item = new ListItem();
            string languageString = Common.GetWebService().LanguageNameQueryById(
                    language.id, preferredLanguageId);
            item.Text = languageString;
            item.Value = language.id.ToString();
            searchLanguageDropDown.Items.Add(item);

            ListItem otherLanguageItem = new ListItem();
            string otherLanguageString = Common.GetWebService().LanguageNameQueryById(
                    language.id, preferredLanguageId);
            otherLanguageItem.Text = otherLanguageString;
            otherLanguageItem.Value = language.id.ToString();
            otherLanguageDropDown.Items.Add(otherLanguageItem);
        }

        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        searchNoneMessageLabel.Visible = false;

        if (keywordSearchText.Text.Length == 0) return;

        ListItem searchItem = searchLanguageDropDown.Items[searchLanguageDropDown.SelectedIndex];
        int searchId = Convert.ToInt32(searchItem.Value);
        ListItem otherItem = otherLanguageDropDown.Items[otherLanguageDropDown.SelectedIndex];
        int otherId = Convert.ToInt32(otherItem.Value);

        Translation[] translations = Common.GetWebService().TransSearch(
                keywordSearchText.Text, searchId, otherId);
        if (translations.Length == 0)
        {
            searchNoneMessageLabel.Visible = true;
            return;
        }

        TableHeaderRow headerRow = translationHeader.getTranslationHeader();
        Table translationTable = new Table();
        translationTable.CssClass = "displayTable";
        translationTable.Rows.Add(headerRow);

        int count = 0;
        foreach (Translation translation in translations)
        {
            TableRow newRow = translationHeader.getTableRowForTranslation(
                    translation, translationHeader.TranslationRow_Click, "a");
            newRow.CssClass = "row" + ((count % 2) + 1).ToString();
            translationTable.Rows.Add(newRow);
            count++;
        }

        translationPlaceHolder.Controls.Add(translationTable);
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
    }
}
