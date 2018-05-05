using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class PlayerJoinCompletedNotification
    {
        public static void Notify(Client client, ulong gameID, ulong personaID)
        {
            //var game = GameManager.Games[client.GameID];
            //var gameClient = BlazeServer.Clients[game.ClientID];

            var data = new List<Tdf>
            {
                //new TdfInteger("GID", client.GameID),
                //new TdfInteger("PID", (client.Type == ClientType.GameplayUser) ? gameClient.User.ID : client.User.ID)
                new TdfInteger("GID", gameID),
                new TdfInteger("PID", personaID)
            };

            client.Notify(Component.GameManager, 0x1E, 0, data);
        }
    }
}
