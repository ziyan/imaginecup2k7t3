<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="MyTranslations.aspx.cs" Inherits="MyTranslations" 
Title="My Translations" Theme="Default" meta:resourcekey="PageResource1" %>

<%@ Register Src="TranslationHeader.ascx" TagName="TranslationHeader" TagPrefix="uc2" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="myTranslationsTitle" runat="server" CssClass="title" Text="My Translations" meta:resourcekey="myTranslationsTitleResource1"></asp:Label><br />
    <br />
    <asp:Panel ID="userPanel" runat="server" Width="100%" meta:resourcekey="userPanelResource1">
        <asp:Button ID="userFuncButton" runat="server" Text="User Functions" OnClick="userFuncButton_Click" meta:resourcekey="userFuncButtonResource1" /><asp:Button ID="translatorFuncButton" runat="server" Text="Translator Functions" OnClick="translatorFuncButton_Click" meta:resourcekey="translatorFuncButtonResource1" /><br />
        <asp:Panel ID="functionPanel" runat="server"
            Width="100%" meta:resourcekey="functionPanelResource1">
        <asp:MultiView ID="functionMultiView" runat="server" ActiveViewIndex="0">
            <asp:View ID="userFuncView" runat="server">
                <asp:Label ID="pendingRequestsLabel" runat="server" Text="Pending Requests" Font-Bold="True" meta:resourcekey="pendingRequestsLabelResource1"></asp:Label>
                <br />
                <asp:Panel ID="pendingRequestsPanel" runat="server" Width="100%" ScrollBars="Vertical" Height="200px" meta:resourcekey="pendingRequestsPanelResource1">
                    <asp:Table ID="pendingRequestsTable" runat="server" meta:resourcekey="pendingRequestsTableResource1" CssClass="displayTable">
                    </asp:Table>
                </asp:Panel>
                <br />
                <asp:Label ID="receivedTranslationsLabel" runat="server" Text="Received Translations" Font-Bold="True" meta:resourcekey="receivedTranslationsLabelResource1"></asp:Label>
                 <br />
                <asp:Panel ID="receivedTranslationsPanel" runat="server" Width="100%" ScrollBars="Vertical" Height="200px" meta:resourcekey="receivedTranslationsPanelResource1">
                    <asp:Table ID="receivedTranslationsTable" runat="server" meta:resourcekey="receivedTranslationsTableResource1" CssClass="displayTable">
                    </asp:Table>
                </asp:Panel>
                <br />
                <asp:Label ID="completedTranslationsLabel" runat="server" Text="Completed Translations" Font-Bold="True" meta:resourcekey="completedTranslationsLabelResource1"></asp:Label>
                <br />
                <asp:Panel ID="completedTranslationsPanel" runat="server" Width="100%" ScrollBars="Vertical" Height="200px" meta:resourcekey="completedTranslationsPanelResource1">
                    <asp:Table ID="completedTranslationsTable" runat="server" meta:resourcekey="completedTranslationsTableResource1" CssClass="displayTable">
                    </asp:Table>
                </asp:Panel>
            </asp:View>
            <asp:View ID="translatorFuncView" runat="server">
                <asp:Label ID="personalReqsLabel" runat="server" Font-Bold="True" Text="Personal Requests" meta:resourcekey="personalReqsLabelResource1"></asp:Label>
                <br />
                <asp:Panel ID="personalReqsPanel" runat="server" Width="100%" ScrollBars="Vertical" Height="200px" meta:resourcekey="personalReqsPanelResource1">
                    <asp:Table ID="personalReqsTable" runat="server" meta:resourcekey="personalReqsTableResource1" CssClass="displayTable">
                    </asp:Table>
                </asp:Panel>
                <br />
                <asp:Label ID="globalReqsLabel" runat="server" Font-Bold="True" Text="Global Requests" meta:resourcekey="globalReqsLabelResource1"></asp:Label>
                <br />
                <asp:Panel ID="globalReqsPanel" runat="server" Width="100%" ScrollBars="Vertical" Height="200px" meta:resourcekey="globalReqsPanelResource1">
                    <asp:Table ID="globalReqsTable" runat="server" meta:resourcekey="globalReqsTableResource1" CssClass="displayTable">
                    </asp:Table>
                </asp:Panel>
                <br />
            </asp:View>
        </asp:MultiView></asp:Panel>
        <uc2:TranslationHeader ID="translationHeader" runat="server" Visible="False" />
        </asp:Panel>
    <uc1:NotAuthedControl ID="NotAuthedControl1" runat="server" />

</asp:Content>

