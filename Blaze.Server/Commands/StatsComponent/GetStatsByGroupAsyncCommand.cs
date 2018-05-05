using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GetStatsByGroupAsyncCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} requested stats by group", request.Client.ID));

            GetStatsAsyncNotification.Notify(request.Client);
        }
    }
}
