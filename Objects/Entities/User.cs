namespace CoolChatRoom.Objects.Entities
{
    internal class User
    {
        private TcpClient Client;

        internal User(TcpClient Client)
        {
            this.Client = Client;
        }

        public void Disconnect()
        {
            Client.Close();
        }
    }
}
