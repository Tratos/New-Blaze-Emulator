using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public enum Component
    {
        Authentication = 1,
        GameManager = 4,
        Redirector,
        Stats = 7,
        Util = 9,
        Clubs = 11,
        GameReporting = 0x1C,
        RSP = 0x801,
        UserSessions = 0x7802
    }

    public enum MessageType
    {
        Message,
        Reply,
        Notification,
        ErrorReply
    }

    public enum NetworkAddressMember
    {
        XboxClientAddress,
        XboxServerAddress,
        IPPAirAddress,
        IPAddress,
        HostnameAddress,
        Unset = 0x7F
    }

    public enum UpnpStatus
    {
        Unknown,
        Found,
        Enabled
    }

    public enum TelemetryOpt
    {
        OptOut,
        OptIn
    }

    public enum GameState
    {
        NewState,
        Initializing,
        Virtual,
        PreGame = 0x82,
        InGame = 0x83,
        PostGame = 4,
        Migrating,
        Destructing,
        Resetable,
        ReplaySetup
    }

    public enum PlayerState
    {
        Disconnected,
        Connected = 2
    }

    public enum PresenceMode
    {
        None,
        Standard,
        Private
    }

    public enum VoipTopology
    {
        Disabled,
        DedicatedServer,
        PeerToPeer
    }

    public enum GameNetworkTopology
    {
        ClientServerPeerHosted,
        ClientServerDedicated,
        PeerToPeerFullMesh = 0x82,
        PeerToPeerPartialMesh,
        PeerToPeerDirtyCastFailover
    }

    public enum PlayerRemovedReason
    {
        PlayerJoinTimeout,
        PlayerConnLost,
        BlazeServerConnLost,
        MigrationFailed,
        GameDestroyed,
        GameEnded,
        PlayerLeft,
        GroupLeft,
        PlayerKicked,
        PlayerKickedWithBan,
        PlayerJoinFromQueueFailed,
        PlayerReservationTimeout,
        HostEjected
    }

    public enum ClientType
    {
        GameplayUser,
        HttpUser,
        DedicatedServer,
        Tools,
        Invalid
    }

    public enum ExternalRefType : ushort
    {
        Unknown,
        Xbox,
        PS3,
        Wii,
        Mobile,
        LegacyProfileID,
        Twitter,
        Facebook
    };

    public enum NatType
    {
        Open,
        Moderate,
        Sequential,
        Strict,
        Unknown
    }
}
