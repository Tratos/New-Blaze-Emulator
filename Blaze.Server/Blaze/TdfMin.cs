using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfMin : Tdf
    {
        public ushort Value;

        public TdfMin(string label, ushort value)
        {
            this.Label = label;
            this.Type = TdfBaseType.Min;

            this.Value = value;
        }
    }
}
