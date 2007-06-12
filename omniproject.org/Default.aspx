<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" 
 MasterPageFile="~/OmniMaster.master" Theme="Default" Title="Omni" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" Text="Welcome to Omni."></asp:Label><br />

    <asp:Panel runat="server" ID="userPanel">
    An authorized user sees this.
    </asp:Panel>
    <uc2:NotAuthedControl ID="NotAuthedControl1" runat="server" />
    
    
</asp:Content>
