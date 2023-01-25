using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorter
{
    public class InsertionSort : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>
        {
            var copy = sequenceToSort.ToArray();
            for(var i = 1;i<copy.Length;i++)
            {
                for(var j=i-1; j>=0; j--)
                {
                    if (copy[j].CompareTo(copy[j+1])>0)
                    {
                        var temp = copy[j];
                        copy[j]= copy[j+1];
                        copy[j+1]= temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return copy;
        }
    }
}