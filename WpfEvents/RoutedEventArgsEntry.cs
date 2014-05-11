namespace WpfEvents
{
    using System.Windows;

    public class RoutedEventArgsEntry : IEventEntry
    {
        public RoutedEventArgsEntry(RoutedEventArgs args)
        {
            Value = args;
            Name = string.Format("{0}.{1}", args.Source.GetType().Name, args.RoutedEvent.Name);
        }
        public string Name { get; private set; }
        public object Value { get; private set; }
    }
}