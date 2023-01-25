using System;
using System.Collections.Generic;
using System.Linq;

public class BubbleSort : ISorter
{
    public IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>
    {
        var copy = sequenceToSort.ToArray();
        bool sorted;
        var top = copy.Length - 1;
        while(true)
        {
            sorted = true;
            var lastSwap = 0;
            for(var i=0; i<top;i++)
            {
                if(copy[i].CompareTo(copy[i + 1]) > 0)
                {
                    sorted = false;
                    var temp = copy[i];
                    copy[i] = copy[i + 1];
                    copy[i + 1] = temp;
                    lastSwap = i;
                }
            }
            top = lastSwap;
            if(sorted)
            {
                break;
            }
        }
        return copy;
    }
}