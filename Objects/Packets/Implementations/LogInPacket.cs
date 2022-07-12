using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Packets.Implementations
{
    public class LogInPacket : Packet 
    {
        public static new string PacketId => "LogIn";
        public string Name { get; set; } = "";

        public static LogInPacket Construct(string[] Arguments)
        {
            LogInPacket Packet = new();
            Packet.Name = Arguments[0];

            return Packet;
        }

        public override string Serialize()
        {
            return $"{PacketId}%{Name}";
        }
    }
}
