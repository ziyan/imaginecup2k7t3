using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class OmniClient : IDisposable
    {
        private org.omniproject.service.OmniService service = new Omni.Client.org.omniproject.service.OmniService();
        private Guid session = Guid.Empty;
        public org.omniproject.service.OmniService Service
        {
            get { return service; }
        }
        public Guid Session
        {
            get { return session; }
        }
        public OmniClient()
        {
            session = service.SessionNew();
        }
        public void Dispose()
        {
            service.SessionAbandon(session);
        }
        public byte[] UserGetCaptcha(int width, int height, string bgcolor, string frontcolor)
        {
            return service.UserGetCaptcha(session, width, height, bgcolor, frontcolor);
        }
    }
}
