using Algorithms.Sequences;
using FluentAssertions;
using NUnit.Framework;
using System.Numerics;

namespace Algorithms.Tests.Sequences;

public static class FibonacciSequenceTests
{
    [Test]
    public static void First10ElementsCorrect() => new FibonacciSequence()
        .Generate(100)
        .Take(10)
        .SequenceEqual(new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })
        .Should()
        .BeTrue();
}
