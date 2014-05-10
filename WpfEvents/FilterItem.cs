namespace WpfEvents
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class FilterItem : INotifyPropertyChanged
    {
        private bool _keep;

        public FilterItem(object key, bool keep)
        {
            _keep = keep;
            Key = key;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Key { get; private set; }

        public bool Keep
        {
            get { return _keep; }
            set
            {
                if (value.Equals(_keep))
                {
                    return;
                }
                _keep = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return string.Format("Key: {0}, Keep: {1}", Key, Keep);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}