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
        private readonly EventsVm _vm = new EventsVm();
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
            _vm.Add(e);
        }
        private void OnInitializedEvent(object sender, EventArgs e)
        {
            _vm.Add("Initialized");
        }
        private void OnLayoutUpdatedEvent(object sender, EventArgs e)
        {
            //_vm.Add("LayoutUpdated");
        }
    }
}
