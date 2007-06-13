<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" Title="Untitled Page" Theme="Default"%>

<%@ Register Src="LanguagePicker.ascx" TagName="LanguagePicker" TagPrefix="uc1" %>
<%@ Register Src="InterestsPicker.ascx" TagName="InterestsPicker" TagPrefix="uc2" %>
<asp:Content ID="mainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="profileLabel" runat="server" Text="My Profile"></asp:Label>
    <br />
    <asp:Label ID="usernameLabel" runat="server" Text="Username: "></asp:Label>
    <asp:Label ID="usernameValueLabel" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="displayNameLabel" runat="server" Text="Display Name: "></asp:Label><br />
    <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
    <br />
    <asp:Label ID="descriptionLabel" runat="server" Text="Description: "></asp:Label><br />
    <uc1:LanguagePicker ID="LanguagePicker1" runat="server" />
    <br />
    <br />
    <uc2:InterestsPicker ID="InterestsPicker1" runat="server" />
    <br />
    <br />
    <asp:Button ID="saveButton" runat="server" Text="Save" />
    <asp:Button ID="cancelButton" runat="server" Text="Cancel" />
</asp:Content>

