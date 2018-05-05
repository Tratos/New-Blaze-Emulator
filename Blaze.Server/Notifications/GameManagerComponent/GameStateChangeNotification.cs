using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GameStateChangeNotification
    {
        public static void Notify(Client client)
        {
            var game = GameManager.Games[client.GameID];

            var data = new List<Tdf>
            {
                new TdfInteger("GID", client.GameID),
                new TdfInteger("GSTA", (ulong)game.State)
            };

            client.Notify(Component.GameManager, 0x64, 0, data);
        }
    }
}
