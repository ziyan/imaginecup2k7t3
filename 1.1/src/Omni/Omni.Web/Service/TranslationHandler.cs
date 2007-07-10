using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Service
{
    public class TranslationHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string message = context.Request["message"];
            string src_lang = context.Request["src_lang"];
            string dst_lang = context.Request["dst_lang"];
            string status = "Unknown";
            string translated_message = "";
            if(message==null||src_lang==null||dst_lang==null||message==""||src_lang==""||dst_lang=="")
            {
                status = "Incomplete";
                translated_message = "";
            }
            else if(src_lang==dst_lang)
            {
                status = "DirectionError";
                translated_message = message;
            }
            else
            {
                try
                {
                    status = "OK";
                    translated_message = Client.OmniClient.TranslationLookup(src_lang, dst_lang, message);
                }
                catch
                {
                    status = "NotSupported";
                }
            }
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            collection.Add(new JSONStringValue("message"), new JSONStringValue(translated_message));
            context.Response.Write(collection.ToString());
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
