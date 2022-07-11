using CoolChatRoom.Objects.Packets.Bases;
using CoolChatRoom.Objects.Util;

namespace CoolChatRoom.Objects.Sockets.Base
{
    public abstract class CoolSocket
    {
        public event EventHandler<IPacket> PacketReceived;
        public bool DisplayLogs;

        protected virtual void OnPacketRecieved(IPacket Packet)
        {
            EventHandler<IPacket> Handler = PacketReceived;
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

        public void Log(string Message, LogLevel Level = LogLevel.Info)
        {
            if (!DisplayLogs) return;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now.ToString()}] [{Level.ToString().ToLower()}] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Message);
        }
    }
}
