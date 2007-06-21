using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class Interest
    {
        public Interest()
        {
        }
        public Interest(int id, int parent_id, string name, int lang_id)
        {
            this.id = id;
            this.parent_id = parent_id;
            this.name = name;
            this.lang_id = lang_id;
        }
        public int id;
        public int parent_id;
        public string name;
        public int lang_id;
    }
}
