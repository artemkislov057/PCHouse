using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model.database
{
    public class SortedReadonlyList<T, TKey> : IReadOnlyList<T>
    {
        public SortedReadonlyList(IEnumerable<T> collection, Func<T, TKey> keySelector)
        {
            list = collection
            .OrderBy(keySelector)
            .ToList();
        }

        private readonly IReadOnlyList<T> list;

        public int Count => list.Count;

        public T this[int index] => list[index];

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public T Min() => list.First();

        public T Max() => list.Last();
    }

}
