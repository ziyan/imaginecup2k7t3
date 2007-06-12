<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="AutomaticTranslation.aspx.cs" Inherits="AutomaticTranslation" Title="Automatic Translation" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Automatic Translations"></asp:Label>
    <br />
    <table>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Source Language"></asp:Label></td>
            <td><asp:Label ID="Label3" runat="server" Text="Destination Language"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList></td>
            <td><asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList></td>
        </tr>
    </table>
    <asp:Label ID="Label4" runat="server" Text="Original Message"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox><br />
    &nbsp;<asp:Button ID="Button1" runat="server" Text="Translate" /><br />
    <asp:Label ID="Label6" runat="server" Text="Translated Message"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
</asp:Content>

