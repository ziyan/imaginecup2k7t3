<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="TranslationDetails.aspx.cs" Inherits="TranslationDetails" 
Title="Translation Details" Theme="Default" meta:resourcekey="PageResource1"　%>

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
        <asp:Panel ID="ansPanel" runat="server" Width="100%" meta:resourcekey="ansPanelResource1">
        </asp:Panel>
        <br /><br />
        <asp:Panel ID="rePanel" runat="server" Width="100%" meta:resourcekey="rePanelResource1">
           <asp:Table ID="reTable" runat="server" CssClass="displayTable" meta:resourcekey="reTableResource1">
                <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource1" runat="server">
                <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource1" runat="server">
                <asp:Label ID="reLabel" Text="Translate This Message" runat="server" meta:resourcekey="reLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow CssClass="row1" meta:resourcekey="TableRowResource1" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                <asp:TextBox runat="server" TextMode="MultiLine" ID="reBox" Style="width:500px" meta:resourcekey="reBoxResource1"></asp:TextBox><br />
                <asp:Button runat="server" Text="Submit My Translation"  ID="reButton" OnClick="submitTransButton_Click" meta:resourcekey="reButtonResource1"/>
                </asp:TableCell>
                </asp:TableRow>
           </asp:Table>
        </asp:Panel>
        <asp:Label ID="useLabel" runat="server" Text="Use In Message" Visible="False" meta:resourcekey="useLabelResource1"></asp:Label>
        <asp:Label ID="approveLabel" runat="server" Text="Approve" Visible="False" meta:resourcekey="approveLabelResource1"></asp:Label>

    </asp:Panel> 
    <asp:Label ID="invalidIdLabel" runat="server" Text="Error - Invalid Translation specified." Visible="False" meta:resourcekey="invalidIdLabelResource1"></asp:Label>
</asp:Content>


