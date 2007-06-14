<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="MyFavorites.aspx.cs" Inherits="MyFavorites" Title="My Favorites" Theme="Default"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="My Favorites">
    </asp:Label>
    <br />
    <asp:Panel ID="userPanel" runat="server">
        <asp:Table ID="favoritesTable" runat="server">
        </asp:Table>
    </asp:Panel>
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>

