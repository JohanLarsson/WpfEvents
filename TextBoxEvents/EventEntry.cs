namespace TextBoxEvents
{
    using System.Windows;

    public class EventEntry
    {
        public EventEntry(string name, object args)
        {
            Name = name;
            Args = args;
        }    
        public string Name { get; private set; }
        public object Args { get; private set; }
    }
}