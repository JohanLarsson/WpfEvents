namespace WpfEvents
{
    using System.Windows;

    public class RoutedEventArgsEntry : IEventEntry<RoutedEventArgs>
    {
        public RoutedEventArgsEntry(RoutedEventArgs args)
        {
            Args = args;
            Name = string.Format("{0}.{1}", args.Source.GetType().Name, args.RoutedEvent.Name);
        }
        public string Name { get; private set; }
        public RoutedEventArgs Args { get; private set; }
    }
}