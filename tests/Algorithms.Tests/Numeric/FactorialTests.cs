using NUnit.Framework;
using Wingmann.Algorithms.Numeric;

namespace Wingmann.Algorithms.Tests.Numeric;

public static class FactorialTests
{
    [Test]
    [TestCase(5, 120)]
    [TestCase(1, 1)]
    [TestCase(0, 1)]
    [TestCase(4, 24)]
    [TestCase(18, 6402373705728000)]
    [TestCase(10, 3628800)]
    public static void GetsFactorial(int input, long expected) =>
        Assert.AreEqual(expected, Factorial.Calculate(input));

    [Test]
    public static void GetsFactorialExceptionForNonPositiveNumbers([Random(-1000, -1, 10, Distinct = true)] int input)
        => Assert.Throws<ArgumentException>(() => Factorial.Calculate(input));
}
