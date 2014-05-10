using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvents
{
    using System.Linq.Expressions;

    public static class NameOf
    {
        public static string Event<T>(Action<T> @event)
        {
            string name = @event.Method.Name;
            throw new NotImplementedException("message");
        }
    }
}
