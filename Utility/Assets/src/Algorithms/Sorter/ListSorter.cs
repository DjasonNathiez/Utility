using System;
using System.Collections.Generic;
using System.Linq;

public class ListSorter : ISorter
{
    public IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>
    {
        var result = sequenceToSort.ToList();
        result.Sort();

        return result;
    }
}
