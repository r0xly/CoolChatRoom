using System.Reflection;

namespace CoolChatRoom.Objects.Packets.Bases
{
    public abstract class Packet
    {
        public static string PacketId { get; }
        public abstract string Serialize();

        public static List<Packet> GetItems()
        {
            List<Packet> Packets = new();

            foreach (Type Ty in Assembly.GetCallingAssembly().GetTypes().Where(Ty => Ty.GetProperty("Type") != null && Ty.GetMethod("Construct") != null))
            {
                Packets.Add((Packet)(object)Ty);
            }

            return Packets;
        }
    }
}
