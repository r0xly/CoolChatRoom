using CoolChatRoom.Objects.Entities;

namespace CoolChatRoom.Objects.Packets.Bases
{
    public abstract class UserPacket : Packet
    {
        public abstract UserEntity Source { get; }
    }
}
