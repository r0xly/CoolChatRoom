using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Packets.Implementations
{
    public class ConnectionPacket : Packet 
    {
        public static PacketType Type => PacketType.Connect;
        public string Username { get; set; } = "";

        public static ConnectionPacket Construct(string[] Arguments)
        {
            ConnectionPacket Packet = new();
            Packet.Username = Arguments[0];

            return Packet;
        }

        public string Serialize()
        {
            return $"{Type}%{Username}";
        }
    }
}
