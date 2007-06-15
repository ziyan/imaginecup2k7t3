<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="HallOfFame.aspx.cs" Inherits="HallOfFame" Title="Hall Of Fame" Theme="Default"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Hall Of Fame">
    </asp:Label>
    <br />
    <br />
    
    <asp:Table ID="Table2" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <asp:Label ID="Label3" runat="server" Text="Most Active (30 Days)"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table ID="allTimeTable" runat="server" CssClass="displayTable">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>
                            <asp:Label ID="allTimeUsernameLabel" runat="server" Text="Username">
                            </asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                            <asp:Label ID="allTimeDisplayNameLabel" runat="server" Text="Display Name">
                            </asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                            <asp:Label ID="allTimeQuantityLabel" runat="server" Text="Number of Translations">
                            </asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    
    <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <asp:Label ID="Label2" runat="server" Text="Most Active (7 Days)"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table ID="sevenDayTable" runat="server" CssClass="displayTable">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>
                            <asp:Label ID="sevenDayUsernameLabel" runat="server" Text="Username">
                            </asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                            <asp:Label ID="sevenDayDisplayNameLabel" runat="server" Text="Display Name">
                            </asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                            <asp:Label ID="sevenDayQuantityLabel" runat="server" Text="Number of Translations">
                            </asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    
    <asp:Table ID="oneDayActive" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <asp:Label ID="Label1" runat="server" Text="Most Active (24 Hours)"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table ID="oneDayTable" runat="server" CssClass="displayTable">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>
                            <asp:Label ID="oneDayUsernameLabel" runat="server" Text="Username">
                            </asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                            <asp:Label ID="oneDayDisplayNameLabel" runat="server" Text="Display Name">
                            </asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                            <asp:Label ID="oneDayQuantityLabel" runat="server" Text="Number of Translations">
                            </asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:PlaceHolder ID="ratingPlaceHolder" runat="server">
    </asp:PlaceHolder>
    
    <asp:Table ID="outterTable" runat="server">
    </asp:Table>
</asp:Content>