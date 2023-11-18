using SimpleEventBus.Events;

namespace Events
{
    public class DiceRollCompletedEvent : EventBase
    {
        public DiceRollCompletedEvent(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}