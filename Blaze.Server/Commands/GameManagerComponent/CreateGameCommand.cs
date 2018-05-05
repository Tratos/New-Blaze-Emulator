using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class CreateGameCommand
    {
        public static void HandleRequest(Request request)
        {
            var attr = (TdfMap)request.Data["ATTR"];
            var gameName = (TdfString)request.Data["GNAM"];
            var gameSettings = (TdfInteger)request.Data["GSET"];
            var playerCapacity = (TdfList)request.Data["PCAP"];
            var igno = (TdfInteger)request.Data["IGNO"];
            var pmax = (TdfInteger)request.Data["PMAX"];
            var nres = (TdfInteger)request.Data["NRES"];

            var notResetable = (TdfInteger)request.Data["NTOP"];
            var voip = (TdfInteger)request.Data["VOIP"];

            var presence = (TdfInteger)request.Data["PRES"];
            var qcap = (TdfInteger)request.Data["QCAP"];

            var game = new Game();

            game.ClientID = request.Client.ID;

            game.Name = gameName.Value;
            game.Attributes = attr.Map;
            game.Capacity = playerCapacity.List;

            game.Level = attr.Map["level"].ToString();
            game.GameType = attr.Map["levellocation"].ToString();

            game.MaxPlayers = (ushort)pmax.Value;
            game.NotResetable = (byte)nres.Value;
            game.QueueCapacity = (ushort)qcap.Value;
            game.PresenceMode = (PresenceMode)presence.Value;
            game.State = GameState.Initializing;

            game.NetworkTopology = (GameNetworkTopology)notResetable.Value;
            game.VoipTopology = (VoipTopology)voip.Value;

            game.Settings = gameSettings.Value;

            game.InternalIP = request.Client.InternalIP;
            game.InternalPort = request.Client.InternalPort;

            game.ExternalIP = request.Client.ExternalIP;
            game.ExternalPort = request.Client.ExternalPort;

            GameManager.Add(game);

            request.Client.GameID = game.ID;

            Log.Info($"Client {request.Client.ID} creating game {game.ID} ({game.Name})");

            var data = new List<Tdf>
            {
                new TdfInteger("GID", (ulong)game.ID)
            };

            request.Reply(0, data);

            GameStateChangeNotification.Notify(request.Client);
            GameSetupNotification.Notify(request.Client);
        }
    }
}
