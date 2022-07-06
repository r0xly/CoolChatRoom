namespace CoolChatRoom.Objects.Structures
{
    internal class Receiver
    {
        internal void Start(NetworkStream Stream)
        {
            new Thread(() => { Recieve(Stream); }).Start();
        }

        public void Recieve(NetworkStream Stream)
        {
            Byte[] Bytes = new Byte[256];
            string? Data;

            while(true)
            {
                int i;
                Data = null;

                while((i = Stream.Read(Bytes, 0, Bytes.Length)) != 0)
                {
                    Data = System.Text.Encoding.ASCII.GetString(Bytes, 0, i);
                    Data = Data.ToUpper();
                }

                if (Data != null) Console.WriteLine(Data); 
            }
        }
    }
}
