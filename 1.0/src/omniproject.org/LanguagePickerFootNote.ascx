<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguagePickerFootNote.ascx.cs" Inherits="LanguagePickerFootNote" %>

<asp:Label ID="introLabel" runat="server" Font-Bold="True" Text="*Skill rating table:" meta:resourcekey="introLabelResource1"></asp:Label>

<asp:Table ID="ratingTableId" runat="server" meta:resourcekey="ratingTableIdResource1" CssClass="displayTable">
    <asp:TableHeaderRow ID="TableHeaderRow1" meta:resourcekey="TableHeaderRowResource1" runat="server">
        <asp:TableHeaderCell ID="TableHeaderCell1" meta:resourcekey="TableHeaderCellResource1" runat="server">
            <asp:Label ID="ratingLabel" runat="server" Text="Rating" meta:resourcekey="ratingLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell2" meta:resourcekey="TableHeaderCellResource2" runat="server">
            <asp:Label ID="descriptionLabel" runat="server" Text="Description" meta:resourcekey="descriptionLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow ID="TableRow1" meta:resourcekey="TableRowResource1" runat="server" CssClass="row1">
        <asp:TableCell ID="TableCell1" meta:resourcekey="TableCellResource1" runat="server">
            <asp:Label ID="rating5Label" runat="server" Text="5 - Fluent" meta:resourcekey="rating5LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell2" meta:resourcekey="TableCellResource2" runat="server">
            <asp:Label ID="rating5Description" runat="server" Text="Able to read and write about most any topic regardless of with familiarity with topic. Understands both meaning and cultural references." meta:resourcekey="rating5DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow2" meta:resourcekey="TableRowResource2" runat="server" CssClass="row2">
        <asp:TableCell ID="TableCell3" meta:resourcekey="TableCellResource3" runat="server">
            <asp:Label ID="rating4Label" runat="server" Text="4 - Advanced" meta:resourcekey="rating4LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell4" meta:resourcekey="TableCellResource4" runat="server">
            <asp:Label ID="rating4Description" runat="server" Text="Able to read and write about most topics without language references." meta:resourcekey="rating4DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow3" meta:resourcekey="TableRowResource3" runat="server" CssClass="row1">
        <asp:TableCell ID="TableCell5" meta:resourcekey="TableCellResource5" runat="server">
            <asp:Label ID="Label1" runat="server" Text="3 - Intermediate" meta:resourcekey="Label1Resource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell6" meta:resourcekey="TableCellResource6" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Able to read and write about most topics when using language references." meta:resourcekey="Label2Resource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow4" meta:resourcekey="TableRowResource4" runat="server" CssClass="row2">
        <asp:TableCell ID="TableCell7" meta:resourcekey="TableCellResource7" runat="server">
            <asp:Label ID="rating2Label" runat="server" Text="2 - Novice" meta:resourcekey="rating2LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell8" meta:resourcekey="TableCellResource8" runat="server">
            <asp:Label ID="rating2Description" runat="server" Text="Able to read and write about familiar topics while using language references." meta:resourcekey="rating2DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow5" meta:resourcekey="TableRowResource5" runat="server" CssClass="row1">
        <asp:TableCell ID="TableCell9" meta:resourcekey="TableCellResource9" runat="server">
            <asp:Label ID="rating1Label" runat="server" Text="1 - Beginner " meta:resourcekey="rating1LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell10" meta:resourcekey="TableCellResource10" runat="server">
            <asp:Label ID="rating1Description" runat="server" Text="Only able to read and write about basic personal information and social interaction." meta:resourcekey="rating1DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
