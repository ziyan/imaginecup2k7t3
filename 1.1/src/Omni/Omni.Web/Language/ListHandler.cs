using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Language
{
    public class ListHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //cache the list to increase speed
            Client.Language[] languages;
            //if nocache is specified, clear the cache
            bool nocache = (context.Request["nocache"]!=null);
            if (context.Application["OmniSystemLanguageListCache"] == null || nocache)
            {
                languages = Common.Client.LanguageList();
                if (nocache)
                {
                    context.Application["OmniSystemLanguageListCache"] = null;
                    context.Response.Expires = -1;
                }
                else
                    context.Application["OmniSystemLanguageListCache"] = languages;
            }
            else
            {
                languages = (Client.Language[])context.Application["OmniSystemLanguageListCache"];
            }

            JSONArrayCollection jsonLanguages = new JSONArrayCollection();
            if (languages != null)
            {
                for (int i = 0; i < languages.Length; i++)
                {
                    JSONObjectCollection obj = new JSONObjectCollection();
                    obj.Add(new JSONStringValue("id"), new JSONNumberValue(languages[i].ID));
                    obj.Add(new JSONStringValue("code"), new JSONStringValue(languages[i].Code));
                    jsonLanguages.Add(obj);
                }
            }
            context.Response.Write(jsonLanguages.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
