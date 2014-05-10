namespace WpfEvents
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Annotations;

    public class EventsVm : INotifyPropertyChanged
    {
        private readonly ObservableCollection<object> _events = new ObservableCollection<object>();
        private string _value;

        public EventsVm()
        {

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

        public void Add(RoutedEventArgs args)
        {
            Events.Insert(0, args);
        }

        public void Add(DependencyPropertyChangedEventArgs args)
        {
            Events.Insert(0, args);
        }

        public void Add(string eventName)
        {
            Events.Insert(0, new EventEntry(eventName));
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
