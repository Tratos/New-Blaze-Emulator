using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class JoiningPlayerInitiateConnectionsNotification
    {
        public static void Notify(Client client)
        {
            var game = GameManager.Games[client.GameID];

            var slotID = game.Slots.FindIndex(slot => slot == client.User.ID);

            var data = new List<Tdf>
            {
                new TdfStruct("GAME", new List<Tdf>
                {
                    new TdfList("ADMN", TdfBaseType.Integer, new ArrayList { client.User.ID }),
                    new TdfMap("ATTR", TdfBaseType.String, TdfBaseType.String, game.Attributes),
                    new TdfList("CAP", TdfBaseType.Integer, game.Capacity),
                    new TdfInteger("GID", (ulong)client.GameID),
                    new TdfString("GNAM", game.Name),
                    new TdfInteger("GPVH", 666),
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
                    new TdfInteger("IGNO", 0),
                    new TdfInteger("MCAP", game.MaxPlayers),
                    new TdfStruct("NQQS", new List<Tdf>
                    {
                        new TdfInteger("DBPS", 0),
                        new TdfInteger("NATT", 0),
                        new TdfInteger("UBPS", 0)
                    }),
                    new TdfInteger("NRES", (ulong)game.NotResetable),
                    new TdfInteger("NTOP", (ulong)game.NetworkTopology),
                    new TdfString("PGID", ""),
                    new TdfBlob("PGSR", new byte[] { }),
                    new TdfStruct("PHST", new List<Tdf>
                    {
                        new TdfInteger("HPID", client.User.ID),
                        new TdfInteger("HSLT", 1)
                    }),
                    new TdfInteger("PRES", (ulong)game.PresenceMode),
                    new TdfString("PSAS", "ams"),
                    new TdfInteger("QCAP", (ulong)game.QueueCapacity),
                    new TdfInteger("SEED", 2291),
                    new TdfInteger("TCAP", 0),
                    new TdfStruct("THST", new List<Tdf>
                    {
                        new TdfInteger("HPID", (ulong)client.GameID),
                        new TdfInteger("HSLT", 0)
                    }),
                    new TdfString("UUID", "714b05dc-93bc-49ac-961c-cb38b574f30a"),
                    new TdfInteger("VOIP", (ulong)game.VoipTopology),
                    new TdfString("VSTR", "67")
                }),
                new TdfList("PROS", TdfBaseType.Struct, new ArrayList
                {
                    new List<Tdf>
                    {
                        new TdfBlob("BLOB", new byte[] { }),
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
                        new TdfInteger("STAT", 2),
                        new TdfInteger("TIDX", 65535),
                        new TdfInteger("TIME", 0),
                        new TdfVector3("UGID", 0, 0, 0),
                        new TdfInteger("UID", client.User.ID)
                    }
                }),
                new TdfInteger("REAS", 0),
                new TdfStruct("VALU", new List<Tdf>
                {
                    new TdfInteger("DCTX", 3)
                })
            };

            client.Notify(Component.GameManager, 0x16, 0, data);
        }
    }
}