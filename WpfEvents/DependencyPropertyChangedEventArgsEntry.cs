namespace WpfEvents
{
    using System.Windows;

    public class DependencyPropertyChangedEventArgsEntry : IEventEntry
    {
        public DependencyPropertyChangedEventArgsEntry(DependencyPropertyChangedEventArgs args)
        {
            OldValue = args.OldValue;
            NewValue = args.NewValue;
            Value = args;
            Name = string.Format("{0}.{1}", args.Property.OwnerType.Name, args.Property.Name);
        }
        public string Name { get; private set; }
        public object Value { get; private set; }
        public object OldValue { get; private set; }
        public object NewValue { get; private set; }
        public DependencyProperty Property
        {
            get
            {
                return ((DependencyPropertyChangedEventArgs)Value).Property;
            }
        }
    }
}