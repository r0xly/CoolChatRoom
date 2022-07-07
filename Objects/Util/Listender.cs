namespace CoolChatRoom.Objects.Util
{
    public class Listener<T>
    {
        public event EventHandler<T> Fired;

        internal void Fire(T arg)
        {
            Fired(null, arg); 
        }
    }
}
