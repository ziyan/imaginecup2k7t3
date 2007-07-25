using System;
using System.Web;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace Omni.Web.Interest
{
    public class ListHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //cache the list to increase speed
            Client.Interest[] interests;
            //if nocache is specified, clear the cache
            bool nocache = (context.Request["nocache"]!=null);
            if (context.Application["OmniSystemInterestListCache"] == null || nocache)
            {
                interests = Common.Client.InterestList();
                if (nocache)
                {
                    context.Application["OmniSystemInterestListCache"] = null;
                    context.Response.Expires = -1;
                }
                else
                    context.Application["OmniSystemInterestListCache"] = interests;
            }
            else
            {
                interests = (Client.Interest[])context.Application["OmniSystemInterestListCache"];
            }

            JSONArrayCollection jsonInterests = new JSONArrayCollection();
            if (interests != null)
            {
                for (int i = 0; i < interests.Length; i++)
                {
                    jsonInterests.Add(Common.getInterestJSON(interests[i]));
                }
            }
            context.Response.Write(jsonInterests.ToString());
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
