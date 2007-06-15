<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" 
 MasterPageFile="~/OmniMaster.master" Theme="Default" Title="Omni" %>

<%@ Register Src="TranslationHeader.ascx" TagName="TranslationHeader" TagPrefix="uc1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel runat="server" ID="userPanel">
        <asp:Label ID="titleLabel1" runat="server" Text="Available Global Translations for" CssClass="title">
        </asp:Label>
        <asp:Label ID="displayNameLabel" runat="server" CssClass="title">
        </asp:Label>
        <br />
        <br />
        <uc1:TranslationHeader ID="translationHeader" runat="server" Visible="false" />
    </asp:Panel>
    <asp:Panel runat="server" ID="guestPanel">
        <asp:Label ID="guestTitleLabel" runat="server" Text="Welcome to Omni." CssClass="title">
        </asp:Label>
        <br />
        <asp:Label ID="omniDescription" runat="server" Text="Hello! (Add description here)">
        </asp:Label>
    </asp:Panel>
</asp:Content>
