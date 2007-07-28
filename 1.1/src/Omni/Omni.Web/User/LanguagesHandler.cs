using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class LanguagesHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            string status = "Unknown";

            int user_id = Convert.ToInt32(Util.Validator.IsInteger(context.Request["user_id"]) ? context.Request["user_id"] : "0");
            Client.UserLanguage[] languages = null;
            if (user_id > 0)
            {
                try
                {
                    languages = Common.Client.UserLanguages(user_id);
                    if (languages != null)
                        status = "OK";
                    else
                        status = "Error";
                }
                catch
                {
                    status = "Error";
                }
            }
            else
            {
                status = "Incomplete";
            }

            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            JSONArrayCollection jsonLanguages = new JSONArrayCollection();
            if (languages != null)
            {
                for (int i = 0; i < languages.Length; i++)
                {
                    jsonLanguages.Add(Common.getUserLanguageJSON(languages[i]));
                }
            }
            collection.Add(new JSONStringValue("languages"), jsonLanguages);
            context.Response.Write(collection.ToString());
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
