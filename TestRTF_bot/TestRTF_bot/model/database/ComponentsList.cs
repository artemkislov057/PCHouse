using System;
using System.Collections.Generic;
using System.Linq;
using TestRTF_bot.Models;

namespace TestRTF_bot.model.database
{
    public class ComponentsList<T> : SortedReadonlyList<T, int> where T : IComponent
    {
        public ComponentsList(IEnumerable<T> collection, Func<T, int> predicate) : base(collection, predicate)
        {

        }

        public int GetIndexOfMoreOrEqual(int cost)
        {
            for (var i = 0; i < Count; i++)
            {
                if (this[i].Cost >= cost)
                    return i;
            }
            return Count;
        }

        public IEnumerable<T> GetRange(int minCost, int maxCost)
        {
            for (var i = GetIndexOfMoreOrEqual(minCost); i < Count && this[i].Cost <= maxCost; i++)
                yield return this[i];
        }

        public T[] GetRangeArray(int minCost, int maxCost)
        {
            return GetRange(minCost, maxCost).ToArray();
        }
    }
}
