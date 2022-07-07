using System.Text;
using CoolChatRoom.Objects.Parameters;
using CoolChatRoom.Objects.Packets.Bases;
using CoolChatRoom.Objects.Packets.Implementations;
using CoolChatRoom.Objects.Sockets.Base;

namespace CoolChatRoom.Objects.Sockets.Implementations
{
    public class CoolSocketClient : CoolSocket 
    {
        private CoolSocketClientParams Parameters;
        private Receiver Receiver;
        private TcpClient? TcpClient;

        public CoolSocketClient(CoolSocketClientParams Parameters)
        {
            this.Parameters = Parameters;
            Receiver = new();
            Receiver.PacketReceived += (s, e) => OnPacketRecieved(e); 
        }

        public void Connect(string Username)
        {
            try
            {
                TcpClient = new(Parameters.IP, Parameters.Port);
                Receiver.Start(TcpClient.GetStream());

                SendPacket(new ConnectionPacket()
                {
                    Username = Username,
                });

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

        public void SendPacket(Packet Packet)
        {
            byte[] Bytes = Encoding.ASCII.GetBytes(Packet.Serialize());
            NetworkStream Stream = TcpClient.GetStream();
            Stream.Write(Bytes, 0, Bytes.Length);
        }

    }
}
