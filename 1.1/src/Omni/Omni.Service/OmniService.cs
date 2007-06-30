using System;
using System.Collections;
using System.Web.Services;

namespace Omni.Service
{
    [WebService(Namespace = "http://service.omniproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OmniService : System.Web.Services.WebService
    {
        public OmniService()
        {
        }

        /// <summary>
        /// Creates a new session
        /// </summary>
        /// <returns>the session id</returns>
        [WebMethod(Description = "Creates a new session, returns a session id.")]
        public Guid SessionNew()
        {
            return ServiceSession.Create().Id;
        }

        /// <summary>
        /// Check if the session exists
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>true for exists, false otherwise</returns>
        [WebMethod(Description = "Check if the session exists.")]
        public bool SessionExists(Guid session)
        {
            return ServiceSession.Exists(session);
        }

        /// <summary>
        /// Abandon session
        /// </summary>
        /// <param name="session">session id</param>
        [WebMethod(Description = "Abandon session.")]
        public void SessionAbandon(Guid session)
        {
            ServiceSession.Abandon(session);
        }


        /// <summary>
        /// Get a captcha image
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>captcha image</returns>
        [WebMethod(Description = "Get a captcha image.")]
        public byte[] UserGetCaptcha(Guid session, int width, int height, string bgcolor, string frontcolor)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.GetCaptcha(width, height, System.Drawing.ColorTranslator.FromHtml(bgcolor), System.Drawing.ColorTranslator.FromHtml(frontcolor));
        }

        /// <summary>
        /// Check if user has logged in
        /// </summary>
        /// <param name="session">session id</param>
        /// <returns>true if logged in, false otherwise</returns>
        [WebMethod(Description = "Check if user has logged in.")]
        public bool UserIsLoggedIn(Guid session)
        {
            ServiceSession Session = ServiceSession.Get(session);
            return Session.UserContext.IsLoggedIn;
        }

        /// <summary>
        /// Dictionary definition lookup service.
        /// </summary>
        /// <param name="lang_id">Language id</param>
        /// <param name="word">Word</param>
        /// <returns>Definition for word</returns>
        [WebMethod(Description = "Dictionary definition lookup service.")]
        public string DefinitionLookup(int lang_id, string word)
        {
            return External.DictionaryService.Lookup(lang_id, word);
        }

        /// <summary>
        /// Translate a message.
        /// </summary>
        /// <param name="src_lang_id">Source language id</param>
        /// <param name="dst_lang_id">Destination language id</param>
        /// <param name="message">Message</param>
        /// <returns>Translated message</returns>
        [WebMethod(Description = "Translate a message.")]
        public string TranslationLookup(int src_lang_id, int dst_lang_id, string message)
        {
            return External.TranslationService.Lookup(src_lang_id, dst_lang_id, message);
        }


    }
}
