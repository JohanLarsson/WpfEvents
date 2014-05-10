namespace WpfEvents
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using Annotations;
    public class Vm : INotifyPropertyChanged
    {
        private readonly Type[] _types;
        private Type _type;
        private string _xaml;
        public Vm()
        {
            _types = typeof(FrameworkElement).Assembly.GetTypes()
                                         .Where(x => x.IsSubclassOf(typeof(FrameworkElement)))
                                         .OrderBy(x=>x.Name)
                                         .ToArray();
            _type = typeof (TextBox);
            _xaml = GeneratedCode(_type);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<Type> Types
        {
            get
            {
                return _types;
            }
        }
        
        public Type Type
        {
            get { return _type; }
            set
            {
                if (Equals(value, _type))
                {
                    return;
                }
                _type = value;
                Xaml = GeneratedCode(_type);
                OnPropertyChanged();
            }
        }
        
        public string Xaml
        {
            get { return _xaml; }
            set
            {
                if (value == _xaml)
                {
                    return;
                }
                _xaml = value;
                OnPropertyChanged();
            }
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

        private string GeneratedCode(Type type)
        {
            EventInfo[] eventInfos = type.GetEvents()
                                         .OrderBy(x => x.Name)
                                         .ToArray();
            var xamlBuilder = new StringBuilder();
            var codeBuilder = new StringBuilder();
            foreach (var eventInfo in eventInfos)
            {
                if (eventInfo.EventHandlerType == typeof(EventHandler))
                {
                    xamlBuilder.AppendLine(string.Format(@"{0} = ""On{0}Event""", eventInfo.Name));
                }
                else
                {
                    xamlBuilder.AppendLine(eventInfo.Name + @"=""OnEvent""");
                }

            }
            string s = xamlBuilder.ToString();
            return s;
        }
    }
}
