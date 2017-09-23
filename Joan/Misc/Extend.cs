using System;
using System.Collections.Generic;

namespace Joan.Misc
{
    public static class Extend
    {
        public static void ForEach<T>(this IEnumerable<T> Enum,Action<T> action)
        {
            foreach (var i in Enum)
            {
                action(i);
            }
        }
    }
}
