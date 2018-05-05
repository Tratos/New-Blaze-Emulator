using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GameSetupNotification
    {
        public static void Notify(Client client)
        {
            var game = GameManager.Games[client.GameID];

            var data = new List<Tdf>
            {
                new TdfStruct("GAME", new List<Tdf>
                {
                    new TdfList("ADMN", TdfBaseType.Integer, new ArrayList
                    {
                        client.User.ID
                    }),
                    new TdfMap("ATTR", TdfBaseType.String, TdfBaseType.String, game.Attributes),
                    new TdfList("CAP", TdfBaseType.Integer, game.Capacity),
                    new TdfInteger("GID", game.ID),
                    new TdfString("GNAM", game.Name),
                    new TdfInteger("GPVH", 666),
                    //new TdfInteger("GSET", game.gset), TODO
                    new TdfInteger("GSID", 1),
                    new TdfInteger("GSTA", (ulong)game.State),
                    new TdfString("GTYP", "frostbite_multiplayer"),
                    new TdfList("HNET", TdfBaseType.Struct, new ArrayList
                    {
                        new List<Tdf>
                        {
                            new TdfStruct("EXIP", new List<Tdf>
                            {
                                new TdfInteger("IP", game.ExternalIP),
                                new TdfInteger("PORT", game.ExternalPort)
                            }),
                            new TdfStruct("INIP", new List<Tdf>
                            {
                                new TdfInteger("IP", game.InternalIP),
                                new TdfInteger("PORT", game.InternalPort)
                            })
                        }
                    }, true),
                    new TdfInteger("HSES", 13666),
                    new TdfInteger("MCAP", game.MaxPlayers),
                    new TdfInteger("NRES", game.NotResetable),
                    new TdfInteger("NTOP", (ulong)game.NetworkTopology),
                    new TdfString("PGID", "b6852db1-ba37-4b40-aea3-0bd16efba4f9"),
                    new TdfBlob("PGSR", new byte[] { }),
                    new TdfStruct("PHST", new List<Tdf>
                    {
                        new TdfInteger("HPID", client.User.ID),
                        new TdfInteger("HSLT", 1)
                    }),
                    new TdfInteger("PRES", (ulong)game.PresenceMode),
                    new TdfString("PSAS", "ams"),
                    new TdfInteger("QCAP", (ulong)game.QueueCapacity),
                    new TdfUnion("REAS", NetworkAddressMember.XboxClientAddress, new List<Tdf> { }),
                    new TdfStruct("VALU", new List<Tdf>
                    {
                        new TdfInteger("DCTX", 0)
                    }),
                    new TdfInteger("SEED", 2291),
                    new TdfInteger("TCAP", 0),
                    new TdfStruct("THST", new List<Tdf>
                    {
                        new TdfInteger("HPID", client.GameID),
                        new TdfInteger("HSLT", 0)
                    }),
                    new TdfString("UUID", "714b05dc-93bc-49ac-961c-cb38b574f30a"),
                    new TdfInteger("VOIP", (ulong)game.VoipTopology),
                    new TdfString("VSTR", "67")
                })
            };

            client.Notify(Component.GameManager, 0x14, 0, data);
        }
    }
}
