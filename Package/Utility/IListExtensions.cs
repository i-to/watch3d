using System.Collections.Generic;
using System.Linq;

namespace Watch3D.Package.Utility
{
    static class IListExtensions
    {
        public static void RemoveAtEach<T>(this IList<T> list, IEnumerable<int> indices)
        {
            var ordered = indices.Distinct().OrderBy(Combinator.Identity);
            int removed = 0;
            foreach (int i in ordered)
            {
                list.RemoveAt(i - removed);
                ++removed;
            }
        }
    }
}
