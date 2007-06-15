<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true"
 CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" Title="Login" Theme="Default"  meta:resourcekey="PageResource1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="loginLabel" runat="server" Text="Login" CssClass="title" meta:resourcekey="loginLabelResource1"></asp:Label><br />
    <asp:Panel ID="loginPanel" runat="server" meta:resourcekey="loginPanelResource1">
        <asp:Table ID="loginTable" runat="server" meta:resourcekey="loginTableResource1">
            <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                    <asp:Label ID="usernameLabel" runat="server" Text="Username:" meta:resourcekey="usernameLabel"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
                    <asp:TextBox ID="usernameTB" runat="server" meta:resourcekey="usernameTBResource1"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
                    <asp:Label ID="passwordLabel" runat="server" Text="Password:" meta:resourcekey="passwordLabel"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource4" runat="server">
                    <asp:TextBox ID="passwordTB" runat="server" TextMode="Password" meta:resourcekey="passwordTBResource1"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" meta:resourcekey="loginButton"/>
        <asp:Button ID="registerButton" runat="server" OnClick="registerButton_Click" Text="Register" />
        <asp:Label ID="errorLabel" runat="server" Text="Invalid credentials." Visible="False" meta:resourcekey="errorLabelResource1"></asp:Label>
    </asp:Panel>
    <asp:Label ID="alreadyLoggedInLabel" runat="server" Text="You are already logged in." Visible="False" meta:resourcekey="alreadyLoggedInLabelResource1"></asp:Label>
</asp:Content>

