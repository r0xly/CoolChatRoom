using CoolChatRoom.Objects.Entities;

namespace CoolChatRoom.Objects.Packets.Bases
{
    public interface UserPacket : IPacket
    {
        public UserEntity Source { get; }
    }
}
