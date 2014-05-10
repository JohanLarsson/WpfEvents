using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfEvents
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Data;

    /// <summary>
    /// Interaction logic for TextBoxEvents.xaml
    /// </summary>
    public partial class TextBoxEvents : UserControl
    {
        private readonly EventsVm _vm = new EventsVm(typeof(TextBox));

        private static readonly Type _disconnectedItemType = typeof(System.Windows.Data.BindingExpressionBase)
            .GetField("DisconnectedItem", BindingFlags.Static | BindingFlags.NonPublic)
            .GetValue(null).GetType();
        public TextBoxEvents()
        {
            InitializeComponent();
            DataContext = _vm;
        }
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            _vm.Clear();
        }
        private void ChangePropValue(object sender, RoutedEventArgs e)
        {
            _vm.Value += "1";
        }
        private void OnEvent(object sender, RoutedEventArgs e)
        {
            _vm.Add(e);
        }
        private void OnEvent(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.GetType() == _disconnectedItemType)
            {
                return;
            }
            if (e.NewValue.GetType() == _disconnectedItemType)
            {
                return;
            }
            _vm.Add(e);
        }
        private void OnInitializedEvent(object sender, EventArgs e)
        {
            _vm.Add(Filter.Initialized);
        }
        private void OnLayoutUpdatedEvent(object sender, EventArgs e)
        {
            _vm.Add(Filter.LayoutUpdated);
        }
    }
}
