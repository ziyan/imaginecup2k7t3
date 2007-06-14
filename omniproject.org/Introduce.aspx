<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="Introduce.aspx.cs" Inherits="Introduce" Title="Introduce" Theme="Default"%>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>

<asp:Content ID="MainId" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" CssClass="title" Text="Introduce">
    </asp:Label>
    <br />
    <asp:Panel ID="userPanel" runat="server">
        <asp:Label ID="introduceLanguageLabel" runat="server" Text="Language for introduction:"></asp:Label>
        <asp:DropDownList ID="introduceLanguageDropDown" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="introduceCountLabel" runat="server" Text="Maximum number of users in introduction"></asp:Label>
        <asp:TextBox ID="introduceCountText" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="introduceButton" runat="server" Text="Introduce" OnClick="introduceButton_Click" />
        <br />
        <br />
        <asp:Table ID="introduceTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <asp:Label ID="introduceUsernameLabel" runat="server" Text="Username">
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="introduceUserRatingLabel" runat="server" Text="User Rating">
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="introduceSystemRatingLabel" runat="server" Text="System Rating">
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="introduceSimilarityLabel" runat="server" Text="Similarity">
                    </asp:Label>
                </asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Label ID="introduceNoneMessage" runat="server" Text="No users found." Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    <uc1:NotAuthedControl ID="notAuthorizedControl" runat="server" />
</asp:Content>