namespace WpfEvents
{
    using System;

    public class EventEntry : IEventEntry<EventArgs>
    {
        public EventEntry(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public EventArgs Args
        {
            get
            {
                return EventArgs.Empty;
            }
        }
    }
}