using CoolChatRoom.Objects.Packets.Implementations;
using CoolChatRoom.Objects.Entities;
using CoolChatRoom.Objects.Sockets.Implementations;

namespace CoolChatRoom.Objects.Structures
{
    internal class ConnectionListener
    {
        private CoolSocketServer Server;

        internal ConnectionListener(CoolSocketServer Server)
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
                UserEntity User = new(Client);
                Console.WriteLine($"New connection.");

                ServerMessagePacket Packet = new()
                {
                    Content = "Hello world!",
                };

                await User.SendPacketAsync(Packet);
            }
        }
    }
}
