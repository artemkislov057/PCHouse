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

        public IEnumerable<T> GetRangeCost(int minCost, int maxCost)
        {
            for (var i = GetIndexOfMoreOrEqual(minCost); i < Count && this[i].Cost <= maxCost; i++)
                yield return this[i];
        }

        public T[] GetRangeCostArray(int minCost, int maxCost)
        {
            return GetRangeCost(minCost, maxCost).ToArray();
        }

        public IEnumerable<T> GetRangeIndex(int leftCost, int range, int percent)
        {
            var index = GetIndexOfMoreOrEqual(leftCost * percent / 100);
            if (index - range < 0)
                index = range;
            for (var i = index - range; i < Count && i < index + range; i++)
                yield return this[i];
        }

        public T[] GetRangeIndexArray(int cost, int range, int percent)
        {
            return GetRangeIndex(cost, range, percent).ToArray();
        }
    }
}
