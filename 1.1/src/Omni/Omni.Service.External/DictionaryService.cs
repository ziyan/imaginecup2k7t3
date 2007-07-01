using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service.External
{
    public static class DictionaryService
    {
        private static com.aonaware.services.DictService svc;

        static DictionaryService()
        {
            svc = new com.aonaware.services.DictService();
        }

        public static string Lookup(string lang, string word)
        {
            if (!lang.ToLower().StartsWith("en"))
                throw new ArgumentException();
            return svc.Define(word).Definitions[0].WordDefinition;
        }
    }
}
