using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Omni.Web;
using Omni.Web.org.omniproject;

public partial class LanguagePicker : System.Web.UI.UserControl
{
    const String ratingIdPrefix = "skillButtonList";

    protected override void OnInit(EventArgs e)
    {
        Language[] languages = Common.GetWebService().LanguageList();
        if (languages.Length < 1)
        {
            tableId.Visible = false;
            return;
        }

        int preferredLanguageId = Common.GetPreferredLanguage();
        if (preferredLanguageId <= 0) return; // should not happen

        foreach (Language language in languages)
        {
            TableCell newLanguageCell = new TableCell();
            Label newLanguageLabel = new Label();
            newLanguageLabel.Text = Common.GetWebService().LanguageNameQueryById(
                    language.id, preferredLanguageId);
            newLanguageCell.Controls.Add(newLanguageLabel);

            TableCell newKnownCell = new TableCell();
            CheckBox newKnownCheck = new CheckBox();
            newKnownCell.Controls.Add(newKnownCheck);

            TableCell newSkillCell = new TableCell();
            RadioButtonList skillButtonList = new RadioButtonList();
            skillButtonList.RepeatDirection = RepeatDirection.Horizontal;
            skillButtonList.ID = ratingIdPrefix + language.id.ToString();
            for (int i = 1; i <= 5; i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = i.ToString();
                skillButtonList.Items.Add(listItem);
            }
            newSkillCell.Controls.Add(skillButtonList);
            if (!IsPostBack)
            {
                skillButtonList.SelectedIndex = 0;
            }

            TableRow newRow = new TableRow();
            tableId.Rows.Add(newRow);
            newRow.Cells.Add(newLanguageCell);
            newRow.Cells.Add(newKnownCell);
            newRow.Cells.Add(newSkillCell);
        }

        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        User currentUser = Common.GetCurrentUser();
        if (currentUser == null) return; // nothing more we can do

        Dictionary<int, int> languageIdRatings = GetUserLanguages(currentUser.id);
        for (int i = 1; i < tableId.Rows.Count; i++)
        {
            TableRow row = tableId.Rows[i];
            TableCell radioCell = row.Cells[2];
            RadioButtonList radioButtonList = (RadioButtonList)radioCell.Controls[0];
            String languageIdString = radioButtonList.ID;
            if (!languageIdString.StartsWith(ratingIdPrefix))
            {
                continue; // fail silently
            }
            languageIdString = languageIdString.Remove(0, ratingIdPrefix.Length);
            int languageId = Convert.ToInt32(languageIdString);

            // user doesn't have language
            if (!languageIdRatings.ContainsKey(languageId)) continue;

            TableCell knownCell = row.Cells[1];
            CheckBox knownCheck = (CheckBox)knownCell.Controls[0];
            knownCheck.Checked = true;

            int currentRating = languageIdRatings[languageId];
            for (int itemCounter = 0; itemCounter < radioButtonList.Items.Count; itemCounter++)
            {
                ListItem item = radioButtonList.Items[itemCounter];
                if (Convert.ToInt32(item.Text) == currentRating)
                {
                    radioButtonList.SelectedIndex = itemCounter;
                    break;
                }
            }
        }
    }

    public void SaveLanguagesToUser(int userId)
    {
        Dictionary<int, int> languageIdRatings = GetUserLanguages(userId);
        for (int i = 1; i < tableId.Rows.Count; i++)
        {
            TableRow row = tableId.Rows[i];
            TableCell radioCell = row.Cells[2];
            RadioButtonList radioButtonList = (RadioButtonList) radioCell.Controls[0];
            String languageIdString = radioButtonList.ID;
            if (!languageIdString.StartsWith(ratingIdPrefix))
            {
                continue; // fail silently
            }
            languageIdString = languageIdString.Remove(0, ratingIdPrefix.Length);
            int languageId = Convert.ToInt32(languageIdString);

            TableCell knownCell = row.Cells[1];
            CheckBox knownCheck = (CheckBox)knownCell.Controls[0];
            if (knownCheck.Checked)
            {
                ListItem selectedItem = radioButtonList.Items[radioButtonList.SelectedIndex];
                short newRating = (short)Convert.ToInt32(selectedItem.Text);
                if (languageIdRatings.ContainsKey(languageId))
                {
                    // check for a changed rating
                    if (languageIdRatings[languageId] == newRating)
                    {
                        newRating = 0; // don't bother setting it if it is the same
                    }

                    languageIdRatings.Remove(languageId);
                }

                if (newRating != 0)
                {
                    Common.GetWebService().UserLanguageSetById(userId, languageId, newRating);
                }
            }
            else
            {
                if (languageIdRatings.ContainsKey(languageId))
                {
                    Common.GetWebService().UserLanguageDeleteById(userId, languageId);
                    languageIdRatings.Remove(languageId);
                }
            }
        }
    }

    private Dictionary<int, int> GetUserLanguages(int userId)
    {
        UserLanguage[] languages = Common.GetWebService().UserLanguageListById(userId);
        Dictionary<int, int> languageIdRatings = new Dictionary<int, int>(languages.Length);
        foreach (UserLanguage language in languages)
        {
            languageIdRatings.Add(language.lang_id, language.self_rating);
        }
        return languageIdRatings;
    }
}
