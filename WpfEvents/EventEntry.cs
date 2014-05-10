namespace WpfEvents
{
    using System.Windows;

    public class EventEntry
    {
        public EventEntry(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}