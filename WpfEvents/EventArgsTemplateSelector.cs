namespace WpfEvents
{
    using System.Windows;
    using System.Windows.Controls;

    public class EventArgsTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _emptyTemplate = new DataTemplate();

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return _emptyTemplate;
            }
            if (item is EventEntry)
            {
                return _emptyTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
