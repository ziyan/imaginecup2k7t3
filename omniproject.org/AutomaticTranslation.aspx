<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="AutomaticTranslation.aspx.cs" Inherits="AutomaticTranslation" Title="Automatic Translation" Theme="Default" Culture="auto"  %>

<asp:Content ID="placeHolderID" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" Text="Automatic Translations" CssClass="title" ></asp:Label>
    <br />
    <asp:Table ID="tableId" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="sourceLabel" runat="server" Text="Source Language"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="destinationLabel" runat="server" Text="Destination Language"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:DropDownList ID="sourceDropDown" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="destinationDropDown" runat="server"></asp:DropDownList>
             </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="OriginalMessageLabel" runat="server" Text="Original Message" ></asp:Label>
    <asp:TextBox ID="OriginalMessageText" runat="server" TextMode="MultiLine" ></asp:TextBox><br />
    &nbsp;<asp:Button ID="TranslationButton" runat="server" Text="Translate" OnClick="TranslationButton_Click"  /><br />
    <asp:Label ID="TranslatedMessageLabel" runat="server" Text="Translated Message" ></asp:Label>
    <asp:TextBox ID="TranslatedMessageText" runat="server" TextMode="MultiLine" ></asp:TextBox>
</asp:Content>

