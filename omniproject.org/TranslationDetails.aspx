<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="TranslationDetails.aspx.cs" Inherits="TranslationDetails" 
Title="Translation Details" Theme="Default" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc2" %>

<%@ Register Src="TranslationHeader.ascx" TagName="TranslationHeader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<asp:Label ID="translationDetailsTitle" runat="server" CssClass="title" Text="Translation Details" meta:resourcekey="translationDetailsTitleResource1"></asp:Label>
<br /><br />
    <asp:Panel ID="userPanel" runat="server" Width="100%" meta:resourcekey="userPanelResource1">
        <uc1:TranslationHeader ID="translationHeader" runat="server" Visible="False" />
        <br />
        <asp:Table ID="translationDetailsTable" runat="server" meta:resourcekey="translationDetailsTableResource1">
        </asp:Table>
        <br />
        <asp:Label ID="origMsgLabel" runat="server" Text="Original Text" meta:resourcekey="origMsgLabelResource1"></asp:Label><br />
        <asp:TextBox ID="origMsgTB" runat="server" Columns="80" Rows="12" TextMode="MultiLine" Height="300px" ReadOnly="True" Width="600px" meta:resourcekey="origMsgTBResource1"></asp:TextBox><br />
        <asp:Label ID="transMsgLabel" runat="server" Text="Translated Text" meta:resourcekey="transMsgLabelResource1"></asp:Label><br />
        <asp:Label ID="transAnsId" runat="server" Visible="False" meta:resourcekey="transAnsIdResource1"></asp:Label><br />
        <asp:TextBox ID="transMsgTB" runat="server" Columns="80" Rows="12" TextMode="MultiLine" Height="300px" ReadOnly="True" Width="600px" meta:resourcekey="transMsgTBResource1"></asp:TextBox><br />
        <br />
        <asp:Label ID="currentRatingLabel" runat="server" Text="Current Rating:" meta:resourcekey="currentRatingLabelResource1"></asp:Label>&nbsp;
        <asp:RadioButtonList ID="readRatingRBL" runat="server" RepeatDirection="Horizontal" Enabled="False" meta:resourcekey="readRatingRBLResource1">
            <asp:ListItem meta:resourcekey="ListItemResource1">1</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource2">2</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource3">3</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource4">4</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource5">5</asp:ListItem>
        </asp:RadioButtonList><br />
        <asp:Button ID="composeFromTransButton" runat="server" Text="Compose Message From Translation" OnClick="composeFromTransButton_Click" /><br />
        <br />
    <asp:MultiView ID="transView" runat="server">
        <asp:View ID="prevTransView" runat="server">
            <asp:Label ID="prevRateLabel" runat="server" Text="Rate this Answer" meta:resourcekey="prevRateLabelResource1"></asp:Label>
            <asp:RadioButtonList ID="writePrevRatingRBL" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="writePrevRatingRBL_SelectedIndexChanged" meta:resourcekey="writePrevRatingRBLResource1">
                <asp:ListItem meta:resourcekey="ListItemResource6">1</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource7">2</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource8">3</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource9">4</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource10">5</asp:ListItem>
            </asp:RadioButtonList></asp:View>
        <asp:View ID="recvTransView" runat="server">
            <asp:Label ID="rateAnsLabel" runat="server" Text="Rate this Answer" meta:resourcekey="rateAnsLabelResource1"></asp:Label><br />
            <asp:RadioButtonList ID="writeRatingRBL" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="writeRatingRBL_SelectedIndexChanged" meta:resourcekey="writeRatingRBLResource1">
            <asp:ListItem meta:resourcekey="ListItemResource11">1</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource12">2</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource13">3</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource14">4</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource15">5</asp:ListItem>
        </asp:RadioButtonList><asp:Button ID="approveTransButton" runat="server" Text="Approve this Translation" OnClick="approveTransButton_Click" meta:resourcekey="approveTransButtonResource1" />
            <br />
            <br />
        </asp:View>
        <asp:View ID="transReqView" runat="server">
            <asp:TextBox ID="translationTB" runat="server"  Columns="80" Rows="12" TextMode="MultiLine" Height="300px" Width="600px" meta:resourcekey="translationTBResource1"></asp:TextBox><br />
            <asp:Button ID="submitTransButton" runat="server" Text="Submit Translation" OnClick="submitTransButton_Click" meta:resourcekey="submitTransButtonResource1" />
        </asp:View>
    </asp:MultiView>
    </asp:Panel> 
    <asp:Label ID="invalidIdLabel" runat="server" Text="Error - Invalid Translation specified." Visible="False" meta:resourcekey="invalidIdLabelResource1"></asp:Label>
</asp:Content>

