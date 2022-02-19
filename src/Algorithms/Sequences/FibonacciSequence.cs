using System.Numerics;
using Algorithms.Sequences.Interfaces;

namespace Algorithms.Sequences;

/// <summary>
/// Implements fibonacci sequence algorithm.
/// Wikipedia: https://wikipedia.org/wiki/Fibonacci_number.
/// </summary>
public class FibonacciSequence : ISequence
{
    public IEnumerable<BigInteger> Sequence
    {
        get
        {
            yield return 0;
            yield return 1;

            BigInteger previous = 0;
            BigInteger current = 1;

            while (true)
            {
                var next = previous + current;
                previous = current;
                current = next;

                yield return next;
            }
        }
    }
}
