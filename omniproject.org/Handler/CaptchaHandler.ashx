<%@ WebHandler Language="C#" Class="CaptchaHandler" %>

using System;
using System.Web;

public class CaptchaHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/gif";
        context.Response.Expires = -1;
        if(HttpContext.Current.Session["ProtectedWebService"] == null) context.Response.End();
        try
        {
            context.Response.BinaryWrite(Omni.Web.Common.GetProtectedWebService().UserCaptcha(Int32.Parse(context.Request["w"]), Int32.Parse(context.Request["h"]), context.Request["bc"], context.Request["fc"]));
            context.Response.Flush();
        }
        catch
        {
        }
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}