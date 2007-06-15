<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" Inherits="SearchUser" Title="Search User" Theme="Default" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Search User">
    </asp:Label>
    <br />
    <br />
    <asp:Panel ID="userPanel" runat="server">
        
    </asp:Panel>
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>

