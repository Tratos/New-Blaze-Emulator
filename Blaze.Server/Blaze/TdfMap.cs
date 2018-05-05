using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class TdfMap : Tdf
    {
        public TdfBaseType KeyType;
        public TdfBaseType ValueType;

        public Dictionary<object, object> Map;

        public TdfMap(string label, TdfBaseType keyType, TdfBaseType valueType, Dictionary<object, object> map)
        {
            this.Label = label;
            this.Type = TdfBaseType.Map;

            this.KeyType = keyType;
            this.ValueType = valueType;

            this.Map = map;
        }
    }
}
