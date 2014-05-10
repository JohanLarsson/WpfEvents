namespace WpfEvents
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    public class EventArgsTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _emptyTemplate = new DataTemplate();

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            container = container as DependencyObject; // Attempt to solve the {DisconnectedItem} issue http://connect.microsoft.com/VisualStudio/feedback/details/619658/wpf-virtualized-control-disconnecteditem-reference-when-datacontext-switch
            if (container == null)
            {
                return _emptyTemplate;
            }
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
