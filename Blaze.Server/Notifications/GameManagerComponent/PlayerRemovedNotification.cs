using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class PlayerRemovedNotification
    {
        public static void Notify(Client client, ulong playerID)
        {
            var data = new List<Tdf>
            {
                new TdfInteger("GID", client.GameID),
                new TdfInteger("PID", playerID),
                new TdfInteger("REAS", 1)
            };

            client.Notify(Component.GameManager, 0x28, 0, data);
        }
    }
}
