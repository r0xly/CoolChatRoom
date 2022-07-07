using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Packets.Implementations
{
    public class ServerMessagePacket : Packet 
    {
        public static PacketType Type => PacketType.ServerMessage;
        public string Content { get; set; } = "";

        public static ServerMessagePacket Construct(string[] Arguments)
        {
            ServerMessagePacket Packet = new();
            Packet.Content = Arguments[0];

            return Packet;
        }

        public string Serialize()
        {
            return $"{Type}%{Content}";
        }
    }
}
