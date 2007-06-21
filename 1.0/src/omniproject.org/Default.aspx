<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" 
 MasterPageFile="~/OmniMaster.master" Theme="Default" Title="Omni" meta:resourcekey="PageResource1" %>

<%@ Register Src="TranslationHeader.ascx" TagName="TranslationHeader" TagPrefix="uc1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel runat="server" ID="userPanel" meta:resourcekey="userPanelResource1">
        <asp:Label ID="titleLabel1" runat="server" Text="Available Global Translations for" CssClass="title" meta:resourcekey="titleLabel1Resource1"></asp:Label>
        <asp:Label ID="displayNameLabel" runat="server" CssClass="title" meta:resourcekey="displayNameLabelResource1"></asp:Label>
        <br />
        <br />
        <uc1:TranslationHeader ID="translationHeader" runat="server" Visible="False" />
    </asp:Panel>
    <asp:Panel runat="server" ID="guestPanel" meta:resourcekey="guestPanelResource1">
        <asp:Label ID="guestTitleLabel" runat="server" Text="Welcome to Omni." CssClass="title" meta:resourcekey="guestTitleLabelResource1"></asp:Label>
        <br />
        <asp:Label ID="omniDescription" runat="server" Text="Hello! (Add description here)" Visible="False" meta:resourcekey="omniDescriptionResource1"></asp:Label>
        
        <br /> <br />
        <br /> <br />
        <br /> <br />
        <center>
            <asp:Image ID="guestLogo" runat="server" ImageUrl="~/App_Themes/Default/omnilogo_lg.gif" meta:resourcekey="guestLogoResource1" />
        </center>
    </asp:Panel>
</asp:Content>
