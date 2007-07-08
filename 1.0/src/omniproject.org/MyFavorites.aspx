<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="MyFavorites.aspx.cs" Inherits="MyFavorites" Title="My Favorites" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="My Favorites" meta:resourcekey="titleLabelResource1"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="userPanel" runat="server" meta:resourcekey="userPanelResource1">
        <asp:Table ID="favoritesTable" runat="server" CssClass="displayTable" meta:resourcekey="favoritesTableResource1">
            <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource1" runat="server">
                <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource1" runat="server">
                    <asp:Label ID="usernameLabel" runat="server" Text="Username" meta:resourcekey="usernameLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource2" runat="server">
                    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name" meta:resourcekey="displayNameLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </asp:Panel>
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>

