<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguagePicker.ascx.cs" Inherits="LanguagePicker" %>

<asp:Label ID="titleId" runat="server" Text="Known Languages"></asp:Label>
<br />
<asp:Label ID="introLabel" runat="server" Text="Fill in the languages you know using the following rating system:">
</asp:Label>

<asp:Table ID="ratingTableId" runat="server">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell>
            <asp:Label ID="ratingLabel" runat="server" Text="Rating"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="descriptionLabel" runat="server" Text="Description">
            </asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="rating5Label" runat="server" Text="5 - Fluent"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="rating5Description" runat="server" Text="Able to read and write about most any topic regardless of with familiarity with topic. Understands both meaning and cultural references.">
            </asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="rating4Label" runat="server" Text="4 - Advanced"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="rating4Description" runat="server" Text="Able to read and write about most topics without language references.">
            </asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label1" runat="server" Text="3 - Intermediate"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label2" runat="server" Text="Able to read and write about most topics when using language references.">
            </asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="rating2Label" runat="server" Text="2 - Novice"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="rating2Description" runat="server" Text="Able to read and write about familiar topics while using language references.">
            </asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="rating1Label" runat="server" Text="1 - Beginner "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="rating1Description" runat="server" Text="Only able to read and write about basic personal information and social interaction.">
            </asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table ID="tableId" runat="server">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell>
            <asp:Label ID="languageLabel" runat="server" Text="Language"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="KnownLabel" runat="server" Text="Known"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="readingSkillLabel" runat="server" Text="Reading Skill">
            </asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="writingSkillLabel" runat="server" Text="Writing Skill">
            </asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
</asp:Table>
