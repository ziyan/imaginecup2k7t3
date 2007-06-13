<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true"
 CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" Title="Login" Theme="Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="loginLabel" runat="server" Text="Login" CssClass="title"></asp:Label><br />
    <asp:Panel ID="loginPanel" runat="server">
        <asp:Table ID="loginTable" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="usernameLabel" runat="server" Text="Username:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="usernameTB" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="passwordTB" runat="server" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click"
            Width="126px" />
        <asp:Label ID="errorLabel" runat="server" Text="Invalid credentials." Visible="false"></asp:Label>
    </asp:Panel>
    <asp:Label ID="alreadyLoggedInLabel" runat="server" Text="You are already logged in." Visible="false"></asp:Label>
</asp:Content>

