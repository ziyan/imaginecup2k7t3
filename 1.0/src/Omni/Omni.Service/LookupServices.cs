using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service
{
    static public class DictionaryService
    {
        static com.aonaware.services.DictService svc;

        static DictionaryService()
        {
            svc = new Omni.Service.com.aonaware.services.DictService();
        }

        public static string Lookup(int LanguageID, string SearchWord)
        {
            if (LanguageID != 1)
                throw new ArgumentException();
            return svc.Define(SearchWord).Definitions[0].WordDefinition;
        }
    }

    static public class TranslationService
    {
        static readonly Dictionary<int, string> LangCodeTo2Char = new Dictionary<int, string>();
        static de.zeta_software.www.TranslationService svc;

        static TranslationService()
        {
            LangCodeTo2Char.Add(1, "en");
            LangCodeTo2Char.Add(2, "zh");

            svc = new Omni.Service.de.zeta_software.www.TranslationService();
        }

        public static string Lookup(int OrigLanguage, int SearchLanguage, string SearchWord)
        {
            if (OrigLanguage == SearchLanguage)
                return SearchWord;

            de.zeta_software.www.TranslationMode transMode = new de.zeta_software.www.TranslationMode();
            transMode.ObjectID = LangCodeTo2Char[OrigLanguage] + "_" + LangCodeTo2Char[SearchLanguage];
            return svc.Translate(transMode, SearchWord);
        }
    }
}
