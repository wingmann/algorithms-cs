namespace Algorithms.Search;

/// <summary>
/// Jump search checks fewer elements by jumping ahead by fixed steps.
/// The optimal steps to jump is sqrt(n), where n refers to the number of elements in the array.
/// Time Complexity: O(sqrt(n))
/// Note: The array has to be sorted beforehand.
/// </summary>
public static class JumpSearcher
{
    /// <summary>
    /// Find the index of the item searched for in the array.
    /// </summary>
    /// <param name="sortedArray">Sorted array to be search in. Cannot be null.</param>
    /// <param name="searchItem">Item to be search for. Cannot be null.</param>
    /// <typeparam name="T">Type of the array element.</typeparam>
    /// <returns>If item is found, return index. If array is empty or item not found, return -1.</returns>
    public static int FindIndex<T>(T[] sortedArray, T searchItem) where T : IComparable<T>
    {
        if (sortedArray is null)
        {
            throw new ArgumentNullException(nameof(sortedArray));
        }

        if (searchItem is null)
        {
            throw new ArgumentNullException(nameof(searchItem));
        }
        
        var jumpStep = (int)Math.Floor(Math.Sqrt(sortedArray.Length));
        var currentIndex = 0;
        var nextIndex = jumpStep;

        if (sortedArray.Length is 0)
        {
            return -1;
        }

        while (sortedArray[nextIndex - 1].CompareTo(searchItem) < 0)
        {
            currentIndex = nextIndex;
            nextIndex += jumpStep;

            if (nextIndex < sortedArray.Length)
            {
                continue;
            }

            nextIndex = sortedArray.Length - 1;
            break;
        }

        for (var i = currentIndex; i <= nextIndex; i++)
        {
            if (sortedArray[i].CompareTo(searchItem) is 0)
            {
                return i;
            }
        }

        return -1;
    }
}
