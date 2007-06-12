<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InterestsPicker.ascx.cs" Inherits="InterestsPicker" %>
<asp:Label ID="interestsLabel" runat="server" Text="Interests"></asp:Label>
<br />
<asp:Table ID="outterTable" runat="server">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">
            <asp:Table ID="mineTable" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="mineLable" runat="server" Text="Mine"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:ListBox ID="mineListBox" runat="server"></asp:ListBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Table ID="controlTable" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Button ID="addButton" runat="server" Text="&lt; Add" OnClick="Add_Click" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Button ID="removeButton" runat="server" Text="Remove &gt;" OnClick="Remove_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Table ID="allTable" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="allLabel" runat="server" Text="All"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:ListBox ID="allListBox" runat="server"></asp:ListBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
