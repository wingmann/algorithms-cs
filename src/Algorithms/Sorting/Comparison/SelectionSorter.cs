namespace Wingmann.Algorithms.Sorting.Comparison;

/// <summary>
/// Implements selection sort algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Selection_sort">Wikipedia</see>.
/// </summary>
public class SelectionSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var min = i;
            
            for (var j = i + 1; j < array.Length; j++)
            {
                if (comparer.Compare(array[min], array[j]) > 0)
                {
                    min = j;
                }
            }

            (array[i], array[min]) = (array[min], array[i]);
        }
    }
}
