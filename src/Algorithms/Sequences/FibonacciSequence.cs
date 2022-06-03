using System.Data;
using System.Numerics;
using Algorithms.Sequences.Interfaces;

namespace Algorithms.Sequences;

/// <summary>
/// Implements fibonacci sequence algorithm.
/// <see href="https://wikipedia.org/wiki/Fibonacci_number" />
/// </summary>
public class FibonacciSequence : ISequence
{
    /// <inheritdoc cref="ISequence.Generate"/>
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
