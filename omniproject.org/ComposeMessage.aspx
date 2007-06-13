<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="ComposeMessage.aspx.cs" Inherits="ComposeMessage" 
Title="Compose a Message" Theme="Default" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel ID="userPanel" runat="server" Width="100%">
        <asp:Label ID="composeTitleLabel" runat="server" CssClass="title" Text="Compose Message"></asp:Label>
        <br />
        <asp:Button ID="toButton" runat="server" Text="To: " />
        <asp:TextBox ID="toTB" runat="server"></asp:TextBox><br />
        <asp:Label ID="subjectLabel" runat="server" Text="Subject:"></asp:Label>
        <asp:TextBox ID="subjectTB" runat="server"></asp:TextBox><br />
        <asp:Label ID="messageTextLabel" runat="server" Text="Message:"></asp:Label><br />
        <asp:TextBox ID="messageTB" runat="server" Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox><br />
        <asp:Button ID="sendButton" runat="server" OnClick="sendButton_Click" Text="Send Message" /></asp:Panel>
    <uc1:NotAuthedControl ID="NotAuthedControl1" runat="server" />

</asp:Content>

