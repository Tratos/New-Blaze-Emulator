using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class Game
    {
        public ulong ID { get; set; }

        public long ClientID { get; set; }

        public string Name { get; set; }

        public Dictionary<object, object> Attributes { get; set; }

        public ArrayList Capacity { get; set; }

        public string Level { get; set; }

        public string GameType { get; set; }

        public ushort MaxPlayers { get; set; }

        public byte NotResetable { get; set; }

        public ushort QueueCapacity { get; set; }

        public PresenceMode PresenceMode { get; set; }

        public GameState State { get; set; }

        public GameNetworkTopology NetworkTopology { get; set; }

        public VoipTopology VoipTopology { get; set; }

        public ulong Settings { get; set; }

        public ulong InternalIP { get; set; }

        public ushort InternalPort { get; set; }

        public ulong ExternalIP { get; set; }

        public ulong ExternalPort { get; set; }

        public List<ulong> Slots { get; set; }

        public Game()
        {
            Slots = new List<ulong>() { 0 };
        }
    }
}
