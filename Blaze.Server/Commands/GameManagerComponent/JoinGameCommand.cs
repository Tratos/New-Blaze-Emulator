using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class JoinGameCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];

            if (!GameManager.Games.ContainsKey(gameID.Value))
            {
                request.Reply(0x12D0004, null);
                return;
            }

            request.Client.GameID = gameID.Value;

            var data = new List<Tdf>
            {
                new TdfInteger("GID", (ulong)gameID.Value),
                new TdfInteger("JGS", 0)
            };

            request.Reply(0, data);

            var game = GameManager.Games[gameID.Value];
            var gameClient = BlazeServer.Clients[game.ClientID];

            game.Slots.Add(request.Client.User.ID);
            var slotID = game.Slots.FindIndex(slot => slot == request.Client.User.ID);

            Log.Info(string.Format("Client {0} reserving slot {1} in game {2}", request.Client.ID, slotID, gameID.Value));

            UserAddedNotification.Notify(request.Client, gameClient.User.ID, gameClient.User.Name);
            UserUpdatedNotification.Notify(request.Client, gameClient.User.ID);

            PlayerJoiningNotification.Notify(request.Client);

            JoiningPlayerInitiateConnectionsNotification.Notify(request.Client);
            PlayerClaimingReservationNotification.Notify(request.Client);            
        }
    }
}
