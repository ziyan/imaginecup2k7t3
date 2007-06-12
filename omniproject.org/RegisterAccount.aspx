<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="RegisterAccount.aspx.cs" Inherits="RegisterAccount"
 Title="Register an Account" Theme="Default" Culture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="regTitleLabel" runat="server" Text="Register an Account" CssClass="title"></asp:Label><br />
    <asp:Table ID="registrationTable" runat="server" >
    <asp:TableRow runat="server">
    <asp:TableCell runat="server">
    <asp:Label ID="usernameLabel" runat="server" Text="Username" Width="140px" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server">
    <asp:TextBox ID="usernameTB" runat="server" ></asp:TextBox><br />
    </asp:TableCell></asp:TableRow>
    <asp:TableRow runat="server">
    <asp:TableCell runat="server">
    <asp:Label ID="emailLabel" runat="server" Text="E-Mail Address" Width="140px" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server">
    <asp:TextBox ID="emailTB" runat="server" ></asp:TextBox><br />
    </asp:TableCell></asp:TableRow>
    <asp:TableRow runat="server">
    <asp:TableCell runat="server">
    <asp:Label ID="passwordLabel" runat="server" Text="Password" Width="140px" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server">
    <asp:TextBox ID="passwordTB" runat="server" CausesValidation="True" TextMode="Password" ></asp:TextBox><br />
    </asp:TableCell></asp:TableRow>
    <asp:TableRow runat="server">
    <asp:TableCell runat="server">
    <asp:Label ID="confirmPasswordLabel" runat="server" Text="Confirm Password" Width="140px" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server">
    <asp:TextBox ID="confirmPasswordTB" runat="server" CausesValidation="True" TextMode="Password" ></asp:TextBox>
    <asp:CompareValidator runat="server" ID="comparePasswordValidator"
    Display="Dynamic"
    ControlToValidate="confirmPasswordTB"
    ControlToCompare="passwordTB"
    Text="Error: Passwords must match." ></asp:CompareValidator>
    </asp:TableCell></asp:TableRow>
    <asp:TableRow runat="server">
    <asp:TableCell runat="server">
    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name" Width="140px" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server">
    <asp:TextBox ID="displayNameTB" runat="server" ></asp:TextBox><br />
    </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <asp:Label ID="profileDescLabel" runat="server" Text="Profile Description" Width="140px" ></asp:Label><br />
    <asp:TextBox ID="profileDescTB" runat="server" TextMode="MultiLine" Rows="5" Columns="50" ></asp:TextBox><br />
    <br />
    <asp:Label ID="acctVerifyLabel" runat="server" Text="Account Verification" ></asp:Label><br />
    <asp:Image ID="captchaImage" runat="server" ImageUrl="Handler/CaptchaHandler.ashx?w=250&h=75&bc=white&fc=black" /><br />
    <asp:Label ID="captchaInstrLabel" runat="server" Text="Enter the text from the above image." ></asp:Label><br />
    <asp:TextBox ID="captchaTB" runat="server" ></asp:TextBox><br />
    <br />
    <asp:Button ID="registerAccountButton" runat="server" OnClick="registerAccountButton_Click" Text="Register Account" />
</asp:Content>

