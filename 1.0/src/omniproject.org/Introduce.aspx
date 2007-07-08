<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="Introduce.aspx.cs" Inherits="Introduce" Title="Introduce" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Introduce" meta:resourcekey="titleLabelResource1"></asp:Label>
    <br />
    <asp:Panel ID="userPanel" runat="server" meta:resourcekey="userPanelResource1">
        <asp:Table ID="table1" runat="server" meta:resourcekey="table1Resource1">
            <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                    <asp:Label ID="introduceLanguageLabel" runat="server" Text="Language for introduction:" meta:resourcekey="introduceLanguageLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
                    <asp:DropDownList ID="introduceLanguageDropDown" runat="server" meta:resourcekey="introduceLanguageDropDownResource1">
        </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource3" runat="server">
                <asp:TableCell ColumnSpan="2" meta:resourcekey="TableCellResource5" runat="server">
                    <asp:Button ID="introduceButton" runat="server" Text="Introduce" OnClick="introduceButton_Click" meta:resourcekey="introduceButtonResource1" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="introduceTable" runat="server" CssClass="displayTable" meta:resourcekey="introduceTableResource1">
            <asp:TableHeaderRow meta:resourcekey="TableHeaderRowResource1" runat="server">
                <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource1" runat="server">
                    <asp:Label ID="introduceUsernameLabel" runat="server" Text="Username" meta:resourcekey="introduceUsernameLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell ID="TableHeaderCell1" meta:resourcekey="TableHeaderCellResource5" runat="server">
                    <asp:Label ID="introduceNameLabel" runat="server" Text="Name" meta:resourcekey="introduceNameLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource2" runat="server">
                    <asp:Label ID="introduceUserRatingLabel" runat="server" Text="User Rating" meta:resourcekey="introduceUserRatingLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource3" runat="server">
                    <asp:Label ID="introduceSystemRatingLabel" runat="server" Text="System Rating" meta:resourcekey="introduceSystemRatingLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource4" runat="server">
                    <asp:Label ID="introduceSimilarityLabel" runat="server" Text="Similarity" meta:resourcekey="introduceSimilarityLabelResource1"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Label ID="introduceNoneMessage" runat="server" Text="No users found." Visible="False" meta:resourcekey="introduceNoneMessageResource1"></asp:Label>
    </asp:Panel>
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>