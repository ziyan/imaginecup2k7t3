<%@ Page Language="C#" MasterPageFile="~/OmniMaster.master" AutoEventWireup="true" CodeFile="RequestTranslation.aspx.cs" Inherits="RequestTranslation"
Title="Request a Translation" Theme="Default" meta:resourcekey="PageResource1" %>

<%@ Register Src="NotAuthedControl.ascx" TagName="NotAuthedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="requestTransTitleLabel" runat="server" Text="Request a Translation" CssClass="title" meta:resourcekey="requestTransTitleLabelResource1"></asp:Label><br />
    <br />
    <asp:Panel ID="userPanel" runat="server" Width="100%" meta:resourcekey="userPanelResource1">
        <asp:Label ID="desiredTranslatorLabel" runat="server" Text="Desired Translator:" meta:resourcekey="desiredTranslatorLabelResource1"></asp:Label>
        <asp:DropDownList ID="desiredTranslatorDDL" runat="server" OnSelectedIndexChanged="desiredTranslatorDDL_SelectedIndexChanged" AutoPostBack="True" meta:resourcekey="desiredTranslatorDDLResource1">
        <asp:ListItem Text="Specific User" meta:resourcekey="ListItemResource1"></asp:ListItem>
        <asp:ListItem Text="Global / Any" meta:resourcekey="ListItemResource2"></asp:ListItem>        
        </asp:DropDownList>
        <asp:Panel ID="userTranslatorPanel" runat="server" Width="100%" meta:resourcekey="userTranslatorPanelResource1">
            <asp:DropDownList ID="userTranslatorDDL" runat="server" Width="140px" OnSelectedIndexChanged="userTranslatorDDL_SelectedIndexChanged" AutoPostBack="True" meta:resourcekey="userTranslatorDDLResource1">
            <asp:ListItem Text="(Other)" Value="noFav" meta:resourcekey="otherListItem"></asp:ListItem>            
            </asp:DropDownList>
            <asp:TextBox ID="userTranslatorTB" runat="server" Columns="25" Width="200px" meta:resourcekey="userTranslatorTBResource1"></asp:TextBox>
       </asp:Panel>            
        <br />
        <asp:Table ID="headerTable" runat="server" meta:resourcekey="headerTableResource1">
            <asp:TableRow meta:resourcekey="TableRowResource1" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource1" runat="server">
                    <asp:Label ID="srcLangLabel" runat="server" Text="Source Language" meta:resourcekey="srcLangLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource2" runat="server">
                    <asp:DropDownList ID="srcLangDDL" runat="server" meta:resourcekey="srcLangDDLResource1">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource2" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource3" runat="server">
                    <asp:Label ID="destLangLabel" runat="server" Text="Destination Language" meta:resourcekey="destLangLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource4" runat="server">
                    <asp:DropDownList ID="destLangDDL" runat="server" meta:resourcekey="destLangDDLResource1">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow meta:resourcekey="TableRowResource3" runat="server">
                <asp:TableCell meta:resourcekey="TableCellResource5" runat="server">
                    <asp:Label ID="subjectLabel" runat="server" Text="Subject" meta:resourcekey="subjectLabelResource1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell meta:resourcekey="TableCellResource6" runat="server">
                    <asp:TextBox ID="subjectTB" runat="server" Columns="50" meta:resourcekey="subjectTBResource1"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>            
        </asp:Table>
        <asp:Label ID="transTextLabel" runat="server" Text="Text to Translate" meta:resourcekey="transTextLabelResource1"></asp:Label>
        <br />
        <asp:TextBox ID="transTextTB" runat="server" Rows="10" TextMode="MultiLine" Columns="60" Width="400px" Height="300px" meta:resourcekey="transTextTBResource1"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="submitButton" runat="server" Text="Submit Request" OnClick="submitButton_Click" meta:resourcekey="submitButtonResource1" />
        <br />
        <asp:Label ID="invalidUserLabel" runat="server" Text="Error: Invalid username specified." Visible="False" meta:resourcekey="invalidUserLabelResource1"></asp:Label><br />
        <asp:Label ID="emptyFieldsLabel" runat="server" Text="Error: Fill out all fields." Visible="False" meta:resourcekey="emptyFieldsLabelResource1"></asp:Label></asp:Panel>
    <uc1:NotAuthedControl ID="NotAuthedControl1" runat="server" />
</asp:Content>

