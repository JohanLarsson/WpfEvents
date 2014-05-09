namespace TextBoxEvents
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Annotations;

    public class Vm : INotifyPropertyChanged
    {
        private readonly ObservableCollection<EventEntry> _events = new ObservableCollection<EventEntry>();

        public Vm()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Value { get; private set; }

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
