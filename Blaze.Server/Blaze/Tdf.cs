using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public enum TdfBaseType
    {
        Min,
        Integer = 0,
        String,
        Binary,
        Struct,
        List,
        Map,
        Union,
        Variable,
        TDF_TYPE_BLAZE_OBJECT_TYPE,
        TDF_TYPE_BLAZE_OBJECT_ID,
        Float = 0xA,
        TimeValue = 0xB,
        Max = 0xC
    };

    public class Tdf
    {
        public string Label;
        public TdfBaseType Type;
    }
}
