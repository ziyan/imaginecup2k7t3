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
        Translation t = null;
        String req_id_str = Request.QueryString["id"];
        if (req_id_str == null || req_id_str == "" || System.Text.RegularExpressions.Regex.Replace(req_id_str, "[0-9]+", "") != "")
            Response.Redirect("/");

        int req_id = Convert.ToInt32(req_id_str);
        if (req_id <= 0)
            Response.Redirect("/");
        try
        {
            t = Common.GetWebService().TransReqGetById(req_id);
        }
        catch (Exception ex)
        {
            t = null;
            throw ex;
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
            if (Omni.Web.Common.IsUserLoggedIn() && !t.completed)
                rePanel.Visible = true;
            else
                rePanel.Visible = false;
            populateTranslationDetails(t);
            populateTranslationAnswers(t);
        }
    }
    private void populateTranslationDetails(Translation t)
    {
        translationDetailsTable.Rows.Clear();
        translationDetailsTable.Rows.Add(translationHeader.getTranslationHeader(true,false,true));
        TableRow newRow = translationHeader.getTableRowForTranslation(t, null, "a",true,false,true,false);
        newRow.CssClass = "row1";
        translationDetailsTable.Rows.Add(newRow);
        TableCell tc = new TableCell();
        TextBox tb = new TextBox();
        tb.TextMode = TextBoxMode.MultiLine;
        tb.Text = t.orig_body;
        tb.ReadOnly = true;
        tb.Style.Add("width", "100%");
        tc.ColumnSpan = 5;
        tc.Controls.Add(tb);
        TableRow tr = new TableRow();
        tr.CssClass = "row2";
        tr.Cells.Add(tc);
        translationDetailsTable.Rows.Add(tr);
    }
    private void populateTranslationAnswers(Translation t)
    {
        ansPanel.Controls.Clear();
        Translation[] ans = Omni.Web.Common.GetWebService().TransGetByReqId(t.request_id);
        for (int i = 0; i < ans.Length; i++)
        {
            
            //answer
            Table ansTable = new Table();
            ansTable.CssClass = "displayTable";
            TableRow colRow = translationHeader.getTranslationHeader(false, true, false);
            ansTable.Rows.Add(colRow);
            TableRow newRow = translationHeader.getTableRowForTranslation(ans[i], null, "b"+i.ToString(), false, true, false, true);
            newRow.CssClass = "row1";
            ansTable.Rows.Add(newRow);
            TableCell tc = new TableCell();
            TextBox tb = new TextBox();
            tb.TextMode = TextBoxMode.MultiLine;
            tb.Text = ans[i].trans_body;
            tb.ReadOnly = true;
            tb.Style.Add("width", "500px");
            tc.ColumnSpan = 5;
            tc.Controls.Add(tb);
            TableRow tr = new TableRow();
            tr.CssClass = "row2";
            tr.Cells.Add(tc);
            ansTable.Rows.Add(tr);
            TableCell buttonCell = new TableCell();
            buttonCell.ColumnSpan = 3;
            if (Omni.Web.Common.GetCurrentUser() != null)
            {
                Button useButton = new Button();
                useButton.Text = useLabel.Text;
                useButton.ID = "useButton_" + ans[i].trans_id;
                useButton.Click += new EventHandler(composeFromTransButton_Click);
                buttonCell.Controls.Add(useButton);
            }
            if (!t.completed && Omni.Web.Common.GetCurrentUser() != null && t.req_user == Omni.Web.Common.GetCurrentUser().id)
            {
                Button approveButton = new Button();
                approveButton.Text = approveLabel.Text;
                approveButton.Click += new EventHandler(approveTransButton_Click);
                approveButton.ID = "approveButton_" + ans[i].trans_id;
                buttonCell.Controls.Add(approveButton);
            }
            TableRow buttonRow = new TableRow();
            buttonRow.Cells.Add(buttonCell);
            buttonRow.CssClass = "row1";
            ansTable.Rows.Add(buttonRow);

            Label bookmark = new Label();
            bookmark.Text = "<a name=\"ans"+ans[i].trans_id+"\"></a>";
            ansPanel.Controls.Add(bookmark);
            ansPanel.Controls.Add(ansTable);
            Label spacer = new Label();
            spacer.Text="<br/><br/>";
            ansPanel.Controls.Add(spacer);
        }
    }
    protected void submitTransButton_Click(object sender, EventArgs e)
    {
        WebService svc = Common.GetWebService();
        User user = Common.GetCurrentUser();
        if (user == null) return;
        int req_id = Convert.ToInt32(Request.QueryString["id"]);
        svc.TransAnsAdd(req_id, user.id, reBox.Text);
        Response.Redirect(Request.Url.ToString());
    }
    protected void approveTransButton_Click(object sender, EventArgs e)
    {
        if (!Common.GetWebService().UserIsLoggedIn()) return;
        Common.GetWebService().TransReqClose(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(((Button)sender).ID.Replace("approveButton_", "")));
        Server.Transfer("MyTranslations.aspx");
    }
    protected void composeFromTransButton_Click(object sender, EventArgs e)
    {
        if (!Common.GetWebService().UserIsLoggedIn()) return;
        Server.Transfer("ComposeMessage.aspx?ans_id=" + ((Button)sender).ID.Replace("useButton_",""));
    }
}
