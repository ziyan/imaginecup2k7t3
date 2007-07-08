<%@ Control Language="C#" ClassName="NotAuthedControl" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if(this.Visible)
            Response.Redirect("~/UserLogin.aspx");
    }
</script>

<asp:Label ID="notAuthedErrorLabel" runat="server" Text="Error: You must be logged in to use this page." meta:resourcekey="notAuthedErrorLabelResource1"></asp:Label>
