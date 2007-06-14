using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.PocketService
{
    public class Service
    {
        private org.omniproject.WebService webService = new Omni.PocketService.org.omniproject.WebService();
        public Service()
        {
            webService.Url = webService.Url.Replace("omniproject.org", "brianistan.com");
            webService.
            webService.Initialize();
        }
    }
}
