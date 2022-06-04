namespace Algorithms.Strings;

/// <summary>
/// Implements Knuth–Morris–Pratt string search algorithm.
/// <see href="https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm" />
/// </summary>
public static class KmpSearcher
{
    /// <summary>
    /// Search substring start index.
    /// Worst case time complexity: O(n + k), where n - text length, k - pattern length.
    /// </summary>
    /// <param name="data">The string to look in.</param>
    /// <param name="pattern">The pattern to look for.</param>
    /// <returns>
    /// The zero-based positions of all occurrences of <paramref name="pattern" /> in <paramref name="data" />.
    /// </returns>
    public static IEnumerable<int> FindIndexes(string data, string pattern)
    {
        var longest = FindLongestPrefixSuffixValues(pattern);

        for (int i = 0, j = 0; i < data.Length;)
        {
            if (pattern[j] == data[i])
            {
                j++;
                i++;
            }

            if (j == pattern.Length)
            {
                yield return i - j;
                j = longest[j - 1];
                
                continue;
            }

            if (i >= data.Length || pattern[j] == data[i])
            {
                continue;
            }

            if (j is not 0)
            {
                j = longest[j - 1];
            }
            else
            {
                i += 1;
            }
        }
    }
    
    /// <summary>
    /// Gets the longest prefix suffix values for pattern.
    /// </summary>
    /// <param name="pattern">Pattern to seek.</param>
    /// <returns>The longest prefix suffix values for <paramref name="pattern" />.</returns>
    public static int[] FindLongestPrefixSuffixValues(in string pattern)
    {
        var longest = new int[pattern.Length];
        
        for (int i = 1, length = 0; i < pattern.Length;)
        {
            if (pattern[i] == pattern[length])
            {
                length++;
                longest[i] = length;
                i++;
                
                continue;
            }

            if (length is not 0)
            {
                length = longest[length - 1];
            }
            else
            {
                longest[i] = 0;
                i++;
            }
        }

        return longest;
    }
}
