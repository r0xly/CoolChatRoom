using System.Reflection;
using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Factories
{
    internal static class PacketFactory
    {
        public static Packet CreatePacket(string SerializedPacketString)
        {
            string[] Arguments = SerializedPacketString.Split(Strings.PacketArgumentSeperator);

            if (Arguments.Length > 1)
            {
                foreach (Type Ty in Assembly.GetCallingAssembly().GetTypes().Where(Ty => Ty.GetProperty("Type") != null && Ty.GetMethod("Construct") !=  null))
                {
                    if (Ty.GetProperty("Type").GetValue(null) is PacketType e && e.ToString() == Arguments[0])
                    {
                        return (Packet)Ty.GetMethod("Construct").Invoke(null, new object[] { Arguments.Skip(1).ToArray() });
                    }
                }
            }

            throw new ArgumentException("Invalid arguments.");
        }
    }
}
