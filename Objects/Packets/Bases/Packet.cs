using CoolChatRoom.Objects.Constants.Enums;

namespace CoolChatRoom.Objects.Packets.Bases
{
    public interface Packet
    {
        public static PacketType Type { get; }
        public string Serialize();
    }
}
