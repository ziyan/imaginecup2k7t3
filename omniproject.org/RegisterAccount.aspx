<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="RegisterAccount.aspx.cs" Inherits="RegisterAccount"
 Title="Register an Account" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="regTitleLabel" runat="server" Text="Register an Account"></asp:Label><br />
    <asp:Label ID="usernameLabel" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="usernameTB" runat="server"></asp:TextBox><br />
    <asp:Label ID="emailLabel" runat="server" Text="E-Mail Address"></asp:Label>
    <asp:TextBox ID="emailTB" runat="server"></asp:TextBox><br />
    <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passwordTB" runat="server" CausesValidation="True" TextMode="Password"></asp:TextBox><br />
    <asp:Label ID="confirmPasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
    <asp:TextBox ID="confirmPasswordTB" runat="server" CausesValidation="True" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator runat="server" ID="comparePasswordValidator"
    Display="Dynamic"
    ControlToValidate="confirmPasswordTB"
    ControlToCompare="passwordTB"
    Type="String"
    EnableClientScript="true"
    Text="Error: Passwords must match." ></asp:CompareValidator>
    <br />
    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name"></asp:Label>
    <asp:TextBox ID="displayNameTB" runat="server"></asp:TextBox><br />
    <asp:Label ID="profileDescLabel" runat="server" Text="Profile Description"></asp:Label><br />
    <asp:TextBox ID="profileDescTB" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox><br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Account Verification"></asp:Label><br />
    <asp:Image ID="Image1" runat="server" ImageUrl="../handler/CaptchaHandler.ashx?w=300&h=100&bc=white&fc=black" /><br />
    <asp:Button ID="registerAccountButton" runat="server" OnClick="registerAccountButton_Click" Text="Register Account" />

</asp:Content>

