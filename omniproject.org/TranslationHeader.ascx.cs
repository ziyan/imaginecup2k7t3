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

    

    public TableHeaderRow getTranslationHeader(bool hasRequester, bool hasTranslator, bool hasLanguages)
    {
        TableHeaderRow tr = new TableHeaderRow();
        TableHeaderCell date = new TableHeaderCell();
        date.Controls.Add(cloneLabel(transDateLabel));
        tr.Cells.Add(date);

        if (hasRequester)
        {
            TableHeaderCell requestor = new TableHeaderCell();
            requestor.Controls.Add(cloneLabel(transRequestorLabel));
            tr.Cells.Add(requestor);
        }
        if(hasTranslator)
        {
            TableHeaderCell translator = new TableHeaderCell();
            translator.Controls.Add(cloneLabel(transTranslatorLabel));
            tr.Cells.Add(translator);
        }

        if (hasLanguages)
        {
            TableHeaderCell subject = new TableHeaderCell();
            subject.Controls.Add(cloneLabel(transSubjectLabel));
            tr.Cells.Add(subject);


            TableHeaderCell srcLang = new TableHeaderCell();
            srcLang.Controls.Add(cloneLabel(transSrcLangLabel));
            TableHeaderCell destLang = new TableHeaderCell();
            destLang.Controls.Add(cloneLabel(transDestLangLabel));
            tr.Cells.Add(srcLang);
            tr.Cells.Add(destLang);
        }
        else
        {
            TableHeaderCell rating = new TableHeaderCell();
            rating.Controls.Add(cloneLabel(ratingLabel));
            tr.Cells.Add(rating);

        }
        return tr;
    }

    public TableRow getTableRowForTranslation(Translation t, EventHandler eh, String prefix, bool hasRequester, bool hasTranslator, bool hasLanguages, bool isAnswer)
    {
        int userid = -1;
        WebService svc = Common.GetWebService();
        int prefLangId = Common.GetPreferredLanguage();
        User tmpUser;

        TableRow tr = new TableRow();
        TableCell date = new TableCell();
        Label dateL = new Label();
        if (!isAnswer)
        {
            dateL.Text = t.date.ToString();
        }
        else
        {
            dateL.Text = t.trans_date.ToString();
        }
        date.Controls.Add(dateL);
        tr.Cells.Add(date);

        if (hasRequester)
        {
            TableCell requestor = new TableCell();
            Label requestorL = new Label();
            tmpUser = svc.UserGetById(t.req_user);
            requestorL.Text = tmpUser.username;
            requestor.Controls.Add(requestorL);
            tr.Cells.Add(requestor);
        }
        if(hasTranslator)
        {
            TableCell translator = new TableCell();
            Label translatorL = new Label();
            if (t.dst_type == TranslationDestinationType.Public && t.type == TranslationDataType.Request)
                translatorL.Text = globalTransLabel.Text;
            else
            {
                userid = t.trans_user;
                tmpUser = svc.UserGetById(userid);
                translatorL.Text = (tmpUser == null) ? "" : tmpUser.username;
            }
            translator.Controls.Add(translatorL);
            tr.Cells.Add(translator);
        }
        if (hasLanguages)
        {
            TableCell subject = new TableCell();
            if (eh != null)
            {
                LinkButton lb = new LinkButton();
                lb.Text = t.subject;
                lb.SkinID = "black";
                if(isAnswer)
                {
                    lb.ID = prefix + rowAnsIdPrefix + t.request_id+"_"+t.trans_id;
                }
                else
                {
                    lb.ID = prefix + rowIdPrefix + t.request_id;
                }
                
                lb.Click += eh;
                subject.Controls.Add(lb);
            }
            else
            {
                Label subjLabel = new Label();
                subjLabel.Text = t.subject;
                subject.Controls.Add(subjLabel);
            }
            tr.Cells.Add(subject);

            TableCell srcLang = new TableCell();
            Label srcLangL = new Label();
            srcLangL.Text = svc.LanguageNameQueryById(t.src_lang_id, prefLangId);
            srcLang.Controls.Add(srcLangL);
            tr.Cells.Add(srcLang);

            TableCell destLang = new TableCell();
            Label destLangL = new Label();
            destLangL.Text = svc.LanguageNameQueryById(t.dst_lang_id, prefLangId);
            destLang.Controls.Add(destLangL);
            tr.Cells.Add(destLang);
        }
        else
        {
            Spaanjaars.Toolkit.ContentRating rater = new Spaanjaars.Toolkit.ContentRating();
            rater.ID = "r_" + t.trans_id;
            rater.Rated += new Spaanjaars.Toolkit.RatingEventHandler(rater_Rated);
            rater.Load += new EventHandler(rater_Load);
            TableCell ratingL = new TableCell();
            
            ratingL.Controls.Add(rater);
            tr.Cells.Add(ratingL);
             
        }
        if (!t.completed)
            tr.Style.Add("font-weight", "bold");
        return tr;
    }

    void rater_Load(object sender, EventArgs e)
    {
        Spaanjaars.Toolkit.ContentRating rater = (Spaanjaars.Toolkit.ContentRating)sender;
        int ans_id = Convert.ToInt32(rater.ID.Substring(2));

        int[] data = new int[] { 0, 0, 0, 0, 0 };
        rater.DataSource = data;
        //get rating
        int rating = Omni.Web.Common.GetWebService().TransAnsRateGetById(Omni.Web.Common.GetCurrentUser() == null ? 0 : Omni.Web.Common.GetCurrentUser().id, ans_id);
        if (rating < 0)
        {
            rater.Enabled = false;
            rating = -rating;
        }
        else
        {
            rater.Enabled = true;
        }
        if (rating <= 0) rating = 1;
        if (rating > 5) rating = 5;
        data[rating - 1] = 1;
        rater.DataSource = data;
        rater.ItemId = Guid.NewGuid();
        rater.DataBind();
    }

    void rater_Rated(object sender, Spaanjaars.Toolkit.RateEventArgs e)
    {
        Spaanjaars.Toolkit.ContentRating rater = (Spaanjaars.Toolkit.ContentRating)sender;
        int ans_id = Convert.ToInt32(rater.ID.Substring(2));
        Omni.Web.Common.GetWebService().TransAnsRateById(Omni.Web.Common.GetCurrentUser() == null ? 0 : Omni.Web.Common.GetCurrentUser().id, ans_id, Convert.ToInt16(e.RateValue));
        int[] data = new int[] { 0, 0, 0, 0, 0 };
        rater.DataSource = data;
        //get rating
        int rating = Omni.Web.Common.GetWebService().TransAnsRateGetById(Omni.Web.Common.GetCurrentUser() == null ? 0 : Omni.Web.Common.GetCurrentUser().id, ans_id);
        if (rating < 0)
        {
            rater.Enabled = false;
            rating = -rating;
        }
        else
        {
            rater.Enabled = true;
        }
        if (rating <= 0) rating = 1;
        if (rating > 5) rating = 5;
        data[rating - 1] = 1;
        rater.DataSource = data;
        rater.ItemId = Guid.NewGuid();
        rater.DataBind();
    }

    public void TranslationRow_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        String id = lb.ID;
        string[] ids = id.Split("_".ToCharArray());

        if (ids.Length < 2) return;
        string url = "TranslationDetails.aspx?id=";
        url += ids[1];
        if (ids.Length == 3)
            url += "#ans" + ids[2];

        Response.Redirect(url);
    }
}
