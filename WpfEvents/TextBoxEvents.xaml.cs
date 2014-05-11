﻿namespace WpfEvents
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TextBoxEvents.xaml
    /// </summary>
    public partial class TextBoxEvents : EventsUserControl
    {
        public TextBoxEvents()
            : base(typeof(TextBox))
        {
            InitializeComponent();
            DataContext = _vm;
        }
        protected override void ChangePropValue(object sender, RoutedEventArgs e)
        {
            _vm.Value += "1";
        }
    }
}
