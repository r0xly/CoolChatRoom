using CoolChatRoom.Objects.Entities;

namespace CoolChatRoom.Objects.Packets.Bases
{
    public interface UserPacket : Packet
    {
        public UserEntity Source { get; }
    }
}
