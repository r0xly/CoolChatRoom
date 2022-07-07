using CoolChatRoom.Objects.Configs;
using CoolChatRoom.Objects.Sockets.Base;

namespace CoolChatRoom.Objects.Sockets.Implementations
{
    public class CoolSocketServer : CoolSocket
    {
        public bool Active => TcpListener.Server.IsBound;

        private CoolSocketServerParams Parameters;
        private TcpListener TcpListener;
        private ConnectionListener ConnectionListener;
        private IPAddress IP = IPAddress.Parse("127.0.0.1");

        public CoolSocketServer(CoolSocketServerParams Parameters)
        {
            this.Parameters = Parameters;
            TcpListener = new(IP, Parameters.Port);
            ConnectionListener = new(this);
        }

        public void Start()
        {
            try
            {
                TcpListener.Start();
                ConnectionListener.Start();
                Console.WriteLine(Strings.ServerStarted);
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
        }

        public async Task<TcpClient> AcceptTcpClientAsync()
        {
            return await TcpListener.AcceptTcpClientAsync();
        }
    }
}
