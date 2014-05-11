namespace WpfEvents
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public abstract class EventsUserControl : UserControl
    {
        protected readonly EventsVm _vm;

        public EventsUserControl(Type type)
        {
            _vm =  new EventsVm(type);
        }
        protected void ClearClick(object sender, RoutedEventArgs e)
        {
            _vm.Clear();
        }

        protected abstract void ChangePropValue(object sender, RoutedEventArgs e);

        protected void OnEvent(object sender, RoutedEventArgs e)
        {
            _vm.Add(e);
        }
        protected void OnEvent(object sender, DependencyPropertyChangedEventArgs e)
        {
            _vm.Add(e);
        }
        protected void OnInitializedEvent(object sender, EventArgs e)
        {
            _vm.Add(Filter.Initialized);
        }
        protected void OnLayoutUpdatedEvent(object sender, EventArgs e)
        {
            _vm.Add(Filter.LayoutUpdated);
        }
    }
}