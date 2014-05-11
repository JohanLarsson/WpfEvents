namespace WpfEvents
{
    using System.Windows;

    public class DependencyPropertyChangedEventArgsEntry : IEventEntry<DependencyPropertyChangedEventArgs>, IEventEntry<object>
    {
        public DependencyPropertyChangedEventArgsEntry(DependencyPropertyChangedEventArgs args)
        {
            OldValue = args.OldValue;
            NewValue = args.NewValue;
            Args = args;
            Name = string.Format("{0}.{1}", args.Property.OwnerType.Name, args.Property.Name);
        }
        public string Name { get; private set; }
        object IEventEntry<object>.Args
        {
            get
            {
                return Args;
            }
        }
        public DependencyPropertyChangedEventArgs Args { get; private set; }
        public object OldValue { get; private set; }
        public object NewValue { get; private set; }
        public DependencyProperty Property
        {
            get
            {
                return Args.Property;
            }
        }
    }
}