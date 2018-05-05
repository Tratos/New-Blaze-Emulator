using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class AuthenticationComponent
    {
        public static void HandleRequest(Request request)
        {
            switch (request.CommandID)
            {
                case 0x28:
                    LoginCommand.HandleRequest(request);
                    break;

                case 0x32:
                    SilentLoginCommand.HandleRequest(request);
                    break;

                case 0x6E:
                    LoginPersonaCommand.HandleRequest(request);
                    break;

                case 0x1D:
                    ListUserEntitlements2Command.HandleRequest(request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
