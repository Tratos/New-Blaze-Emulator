using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SubmitTrustedEndGameReportCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} submitting trusted end-game report", request.Client.ID));

            request.Reply();
        }
    }
}
