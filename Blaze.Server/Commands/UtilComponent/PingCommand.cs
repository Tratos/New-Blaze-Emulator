using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class PingCommand
    {
        public static void HandleRequest(Request request)
        {
            var data = new List<Tdf>
            {
                new TdfInteger("STIM", Utils.GetUnixTime())
            };

            request.Reply(0, data);
        }
    }
}
