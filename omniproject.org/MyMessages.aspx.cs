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
using System.Collections.Generic;

using Omni.Web;
using Omni.Web.org.omniproject;

public partial class MyMessages : System.Web.UI.Page
{
    enum MsgFilterTypes { Received, Sent, /*Unsent,*/ All };
    enum MsgViews { Unread, Read, All };

    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteCommon.setLoginView(NotAuthedControl1, userPanel);

        if (userPanel.Visible)
        {
            populateMessages();
        }
    }

    private void populateMessages()
    {
        int count = messageTable.Rows.Count;
        for (int i = 1; i < count; i++)
        {
            messageTable.Rows.RemoveAt(1);
        }
        
        User user = Common.GetCurrentUser();
        Message[] msgs;
        Message[] msgs2 = null;
        if((MsgFilterTypes)msgTypeDDL.SelectedIndex == MsgFilterTypes.Sent)
            msgs = Common.GetWebService().MessageSentByUser(user.id);
        else
        {
            msgs = Common.GetWebService().MessageRecvByUser(user.id, MessageDestinationType.User);
            if ((MsgFilterTypes)msgTypeDDL.SelectedIndex == MsgFilterTypes.All)
                msgs2 = Common.GetWebService().MessageSentByUser(user.id);
        }
        
        //Message[] msgs3 = msgs;
        Dictionary<int, int> ids = new Dictionary<int, int>();

        for (int i = 0; i < msgs.Length; i++)
        {
            ids.Add(msgs[i].id, msgs[i].id);
        }
        ArrayList ar = new ArrayList(msgs);
        if (msgs2 != null)
        {
            /*msgs3 = new Message[msgs.Length + msgs2.Length];
            for (int i = 0; i < msgs.Length; i++)
                msgs3[i] = msgs[i];
            for (int i = 0; i < msgs2.Length; i++)
                msgs3[i + msgs.Length] = msgs2[i];*/
            for (int i = 0; i < msgs2.Length; i++)
            {
                if (!ids.ContainsKey(msgs2[i].id))
                {
                    ids.Add(msgs2[i].id, msgs2[i].id);
                    ar.Add(msgs2[i]);
                }
            }
        }
        object[] msgs3 = ar.ToArray();

        foreach (Object mm in msgs3)
        {
            Message m = (Message)mm;

            TableRow tr = tableRowFromMessage(m, true, false);

            // Commented out support for Unread vs Read vs All
            /*if(((MsgViews)msgViewDDL.SelectedIndex == MsgViews.Read && !m.unread) ||
               ((MsgViews)msgViewDDL.SelectedIndex == MsgViews.Unread && m.unread) ||
               (MsgViews)msgViewDDL.SelectedIndex == MsgViews.All)*/
            messageTable.Rows.Add(tr);

        }
    }
    private TableRow tableRowFromMessage(Message m, bool link, bool border)
    {
        int selMsgId = -1;
        if (msgIdLabel.Text != null && msgIdLabel.Text.Length > 0)
            selMsgId = Convert.ToInt32(msgIdLabel.Text);

        TableRow tr = new TableRow();
        TableCell unread = new TableCell();
        Label ul = new Label();
        if (m.unread) ul.Text = "X";
        unread.Controls.Add(ul);
        unread.HorizontalAlign = HorizontalAlign.Center;
        if (border)
        {
            unread.BorderStyle = BorderStyle.Solid;
        }
        tr.Cells.Add(unread);
        TableCell date = new TableCell();
        Label dl = new Label();
        dl.Text = m.date.ToString();
        date.Controls.Add(dl);
        if (border)
        {
            date.BorderStyle = BorderStyle.Solid;
        }
        tr.Cells.Add(date);
        TableCell sender = new TableCell();
        Label sl = new Label();
        int userid = m.src_id;
        String un = Common.GetWebService().UserGetById(userid).username;
        sl.Text = un;
        sl.Font.Bold = m.unread;
        sl.Font.Italic = (selMsgId == m.id);
        sender.Controls.Add(sl);
        if (border)
        {
            sender.BorderStyle = BorderStyle.Solid;
        }
        tr.Cells.Add(sender);
        TableCell recipient = new TableCell();
        Label rl = new Label();
        int useridR = m.dst_id;
        String unR = Common.GetWebService().UserGetById(useridR).username;
        rl.Text = unR;
        rl.Font.Bold = m.unread;
        rl.Font.Italic = (selMsgId == m.id);
        recipient.Controls.Add(rl);
        if (border)
        {
            recipient.BorderStyle = BorderStyle.Solid;
        }
        tr.Cells.Add(recipient);
        TableCell subject = new TableCell();
        if (link)
        {
            LinkButton lb = new LinkButton();
            lb.Text = m.subject;
            lb.Font.Bold = m.unread;
            lb.Font.Italic = (selMsgId == m.id);
            lb.SkinID = "black";
            lb.ID = "linkButton_" + m.id;
            lb.Click += LinkButton_Click;
            if (border)
            {
                subject.BorderStyle = BorderStyle.Solid;
            }
            subject.Controls.Add(lb);
        }
        else
        {
            Label lb = new Label();
            lb.Text = m.subject;
            lb.Font.Bold = m.unread;
            lb.Font.Italic = (selMsgId == m.id);
            if (border)
            {
                subject.BorderStyle = BorderStyle.Solid;
            }
            subject.Controls.Add(lb);
        }
        Label ll = new Label();
        ll.Text = m.subject;
        tr.Cells.Add(subject);

        return tr;
    }

    protected void composeMsgLabel_Click(object sender, EventArgs e)
    {
        Server.Transfer("ComposeMessage.aspx");
    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        String id = lb.ID;
        id = id.Replace("linkButton_", "");
        int intId = Convert.ToInt32(id);
        msgIdLabel.Text = id;
        Message msg = Common.GetWebService().MessageGetById(intId);
        if (msg != null)
        {
            messageDetailPanel.Visible = true;
            messageTB.Text = msg.body;
            curMsgTable.Rows.Clear();
            curMsgTable.Rows.Add(tableRowFromMessage(msg,false, true));
            populateMessages();
        }
    }
    protected void replyButton_Click(object sender, EventArgs e)
    {
        int intId = -1;
        if(msgIdLabel.Text != null && msgIdLabel.Text.Length > 0)
            intId = Convert.ToInt32(msgIdLabel.Text);
        Server.Transfer("ComposeMessage.aspx?id=" + intId);
    }
}
