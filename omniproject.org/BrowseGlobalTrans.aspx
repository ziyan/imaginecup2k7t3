<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" 
CodeFile="BrowseGlobalTrans.aspx.cs" Inherits="BrowseGlobalTrans" 
Title="Browse Global Translations" Theme="Default" %>

<%@ Register Src="TranslationHeader.ascx" TagName="TranslationHeader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" Text="Browse Global Translations" CssClass="title"></asp:Label>
    <asp:Table ID="inputTable" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="searchLanguageLabel" runat="server" Text="Search Language">
                            </asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="searchLanguageDropDown" runat="server">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="otherLanguageLabel" runat="server" Text="Other Language">
                            </asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="otherLanguageDropDown" runat="server">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="keywordSearchLabel" runat="server" Text="Keyword Search"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:TextBox ID="keywordSearchText" runat="server"></asp:TextBox>
                            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <br />
    <uc1:TranslationHeader ID="translationHeader" runat="server" Visible="false" />
    <asp:PlaceHolder ID="translationPlaceHolder" runat="server"></asp:PlaceHolder>
    <asp:Label ID="searchNoneMessageLabel" runat="server" Text="No translations found" Visible="false"></asp:Label>
    <br />
</asp:Content>

