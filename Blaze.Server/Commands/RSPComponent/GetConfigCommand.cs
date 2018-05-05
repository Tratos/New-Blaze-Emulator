using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GetConfigCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} requested RSP configuration", request.Client.ID));

            foreach (var tdf in request.Data)
            {
                Log.Info(tdf.Key + "(" + tdf.Value.Type + ")");
            }

            request.Reply();
        }
    }
}
