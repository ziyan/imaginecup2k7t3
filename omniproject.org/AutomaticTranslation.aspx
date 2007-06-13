<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="AutomaticTranslation.aspx.cs" Inherits="AutomaticTranslation" Title="Automatic Translation" Theme="Default" Culture="auto"  meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="placeHolderID" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" Text="Automatic Translations" CssClass="title" meta:resourcekey="titleLabelResource1" ></asp:Label>
    <br />
    <asp:Table ID="tableId" runat="server" meta:resourcekey="tableIdResource1">
        <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
            <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                <asp:Label ID="sourceLabel" runat="server" Text="Source Language" meta:resourcekey="sourceLabelResource1"></asp:Label>
            </asp:TableCell>
            <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
                <asp:Label ID="destinationLabel" runat="server" Text="Destination Language" meta:resourcekey="destinationLabelResource1"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
            <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
                <asp:DropDownList ID="sourceDropDown" runat="server" meta:resourcekey="sourceDropDownResource1"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell meta:resourcekey="TableCellResource4" runat="server">
                <asp:DropDownList ID="destinationDropDown" runat="server" meta:resourcekey="destinationDropDownResource1"></asp:DropDownList>
             </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="OriginalMessageLabel" runat="server" Text="Original Message" meta:resourcekey="OriginalMessageLabelResource1" ></asp:Label>
    <asp:TextBox ID="OriginalMessageText" runat="server" TextMode="MultiLine" meta:resourcekey="OriginalMessageTextResource1" ></asp:TextBox><br />
    &nbsp;<asp:Button ID="TranslationButton" runat="server" Text="Translate" OnClick="TranslationButton_Click" meta:resourcekey="TranslationButtonResource1"  /><br />
    <asp:Label ID="TranslatedMessageLabel" runat="server" Text="Translated Message" meta:resourcekey="TranslatedMessageLabelResource1" ></asp:Label>
    <asp:TextBox ID="TranslatedMessageText" runat="server" TextMode="MultiLine" meta:resourcekey="TranslatedMessageTextResource1" ></asp:TextBox>
</asp:Content>

