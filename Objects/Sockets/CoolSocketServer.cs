using CoolChatRoom.Objects.Configs;
using CoolChatRoom.Objects.Structures;
using CoolChatRoom.Objects.Constants;
using System.Text;

namespace CoolChatRoom.Objects.Sockets
{
    public class CoolSocketServer
    {
        public bool Active
        {
            get { return TcpListener.Server.IsBound; }
        }

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
            catch(SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
        }

        public async Task<TcpClient> AcceptTcpClientAsync()
        {
            return await TcpListener.AcceptTcpClientAsync();
        }

        public async Task WriteAsync(TcpClient Client, byte[] Message)
        {
            NetworkStream Stream = Client.GetStream();
            await Stream.WriteAsync(Message, 0, Message.Length);
        }
    }
}
