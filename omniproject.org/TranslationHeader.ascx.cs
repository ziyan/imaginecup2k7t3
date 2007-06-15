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

public partial class TranslationHeader : System.Web.UI.UserControl
{
    public const String rowIdPrefix = "transRow_";
    public const String rowAnsIdPrefix = "transAnsRow_";


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private Label cloneLabel(Label l)
    {
        Label nl = new Label();
        nl.Text = l.Text;
        return nl;
    }

    public TableHeaderRow getTranslationHeader()
    {
        BorderStyle borderStyle = BorderStyle.Solid;
        int borderWidth = 1;

        TableHeaderRow tr = new TableHeaderRow();
        TableHeaderCell date = new TableHeaderCell();
        date.BorderStyle = borderStyle;
        date.BorderWidth = borderWidth;
        date.Controls.Add(cloneLabel(transDateLabel));
        TableHeaderCell requestor = new TableHeaderCell();
        requestor.BorderStyle = borderStyle;
        requestor.BorderWidth = borderWidth;
        requestor.Controls.Add(cloneLabel(transRequestorLabel));
        TableHeaderCell translator = new TableHeaderCell();
        translator.BorderStyle = borderStyle;
        translator.BorderWidth = borderWidth;
        translator.Controls.Add(cloneLabel(transTranslatorLabel));
        TableHeaderCell subject = new TableHeaderCell();
        subject.BorderStyle = borderStyle;
        subject.BorderWidth = borderWidth;
        subject.Controls.Add(cloneLabel(transSubjectLabel));
        TableHeaderCell srcLang = new TableHeaderCell();
        srcLang.BorderStyle = borderStyle;
        srcLang.BorderWidth = borderWidth;
        srcLang.Controls.Add(cloneLabel(transSrcLangLabel));
        TableHeaderCell destLang = new TableHeaderCell();
        destLang.BorderStyle = borderStyle;
        destLang.BorderWidth = borderWidth;
        destLang.Controls.Add(cloneLabel(transDestLangLabel));

        tr.Cells.Add(date);
        tr.Cells.Add(requestor);
        tr.Cells.Add(translator);
        tr.Cells.Add(subject);
        tr.Cells.Add(srcLang);
        tr.Cells.Add(destLang);

        return tr;
    }

    public TableRow getTableRowForTranslation(Translation t, EventHandler eh, String prefix)
    {
        int userid = -1;
        WebService svc = Common.GetWebService();
        int prefLangId = Common.GetPreferredLanguage();
        User tmpUser;

        TableRow tr = new TableRow();
        TableCell date = new TableCell();
        Label dateL = new Label();
        dateL.Text = t.date.ToString();
        date.Controls.Add(dateL);

        TableCell requestor = new TableCell();
        Label requestorL = new Label();
        userid = t.req_user;
        tmpUser = svc.UserGetById(userid);
        requestorL.Text = (tmpUser == null) ? "" : tmpUser.username;
        requestor.Controls.Add(requestorL);

        TableCell translator = new TableCell();
        Label translatorL = new Label();
        if (t.dst_type == TranslationDestinationType.Public && t.type == TranslationDataType.Request)
            translatorL.Text = globalTransLabel.Text;
        else
        {
            userid = t.dst_id;
            tmpUser = svc.UserGetById(userid);
            translatorL.Text = (tmpUser == null) ? "" : tmpUser.username;
        }
        translator.Controls.Add(translatorL);

        TableCell subject = new TableCell();
        if (eh != null)
        {
            LinkButton lb = new LinkButton();
            lb.Text = t.subject;
            lb.SkinID = "black";
            if (t.type == TranslationDataType.Full)
            {
                lb.ID = prefix + rowAnsIdPrefix + t.trans_id;
            }
            else lb.ID = prefix + rowIdPrefix + t.request_id;
            lb.Click += eh;
            subject.Controls.Add(lb);
        }
        else
        {
            Label subjLabel = new Label();
            subjLabel.Text = t.subject;
            subject.Controls.Add(subjLabel);
        }

        TableCell srcLang = new TableCell();
        Label srcLangL = new Label();
        srcLangL.Text = svc.LanguageNameQueryById(t.src_lang_id, prefLangId);
        srcLang.Controls.Add(srcLangL);

        TableCell destLang = new TableCell();
        Label destLangL = new Label();
        destLangL.Text = svc.LanguageNameQueryById(t.dst_lang_id, prefLangId);
        destLang.Controls.Add(destLangL);

        tr.Cells.Add(date);
        tr.Cells.Add(requestor);
        tr.Cells.Add(translator);
        tr.Cells.Add(subject);
        tr.Cells.Add(srcLang);
        tr.Cells.Add(destLang);

        return tr;
    }

    public void TranslationRow_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        String id = lb.ID;

        if (id.Contains(rowAnsIdPrefix))
        {
            id = id.Replace(rowAnsIdPrefix, "");
            id = id.Substring(1);
            id = id.Trim();
            //int intId = Convert.ToInt32(id);
            Server.Transfer("TranslationDetails.aspx?ans_id=" + id);
        }
        else
        {
            id = id.Replace(rowIdPrefix, "");
            id = id.Substring(1);
            id = id.Trim();
            //int intId = Convert.ToInt32(id);
            Server.Transfer("TranslationDetails.aspx?id=" + id);
        }
    }
}
