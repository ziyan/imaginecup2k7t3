using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Omni.Service
{
    [WebService(Namespace = "http://omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProtectedWebService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
    {
        public ProtectedWebService()
        {

        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
    
}
