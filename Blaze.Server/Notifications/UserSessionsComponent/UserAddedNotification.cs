using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UserAddedNotification
    {
        public static void Notify(Client client, ulong userID, string userName)
        {
            var data = new List<Tdf>
            {
                new TdfStruct("DATA", new List<Tdf>
                {
                    new TdfUnion("ADDR", NetworkAddressMember.Unset, new List<Tdf> { }),
                    new TdfString("BPS", ""),
                    new TdfString("CTY", ""),
                    new TdfMap("DMAP", TdfBaseType.Integer, TdfBaseType.Integer, new Dictionary<object, object>
                    {
                        { (ulong)0x70001, (ulong)55 },
                        { (ulong)0x70002, (ulong)707 }
                    }),
                    new TdfInteger("HWFG", 0),
                    new TdfStruct("QDAT", new List<Tdf>
                    {
                        new TdfInteger("DBPS", 0),
                        new TdfInteger("NATT", (ulong)NatType.Open),
                        new TdfInteger("UBPS", 0)
                    }),
                    new TdfInteger("UATT", 0)
                }),
                new TdfStruct("USER", new List<Tdf>
                {
                    new TdfInteger("AID", userID),
                    new TdfInteger("ALOC", client.Localization),
                    new TdfInteger("ID", userID),
                    new TdfString("NAME", userName)
                })
            };

            client.Notify(Component.UserSessions, 2, 0, data);
        }
    }
}
