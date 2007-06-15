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

public partial class TranslationDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(NotAuthedControl1, userPanel);

        Translation t = null;

        String transIdStr = Request.QueryString["id"];
        if (transIdStr != null && transIdStr.Length > 0)
        {
            int intId = Convert.ToInt32(transIdStr);
            if (intId > 0)
            {
                
                try
                {
                    t = Common.GetWebService().TransGetByReqId(intId);
                    if (t == null)
                    {
                        t = Common.GetWebService().TransReqGetById(intId);
                    }
                }
                catch (Exception ex)
                {
                    t = null;
                    throw ex;
                }
            }
        }

        if (t == null)
        {
            invalidIdLabel.Text += " " + Request.QueryString["id"];
            invalidIdLabel.Visible = true;
            userPanel.Visible = false;
            return;
        }
        else
        {
            populateTranslationDetails(t);
        }
    }
    private void populateTranslationDetails(Translation t)
    {
        User user = Common.GetCurrentUser();

        translationDetailsTable.Rows.Clear();
        translationDetailsTable.Rows.Add(translationHeader.getTranslationHeader());
        translationDetailsTable.Rows.Add(translationHeader.getTableRowForTranslation(t, null, "a"));

        origMsgTB.Text = t.orig_body;
        if (t.type == TranslationDataType.Full)
        {
            transMsgTB.Text = t.trans_body;
            transAnsId.Text = t.trans_id.ToString();
        }
        else
        {
            transMsgTB.Visible = false;
            transMsgLabel.Visible = false;
        }

        if (t.completed)
            transView.ActiveViewIndex = 0;
        else if (!t.completed && t.type == TranslationDataType.Full && t.dst_type == TranslationDestinationType.User && t.req_user == user.id)
            transView.ActiveViewIndex = 1;
        else if (!t.completed && t.type == TranslationDataType.Request && t.req_user != user.id)
            transView.ActiveViewIndex = 2;

        if (t.trans_rating > 0 && t.trans_rating <= 5)
        {
            readRatingRBL.SelectedIndex = t.trans_rating - 1;
            writeRatingRBL.Visible = false;
            rateAnsLabel.Visible = false;

            writePrevRatingRBL.Visible = false;
            prevRateLabel.Visible = false;
        }
        if (t.type != TranslationDataType.Full)
        {
            writePrevRatingRBL.Visible = false;
            prevRateLabel.Visible = false;
        }
    }
    protected void submitTransButton_Click(object sender, EventArgs e)
    {
        WebService svc = Common.GetWebService();
        User user = Common.GetCurrentUser();
        int req_id = Convert.ToInt32(Request.QueryString["id"]);

        svc.TransAnsAdd(req_id, user.id, translationTB.Text, 0);

        Server.Transfer("MyTranslations.aspx");
    }
    protected void writeRatingRBL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.GetWebService().TransAnsRateById(Common.GetCurrentUser().id, Convert.ToInt32(transAnsId.Text), (short)(writeRatingRBL.SelectedIndex+1));
        readRatingRBL.SelectedIndex = writeRatingRBL.SelectedIndex;
        writeRatingRBL.Visible = false;
        rateAnsLabel.Visible = false;
    }
    protected void approveTransButton_Click(object sender, EventArgs e)
    {
        Common.GetWebService().TransReqClose(Convert.ToInt32(Request.QueryString["id"]));
        Server.Transfer("MyTranslations.aspx");
    }
    protected void writePrevRatingRBL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.GetWebService().TransAnsRateById(Common.GetCurrentUser().id, Convert.ToInt32(transAnsId.Text), (short)(writePrevRatingRBL.SelectedIndex + 1));
        readRatingRBL.SelectedIndex = writePrevRatingRBL.SelectedIndex;
        prevRateLabel.Visible = false;
        writePrevRatingRBL.Visible = false;
    }
}
