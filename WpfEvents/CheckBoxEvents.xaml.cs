namespace WpfEvents
{
    using System.Windows;
    using System.Windows.Controls;
    /// <summary>
    /// Interaction logic for CheckBoxEvents.xaml
    /// </summary>
    public partial class CheckBoxEvents : EventsUserControl
    {
        public CheckBoxEvents()
            : base(typeof(TextBox))
        {
            InitializeComponent();
            DataContext = _vm;
        }
        protected override void ChangePropValue(object sender, RoutedEventArgs e)
        {
            _vm.Value = !(bool)_vm.Value;
        }
    }
}
