using CoolChatRoom.Objects.Configs;
using CoolChatRoom.Objects.Entities;
using CoolChatRoom.Objects.Sockets.Base;
using CoolChatRoom.Objects.Packets.Bases;

namespace CoolChatRoom.Objects.Sockets.Implementations
{
    public class CoolSocketServer : CoolSocket
    {
        public bool Active => TcpListener.Server.IsBound;
        public event EventHandler<UserEntity> UserAdded;

        private CoolSocketServerParams Parameters;
        private TcpListener TcpListener;
        private ConnectionHandler ConnectionListener;
        private IPAddress IP = IPAddress.Parse("127.0.0.1");
        private List<UserEntity> UserList = new();

        public CoolSocketServer(CoolSocketServerParams Parameters)
        {
            this.Parameters = Parameters;
            DisplayLogs = Parameters.DisplayLogs;
            TcpListener = new(IP, Parameters.Port);
            ConnectionListener = new(this);
        }

        public void Start()
        {
            try
            {
                TcpListener.Start();
                ConnectionListener.Start();
                Log(Strings.ServerStarted);
            }
            catch (SocketException e)
            {
                Log($"SocketException: {e}", LogLevel.Error);
            }
        }

        internal async Task<TcpClient> AcceptTcpClientAsync()
        {
            return await TcpListener.AcceptTcpClientAsync();
        }

        internal void AddUser(UserEntity User)
        {
            UserList.Add(User);
            OnUserAdded(User);
        }

        protected virtual void OnUserAdded(UserEntity User)
        {
            var Handler = UserAdded;

            if (Handler != null)
                Handler(this, User);

            Log($"User added: {User.Name}");
        }

        public async Task BrodcastAsync(IPacket Packet, UserEntity[]? Filter)
        { 
        
            foreach (var User in UserList)
            {
                if (Filter == null || !Filter.Contains(User)) await User.SendPacketAsync(Packet);
            }
        }

    }
}
