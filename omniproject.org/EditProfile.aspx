<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" Title="Untitled Page" Theme="Default"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc3" %>

<%@ Register Src="LanguagePicker.ascx" TagName="LanguagePicker" TagPrefix="uc1" %>
<%@ Register Src="InterestsPicker.ascx" TagName="InterestsPicker" TagPrefix="uc2" %>
<asp:Content ID="mainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="profileLabel" runat="server" Text="My Profile" CssClass="title"></asp:Label>
    <br />
    <asp:Panel runat="server" ID="userPanel">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="usernameLabel" runat="server" Text="Username: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="usernameValueLabel" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name: ">
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="displayNameText" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="emailText" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="descriptionLabel" runat="server" Text="Description: ">
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="descriptionText" runat="server" TextMode="MultiLine">
                    </asp:TextBox>
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
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" />
        <asp:Button ID="cancelButton" runat="server" OnClick="cancelButton_Click" Text="Cancel" />
    </asp:Panel>
    <br />
    <uc3:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>

