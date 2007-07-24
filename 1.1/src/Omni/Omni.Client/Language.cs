using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class Language
    {
        internal Language(org.omniproject.service.Language language)
        {
            this.id = language.id;
            this.code = language.code;
        }
        private int id;
        private string code;
        public int ID
        {
            get { return id; }
        }
        public string Code
        {
            get { return code; }
        }
    }
}
