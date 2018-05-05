using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class PreAuthCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} pre-authenticating", request.Client.ID));

            var clientData = (TdfStruct)request.Data["CDAT"];
            var clientType = (TdfInteger)clientData.Data.Find(tdf => tdf.Label == "TYPE");
            var clientService = (TdfString)clientData.Data.Find(tdf => tdf.Label == "SVCN");

            var clientInfo = (TdfStruct)request.Data["CINF"];
            var clientLocalization = (TdfInteger)clientInfo.Data.Find(tdf => tdf.Label == "LOC");

            request.Client.Type = (ClientType)clientType.Value;
            request.Client.Localization = (ulong)clientLocalization.Value;
            request.Client.Service = clientService.Value;

            // TODO: fix this
            var cids = new TdfList("CIDS", TdfBaseType.Integer, new ArrayList
            {
                //1, 25, 4, 27, 28, 6, 7, 9, 10, 11, 30720, 30721, 30722, 30723, 20, 30725, 30726, 2000
            });
            cids.List.AddRange((new ulong[] { 1, 25, 4, 27, 28, 6, 7, 9, 10, 11, 30720, 30721, 30722, 30723, 20, 30725, 30726, 2000 }).ToArray());

            var data = new List<Tdf>
            {
                new TdfInteger("ANON", 0),
                new TdfString("ASRC", "300294"),
                cids,
                new TdfString("CNGN", ""),
                new TdfStruct("CONF", new List<Tdf>
                {
                    new TdfMap("CONF", TdfBaseType.String, TdfBaseType.String, new Dictionary<object, object>
                    {
                        { "connIdleTimeout", "90s" },
                        { "defaultRequestTimeout", "80s" },
                        { "pingPeriod", "20s" },
                        { "voipHeadsetUpdateRate", "1000" },
                        { "xlspConnectionIdleTimeout", "300" }
                    })
                }),
                new TdfString("INST", request.Client.Service),
                new TdfInteger("MINR", 0),
                new TdfString("NASP", "cem_ea_id"),
                new TdfString("PILD", ""),
                new TdfString("PLAT", "pc"), // TODO: fetch from decoded data
                new TdfString("PTAG", ""),
                new TdfStruct("QOSS", new List<Tdf>
                {
                    new TdfStruct("BWPS", new List<Tdf>
                    {
                        new TdfString("PSA", "127.0.0.1"),
                        new TdfInteger("PSP", 17502),
                        new TdfString("SNA", "ams")
                    }),
                    new TdfInteger("LNP", 10),
                    new TdfMap("LTPS", TdfBaseType.String, TdfBaseType.Struct, new Dictionary<object, object>
                    {
                        { "ams", new List<Tdf>
                            {
                                new TdfString("PSA", "127.0.0.1"),
                                new TdfInteger("PSP", 17502),
                                new TdfString("SNA", "ams")
                            }
                        }
                    }),
                    new TdfInteger("SVID", 1161889797)
                }),
                new TdfString("RSRC", "300294"),
                new TdfString("SVER", "Blaze 3.15.08.0 (CL# 1060080)")
            };

            request.Reply(0, data);
        }
    }
}
