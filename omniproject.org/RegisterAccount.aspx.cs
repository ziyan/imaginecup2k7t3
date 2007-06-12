using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class RegisterAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void registerAccountButton_Click(object sender, EventArgs e)
    {
        //public int UserRegister(string username, string md5password,
        //string email, string name, string description, string captcha)
        String username = usernameTB.Text;
        String password = passwordTB.Text;
        String email = emailTB.Text;
        String name = displayNameTB.Text;
        String description = profileDescTB.Text;
        String captcha = captchaTB.Text;
        String md5password = Omni.Web.Common.GetMD5Hash(password);

        int result = -1;
        //try
        {
            result = Omni.Web.Common.GetWebService().UserRegister(username, md5password, email, name, description, captcha);
        }
       // catch (Exception ex)
        {
       //     Response.Write("Something went horribly wrong.");
        }
        if (result > 0)
            Response.Write("Added user w/ uid = " + result);
        else Response.Write("No User Added");
        
    }
}
