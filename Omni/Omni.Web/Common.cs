using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Omni.Web
{
    public static class Common
    {
        public static org.omniproject.secure.ProtectedWebService GetProtectedWebService()
        {
            if (HttpContext.Current.Session==null||HttpContext.Current.Session["ProtectedWebService"] == null) throw new NullReferenceException("No session used.");
            return (org.omniproject.secure.ProtectedWebService)HttpContext.Current.Session["ProtectedWebService"];
        }

        public static org.omniproject.service.PublicWebService GetPublicWebService()
        {
            if (HttpContext.Current.Session==null||HttpContext.Current.Session["PublicWebService"] == null) throw new NullReferenceException("No session used.");
            return (org.omniproject.service.PublicWebService)HttpContext.Current.Session["PublicWebService"];
        }
    }
}
