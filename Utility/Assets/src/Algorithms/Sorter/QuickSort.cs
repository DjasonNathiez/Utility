using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorter
{
    public class QuickSort : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>
        {
            var enumator = sequenceToSort.GetEnumerator();
            if (!enumator.MoveNext())
            {
                return Enumerable.Empty<T>();
            }

            var pivot = enumator.Current;

            var left = new List<T>();
            var middle = new List<T>{pivot};
            var right = new List<T>();

            while (enumator.MoveNext())
            {
                switch (enumator.Current.CompareTo(pivot))
                {
                    case < 0:
                    {
                        left.Add(enumator.Current);
                        break;
                    }

                    case 0:
                    {
                        middle.Add(enumator.Current);
                        break;
                    }

                    case > 0:
                    {
                        right.Add(enumator.Current);
                        break;
                    }
                }
            }

            return Sort(left).Concat(middle).Concat(Sort(right));
        }
    }
}