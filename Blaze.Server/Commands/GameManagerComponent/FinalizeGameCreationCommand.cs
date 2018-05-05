using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class FinalizeGameCreationCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];

            Log.Info(string.Format("Client {0} updating game {1} session", request.Client.ID, gameID.Value));

            request.Reply();
        }
    }
}
