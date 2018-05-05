using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfBlob : Tdf
    {
        public byte[] Data;

        public TdfBlob(string label, byte[] data)
        {
            this.Label = label;
            this.Type = TdfBaseType.Binary;

            this.Data = data;
        }
    }
}
