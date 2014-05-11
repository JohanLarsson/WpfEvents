namespace WpfEvents
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Annotations;
    using Properties;

    public class Vm : INotifyPropertyChanged
    {
        private readonly Type[] _types;
        private Type _type;
        private string _xaml;
        private readonly ObservableCollection<DataTemplateXaml> _dataTemplates = new ObservableCollection<DataTemplateXaml>();
        public Vm()
        {
            _types = typeof(FrameworkElement).Assembly.GetTypes()
                                         .Where(x => x.IsSubclassOf(typeof(FrameworkElement)))
                                         .OrderBy(x => x.Name)
                                         .ToArray();
            _type = typeof(TextBox);
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
                if (value == _type)
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
        public ObservableCollection<DataTemplateXaml> DataTemplates
        {
            get
            {
                return _dataTemplates;
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
            DataTemplates.Clear();
            //var resourceManager = Resources.ResourceManager;
            //var resourceDictionary = new ResourceDictionary()
            //{
            //    Source = new Uri("App.xaml", UriKind.Relative)
            //};
            //var keys = new HashSet<object>(resourceDictionary.Keys.Cast<object>());
            //var key = new System.Windows.DataTemplateKey(typeof(TextBlock));

            //var lackingTemplate = eventInfos.Where(x => !keys.Contains(new DataTemplateKey(x.GetArgsType())))
            //                                .ToArray();
            var xamls = eventInfos.Select(x => new DataTemplateXaml(x))
                                  .ToArray();
            var set = new HashSet<DataTemplateXaml>(xamls);

            foreach (var t in set.OrderBy(x => x.Name))
            {
                DataTemplates.Add(t);
            }
            string s = xamlBuilder.ToString();
            return s;
        }
    }
}
