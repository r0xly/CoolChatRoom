using CoolChatRoom.Objects.Sockets;

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
                Console.WriteLine($"New client :o {Client.ToString}");

                byte[] Message = { 77, 77 }; 
                await Server.WriteAsync(Client, Message);
            }
        }
    }
}
