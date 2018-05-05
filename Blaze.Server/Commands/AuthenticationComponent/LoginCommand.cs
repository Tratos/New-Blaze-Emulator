using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class LoginCommand
    {
        public static void HandleRequest(Request request)
        {
            var email = (TdfString)request.Data["MAIL"];

            Log.Info(string.Format("Client {0} logging in with email {1}", request.Client.ID, email.Value));

            var user = Configuration.Users.Find(u => u.Email == email.Value);

            if (user == null)
            {
                Log.Warn("User not found");
                return;
            }

            request.Client.User = user;

            var data = new List<Tdf>
            {
                new TdfString("LDHT", ""),
                new TdfInteger("NTOS", 0),
                new TdfString("PCTK", ""),
                new TdfList("PLST", TdfBaseType.Struct, new ArrayList
                {
                    new List<Tdf>
                    {
                        new TdfString("DSNM", user.Name),
                        new TdfInteger("LAST", 0),
                        new TdfInteger("PID", user.ID),
                        new TdfInteger("STAS", 2),
                        new TdfInteger("XREF", 0),
                        new TdfInteger("XTYP", (ulong)ExternalRefType.Unknown)
                    }
                }),
                new TdfString("PRIV", ""),
                new TdfString("SKEY", ""),
                new TdfInteger("SPAM", 1),
                new TdfString("THST", ""),
                new TdfString("TSUI", ""),
                new TdfString("TURI", ""),
                new TdfInteger("UID", (ulong)request.Client.ID)
            };

            request.Reply(0, data);
        }
    }
}
