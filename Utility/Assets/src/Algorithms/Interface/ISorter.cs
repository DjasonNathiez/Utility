using System;
using System.Collections.Generic;

public interface ISorter
{
    IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>;
}