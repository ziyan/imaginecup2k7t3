using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Web
{
    public static class Common
    {
        public static Omni.Client.OmniClient Client
        {
            get
            {
                return (Omni.Client.OmniClient)System.Web.HttpContext.Current.Session["Client"];
            }
        }
    }
}
