namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Implements insertion sort algorithm.
/// </summary>
public static class InsertionSorter
{
    /// <summary>
    /// Sorts array using specified comparer, internal, in-place, stable.<br/>
    /// Time complexity: O(n^2), space complexity: O(1), where n - array length.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <param name="comparer">Compares elements.</param>
    /// <typeparam name="T">Type of array element.</typeparam>
    public static void Sort<T>(T[] array, IComparer<T> comparer)
        where T : IComparable<T>
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
