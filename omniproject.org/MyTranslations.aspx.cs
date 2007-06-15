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

public partial class MyTranslations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(NotAuthedControl1, userPanel);

        if (userPanel.Visible)
        {
            //if(functionMultiView.ActiveViewIndex == 1)
                populateTranslationsT();
            //else 
            populateTranslations();
        }
    }
    protected void userFuncButton_Click(object sender, EventArgs e)
    {
        functionMultiView.ActiveViewIndex = 0;
    }
    protected void translatorFuncButton_Click(object sender, EventArgs e)
    {
        functionMultiView.ActiveViewIndex = 1;
    }
    protected void pendingRequestsLB_Click(object sender, EventArgs e)
    {
        pendingRequestsPanel.Visible = !pendingRequestsPanel.Visible;
    }
    protected void receivedTranslationsLB_Click(object sender, EventArgs e)
    {
        receivedTranslationsPanel.Visible = !receivedTranslationsPanel.Visible;
    }
    protected void completedTranslationsLB_Click(object sender, EventArgs e)
    {
        completedTranslationsPanel.Visible = !completedTranslationsPanel.Visible;
    }
    private void populateTranslations()
    {
        WebService svc = Common.GetWebService();
        User user = Common.GetCurrentUser();

        // User: Pending Requests
        pendingRequestsTable.Rows.Clear();
        pendingRequestsTable.Rows.Add(translationHeader.getTranslationHeader());

        Translation[] transPending = svc.TransGetPendingByUser(user.id);
        for (int i = 0; i < transPending.Length; i++)
        {
            pendingRequestsTable.Rows.Add(translationHeader.getTableRowForTranslation(transPending[i], TranslationRow_Click, "a"));
        }

        // User: Received Translations
        receivedTranslationsTable.Rows.Clear();
        receivedTranslationsTable.Rows.Add(translationHeader.getTranslationHeader());

        Translation[] transReceived = svc.TransGetUnApprByUser(user.id);
        for (int i = 0; i < transReceived.Length; i++)
        {
            receivedTranslationsTable.Rows.Add(translationHeader.getTableRowForTranslation(transReceived[i], TranslationRow_Click, "b"));
        }


        // User: Completed Translations
        completedTranslationsTable.Rows.Clear();
        completedTranslationsTable.Rows.Add(translationHeader.getTranslationHeader());

        Translation[] transApproved = svc.TransGetApprByUser(user.id);
        for (int i = 0; i < transApproved.Length; i++)
        {
            completedTranslationsTable.Rows.Add(translationHeader.getTableRowForTranslation(transApproved[i], TranslationRow_Click, "c"));
        }

    }

    private void populateTranslationsT()
    {
        WebService svc = Common.GetWebService();
        User user = Common.GetCurrentUser();

        // Translator: Personal Reqs
        personalReqsTable.Rows.Clear();
        personalReqsTable.Rows.Add(translationHeader.getTranslationHeader());

        Translation[] personalTrans = svc.TransReqGetForUser(user.id);
        for (int i = 0; i < personalTrans.Length; i++)
        {
            personalReqsTable.Rows.Add(translationHeader.getTableRowForTranslation(personalTrans[i], TranslationRow_Click, "d"));
        }

        // Translator: Global Reqs
        globalReqsTable.Rows.Clear();
        globalReqsTable.Rows.Add(translationHeader.getTranslationHeader());

        Translation[] globalTrans = svc.TransReqFindGlobalForUser(user.id);
        for (int i = 0; i < globalTrans.Length; i++)
        {
            globalReqsTable.Rows.Add(translationHeader.getTableRowForTranslation(globalTrans[i], TranslationRow_Click, "e"));
        }
    }

    protected void TranslationRow_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        String id = lb.ID;
        id = id.Replace(TranslationHeader.rowIdPrefix, "");
        id = id.Substring(1);
        id = id.Trim();
        //int intId = Convert.ToInt32(id);
        Server.Transfer("TranslationDetails.aspx?id=" + id);
    }
}
