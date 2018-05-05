using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfList : Tdf
    {
        public TdfBaseType ListType;
        public ArrayList List;

        public bool Stub;

        public TdfList(string label, TdfBaseType listType, ArrayList list, bool stub = false)
        {
            this.Label = label;
            this.Type = TdfBaseType.List;

            this.ListType = listType;
            this.List = list;

            this.Stub = stub;
        }
    }
}
