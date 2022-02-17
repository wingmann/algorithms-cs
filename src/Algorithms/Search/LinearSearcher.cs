namespace Algorithms.Search;

/// <summary>
/// Implements linear search algorithm.
/// </summary>
public class LinearSearcher
{
    /// <summary>
    /// Finds first item in array that satisfies specified term.
    /// Time complexity: O(n), space complexity: O(1).
    /// </summary>
    /// <param name="data">Array to search in.</param>
    /// <param name="term">Term to check against.</param>
    /// <typeparam name="T">Type of array element.</typeparam>
    /// <exception cref="ItemNotFoundException"></exception>
    /// <returns>First item that satisfies term.</returns>
    public static T Find<T>(T[] data, Func<T, bool> term)
    {
        foreach (T t in data)
        {
            if (term(t))
            {
                return t;
            }
        }

        throw new ApplicationException("Item not found.");
    }
    
    /// <summary>
    /// Finds index of first item in array that satisfies specified term.
    /// Time complexity: O(n), space complexity: O(1).
    /// </summary>
    /// <param name="data">Array to search in.</param>
    /// <param name="term">Term to check against.</param>
    /// <returns>Index of first item that satisfies term or -1 if none found.</returns>
    public static int FindIndex<T>(T[] data, Func<T, bool> term)
    {
        for (var i = 0; i < data.Length; i++)
        {
            if (term(data[i]))
            {
                return i;
            }
        }

        return -1;
    }
}
