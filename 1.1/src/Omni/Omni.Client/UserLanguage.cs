using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class UserLanguage
    {
        internal UserLanguage(org.omniproject.service.UserLanguage ul)
        {
            this.user_id = ul.user_id;
            this.lang_id = ul.lang_id;
            this.self_rating = ul.self_rating;
            this.net_rating = ul.net_rating;
        }
        private int user_id;
        private int lang_id;
        private int self_rating;
        private float net_rating;
        public int UserId
        {
            get { return user_id; }
        }
        public int LangId
        {
            get { return lang_id; }
        }
        public int SelfRating
        {
            get { return self_rating; }
        }
        public float NetRating
        {
            get { return net_rating; }
        }
    }
}
