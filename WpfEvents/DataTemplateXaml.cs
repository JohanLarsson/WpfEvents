namespace WpfEvents
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;
    //<TextBlock Text="{Binding Args.Handled}"/>
    //<TextBlock Text="{Binding Args.Source, StringFormat=' Source: {0}'}"/>
    //<TextBlock Text="{Binding Args.OriginalSource, StringFormat=' OriginalSource: {0}'}"/>
    //<DataTemplate DataType="{x:Type DependencyPropertyChangedEventArgs}">
    //    <StackPanel Orientation="Horizontal">
    //        <TextBlock Text="OldValue: "/>
    //        <ContentPresenter Content="{Binding OldValue, TargetNullValue='null'}"/>
    //        <TextBlock Text=" NewValue: "/>
    //        <ContentPresenter Content="{Binding NewValue, TargetNullValue='null'}"/>
    //    </StackPanel>
    //</DataTemplate>
    public class DataTemplateXaml
    {
        private static readonly HashSet<string> RoutedInfos = new HashSet<string>(typeof(RoutedEventArgs).GetProperties().Select(x => x.Name));
        public DataTemplateXaml(EventInfo eventInfo)
        {
            Type argsType = eventInfo.GetArgsType();
            Name = argsType.Name;
            var templateElement = new XElement("DataTemplate");
            templateElement.Add(new XAttribute("DataType", string.Format(@"{{x:Type {0}}}", Name)));
            var stackPanelElement = new XElement("StackPanel");
            stackPanelElement.Add(new XAttribute("Orientation", "Horizontal"));
            var propertyInfos = argsType.GetProperties()
                                        .Where(x => !RoutedInfos.Contains(x.Name))
                                        .ToArray();
            foreach (var prop in propertyInfos)
            {
                var tbe = new XElement("TextBlock");
                tbe.Add(new XAttribute("Text", prop.Name + ": "));
                stackPanelElement.Add(tbe);
                var cpe = new XElement("ContentPresenter");
                cpe.Add(new XAttribute("Content", string.Format(@"{{Binding {0}, TargetNullValue='null'}}", prop.Name)));
                stackPanelElement.Add(cpe);
            }
            templateElement.Add(stackPanelElement);
            Xaml = templateElement.ToString();
        }

        public string Name { get; private set; }

        public string Xaml { get; private set; }

        protected bool Equals(DataTemplateXaml other)
        {
            return string.Equals(Name, other.Name);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((DataTemplateXaml)obj);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }
    }
}