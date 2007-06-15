using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class UserRankRating
    {
        public UserRankRating()
        {
        }
        public UserRankRating(User user, int lang_id, float net_rating)
        {
            this.user = user;
            this.lang_id = lang_id;
            this.net_rating = net_rating;
        }
        public User user;
        public int lang_id;
        public float net_rating;
    }
}
