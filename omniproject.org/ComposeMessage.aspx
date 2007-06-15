<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="ComposeMessage.aspx.cs" Inherits="ComposeMessage" 
Title="Compose a Message" Theme="Default" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel ID="userPanel" runat="server" Width="100%" meta:resourcekey="userPanelResource1">
        <asp:Label ID="composeTitleLabel" runat="server" CssClass="title" Text="Compose Message" meta:resourcekey="composeTitleLabelResource1"></asp:Label>
        <br />
        <asp:Table ID="headerTable" runat="server" meta:resourcekey="headerTableResource1">
        <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
        <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
            <asp:Label ID="toButton" runat="server" Text="To: " meta:resourcekey="toButtonResource1" />
        </asp:TableCell>
        <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
            <asp:DropDownList ID="toDDL" runat="server" Width="190px" OnSelectedIndexChanged="toDDL_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="toTB" runat="server" Columns="25" MaxLength="50" meta:resourcekey="toTBResource1"></asp:TextBox>
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
        <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
            <asp:Label ID="subjectLabel" runat="server" Text="Subject:" meta:resourcekey="subjectLabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell meta:resourcekey="TableCellResource4" runat="server">
<asp:TextBox ID="subjectTB" runat="server" Columns="50" MaxLength="255" meta:resourcekey="subjectTBResource1"></asp:TextBox>        
        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Label ID="messageTextLabel" runat="server" Text="Message:" meta:resourcekey="messageTextLabelResource1"></asp:Label><br />
        <asp:TextBox ID="messageTB" runat="server" Rows="10" TextMode="MultiLine" Width="95%" meta:resourcekey="messageTBResource1"></asp:TextBox><br />
        &nbsp;<br />
        <asp:Button ID="sendButton" runat="server" OnClick="sendButton_Click" Text="Send Message" meta:resourcekey="sendButtonResource1" /><br />
        <asp:Label ID="missingSubjectLabel" runat="server" Text="Error: Subject field is required." Visible="false" meta:resourcekey="missingSubjectLabelResource1"></asp:Label><br />
        <asp:Label ID="invalidUsernameLabel" runat="server" Text="Error: Invalid username entered." Visible="false" meta:resourcekey="invalidUsernameLabelResource1"></asp:Label></asp:Panel>
    <uc1:NotAuthedControl ID="NotAuthedControl1" runat="server" />

</asp:Content>

