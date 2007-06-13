using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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

        successLabel.Visible = false;
        invalidCaptchaLabel.Visible = false;
        duplicateLabel.Visible = false;
        genericErrorLabel.Visible = false;

        int result = 0;
        bool error = false;
        try
        {
            result = Omni.Web.Common.GetWebService().UserRegister(username, md5password, email, name, description, captcha);
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            Exception ex2 = ex.InnerException;
            if (ex2 is ArgumentException)
            {
                invalidCaptchaLabel.Visible = true;
                error = true;
            }
            else
            {
                genericErrorLabel.Visible = true;
                error = true;
            }
        }
        catch (Exception)
        {
            genericErrorLabel.Visible = true;
            error = true;
        }
        if (!error)
        {
            if (result <= 0)
                duplicateLabel.Visible = true;
            else
                successLabel.Visible = true;
        }
    }
}
