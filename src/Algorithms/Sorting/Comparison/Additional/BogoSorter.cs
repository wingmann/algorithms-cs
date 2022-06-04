using System.Collections;
using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison.Additional;

/// <summary>
/// Implements bogo sort algorithm.<br />
/// See <see href="https://en.wikipedia.org/wiki/Bogosort" />.
/// </summary>
public class BogoSorter : IComparisonSorter
{
    private readonly Random _random = new();
    
    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        while (IsSorted(array, comparer) is false)
        {
            Shuffle(array);
        }
    }
    
    private static bool IsSorted<T>(IReadOnlyList<T> array, IComparer<T> comparer)
    {
        for (var i = 0; i < array.Count - 1; i++)
        {
            if (comparer.Compare(array[i], array[i + 1]) > 0)
            {
                return false;
            }
        }

        return true;
    }

    private void Shuffle<T>(IList<T> array)
    {
        var taken = new BitArray(array.Count);
        var newArray = new T[array.Count];
        
        foreach (var t in array)
        {
            int nextPosition;
            
            do
            {
                nextPosition = _random.Next(0, int.MaxValue) % array.Count;
            }
            while (taken[nextPosition]);

            taken[nextPosition] = true;
            newArray[nextPosition] = t;
        }

        for (var i = 0; i < array.Count; i++)
        {
            array[i] = newArray[i];
        }
    }
}
