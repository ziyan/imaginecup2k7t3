<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="TranslationDetails.aspx.cs" Inherits="TranslationDetails" 
Title="Translation Details" Theme="Default" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc2" %>
<%@ Register Src="TranslationHeader.ascx" TagName="TranslationHeader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<asp:Label ID="translationDetailsTitle" runat="server" CssClass="title" Text="Translation Details" meta:resourcekey="translationDetailsTitleResource1"></asp:Label>
<br />
    <asp:Panel ID="userPanel" runat="server" Width="100%" meta:resourcekey="userPanelResource1">
    <br /><br />
        <uc1:TranslationHeader ID="translationHeader" runat="server" Visible="False" />
        <asp:Table ID="translationDetailsTable" runat="server" meta:resourcekey="translationDetailsTableResource1" CssClass="displayTable">
        </asp:Table>

        <br /><br />
        <asp:Panel ID="ansPanel" runat="server" Width="100%">
        </asp:Panel>
        <br /><br />
        <asp:Panel ID="rePanel" runat="server" Width="100%">
           <asp:Table ID="reTable" runat="server" CssClass="displayTable">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                <asp:Label ID="reLabel" Text="Translate This Message" runat="Server"></asp:Label>
                </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow CssClass="row1">
                <asp:TableCell>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="reBox" Style="width:500px"></asp:TextBox><br />
                <asp:Button runat="server" Text="Submit My Translation"  ID="reButton" OnClick="submitTransButton_Click"/>
                </asp:TableCell>
                </asp:TableRow>
           </asp:Table>
        </asp:Panel>
        <asp:Label ID="useLabel" runat="server" Text="Use In Message" Visible="false"></asp:Label>
        <asp:Label ID="approveLabel" runat="server" Text="Approve" Visible="false"></asp:Label>

    </asp:Panel> 
    <asp:Label ID="invalidIdLabel" runat="server" Text="Error - Invalid Translation specified." Visible="False" meta:resourcekey="invalidIdLabelResource1"></asp:Label>
</asp:Content>


