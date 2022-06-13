namespace Wingmann.Algorithms.Strings;

/// <summary>
/// Implements string permutation algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Permutation">Wikipedia</see>.
/// </summary>
public static class Permutation
{
    /// <summary>
    /// Collects list of all the permutations of <paramref name="word" />.
    /// </summary>
    /// <param name="word">Input string value.</param>
    /// <returns>List of all the permutations of <paramref name="word" />.</returns>
    public static List<string> GetEveryUniquePermutation(string word)
    {
        if (word.Length < 2)
        {
            return new List<string> { word };
        }

        HashSet<string> result = new();

        for (var i = 0; i < word.Length; i++)
        {
            result.UnionWith(
                GetEveryUniquePermutation(word.Remove(i, 1))
                    .Select(subPerm => word[i] + subPerm)
            );
        }

        return result.ToList();
    }
}
