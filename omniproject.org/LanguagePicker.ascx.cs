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

public partial class LanguagePicker : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
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

            TableCell newReadingSkillCell = new TableCell();
            RadioButtonList readingSkillButtonList = new RadioButtonList();
            for (int i = 1; i <= 5; i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = i.ToString();
                readingSkillButtonList.Items.Add(listItem);
            }
            newReadingSkillCell.Controls.Add(readingSkillButtonList);
           
            TableCell newWritingSkillCell = new TableCell();
            RadioButtonList writingSkillButtonList = new RadioButtonList();
            for (int i = 1; i <= 5; i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = i.ToString();
                writingSkillButtonList.Items.Add(listItem);
            }
            newWritingSkillCell.Controls.Add(writingSkillButtonList);

            TableRow newRow = new TableRow();
            newRow.Cells.Add(newLanguageCell);
            newRow.Cells.Add(newKnownCell);
            newRow.Cells.Add(newReadingSkillCell);
            newRow.Cells.Add(newWritingSkillCell);

            tableId.Rows.Add(newRow);
        }
    }
}
