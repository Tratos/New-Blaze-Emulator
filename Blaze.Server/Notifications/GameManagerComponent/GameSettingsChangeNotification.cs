using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GameSettingsChangeNotification
    {
        public static void Notify(Client client)
        {
            var game = GameManager.Games[client.GameID];

            var data = new List<Tdf>
            {
                new TdfInteger("ATTR", (ulong)game.Settings),
                new TdfInteger("GID", game.ID)
            };

            client.Notify(Component.GameManager, 0x6E, 0, data);
        }
    }
}
