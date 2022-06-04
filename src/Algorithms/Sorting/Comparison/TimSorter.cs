using Algorithms.Sorting.Comparison.Interfaces;
using Algorithms.Sorting.Comparison.Internal;

namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Implements hybrid sorting algorithm, derived from merge sort and insertion sort.<br />
/// See <see href="https://en.wikipedia.org/wiki/Timsort" />.
/// </summary>
public class TimSorter : IComparisonSorter
{
    private readonly int _minMerge;
    private readonly int _initMinGallop;
    private readonly int[] _runBase;
    private readonly int[] _runLengths;

    private int _minGallop;
    private int _stackSize;

    public TimSorter()
    {
        _initMinGallop = 7;
        _minMerge = 32;
        _runBase = new int[85];
        _runLengths = new int[85];
        _stackSize = 0;
        _minGallop = 7;
    }

    public TimSorter(int minMerge, int minGallop)
    {
        _initMinGallop = minGallop;
        _minMerge = minMerge;
        _runBase = new int[85];
        _runLengths = new int[85];
        _stackSize = 0;
        _minGallop = minGallop;
    }

    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        var start = 0;
        var remaining = array.Length;

        if (remaining < _minMerge)
        {
            if (remaining < 2)
            {
                // Arrays of size 0 or 1 are always sorted.
                return;
            }

            // Don't need to merge, just binary sort.
            BinarySort(array, start, remaining, start, ref comparer);
            return;
        }

        var minRun = MinRunLength(remaining, _minMerge);

        do
        {
            // Identify next run.
            var runLen = CountRunAndMakeAscending(array, start, ref comparer);

            // If the run is too short extend to Min(MIN_RUN, remaining).
            if (runLen < minRun)
            {
                var force = Math.Min(minRun, remaining);
                BinarySort(array, start, start + force, start + runLen, ref comparer);
                runLen = force;
            }

            _runBase[_stackSize] = start;
            _runLengths[_stackSize] = runLen;
            _stackSize++;

            MergeCollapse(array, ref comparer);

            start += runLen;
            remaining -= runLen;
        }
        while (remaining is not 0);

