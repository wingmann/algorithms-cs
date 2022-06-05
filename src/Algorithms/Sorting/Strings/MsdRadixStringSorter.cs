namespace Algorithms.Sorting.Strings;

/// <summary>
/// Implements most significant digit radix string sorting algorithm.
/// See on <see href="https://www.geeksforgeeks.org/msd-most-significant-digit-radix-sort">GeeksForGeeks</see>.
/// </summary>
public class MsdRadixStringSorter : IStringSorter
{
    /// <inheritdoc cref="IStringSorter.Sort" />
    public void Sort(string[] array) =>
        Sort(array, 0, array.Length - 1, 0, new string[array.Length]);
    
    private static void Sort(IList<string> array, int l, int r, int d, IList<string> temp)
    {
        if (l >= r)
        {
            return;
        }

        const int k = 256;
        var count = new int[k + 2];
        
        for (var i = l; i <= r; i++)
        {
            var j = Key(array[i]);
            count[j + 2]++;
        }

        for (var i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        for (var i = l; i <= r; i++)
        {
            var j = Key(array[i]);
            temp[count[j + 1]++] = array[i];
        }

        for (var i = l; i <= r; i++)
        {
            array[i] = temp[i - l];
        }

        for (var i = 0; i < k; i++)
        {
            Sort(array, l + count[i], l + count[i + 1] - 1, d + 1, temp);
        }

        int Key(string s) => d >= s.Length ? -1 : s[d];
    }
}
