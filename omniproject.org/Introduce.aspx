<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="Introduce.aspx.cs" Inherits="Introduce" Title="Introduce" Theme="Default"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Introduce">
    </asp:Label>
    <br />
    <asp:Panel ID="userPanel" runat="server">
        <asp:Label ID="introduceCountLabel" runat="server" Text="Maximum number of users in introduction"></asp:Label>
        <asp:TextBox ID="introduceCountText" runat="server"></asp:TextBox>
        <asp:Button ID="introduceButton" runat="server" Text="Introduce" OnClick="introduceButton_Click" />
        <asp:Table ID="introduceTable" runat="server">
        </asp:Table>
    </asp:Panel>
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>