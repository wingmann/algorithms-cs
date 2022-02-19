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
    IEnumerable<BigInteger> Sequence { get; }
}
