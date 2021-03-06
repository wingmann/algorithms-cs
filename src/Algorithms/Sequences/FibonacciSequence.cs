using System.Numerics;

namespace Wingmann.Algorithms.Sequences;

/// <summary>
/// Implements fibonacci sequence algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Fibonacci_number">Wikipedia</see>.
/// </summary>
public class FibonacciSequence : ISequence
{
    /// <inheritdoc cref="ISequence.Generate" />
    public IEnumerable<BigInteger> Generate(int limit)
    {
        yield return 0;
        yield return 1;

        BigInteger previous = 0;
        BigInteger current = 1;

        while (limit > 0)
        {
            var next = previous + current;
            previous = current;
            current = next;

            limit--;
            yield return next;
        }
    }
}
