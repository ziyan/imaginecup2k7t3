<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectPreferredLanguage.aspx.cs" Inherits="SelectPreferredLanguage"
Title="" Theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
</head>
<body style="background-image: url(App_Themes/Default/grad1.jpg); background-repeat: repeat-x;">
    <form id="form1" runat="server">
    <center>
    <asp:Image ID="logoImg" runat="server" ImageAlign="Middle" ImageUrl="~/App_Themes/Default/omnilogo_lg.gif" />
    </center>
    <asp:Panel runat="server" ID="languagePanel" HorizontalAlign="Center" CssClass="langpanel">
    </asp:Panel>
    </form>
</body>
</html>