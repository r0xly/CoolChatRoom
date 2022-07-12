using CoolChatRoom.Objects.Sockets.Implementations;
using CoolChatRoom.Objects.Entities;
using CoolChatRoom.Objects.Packets.Bases;
using CoolChatRoom.Objects.Packets.Implementations;

namespace CoolChatRoom.Objects.Structures
{
    internal class ConnectionHandler
    {
        private CoolSocketServer Server;

        internal ConnectionHandler(CoolSocketServer Server)
        {
            this.Server = Server;
        }

        public void Start()
        {
            new Thread(() => Listen().GetAwaiter().GetResult()).Start(); // ugly ugly ugly
        }

        private async Task Listen()
        {
            while (Server.Active)
            {
                TcpClient Client = await Server.AcceptTcpClientAsync();
                new Thread(() => HandleLogIn(Client)).Start();
            }
        }

        private void HandleLogIn(TcpClient Client)
        {
            UserEntity User = new(Client);

            void HandlePacketRecieved(object? Source, Packet Packet)
            {
                if (Packet is LogInPacket LogInPacket)
                {
                    User.Name = LogInPacket.Name; 
                    User.PacketRecieved -= HandlePacketRecieved;
                }
            }

            User.PacketRecieved += HandlePacketRecieved;

            var StartTime = DateTime.UtcNow;
            while (DateTime.UtcNow - StartTime < TimeSpan.FromSeconds(1) && User.Name == null) { }

            if (User.Name == null)
            {
                User.PacketRecieved -= HandlePacketRecieved;
                Client.Close();
            }
            else
            {
                Server.AddUser(User);                    
            }
        }
    }
}
