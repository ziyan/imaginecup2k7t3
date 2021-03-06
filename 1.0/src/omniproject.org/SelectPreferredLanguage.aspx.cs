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

public partial class SelectPreferredLanguage : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Language[] languages = Common.GetWebService().LanguageList();

        foreach (Language lang in languages)
        {
            LinkButton lb = new LinkButton();
            lb.SkinID = "black";
            String id = "langButton" + lang.id.ToString();
            lb.ID = id;
            String languageString = Common.GetWebService().LanguageNameQueryById(
                    lang.id, lang.id);
            lb.Text = languageString;
            lb.Click += LinkButton_Click;
            languagePanel.Controls.Add(lb);
            Label newln = new Label();
            newln.ID = "newlnLabel" + lang.id.ToString();
            newln.Text = "   |   ";
            languagePanel.Controls.Add(newln);
        }
        languagePanel.Controls.RemoveAt(languagePanel.Controls.Count - 1);
    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        String id = lb.ID;
        id = id.Replace("langButton", "");
        int langId = Convert.ToInt32(id);

        Common.SetPreferredLanguage(langId);
        Response.Redirect("Default.aspx");

    }
}
