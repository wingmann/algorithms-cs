using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison.Additional;

/// <summary>
/// Implements pancake sort algorithm.
/// </summary>
public class PancakeSorter : IComparisonSorter
{
    /// <summary>
    /// Sorts array using specified comparer, internal, in-place, stable.
    /// Time complexity: O(n^2), space complexity: O(1), where n - array length.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <param name="comparer">Compares elements.</param>
    /// <typeparam name="T">Type of array element.</typeparam>
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        var n = array.Length;

        // Start from the complete array and one by one reduce current size by one.
        for (var currSize = n; currSize > 1; --currSize)
        {
            // Find index of the maximum element in array[0..curr_size-1].
            var mi = FindMax(array, currSize, comparer);

            // Move the maximum element to end of current array if it's not already at  the end.
            if (mi == currSize - 1)
            {
                continue;
            }
            
            // To move to the end, first move maximum number to beginning.
            Flip(array, mi);

            // Now move the maximum number to end by reversing current array.
            Flip(array, currSize - 1);
        }
    }

    // Reverses array[0..i]
    private static void Flip<T>(IList<T> array, int i)
    {
        var start = 0;
        
        while (start < i)
        {
            (array[start], array[i]) = (array[i], array[start]);
            start++;
            i--;
        }
    }

    // Returns index of the maximum element in array[0..n-1].
    private static int FindMax<T>(IReadOnlyList<T> array, int n, IComparer<T> comparer)
    {
        var mi = 0;
        
        for (var i = 0; i < n; i++)
        {
            if (comparer.Compare(array[i], array[mi]) is 1)
            {
                mi = i;
            }
        }

        return mi;
    }
}
