using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Service
{
    public class DictionaryHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            string word = context.Request["word"];
            string lang = context.Request["lang"];
            string status = "Unknown";
            string definition = "";
            if (word == null || lang == null || word == "" || lang == "")
            {
                status = "Incomplete";
            }
            else
            {
                try
                {
                    status = "OK";
                    definition = Client.OmniClient.DefinitionLookup(lang, word);
                }
                catch
                {
                    status = "NotSupported";
                }
            }
            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            collection.Add(new JSONStringValue("definition"), new JSONStringValue(definition));
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
