using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public class UserLanguage
    {
        public UserLanguage()
        {
        }
        public UserLanguage(int user_id, int lang_id, int self_rating, float net_rating)
        {
            this.user_id = user_id;
            this.lang_id = lang_id;
            this.self_rating = self_rating;
            this.net_rating = net_rating;
        }
        public int user_id;
        public int lang_id;
        public int self_rating;
        public float net_rating;
    }
}
