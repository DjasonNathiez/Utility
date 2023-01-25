using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorter
{
    public class SelectionSort : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>
        {
            var copy = sequenceToSort.ToList();

            while(copy.Any())
            {
                var candidate = copy.First();
                for(var i = 1; i< copy.Count; i++)
                {
                    if (candidate.CompareTo(copy[i])>0)
                    {
                        candidate = copy[i];
                    }
                }
                yield return candidate;
                copy.Remove(candidate);
            }
        }
    }
}
