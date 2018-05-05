using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfString : Tdf
    {
        public string Value;

        public TdfString(string label, string value)
        {
            this.Label = label;
            this.Type = TdfBaseType.String;

            this.Value = value;
        }
    }
}
