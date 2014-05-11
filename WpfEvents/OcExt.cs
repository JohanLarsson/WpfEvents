namespace WpfEvents
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class OcExt
    {
        public static void AddRange<T>(this ObservableCollection<T> col, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                col.Add(item);
            }
        }
    }
}