namespace GameLokal.Toolkit
{
    public struct GameEvent
    {
        public string EventName;

        public GameEvent(string newName)
        {
            EventName = newName;
        }

        private static GameEvent _event;

        public static void Trigger(string newName)
        {
            _event.EventName = newName;
            EventManager.TriggerEvent(_event);
        }
    }
}