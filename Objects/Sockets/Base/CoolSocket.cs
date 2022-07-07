using CoolChatRoom.Objects.Packets.Bases;
using CoolChatRoom.Objects.Util;

namespace CoolChatRoom.Objects.Sockets.Base
{
    public abstract class CoolSocket
    {
        public event EventHandler<Packet> PacketReceived;

        protected virtual void OnPacketRecieved(Packet Packet)
        {
            PacketReceived(this, Packet);
        }
        public Listener<T> AddPacketListener<T>()
        {
            Listener<T> PacketListener = new();

            PacketReceived += (Sender, Packet) =>
            {
                if (Packet is T) PacketListener.Fire((T)Packet);
            };

            return PacketListener;            
        }
    }
}
