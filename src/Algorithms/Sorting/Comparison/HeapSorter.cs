namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Heap sort is a comparison based sorting technique based on Binary Heap data structure.
/// </summary>
/// <typeparam name="T">Input array type.</typeparam>
public class HeapSorter<T> : IComparisonSorter<T>
    where T : IComparable<T>
{
    /// <summary>
    /// Sorts input array using heap sort algorithm.
    /// </summary>
    /// <param name="array">Input array.</param>
    /// <param name="comparer">Comparer type for elements.</param>
    public void Sort(T[] array, IComparer<T> comparer) => HeapSort(array, comparer);
    
    private static void HeapSort(IList<T> data, IComparer<T> comparer)
    {
        var heapSize = data.Count;
        
        for (var p = (heapSize - 1) / 2; p >= 0; p--)
        {
            MakeHeap(data, heapSize, p, comparer);
        }

        for (var i = data.Count - 1; i > 0; i--)
        {
            (data[i], data[0]) = (data[0], data[i]);

            heapSize--;
            MakeHeap(data, heapSize, 0, comparer);
        }
    }

    private static void MakeHeap(IList<T> input, int heapSize, int index, IComparer<T> comparer)
    {
        var rightIndex = index;

        while (true)
        {
            var right = (rightIndex + 1) * 2;
            var left = right - 1;
            var largest = left < heapSize && comparer.Compare(input[left], input[rightIndex]) == 1 ? left : rightIndex;

            // Finds the index of the largest.
            if (right < heapSize && comparer.Compare(input[right], input[largest]) == 1)
            {
                largest = right;
            }

            if (largest == rightIndex)
            {
                return;
            }

            // Process of re-heaping/swapping.
            (input[rightIndex], input[largest]) = (input[largest], input[rightIndex]);
            rightIndex = largest;
        }
    }
}
