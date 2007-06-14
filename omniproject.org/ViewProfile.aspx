<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" Title="User Profile" Theme="Default"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc3" %>

<asp:Content ID="mainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel runat="server" ID="userPanel">
        <asp:Label ID="profileLabel" runat="server" Text="User Profile" CssClass="title"></asp:Label>
        <br />
        <asp:Table ID="basicInfoTable" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name: ">
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="displayNameText" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="emailText" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="descriptionLabel" runat="server" Text="Description: ">
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="descriptionText" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Label ID="languagesLabel" runat="server" Text="Languages: "></asp:Label>
        <asp:Table ID="languagesTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Language</asp:TableHeaderCell>
                <asp:TableHeaderCell>User Rating</asp:TableHeaderCell>
                <asp:TableHeaderCell>System Rating</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Label ID="languagesNoneMessage" runat="server" Text="None" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="interestsLabel" runat="server" Text="Interests:"></asp:Label>
        <asp:Table ID="interestsTable" runat="server">
        </asp:Table>
        <asp:Label ID="interestsNoneMessage" runat="server" Text="None" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="addFavorite" runat="server" OnClick="addFavorite_Click" Text="Add Favorite" />
        <asp:Button ID="removeFavorite" runat="server" OnClick="removeFavorite_Click" Text="Remove Favorite" />
        <asp:Button ID="sendMessage" runat="server" OnClick="sendMessage_Click" Text="Send Message" />
    </asp:Panel>
    <br />
    <uc3:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>
