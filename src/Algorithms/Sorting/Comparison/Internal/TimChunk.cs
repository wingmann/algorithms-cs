namespace Wingmann.Algorithms.Sorting.Comparison.Internal;

/// <summary>
/// handling gallop merges, allows for tracking array indexes and wins.
/// </summary>
/// <typeparam name="T">Type of array element.</typeparam>
internal class TimChunk<T>
{
    public T[] Array { get; init; } = default!;

    public int Index { get; set; }

    public int Remaining { get; set; }

    public int Wins { get; set; }
}
