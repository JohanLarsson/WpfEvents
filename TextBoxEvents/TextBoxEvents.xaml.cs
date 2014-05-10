using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEvents
{
    using System.Reflection;

    /// <summary>
    /// Interaction logic for TextBoxEvents.xaml
    /// </summary>
    public partial class TextBoxEvents : UserControl
    {
        private readonly EventsVm _vm = new EventsVm();
        public TextBoxEvents()
        {
            InitializeComponent();
            foreach (var eventInfo in TextBox.GetType().GetEvents(BindingFlags.FlattenHierarchy))
            {
                eventInfo.AddEventHandler(this, new Action<object, object>((o, e) => _vm.Add(e)));
            }

        }
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            _vm.Clear();
        }
        private void ChangePropValue(object sender, RoutedEventArgs e)
        {
            _vm.Value += "1";
        }
        private void TextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_Initialized(object sender, System.EventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //_vm.Add(e);
        }

        private void TextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            _vm.Add(e);
        }

        private void TextBox_Unloaded(object sender, RoutedEventArgs e)
        {
            _vm.Add(e);
        }
    }
}
