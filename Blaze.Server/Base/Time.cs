using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public static class Time
    {
        private static long _initialCount;

        public static void Initialize()
        {
            _initialCount = Stopwatch.GetTimestamp();
        }

        public static long CurrentTime
        {
            get
            {
                return (Stopwatch.GetTimestamp() - _initialCount) / (Stopwatch.Frequency / 1000);
            }
        }
    }
}
