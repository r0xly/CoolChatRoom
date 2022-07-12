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

            PacketReceived += (Sender, RecievedPacket) =>
            {
                if (RecievedPacket is T Packet) PacketListener.Fire(Packet);
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
