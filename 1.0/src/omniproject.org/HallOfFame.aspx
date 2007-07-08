<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="HallOfFame.aspx.cs" Inherits="HallOfFame" Title="Hall Of Fame" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Hall Of Fame" meta:resourcekey="titleLabelResource1"></asp:Label>
    <br />
    <br />
    
    <asp:Table ID="Table2" runat="server" meta:resourcekey="Table2Resource1">
        <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource1" runat="server">
            <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource1" runat="server">
                <asp:Label ID="Label3" runat="server" Text="Most Active (30 Days)" meta:resourcekey="Label3Resource1"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
            <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                <asp:Table ID="allTimeTable" runat="server" CssClass="displayTable" meta:resourcekey="allTimeTableResource1">
                    <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource2" runat="server">
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource2" runat="server">
                            <asp:Label ID="allTimeUsernameLabel" runat="server" Text="Username" meta:resourcekey="allTimeUsernameLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource3" runat="server">
                            <asp:Label ID="allTimeDisplayNameLabel" runat="server" Text="Display Name" meta:resourcekey="allTimeDisplayNameLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource4" runat="server">
                            <asp:Label ID="allTimeQuantityLabel" runat="server" Text="Number of Translations" meta:resourcekey="allTimeQuantityLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    
    <asp:Table ID="Table1" runat="server" meta:resourcekey="Table1Resource1">
        <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource3" runat="server">
            <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource5" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Most Active (7 Days)" meta:resourcekey="Label2Resource1"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
            <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
                <asp:Table ID="sevenDayTable" runat="server" CssClass="displayTable" meta:resourcekey="sevenDayTableResource1">
                    <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource4" runat="server">
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource6" runat="server">
                            <asp:Label ID="sevenDayUsernameLabel" runat="server" Text="Username" meta:resourcekey="sevenDayUsernameLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource7" runat="server">
                            <asp:Label ID="sevenDayDisplayNameLabel" runat="server" Text="Display Name" meta:resourcekey="sevenDayDisplayNameLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource8" runat="server">
                            <asp:Label ID="sevenDayQuantityLabel" runat="server" Text="Number of Translations" meta:resourcekey="sevenDayQuantityLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    
    <asp:Table ID="oneDayActive" runat="server" meta:resourcekey="oneDayActiveResource1">
        <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource5" runat="server">
            <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource9" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Most Active (24 Hours)" meta:resourcekey="Label1Resource1"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow meta:resourcekey="TableRowResource3" runat="server">
            <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
                <asp:Table ID="oneDayTable" runat="server" CssClass="displayTable" meta:resourcekey="oneDayTableResource1">
                    <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource6" runat="server">
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource10" runat="server">
                            <asp:Label ID="oneDayUsernameLabel" runat="server" Text="Username" meta:resourcekey="oneDayUsernameLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource11" runat="server">
                            <asp:Label ID="oneDayDisplayNameLabel" runat="server" Text="Display Name" meta:resourcekey="oneDayDisplayNameLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource12" runat="server">
                            <asp:Label ID="oneDayQuantityLabel" runat="server" Text="Number of Translations" meta:resourcekey="oneDayQuantityLabelResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="ratingLabel" Visible="false" runat="server" Text="Rating" meta:resourcekey="ratingLabel"></asp:Label>
    <asp:Label ID="highRatingLabel" Visible="false" runat="server" Text="Highest Rating ({0})" meta:resourcekey="highRatingLabel"></asp:Label>
    <asp:PlaceHolder ID="ratingPlaceHolder" runat="server">
    </asp:PlaceHolder>
    
    <asp:Table ID="outterTable" runat="server" meta:resourcekey="outterTableResource1">
    </asp:Table>
</asp:Content>
