using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Translation
{
    public class FindGlobalRequestsForUserHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //string status = "Unknown";
            Client.Translation[] trans = null;
            trans = Common.Client.TranslationFindGlobalRequestsForUser();

            JSONObjectCollection collection = new JSONObjectCollection();
            JSONArrayCollection objArray = new JSONArrayCollection();
            //collection.Add(new JSONStringValue("status"), new JSONStringValue(status));
            if (trans != null)
            {
                foreach (Client.Translation t in trans)
                {
                    objArray.Add(Common.getTranslationJSON(t));
                }
            }
            collection.Add(new JSONStringValue("results"), objArray);
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
