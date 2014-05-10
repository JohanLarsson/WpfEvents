namespace WpfEvents
{
    using System.Windows;
    using System.Windows.Controls;

    public class EventNameTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _emptyTemplate = new DataTemplate();
        public DataTemplate RoutedEventArgsNameTemplate { get; set; }
        public DataTemplate EventArgsNameTemplate { get; set; }
        public DataTemplate DependencyPropertyChangedEventArgsNameTemplate { get; set; }
        public DataTemplate T4 { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            container = container as DependencyObject; // Attempt to solve the {DisconnectedItem} issue http://connect.microsoft.com/VisualStudio/feedback/details/619658/wpf-virtualized-control-disconnecteditem-reference-when-datacontext-switch
            if (container == null || item == null)
            {
                return _emptyTemplate;
            }
            if (item is RoutedEventArgs)
            {
                return RoutedEventArgsNameTemplate;
            }
            if (item is DependencyPropertyChangedEventArgs)
            {
                return DependencyPropertyChangedEventArgsNameTemplate;
            }
            if (item is EventEntry)
            {
                return EventArgsNameTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}