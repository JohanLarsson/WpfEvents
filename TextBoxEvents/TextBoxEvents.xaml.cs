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
            _vm.Add("LayoutUpdated");
        }
        //private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_Initialized(object sender, System.EventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    //_vm.Add(e);
        //}

        //private void TextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_TargetUpdated(object sender, DataTransferEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        //{
        //    _vm.Add(e);
        //}

        //private void TextBox_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    _vm.Add(e);
        //}
    }
}
