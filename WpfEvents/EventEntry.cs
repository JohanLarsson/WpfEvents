namespace WpfEvents
{
    using System;
    using System.Windows;

    public class EventEntry : IEquatable<EventEntry>
    {
        public EventEntry(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

        public bool Equals(EventEntry other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
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
            return Equals((EventEntry) obj);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public static bool operator ==(EventEntry left, EventEntry right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(EventEntry left, EventEntry right)
        {
            return !Equals(left, right);
        }
    }
}