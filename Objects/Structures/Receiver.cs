using System.Text;
using CoolChatRoom.Objects.Factories;
using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Structures
{
    public class Receiver
    {
        public event EventHandler<IPacket> PacketReceived;

        internal void Start(NetworkStream Stream)
        {
            new Thread(() => { Recieve(Stream); }).Start();
        }

        internal void Recieve(NetworkStream Stream)
        {
            Byte[] Bytes = new Byte[256];
            string Data;
            int i;

            try
            {
                while (Stream.CanRead && (i = Stream.Read(Bytes, 0, Bytes.Length)) != 0)
                {
                    Data = Encoding.ASCII.GetString(Bytes, 0, i);
                    var Packet = PacketFactory.CreatePacket(Data);
                    OnPacketRecieved(Packet);
                }
            }
            catch { }
        }

        protected virtual void OnPacketRecieved(IPacket Packet)
        {

            EventHandler<IPacket> Handler = PacketReceived;
            if (Handler != null)
                Handler(this, Packet);
        }
    }
}
