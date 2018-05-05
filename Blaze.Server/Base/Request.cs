using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class Request
    {
        public Client Client { get; set; }

        public Component ComponentID { get; set; }

        public int CommandID { get; set; }

        public int ErrorCode { get; set; }

        public MessageType MessageType { get; set; }

        public int MessageID { get; set; }

        public Dictionary<string, Tdf> Data { get; set; }

        public Request(Client client)
        {
            Client = client;
        }

        public void Reply(int errorCode = 0, List<Tdf> data = null)
        {
            Client.Reply(this, errorCode, data);
        }
    }
}
