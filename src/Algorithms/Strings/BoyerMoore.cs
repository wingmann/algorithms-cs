namespace Wingmann.Algorithms.Strings;

/// <summary>
/// Implements Boyer-Moore string search algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Boyer-Moore_string-search_algorithm">Wikipedia</see>.
/// </summary>
public static class BoyerMoore
{
    /// <summary>
    /// Finds the index of the first occurrence of the pattern p in t.
    /// </summary>
    /// <param name="data">Input text.</param>
    /// <param name="pattern">Search pattern.</param>
    /// <returns>Index of the pattern in text or -1 if the pattern  was not found.</returns>
    public static int FindFirstOccurrence(string data, string pattern)
    {
        var dataLength = data.Length;
        var patternLength = pattern.Length;
        
        // For each symbol of the alphabet, the position of its rightmost occurrence in the pattern,
        // or -1 if the symbol does not occur in the pattern.
        var badChar = BadCharacterRule(pattern, patternLength);

        // Each entry goodSuffix[i] contains the shift distance of the pattern
        // if a mismatch at position i – 1 occurs, i.e. if the suffix of the pattern starting at position i has matched.
        var goodSuffix = GoodSuffixRule(pattern, patternLength);

        // Index in text.
        var i = 0;

        // Index in pattern.
        int j;

        while (i <= dataLength - patternLength)
        {
            // Starting at end of pattern.
            j = patternLength - 1;

            // While matching.
            while (j >= 0 && pattern[j] == data[i + j])
            {
                j--;
            }

            // Pattern found.
            if (j < 0)
            {
                return i;
            }

            // Pattern is shifted by the maximum of the values given by the good-suffix and the
            // bad-character heuristics.
            i += Math.Max(goodSuffix[j + 1], j - badChar[data[i + j]]);
        }

        // Pattern not found.
        return -1;
    }
    
    // Finds out the position of its rightmost occurrence in the pattern for each symbol of the alphabet,
    // or -1 if the symbol does not occur in the pattern.
    private static int[] BadCharacterRule(string pattern, int patternLength)
    {
        // For each character (note that there are more than 256 characters)
        var badChar = new int[256];
        Array.Fill(badChar, -1);

        // Iterate from left to right over the pattern.
        for (var j = 0; j < patternLength; j++)
        {
            badChar[pattern[j]] = j;
        }

        return badChar;
    }
    
    // Finds out the shift distance of the pattern if a mismatch at position i – 1 occurs
    // for each character of the pattern, i.e. if the suffix of the pattern starting at position i has matched.
    private static int[] GoodSuffixRule(string pattern, int patternLength)
    {
        // The matching suffix occurs somewhere else in the pattern
        // --> matching suffix is a border of a suffix of the pattern.

        // f[i] contains starting position of the widest border of the suffix of the pattern beginning at position i.
        var f = new int[pattern.Length + 1];

        // Suffix of p[m] has no border --> f[m] = m+1.
        f[patternLength] = patternLength + 1;

        // Corresponding shift distance.
        var s = new int[pattern.Length + 1];

        // Start of suffix including border of the pattern.
        var i = patternLength;

        // Start of suffix of the pattern.
        var j = patternLength + 1;

        while (i > 0)
        {
            // Checking if a shorter border that is already known can be extended to the left by the same symbol.
            while (j <= patternLength && pattern[i - 1] != pattern[j - 1])
            {
                if (s[j] == 0)
                {
                    s[j] = j - i;
                }

                j = f[j];
            }

            --i;
            --j;
            f[i] = j;
        }

        // Only a part of the matching suffix occurs at the beginning of the pattern (filling remaining entries).
        j = f[0];
        
        for (i = 0; i <= patternLength; i++)
        {
            // Starting position of the greatest border.
            if (s[i] is 0)
            {
                s[i] = j;
            }

            // From position i = j, it switches to the next narrower border f[j]
            if (i == j)
            {
                j = f[j];
            }
        }

        return s;
    }
}
