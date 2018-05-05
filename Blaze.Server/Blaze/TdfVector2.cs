using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfVector2 : Tdf
    {
        public ulong Value1;
        public ulong Value2;

        public TdfVector2(string label, ulong value1, ulong value2)
        {
            this.Label = label;
            this.Type = TdfBaseType.TDF_TYPE_BLAZE_OBJECT_TYPE;

            this.Value1 = value1;
            this.Value2 = value2;
        }
    }
}
