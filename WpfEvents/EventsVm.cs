namespace WpfEvents
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Annotations;

    public class EventsVm : INotifyPropertyChanged
    {
        private readonly ObservableCollection<object> _events = new ObservableCollection<object>();
        private string _value;

        public EventsVm(Type type)
        {
            Type = type;
            Filter = new Filter(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Value
        {
            get { return _value; }
            set
            {
                if (value == _value)
                {
                    return;
                }
                _value = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<object> Events
        {
            get
            {
                return _events;
            }
        }

        public Filter Filter { get; private set; }

        public Type Type { get; private set; }

        public void Add(RoutedEventArgs args)
        {
            if (Filter.IsKeeper(args))
            {
                Events.Insert(0, args);
            }
        }

        public void Add(DependencyPropertyChangedEventArgs args)
        {
            if (Filter.IsKeeper(args))
            {
                Events.Insert(0, args);
            }
        }

        public void Add(string eventName)
        {
            if (Filter.IsKeeper(eventName))
            {
                Events.Insert(0, new EventEntry(eventName));
            }
        }

        public void Clear()
        {
            _events.Clear();
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
