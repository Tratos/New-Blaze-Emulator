using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfUnion : Tdf
    {
        public NetworkAddressMember activeMember;
        public List<Tdf> Data;

        public TdfUnion(string label, NetworkAddressMember value, List<Tdf> data)
        {
            this.Label = label;
            this.Type = TdfBaseType.Union;

            this.activeMember = value;
            this.Data = data;
        }
    }
}
