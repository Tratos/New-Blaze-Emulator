using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GetStatGroupCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} requested stats group", request.Client.ID));

            var data = new List<Tdf>
            {
                
            };

            request.Reply(0, data);
        }
    }
}
