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
                for (int i = userTranslatorDDL.Items.Count - 1; i > 0; i--)
                    userTranslatorDDL.Items.RemoveAt(i);
                for (int i = 0; i < favorites.Length; i++)
                {
                    String favUsername = favorites[i].username;
                    userTranslatorDDL.Items.Add(new ListItem(favUsername, favUsername));
                }
            }
        }

        if (!IsPostBack)
        {
            Language[] languages = Common.GetWebService().LanguageList();

            int prefLang = Common.GetPreferredLanguage();
            srcLangDDL.Items.Clear();
            destLangDDL.Items.Clear();
            if (prefLang <= 0)
            {
                srcLangDDL.Items.Add(new ListItem("----", "0"));
                destLangDDL.Items.Add(new ListItem("----", "0"));
            }

            for (int i = 0; i < languages.Length; i++)
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
        }


        if (desiredTranslatorDDL.SelectedIndex != 0)
        {
            userTranslatorPanel.Enabled = false;
        }
        else userTranslatorPanel.Enabled = true;


        // Passed in messages
        String msgIdStr = Request.QueryString["msg_id"];
        if (msgIdStr != null && msgIdStr.Length > 0)
        {
            int msgid = Convert.ToInt32(msgIdStr);
            if(msgid > 0)
            {
                Message msg = Common.GetWebService().MessageGetById(msgid);
                transTextTB.Text = msg.body;
                subjectTB.Text = msg.subject;
            }
        }

        // Passed in messages, pending translation
        String msgPendingIdStr = Request.QueryString["msg_pending_id"];
        if (msgPendingIdStr != null && msgPendingIdStr.Length > 0)
        {
            int msgid = Convert.ToInt32(msgPendingIdStr);
            if (msgid > 0)
            {
                Message msg = Common.GetWebService().MessageGetById(msgid);
                transTextTB.Text = msg.body;
                subjectTB.Text = msg.subject;
            }
        }
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

        int reqId = svc.TransReqAdd(userId, srcLangId, dstLangId, subject, message, dstId, dst_type, 0);
        
        String msgPendingIdStr = Request.QueryString["msg_pending_id"];
        // If this is from a pending message, update the req_id for
        // the linked message
        if (msgPendingIdStr != null && msgPendingIdStr.Length > 0)
        {
            int msgId = Convert.ToInt32(msgPendingIdStr);
            svc.MessageUpdTransReqId(msgId, reqId);
        }

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
