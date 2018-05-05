using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GetStatsAsyncNotification
    {
        public static void Notify(Client client)
        {
            var data = new List<Tdf>
            {

            };

            client.Notify(Component.Stats, 0x32, 0, data);
        }
    }
}
