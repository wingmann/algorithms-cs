namespace Algorithms.Search.Interfaces;

/// <summary>
/// Common interface of most search algorithms.
/// </summary>
public interface ISearchAlgorithm
{
    /// <summary>
    /// Finds the index of first occurrence of the target item.
    /// </summary>
    /// <param name="data">Array where the element should be found.</param>
    /// <param name="item">Element which should be found.</param>
    /// <typeparam name="T">Comparable type.</typeparam>
    /// <returns>Index of the first occurrence of the target element, or -1 if it is not found.</returns>
    int FindIndex<T>(T[] data, T item) where T : IComparable<T>;
}
