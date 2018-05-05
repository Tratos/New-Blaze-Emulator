using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SetGameSettingsCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];
            var gameSettings = (TdfInteger)request.Data["GSET"];

            Log.Info(string.Format("Client {0} setting game settings to {1}", gameID.Value, gameSettings.Value));

            GameManager.Games[gameID.Value].Settings = gameSettings.Value;

            request.Reply();

            GameSettingsChangeNotification.Notify(request.Client);
        }
    }
}
