using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    [Serializable]
    public class User
    {
        public string name = "a";
        internal int id = 10;
        public int ID
        {
            get
            {
                return id;
            }
        }
    }
}
