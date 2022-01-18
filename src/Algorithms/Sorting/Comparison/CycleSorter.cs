namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Cycle sort is an in-place, unstable sorting algorithm, a comparison sort that is theoretically optimal in
/// terms of the total number of writes to the original array.
/// It is based on the idea that the permutation to be sorted can be factored into cycles,
/// which can individually be rotated to give a sorted result.
/// </summary>
public class CycleSorter : IComparisonSorter
{
    /// <summary>
    /// Sorts input array using cycle sort.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <param name="comparer">Compares elements.</param>
    /// <typeparam name="T">Type of array element.</typeparam>
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            MoveCycle(array, i, comparer);
        }
    }

    private static void MoveCycle<T>(T[] array, int beginIndex, IComparer<T> comparer)
    {
        var item = array[beginIndex];
        var pos = beginIndex + CountSmallerElements(array, beginIndex + 1, item, comparer);

        if (pos == beginIndex)
        {
            return;
        }

        pos = SkipSameElements(array, pos, item, comparer);

        (array[pos], item) = (item, array[pos]);

        while (pos != beginIndex)
        {
            pos = beginIndex + CountSmallerElements(array, beginIndex + 1, item, comparer);
            pos = SkipSameElements(array, pos, item, comparer);

            (array[pos], item) = (item, array[pos]);
        }
    }

    private static int SkipSameElements<T>(IReadOnlyList<T> array, int nextIndex, T item, IComparer<T> comparer)
    {
        while (comparer.Compare(array[nextIndex], item) is 0)
        {
            nextIndex++;
        }

        return nextIndex;
    }

    private static int CountSmallerElements<T>(IReadOnlyList<T> array, int beginIndex, T element, IComparer<T> comparer)
    {
        var smallerElements = 0;
        
        for (var i = beginIndex; i < array.Count; i++)
        {
            if (comparer.Compare(array[i], element) < 0)
            {
                smallerElements++;
            }
        }

        return smallerElements;
    }
}
