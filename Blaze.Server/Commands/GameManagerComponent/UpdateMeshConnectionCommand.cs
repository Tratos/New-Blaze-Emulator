using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UpdateMeshConnectionCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} updating mesh connection", request.Client.ID));

            var gameID = (TdfInteger)request.Data["GID"];

            var targ = (TdfList)request.Data["TARG"];
            var targData = (List<Tdf>)targ.List[0];
            var playerID = (TdfInteger)targData[1];
            var stat = (TdfInteger)targData[2];

            request.Reply();

            if (stat.Value == 2)
            {
                if (request.Client.Type == ClientType.GameplayUser)
                {
                    GamePlayerStateChangeNotification.Notify(request.Client, gameID.Value, request.Client.User.ID);
                    PlayerJoinCompletedNotification.Notify(request.Client, gameID.Value, request.Client.User.ID);
                }
                else if (request.Client.Type == ClientType.DedicatedServer)
                {
                    GamePlayerStateChangeNotification.Notify(request.Client, gameID.Value, playerID.Value);
                    PlayerJoinCompletedNotification.Notify(request.Client, gameID.Value, playerID.Value);
                }
            }
            else if (stat.Value == 0)
            {
                if (request.Client.Type == ClientType.GameplayUser)
                {
                    var game = GameManager.Games[gameID.Value];
                    game.Slots.Remove(playerID.Value);

                    PlayerRemovedNotification.Notify(request.Client, playerID.Value);
                }
                else if (request.Client.Type == ClientType.DedicatedServer)
                {
                    var game = GameManager.Games[gameID.Value];
                    game.Slots.Remove(playerID.Value);

                    PlayerRemovedNotification.Notify(request.Client, playerID.Value);
                }
            }
        }
    }
}
