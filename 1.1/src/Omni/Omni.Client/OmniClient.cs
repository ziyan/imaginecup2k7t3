using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class OmniClient : IDisposable
    {
        private org.omniproject.service.OmniService service = new Omni.Client.org.omniproject.service.OmniService();
        /// <summary>
        /// The OmniService object
        /// </summary>
        public org.omniproject.service.OmniService Service
        {
            get { return service; }
        }

        #region Session related
        private Guid session = Guid.Empty;
        /// <summary>
        /// Session ID
        /// </summary>
        public Guid Session
        {
            get { return session; }
        }
        /// <summary>
        /// Construct a new connection to OmniService
        /// </summary>
        public OmniClient()
        {
            session = service.SessionNew();
        }
        /// <summary>
        /// Dispose session
        /// </summary>
        public void Dispose()
        {
            service.SessionAbandon(session);
        }
        /// <summary>
        /// Check for session validity
        /// </summary>
        private void CheckSession()
        {
            if (!service.SessionExists(session))
                session = service.SessionNew();
        }
        /// <summary>
        /// Keep session alive
        /// </summary>
        public void KeepAlive()
        {
            CheckSession();
            service.SessionKeepAlive(session);
        }
        #endregion

        #region User
        /// <summary>
        /// Get a captcha image for login and register
        /// </summary>
        /// <param name="width">width of the image</param>
        /// <param name="height">height of the image</param>
        /// <param name="bgcolor">background color</param>
        /// <param name="frontcolor">text color</param>
        /// <returns>a byte array for captcha in jpeg format</returns>
        public byte[] UserGetCaptcha(int width, int height, string bgcolor, string frontcolor)
        {
            CheckSession();
            return service.UserGetCaptcha(session, width, height, bgcolor, frontcolor);
        }

        /// <summary>
        /// Check see if user has logged in
        /// </summary>
        /// <returns>true for logged in, false otherwise</returns>
        public bool UserIsLoggedIn()
        {
            CheckSession();
            return service.UserIsLoggedIn(session);
        }
        #endregion

        #region Lookup service
        /// <summary>
        /// Dictionary definition lookup service.
        /// </summary>
        /// <param name="lang_id">Language id</param>
        /// <param name="word">Word</param>
        /// <returns>Definition for word</returns>
        public static string DefinitionLookup(string lang, string word)
        {
            org.omniproject.service.OmniService service = new Omni.Client.org.omniproject.service.OmniService();
            return service.DefinitionLookup(lang, word);
        }

        /// <summary>
        /// Translate a message.
        /// </summary>
        /// <param name="src_lang_id">Source language id</param>
        /// <param name="dst_lang_id">Destination language id</param>
        /// <param name="message">Message</param>
        /// <returns>Translated message</returns>
        public static string TranslationLookup(string src_lang, string dst_lang, string message)
        {
            org.omniproject.service.OmniService service = new Omni.Client.org.omniproject.service.OmniService();
            return service.TranslationLookup(src_lang, dst_lang, message);
        }
        #endregion
    }
}
