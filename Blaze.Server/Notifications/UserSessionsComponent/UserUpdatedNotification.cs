using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UserUpdatedNotification
    {
        public static void Notify(Client client, ulong userID)
        {
            var data = new List<Tdf>
            {
                new TdfInteger("FLGS", 3),
                new TdfInteger("ID", userID)
            };

            client.Notify(Component.UserSessions, 5, 0, data);
        }
    }
}
