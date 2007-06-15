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

public partial class RequestTranslation : System.Web.UI.Page
{
    enum TranslatorType { User, Global }

    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(NotAuthedControl1, userPanel);

        User user = Common.GetCurrentUser();
        User[] favorites = Common.GetWebService().UserFavorUserListById(user.id);
        if (favorites.Length == 0)
        {
            userTranslatorDDL.Visible = false;
        }
        else
        {
            if (userTranslatorDDL.SelectedIndex == 0)
            {
                for (int i = 1; i < userTranslatorDDL.Items.Count; i++)
                    userTranslatorDDL.Items.RemoveAt(i);
                for (int i = 0; i < favorites.Length; i++)
                {
                    String favUsername = favorites[i].username;
                    userTranslatorDDL.Items.Add(new ListItem(favUsername, favUsername));
                }
            }
        }

        Language[] languages = Common.GetWebService().LanguageList();

        int prefLang = Common.GetPreferredLanguage();
        srcLangDDL.Items.Clear();
        destLangDDL.Items.Clear();
        if (prefLang <= 0)
        {
            srcLangDDL.Items.Add(new ListItem("----", "0"));
            destLangDDL.Items.Add(new ListItem("----", "0"));
        }

        for(int i=0; i<languages.Length; i++)
        {
            Language language = languages[i];
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
                srcLangDDL.Items.Add(item);

                item = new ListItem(languageString, language.id.ToString());
                item.Selected = true;
                destLangDDL.Items.Add(item);
            }
            else
            {
                srcLangDDL.Items.Add(
                        new ListItem(languageString, language.id.ToString()));
                destLangDDL.Items.Add(
                        new ListItem(languageString, language.id.ToString()));
            }
        }


        if (desiredTranslatorDDL.SelectedIndex != 0)
        {
            userTranslatorPanel.Enabled = false;
        }
        else userTranslatorPanel.Enabled = true;
    }
    /*
    protected void userRB_CheckedChanged(object sender, EventArgs e)
    {
        globalRB.Checked = !userRB.Checked;

        if (userRB.Checked)
        {
            userTranslatorPanel.Enabled = true;
        }
        else
        {
            userTranslatorPanel.Enabled = false;
        }
    }
    protected void globalRB_CheckedChanged(object sender, EventArgs e)
    {
        userRB.Checked = !globalRB.Checked;
    }*/
    protected void desiredTranslatorDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (desiredTranslatorDDL.SelectedIndex != 0)
        {
            userTranslatorPanel.Enabled = false;
        }
        else userTranslatorPanel.Enabled = true;
    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        User user = Common.GetCurrentUser();
        WebService svc = Common.GetWebService();

        if (subjectLabel.Text.Length == 0 || transTextTB.Text.Length == 0)
        {
            emptyFieldsLabel.Visible = true;
            return;
        }
        else emptyFieldsLabel.Visible = false;

        int userId = user.id;
        int srcLangId = Convert.ToInt32(srcLangDDL.SelectedValue);
        int dstLangId = Convert.ToInt32(destLangDDL.SelectedValue);
        String subject = subjectTB.Text;
        String message = transTextTB.Text;
        int dstId = 0;
        TranslationDestinationType dst_type;
        if ((TranslatorType)desiredTranslatorDDL.SelectedIndex == TranslatorType.User)
        {
            dst_type = TranslationDestinationType.User;
            String selUsername = userTranslatorTB.Text;
            dstId = svc.UserIdGetByUsername(selUsername);
            if (dstId <= 0)
            {
                invalidUserLabel.Visible = true;
                return;
            }
            else invalidUserLabel.Visible = false;
        }
        else // if ((TranslatorType)desiredTranslatorDDL.SelectedIndex == TranslatorType.Global)
        {
            dst_type = TranslationDestinationType.Public;
        }

        svc.TransReqAdd(userId, srcLangId, dstLangId, subject, message, dstId, dst_type, 0);
        Server.Transfer("MyTranslations.aspx");
    }
    protected void userTranslatorDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (userTranslatorDDL.SelectedIndex > 0)
        {
            userTranslatorTB.Text = userTranslatorDDL.SelectedValue;
            userTranslatorTB.Enabled = false;
        }
        else userTranslatorTB.Enabled = true;
    }
}
