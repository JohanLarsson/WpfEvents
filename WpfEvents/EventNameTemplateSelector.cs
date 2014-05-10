namespace WpfEvents
{
    using System.Windows;
    using System.Windows.Controls;

    public class EventNameTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RoutedEventArgsNameTemplate { get; set; }
        public DataTemplate EventArgsNameTemplate { get; set; }
        public DataTemplate T3 { get; set; }
        public DataTemplate T4 { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is RoutedEventArgs)
            {
                return RoutedEventArgsNameTemplate;
            }
            if (item is EventEntry)
            {
                return EventArgsNameTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}