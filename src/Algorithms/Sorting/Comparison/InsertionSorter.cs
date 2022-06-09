namespace Wingmann.Algorithms.Sorting.Comparison;

/// <summary>
/// Implements insertion sort algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Insertion_sort">Wikipedia</see>.
/// </summary>
public class InsertionSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var min = i;
            
            for (var j = i + 1; j < array.Length; j++)
            {
                if (comparer.Compare(array[j], array[min]) < 0)
                {
                    min = j;
                }
            }

            (array[min], array[i]) = (array[i], array[min]);
        }
    }
}
