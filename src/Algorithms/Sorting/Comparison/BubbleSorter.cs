using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Implements bubble sort algorithm.
/// <see href="https://en.wikipedia.org/wiki/Bubble_sort" />
/// </summary>
public class BubbleSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}"/>
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var wasChanged = false;
            
            for (var j = 0; j < array.Length - i - 1; j++)
            {
                if (comparer.Compare(array[j], array[j + 1]) <= 0)
                {
                    continue;
                }
                
                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                wasChanged = true;
            }

            if (wasChanged is false)
            {
                break;
            }
        }
    }
}
