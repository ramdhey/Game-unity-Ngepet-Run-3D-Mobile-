namespace GameLokal.Toolkit
{
    public interface IEventListener<T> : IEventListenerBase
    {
        void OnEvent(T e);
    }
}