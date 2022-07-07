using System.Text;
using CoolChatRoom.Objects.Factories;
using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Structures
{
    internal class Receiver
    {
        public event EventHandler<Packet> PacketReceived;

        internal void Start(NetworkStream Stream)
        {
            new Thread(() => { Recieve(Stream); }).Start();
        }

        internal void Recieve(NetworkStream Stream)
        {
            Byte[] Bytes = new Byte[256];
            string Data;
            int i;

            while ((i = Stream.Read(Bytes, 0, Bytes.Length)) != 0)
            {
                Data = Encoding.ASCII.GetString(Bytes, 0, i);
                var Packet = PacketFactory.CreatePacket(Data);
                OnPacketRecieved(Packet);
            }
        }

        protected virtual void OnPacketRecieved(Packet Packet)
        {
            PacketReceived(null, Packet);
        }
    }
}
