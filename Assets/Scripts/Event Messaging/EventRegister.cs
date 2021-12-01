namespace GameLokal.Toolkit
{
    public static class EventRegister
    {
        public delegate void Delegate<T>(T eventType);

        public static void EventStartListening<T>(this IEventListener<T> caller) where T : struct
        {
            EventManager.AddListener<T>(caller);
        }

        public static void EventStopListening<T>(this IEventListener<T> caller) where T : struct
        {
            EventManager.RemoveListener<T>(caller);
        }
    }
}