<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" 
CodeFile="MyMessages.aspx.cs" Inherits="MyMessages" 
Title="My Messages" Theme="Default" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="myMessagesTitleLabel" runat="server" CssClass="title" Text="My Messages" meta:resourcekey="myMessagesTitleLabelResource1"></asp:Label><br />
    <br />
    <asp:Panel ID="userPanel" runat="server" meta:resourcekey="userPanelResource1">
        <asp:Button ID="composeMsgLabel" runat="server" Text="Compose a New Message" OnClick="composeMsgLabel_Click" meta:resourcekey="composeMsgLabelResource1" /><br />
        <br />
        <asp:Label ID="viewMsgsLabel" runat="server" CssClass="subtitle" Text="View Messages" meta:resourcekey="viewMsgsLabelResource1"></asp:Label><br />
        <asp:Panel ID="searchPanel" runat="server" meta:resourcekey="searchPanelResource1">
            <asp:Label ID="searchLabel" runat="server" Text="Search Text: " meta:resourcekey="searchLabelResource1"></asp:Label>
            <asp:TextBox ID="searchTB" runat="server" meta:resourcekey="searchTBResource1"></asp:TextBox>
            &nbsp;<asp:Button ID="searchButton" runat="server" Text="Search" meta:resourcekey="searchButtonResource1" />&nbsp;
        </asp:Panel>
        <asp:Label ID="messageTypeLabel" runat="server" Text="Message Type: " meta:resourcekey="messageTypeLabelResource1"></asp:Label>
        <asp:DropDownList ID="msgTypeDDL" runat="server" AutoPostBack="True" meta:resourcekey="msgTypeDDLResource1">
            <asp:ListItem Selected="True" meta:resourcekey="ListItemResource1">Received</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource2">Sent</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource3">All</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="viewLabel" runat="server" Text="View Messages: " Visible="False" meta:resourcekey="viewLabelResource1"></asp:Label>
        <asp:DropDownList ID="msgViewDDL" runat="server" Visible="False" meta:resourcekey="msgViewDDLResource1">
            <asp:ListItem Selected="True" meta:resourcekey="ListItemResource4">Unread</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource5">Read</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource6">All</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<br />
        <asp:Label ID="unreadMsgLabel" runat="server" Text="Unread" Visible="False" meta:resourcekey="unreadMsgLabelResource1"></asp:Label> 
        <asp:Label ID="dateMsgLabel" runat="server" Text="Date" Visible="False" meta:resourcekey="dateMsgLabelResource1"></asp:Label> 
        <asp:Label ID="senderMsgLabel" runat="server" Text="Sender" Visible="False" meta:resourcekey="senderMsgLabelResource1"></asp:Label>
        <asp:Label ID="recipientMsgLabel" runat="server" Text="Recipient" Visible="False" meta:resourcekey="recipientMsgLabelResource1"></asp:Label> 
        <asp:Label ID="subjectMsgLabel" runat="server" Text="Subject" Visible="False" meta:resourcekey="subjectMsgLabelResource1"></asp:Label>         
        <asp:Table CssClass="displayTable" ID="messageTable" runat="server" meta:resourcekey="messageTableResource1">
        </asp:Table>
        <br />
        <asp:Panel ID="messageDetailPanel" runat="server" Visible="False" meta:resourcekey="messageDetailPanelResource1">
            <asp:Label ID="messageDetailsLabel" runat="server" Text="Message Details:" meta:resourcekey="messageDetailsLabelResource1"></asp:Label>
            <asp:Table CssClass="displayTable" ID="curMsgTable" runat="server" meta:resourcekey="curMsgTableResource1">
            </asp:Table>
            <asp:Label ID="msgIdLabel" runat="server" Visible="False" meta:resourcekey="msgIdLabelResource1"></asp:Label><br />
            <asp:Button ID="replyButton" runat="server" Text="Reply to Sender" OnClick="replyButton_Click" meta:resourcekey="replyButtonResource1" />
            <asp:Button ID="requestTransButton" runat="server" Text="Request Translation" meta:resourcekey="requestTransButtonResource1" />
            </asp:Panel>
        </asp:Panel>
    <uc1:NotAuthedControl ID="NotAuthedControl1" runat="server" />
    <br />
    &nbsp;<br />
    <br />
</asp:Content>

