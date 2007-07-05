using System;
using System.Collections.Specialized;


namespace Omni.Data
{
    public static class Configuration
    {
        /// <summary>
        /// Local configuration reading
        /// </summary>
        public static NameValueCollection LocalSettings
        { 
            get { return System.Configuration.ConfigurationManager.AppSettings; }
        }
    }
}
