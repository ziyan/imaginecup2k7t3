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

public partial class LanguageSelector : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(langDropDown.Items.Count == 0)
            populateDropDown();
    }
    protected void langDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        String selVal = langDropDown.SelectedValue;
        int value = Convert.ToInt32(selVal);
        Common.SetPreferredLanguage(value);
        Response.Redirect(Request.Url.ToString());
    }
    private void populateDropDown()
    {
        
        Language[] languages = Common.GetWebService().LanguageList();

        int prefLang = Common.GetPreferredLanguage();
        langDropDown.Items.Clear();
        if(prefLang<=0) langDropDown.Items.Add(new ListItem("(Choose)","0"));

        foreach (Language language in languages)
        {
            string languageString;
            if (prefLang > 0)
                languageString = Common.GetWebService().LanguageNameQueryById(
                    language.id, prefLang);
            else languageString = Common.GetWebService().LanguageNameQueryById(
                    language.id, language.id);
            if (language.id == prefLang)
            {
                ListItem item = new ListItem(languageString, language.id.ToString());
                item.Selected = true;
                langDropDown.Items.Add(item);
            }
            else
                langDropDown.Items.Add(
                        new ListItem(languageString, language.id.ToString()));
        }
    }

    public void enlarge()
    {
        langDropDown.Font.Size = 32;
    }
}
