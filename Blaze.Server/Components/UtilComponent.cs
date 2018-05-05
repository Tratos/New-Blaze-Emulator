using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UtilComponent
    {
        public static void HandleRequest(Request request)
        {
            switch (request.CommandID)
            {
                case 1:
                    FetchClientConfigCommand.HandleRequest(request);
                    break;

                case 2:
                    PingCommand.HandleRequest(request);
                    break;

                case 5:
                    GetTelemetryServerCommand.HandleRequest(request);
                    break;

                case 7:
                    PreAuthCommand.HandleRequest(request);
                    break;

                case 8:
                    PostAuthCommand.HandleRequest(request);
                    break;

                case 0xB:
                    UserSettingsSaveCommand.HandleRequest(request);
                    break;

                case 0xC:
                    UserSettingsLoadAllCommand.HandleRequest(request);
                    break;

                case 0x16:
                    SetClientMetricsCommand.HandleRequest(request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
