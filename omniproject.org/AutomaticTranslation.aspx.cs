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

public partial class AutomaticTranslation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // FIXME: this is hardcoded right now: we'll need to localize this
        if ((sourceDropDown.Items.Count == 0) && 
                (destinationDropDown.Items.Count == 0))
        {
            sourceDropDown.Items.Add("English");
            sourceDropDown.Items.Add("Chinese");
            destinationDropDown.Items.Add("English");
            destinationDropDown.Items.Add("Chinese");
        }
    }
    protected void TranslationButton_Click(object sender, EventArgs e)
    {
        ListItem sourceItem = sourceDropDown.Items[sourceDropDown.SelectedIndex];
        ListItem destItem = destinationDropDown.Items[destinationDropDown.SelectedIndex];
        int sourceCode = sourceItem.Text.Equals("English") ? 1 : 2;
        int destCode = destItem.Text.Equals("English") ? 1 : 2;

        string translatedText= Omni.Web.Common.GetWebService().TranslationLookup(
                sourceCode, destCode, OriginalMessageText.Text);
        TranslatedMessageText.Text = translatedText;
    }
}
