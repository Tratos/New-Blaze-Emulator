using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SilentLoginCommand
    {
        public static void HandleRequest(Request request)
        {
            var personaID = (TdfInteger)request.Data["PID"];

            var user = Configuration.Users.Find(u => u.ID == personaID.Value);
            request.Client.User = user;

            var data = new List<Tdf>
            {
                new TdfInteger("AGUP", 0),
                new TdfString("LDHT", ""),
                new TdfInteger("NTOS", 0),
                new TdfString("PCTK", ""),
                new TdfString("PRIV", ""),
                new TdfStruct("SESS", new List<Tdf>
                {
                    new TdfInteger("BUID", request.Client.User.ID),
                    new TdfInteger("FRST", 0),
                    new TdfString("KEY", ""),
                    new TdfInteger("LLOG", 0),
                    new TdfString("MAIL", request.Client.User.Email),
                    new TdfStruct("PDTL", new List<Tdf>
                    {
                        new TdfString("DSNM", request.Client.User.Name),
                        new TdfInteger("LAST", 0),
                        new TdfInteger("PID", request.Client.User.ID),
                        new TdfInteger("STAS", 0),
                        new TdfInteger("XREF", 0),
                        new TdfInteger("XTYP", (ulong)ExternalRefType.Unknown)
                    }),
                    new TdfInteger("UID", (ulong)request.Client.ID)
                }),
                new TdfInteger("SPAM", 0),
                new TdfString("THST", ""),
                new TdfString("TSUI", ""),
                new TdfString("TURI", "")
            };

            request.Reply(0, data);

            UserAddedNotification.Notify(request.Client, request.Client.User.ID, request.Client.User.Name);
            UserUpdatedNotification.Notify(request.Client, request.Client.User.ID);
        }
    }
}
