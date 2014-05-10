namespace WpfEvents
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Annotations;

    public class EventsVm : INotifyPropertyChanged
    {
        private readonly ObservableCollection<EventEntry> _events = new ObservableCollection<EventEntry>();
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

        public ObservableCollection<EventEntry> Events
        {
            get
            {
                return _events;
            }
        }

        public void Add(object args, [CallerMemberName] string caller = null)
        {
            Events.Insert(0, new EventEntry(caller, args));
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

        public void Clear()
        {
            _events.Clear();
        }
    }
}
