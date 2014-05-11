namespace WpfEvents
{
    using System;

    public class EventEntry : IEventEntry
    {
        public EventEntry(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public object Value
        {
            get
            {
                return EventArgs.Empty;
            }
        }
    }
}