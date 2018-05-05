using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfInteger : Tdf
    {
        public ulong Value;

        public TdfInteger(string label, ulong value)
        {
            this.Label = label;
            this.Type = TdfBaseType.Integer;

            this.Value = value;
        }
    }
}
