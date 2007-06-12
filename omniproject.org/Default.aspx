<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" 
 MasterPageFile="~/OmniMaster.master" Theme="Default" Title="Omni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" Text="Welcome to Omni."></asp:Label><br />
    <asp:MultiView ID="loginView" runat="server">
        <asp:View ID="guestView" runat="server">
        A guest sees this
        </asp:View>
        <asp:View ID="userView" runat="server">
        An authorized user sees this
        </asp:View>
    
    </asp:MultiView>
    
</asp:Content>
