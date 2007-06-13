using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    class Translation
    {
        public TranslationDataType type;

        // Request Stuff
        public int request_id;
        public int src_lang_id;
        public int dst_lang_id;
        public int dest_id;
        public TranslationDestinationType dest_type;
        public string subject;
        public string orig_body;
        public DateTime date;
        public bool completed;
        public int msg_id;

        // Answer Stuff
        public int trans_id;
        public string trans_body;
        public int trans_rating;
        public DateTime trans_date;
    }
}
