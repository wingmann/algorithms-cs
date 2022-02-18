using Algorithms.Strings;
using NUnit.Framework;

namespace Algorithms.Tests.Strings;

public class BoyerMooreTests
{
    [TestCase("HelloIamATestcaseAndIWillPass", "Testcase", 9)]
    [TestCase("HelloIamATestcaseAndImCaseSensitive", "TestCase", -1)]
    [TestCase("Hello I am a testcase and I work with whitespaces", "testcase", 13)]
    public void FindFirstOccurrence_IndexCheck(string t, string p, int expectedIndex)
    {
        var resultIndex = BoyerMoore.FindFirstOccurrence(t, p);
        Assert.AreEqual(resultIndex, expectedIndex);
    }
}
