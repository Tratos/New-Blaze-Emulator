using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class StatsComponent
    {
        public static void HandleRequest(Request request)
        {
            switch (request.CommandID)
            {
                case 4:
                    GetStatGroupCommand.HandleRequest(request);
                    break;

                case 0x10:
                    GetStatsByGroupAsyncCommand.HandleRequest(request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
