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
        pendingRequestsTable.Rows.Add(translationHeader.getTranslationHeader(false,false,true));

        Translation[] transPending = svc.TransGetPendingByUser(user.id);
        int count = 0;
        for (int i = 0; i < transPending.Length; i++)
        {
            TableRow newRow = translationHeader.getTableRowForTranslation(transPending[i], translationHeader.TranslationRow_Click, "a",false,false,true,false);
            newRow.CssClass = "row" + ((count % 2) + 1).ToString();
            pendingRequestsTable.Rows.Add(newRow);
            count++;
        }

        // User: Received Translations
        receivedTranslationsTable.Rows.Clear();
        receivedTranslationsTable.Rows.Add(translationHeader.getTranslationHeader(false,true,true));
        count = 0;
        Translation[] transReceived = svc.TransGetUnApprByUser(user.id);
        for (int i = 0; i < transReceived.Length; i++)
        {
            TableRow newRow = translationHeader.getTableRowForTranslation(transReceived[i], translationHeader.TranslationRow_Click, "b",false,true,true,true);
            newRow.CssClass = "row" + ((count % 2) + 1).ToString();
            receivedTranslationsTable.Rows.Add(newRow);
            count++;
        }


        // User: Completed Translations
        completedTranslationsTable.Rows.Clear();
        completedTranslationsTable.Rows.Add(translationHeader.getTranslationHeader(false,false,true));

        count = 0;
        Translation[] transApproved = svc.TransGetApprByUser(user.id);
        for (int i = 0; i < transApproved.Length; i++)
        {
            TableRow newRow = translationHeader.getTableRowForTranslation(transApproved[i], translationHeader.TranslationRow_Click, "c",false,false,true,false);
            newRow.CssClass = "row" + ((count % 2) + 1).ToString();
            completedTranslationsTable.Rows.Add(newRow);
            count++;
        }

    }

    private void populateTranslationsT()
    {
        WebService svc = Common.GetWebService();
        User user = Common.GetCurrentUser();

        // Translator: Personal Reqs
        personalReqsTable.Rows.Clear();
        personalReqsTable.Rows.Add(translationHeader.getTranslationHeader(true,false,true));

        int count = 0;
        Translation[] personalTrans = svc.TransReqGetForUser(user.id);
        for (int i = 0; i < personalTrans.Length; i++)
        {
            TableRow newRow = translationHeader.getTableRowForTranslation(personalTrans[i], translationHeader.TranslationRow_Click, "d",true,false,true,false);
            newRow.CssClass = "row" + ((count % 2) + 1).ToString();
            personalReqsTable.Rows.Add(newRow);
            count++;
        }

        // Translator: Global Reqs
        globalReqsTable.Rows.Clear();
        globalReqsTable.Rows.Add(translationHeader.getTranslationHeader(true,false,true));

        count = 0;
        Translation[] globalTrans = svc.TransReqFindGlobalForUser(user.id);
        for (int i = 0; i < globalTrans.Length; i++)
        {
            TableRow newRow = translationHeader.getTableRowForTranslation(globalTrans[i], translationHeader.TranslationRow_Click, "e",true,false,true,false);
            newRow.CssClass = "row" + ((count % 2) + 1).ToString();
            globalReqsTable.Rows.Add(newRow);
            count++;
        }
    }
}
