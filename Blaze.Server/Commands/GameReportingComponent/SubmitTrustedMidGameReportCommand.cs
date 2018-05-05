using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SubmitTrustedMidGameReportCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} submitting trusted mid-game report", request.Client.ID));

            request.Reply();
        }
    }
}
