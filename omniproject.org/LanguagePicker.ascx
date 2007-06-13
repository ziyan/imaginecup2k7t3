<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguagePicker.ascx.cs" Inherits="LanguagePicker" %>

<asp:Label ID="titleId" runat="server" Text="Known Languages" meta:resourcekey="titleIdResource1"></asp:Label>
<br />
<asp:Label ID="introLabel" runat="server" Text="Fill in the languages you know using the following rating system:" meta:resourcekey="introLabelResource1"></asp:Label>

<asp:Table ID="ratingTableId" runat="server" meta:resourcekey="ratingTableIdResource1">
    <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource1" runat="server">
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource1" runat="server">
            <asp:Label ID="ratingLabel" runat="server" Text="Rating" meta:resourcekey="ratingLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource2" runat="server">
            <asp:Label ID="descriptionLabel" runat="server" Text="Description" meta:resourcekey="descriptionLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
        <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
            <asp:Label ID="rating5Label" runat="server" Text="5 - Fluent" meta:resourcekey="rating5LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
            <asp:Label ID="rating5Description" runat="server" Text="Able to read and write about most any topic regardless of with familiarity with topic. Understands both meaning and cultural references." meta:resourcekey="rating5DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
        <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
            <asp:Label ID="rating4Label" runat="server" Text="4 - Advanced" meta:resourcekey="rating4LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell meta:resourcekey="TableCellResource4" runat="server">
            <asp:Label ID="rating4Description" runat="server" Text="Able to read and write about most topics without language references." meta:resourcekey="rating4DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow meta:resourcekey="TableRowResource3" runat="server">
        <asp:TableCell meta:resourcekey="TableCellResource5" runat="server">
            <asp:Label ID="Label1" runat="server" Text="3 - Intermediate" meta:resourcekey="Label1Resource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell meta:resourcekey="TableCellResource6" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Able to read and write about most topics when using language references." meta:resourcekey="Label2Resource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow meta:resourcekey="TableRowResource4" runat="server">
        <asp:TableCell meta:resourcekey="TableCellResource7" runat="server">
            <asp:Label ID="rating2Label" runat="server" Text="2 - Novice" meta:resourcekey="rating2LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell meta:resourcekey="TableCellResource8" runat="server">
            <asp:Label ID="rating2Description" runat="server" Text="Able to read and write about familiar topics while using language references." meta:resourcekey="rating2DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow meta:resourcekey="TableRowResource5" runat="server">
        <asp:TableCell meta:resourcekey="TableCellResource9" runat="server">
            <asp:Label ID="rating1Label" runat="server" Text="1 - Beginner " meta:resourcekey="rating1LabelResource1"></asp:Label>
        </asp:TableCell>
        <asp:TableCell meta:resourcekey="TableCellResource10" runat="server">
            <asp:Label ID="rating1Description" runat="server" Text="Only able to read and write about basic personal information and social interaction." meta:resourcekey="rating1DescriptionResource1"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table ID="tableId" runat="server" meta:resourcekey="tableIdResource1">
    <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource2" runat="server">
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource3" runat="server">
            <asp:Label ID="languageLabel" runat="server" Text="Language" meta:resourcekey="languageLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource4" runat="server">
            <asp:Label ID="KnownLabel" runat="server" Text="Known" meta:resourcekey="KnownLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource5" runat="server">
            <asp:Label ID="skillLabel" runat="server" Text="Skill" meta:resourcekey="skillLabelResource1"></asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
</asp:Table>
