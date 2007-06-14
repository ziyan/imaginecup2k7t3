<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" Title="Edit Profile" Theme="Default" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc3" %>

<%@ Register Src="LanguagePicker.ascx" TagName="LanguagePicker" TagPrefix="uc1" %>
<%@ Register Src="InterestsPicker.ascx" TagName="InterestsPicker" TagPrefix="uc2" %>
<asp:Content ID="mainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel runat="server" ID="userPanel" meta:resourcekey="userPanelResource1">
        <asp:Label ID="profileLabel" runat="server" Text="My Profile" CssClass="title" meta:resourcekey="profileLabelResource1"></asp:Label>
        <br />
        <asp:Table ID="Table1" runat="server" meta:resourcekey="Table1Resource1">
            <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                    <asp:Label ID="usernameLabel" runat="server" Text="Username: " meta:resourcekey="usernameLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
                    <asp:Label ID="usernameValueLabel" runat="server" meta:resourcekey="usernameValueLabelResource1"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
                    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name: " meta:resourcekey="displayNameLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource4" runat="server">
                    <asp:TextBox ID="displayNameText" runat="server" meta:resourcekey="displayNameTextResource1"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource3" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource5" runat="server">
                    <asp:Label ID="emailLabel" runat="server" Text="Email:" meta:resourcekey="emailLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource6" runat="server">
                    <asp:TextBox ID="emailText" runat="server" meta:resourcekey="emailTextResource1"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource4" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource7" runat="server">
                    <asp:Label ID="descriptionLabel" runat="server" Text="Description: " meta:resourcekey="descriptionLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource8" runat="server">
                    <asp:TextBox ID="descriptionText" runat="server" TextMode="MultiLine" meta:resourcekey="descriptionTextResource1"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        <uc1:LanguagePicker ID="languagePicker" runat="server" />
        <br />
        <br />
        <uc2:InterestsPicker ID="interestsPicker" runat="server" />
        <br />
        <br />
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" meta:resourcekey="saveButtonResource1" />
        <asp:Button ID="cancelButton" runat="server" OnClick="cancelButton_Click" Text="Cancel" meta:resourcekey="cancelButtonResource1" />
    </asp:Panel>
    <br />
    <uc3:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>

