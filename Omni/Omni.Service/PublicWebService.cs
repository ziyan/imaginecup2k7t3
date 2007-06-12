using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Omni.Service
{
    [WebService(Namespace = "http://omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PublicWebService : System.Web.Services.WebService
    {
        public PublicWebService()
        {

        }

        [WebMethod]
        public string DictionaryLookup( int LanguageID, string SearchWord )
        {
            return "Oh No! No Web Service Here!";
        }

        [WebMethod]
        public string TranslationLookup( int OrigLanguage, int SearchLanguage, string SearchWord)
        {
            return "Oh No! No Web Service Here!";
        }
    }

}
