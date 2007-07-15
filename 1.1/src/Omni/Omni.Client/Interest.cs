using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Client
{
    public class Interest
    {
        internal Interest(org.omniproject.service.Interest interest)
        {
            this.id = interest.id;
            this.parent_id = interest.parent_id;
            this.name = interest.name;
        }
        private int id;
        private int parent_id;
        private string name;
        public int ID
        {
            get { return id; }
        }
        public int ParentID
        {
            get { return parent_id; }
        }
        public string Name
        {
            get { return name; }
        }
    }
}
