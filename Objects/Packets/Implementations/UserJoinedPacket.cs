using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Packets.Implementations
{
    public class UserJoinedPacket : Packet 
    {
        public static PacketType Type => PacketType.UserJoinedPacket;
        public string Name { get; set; } = "";

        public static UserJoinedPacket Construct(string[] Arguments)
        {
            UserJoinedPacket Packet = new();
            Packet.Name = Arguments[0];

            return Packet;
        }

        public string Serialize()
        {
            return $"{Type}%{Name}";
        }
    }
}
