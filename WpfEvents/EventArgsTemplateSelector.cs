namespace WpfEvents
{
    using System.Windows;
    using System.Windows.Controls;

    public class EventArgsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextChangedEventArgsTemplate { get; set; }
        public DataTemplate T2 { get; set; }
        public DataTemplate T3 { get; set; }
        public DataTemplate T4 { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TextChangedEventArgs)
            {
                return TextChangedEventArgsTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
