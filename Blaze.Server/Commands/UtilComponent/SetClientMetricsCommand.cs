using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SetClientMetricsCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} setting metrics", request.Client.ID));

            request.Reply();
        }
    }
}
