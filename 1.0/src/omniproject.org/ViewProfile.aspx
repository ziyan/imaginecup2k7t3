<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" Title="User Profile" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc3" %>

<asp:Content ID="mainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel runat="server" ID="userPanel" meta:resourcekey="userPanelResource1">
        <asp:Label ID="profileLabel" runat="server" Text="User Profile" CssClass="title" meta:resourcekey="profileLabelResource1"></asp:Label>
        <asp:Label ID="profileEndingLabel" runat="server" Text="'s Profile" CssClass="title" Visible="False" meta:resourcekey="profileEndingLabelResource1"></asp:Label>
        <br />
        <asp:Table ID="layoutTable" runat="server" meta:resourcekey="basicInfoTableResource1">
            <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name: " meta:resourcekey="displayNameLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
                    <asp:Label ID="displayNameText" runat="server" meta:resourcekey="displayNameTextResource1"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
                    <asp:Label ID="emailLabel" runat="server" Text="Email:" meta:resourcekey="emailLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource4" runat="server">
                    <asp:Label ID="emailText" runat="server" meta:resourcekey="emailTextResource1"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource3" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource5" runat="server">
                    <asp:Label ID="descriptionLabel" runat="server" Text="Description: " meta:resourcekey="descriptionLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource6" runat="server">
                    <asp:Label ID="descriptionText" runat="server" meta:resourcekey="descriptionTextResource1"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="languagesLabel" runat="server" Text="Languages: " meta:resourcekey="languagesLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Table ID="languagesTable" runat="server" meta:resourcekey="languagesTableResource1" CssClass="displayTable">
                        <asp:TableHeaderRow ID="TableHeaderRow1" meta:resourcekey="TableHeaderRowResource1" runat="server">
                            <asp:TableHeaderCell ID="TableHeaderCell1" meta:resourcekey="TableHeaderCellResource1" runat="server">Language</asp:TableHeaderCell>
                            <asp:TableHeaderCell ID="TableHeaderCell2" meta:resourcekey="TableHeaderCellResource2" runat="server">User Rating</asp:TableHeaderCell>
                            <asp:TableHeaderCell ID="TableHeaderCell3" meta:resourcekey="TableHeaderCellResource3" runat="server">System Rating</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <asp:Label ID="languagesNoneMessage" runat="server" Text="None" Visible="False" meta:resourcekey="languagesNoneMessageResource1"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="interestsLabel" runat="server" Text="Interests:" meta:resourcekey="interestsLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Table ID="interestsTable" runat="server" meta:resourcekey="interestsTableResource1" CssClass="displayTable">
                    </asp:Table>
                    <asp:Label ID="interestsNoneMessage" runat="server" Text="None" Visible="False" meta:resourcekey="interestsNoneMessageResource1"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="addFavorite" runat="server" OnClick="addFavorite_Click" Text="Add Favorite" meta:resourcekey="addFavoriteResource1" />
        <asp:Button ID="removeFavorite" runat="server" OnClick="removeFavorite_Click" Text="Remove Favorite" meta:resourcekey="removeFavoriteResource1" />
        <asp:Button ID="sendMessage" runat="server" OnClick="sendMessage_Click" Text="Send Message" meta:resourcekey="sendMessageResource1" />
    </asp:Panel>
    <br />
    <uc3:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>
