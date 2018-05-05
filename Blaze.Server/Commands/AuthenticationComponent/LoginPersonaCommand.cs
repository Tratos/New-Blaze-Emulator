using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class LoginPersonaCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} logging in to persona {1}", request.Client.ID, request.Client.User.Name));

            var data = new List<Tdf>
            {
                new TdfInteger("BUID", request.Client.User.ID),
                new TdfInteger("FRST", 0),
                new TdfString("KEY", ""),
                new TdfInteger("LLOG", Utils.GetUnixTime()),
                new TdfString("MAIL", request.Client.User.Email),
                new TdfStruct("PDTL", new List<Tdf>
                {
                    new TdfString("DSNM", request.Client.User.Name),
                    new TdfInteger("LAST", Utils.GetUnixTime()),
                    new TdfInteger("PID", request.Client.User.ID),
                    new TdfInteger("STAS", 2),
                    new TdfInteger("XREF", 0),
                    new TdfInteger("XTYP", (ulong)ExternalRefType.Unknown)
                }),
                new TdfInteger("UID", (ulong)request.Client.ID)
            };

            request.Reply(0, data);

            UserAddedNotification.Notify(request.Client, request.Client.User.ID, request.Client.User.Name);
            UserUpdatedNotification.Notify(request.Client, request.Client.User.ID);
        }
    }
}
