<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="RegisterAccount.aspx.cs" Inherits="RegisterAccount"
 Title="Register an Account" Theme="Default" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="regTitleLabel" runat="server" Text="Register an Account" CssClass="title" meta:resourcekey="regTitleLabelResource1"></asp:Label><br />
    <br />
    <asp:Table ID="registrationTable" runat="server" meta:resourcekey="registrationTableResource1" >
    <asp:TableRow runat="server" meta:resourcekey="TableRowResource1">
    <asp:TableCell runat="server" meta:resourcekey="TableCellResource1">
    <asp:Label ID="usernameLabel" runat="server" Text="Username" Width="140px" meta:resourcekey="usernameLabelResource1" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server" meta:resourcekey="TableCellResource2">
    <asp:TextBox CausesValidation="True"  ID="usernameTB" runat="server" meta:resourcekey="usernameTBResource1" ></asp:TextBox> 
    <asp:RequiredFieldValidator Display="Dynamic" ID="usernameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="usernameTB">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="usernameRegularExpressionValidator" runat="server" ErrorMessage="!" ControlToValidate="usernameTB" ValidationExpression="[0-9A-Za-z]{3,}"></asp:RegularExpressionValidator>
    </asp:TableCell></asp:TableRow>
    
    <asp:TableRow runat="server" meta:resourcekey="TableRowResource3">
    <asp:TableCell runat="server" meta:resourcekey="TableCellResource5">
    <asp:Label ID="passwordLabel" runat="server" Text="Password" Width="140px" meta:resourcekey="passwordLabelResource1" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server" meta:resourcekey="TableCellResource6">
    <asp:TextBox CausesValidation="True" ID="passwordTB" runat="server" TextMode="Password" meta:resourcekey="passwordTBResource1" ></asp:TextBox> 
    <asp:RequiredFieldValidator Display="Dynamic" ID="passwordRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="passwordTB">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="passwordRegularExpressionValidator" runat="server" ErrorMessage="!" ControlToValidate="passwordTB" ValidationExpression="[\S\s]{6,}"></asp:RegularExpressionValidator>
    </asp:TableCell></asp:TableRow>
    <asp:TableRow runat="server" meta:resourcekey="TableRowResource4">
    <asp:TableCell runat="server" meta:resourcekey="TableCellResource7">
    <asp:Label ID="confirmPasswordLabel" runat="server" Text="Confirm Password" Width="140px" meta:resourcekey="confirmPasswordLabelResource1" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server" meta:resourcekey="TableCellResource8">
    <asp:TextBox ID="confirmPasswordTB" runat="server" CausesValidation="True" TextMode="Password" meta:resourcekey="confirmPasswordTBResource1" ></asp:TextBox> <asp:CompareValidator runat="server" ID="comparePasswordValidator"
    Display="Dynamic"
    ControlToValidate="confirmPasswordTB"
    ControlToCompare="passwordTB"
    Text="!" meta:resourcekey="comparePasswordValidatorResource1" ></asp:CompareValidator>
    </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="TableRow1" runat="server" meta:resourcekey="TableRowResource2">
    <asp:TableCell ID="TableCell1" runat="server" meta:resourcekey="TableCellResource3">
    <asp:Label　ID="emailLabel" runat="server" Text="E-Mail Address" Width="140px" meta:resourcekey="emailLabelResource1" ></asp:Label>
    </asp:TableCell><asp:TableCell ID="TableCell2" runat="server" meta:resourcekey="TableCellResource4">
    <asp:TextBox CausesValidation="True" ID="emailTB" runat="server" meta:resourcekey="emailTBResource1" ></asp:TextBox> 
    <asp:RequiredFieldValidator Display="Dynamic" ID="emailRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="emailTB"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="emailRegularExpressionValidator" runat="server" ErrorMessage="!" ControlToValidate="emailTB" ValidationExpression="[a-zA-Z0-9_\-\.]+\@([a-zA-Z0-9\-]+\.)+[a-zA-Z]+"></asp:RegularExpressionValidator>
    
    </asp:TableCell></asp:TableRow>
    <asp:TableRow runat="server" meta:resourcekey="TableRowResource5">
    <asp:TableCell runat="server" meta:resourcekey="TableCellResource9">
    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name" Width="140px" meta:resourcekey="displayNameLabelResource1" ></asp:Label>
    </asp:TableCell><asp:TableCell runat="server" meta:resourcekey="TableCellResource10">
    <asp:TextBox CausesValidation="True" ID="displayNameTB" runat="server" meta:resourcekey="displayNameTBResource1" ></asp:TextBox> 
    <asp:RequiredFieldValidator Display="Dynamic" ID="displayRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="displayNameTB">
    </asp:RequiredFieldValidator>
    </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Label ID="profileDescLabel" runat="server" Text="Profile Description" Width="140px" meta:resourcekey="profileDescLabelResource1" ></asp:Label><br />
    <asp:TextBox ID="profileDescTB" runat="server" TextMode="MultiLine" Rows="5" Columns="50" meta:resourcekey="profileDescTBResource1"></asp:TextBox><br />
    <br />
    <asp:Label ID="acctVerifyLabel" runat="server" Text="Account Verification" meta:resourcekey="acctVerifyLabelResource1" ></asp:Label><br />
    <asp:Image ID="captchaImage" runat="server" ImageUrl="Handler/CaptchaHandler.ashx?w=250&h=75&bc=white&fc=black" meta:resourcekey="captchaImageResource1" /><br />
    <asp:Label ID="captchaInstrLabel" runat="server" Text="Enter the text from the above image." meta:resourcekey="captchaInstrLabelResource1" ></asp:Label><br />
    <asp:TextBox CausesValidation="True" ID="captchaTB" runat="server" meta:resourcekey="captchaTBResource1" MaxLength="5"></asp:TextBox>
    <asp:RequiredFieldValidator Display="Dynamic" ID="captchaRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="captchaTB">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="captchaRegularExpressionValidator" runat="server" ErrorMessage="!" ControlToValidate="captchaTB" ValidationExpression="[a-zA-Z0-9]{5}"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Button ID="registerAccountButton" runat="server" OnClick="registerAccountButton_Click" Text="Register Account" meta:resourcekey="registerAccountButtonResource1" /><br />
    <br />
    <asp:Label ID="duplicateLabel" runat="server" Text="Error - This user or email already exists." Visible="False" meta:resourcekey="duplicateLabelResource1"></asp:Label>
    <asp:Label ID="invalidCaptchaLabel" runat="server" Text="Error - Your text from the image is invalid." Visible="False" meta:resourcekey="invalidCaptchaLabelResource1"></asp:Label>
</asp:Content>

