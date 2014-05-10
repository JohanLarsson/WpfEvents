namespace WpfEvents
{
    using System;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

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
        public DataTemplateXaml(EventInfo eventInfo)
        {
            Type argsType = eventInfo.GetArgsType();
            Name = argsType.Name;
            var templateElement = new XElement("DataTemplate");
            templateElement.Add(new XAttribute("DataType", string.Format(@"{{x:Type {0}}}", Name)));
            var stackPanelElement = new XElement("StackPanel");
            stackPanelElement.Add(new XAttribute("Orientation", "Horizontal"));
            foreach (var prop in argsType.GetProperties())
            {
                var tbe = new XElement("TextBlock");
                tbe.Add(new XAttribute("Text",prop.Name + ": "));
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
            return Equals((DataTemplateXaml) obj);
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