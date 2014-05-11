namespace WpfEvents
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    using Annotations;

    public class Filter : INotifyPropertyChanged
    {
        public const string Initialized = "Initialized";
        public const string LayoutUpdated = "LayoutUpdated";
        public const string Stylus = "Stylus";
        public const string Mouse = "Mouse";
        public const string Keyboard = "Keyboard";
        private readonly string[] _inputs = { Stylus, Mouse, Keyboard };
        private readonly ObservableCollection<FilterItem> _items = new ObservableCollection<FilterItem>();

        private readonly List<FilterItem> _mouseItems = new List<FilterItem>
        {
            new FilterItem(Mouse.PreviewMouseMoveEvent, false),
            new FilterItem(Mouse.MouseMoveEvent, false),
            new FilterItem(Mouse.PreviewMouseDownOutsideCapturedElementEvent, false),
            new FilterItem(Mouse.PreviewMouseUpOutsideCapturedElementEvent, false),
            new FilterItem(Mouse.PreviewMouseDownEvent, false),
            new FilterItem(Mouse.MouseDownEvent, false),
            new FilterItem(Mouse.PreviewMouseUpEvent, false),
            new FilterItem(Mouse.MouseUpEvent, false),
            new FilterItem(Mouse.PreviewMouseWheelEvent, false),
            new FilterItem(Mouse.MouseWheelEvent, false),
            new FilterItem(Mouse.MouseEnterEvent, false),
            new FilterItem(Mouse.MouseLeaveEvent, false),
            new FilterItem(Mouse.GotMouseCaptureEvent, false),
            new FilterItem(Mouse.LostMouseCaptureEvent, false),
            new FilterItem(Mouse.QueryCursorEvent, false),
            new FilterItem(Mouse.MouseWheelDeltaForOneLine, false),
        };

        private readonly List<FilterItem> _keyBoradItems = new List<FilterItem>
        {
            new FilterItem(Keyboard.PreviewKeyDownEvent, false),
            new FilterItem(Keyboard.KeyDownEvent, false),
            new FilterItem(Keyboard.PreviewKeyUpEvent, false),
            new FilterItem(Keyboard.KeyUpEvent, false),
            new FilterItem(Keyboard.PreviewGotKeyboardFocusEvent, false),
            new FilterItem(Keyboard.PreviewKeyboardInputProviderAcquireFocusEvent, false),
            new FilterItem(Keyboard.KeyboardInputProviderAcquireFocusEvent, false),
            new FilterItem(Keyboard.GotKeyboardFocusEvent, false),
            new FilterItem(Keyboard.PreviewLostKeyboardFocusEvent, false),
            new FilterItem(Keyboard.LostKeyboardFocusEvent, false),
        };

        private readonly List<FilterItem> _stylusItems = new List<FilterItem>
        {
            new FilterItem(Stylus.PreviewStylusDownEvent, false),
            new FilterItem(Stylus.StylusDownEvent, false),
            new FilterItem(Stylus.PreviewStylusUpEvent, false),
            new FilterItem(Stylus.StylusUpEvent, false),
            new FilterItem(Stylus.PreviewStylusMoveEvent, false),
            new FilterItem(Stylus.StylusMoveEvent, false),
            new FilterItem(Stylus.PreviewStylusInAirMoveEvent, false),
            new FilterItem(Stylus.StylusInAirMoveEvent, false),
            new FilterItem(Stylus.StylusEnterEvent, false),
            new FilterItem(Stylus.StylusLeaveEvent, false),
            new FilterItem(Stylus.PreviewStylusInRangeEvent, false),
            new FilterItem(Stylus.StylusInRangeEvent, false),
            new FilterItem(Stylus.PreviewStylusOutOfRangeEvent, false),
            new FilterItem(Stylus.StylusOutOfRangeEvent, false),
            new FilterItem(Stylus.PreviewStylusSystemGestureEvent, false),
            new FilterItem(Stylus.StylusSystemGestureEvent, false),
            new FilterItem(Stylus.GotStylusCaptureEvent, false),
            new FilterItem(Stylus.LostStylusCaptureEvent, false),
            new FilterItem(Stylus.StylusButtonDownEvent, false),
            new FilterItem(Stylus.StylusButtonUpEvent, false),
            new FilterItem(Stylus.PreviewStylusButtonDownEvent, false),
            new FilterItem(Stylus.PreviewStylusButtonUpEvent, false),
            new FilterItem(Stylus.IsPressAndHoldEnabledProperty, false),
            new FilterItem(Stylus.IsFlicksEnabledProperty, false),
            new FilterItem(Stylus.IsTapFeedbackEnabledProperty, false),
            new FilterItem(Stylus.IsTouchFeedbackEnabledProperty, false),
        };
        public Filter(EventsVm vm)
        {
            Vm = vm;
            _items = new ObservableCollection<FilterItem>
            {
                new FilterItem(LayoutUpdated, false),
                new FilterItem(Initialized, true),
                new FilterItem(UIElement.IsVisibleProperty, true),
                new FilterItem(UIElement.PreviewMouseLeftButtonDownEvent, false),
                new FilterItem(UIElement.MouseLeftButtonDownEvent, false),
                new FilterItem(FrameworkElement.SizeChangedEvent, false),
                new FilterItem(FrameworkElement.DataContextProperty, true),
                new FilterItem(FrameworkElement.LoadedEvent, true),
            };
            _items.AddRange(_mouseItems);
            _items.AddRange(_keyBoradItems);
            _items.AddRange(_stylusItems);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public EventsVm Vm { get; private set; }

        public ObservableCollection<FilterItem> Items
        {
            get
            {
                return _items;
            }
        }
        public bool KeepMouseEvents { get; set; }

        public Type Type { get; private set; }

        public bool IsKeeper(string eventName)
        {
            var item = _items.SingleOrDefault(x => Equals(x.Key, eventName));
            if (item == null)
            {
                return true;
            }
            return item.Keep;
        }

        public bool IsKeeper(DependencyPropertyChangedEventArgs args)
        {
            var item = _items.SingleOrDefault(x => Equals(x.Key, args.Property));
            if (item == null)
            {
                var filterItem = new FilterItem(args.Property, true);
                if (args.Property.Name.Contains(Mouse))
                {
                    _mouseItems.Add(filterItem);
                    Items.Add(filterItem);
                    filterItem.Keep = false;
                }
                else if (args.Property.Name.Contains(Keyboard))
                {
                    _keyBoradItems.Add(filterItem);
                    Items.Add(filterItem);
                    filterItem.Keep = false;
                }
                else if (args.Property.Name.Contains(Stylus))
                {
                    _stylusItems.Add(filterItem);
                    Items.Add(filterItem);
                    filterItem.Keep = false;
                }
                else
                {
                    return true;
                }
            }
            return item.Keep;
        }

        public bool IsKeeper(RoutedEventArgs args)
        {
            var item = _items.SingleOrDefault(x => Equals(x.Key, args.RoutedEvent));
            if (item == null)
            {
                return true;
            }
            return item.Keep;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}