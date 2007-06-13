using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class UserLanguage
    {
        public UserLanguage()
        {
        }
        public UserLanguage(int user_id, int lang_id, short self_rating, short net_rating)
        {
            this.lang_id = lang_id;
            this.user_id = user_id;
            this.net_rating = net_rating;
            this.self_rating = self_rating;
        }
        public int lang_id;
        public int user_id;
        public short net_rating;
        public short self_rating;
    }
}
