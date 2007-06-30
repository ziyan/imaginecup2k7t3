using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service.External
{
    public static class TranslationService
    {
        private static readonly Dictionary<int, string> LangCodeTo2Char = new Dictionary<int, string>();
        private static de.zeta_software.www.TranslationService svc;

        static TranslationService()
        {
            LangCodeTo2Char.Add(1, "en");
            LangCodeTo2Char.Add(2, "zh");

            svc = new de.zeta_software.www.TranslationService();
        }

        public static string Lookup(int src_lang_id, int dst_lang_id, string message)
        {
            if (src_lang_id == dst_lang_id)
                return message;

            de.zeta_software.www.TranslationMode transMode = new de.zeta_software.www.TranslationMode();
            transMode.ObjectID = LangCodeTo2Char[src_lang_id] + "_" + LangCodeTo2Char[dst_lang_id];
            return svc.Translate(transMode, message);
        }
    }
}
