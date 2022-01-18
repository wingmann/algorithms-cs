﻿namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Heap sort is a comparison based sorting technique based on Binary Heap data structure.
/// </summary>
public class HeapSorter : IComparisonSorter
{
    /// <summary>
    /// Sorts input array using heap sort algorithm.
    /// </summary>
    /// <param name="array">Input array.</param>
    /// <param name="comparer">Comparer type for elements.</param>
    /// <typeparam name="T">Input array type.</typeparam>
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        var heapSize = array.Length;
        
        for (var p = (heapSize - 1) / 2; p >= 0; p--)
        {
            MakeHeap(array, heapSize, p, comparer);
        }

        for (var i = array.Length - 1; i > 0; i--)
        {
            (array[i], array[0]) = (array[0], array[i]);

            heapSize--;
            MakeHeap(array, heapSize, 0, comparer);
        }
    }

    private static void MakeHeap<T>(IList<T> input, int heapSize, int index, IComparer<T> comparer)
    {
        var rightIndex = index;

        while (true)
        {
            var right = (rightIndex + 1) * 2;
            var left = right - 1;
            var largest = left < heapSize && comparer.Compare(input[left], input[rightIndex]) is 1 ? left : rightIndex;

            // Finds the index of the largest.
            if (right < heapSize && comparer.Compare(input[right], input[largest]) is 1)
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