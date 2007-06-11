using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Drawing;
using System.IO;

namespace Omni.Web
{
    public static class Captcha
    {
        public static byte[] GetImage(int width, int height, string bgColor, string frontColor)
        {
            if (HttpContext.Current.Session["ProtectedWebService"] == null || bgColor == null || frontColor == null) throw new ArgumentNullException();
            if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException();
            return ((org.omniproject.secure.ProtectedWebService)HttpContext.Current.Session["ProtectedWebService"]).UserCaptcha(width, height, bgColor, frontColor);
        }
    }
}
