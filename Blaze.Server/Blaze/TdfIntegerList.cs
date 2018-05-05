using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfIntegerList : Tdf
    {
        public List<ulong> list;

        public TdfIntegerList(string label, List<ulong> list)
        {
            this.Label = label;
            this.Type = TdfBaseType.Variable;

            this.list = list;
        }
    }
}
