using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorter
{
    public class MergeSort : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> sequenceToSort) where T : IComparable<T>
        {
            if (!sequenceToSort.Skip(1).Any())
            {
                return sequenceToSort;
            }

            var splits = sequenceToSort.Select((element, i) => (element, i))
                .GroupBy(pair => pair.i%2, pair => pair.element).ToArray();

            if (splits.Count() < 2)
            {
                return sequenceToSort;
            }

            return Merge(Sort(splits[0]), Sort(splits[1]));
        }

        private IEnumerable<T> Merge<T>(IEnumerable<T> enumerable1, IEnumerable<T> enumerable2) where T : IComparable<T>
        {
            var enumerator1 = enumerable1.GetEnumerator();
            var enumerator2 = enumerable2.GetEnumerator();

            enumerator1.MoveNext();
            enumerator2.MoveNext();

            while (true)
            {
                if (enumerator1.Current.CompareTo(enumerator2.Current) < 0)
                {
                    yield return enumerator1.Current;
                    
                    if (!enumerator1.MoveNext())
                    {
                        do
                        {
                            yield return enumerator2.Current;
                        } while (enumerator2.MoveNext());
                        
                        yield break;
                    }
                }
                else
                {
                    yield return enumerator2.Current;
                    if (!enumerator2.MoveNext())
                    {
                        do
                        {
                            yield return enumerator1.Current;
                        } while (enumerator1.MoveNext());
                        
                        yield break;
                    }
                }
            }
        }
    }
}