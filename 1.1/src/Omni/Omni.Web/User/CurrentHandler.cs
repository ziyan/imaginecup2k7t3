using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.User
{
    public class CurrentHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            Client.User user = Common.Client.UserCurrent;

            Client.UserLanguage[] languages = null;
            //Client.UserSummary summary = null;
            if (user != null)
            {
                languages = Common.Client.UserLanguages(user.ID);
                //summary = Common.Client.UserSummary(user.ID);
            }

            JSONObjectCollection collection = new JSONObjectCollection();
            collection.Add(new JSONStringValue("loggedin"), new JSONBoolValue(user != null));
            collection.Add(new JSONStringValue("user"), Common.getUserJSON(user));
            //collection.Add(new JSONStringValue("summary"), Common.getUserSummaryJSON(summary));

            JSONArrayCollection langIDs = new JSONArrayCollection();
            if (languages != null)
            {
                foreach (Client.UserLanguage ul in languages)
                {
                    langIDs.Add(new JSONNumberValue(ul.LangId));
                }
            }
            collection.Add(new JSONStringValue("user_lang"), langIDs);
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
