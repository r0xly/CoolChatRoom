using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Packets.Implementations
{
    public class LogInPacket : Packet 
    {
        public static PacketType Type => PacketType.Connect;
        public string Name { get; set; } = "";

        public static LogInPacket Construct(string[] Arguments)
        {
            LogInPacket Packet = new();
            Packet.Name = Arguments[0];

            return Packet;
        }

        public string Serialize()
        {
            return $"{Type}%{Name}";
        }
    }
}
