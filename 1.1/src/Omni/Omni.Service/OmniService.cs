using System;
using System.Collections;
using System.Web.Services;

namespace Omni.Service
{
    [WebService(Namespace = "http://api.omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OmniService : System.Web.Services.WebService
    {
        public OmniService()
        {
        }
        [WebMethod]
        public Guid SessionNew()
        {
            return ServiceSession.Create().Id;
        }
        [WebMethod]
        public bool SessionExists(Guid id)
        {
            return ServiceSession.Exists(id);
        }

        [WebMethod]
        public bool UserIsLoggedIn(Guid id)
        {
            ServiceSession session = ServiceSession.Get(id);
            return session.UserContext.IsLoggedIn;
        }
    }
}
