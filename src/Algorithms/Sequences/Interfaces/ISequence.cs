using System.Numerics;

namespace Algorithms.Sequences.Interfaces;

/// <summary>
/// Common interface for all integral sequences.
/// </summary>
public interface ISequence
{
    /// <summary>
    /// Gets sequence as enumerable.
    /// </summary>
    /// <param name="limit">Upper bound generation limit.</param>
    /// <returns>Sequence of integer values.</returns>
    IEnumerable<BigInteger> Generate(int limit);
}
