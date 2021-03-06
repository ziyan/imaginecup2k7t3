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


public partial class AutomaticTranslation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((sourceDropDown.Items.Count == 0) && 
                (destinationDropDown.Items.Count == 0))
        {
            Language[] languages = Common.GetWebService().LanguageList();
            foreach (Language language in languages)
            {
                string languageString = Common.GetWebService().LanguageNameQueryById(
                        language.id, Common.GetPreferredLanguage());
                sourceDropDown.Items.Add(
                            new ListItem(languageString, language.id.ToString()));
                destinationDropDown.Items.Add(
                            new ListItem(languageString, language.id.ToString()));
            }
        }
    }
    protected void TranslationButton_Click(object sender, EventArgs e)
    {
        ListItem sourceItem = sourceDropDown.Items[sourceDropDown.SelectedIndex];
        ListItem destItem = destinationDropDown.Items[destinationDropDown.SelectedIndex];
        int sourceCode = Convert.ToInt32(sourceItem.Value);
        int destCode = Convert.ToInt32(destItem.Value);

        string translatedText= Omni.Web.Common.GetWebService().TranslationLookup(
                sourceCode, destCode, OriginalMessageText.Text);
        TranslatedMessageText.Text = translatedText;
    }
}
    