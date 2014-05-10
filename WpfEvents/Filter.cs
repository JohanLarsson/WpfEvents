namespace WpfEvents
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Filter
    {
        public const string Initialized = "Initialized";
        public const string LayoutUpdated = "LayoutUpdated";
        public Filter(EventsVm vm)
        {
            VM = vm;
            EventInfo[] eventInfos = vm.Type.GetEvents()
                                       .OrderBy(x => x.Name)
                                       .ToArray();
        }
        public EventsVm VM { get; private set; }

        public Type Type { get; private set; }
    }
}