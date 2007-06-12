<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" 
CodeFile="SelectPreferredLanguage.aspx.cs" Inherits="SelectPreferredLanguage" 
Title="Select your Preferred Language" Theme="Default" %>

<%@ Register Src="LanguageSelector.ascx" TagName="LanguageSelector" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <uc1:LanguageSelector ID="LanguageSelector1" runat="server" />

</asp:Content>

