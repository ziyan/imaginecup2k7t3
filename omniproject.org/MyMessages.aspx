<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" 
CodeFile="MyMessages.aspx.cs" Inherits="MyMessages" 
Title="My Messages" Theme="Default" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="myMessagesTitleLabel" runat="server" CssClass="title" Text="My Messages"></asp:Label><br />
    <br />
    <asp:Panel ID="userPanel" runat="server">
        <br />
        <asp:Button ID="composeMsgLabel" runat="server" Text="Compose a New Message" OnClick="composeMsgLabel_Click" /><br />
        <br />
        <asp:Label ID="viewMsgsLabel" runat="server" CssClass="subtitle" Text="View Messages"></asp:Label><br />
        <asp:Panel ID="searchPanel" runat="server">
            <asp:Label ID="searchLabel" runat="server" Text="Search Text: "></asp:Label>
            <asp:TextBox ID="searchTB" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="searchButton" runat="server" Text="Search" />&nbsp;
        </asp:Panel>
        <asp:Label ID="messageTypeLabel" runat="server" Text="Message Type: "></asp:Label>
        <asp:DropDownList ID="msgTypeDDL" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True">Received</asp:ListItem>
            <asp:ListItem>Sent</asp:ListItem>
            <%--<asp:ListItem>Unsent</asp:ListItem>--%>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="viewLabel" runat="server" Text="View Messages: "></asp:Label>
        <asp:DropDownList ID="msgViewDDL" runat="server" Visible="false">
            <asp:ListItem Selected="True">Unread</asp:ListItem>
            <asp:ListItem>Read</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList><br />
        &nbsp;<br />
        <asp:Table ID="messageTable" runat="server" BorderStyle="Solid" BorderWidth="1">
            <asp:TableHeaderRow runat="server"  BorderStyle="Solid" BorderWidth="1" >
                <asp:TableHeaderCell runat="server" BorderStyle="Solid" BorderWidth="1">
                    <asp:Label ID="unreadMsgLabel" runat="server" Text="Unread"></asp:Label> 
                </asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" BorderStyle="Solid" BorderWidth="1">
                    <asp:Label ID="dateMsgLabel" runat="server" Text="Date"></asp:Label> 
                </asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" BorderStyle="Solid" BorderWidth="1" Width="80">
                    <asp:Label ID="senderMsgLabel" runat="server" Text="Sender"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" BorderStyle="Solid" BorderWidth="1" Width="80">
                    <asp:Label ID="recipientMsgLabel" runat="server" Text="Recipient"></asp:Label> 
                </asp:TableHeaderCell>                
                <asp:TableHeaderCell runat="server" BorderStyle="Solid" BorderWidth="1">
                    <asp:Label ID="subjectMsgLabel" runat="server" Text="Subject"></asp:Label> 
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        <asp:Panel ID="messageDetailPanel" runat="server" Visible="false">
            <asp:Label ID="messageDetailsLabel" runat="server" Text="Message Details:"></asp:Label>
            <asp:Table ID="curMsgTable" runat="server">
            </asp:Table>
            <asp:TextBox ID="messageTB" runat="server" TextMode="MultiLine" ReadOnly="true" Rows="10"
                Columns="50"></asp:TextBox>
            <asp:Label ID="msgIdLabel" runat="server" Visible="False"></asp:Label><br />
            <asp:Button ID="replyButton" runat="server" Text="Reply to Sender" OnClick="replyButton_Click" />
            <asp:Button ID="requestTransButton" runat="server" Text="Request Translation" />
            </asp:Panel>
        <br />
        
    </asp:Panel>
    <uc1:NotAuthedControl ID="NotAuthedControl1" runat="server" />
    <br />
    &nbsp;<br />
    <br />
</asp:Content>