        MergeForceCollapse(array, ref comparer);
    }

    // Returns the minimum acceptable run length for an array of the specified length.
    // Natural runs shorter than this will be extended.
    private static int MinRunLength(int total, int minRun)
    {
        var r = 0;

        while (total >= minRun)
        {
            r |= total & 1;
            total >>= 1;
        }

        return total + r;
    }

    // Reverse the specified range of the specified array.
    private static void ReverseRange<T>(IList<T> array, int start, int end)
    {
        end--;

        while (start < end)
        {
            var temp = array[start];
            array[start++] = array[end];
            array[end--] = temp;
        }
    }

    // Left shift a value, preventing a roll over to negative numbers.
    // Returns left shifted value, bound to max value of int.
    private static int BoundLeftShift(int shift) => shift << 1 < 0 ? (shift << 1) + 1 : int.MaxValue;

    // Check the chunks before getting in to a merge to make sure there's something to actually do.
    private static bool NeedsMerge<T>(TimChunk<T> left, TimChunk<T> right, ref int destination)
    {
        right.Array[destination++] = right.Array[right.Index++];

        if (--right.Remaining is 0)
        {
            Array.Copy(left.Array, left.Index, right.Array, destination, left.Remaining);
            return false;
        }

        if (left.Remaining is not 1)
        {
            return true;
        }

        Array.Copy(right.Array, right.Index, right.Array, destination, right.Remaining);
        right.Array[destination + right.Remaining] = left.Array[left.Index];

        return false;
    }

    // Moves over the last parts of the chunks.
    private static void FinalizeMerge<T>(TimChunk<T> left, TimChunk<T> right, int dest)
    {
        switch (left.Remaining)
        {
            case 1:
            {
                Array.Copy(right.Array, right.Index, right.Array, dest, right.Remaining);
                right.Array[dest + right.Remaining] = left.Array[left.Index];
                break;
            }
            case 0:
            {
                throw new ArgumentException("Comparison method violates its general contract.");
            }
            default:
            {
                Array.Copy(left.Array, left.Index, right.Array, dest, left.Remaining);
                break;
            }
        }
    }

    // Returns the length of the run beginning at the specified position in the specified array and reverses the run
    // if it is descending (ensuring that the run will always be ascending when the method returns).
    //
    // A run is the longest ascending sequence with: a[lo] <= a[lo + 1] <= a[lo + 2] <= ...
    // or the longest descending sequence with: a[lo] > a[lo + 1] > a[lo + 2] > ...
    //
    // For its intended use in a stable mergesort, the strictness of the definition of "descending" is needed so that
    // the call can safely reverse a descending sequence without violating stability.
    private static int CountRunAndMakeAscending<T>(IList<T> array, int start, ref IComparer<T> comparer)
    {
        var runHi = start + 1;

        if (runHi == array.Count)
        {
            return 1;
        }

        // Find end of run, and reverse range if descending.
        if (comparer.Compare(array[runHi++], array[start]) < 0)
        {
            // Descending
            while (runHi < array.Count && comparer.Compare(array[runHi], array[runHi - 1]) < 0)
            {
                runHi++;
            }

            ReverseRange(array, start, runHi);
        }
        else
        {
            // Ascending
            while (runHi < array.Count && comparer.Compare(array[runHi], array[runHi - 1]) >= 0)
            {
                runHi++;
            }
        }

        return runHi - start;
    }

    // Find the position in the array that a key should fit to the left of where it currently sits.
    private static int GallopLeft<T>(IReadOnlyList<T> array, T key, int i, int len, int hint, ref IComparer<T> comparer)
    {
        var (offset, lastOffset) = comparer.Compare(key, array[i + hint]) switch
        {
            > 0 => RightRun(array, key, i, len, hint, 0, ref comparer),
            _ => LeftRun(array, key, i, hint, 1, ref comparer),
        };

        return FinalOffset(array, key, i, offset, lastOffset, 1, ref comparer);
    }

    // Find the position in the array that a key should fit to the right of where it currently sits.
    private static int GallopRight<T>(IReadOnlyList<T> array, T key, int i, int len, int hint,
        ref IComparer<T> comparer)
    {
        var (offset, lastOffset) = comparer.Compare(key, array[i + hint]) switch
        {
            < 0 => LeftRun(array, key, i, hint, 0, ref comparer),
            _ => RightRun(array, key, i, len, hint, -1, ref comparer),
        };

        return FinalOffset(array, key, i, offset, lastOffset, 0, ref comparer);
    }

    private static (int offset, int lastOfs) LeftRun<T>(IReadOnlyList<T> array, T key, int i, int hint, int lt,
        ref IComparer<T> comparer)
    {
        var maxOfs = hint + 1;
        var (offset, tmp) = (1, 0);

        while (offset < maxOfs && comparer.Compare(key, array[i + hint - offset]) < lt)
        {
            tmp = offset;
            offset = BoundLeftShift(offset);
        }

        if (offset > maxOfs)
        {
            offset = maxOfs;
        }

        var lastOfs = hint - offset;
        offset = hint - tmp;

        return (offset, lastOfs);
    }

    private static (int offset, int lastOfs) RightRun<T>(IReadOnlyList<T> array, T key, int i, int len, int hint,
        int gt, ref IComparer<T> comparer)
    {
        var offset = 1;
        var lastOfs = 0;
        var maxOfs = len - hint;

        while (offset < maxOfs && comparer.Compare(key, array[i + hint + offset]) > gt)
        {
            lastOfs = offset;
            offset = BoundLeftShift(offset);
        }

        if (offset > maxOfs)
        {
            offset = maxOfs;
        }

        offset += hint;
        lastOfs += hint;

        return (offset, lastOfs);
    }

    private static int FinalOffset<T>(IReadOnlyList<T> array, T key, int i, int offset, int lastOfs, int lt,
        ref IComparer<T> comparer)
    {
        lastOfs++;

        while (lastOfs < offset)
        {
            var m = lastOfs + (int)((uint)(offset - lastOfs) >> 1);

            if (comparer.Compare(key, array[i + m]) < lt)
            {
                offset = m;
            }
            else
            {
                lastOfs = m + 1;
            }
        }

        return offset;
    }

    // Sorts the specified portion of the specified array using a binary insertion sort.
    // It requires O(n log n) compares, but O(n^2) data movement.
    private static void BinarySort<T>(T[] array, int start, int end, int first, ref IComparer<T> comparer)
    {
        if (first >= end || first <= start)
        {
            first = start + 1;
        }

        while (first < end)
        {
            var target = array[first];
            var targetInsertLocation = BinarySearch(array, start, first - 1, target, ref comparer);
            Array.Copy(array, targetInsertLocation, array, targetInsertLocation + 1, first - targetInsertLocation);

            array[targetInsertLocation] = target;
            first++;
        }
    }

    private static int BinarySearch<T>(IReadOnlyList<T> array, int left, int right, T target, ref IComparer<T> comparer)
    {
        while (left < right)
        {
            var mid = (left + right) >> 1;

            if (comparer.Compare(target, array[mid]) < 0)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return comparer.Compare(target, array[left]) < 0 ? left : left + 1;
    }

    private void MergeCollapse<T>(T[] array, ref IComparer<T> comparer)
    {
        while (_stackSize > 1)
        {
            var n = _stackSize - 2;
            
            if (n > 0 && _runLengths[n - 1] <= _runLengths[n] + _runLengths[n + 1])
            {
                if (_runLengths[n - 1] < _runLengths[n + 1])
                {
                    n--;
                }

                MergeAt(array, n, ref comparer);
            }
            else if (_runLengths[n] <= _runLengths[n + 1])
            {
                MergeAt(array, n, ref comparer);
            }
            else
            {
                break;
            }
        }
    }

    private void MergeForceCollapse<T>(T[] array, ref IComparer<T> comparer)
    {
        while (_stackSize > 1)
        {
            var n = _stackSize - 2;
            
            if (n > 0 && _runLengths[n - 1] < _runLengths[n + 1])
            {
                n--;
            }

            MergeAt(array, n, ref comparer);
        }
    }

    private void MergeAt<T>(T[] array, int index, ref IComparer<T> comparer)
    {
        var baseA = _runBase[index];
        var lenA = _runLengths[index];
        var baseB = _runBase[index + 1];
        var lenB = _runLengths[index + 1];

        _runLengths[index] = lenA + lenB;

        if (index == _stackSize - 3)
        {
            _runBase[index + 1] = _runBase[index + 2];
            _runLengths[index + 1] = _runLengths[index + 2];
        }

        _stackSize--;

        var k = GallopRight(array, array[baseB], baseA, lenA, 0, ref comparer);

        baseA += k;
        lenA -= k;

        if (lenA <= 0)
        {
            return;
        }

        lenB = GallopLeft(array, array[baseA + lenA - 1], baseB, lenB, lenB - 1, ref comparer);

        if (lenB <= 0)
        {
            return;
        }

        Merge(array, baseA, lenA, baseB, lenB, ref comparer);
    }

    private void Merge<T>(T[] array, int baseA, int lenA, int baseB, int lenB, ref IComparer<T> comparer)
    {
        var endA = baseA + lenA;
        var dest = baseA;

        TimChunk<T> left = new()
        {
            Array = array[baseA..endA],
            Remaining = lenA,
        };

        TimChunk<T> right = new()
        {
            Array = array,
            Index = baseB,
            Remaining = lenB,
        };

        // Move first element of the right chunk and deal with degenerate cases.
        if (NeedsMerge(left, right, ref dest) is false)
        {
            // One of the chunks had 0-1 items in it, so no need to merge anything.
            return;
        }

        var gallop = _minGallop;

        while (RunMerge(left, right, ref dest, ref gallop, ref comparer))
        {
            // Penalize for leaving gallop mode.
            gallop = gallop > 0 ? gallop + 2 : 2;
        }

        _minGallop = gallop >= 1 ? gallop : 1;

        FinalizeMerge(left, right, dest);
    }

    private bool RunMerge<T>(TimChunk<T> left, TimChunk<T> right, ref int dest, ref int gallop,
        ref IComparer<T> comparer)
    {
        // Reset the number of times in row a run wins.
        left.Wins = 0;
        right.Wins = 0;

        // Run a stable merge sort until (if ever) one run starts winning consistently.
        if (StableMerge(left, right, ref dest, gallop, ref comparer))
        {
            // Stable merge sort completed with no viable gallops, time to exit.
            return false;
        }

        // One run is winning so consistently that galloping may be a huge win.
        // So try that, and continue galloping until (if ever) neither run appears to be winning consistently anymore.
        do
        {
            if (GallopMerge(left, right, ref dest, ref comparer))
            {
                // Galloped all the way to the end, merge is complete.
                return false;
            }

            // We had a bit of a run, so make it easier to get started again.
            gallop--;
        }
        while (left.Wins >= _initMinGallop || right.Wins >= _initMinGallop);

        return true;
    }

    private static bool StableMerge<T>(TimChunk<T> left, TimChunk<T> right, ref int dest, int gallop,
        ref IComparer<T> comparer)
    {
        do
        {
            if (comparer.Compare(right.Array[right.Index], left.Array[left.Index]) < 0)
            {
                right.Array[dest++] = right.Array[right.Index++];
                right.Wins++;
                left.Wins = 0;

                if (--right.Remaining is 0)
                {
                    return true;
                }
            }
            else
            {
                right.Array[dest++] = left.Array[left.Index++];
                left.Wins++;
                right.Wins = 0;

                if (--left.Remaining is 1)
                {
                    return true;
                }
            }
        }
        while ((left.Wins | right.Wins) < gallop);

        return false;
    }

    private static bool GallopMerge<T>(TimChunk<T> left, TimChunk<T> right, ref int dest, ref IComparer<T> comparer)
    {
        left.Wins = GallopRight(left.Array, right.Array[right.Index], left.Index, left.Remaining, 0, ref comparer);

        if (left.Wins is not 0)
        {
            Array.Copy(left.Array, left.Index, right.Array, dest, left.Wins);
            dest += left.Wins;
            left.Index += left.Wins;
            left.Remaining -= left.Wins;

            if (left.Remaining <= 1)
            {
                return true;
            }
        }

        right.Array[dest++] = right.Array[right.Index++];

        if (--right.Remaining is 0)
        {
            return true;
        }

        right.Wins = GallopLeft(right.Array, left.Array[left.Index], right.Index, right.Remaining, 0, ref comparer);

        if (right.Wins is not 0)
        {
            Array.Copy(right.Array, right.Index, right.Array, dest, right.Wins);

            dest += right.Wins;
            right.Index += right.Wins;
            right.Remaining -= right.Wins;

            if (right.Remaining is 0)
            {
                return true;
            }
        }

        right.Array[dest++] = left.Array[left.Index++];

        return --left.Remaining is 1;
    }
}
