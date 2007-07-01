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

        public static string Lookup(int LanguageID, string SearchWord)
        {
            if (LanguageID != 1)
                throw new ArgumentException();
            return svc.Define(SearchWord).Definitions[0].WordDefinition;
        }
    }
}
