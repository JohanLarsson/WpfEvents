namespace WpfEvents
{
    public interface IEventEntry
    {
        string Name { get; }
        object Value { get; }
    }
}