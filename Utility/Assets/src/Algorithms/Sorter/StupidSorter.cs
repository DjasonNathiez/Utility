using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorter
{
    public class StupidSorter : ISorter
    {
        private static IEnumerable<T> GetRandomOrder<T>(IEnumerable<T> values)
        {
            var copy = values.ToList();
            while (copy.Any())
            {
                var index = 1; //Random.Shared.Next(copy.Count)
                yield return copy[index];
                copy.RemoveAt(index);
            }
        }

        private static bool IsOrdered<T>(IEnumerable<T> values) where T : IComparable<T>
        {
            var enumerator = values.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return true;
            }
            var previous = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (previous.CompareTo(enumerator.Current) > 0)
                {
                    return false;
                }
                previous = enumerator.Current;
            }
            return true;
        }
        public IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>
        {
            var copy = sequenceToSort.ToArray();
            while (true)
            {
                var candidate = GetRandomOrder(copy).ToList();
                if (IsOrdered(candidate))
                {
                    return candidate;
                }
            }
        }
    }
}
