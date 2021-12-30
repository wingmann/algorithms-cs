﻿namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Implements selection sort algorithm.
/// </summary>
/// <typeparam name="T">Type of array element.</typeparam>
public class SelectionSorter<T> : IComparisonSorter<T>
    where T : IComparable<T>
{
    /// <summary>
    /// Sorts array using specified comparer, internal, in-place, stable.
    /// Time complexity: O(n^2), space complexity: O(1), where n - array length.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <param name="comparer">Compares elements.</param>
    public void Sort(T[] array, IComparer<T> comparer)
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
