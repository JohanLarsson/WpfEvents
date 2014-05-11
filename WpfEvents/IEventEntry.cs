namespace WpfEvents
{
    public interface IEventEntry<out T>
    {
        string Name { get; }
        T Args { get; }
    }
}