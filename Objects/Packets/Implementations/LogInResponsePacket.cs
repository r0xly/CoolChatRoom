using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Packets.Implementations
{
    public class LogInResponsePacket : Packet
    {
        public static new string PacketId => "LogInResponse";
        public string SessionToken { get; set; } = "";

        public static LogInResponsePacket Construct(string[] Arguments)
        {
            LogInResponsePacket Packet = new();
            Packet.SessionToken = Arguments[0];

            return Packet;
        }

        public override string Serialize()
        {
            return $"{PacketId}%{SessionToken}";
        }
    }
}
