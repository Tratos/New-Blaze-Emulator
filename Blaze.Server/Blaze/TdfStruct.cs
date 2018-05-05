using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfStruct : Tdf
    {
        public List<Tdf> Data;

        public TdfStruct(string label, List<Tdf> data)
        {
            this.Label = label;
            this.Type = TdfBaseType.Struct;

            this.Data = data;
        }
    }
}
