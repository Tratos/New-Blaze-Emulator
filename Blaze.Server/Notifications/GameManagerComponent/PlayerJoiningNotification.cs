using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class PlayerJoiningNotification
    {
        public static void Notify(Client client)
        {
            var game = GameManager.Games[client.GameID];
            var gameClient = BlazeServer.Clients[game.ClientID];

            var slotID = game.Slots.FindIndex(slot => slot == client.User.ID);

            var data = new List<Tdf>
            {
                new TdfInteger("GID", client.GameID),
                new TdfStruct("PDAT", new List<Tdf>
                {
                    new TdfInteger("EXID", 0),
                    new TdfInteger("GID", client.GameID),
                    new TdfInteger("LOC", client.Localization),
                    new TdfString("NAME", client.User.Name),
                    new TdfMap("PATT", TdfBaseType.String, TdfBaseType.String, new Dictionary<object, object>
                    {
                        { "Premium", "False" }
                    }),
                    new TdfInteger("PID", client.User.ID),
                    new TdfUnion("PNET", NetworkAddressMember.IPPAirAddress, new List<Tdf>
                    {
                        new TdfStruct("VALU", new List<Tdf>
                        {
                            new TdfStruct("EXIP", new List<Tdf>
                            {
                                new TdfInteger("IP", client.ExternalIP),
                                new TdfInteger("PORT", client.ExternalPort)
                            }),
                            new TdfStruct("INIP", new List<Tdf>
                            {
                                new TdfInteger("IP", client.InternalIP),
                                new TdfInteger("PORT", client.InternalPort)
                            })
                        })
                    }),
                    new TdfInteger("SID", (ulong)slotID),
                    new TdfInteger("SLOT", 0),
                    new TdfInteger("STAT", 0),
                    new TdfInteger("TIDX", 65535),
                    new TdfInteger("TIME", 0),
                    new TdfVector3("UGID", 0, 0, 0),
                    new TdfInteger("UID", (ulong)client.ID)
                })
            };

            gameClient.Notify(Component.GameManager, 0x15, 0, data);
        }
    }
}
