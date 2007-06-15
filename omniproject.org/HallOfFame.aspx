<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="HallOfFame.aspx.cs" Inherits="HallOfFame" Title="Hall Of Fame" Theme="Default"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Hall Of Fame">
    </asp:Label>
    <br />
    <br />
    <asp:Panel ID="userPanel" runat="server">
        
    </asp:Panel>
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>