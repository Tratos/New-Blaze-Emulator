using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UpdateNetworkInfoCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} updating network info", request.Client.ID));

            var addr = (TdfUnion)request.Data["ADDR"];
            var valu = (TdfStruct)addr.Data.Find(tdf => tdf.Label == "VALU");

            var inip = (TdfStruct)valu.Data.Find(tdf => tdf.Label == "INIP");
            var ip = (TdfInteger)inip.Data.Find(tdf => tdf.Label == "IP");
            var port = (TdfInteger)inip.Data.Find(tdf => tdf.Label == "PORT");

            request.Client.InternalIP = ip.Value;
            request.Client.InternalPort = (ushort)port.Value;

            request.Client.ExternalIP = ip.Value;
            request.Client.ExternalPort = (ushort)port.Value;

            request.Reply();
        }
    }
}
