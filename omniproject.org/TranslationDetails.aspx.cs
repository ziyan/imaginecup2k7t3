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
        bool isLoggedIn = Common.GetWebService().UserIsLoggedIn();

        Translation t = null;

        String transAnsIdStr = Request.QueryString["ans_id"];
        if (transAnsIdStr != null && transAnsIdStr.Length > 0)
        {
            int intId = Convert.ToInt32(transAnsIdStr);
            if (intId > 0)
            {
                try
                {
                    t = Common.GetWebService().TransGetByAnsId(intId);
                }
                catch (Exception ex)
                {
                    t = null;
                    throw ex;
                }
            }
        }
        else
        {
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
            if (isLoggedIn || (t.dst_type == TranslationDestinationType.Public && t.type==TranslationDataType.Request))
                populateTranslationDetails(t);
            if (!isLoggedIn)
            {
                transView.Visible = false;
                composeFromTransButton.Visible = false;
            }
        }
    }
    private void populateTranslationDetails(Translation t)
    {
        bool isLoggedIn = Common.GetWebService().UserIsLoggedIn();
        User user = Common.GetCurrentUser();

        if (!isLoggedIn)
        {
            t.trans_user = 0;
            t.req_user = 0;
        }

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

        if (transView.Visible)
        {
            if (t.completed)
                transView.ActiveViewIndex = 0;
            else if (!t.completed && t.type == TranslationDataType.Full && /*t.dst_type == TranslationDestinationType.User &&*/ t.req_user == user.id)
                transView.ActiveViewIndex = 1;
            else if (!t.completed && /*t.type == TranslationDataType.Request && */ t.req_user != user.id)
                transView.ActiveViewIndex = 2;
        }
        RatingUserControl1.Ans_Id = t.trans_id;
    }
    protected void submitTransButton_Click(object sender, EventArgs e)
    {
        WebService svc = Common.GetWebService();
        User user = Common.GetCurrentUser();
        int req_id = Convert.ToInt32(Request.QueryString["id"]);

        svc.TransAnsAdd(req_id, user.id, translationTB.Text);

        Server.Transfer("MyTranslations.aspx");
    }
    protected void approveTransButton_Click(object sender, EventArgs e)
    {
        Common.GetWebService().TransReqClose(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(Request.QueryString["ans_id"]));
        Server.Transfer("MyTranslations.aspx");
    }
    protected void composeFromTransButton_Click(object sender, EventArgs e)
    {
        if (!Common.GetWebService().UserIsLoggedIn()) return;

        String transAnsIdStr = Request.QueryString["ans_id"];
        if (transAnsIdStr != null && transAnsIdStr.Length > 0)
        {
            Server.Transfer("ComposeMessage.aspx?ans_id=" + transAnsIdStr);
        }
        else
        {
            String transIdStr = Request.QueryString["id"];
            if (transIdStr != null && transIdStr.Length > 0)
            {
                Server.Transfer("ComposeMessage.aspx?req_id=" + transIdStr);
            }
        }

    }
}
