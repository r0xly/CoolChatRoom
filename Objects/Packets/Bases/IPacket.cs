using CoolChatRoom.Objects.Constants.Enums;

namespace CoolChatRoom.Objects.Packets.Bases
{
    public interface IPacket
    {
        public static PacketType Type { get; }
        public string Serialize();
    }
}
