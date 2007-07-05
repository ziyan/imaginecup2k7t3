using System;
using System.Web;

namespace Omni.Web.User
{
    public class CaptchaHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.Expires = -1;
            int width = Convert.ToInt32(Util.Validator.IsInteger(context.Request["width"]) ? context.Request["width"] : "200");
            int height = Convert.ToInt32(Util.Validator.IsInteger(context.Request["height"]) ? context.Request["height"] : "100");
            string bgcolor = context.Request["bgcolor"] == null ? "white" : context.Request["bgcolor"];
            string frontcolor = context.Request["frontcolor"] == null ? "black" : context.Request["frontcolor"];
            context.Response.BinaryWrite(Common.Client.UserGetCaptcha(width, height, bgcolor, frontcolor));
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
