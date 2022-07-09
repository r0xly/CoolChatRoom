using CoolChatRoom.Objects.Packets.Bases;
using CoolChatRoom.Objects.Util;

namespace CoolChatRoom.Objects.Sockets.Base
{
    public abstract class CoolSocket
    {
        public event EventHandler<Packet> PacketReceived;
        public bool DisplayLogs;

        protected virtual void OnPacketRecieved(Packet Packet)
        {
            EventHandler<Packet> Handler = PacketReceived;
            if (Handler != null)
                Handler(this, Packet);
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

        public void Log(string Message, object Source, LogLevel Level = LogLevel.Info)
        {
            if (DisplayLogs) Console.WriteLine($"{DateTime.Now.ToString()} | {Level.ToString().ToUpper()} | {Source.ToString().Split(".").Last()} | {Message}"); 
        }
    }
}
