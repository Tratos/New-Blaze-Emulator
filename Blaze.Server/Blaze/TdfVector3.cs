using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfVector3 : Tdf
    {
        public ulong Value1;
        public ulong Value2;
        public ulong Value3;

        public TdfVector3(string label, ulong value1, ulong value2, ulong value3)
        {
            this.Label = label;
            this.Type = TdfBaseType.TDF_TYPE_BLAZE_OBJECT_ID;

            this.Value1 = value1;
            this.Value2 = value2;
            this.Value3 = value3;
        }
    }
}
