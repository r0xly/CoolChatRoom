using CoolChatRoom.Objects.Parameters;
using CoolChatRoom.Objects.Structures;

using CoolChatRoom.Objects.Constants;

namespace CoolChatRoom.Objects.Sockets
{
    public class CoolSocketClient
    {
        private CoolSocketClientParams Parameters;
        private TcpClient? TcpClient;
        private Receiver Receiver;

        public CoolSocketClient(CoolSocketClientParams Parameters)
        {
            this.Parameters = Parameters;
            Receiver = new();
        }

        public void Connect()
        {
            try
            {
                TcpClient = new(Parameters.IP, Parameters.Port);
                Receiver.Start(TcpClient.GetStream());
                Console.WriteLine(Strings.ClientStarted);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

    }
}
