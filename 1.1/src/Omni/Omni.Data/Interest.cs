using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public class Interest
    {
        public Interest()
        {
        }
        public Interest(int id, int parent_id, string name)
        {
            this.id = id;
            this.parent_id = parent_id;
            this.name = name;
        }
        public int id;
        public int parent_id;
        public string name;
    }
}
