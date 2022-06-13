using NUnit.Framework;
using Wingmann.Algorithms.Numeric;
using Wingmann.Algorithms.Strings;

namespace Wingmann.Algorithms.Tests.Strings;

public static class PermutationTests
{
    [TestCase("")]
    [TestCase("A")]
    [TestCase("abcd")]
    [TestCase("aabcd")]
    [TestCase("aabbbcd")]
    [TestCase("aabbbccccd")]
    public static void Test_GetEveryUniquePermutation(string word)
    {
        var permutations = Permutation.GetEveryUniquePermutation(word);
        Dictionary<char, int> occurrence = new();

        foreach (var c in word)
        {
            if (occurrence.ContainsKey(c))
            {
                occurrence[c] += 1;
            }
            else
            {
                occurrence[c] = 1;
            }
        }
        
        var expectedNumberOfAnagrams = Factorial.Calculate(word.Length);
        
        expectedNumberOfAnagrams = occurrence.Aggregate(
            expectedNumberOfAnagrams,
            (current, keyValuePair) => current / Factorial.Calculate(keyValuePair.Value));
        
        Assert.AreEqual(expectedNumberOfAnagrams, permutations.Count);

        var wordSorted = SortString(word);
        
        foreach (var permutation in permutations)
        {
            Assert.AreEqual(wordSorted, SortString(permutation));
        }

        Assert.AreEqual(permutations.Count, new HashSet<string>(permutations).Count);
    }

    private static string SortString(string word)
    {
        var asArray = word.ToArray();
        Array.Sort(asArray);
        return new string(asArray);
    }
}
