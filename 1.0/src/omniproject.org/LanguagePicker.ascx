<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguagePicker.ascx.cs" Inherits="LanguagePicker" %>

<asp:Table ID="tableId" runat="server" meta:resourcekey="tableIdResource1" CssClass="displayTable">
    <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource2" runat="server">
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource3" runat="server">
            <asp:Label ID="languageLabel" runat="server" Text="Language" meta:resourcekey="languageLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource4" runat="server">
            <asp:Label ID="KnownLabel" runat="server" Text="Known" meta:resourcekey="KnownLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource5" runat="server">
            <asp:Label ID="skillLabel" runat="server" Text="Skill*" meta:resourcekey="skillLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
</asp:Table>

