namespace WpfEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Annotations;

    public class Filter : INotifyPropertyChanged
    {
        public const string Initialized = "Initialized";
        public const string LayoutUpdated = "LayoutUpdated";
        private readonly List<FilterItem> _items = new List<FilterItem>(); 

        public Filter(EventsVm vm)
        {
            Vm = vm;
            _items.Add(new FilterItem(LayoutUpdated, false));
            _items.Add(new FilterItem(Initialized, true));
            _items.Add(new FilterItem(UIElement.IsVisibleProperty, true));
            _items.Add(new FilterItem(FrameworkElement.SizeChangedEvent, false));
            _items.Add(new FilterItem(FrameworkElement.DataContextProperty, true));
            _items.Add(new FilterItem(FrameworkElement.LoadedEvent, true));

        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public EventsVm Vm { get; private set; }

        public IEnumerable<FilterItem> Items
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
            var item = _items.SingleOrDefault(x=> Equals(x.Key, eventName));
            if (item == null)
            {
                return false;
            }
            return item.Keep;
        }

        public bool IsKeeper(DependencyPropertyChangedEventArgs args)
        {
            var item = _items.SingleOrDefault(x => Equals(x.Key, args.Property));
            if (item == null)
            {
                return false;
            }
            return item.Keep;
        }

        public bool IsKeeper(RoutedEventArgs args)
        {
            var item = _items.SingleOrDefault(x => Equals(x.Key, args.RoutedEvent));
            if (item == null)
            {
                return false;
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