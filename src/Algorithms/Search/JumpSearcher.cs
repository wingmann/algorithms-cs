namespace Algorithms.Search;

/// <summary>
/// Implements jump search algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Jump_search">Wikipedia</see>.
/// </summary>
public class JumpSearcher : ISearchAlgorithm
{
    /// <inheritdoc cref="ISearchAlgorithm.FindIndex{T}" />
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