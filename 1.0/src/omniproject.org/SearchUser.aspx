<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" Inherits="SearchUser" Title="Search User" Theme="Default" meta:resourcekey="PageResource1"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Search User" meta:resourcekey="titleLabelResource1"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="userPanel" runat="server" meta:resourcekey="userPanelResource1">
        <asp:Label ID="searchUserLabel" runat="server" Text="Search for:" meta:resourcekey="searchUserLabelResource1"></asp:Label>
        <asp:TextBox ID="searchUserText" runat="server" meta:resourcekey="searchUserTextResource1"></asp:TextBox>
        <asp:Button ID="searchUserButton" runat="server" OnClick="searchUserButton_Click" Text="Search" meta:resourcekey="searchUserButtonResource1" />
        <br />
        <br />
        <asp:Label ID="searchUserNoneMessage" runat="server" Text="No users found" meta:resourcekey="searchUserNoneMessageResource1"></asp:Label>
        <asp:Table ID="searchUserTable" runat="server" CssClass="displayTable" meta:resourcekey="searchUserTableResource1">
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
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>

