using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Packets.Implementations
{
    public class ServerMessagePacket : Packet 
    {
        public static new string PacketId => "ServerMessage";
        public string Content { get; set; } = "";

        public static ServerMessagePacket Construct(string[] Arguments)
        {
            ServerMessagePacket Packet = new();
            Packet.Content = Arguments[0];

            return Packet;
        }

        public override string Serialize()
        {
            return $"{PacketId}%{Content}";
        }
    }
}
