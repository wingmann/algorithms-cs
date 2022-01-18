using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Implements bubble sort algorithm.
/// </summary>
public class BubbleSorter : IComparisonSorter
{
    /// <summary>
    /// Sorts array using specified comparer, internal, in-place, stable.<br/>
    /// Time complexity: O(n^2), space complexity: O(1), where n - array length.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <param name="comparer">Compares elements.</param>
    /// <typeparam name="T">Type of array element.</typeparam>
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
