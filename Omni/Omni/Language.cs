using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public struct Language
    {
        public Language(int id, string code)
        {
            this.id = id;
            this.code = code;
        }
        public int id;
        public string code;
    }
}
