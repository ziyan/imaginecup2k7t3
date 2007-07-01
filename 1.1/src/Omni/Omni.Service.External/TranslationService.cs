using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Service.External
{
    public static class TranslationService
    {
        /*
         * Language 	Code
         * Arabic 	ar
         * Bulgarian 	bg
         * Catalan 	ca
         * Chinese (simplified) 	zh_CN
         * Chinese (traditional) 	zh_TW
         * Croatian 	hr
         * Czech 	cs
         * Danish 	da
         * Dutch 	nl
         * English (Australia) 	en_AU
         * English (UK) 	en_GB
         * English (US) 	en_US
         * Estonian 	et
         * Finnish 	fi
         * French 	fr
         * German 	de
         * Greek 	el
         * Hebrew 	iw
         * Hindi 	hi
         * Hungarian 	hu
         * Icelandic 	is
         * Indonesian 	id
         * Italian 	it
         * Japanese 	ja
         * Korean 	ko
         * Latvian 	lv
         * Lithuanian 	lt
         * Norwegian 	no
         * Polish 	pl
         * Portuguese (Brazil) 	pt_BR
         * Portuguese (Portugal) 	pt_PT
         * Romanian 	ro
         * Russian 	ru
         * Serbian 	sr
         * Slovak 	sk
         * Slovenian 	sl
         * Spanish 	es
         * Swedish 	sv
         * Tagalog 	tl
         * Thai 	th
         * Turkish 	tr
         * Ukrainian 	uk
         * Urdu 	ur
         * Vietnamese 	vi
         */
        private static de.zeta_software.www.TranslationService svc;
        private static readonly Dictionary<string, string> lang_code = new Dictionary<string, string>();
        static TranslationService()
        {
            svc = new de.zeta_software.www.TranslationService();
            lang_code.Add("en", "en");
            lang_code.Add("en-us", "en");
            lang_code.Add("en-gb", "en");
            lang_code.Add("en-au", "en");
            lang_code.Add("zh", "zh");
            lang_code.Add("zh-cn", "zh");
            lang_code.Add("zh-tw", "zh");
        }

        public static string Lookup(string src_lang, string dst_lang, string message)
        {
            if (src_lang == null || dst_lang == null) throw new ArgumentNullException();
            src_lang = src_lang.ToLower().Replace("_", "-");
            dst_lang = dst_lang.ToLower().Replace("_", "-");
            if ((!lang_code.ContainsKey(src_lang)) || (!lang_code.ContainsKey(dst_lang)))
                throw new ArgumentOutOfRangeException();
            if (src_lang == dst_lang)
                return message;
            de.zeta_software.www.TranslationMode transMode = new de.zeta_software.www.TranslationMode();
            transMode.ObjectID = lang_code[src_lang] + "_" + lang_code[dst_lang];
            return svc.Translate(transMode, message);
        }
    }
}
