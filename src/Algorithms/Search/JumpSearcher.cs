using Algorithms.Search.Interfaces;

namespace Algorithms.Search;

/// <summary>
/// Jump search algorithm.
/// </summary>
public class JumpSearcher : ISearchAlgorithm
{
    /// <summary>
    /// Finds the index of first occurrence of the target item.
    /// </summary>
    /// <param name="data">Array where the element should be found.</param>
    /// <param name="item">Element which should be found.</param>
    /// <typeparam name="T">Comparable type.</typeparam>
    /// <returns>Index of the first occurrence of the target element, or -1 if it is not found.</returns>
    public int FindIndex<T>(T[] data, T item) where T : IComparable<T>
    {
        if (data.Length is 0)
        {
            return -1;
        }

        var jumpStep = (int)Math.Floor(Math.Sqrt(data.Length));
        var currentIndex = 0;
        var nextIndex = jumpStep;

        while (data[nextIndex - 1].CompareTo(item) < 0)
        {
            currentIndex = nextIndex;
            nextIndex += jumpStep;

            if (nextIndex < data.Length)
            {
                continue;
            }

            nextIndex = data.Length - 1;
            break;
        }

        for (var i = currentIndex; i <= nextIndex; i++)
        {
            if (data[i].CompareTo(item) is 0)
            {
                return i;
            }
        }

        return -1;
    }
}
