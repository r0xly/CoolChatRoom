using CoolChatRoom.Objects.Packets.Bases;
using System.Text;

namespace CoolChatRoom.Objects.Entities
{
    public class UserEntity
    {
        public string? Name;
        public int LastPing;
        public event EventHandler<Packet> PacketRecieved;

        private TcpClient Client;
        private Receiver Reciver;

        internal UserEntity(TcpClient Client)
        {
            this.Client = Client;
            Reciver = new();
            Reciver.Start(Client.GetStream());
            Reciver.PacketReceived += (s, e) =>
            {
                PacketRecieved(s, e);
            };
        }

        public void Disconnect()
        {
            Client.Close();
        }

        public async Task SendPacketAsync(Packet Packet)
        {
            byte[] Bytes = Encoding.ASCII.GetBytes(Packet.Serialize());
            NetworkStream Stream = Client.GetStream();
            await Stream.WriteAsync(Bytes, 0, Bytes.Length);
        }
    }
}
