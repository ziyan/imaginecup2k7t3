<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" Inherits="SearchUser" Title="Search User" Theme="Default" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Search User">
    </asp:Label>
    <br />
    <br />
    <asp:Panel ID="userPanel" runat="server">
        <asp:Label ID="searchUserLabel" runat="server" Text="Search for:"></asp:Label>
        <asp:TextBox ID="searchUserText" runat="server"></asp:TextBox>
        <asp:Button ID="searchUserButton" runat="server" OnClick="searchUserButton_Click" Text="Search" />
        <br />
        <br />
        <asp:Label ID="searchUserNoneMessage" runat="server" Text="No users found">
        </asp:Label>
        <asp:Table ID="searchUserTable" runat="server" CssClass="displayTable">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label ID="usernameLabel" runat="server" Text="Username">
                    </asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name">
                    </asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </asp:Panel>
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>

