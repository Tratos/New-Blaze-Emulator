using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public class Client
    {
        public long ID { get; set; }

        public ulong GameID { get; set; }

        public User User { get; set; }

        public Socket Socket { get; set; }

        public SslStream Stream { get; set; }

        public IPEndPoint EndPoint { get; set; }

        public byte[] ReceiveBuffer { get; set; }

        public long LastSeen { get; private set; }

        public ClientType Type { get; set; }

        public ulong Localization { get; set; }

        public string Service { get; set; }

        public ulong InternalIP { get; set; }

        public ushort InternalPort { get; set; }

        public ulong ExternalIP { get; set; }

        public ulong ExternalPort { get; set; }

        public Client()
        {
            ReceiveBuffer = new byte[2048];
        }

        public void Touch()
        {
            LastSeen = Time.CurrentTime;
        }

        public void HandleRequest(byte[] buffer, int length)
        {
            Touch();

            int headerSize = (((buffer[9] >> 3) & 4) + ((buffer[9] >> 3) & 2) + 12);

            Component componentID = (Component)(buffer[3] | (buffer[2] << 8));
            int commandID = buffer[5] | (buffer[4] << 8);
            int errorCode = buffer[7] | (buffer[6] << 8);
            MessageType messageType = (MessageType)((buffer[8] >> 4) << 16);
            int messageID = buffer[11] | ((buffer[10] | ((buffer[9] & 0xF) << 8)) << 8);

            int payloadSize = buffer[1] | (buffer[0] << 8);

            if (Convert.ToBoolean(buffer[9] & 0x10))
            {
                payloadSize |= (buffer[13] | (buffer[12] << 8) >> 16);
            }

            byte[] payload = buffer.Skip(headerSize).Take(payloadSize).ToArray();

            var decoder = new TdfDecoder(payload);
            var requestData = decoder.Decode();

            var request = new Request(this);

            request.ComponentID = componentID;
            request.CommandID = (ushort)commandID;
            request.ErrorCode = errorCode;
            request.MessageID = messageID;
            request.Data = requestData;

            HandleRequest(request);
        }

        private void HandleRequest(Request request)
        {
            switch (request.ComponentID)
            {
                case Component.Authentication:
                    AuthenticationComponent.HandleRequest(request);
                    break;

                case Component.GameManager:
                    GameManagerComponent.HandleRequest(request);
                    break;

                case Component.Redirector:
                    RedirectorComponent.HandleRequest(request);
                    break;

                case Component.Stats:
                    StatsComponent.HandleRequest(request);
                    break;

                case Component.Util:
                    UtilComponent.HandleRequest(request);
                    break;

                case Component.Clubs:
                    ClubsComponent.HandleRequest(request);
                    break;

                case Component.GameReporting:
                    GameReportingComponent.HandleRequest(request);
                    break;

                case Component.RSP:
                    RSPComponent.HandleRequest(request);
                    break;

                case Component.UserSessions:
                    UserSessionsComponent.HandleRequest(request);
                    break;

                default:
                    Log.Info(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }

        private void Send(Component componentID, int commandID, int errorCode, MessageType messageType, int messageID, List<Tdf> data)
        {
            var payload = new TdfEncoder(data).Encode();
            var stream = new MemoryStream();

            // encode payload size
            stream.WriteByte((byte)((payload.Length & 0xFFFF) >> 8));
            stream.WriteByte((byte)((byte)payload.Length & 0xFF));

            // encode header
            stream.WriteByte((byte)(((ushort)componentID >> 8) & 0xFF));
            stream.WriteByte((byte)((ushort)componentID & 0xFF));

            stream.WriteByte((byte)(((ushort)commandID >> 8) & 0xFF));
            stream.WriteByte((byte)((ushort)commandID & 0xFF));

            stream.WriteByte((byte)(((byte)errorCode >> 8) & 0xFF));
            stream.WriteByte((byte)((byte)errorCode & 0xFF));

            stream.WriteByte((byte)((byte)messageType * 16));
            stream.WriteByte((byte)(((byte)messageID >> 16) & 0xF));

            stream.WriteByte((byte)((byte)messageID >> 8));
            stream.WriteByte((byte)((byte)messageID & 0xFF));

            if (payload != null && payload.Length > 0)
            {
                stream.Write(payload, 0, payload.Length);
            }

            byte[] buffer = stream.GetBuffer();
            int position = (int)stream.Position;

            var outData = buffer.Take(position).ToArray();

            Stream.Write(outData, 0, outData.Length);
            Stream.Flush();
        }

        public void Notify(Component componentID, int commandID, int errorCode, List<Tdf> data)
        {
            Send(componentID, commandID, errorCode, MessageType.Notification, 0, data);
        }

        public void Reply(Request request, int errorCode, List<Tdf> data)
        {
            var messageType = (errorCode > 0) ? MessageType.ErrorReply : MessageType.Reply;

            Send(request.ComponentID, request.CommandID, errorCode, messageType, request.MessageID, data);
        }
    }
}
